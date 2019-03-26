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

namespace PackageMachine
{
    public partial class FmMain : Form
    {
        Functions.OPC_ToPLC plc;
        public FmMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            CheckForIllegalCrossThreadCalls = false;
        
            plc = new Functions.OPC_ToPLC();
          
             pbInfo_Click(null, null); 
          
            robotService = new RobotTaskService();
        }
        FmInfo frm = null;
        /// <summary>
        /// 机器人任务处理类
        /// </summary>
        RobotTaskService robotService = null;
        /// <summary>
        /// 服务创建成功标志
        /// </summary>
        bool CreateState = false;
        /// <summary>
        /// 机器人状态
        /// </summary>
        bool RoBotState = false;
        /// <summary>
        ///  后台发送机器人任务的线程
        /// </summary>
        private Thread thread = null;             
        /// <summary>
        /// 通信基类
        /// </summary>
        private Socket socketCore = null;

        /// <summary>
        /// 连接标志
        /// </summary>
        private bool connectSuccess = false;
        /// <summary>
        /// 字符串大小
        /// </summary>
        private byte[] buffer = new byte[2048];
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
                connectSuccess = false;  
                //new Thread(() =>
                //{
                //    //
                //    Thread.Sleep(2000);
                //    if (!connectSuccess) socketCore?.Close();//如果连接失败，这里将会跳入到心跳检测
                //}).Start();
                //连接服务器
                socketCore.Connect(IPAddress.Parse(GlobalPara.RobitPlc_Ip), int.Parse(GlobalPara.RobitPlc_Port));
              
