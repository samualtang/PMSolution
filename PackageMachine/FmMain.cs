using Functions.Model;
using Functions.PubFunction;
using HslCommunication.Enthernet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication.Enthernet;
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
            handle += updateListBox;


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
        #region   任务的信息 在主窗体显示
        delegate void HandleUpDate(string info);
        private delegate void HandleDelegate(string strshow);
        static HandleUpDate handle ;
        public static void GetTaskInfo(string Info)
        {
            handle(Info);
        }
        void upDateList(string info)
        {
            updateListBox(info);
        }

        public void updateListBox(string info)
        {
            String time = DateTime.Now.ToLongTimeString();

            if (this.list_date.InvokeRequired)
            {

                this.list_date.Invoke(new HandleDelegate(updateListBox), info);
            }
            else
            {
                this.list_date.Items.Insert(0, time + "    " + info);

            }
        }
        #endregion
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
                await Task.Run( StartConnectionRobit);
            }
            catch (NotSupportedException EX)
            {
                GetTaskInfo("NotSupportedException错误:" + EX.Message);
            }
            catch(Exception ex)
            {
                GetTaskInfo("Exception错误:" + ex.Message);
            }
        }

        private async Task  StartConnectionRobit()
        {
            try
            { 
                string ErrMsg = "";
                if (!TcpIp_ConnPlc.CreatConn(GlobalPara.RobitPlc_Ip, GlobalPara.RobitPlc_Port, out ErrMsg))
                {

                }
                else
                {
                    GetTaskInfo("机器人PLC连接失败，错误：" + ErrMsg);
                }
                await Task.Delay(0);
            }
            catch (Exception ex)
            { 
                GetTaskInfo("机器人PLC连接失败!请检查网络：" + ex.Message);
            }
        }
        #region HSL 方式TCPIP连接
        //private NetComplexClient complexClient = null;

        //void CreateConn(string ip, string prot, out string ErrMsg)
        //{
        //    ErrMsg = ""; 
        //    if (!IPAddress.TryParse(ip, out IPAddress address))
        //    {
        //        ErrMsg += "IP地址填写不正确";
        //        return;
        //    }

        //    if (!int.TryParse(prot, out int port))
        //    {
        //        ErrMsg += "port填写不正确";
        //        return;
        //    }
        //    try
        //    {
        //        // 连接 connect
        //        complexClient = new NetComplexClient();
        //        complexClient.ClientAlias = "别名";
        //        complexClient.EndPointServer = new IPEndPoint(address, port);
        //        complexClient.Token = new Guid("令牌");
        //        complexClient.AcceptString += ComplexClient_AcceptString;//收到文本时 触发事件 
        //        complexClient.MessageAlerts += ComplexClient_MessageAlerts;//服务器的异常，启动，等等一般消息产生的时候，出发此事件
        //        complexClient.ClientStart();
        //    }
        //    catch (Exception ex)
        //    {
        //        HslCommunication.BasicFramework.SoftBasic.ShowExceptionMessage(ex);
        //    }
        //}


        //private void ShowTextInfo(string text )
        //{ 
        //    if (InvokeRequired)
        //    {
        //        Invoke(new Action<string>(ShowTextInfo), text);
        //        return;
        //    }

        //    GetTaskInfo(text + Environment.NewLine);
        //}

        //private void ComplexClient_AcceptString(AppSession session, NetHandle handle, string data)
        //{
        //    // 接收字符串
        //    ShowTextInfo($"[{session.IpEndPoint}] [{handle}] {data}");
        //} 
 
        //private void ComplexClient_MessageAlerts(string text)
        //{
        //    if (InvokeRequired)
        //    {
        //        Invoke(new Action<string>(ComplexClient_MessageAlerts), text);
        //        return;
        //    } 
        //     lblServerInfo.Text = text;
        //}
        #endregion
    }
}
