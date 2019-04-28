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
            lb_ShowLastDetail = new LinkLabel();
            this.timer1 = new Timer(this.components);
            this.p_Main.SuspendLayout();
            base.SuspendLayout();
            this.p_Main.BorderStyle = BorderStyle.FixedSingle;
            this.p_Main.Controls.Add(this.lb_ShowDetail);
            p_Main.Controls.Add(lb_ShowLastDetail);
            this.p_Main.Dock = DockStyle.Fill;
            this.p_Main.Location = new Point(0, 0);
            this.p_Main.Margin = new Padding(4, 4, 4, 4);
            this.p_Main.Name = "p_Main";
            this.p_Main.Size = new Size(1031, 109);
            this.p_Main.TabIndex = 0;
            this.lb_ShowDetail.AutoSize = true;
            this.lb_ShowDetail.Location = new Point(11, 5);
            this.lb_ShowDetail.Margin = new Padding(4, 0, 4, 0);
            this.lb_ShowDetail.Name = "lb_ShowDetail";
            this.lb_ShowDetail.Size = new Size(67, 15);
            this.lb_ShowDetail.TabIndex = 0;
            this.lb_ShowDetail.TabStop = true;
            this.lb_ShowDetail.Text = "显\r\n示\r\n更\r\n多";
            this.lb_ShowDetail.LinkClicked += this.lb_ShowDetail_LinkClicked;
            
            lb_ShowLastDetail.AutoSize = true;
            lb_ShowLastDetail.Location = new Point( 150, 5);
            this.lb_ShowLastDetail.Margin = new Padding(4, 0, 4, 0);
            this.lb_ShowLastDetail.Name = "lb_ShowDetail";
            this.lb_ShowLastDetail.Size = new Size(67, 15); 
 
            this.lb_ShowLastDetail.Text = "查\r\n已\r\n完\r\n成";
            this.lb_ShowLastDetail.LinkClicked += Lb_ShowLastDetail_LinkClicked;
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

        private void Lb_ShowLastDetail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var info = (from item in TobaccoList1 where item.TobaccoState == 20 orderby item.SortNum descending, item.PacktaskNum descending, item.CigNum descending select item).ToList();

            FmCacheDetail fcd = new FmCacheDetail(info);
            fcd.ShowDialog();
        }

        private void CreateButton()
        {
            int num = 40;
            
            this.buttonList = new List<Button>();
            for (int i = 0; i < num; i++)
            {
                Button button = ButtonCreator.Create(this.p_Main, i);
                button.Text = "默认" + (i + 1).ToString();
                button.BackColor = Color.FromArgb(0, 255, 0);
                button.ForeColor = Color.Black;
                button.Font = new Font(button.Font.FontFamily, 11f, FontStyle.Bold);
            
                button.Width = 60;
                button.Height = 60;
                button.Visible = false;
             
     
                this.buttonList.Add(button);
            }
            //num3 -= this.buttonList[i - 1].Width;
            //button.Top = p_Main.Height - button.Height;
            //button.Left = num3;
            //int width = 0;
   
            //for (int i = 0; i < buttonList.Count; i++)
            //{
            //    buttonList[i].Top = p_Main.Height - buttonList[i].Height-2;
            //    width += buttonList[i].Width;
            //    buttonList[i].Top = width-4;
            //}
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
       
        public void UpdateValue(List<TobaccoInfo> Linfo)
        {
            TobaccoList = Linfo.Where(a => a.TobaccoState == 10).ToList();
            TobaccoList1 = Linfo;
            this.UpdateTobaccoShow();
        }
        /// <summary>
        /// 最后一个任务 清除整个界面
        /// </summary>
        public void ClearData()
        {
            for (int i = 0; i < this.buttonList.Count; i++)
            {
                this.buttonList[i].Visible = false;
            }
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
                int listIndex = 0;
                int Tishwidth =0; 
                foreach (TobaccoInfo tobaccoInfo in this.TobaccoList)
                { 
                    for (int j = 0; j < 1; j++)
                    {
                        if (listIndex >= this.buttonList.Count)
                        {
                            break;
                        } 
                        this.buttonList[listIndex].Text = tobaccoInfo.GlobalIndex + "."+ tobaccoInfo.OrderIndex+"." + tobaccoInfo.TobaccoName;
                        this.buttonList[listIndex].Visible = true;
                        this.buttonList[listIndex].TextAlign = ContentAlignment.MiddleCenter;
                        this.buttonList[listIndex].ForeColor = Color.Black;
                        this.buttonList[listIndex].Font = font;
                        this.buttonList[listIndex].TabIndex = j;
                        buttonList[listIndex].BackColor = Color.WhiteSmoke;
                        buttonList[listIndex].Width = (int)tobaccoInfo.TobaccoWidth;// + (int)(tobaccoInfo.TobaccoWidth*0.2);
                        buttonList[listIndex].Height = (int)tobaccoInfo.TobaccoHeight;// + (int)(tobaccoInfo.TobaccoHeight *0.2);
                       /// this.buttonList[listIndex].Left =  base.Width/2 -buttonList[listIndex].Width/2;
                        
                       // this.buttonList[listIndex].Top = Tishwidth;
                        if(tobaccoInfo.OrderIndex == 1)
                        {
                            //this.buttonList[listIndex].Top = 0;
                            //Tishwidth -= buttonList[listIndex].Height;
                          this.buttonList[listIndex].BackColor = Color.Green; 
                        }
                        buttonList[listIndex].Location = new Point(base.Width / 2 - buttonList[listIndex].Width / 2, Tishwidth);
                        Tishwidth += this.buttonList[listIndex].Height;
                        //FmInfo.GetTaskInfo(buttonList[listIndex].Text+" | "+ buttonList[listIndex].Top);
                        listIndex++;
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
            FmCacheDetail fcd = new FmCacheDetail(TobaccoList);
            fcd.ShowDialog();
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

        private List<TobaccoInfo> TobaccoList1 = new List<TobaccoInfo>();

        // Token: 0x040000E8 RID: 232
        private static List<TobaccoInfo> TobaccoListAll = new List<TobaccoInfo>();
         

        // Token: 0x040000EA RID: 234
        private Panel p_Main;

        // Token: 0x040000EB RID: 235
        private Timer timer1;

        // Token: 0x040000EC RID: 236
        private LinkLabel lb_ShowDetail;
        private LinkLabel lb_ShowLastDetail;
    }
}
