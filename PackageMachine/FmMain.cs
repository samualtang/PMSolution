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
        public FmMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            CheckForIllegalCrossThreadCalls = false
                 ;

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
            FmInfo frm = new FmInfo();
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
            
        }

        private void pbConnSet_Click(object sender, EventArgs e)
        {
           
        }

        private void pbSize_Click(object sender, EventArgs e)
        {
            
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
            if (string.IsNullOrWhiteSpace(ErrMsg) )
            {
                FmInfo.GetTaskInfo("机器人文本触发事件创建成功...");
            }
            else
            {
                FmInfo.GetTaskInfo("客户端初始化失败！错误：" + ErrMsg);
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
            CloseDataChange();
        }

        private void pbStop_Click(object sender, EventArgs e)
        {
            CloseDataChange();
        }

        void CloseDataChange()
        {
            if (complexClient != null)
            {
                complexClient.AcceptString -= ComplexClient_AcceptString;//收到文本时 触发事件 
                complexClient.MessageAlerts -= ComplexClient_MessageAlerts;//服务器的异常，启动，等等一般消息产生的时候，出发此事件
                FmInfo.GetTaskInfo("断开与机器人的连接！");
            }
            else
            {
                FmInfo.GetTaskInfo("请先连接服务器！");
            }
        }
    }
}
