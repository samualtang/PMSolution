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
          
             pbInfo_Click(null, null);  
            robotService = new RobotTaskService(); 
          CreateOpcClinet();
        }

   
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
                //连接服务器


                //socketCore.ReceiveTimeout = 5000;//5秒没有响应则算连接超时
                connectSuccess = true;
                ////异步接受来自服务端的信息
                socketCore.BeginReceive(buffer, 0, 2048, SocketFlags.None, new AsyncCallback(ReceiveCallBack), socketCore);
                if (socketCore.Connected)
                { 
                    FmInfo.GetTaskInfo("机器人：服务器连接成功！");
                    lblServerInfo.Text = "机器人服务器连接成功！";
                }
                else
                {
                    FmInfo.GetTaskInfo("机器人：服务器连接失败！");
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
            string[] strmessage = plc.ConnectionToPLC();//创建plc连接
            //strmessage[1] = "1";
         
            FmInfo.GetGroup(plc.UnNormalGroup);//传入OPC组到信息显示界面
            if (strmessage[1] == "1")
            {
                CreateState = false;
                FmInfo.GetTaskInfo("opC创建失败！");
               
            }
            else
            {
                CreateState = false;
                FmInfo.GetTaskInfo("opC创成功！");
               
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
                    msg = msg.Substring(start, end);
                    string[] arrData = msg.Trim().Split(',');
                    string outStr = "";//错误信息
                    if (arrData[0].ToLower() == "f")//F头部 代表机器人完成
                    { 
                        //S  所在的位置 单抓 3 双抓 5

                        if (msg.Contains("|"))//如果包含双抓
                        {
                            if (arrData[4].ToLower() == "s")//s头部 代表机器人状态
                            {
                                if (arrData[5].Replace('\0', ' ').Trim() == "1")
                                {
                                    FmInfo.GetTaskInfo("机器人：读取到自动运行状态开启！");
                                    RoBotState = true;
                                }
                                else
                                {
                                    FmInfo.GetTaskInfo("机器人：读取到状态为：" + arrData[5] + "0为自动运行状态关闭");
                                    RoBotState = false;
                                    return;
                                }
                            }
                            else
                            {
                                FmInfo.GetTaskInfo("机器人:异常收到来自机器人的信息，位置为4的索引不为S");
                            }
                            FmInfo.GetTaskInfo("机器人：收到双抓完成");
                            string[] newArr = msg.Substring(2).Trim().Split('|');
                            if (newArr.Length == 2)
                            {
                                for (int i = 0; i < newArr.Length; i++)
                                {
                                    string[] arr = newArr[i].Trim().Split(',');
                                    robotService.UpDateFinishTask(arr, out outStr);
                                    if (!string.IsNullOrWhiteSpace(outStr))
                                    {
                                        FmInfo.GetTaskInfo("机器人： " + outStr);
                                    }
                                    else
                                    {
                                        FmInfo.GetTaskInfo("机器人：任务号" + arr[0] + "，条烟流水号：" + arr[1] + "，数据库更新完成！");
                                    }
                                }
                                if (!string.IsNullOrWhiteSpace(outStr))//如果更新任务无异常 则发送任务
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
                                string flag = arrData[4].Replace('\0', ' ').Trim();
                                if (flag == "1")
                                {
                                    FmInfo.GetTaskInfo("机器人：读取到自动运行状态开启！");
                                    RoBotState = true;
                                }
                                else
                                {
                                    FmInfo.GetTaskInfo("机器人：读取到状态为：" + arrData[4] + "0为自动运行状态关闭");
                                    RoBotState = false;
                                    return;
                                }
                            }
                            else
                            {
                                FmInfo.GetTaskInfo("机器人:异常收到来自机器人的信息，位置为3的索引不为S");
                            }
                            FmInfo.GetTaskInfo("机器人：收到单抓完成信号");
                            string[] Arr = msg.Substring(2).Trim().Split(',');
                            if (Arr[1] == "0")
                            {
                                return;
                            }
                            robotService.UpDateFinishTask(Arr, out outStr);
                            if (!string.IsNullOrWhiteSpace(outStr))
                            { 
                                FmInfo.GetTaskInfo("机器人： " + outStr);
                            }
                            else//无错误的情况下 发送任务
                            {
                                FmInfo.GetTaskInfo("机器人：任务号" + Arr[0] + "，条烟流水号：" + Arr[1] + "，数据库更新完成！");
                            }
                        }
                    }
                    //else if (arrData[0] == "S")//S头部 代表机器人状态
                    //{
                    //    string[] newArr = msg.Substring(2).Trim().Split(',');
                    //    if (newArr[0] == "1")
                    //    { 
                    //        FmInfo.GetTaskInfo("机器人：读取到自动运行状态开启！");
                    //        RoBotState = true;
                    //    }
                    //    else if (newArr[0] == "0")
                    //    {
                    //        FmInfo.GetTaskInfo("机器人：读取到自动运行状态关闭！");
                    //        RoBotState = false;
                    //    }
                    //}
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

        #region  TCPIP连接
  
        private async Task   ConnectionAsync()
        {
           
            string ErrMsg =  await Task.Run( ()=> CreateDataChange()); //创建 

            if (string.IsNullOrWhiteSpace(ErrMsg) )//事件创建成功
            {  
                FmInfo.GetTaskInfo("启动定时器");
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
              //  pbStart.Enabled = false;
                pbStart.Cursor = Cursors.No;
              //  pbStop.Enabled = true;
                pbStop.Cursor = Cursors.Hand;

            }
            else if(i == 2)//暂停任务
            {
             //   pbStart.Enabled = true;
                pbStart.Cursor = Cursors.Hand;
               // pbStop.Enabled = false;
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
                if (socketCore == null)//如果与服务器断开连接，则重新创建
                {
                    CreateSocketClinet(); 
                }  
                thread = new Thread(new ThreadStart( SendRobotTask))//机器人任务发送
                {
                    IsBackground = true
                   
                };
                thread.Start(); 
         
                try
                {
                    if( CreateState) { 
                    plc.ShapeGroup1.callback += OnDataChange;
                    plc.ShapeGroup2.callback += OnDataChange;
                    //常规烟翻版
                    plc.ShapeGroup3.callback += OnDataChange;
                    plc.ShapeGroup4.callback += OnDataChange;
                    FmInfo.GetTaskInfo("倍速链，翻版，通信事件绑定成功");
                    }
                    //异型烟倍速链
                    else
                    {
                        return "异型烟链板机触发事件绑定失败";
                    }
                }
                catch (Exception ex)
                {
                    FmInfo.GetTaskInfo("异型烟链板机触发事件绑定失败");
                    return ex.Message;
                }
               
                return "";
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
                        this.lblServerInfo .Invoke((Action)(() => this.lblServerInfo.Text = "与PA服务器断开连接，正在重连第" + times + "次...")); 
                        socketCore = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//使用TCPip协议
                        socketCore.Connect(IPAddress.Parse(GlobalPara.RobitPlc_Ip), int.Parse(GlobalPara.RobitPlc_Port));
                        if (socketCore.Connected)
                        { 
                            SendRobotTask();
                            socketCore.BeginReceive(buffer, 0, 2048, SocketFlags.None, new AsyncCallback(ReceiveCallBack), socketCore);
                            connectSuccess = true;
                            break;
                        }
                        continue;
                    } 
                    times = 0;
                }
                catch (Exception e)
                {
                    //TCPLogger.Log("CheckAlive异常.", e);
                }
                Thread.Sleep(500);
            }
        } 
        /// <summary>
        /// 机器人任务数组
        /// </summary>
        byte[] bytes = null;
        string copyTaskInfo="";
        /// <summary>
        /// 发送机器人任务
        /// </summary>
        /// <returns></returns>
        void SendRobotTask()
        {
            FmInfo.GetTaskInfo("机器人：五秒后发送机器人任务");
            Thread.Sleep(5000);
        aa: if (RoBotState)//读取机器人状态为自动运行
            {
           
                try
                {
                    
                    //如果有新增的任务就一直循环取出来发送该条任务，直到该条任务做完，切换下一条任务
                    while (connectSuccess  )//发送机制：取出当前第一条未完成的任务，间隔一秒发送一次，直到这条任务完成，跳到下一条任务！
                    {
                    //获取机器人任务
                    bb: string taskInfo = robotService.GetRobotInfo(out string outStr); 
                        bytes = Encoding.ASCII.GetBytes(taskInfo);
                      
                        if (string.IsNullOrWhiteSpace(taskInfo))
                        {
                            FmInfo.GetTaskInfo("机器人：任务发送完毕");
                            break;
                        }
                        try
                        {
                            if(isClientConnected(socketCore))
                            {
                                socketCore?.Send(bytes, 0, bytes.Length, SocketFlags.None);//发送数据
                                
                                    FmInfo.GetTaskInfo("机器人：发送数据，任务：" + taskInfo);
                               
                                
                            }
                            else 
                            {
                                connectSuccess = false;
                                FmInfo.GetTaskInfo("机器人：远程主机强制断开一个现有连接，发送任务失败！");
                                CheckAlive();
                            }
                            copyTaskInfo = taskInfo;
                        }
                        catch (Exception ex)
                        { 
                            FmInfo.GetTaskInfo("机器人：任务发送停止,未知错误："+ ex.Message + "\r\n"+ outStr+"任务将在10秒后重新发送！");
                            Thread.Sleep(10000);//暂停10秒后 继续读取
                            goto bb;
                             
                        } 
                        Thread.Sleep(1000); // 一秒后再次发送
                    }
                    
                   
                }
                catch (Exception ex)
                { 
                    FmInfo.GetTaskInfo("发送机器人任务方法，未知错误：" + ex.Message);
                    goto aa;
                }
            }
            else
            {
                FmInfo.GetTaskInfo("机器人自动运行状态为关闭,十秒之后再次检测机器人状态");
                Thread.Sleep(10000);//十秒之后再次检测机器人状态
                goto aa;
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
                this.Close();

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
                EnabletStartAndStop(2);
                CloseDataChange();
            }
        }

        /// <summary>
        /// 断开通信连接
        /// </summary>
        void CloseDataChange()
        {
            if (socketCore != null)
            {
                //complexClient.AcceptString -= ComplexClient_AcceptString;//收到文本时 触发事件 
                //complexClient.MessageAlerts -= ComplexClient_MessageAlerts;//服务器的异常，启动，等等一般消息产生的时候，出发此事件
                connectSuccess = false;
                socketCore.Close();
                socketCore  = null;
                FmInfo.GetTaskInfo("断开与机器人的连接！");
                try
                {
                    
                    plc.ShapeGroup1.callback -= OnDataChange;
                    plc.ShapeGroup2.callback -= OnDataChange;
                    FmInfo.GetTaskInfo("异型烟链板机断开连接！");
                }
                catch(NullReferenceException nuller)
                {
                    FmInfo.GetTaskInfo("OPC未能创建成功！"+nuller.Message);
                }
                catch (Exception)
                {
                    FmInfo.GetTaskInfo("异型烟链板机任务停止失败！");
                }
                FmInfo.Func(2);
                FmInfo.GetTaskInfo("任务停止发送与接收！");
            }
            else
            {
                FmInfo.GetTaskInfo("请先连接服务器！");
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
            if (group == 1)//任务发送块组
            {
                for (int i = 0; i < clientId.Length; i++)
                {
                    if (clientId[i] == 8)//接收信号位
                    {
                    
                        int packtasknum = int.Parse(plc.ShapeGroup1.Read(0).ToString());//任务号
                        int tempvalue = int.Parse(plc.ShapeGroup1.Read(7).ToString());//接收信号
                        if (tempvalue == 0)//如果有接收信号
                        {
                            try
                            { 
                                FmInfo.AutoRefreshShow(packtasknum);//更新垛型展示
                                //读取接收信号的任务 数据库置接收 
                                if (plc.UpDateToYxyState(packtasknum,15))
                                {
                                    FmInfo.GetTaskInfo("链板机收到任务号" +packtasknum +"，更新已接收！");
                                }
                                else
                                {
                                    FmInfo.GetTaskInfo("链板机收到任务号" + packtasknum + "，更新失败！");
                                }
                                //更改标志位 写入新任务
                                var x = await Task.Run(() => plc.WriteTaskSend_YXY()); 
                                index++;
                                GlobalPara.GlbobaIndex = index;
                            }
                            catch (Exception ex)
                            {
                                FmInfo.GetTaskInfo("服务器连接失败！" + ex.Message);
                                return;
                            }
                        }
                    }
                }
            }
           else if (group == 2)//完成信号块组
            {
                for (int i = 0; i < clientId.Length; i++)
                {
                    //完成任务号
                    int tempvalue = int.Parse(values[i].ToString());
                    if (tempvalue > 0)
                    {
                        try
                        {
                            if (tempvalue != 0)
                            {
                                FmInfo.GetTaskInfo("任务号" + tempvalue + "完成");
                                plc. ShapeGroup2.Write(0, i);
                                FmInfo.GetTaskInfo(plc.ReadAndWriteYXYTaskConpelte(tempvalue, i));//更新数据库 更新DB块
                            }
                        }
                        catch (Exception ex)
                        {
                            FmInfo.GetTaskInfo("服务器连接失败！" + ex.Message);
                            return;
                        }
                    }
                }
            }
            else if (group == 3)//常规烟翻版任务交互
            {
                for (int i = 0; i < clientId.Length; i++)
                {
                    if (clientId[i] == 8)//接收信号位
                    {

                        int packtasknum = int.Parse(plc.ShapeGroup3.Read(0).ToString());//任务号
                        int tempvalue = int.Parse(plc.ShapeGroup4.Read(6).ToString());//接收信号
                        if (tempvalue == 0)//如果有接收信号
                        {
                            try
                            { 
                                //读取接收信号的任务 数据库置接 收 
                                FmInfo.GetTaskInfo(packtasknum + "收到任务"); 
                                //更改标志位 写入新任务
                                var x = await Task.Run(() => plc.WriteTaskSend_CGY());
                                index++;
                                GlobalPara.GlbobaIndex = index;
                            }
                            catch (Exception ex)
                            {
                                FmInfo.GetTaskInfo("服务器连接失败！" + ex.Message);
                                return;
                            }
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
 

 


    }
}
