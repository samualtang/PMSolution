using Functions.Model;
using Functions.PubFunction;
using HslCommunication.Enthernet;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication;
using System.Net;
using HslCommunication.Core.Net;
using System.Threading;

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
            string[] strmessage = plc.ConnectionToPLCYXY();
            FmInfo.GetTaskInfo(strmessage[0]); //创建plc连接
            if (strmessage[1] == "1")
            {
                timer1.Interval = 10000;
                timer1.Start(); //启动定时器
            }
            CreateHslClinet();
            pbInfo_Click(null, null);
        }
        /// <summary>
        /// 创建Tcp客户端
        /// </summary>
        void CreateHslClinet()
        { 
            if (!IPAddress.TryParse(GlobalPara.RobitPlc_Ip, out IPAddress address))
            { 
                FmInfo.GetTaskInfo("Robit_IP地址填写不正确");
            }
            if (!int.TryParse(GlobalPara.RobitPlc_Port, out int port))
            { 
                FmInfo.GetTaskInfo("Robit_Port地址填写不正确");
            }
            try
            {
                if (complexClient == null)
                {
                    // 连接 connect
                    complexClient = new NetComplexClient
                    {
                        ClientAlias = "别名",
                        EndPointServer = new IPEndPoint(address, port),
                        Token = new Guid("00000000-0000-0000-0000-000000000000")
                    };

                    complexClient.ClientStart();
                } 
            }
            catch (Exception ex)
            {
                FmInfo.GetTaskInfo(ex.Message); 
            }
        }
        private void pbInfo_Click(object sender, EventArgs e)
        {
            // ContrlCtrl(panelMain);
            FmInfo frm = new FmInfo(plc);
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
            try
            {
              Task a =  ConnectionAsync();//异步开始创建事件 
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
                FmInfo.Func(1);
                EnabletStartAndStop(1);
                FmInfo.GetTaskInfo("机器人文本触发事件创建成功...");
            }
            else
            {
                FmInfo.GetTaskInfo("客户端初始化失败！错误：" + ErrMsg);
            }
             
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
        /// 创建数据变化事件
        /// </summary> 
        /// <returns></returns>
        string CreateDataChange()
        { 
            try
            {
                complexClient.AcceptString += ComplexClient_AcceptString;//收到文本时 触发事件 
                complexClient.MessageAlerts += ComplexClient_MessageAlerts;//服务器的异常，启动，等等一般消息产生的时候，出发此事件
                try
                {
                    plc.ShapeGroup1.callback += OnDataChange;
                    plc.ShapeGroup2.callback += OnDataChange;
                }
                catch (Exception)
                {
                    FmInfo.GetTaskInfo("异型烟链板机触发事件绑定失败");
                }
                
                return "";
            }
            catch (Exception ex)
            { 
                return ex.Message;
            } 
        }


        private void ShowTextInfo(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(ShowTextInfo), text);
                return;
            }

            FmInfo.GetTaskInfo(text + Environment.NewLine);
        }
        /// <summary>
        /// 收到文本时 触发事件 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="handle"></param>
        /// <param name="data"></param>
        private void ComplexClient_AcceptString(AppSession session, NetHandle handle, string data)
        {
            // 接收字符串
            ShowTextInfo($"[{session.IpEndPoint}] [{handle}] {data}");
            string[] arrData = data.Split(',');
            for (int i = 0; i < arrData.Length; i++)
            {
                if (arrData[0] == "1")//机器人自动运行 状态 1 是， 0 否
                {
                    System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
               
                }
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
            FmInfo.GetTaskInfo(text);
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

        void CloseDataChange()
        {
            if (complexClient != null)
            {
                complexClient.AcceptString -= ComplexClient_AcceptString;//收到文本时 触发事件 
                complexClient.MessageAlerts -= ComplexClient_MessageAlerts;//服务器的异常，启动，等等一般消息产生的时候，出发此事件
                FmInfo.GetTaskInfo("断开与机器人的连接！");
                try
                {
                    plc.ShapeGroup1.callback += OnDataChange;
                    plc.ShapeGroup2.callback += OnDataChange;
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
                        int packtasknum = int.Parse(values[0].ToString());//任务号
                        int tempvalue = int.Parse(values[7].ToString());//接收信号
                        if (tempvalue == 0)//如果有接收信号
                        {
                            try
                            {
                                //读取接收信号的任务 数据库置接收 
                                FmInfo.GetTaskInfo(plc.WriteDBReceive_YXY(packtasknum));
                                //更改标志位 写入新任务
                                var x = await Task.Run(() => plc.WriteTaskSend_YXY());
                                FmInfo.GetTaskInfo(x);
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
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            FmInfo.GetTaskInfo("触发定时器，"+plc.timerSendTask());
            timer1.Stop();
        }
    }
}
