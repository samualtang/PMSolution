using Functions.Model;
using Functions.PubFunction;
using HslCommunication.Enthernet;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication;
using System.Net; 
using System.Threading;
using Functions.BLL;
using System.Text;
using System.Linq;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;
using System.Collections.Generic;

namespace PackageMachine
{
    public partial class FmMain : Form
    {
       
        public FmMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            CheckForIllegalCrossThreadCalls = false;
        
            plc = new Functions.OPC_ToPLC();
            Text = "[" + GlobalPara.PackageNo + "号]包装机系统 版本" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
             pbInfo_Click(null, null);  
            robotService = new RobotTaskService();

          CreateOpcClinet();
            modbus = new Modbus();
        }

        Modbus modbus;
        /// <summary>
        /// 服务创建成功标志
        /// </summary>
        bool CreateState = false;
        /// <summary>
        /// 任务信息界面
        /// </summary>
        FmInfo frm = null;
        #region OPC字段
        /// <summary>
        /// OPC服务类
        /// </summary>
        Functions.OPC_ToPLC plc;
        #endregion

        #region 机器人
        /// <summary>
        /// 机器人任务处理类
        /// </summary>
        RobotTaskService robotService = null;
        /// <summary>
        /// 机器人状态
        /// </summary>
        bool RoBotState = false;
        /// <summary>
        /// 机器人： 后台发送机器人任务的线程
        /// </summary>
        private Thread thread = null;             
        /// <summary>
        /// 机器人：通信基类
        /// </summary>
        private Socket socketCore = null;

        /// <summary>
        /// 机器人：连接标志
        /// </summary>
        private bool connectSuccess = false;
        /// <summary>
        /// 机器人：字符串大小
        /// </summary>
        private byte[] buffer = new byte[2048];
        #endregion
        /// <summary>
        /// Socket服务器连接
        /// </summary>
        void CreateSocketClinet()
        { 
            if (!IPAddress.TryParse(GlobalPara.RobitPlc_Ip, out IPAddress address))
            { 
                FmInfo.GetTaskInfo("Robit_IP地址填写不正确");
                return;
            }
            if (!int.TryParse(GlobalPara.RobitPlc_Port, out int port))
            { 
                FmInfo.GetTaskInfo("Robit_Port地址填写不正确");
                return;
            }
            try
            {
                socketCore?.Close();
              
                socketCore = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//使用TCPip协议
                socketCore.Connect(IPAddress.Parse(GlobalPara.RobitPlc_Ip), int.Parse(GlobalPara.RobitPlc_Port));
                connectSuccess = false;
                new Thread(() =>
                {
                     //
                     Thread.Sleep(2000);
                    if (!connectSuccess) socketCore?.Close();//如果连接失败，这里将会跳入到心跳检测
                 }).Start(); 
                connectSuccess = true;
                ////异步接受来自服务端的信息
                socketCore.BeginReceive(buffer, 0, 2048, SocketFlags.None, new AsyncCallback(ReceiveCallBack), socketCore);
                if (socketCore.Connected)
                { 
                    FmInfo.GetTaskInfo("机器人：服务器连接成功！");
                    lblServerInfo.Text = "机器人服务器连接成功！";
                    thread = new Thread(new ThreadStart(SendRobotTask))//机器人任务发送
                    {
                        IsBackground = true

                    };
                    thread.Start();
                }
                else
                {
                    FmInfo.GetTaskInfo("机器人：服务器连接失败！");
                    lblServerInfo.Text = "机器人：服务器连接失败！";
                } 
              
            }
            catch (Exception ex)
            {
                FmInfo.GetTaskInfo(ex.Message); 
            }
        }
        /// <summary>
        /// OPC服务连接
        /// </summary>
        void CreateOpcClinet()
        { 
            string[] strmessage = plc.CreateOPCServer();//创建plc连接
            if (string.IsNullOrWhiteSpace(strmessage[0]))
            {
                FmInfo.GetTaskInfo("opC服务器创成功！");
                FmInfo.GetTaskInfo("尝试连接异型烟链板机和常规烟翻版");
                if (plc.CheckYXYConnection())
                {
                    FmInfo.GetTaskInfo("倍速链:PLC连接成功!"); 
                    FmInfo.GetGroup(plc.UnNormalGroup, plc.ShapeGroup7);//传入OPC组到信息显示界面
                    CreateState = true;
                }
                else
                {
                    FmInfo.GetTaskInfo("倍速链:PLC连接失败!");
                    CreateState = false;

                }
                if (plc.CheckFbConnction())
                {
                    FmInfo.GetTaskInfo("翻板:PLC连接成功!");
                    CreateState = true;
                }
                else
                {
                    FmInfo.GetTaskInfo("翻板:PLC连接失败!");
                    CreateState = false;
                } 
            }
            else
            {
                FmInfo.GetTaskInfo("OPC服务创建失败，错误："+strmessage[0]);
                CreateState = false;
            }
 
 
        }
        bool CheckRobotRunState(string falg)
        {
            if (falg == "1")
            { 
                updateLabel("机器人状态：开启", lblRobotState);
                FirstSend = false;
                return    RoBotState = true;
            }
            else if( falg == "2")//2标识 当前任务往前跳发送一个
            {
                flag = false;
                robotService.UpdateLastPacktaskNumCigstate();
                FmInfo.GetTaskInfo("机器人：收到标识2，重发前一个任务！");
                flag = true;
                updateLabel("机器人状态：开启", lblRobotState);
                return RoBotState = true;
            }
            {  
                updateLabel("机器人状态：关闭", lblRobotState);
                return  RoBotState = false;
                 
            }
        }