                //socketCore.ReceiveTimeout = 5000;//5秒没有响应则算连接超时
                connectSuccess = true;
                ////异步接受来自服务端的信息
                socketCore.BeginReceive(buffer, 0, 2048, SocketFlags.None, new AsyncCallback(ReceiveCallBack), socketCore);
                if (socketCore.Connected)
                { 
                    FmInfo.GetTaskInfo("机器人服务器连接成功！");
                }
                else
                {
                    FmInfo.GetTaskInfo("机器人服务器连接失败！");
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
            string[] strmessage = new string[2];// plc.ConnectionToPLC();//创建plc连接
            strmessage[1] = "1";
            GlobalPara.GlbobaIndex = 1;
            FmInfo.GetGroup(plc.UnNormalGroup);//传入OPC组到信息显示界面
            if (strmessage[1] == "1")
            {
                FmInfo.GetTaskInfo("opC创建失败！");
               
            }
            else
            {
                FmInfo.GetTaskInfo("opC创成功！");
               
            }
        }
        string b = "";
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
              //  Array.Copy(buffer, 0, data, 0, length);
                Invoke(new Action(() =>
                {
                    string msg = string.Empty; 
                     msg = Encoding.ASCII.GetString(buffer);//对获取的数据进行编码转换 
                    string[] arrData = msg.Trim().Split(',');
                    string outStr = "";//错误信息
                    if (arrData[0] == "F")//F头部 代表机器人完成
                    {
                        //if (!RoBotState)
                        //{
                        //    FmInfo.GetTaskInfo("读取机器人自动运行状态关闭！");
                        //    return;
                        //}
                        if (msg.Contains("|"))//如果包含双抓
                        {
                            FmInfo.GetTaskInfo("收到双抓完成");
                            
                            string[] newArr = msg.Substring(2).Trim().Split('|');
                            if (newArr.Length == 2)
                            {
                                for (int i = 0; i < newArr.Length; i++)
                                {
                                    string[] arr = newArr[i].Trim().Split(',');
                                    robotService.UpDateFinishTask(arr, out outStr);
                                    if (!string.IsNullOrWhiteSpace(outStr))
                                    {
                                        FmInfo.GetTaskInfo("任务包号数据更新失败错误：" + outStr);
                                    }
                                    else
                                    {
                                        FmInfo.GetTaskInfo("任务包号" + arr[0] + "完成，数据库更新完成！");
                                    }
                                }
                                if (!string.IsNullOrWhiteSpace(outStr))//如果更新任务无异常 则发送任务
                                {
                                    FmInfo.GetTaskInfo(outStr);
                                }
                                else//发送任务
                                {



                                    //SendRobotTask();
                                }
                            }
                            else
                            {
                                FmInfo.GetTaskInfo("双抓任务完成信号有误,完成信号长度为" + newArr.Length);
                            }
                        }
                        else//单抓的情况下
                        {
                            FmInfo.GetTaskInfo("收到单抓完成信号");
                            string[] newArr = msg.Substring(2).Trim().Split(',');
                            b = newArr[0];
                            FmInfo.GetTaskInfo("任务号第"+robotIndex +"条 "+ newArr[0] + "任务号！  完成");
                            string[] finishtask = a.Substring(2).Trim().Split(',');
                            if(b  == finishtask[0])
                            {
                                robotIndex++;
                            
                            }
                           
                            return;
                            //robotService.UpDateFinishTask(newArr, out outStr);
                            if (string.IsNullOrWhiteSpace(outStr))
                            {

                                FmInfo.GetTaskInfo(outStr);
                            }
                            else//无错误的情况下 发送任务
                            {
                                FmInfo.GetTaskInfo("任务包号" + newArr[0] + "完成，数据库更新完成！");
                                //SendRobotTask();
                            }
                        }
                    }
                    else if (arrData[0] == "S")//S头部 代表机器人状态
                    {
                        string[] newArr = msg.Substring(2).Trim().Split(',');
                        if (newArr[0] == "1")
                        { 
                            FmInfo.GetTaskInfo("读取到自动运行状态开启！");
                            RoBotState = true;
                        }
                        else if (newArr[0] == "0")
                        {
                            FmInfo.GetTaskInfo("读取到自动运行状态关闭！");
                            RoBotState = false;
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
                  FmInfo.GetTaskInfo( "服务器断开连接。" +ex.Message );
                    //ThreadHeartCheck();
                }));
            }
        }
        #region  按钮事件
        private void pbInfo_Click(object sender, EventArgs e)
        {
            // ContrlCtrl(panelMain);
            frm = new FmInfo();
            if (CheckExist(frm) == true)
            {
                frm.Dispose();
                frm = null;
                return;
            }
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            //frm.WindowState = FormWindowState.Maximized;
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
            CreateState = true;
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
        #region 暂时无用
        //private async Task  StartConnectionRobit()
        //{
        //    try
        //    { 
        //        string ErrMsg = "";
        //        if (!TcpIp_ConnPlc.CreatConn(GlobalPara.RobitPlc_Ip, GlobalPara.RobitPlc_Port, out ErrMsg))
        //        {

        //        }
        //        else
        //        {
        //            GetTaskInfo("机器人PLC连接失败，错误：" + ErrMsg);
        //        }
        //        await Task.Delay(0);
        //    }
        //    catch (Exception ex)
        //    { 
        //        GetTaskInfo("机器人PLC连接失败!请检查网络：" + ex.Message);
        //    }
        //}
        #endregion
        #region HSL 方式TCPIP连接
        /// <summary>
        /// 连接机器人
        /// </summary>
        private NetComplexClient complexClient = null;
        private async Task   ConnectionAsync()
        {
           
            string ErrMsg =  await Task.Run( ()=> CreateDataChange()); //创建 

            if (string.IsNullOrWhiteSpace(ErrMsg) )//事件创建成功
            {
               
            
                FmInfo.GetTaskInfo("机器人文本触发事件创建成功...");
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
                //complexClient.AcceptString += ComplexClient_AcceptString;//收到文本时 触发事件 
                //complexClient.MessageAlerts += ComplexClient_MessageAlerts;//服务器的异常，启动，等等一般消息产生的时候，出发此事件

                if (socketCore == null)//如果与服务器断开连接，则重新创建
                {
                    CreateSocketClinet();
                }
                //else
                //{
                //    //开始异步接受来自服务端的信息
                //  //  socketCore?.BeginReceive(buffer, 0, 1024, SocketFlags.None, new AsyncCallback(ReceiveCallBack), socketCore);
                //} 
                thread = new Thread(SendRobotTask)
                {
                    IsBackground = true
                };
                thread.Start();

                FmInfo.GetTaskInfo("机器人通信事件绑定成功");
                try
                {
                    plc.ShapeGroup1.callback += OnDataChange;
                    plc.ShapeGroup2.callback += OnDataChange;
                }
                catch (Exception ex)
                {
                   // FmInfo.GetTaskInfo("异型烟链板机触发事件绑定失败");
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
        /// 显示信息
        /// </summary>
        /// <param name="text"></param>
        private void ShowTextInfo(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(ShowTextInfo), text);
                return;
            }

            FmInfo.GetTaskInfo(text + Environment.NewLine);
        }
        int robotIndex = 1;
      
        /// <summary>
        /// 重连时间
        /// </summary>
        int timeTick = 1;
        /// <summary>
        /// 心跳检测，断线重连
        /// </summary>
        private void ThreadHeartCheck()
        { 
            Thread.Sleep(2000);
            socketCore = null;
            if(timeTick > 1)
            {
                return;
            }
            while (true)
            {
                try
                {
                    socketCore = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socketCore.Connect(IPAddress.Parse(GlobalPara.RobitPlc_Ip), int.Parse(GlobalPara.RobitPlc_Port));
                    if (socketCore.Connected)
                    {
                        connectSuccess = true;
                        break;
                    }
                    lblServerInfo.Text = "尝试重新连接中.." + timeTick + "秒";
                    timeTick++;
                    Thread.Sleep(1000);
                }
                catch (Exception)
                {
                     
                }
               
            }
        }
        /// <summary>
        /// 机器人任务数组
        /// </summary>
        byte[] bytes = null;

        string a = "";
        /// <summary>
        /// 发送机器人任务
        /// </summary>
        /// <returns></returns>
        void SendRobotTask()
        {
         aa: if (!RoBotState)//读取机器人状态为自动运行
            {
                try
                {
                    
                    //如果有新增的任务就一直循环取出来发送该条任务，直到该条任务做完，切换下一条任务
                    while (connectSuccess)//发送机制：取出当前第一条未完成的任务，间隔一秒发送一次，直到这条任务完成，跳到下一条任务！
                    {
                       
                    bb: if (robotIndex % 2 > 0)
                        {
                            a = "t,100" + robotIndex + ",1,102,30,27,0,3,1406895,129,102,27".Trim();//单抓

                        }
                        else if (robotIndex % 2 == 0)
                        {
                            a = "t,100" + robotIndex + ",2,214,27,100,1,3,5224354,129,102,27|T,100" + robotIndex + ",3,214,27,100,1,3,5224354,129,102,27".Trim();//单抓
                        }
                        //获取机器人任务
                        //bytes = robotService.GetRobitInfo(out string outStr).Select(o => Convert.ToByte(o)).ToArray();


                        bytes = Encoding.ASCII.GetBytes(a);
                        if (bytes[2] == 0)
                        {
                            FmInfo.GetTaskInfo("机器人任务发送完毕");
                            break;
                        }
                        try
                        {
                            if(socketCore.Connected)
                            {
                                socketCore?.Send(bytes, 0, bytes.Length, SocketFlags.None);//发送数据
                                FmInfo.GetTaskInfo("发送数据："+a);
                            }
                            else 
                            {
                                connectSuccess = false;
                                FmInfo.GetTaskInfo("远程主机强制断开一个现有连接，发送任务失败！");
                                ThreadHeartCheck();
                            } 
                        }
                        catch (Exception ex)
                        { 
                            FmInfo.GetTaskInfo("任务发送停止,未知错误："+ ex.Message+"任务将在10秒后重新发送！");
                            Thread.Sleep(10000);//暂停10秒后 继续读取
                            goto bb;

                            //HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage(ex);
                        }
                       
                        Thread.Sleep(1000);
                        
                        //string outStr = "";
                        ////获取任务
                        //if(bytes == null)
                        //{
                        //    bytes = await Task.Run(() => robotService.GetRobitInfo(out outStr).Select(o => Convert.ToByte(o)).ToArray());//获取机器人任务
                        //}
                         
                        //complexClient.Send(Nethandle, bytes);

                        //if (!string.IsNullOrWhiteSpace(outStr))
                        //{
                        //    FmInfo.GetTaskInfo("获取机器人任务方法，错误：" + outStr);
                        //    return;
                        //}
                        //if (bytes[0] == 0)
                        //{
                        //    FmInfo.GetTaskInfo("机器人任务发送完毕！");
                        //    return;
                        //}
                    }
                   
               
                
                     
                    // 数据发送
                    //NetHandle Nethandle = new NetHandle();
                    ////byte[] bytes = await Task.Run(()=>   robotService.GetRobitInfo(out outStr).Select(o => Convert.ToByte(o)).ToArray() );//获取机器人任务
                    //if (!string.IsNullOrWhiteSpace(outStr))
                    //{
                    //    FmInfo.GetTaskInfo("获取机器人任务方法，错误："+outStr);
                    //    return;
                    //}
                    //if (bytes[0] == 0)
                    //{
                    //    FmInfo.GetTaskInfo("机器人任务发送完毕！");
                    //    return;
                    //}

                    //complexClient.Send(Nethandle, bytes);//发送任务至服务器
                }
                catch (Exception ex)
                {

                    FmInfo.GetTaskInfo("发送机器人任务方法，未知错误：" + ex.Message);
                }
            }
            else
            {
                FmInfo.GetTaskInfo("机器人自动运行状态为关闭");
                Thread.Sleep(10000);//十秒之后再次检测机器人状态
                goto aa;
            }
        }
        /// <summary>
        /// 服务器的异常，启动，等等一般消息产生的时候，出发此事件
        /// </summary>
        /// <param name="text"></param>
        private void ComplexClient_MessageAlerts(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(ComplexClient_MessageAlerts), text);
                
                return;
            }
            lblServerInfo.Text = text;
           // FmInfo.GetTaskInfo(text);
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
                             
                                //读取接收信号的任务 数据库置接收 
                                FmInfo.GetTaskInfo( packtasknum +"收到任务");
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
            if (group == 2)//完成信号块组
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
                                //FmInfo.GetTaskInfo(plc.ReadAndWriteYXYTaskConpelte(tempvalue, i));//更新数据库 更新DB块
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
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            FmInfo.GetTaskInfo("触发定时器，"+plc.timerSendTask());
            timer1.Stop();
        }
    }
}
