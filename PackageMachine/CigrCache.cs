using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFModle.Model;
using PackageMachine.Code;

namespace PackageMachine
{
    public partial class CigrCache : UserControl
    {
        public CigrCache()
        {
            InitializeComponent();
            
            this.p_Main = new Panel();
            this.lb_ShowDetail = new LinkLabel();
            this.timer1 = new Timer(this.components);
            this.p_Main.SuspendLayout();
            base.SuspendLayout();
            this.p_Main.BorderStyle = BorderStyle.FixedSingle;
            this.p_Main.Controls.Add(this.lb_ShowDetail);
            this.p_Main.Dock = DockStyle.Fill;
            this.p_Main.Location = new Point(0, 0);
            this.p_Main.Margin = new Padding(4, 4, 4, 4);
            this.p_Main.Name = "p_Main";
            this.p_Main.Size = new Size(1031, 109);
            this.p_Main.TabIndex = 0;
            this.lb_ShowDetail.AutoSize = true;
            this.lb_ShowDetail.Location = new Point(21, 14);
            this.lb_ShowDetail.Margin = new Padding(4, 0, 4, 0);
            this.lb_ShowDetail.Name = "lb_ShowDetail";
            this.lb_ShowDetail.Size = new Size(67, 15);
            this.lb_ShowDetail.TabIndex = 0;
            this.lb_ShowDetail.TabStop = true;
            this.lb_ShowDetail.Text = "显示更多";
            this.lb_ShowDetail.LinkClicked += this.lb_ShowDetail_LinkClicked;
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            base.AutoScaleDimensions = new SizeF(8f, 15f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.Controls.Add(this.p_Main);
            base.Margin = new Padding(4, 4, 4, 4);
            base.Name = "CigrCahce";
            base.Size = new Size(1031, 109);
            base.Load += this.TobaccoListShow_Load;
            base.Resize += this.TobaccoShow_Resize;
            this.p_Main.ResumeLayout(false);
            this.p_Main.PerformLayout();
            base.ResumeLayout(false);
        }

        private void CreateButton()
        {
            int num = 12;
            this.buttonList = new List<Button>();
            for (int i = 0; i < num; i++)
            {
                Button button = ButtonCreator.Create(this.p_Main, i);
                button.Text = "未扫描" + (i + 1).ToString();
                button.BackColor = Color.FromArgb(0, 255, 0);
                button.ForeColor = Color.Black;
                button.Font = new Font(button.Font.FontFamily, 11f, FontStyle.Bold);
                button.Visible = true;
                this.buttonList.Add(button);
            }
        }

        // Token: 0x060000E3 RID: 227 RVA: 0x000100C8 File Offset: 0x0000E2C8
        public void AddData(TobaccoInfo data)
        {
            //if (!this.TobaccoList.Contains(data))
            //{
            //    data.OnPosition = false;
            //    this.TobaccoList.Add(data);
            //    TobaccoListShow.TobaccoListAll.Add(data);
            //}
        }

        // Token: 0x060000E4 RID: 228 RVA: 0x00010108 File Offset: 0x0000E308
        public void RemoveData(TobaccoInfo data)
        {
            //this.TobaccoList.Remove(data);
            //TobaccoListShow.TobaccoListAll.Remove(data);
            //if (data.OtherDoubleTobacco != null)
            //{
            //    this.TobaccoList.Remove(data.OtherDoubleTobacco);
            //    TobaccoListShow.TobaccoListAll.Remove(data.OtherDoubleTobacco);
            //}
            //this.UpdateTobaccoShow();
        }

        // Token: 0x060000E5 RID: 229 RVA: 0x00010168 File Offset: 0x0000E368
        public void ClearData()
        {
            //this.TobaccoList.Clear();
            //TobaccoListShow.TobaccoListAll.Clear();
            //this.UpdateTobaccoShow();
        }

        // Token: 0x060000E6 RID: 230 RVA: 0x0001018C File Offset: 0x0000E38C
        public void OnPosition(int TobaccoIndex)
        {
            //foreach (TobaccoInfo tobaccoInfo in this.TobaccoList)
            //{
            //    if (tobaccoInfo.TobaccoIndex <= TobaccoIndex)
            //    {
            //        tobaccoInfo.OnPosition = true;
            //    }
            //    else
            //    {
            //        tobaccoInfo.OnPosition = false;
            //    }
            //}
            //this.UpdateTobaccoShow();
        }

        // Token: 0x060000E7 RID: 231 RVA: 0x00010208 File Offset: 0x0000E408
        public void UpdateTobaccoShow()
        {
            Font font = new Font(this.Font.FontFamily, 11f, FontStyle.Bold);
            if (this.buttonList != null && this.buttonList.Count > 0)
            {
                font = this.buttonList[0].Font;
            }
            for (int i = 0; i < this.buttonList.Count; i++)
            {
                this.buttonList[i].Visible = false;
            }
            if (this.TobaccoList != null && this.TobaccoList.Count != 0)
            {
                float num = 0;// (float)base.Width / (SecretParam.RobitParam.WidthLimited * 2.5f);
                int num2 = 0;
                int num3 = base.Width;
                int num4 = 0;
                int num5 = 0;
                foreach (TobaccoInfo tobaccoInfo in this.TobaccoList)
                {
                    bool flag;
                    //if (tobaccoInfo.pack.PackageNO != num5)
                    //{
                    //    num5 = tobaccoInfo.pack.PackageNO;
                    //    flag = true;
                    //}
                    //else
                    //{
                    //    flag = false;
                    //}
                    num4++;
                    for (int j = 0; j < 1; j++)
                    {
                        if (num2 >= this.buttonList.Count)
                        {
                            break;
                        }
                        this.buttonList[num2].ImageKey = tobaccoInfo.TobaccoName;
                        this.buttonList[num2].Text = "tobaccoInfo.TobaccoIndexPackage "+ "." + tobaccoInfo.TobaccoName;
                        this.buttonList[num2].Visible = true;
                        this.buttonList[num2].TextAlign = ContentAlignment.MiddleCenter;
                        this.buttonList[num2].ForeColor = Color.Black;
                        this.buttonList[num2].Font = font;
                        this.buttonList[num2].TabIndex = num2;
                        //if (tobaccoInfo.OnPosition)
                        //{
                        //    this.buttonList[num2].BackColor = Color.FromArgb(0, 255, 0);
                        //}
                        //else
                        //{
                        //    this.buttonList[num2].BackColor = Color.White;
                        //}
                        //if (flag)
                        //{
                        //    this.buttonList[num2].BackColor = Color.Green;
                        //}
                        //this.buttonList[num2].Height = (int)(num * tobaccoInfo.Height + 10f);
                        //this.buttonList[num2].Width = (int)(num * tobaccoInfo.Width);
                        this.buttonList[num2].Top = this.p_Main.Height - this.buttonList[num2].Height;
                        num3 -= this.buttonList[num2].Width;
                        this.buttonList[num2].Left = num3;
                        num2++;
                    }
                    if (num4 == 100)
                    {
                        break;
                    }
                }
            }
        }

        // Token: 0x060000E8 RID: 232 RVA: 0x00010580 File Offset: 0x0000E780
        private void TobaccoShow_Resize(object sender, EventArgs e)
        {
        }

        // Token: 0x060000E9 RID: 233 RVA: 0x00010584 File Offset: 0x0000E784
        private void lb_ShowDetail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
 
        }

        // Token: 0x060000EA RID: 234 RVA: 0x000105A5 File Offset: 0x0000E7A5
        private void TobaccoListShow_Load(object sender, EventArgs e)
        {
            this.CreateButton();
          //  this.UpdateTobaccoShow();
        }

 

    

        // Token: 0x040000E6 RID: 230
        private List<Button> buttonList;

        // Token: 0x040000E7 RID: 231
        private List<TobaccoInfo> TobaccoList = new List<TobaccoInfo>();

        // Token: 0x040000E8 RID: 232
        private static List<TobaccoInfo> TobaccoListAll = new List<TobaccoInfo>();
         

        // Token: 0x040000EA RID: 234
        private Panel p_Main;

        // Token: 0x040000EB RID: 235
        private Timer timer1;

        // Token: 0x040000EC RID: 236
        private LinkLabel lb_ShowDetail;
    }
}