        /// <summary>
        /// 判断是否处于连接状态
        /// </summary>
        /// <param name="ClientSocket"></param>
        /// <returns></returns>
        public bool isClientConnected(Socket ClientSocket)
        {
            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();

            TcpConnectionInformation[] tcpConnections = ipProperties.GetActiveTcpConnections();

            foreach (TcpConnectionInformation c in tcpConnections)
            {
                TcpState stateOfConnection = c.State;

                if (c.LocalEndPoint.Equals(ClientSocket.LocalEndPoint) && c.RemoteEndPoint.Equals(ClientSocket.RemoteEndPoint))
                {
                    if (stateOfConnection == TcpState.Established)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 处理完成信号标志
        /// </summary>
        bool flag = true;
        /// <summary>
        /// 响应来自服务端的信息
        /// </summary>
        /// <param name="ar"></param>
        private void ReceiveCallBack(IAsyncResult ar)
        {
            try
            {
               
                int length = socketCore.EndReceive(ar);//结束挂起的异步读取
                //开始异步接受来自服务端的信息
                socketCore.BeginReceive(buffer, 0, 2048, SocketFlags.None, new AsyncCallback(ReceiveCallBack), socketCore); 
                if (length == 0) return; 
                byte[] data = new byte[length];
                Array.Copy(buffer, 0, data, 0, length);
                Invoke(new Action(() =>
                {
                    string msg = string.Empty; 
                     msg = Encoding.ASCII.GetString(data);//对获取的数据进行编码转换  //传输的数据会有乱码 
                    if (msg.Length <= 0)// \0\0\0\0\0\\0\0\0\0\0\0\0\0\0\0\0
                        return;
                    int start = msg.IndexOf("F");//从F开始截取
                    int end = msg.IndexOf("\0");//从 \0后截取结束
                    if(start < 0)
                    {
                        return;
                    }
                    msg = msg.Substring(start, end);
                    string[] arrData = msg.Trim().Split(',');
                    string outStr = "";//错误信息
                    if (arrData[0].ToLower() == "f")//F头部 代表机器人完成
                    {
                       
                        if (GlobalPara.JugValueEqualsLastOne(msg))//如果数据与上一次的相等 则不做任何操作
                        {
                            return;
                        }
                      
                        //S  所在的位置 单抓 3 双抓 5
                        if (msg.Contains("|"))//如果包含双抓
                        {
                            if (arrData[4].ToLower() == "s")//s头部 代表机器人状态
                            { 
                                if(!CheckRobotRunState(arrData[5].Replace('\0', ' ').Trim()))
                                {
                                    return;
                                }
                            }
                            else
                            {
                                FmInfo.GetTaskInfo("机器人:异常收到来自机器人的信息，位置为4的索引不为S,"+ msg);
                            }  
                          
                            string[] newArr = msg.Substring(2).Trim().Split('|');
                            if (newArr.Length == 2)
                            {
                                flag = false;
                                string[] arr1 = newArr[0].Trim().Split(',');
                                string[] arr2 = newArr[1].Trim().Split(',');
                                List<string[]> arrlist = new List<string[]>();
                                arrlist.Add(arr1);
                                arrlist.Add(arr2);
                                robotService.UpDateFinishTasks(arrlist, out outStr);
                                //robotService.UpDateFinishTask(arr1, out outStr);//y 修改为一起修改 20190709
                                //robotService.UpDateFinishTask(arr2, out outStr);
                                FmInfo.AutoRefreshUnShow(Convert.ToDecimal( arr2[0]),Convert.ToInt32( arr2[1]));
                                FmInfo.FuncAutoRefsh();//更新显示界面
                                flag = true;
                                //FmInfo.AutoRefreshUnShow(int.Parse(arr2[0]));
                                if (!string.IsNullOrWhiteSpace(outStr))
                                {
                                    FmInfo.GetTaskInfo("机器人： " + outStr);
                                }
                                else
                                {
                                    FmInfo.GetTaskInfo("机器人：任务号" + arr1[0] + "，条烟流水号：" + arr1[1] + "，数据库更新完成！");
                                    FmInfo.GetTaskInfo("机器人：任务号" + arr2[0] + "，条烟流水号：" + arr2[1] + "，数据库更新完成！");
                                    updateLabel("机器人：任务号" + arr2[0] + "，条烟流水号：" + arr2[1] + "，数据库更新完成！", lblFinshiTask);
                              
                                }
                                
                                if (!string.IsNullOrWhiteSpace(outStr))//
                                {
                                    FmInfo.GetTaskInfo(outStr);
                                }
                              
                            }
                            else
                            {
                                FmInfo.GetTaskInfo("机器人：双抓任务完成信号有误,完成信号长度为" + newArr.Length);
                            }
                        }
                        else//单抓的情况下
                        {
                            if (arrData[3].ToLower() == "s")
                            {
                                if(!CheckRobotRunState( arrData[4].Replace('\0', ' ').Trim()))
                                {
                                    return   ;
                                }
                            }
                            else
                            {
                                FmInfo.GetTaskInfo("机器人:异常收到来自机器人的信息，位置为3的索引不为S,"+msg);
                            } 
                            updateLabel("机器人：收到单抓完成信号", lblFinshiTask);
                            string[] Arr = msg.Substring(2).Trim().Split(',');
                            if (Arr[1] == "0")
                            {
                                return;
                            }
                            flag = false;
                            robotService.UpDateFinishTask(Arr, out outStr);
                            flag = true;
                            FmInfo.AutoRefreshUnShow(Convert.ToDecimal(Arr[0]), Convert.ToInt32(Arr[1]));
                            FmInfo.FuncAutoRefsh();//更新显示界面
                            // FmInfo.AutoRefreshUnShow(int.Parse(Arr[0]));
                            if (!string.IsNullOrWhiteSpace(outStr))
                            { 
                                FmInfo.GetTaskInfo("机器人： " + outStr);
                            }
                            else 
                            {
                                FmInfo.GetTaskInfo("机器人：任务号" + Arr[0] + "，条烟流水号：" + Arr[1] + "，数据库更新完成！"); 
                                updateLabel("机器人：任务号" + Arr[0] + "，条烟流水号：" + Arr[1] + "，数据库更新完成！", lblFinshiTask);
                           
                            }
                        }
                    }
                
                }));
            }
            catch (ObjectDisposedException)
            {

            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                  FmInfo.GetTaskInfo("机器人：服务器断开连接。" + ex.Message );
                    //ThreadHeartCheck();
                }));
            }
        }


        
        private delegate void HandleDelegate1(string info, Label label);
        public void updateLabel(string info, Label label)
        { 
            if (label.InvokeRequired)
            {
                label.Invoke(new HandleDelegate1(updateLabel), new Object[] { info, label });
            }
            else
            {
                label.Text = info;

            }
        }
        #region  按钮事件
        private void pbInfo_Click(object sender, EventArgs e)
        {
            frm = new FmInfo();
            if (CheckExist(frm) == true)
            {
                frm.Dispose();
                frm = null;
                return;
            }
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
           
        }

