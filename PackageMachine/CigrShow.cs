using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PackageMachine.Code;
using EFModle.Model;

namespace PackageMachine
{
    public partial class CigrShow : UserControl
    {
        public CigrShow()
        {
            InitializeComponent();
            this.p_Main = new Panel();
            this.lab_Line = new Label();
            this.timer1 = new Timer(this.components);
            this.tp_CodeInfo = new ToolTip(this.components);
            this.p_Main.SuspendLayout();
            base.SuspendLayout();
            this.p_Main.BorderStyle = BorderStyle.FixedSingle;
            this.p_Main.Controls.Add(this.lab_Line);
            this.p_Main.Dock = DockStyle.Fill;
            this.p_Main.Location = new Point(0, 0);
            this.p_Main.Margin = new Padding(4);
            this.p_Main.Name = "p_Main";
            this.p_Main.Size = new Size(876, 489);
            this.p_Main.TabIndex = 0; 
            this.lab_Line.AutoSize = true;
            this.lab_Line.Location = new Point(0, 208);
            this.lab_Line.Margin = new Padding(4, 0, 4, 0);
            this.lab_Line.Name = "lab_Line";
            this.lab_Line.Size = new Size(1029, 15);
            this.lab_Line.TabIndex = 0;
            //this.lab_Line.Text = "限高----------------------------------------------------------------------------------------------------------------------------";
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            base.AutoScaleDimensions = new SizeF(8f, 15f); 
            this.BackColor = Color.White;
            base.Controls.Add(this.p_Main);
            base.Margin = new Padding(4);
            base.Name = "TobaccoShow";
            base.Size = new Size(876, 489);
            base.Resize += this.TobaccoShow_Resize;
            this.p_Main.ResumeLayout(false);
            this.p_Main.PerformLayout();
            base.ResumeLayout(false);
            
            ShowLoad();
        }

 

