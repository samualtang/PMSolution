using Functions.Model;
using Functions.PubFunction;
using HslCommunication.Enthernet;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication;
using System.Net;
using HslCommunication.Core.Net;

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
           
            
            pbInfo_Click(null, null);
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

        private async void pbStart_Click(object sender, EventArgs e)
        {
            try
            {
                await Task.Run(Connection);
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
        private NetComplexClient complexClient = null;
        private async Task Connection()
        {
            CreateConn(GlobalPara.RobitPlc_Ip,GlobalPara.RobitPlc_Port, out string ErrMsg); 
            if(string.IsNullOrWhiteSpace(ErrMsg ) )
            {
                FmInfo.GetTaskInfo("客户端初始化成功。。。连接中。。");
            }
            else
            {
                FmInfo.GetTaskInfo("客户端初始化失败！错误：" + ErrMsg);
            }
            await Task.Delay(0);
        }
        void CreateConn(string ip, string prot, out string ErrMsg)
        {
            ErrMsg = "";
            if (!IPAddress.TryParse(ip, out IPAddress address))
            {
                ErrMsg += "IP地址填写不正确";
                return;
            } 
            if (!int.TryParse(prot, out int port))
            {
                ErrMsg += "port填写不正确";
                return;
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
                    complexClient.AcceptString += ComplexClient_AcceptString;//收到文本时 触发事件 
                    complexClient.MessageAlerts += ComplexClient_MessageAlerts;//服务器的异常，启动，等等一般消息产生的时候，出发此事件
                    complexClient.ClientStart(); 
                }
                else
                {
                    ErrMsg += "请勿重复点击开始任务！";
                    FmInfo.GetTaskInfo("请勿重复点击开始任务！");
                }
            }
            catch (Exception ex)
            {
                HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage(ex);
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
            CloseConn();
        }

        private void pbStop_Click(object sender, EventArgs e)
        {
            CloseConn();
        }

        void CloseConn()
        {
            if (complexClient != null)
            {
                complexClient.ClientClose();
                complexClient = null;
                FmInfo.GetTaskInfo("断开与机器人的连接！");
            }
            else
            {
                FmInfo.GetTaskInfo("请先连接服务器！");
            }
        }
    }
}