        private void pbDx_Click(object sender, EventArgs e)
        {
           
        }
        
        private void pbUnionS_Click(object sender, EventArgs e)
        {
            FmOrderInfo frm = new FmOrderInfo();
            if (CheckExist(frm) == true)
            {
                frm.Dispose();
                frm = null;
                return;
            }
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill; 
            frm.Show();
        }

        private void pbConnSet_Click(object sender, EventArgs e)
        {
            FmSystemSetup frm = new FmSystemSetup();
            if (CheckExist(frm) == true)
            {
                frm.Dispose();
                frm = null;
                return;
            }
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void pbSize_Click(object sender, EventArgs e)
        {
            FmCommoditySize frm = new FmCommoditySize();
            if (CheckExist(frm) == true)
            {
                frm.Dispose();
                frm = null;
                return;
            }
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private bool CheckExist(Form frm)
        {
            bool blResult = false;
            for (int i = 0; i < MdiChildren.Length; i++)
            {
                if (MdiChildren[i].GetType().Name == frm.GetType().Name)
                {
                    Form tmpFrm = MdiChildren[i];
                    if (tmpFrm.Text == frm.Text)
                    {
                        blResult = true;
                        tmpFrm.Activate();
                    }
                    else if (frm.Text == "")
                    {
                        blResult = true;
                        tmpFrm.Activate();
                    }
                    else if (frm.GetType().Name.ToLower() == "FmInfo")
                    {
                        blResult = true;
                        tmpFrm.Activate();
                    }
                }
            }
            return blResult;
        }

        private void pbStart_Click(object sender, EventArgs e)
        {
            if(pbStart.Cursor == Cursors.No)
            {
                return;
            }
     
            if (!CreateState)
            {
                FmInfo.GetTaskInfo("必须在所有服务创建成功后，才能开始任务！");
                return;
            }
            try
            { 
                 ConnectionAsync();//异步开始创建事件 
            }
            catch (NotSupportedException EX)
            {
                FmInfo.GetTaskInfo("NotSupportedException错误:" + EX.Message);
                
            }
            catch(Exception ex)
            {
               FmInfo. GetTaskInfo("Exception错误:" + ex.Message);
            }
        }
        #endregion

        #region   连接 创建事件
        
        private async Task   ConnectionAsync()
        {
           
            string ErrMsg =  await Task.Run( ()=> CreateDataChange()); //创建 
          
            FmInfo.GetTaskInfo(plc.ReadAndWriteCGYTaskConpelte());//获取常规烟未取走完成信号
            FmInfo.GetTaskInfo(plc.ReadAndWriteYXYTaskConpelte());//获取异形烟未取走完成信号
            if (string.IsNullOrWhiteSpace(ErrMsg) )//事件创建成功
            {  
                if (modbus.Connection())
                {
                    FmInfo.GetTaskInfo("modbus连接成功！");
                   Task.Run(()=> modbus.ReadAsync());
                }
                else
                {
                    FmInfo.GetTaskInfo("modbus连接失败！");
                }
                FmInfo.GetTaskInfo("启动定时器，触发倍速链，翻版跳变！");
                FmInfo.Func(1);
                EnabletStartAndStop(1);
                timer1.Interval = 5000;
                timer1.Start(); //启动定时器
            }
            else
            {
                FmInfo.GetTaskInfo("客户端初始化失败！错误：" + ErrMsg);
            }
            
            FmInfo.Func(1);
            EnabletStartAndStop(1);
        }
        /// <summary>
        /// 启用开始任务和暂停任务
        /// </summary>
        /// <param name="i">1是开始任务，2是暂停任务</param>
        void EnabletStartAndStop(int i)
        {
            if( i == 1) //开始任务
            {
              
                pbStart.Cursor = Cursors.No;
              
                pbStop.Cursor = Cursors.Hand;

            }
            else if(i == 2)//暂停任务
            {
              
                pbStart.Cursor = Cursors.Hand;
              
                pbStop.Cursor = Cursors.No;
            }
        }
        /// <summary>
        /// 创建数据变化事件r
        /// </summary> 
        /// <returns></returns>
        string CreateDataChange()
        { 
            try
            {
                string ErrMsg = "";
                if (socketCore == null)//如果与服务器断开连接，则重新创建
                {
                    CreateSocketClinet();
                   
                }
                try
                {
                    if (plc.CheckYXYConnection())
                    {
                        //异型烟倍速链
                      //  plc.ShapeGroup1.callback += OnDataChange;
                        plc.ShapeGroup2.callback += OnDataChange;//完成信号
                     
                    }
                    else
                    {
                        ErrMsg += "异型烟倍速事件链绑定失败，未连接至PLC";
                    }
                    if (plc.CheckFbConnction())
                    {
                        //常规烟翻版
                        plc.ShapeGroup3.callback += OnDataChange; // 完成信号
                                                                  //  plc.ShapeGroup4.callback += OnDataChange;
                    }
                    else
                    {
                        ErrMsg += "常规烟翻版事件绑定失败，未连接至PLC";
                    }
                    plc.SpyGroup6.callback += OnDataChange;//添加监控的标志位的
                    FmInfo.GetTaskInfo("倍速链，翻版，通信事件绑定成功"); 
                    //异型烟倍速链 
                }
                catch (Exception ex)
                {
                    FmInfo.GetTaskInfo("触发事件绑定失败");
                    return ex.Message;
                }
               
                return ErrMsg;
            }
            catch (Exception ex)
            { 
                return ex.Message;
            } 
        }


        /// <summary>
        /// 心跳检测，断线重连
        /// </summary>
        private void CheckAlive()
        {
            int times = 0;//重连次数 
            Thread.Sleep(10000);
            while (true)
            {
                try
                {
                    Thread.Sleep(1000);
                    if (!isClientConnected(socketCore))
                    {
                        //MessageBox.Show("断线，正在重连");
                        times++;
                       // this.lblServerInfo .Invoke((Action)(() => this.lblServerInfo.Text = "与PA服务器断开连接，正在重连第" + times + "次..."));
                        updateLabel("与机器人服务器断开连接，正在重连第" + times + "次...", lblServerInfo);
                        socketCore = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//使用TCPip协议
                        socketCore.Connect(IPAddress.Parse(GlobalPara.RobitPlc_Ip), int.Parse(GlobalPara.RobitPlc_Port));
                        if (socketCore.Connected)
                        {
                           
                            socketCore.BeginReceive(buffer, 0, 2048, SocketFlags.None, new AsyncCallback(ReceiveCallBack), socketCore);
                            connectSuccess = true;
                            SendRobotTask();
                            updateLabel("机器人服务器重连连接成功！", lblServerInfo);
                            break;
                        } 
                    } 
                    times = 0;
                }
                catch (Exception e)
                {
                   
                }
                Thread.Sleep(500);
            }
        } 
        /// <summary>
        /// 机器人任务数组
        /// </summary>
        byte[] bytes = null;

        /// <summary>
        /// 标记是否第一次发送
        /// </summary>
        bool FirstSend =true;
        /// <summary>
        /// 发送机器人任务
        /// </summary>
        /// <returns></returns>
        void SendRobotTask()
        {
            FmInfo.GetTaskInfo("机器人：一秒后发送机器人任务");
            Thread.Sleep(1000);
        sendTask: if (RoBotState)//读取机器人状态为自动运行
            {
           
                try
                {
                    
                    //如果有新增的任务就一直循环取出来发送该条任务，直到该条任务做完，切换下一条任务
                    while (connectSuccess  )//发送机制：取出当前第一条未完成的任务，间隔一秒发送一次，直到这条任务完成，跳到下一条任务！
                    {
                        //获取机器人任务
                        while (!flag)
                        {
                            FmInfo.GetTaskInfo("机器人：处理完成信号中");
                        }
                        if( FirstSend)//如果是第一次发送
                        {
                            robotService.UpdateLastPacktaskNumCigstate();
                            FirstSend = false;
                        }
                        CreateTask: string taskInfo = robotService.GetRobotInfo(out string outStr); 
                        bytes = Encoding.ASCII.GetBytes(taskInfo);
                        if (!RoBotState)//如果中途接收到机器人状态为 关闭状态 ，则停止发送任务
                        {
                            goto sendTask;
                        }
                        if (string.IsNullOrWhiteSpace(taskInfo))
                        {
                           // FmInfo.GetTaskInfo("机器人：任务发送完毕");
                            lblTask.Text = "机器人：任务发送完毕";
                            break;
                        }
                        try
                        {
                            if(isClientConnected(socketCore))
                            {
                                socketCore?.Send(bytes, 0, bytes.Length, SocketFlags.None);//发送数据 
                                if (!GlobalPara.JugValueEqualsLastOne2(taskInfo))
                                {
                                    FmInfo.GetTaskInfo("机器人：发送数据，任务：" + taskInfo);
                                }                                               // 
                                lblTask.Text = "机器人：发送任务：" + taskInfo;
                            }
                            else 
                            {
                                connectSuccess = false;
                                FmInfo.GetTaskInfo("机器人：远程主机强制断开一个现有连接，发送任务失败！");
                                lblServerInfo.Text = "机器人：服务器连接失败！";
                                CheckAlive();//断开连接 间隔
                            }
                         
                        }
                        catch (Exception ex)
                        { 
                            FmInfo.GetTaskInfo("机器人：任务发送停止,未知错误："+ ex.Message + "\r\n"+ outStr+"任务将在10秒后重新发送！");
                            Thread.Sleep(10000);//暂停10秒后 继续读取
                            goto CreateTask;
                             
                        } 
                       Thread.Sleep(80); // 0.05秒后再次发送
                    }
                    
                   
                }
                catch (Exception ex)
                { 
                    FmInfo.GetTaskInfo("机器人：任务方法，未知错误：" + ex.Message);
                    goto sendTask;
                }
            }
            else
            {
                //FmInfo.GetTaskInfo("机器人自动运行状态为关闭,十秒之后再次检测机器人状态");
                lblTask.Text = "机器人：自动运行状态为关闭,一秒之后再次检测机器人状态";
             
               Thread.Sleep(1000);//十秒之后再次检测机器人状态
                goto sendTask;
            }
        }
       
        #endregion

   

    

        private void pbExit_Click(object sender, EventArgs e)
        {
          
            DialogResult MsgBoxResult = MessageBox.Show("确定要退出程序?",//对话框的显示内容 
                                                          "确认完成后再关闭，否则可能会导致任务丢失！",//对话框的标题 
                                                          MessageBoxButtons.YesNo,//定义对话框的按钮，这里定义了YSE和NO两个按钮 
                                                          MessageBoxIcon.Question,//定义对话框内的图表式样，这里是一个黄色三角型内加一个感叹号 
                                                          MessageBoxDefaultButton.Button2);//定义对话框的按钮式样
            if (DialogResult.Yes == MsgBoxResult)
            {
                CloseDataChange();
                FmInfo.GetTaskInfo("程序关闭！");
                Close();

            }
        }

        private void pbStop_Click(object sender, EventArgs e)
        {
            if (pbStop.Cursor == Cursors.No)
            {
                return;
            }
            DialogResult MsgBoxResult = MessageBox.Show("确定要停止发送任务?",//对话框的显示内容 
                                                        "操作提示",//对话框的标题 
                                                        MessageBoxButtons.YesNo,//定义对话框的按钮，这里定义了YSE和NO两个按钮 
                                                        MessageBoxIcon.Question,//定义对话框内的图表式样，这里是一个黄色三角型内加一个感叹号 
                                                        MessageBoxDefaultButton.Button2);//定义对话框的按钮式样
            if (DialogResult.Yes == MsgBoxResult)
            {
             
                CloseDataChange();
                EnabletStartAndStop(2);
            }
        }

        /// <summary>
        /// 断开通信连接
        /// </summary>
        void CloseDataChange()
        {
            if (socketCore != null)
            {
                connectSuccess = false;
                modbus.DisConnection();
                RoBotState = false;
                socketCore.Close();
                socketCore = null; 
                FirstSend = true;
                FmInfo.GetTaskInfo("断开与机器人的连接！");
            }
            else
            {
                FmInfo.GetTaskInfo("请先连接服务器！");
            }
            try
            {
                plc.ShapeGroup1.callback -= OnDataChange;
                plc.ShapeGroup2.callback -= OnDataChange;
                plc.ShapeGroup3.callback -= OnDataChange;
                plc.ShapeGroup4.callback -= OnDataChange;
                plc.SpyGroup6.callback -= OnDataChange;
                FmInfo.GetTaskInfo("异型烟倍速链，常规烟翻版移除事件成功！");
                FmInfo.Func(2);
                FmInfo.GetTaskInfo("任务停止发送与接收！");
            }
            catch (NullReferenceException nuller)
            {
                FmInfo.GetTaskInfo("OPC未能创建成功！" + nuller.Message);
            }
            catch (Exception ex)
            {
                FmInfo.GetTaskInfo("异型烟链板机任务停止失败！错误："+ex.Message);
            }


        }


        int index = 1;
        /// <summary>
        /// plc数据发生改变时触发事件
        /// </summary>
        /// <param name="group">plc的DB块组</param>
        /// <param name="clientId">DB块集合</param>
        /// <param name="values">返回的值</param>
        public async void OnDataChange(int group, int[] clientId, object[] values)
        {
            #region
            //if (group == 1)//倍速链 任务发送块组
            //{
            //    for (int i = 0; i < clientId.Length; i++)
            //    {
            //        if (clientId[i] == 8)//接收信号位
            //        {

            //            int packtasknum = int.Parse(plc.ShapeGroup1.Read(0).ToString());//任务号
            //            int tempvalue = int.Parse(plc.ShapeGroup1.Read(7).ToString());//接收信号
            //            if (tempvalue == 0)//如果有接收信号
            //            {
            //                try
            //                {
            //                    //FmInfo.AutoRefreshShow(packtasknum);//更新垛型展示
            //                    //读取接收信号的任务 数据库置接收 
            //                    if (packtasknum > 0)
            //                    {
            //                        if (plc.UpDateToYxyState(packtasknum, 15))
            //                        {
            //                            FmInfo.GetTaskInfo("链板机收到任务号" + packtasknum + "，更新已接收！");
            //                        }
            //                        else
            //                        {
            //                            FmInfo.GetTaskInfo("链板机收到任务号" + packtasknum + "，更新失败！");
            //                        }
            //                    }
            //                    //更改标志位 写入新任务
            //                    var x = await Task.Run(() => plc.WriteTaskSend_YXY());
            //                }
            //                catch (Exception ex)
            //                {
            //                    FmInfo.GetTaskInfo("服务器连接失败！" + ex.Message);
            //                    return;
            //                }
            //            }
            //        }
            //    }
            //}
            //else
            #endregion
            if (group == 2)//异型烟倍速链 完成信号块组
            {
                for (int i = 0; i < clientId.Length; i++)
                {
                    //完成任务号
                    int tempvalue = int.Parse(values[i].ToString());
                    if (tempvalue > 0)
                    {
                        //try
                        //{
                            if (tempvalue != 0)
                            {
                                FmInfo.GetTaskInfo("异型烟倍速链：任务号" + tempvalue + "完成"); 
                                FmInfo.GetTaskInfo(plc.ReadAndWriteYXYTaskConpelte(tempvalue, i));//更新数据库 更新DB块
                               // FmInfo.AutoRefreshShow(tempvalue);//更新跺形显示 暂时用常规烟任务号刷新(2019/04/26)
                            }
                        //}
                        //catch (Exception ex)
                        //{
                        //    FmInfo.GetTaskInfo("异型烟倍速链：服务器连接失败！" + ex.Message);
                        //    return;
                        //}
                    }
                }
            }

            if (group == 3)//常规烟 完成信号块组
            {
                for (int i = 0; i < clientId.Length; i++)
                {
                    //完成任务号
                    int tempvalue = int.Parse(values[i].ToString());
                    if (tempvalue > 0)
                    {
                        //try
                        //{
                            if (tempvalue != 0)
                            {
                                FmInfo.GetTaskInfo("常规烟翻版：任务包号" + tempvalue + "完成");
                                FmInfo.GetTaskInfo(plc.ReadAndWriteCGYTaskConpelte(tempvalue, i));//更新数据库 更新DB块
                                FmInfo.AutoRefreshShow(tempvalue);//更新跺形显示
                            }
                        //}
                        //catch (Exception ex)
                        //{
                        //    FmInfo.GetTaskInfo("常规烟翻版：服务器连接失败！" + ex.Message);
                        //    return;
                        //}
                    }
                }
            }
            else if (group == 6)//标志位监控组
            {
                for (int i = 0; i < clientId.Length; i++)
                {
                    if (clientId[i] == 1)//倍速链任务
                    {
                        if (values[i] != null && int.Parse(values[i].ToString()) == 0)//接收
                        {
                            int tasknum = plc.ShapeGroup1.ReadD(0).CastTo(-1);//读取到包号
                            if (tasknum > 0)
                            {
                                plc.UpDateToYxyState(tasknum, 15);//更新任务为接收
                                FmInfo.GetTaskInfo("异型烟倍速链：任务包号：" + tasknum + "已经接收！");

                            }
                            //if (plc.startatg)
                            //{
                            //    FmInfo.GetTaskInfo("倍速链，任务已经处于发送状态，接收到多的跳变信号！");
                            //    return;
                            //}
                            string x = await plc.WriteTaskSend_YXY();
                            FmInfo.GetTaskInfo(x);
                        }
                    }
                    else

                    if (clientId[i] == 2)//常规烟 翻版任务
                    {
                        if (values[i] != null && int.Parse(values[i].ToString()) == 0)//接收
                        {
                            int tasknum = plc.ShapeGroup4.ReadD(0).CastTo(-1);//读取到包号
                            if (tasknum > 0)
                            {
                                plc.UpDateToCgyState(tasknum, 15);//更新任务为接收
                                FmInfo.GetTaskInfo("常规烟翻版：任务包号：" + tasknum + "已经接收！");

                            }
                            //if (plc.startatg)
                            //{
                            //    FmInfo.GetTaskInfo("常规烟，任务已经处于发送状态，接收到多的跳变信号！");
                            //    return;
                            //}
                            string x = await plc.WriteTaskSend_CGY();
                            FmInfo.GetTaskInfo(x);
                        }
                    }
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            FmInfo.GetTaskInfo("触发定时器，"+plc.timerSendTask());
            timer1.Stop();
        }
       
        private void FmMain_SizeChanged(object sender, EventArgs e)
        {
           
            if (Width < 1409)
            {
                Width = 1409;
            }
            if (Height < 780)
            {
                Height = 780;
            }
          
            Location = new System.Drawing.Point(0, 0);
        }

        private void FmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult MsgBoxResult = MessageBox.Show("确定要关闭程序?\r\n ",//对话框的显示内容 
                                                        "操作提示",//对话框的标题 
                                                        MessageBoxButtons.YesNo,//定义对话框的按钮，这里定义了YSE和NO两个按钮 
                                                        MessageBoxIcon.Question,//定义对话框内的图表式样，这里是一个黄色三角型内加一个感叹号 
                                                        MessageBoxDefaultButton.Button2);//定义对话框的按钮式样
            if (DialogResult.Yes == MsgBoxResult)
            {
                Dispose();
                Close();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FmInfo.FuncAutoRefsh();
        }

        private void pbstatus_Click(object sender, EventArgs e)
        {
            Fm_StatusSearch frm = new Fm_StatusSearch();
            if (CheckExist(frm) == true)
            {
                frm.Dispose();
                frm = null;
                return;
            }
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }
    }
}