        /// <summary>
        /// 更新垛型显示层
        /// </summary>
        /// <param name="Linfo">卷烟垛型信息</param>
        public void UpdateValue(List<TobaccoInfo> Linfo)
        { 
            tbinfo = Linfo;
            this.UpdateTobaccoShow();
        }
        /// <summary>
        /// 显示层算法实现
        /// </summary>
        public void UpdateTobaccoShow()
        {
            if (buttonList == null)
            {
                this.CreateButton(7, 6);
            }
            else if (buttonList.Count == 0)
            {
                this.CreateButton(7, 6);
            }
            else
            { 
                Font font = this.buttonList[0].Font; 
                float num = 530 * 200 / (float)( Width *  Height); 
                int ListIndex = 0;
                int TabeltIndex = 0;
                TobaccoInfo detail;
                foreach (var item in tbinfo)
                {
                    detail = item;
                    this.buttonList[ListIndex].Text = "123";
                    this.buttonList[ListIndex].Visible = true;
                    this.buttonList[ListIndex].BackgroundImage = null;
                    this.buttonList[ListIndex].ForeColor = Color.Black;
                    this.buttonList[ListIndex].Font = font;
                    this.buttonList[ListIndex].TabIndex = TabeltIndex;
                    this.buttonList[ListIndex].BackColor = ((detail.Speed == 0) ? Color.White : this.colorList[detail.TobaccoStatus].Color);
                    this.buttonList[ListIndex].Height = (int)detail.TobaccoHeight  ;
                    this.buttonList[ListIndex].Width = (int)detail.TobaccoWidth  ;
                    //this.buttonList[ListIndex].Top = this.p_Main.Height - (int)(detail.PositionHeightLast * (1f + num)) - 4;
                    //this.buttonList[ListIndex].Left = this.p_Main.Width - (int)(detail.PositionWidthLast * (1f + num)) - 4; 
                    buttonList[ListIndex].Location = new Point( (int)detail.PostionX +2, (int)detail.PostionY -2 );
                    if (ListIndex == 0)
                    {

                        buttonList[ListIndex].Location = new Point((int)detail.PostionX - (int)detail.PostionX+2, (int)detail.PostionY  -2);
                    }
                    this.buttonList[ListIndex].Text = string.Concat(new string[]
                                {
                                    detail.GlobalIndex.ToString(),
                                    ".",
                                    detail.OrderIndex.ToString(),
                                    ".",
                                    detail.TobaccoName,
                                }); 
                    ListIndex++;
                    TabeltIndex++;
                     
                }
            }
        }
        /// <summary>
        /// 包类总烟数
        /// </summary>
        private int buttonCount
        {
            get
            {
                return this.lineCount * this.coloumCount;
            }
        }
        /// <summary>
        /// 界面初始化
        /// </summary>
        void ShowLoad()
        {
            this.colorList.Add(new ColorTobacco(Color.White));
            bool flag = false;
            foreach (ColorTobacco colorTobacco in this.colorList)
            {
                if (colorTobacco.Color != Color.White)
                {
                    flag = true;
                }
            }
            if (!flag)
            {
                this.colorList.Clear();
                this.colorList.Add(new ColorTobacco(Color.FromArgb(0, 255, 0)));
                this.colorList.Add(new ColorTobacco(Color.Wheat));
                this.colorList.Add(new ColorTobacco(Color.Peru));
                this.colorList.Add(new ColorTobacco(Color.Red));
                this.colorList.Add(new ColorTobacco(Color.FromArgb(0, 255, 0)));
                this.colorList.Add(new ColorTobacco(Color.Pink));
                this.colorList.Add(new ColorTobacco(Color.Purple));
                this.colorList.Add(new ColorTobacco(Color.Aqua));
                this.colorList.Add(new ColorTobacco(Color.DimGray));
                this.colorList.Add(new ColorTobacco(Color.HotPink));
                this.colorList.Add(new ColorTobacco(Color.Lavender));
                this.colorList.Add(new ColorTobacco(Color.MediumSpringGreen));
                this.colorList.Add(new ColorTobacco(Color.PeachPuff));
                this.colorList.Add(new ColorTobacco(Color.FromArgb(0, 140, 0)));
                this.colorList.Add(new ColorTobacco(Color.Tomato));
                this.colorList.Add(new ColorTobacco(Color.FromArgb(80, 100, 255)));
                this.colorList.Add(new ColorTobacco(Color.FromArgb(120, 120, 0)));
                this.colorList.Add(new ColorTobacco(Color.FromArgb(0, 150, 150)));
                this.colorList.Add(new ColorTobacco(Color.FromArgb(100, 255, 140)));
                this.colorList.Add(new ColorTobacco(Color.FromArgb(50, 255, 40)));
                this.colorList.Add(new ColorTobacco(Color.FromArgb(0, 0, 70)));
                this.colorList.Add(new ColorTobacco(Color.FromArgb(70, 0, 0)));
                this.colorList.Add(new ColorTobacco(Color.FromArgb(140, 0, 70)));
                this.colorList.Add(new ColorTobacco(Color.FromArgb(0, 120, 90)));
                this.colorList.Add(new ColorTobacco(Color.FromArgb(40, 50, 60)));
                this.colorList.Add(new ColorTobacco(Color.FromArgb(47, 180, 200)));
                this.colorList.Add(new ColorTobacco(Color.FromArgb(90, 255, 255)));
                this.colorList.Add(new ColorTobacco(Color.FromArgb(159, 255, 27)));
                this.colorList.Add(new ColorTobacco(Color.FromArgb(170, 180, 47)));
                this.colorList.Add(new ColorTobacco(Color.FromArgb(70, 255, 90)));
            }
            this.CreateButton(6, 6);
        }
        /// <summary>
        ///  卷烟显示初始化
        /// </summary>
        /// <param name="lineCount"></param>
        /// <param name="coloumCount"></param>
        private void CreateButton(int lineCount, int coloumCount)
        {
            this.lineCount = lineCount;
            this.coloumCount = coloumCount;
            this.buttonList = new List<Button>();
            int[][] sizeAndPosition = ButtonCreator.GetSizeAndPosition(W + 2, H + 2, 3, 4, lineCount, coloumCount);
            for (int i = 0; i < this.buttonCount; i++)
            {
                Button button = ButtonCreator.Create(this.p_Main, i);
                button.Text = "卷烟" + (i + 1).ToString();
                button.Width = sizeAndPosition[this.GetPositionIndex(this.buttonCount - 1 - i)][0];
                button.Height = sizeAndPosition[this.GetPositionIndex(this.buttonCount - 1 - i)][1];
                button.Left = sizeAndPosition[this.GetPositionIndex(this.buttonCount - 1 - i)][2];
                button.Top = sizeAndPosition[this.GetPositionIndex(this.buttonCount - 1 - i)][3] + 3;
                button.BackColor = Color.FromArgb(0, 255, 0);
                button.ForeColor = Color.Black;
                button.Font = new Font(button.Font.FontFamily, 11f, FontStyle.Bold);
                button.Visible = true;
                button.MouseEnter += this.btn_MouseEnter;
                button.MouseLeave += this.btn_MouseLeave;
                this.buttonList.Add(button);
            }
        }
        private void TobaccoShow_Resize(object sender, EventArgs e)
        {
             //this.UpdateTobaccoShow();
        }

        private int GetPositionIndex(int index)
        {
            return index;
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            this.tp_CodeInfo.Show(button.ImageKey, button);
        }

        // Token: 0x06000157 RID: 343 RVA: 0x000183A8 File Offset: 0x000165A8
        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button win = (Button)sender;
            this.tp_CodeInfo.Hide(win);
        }
        // Token: 0x0400014C RID: 332
        private List<Button> buttonList;

        public int W { get; set; }
        public int H { get; set; }


        // Token: 0x0400014F RID: 335
        private int lineCount;

        // Token: 0x04000150 RID: 336
        private int coloumCount;

        // Token: 0x04000151 RID: 337
        private bool UesdBackImage = false;

        // Token: 0x04000152 RID: 338
        private bool UesdDifferBackImage = false;

        // Token: 0x04000153 RID: 339
        private string[] arrFileNames = null;

        // Token: 0x04000154 RID: 340
        private List<ColorTobacco> colorList = new List<ColorTobacco>();
         

        // Token: 0x04000156 RID: 342
        private Panel p_Main;

        // Token: 0x04000157 RID: 343
        private Timer timer1;

        // Token: 0x04000158 RID: 344
        private Label lab_Line;

        // Token: 0x04000159 RID: 345
        private ToolTip tp_CodeInfo;

        public List<TobaccoInfo> tbinfo = null;
    }
}
