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
using Functions.PubFunction;

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
            this.p_Main.Size = new Size(W, H);
            this.p_Main.TabIndex = 0; 
            this.lab_Line.AutoSize = true;
            this.lab_Line.Location = new Point(0, 300); 
            this.lab_Line.Margin = new Padding(4, 0, 4, 0);
            this.lab_Line.Name = "lab_Line";
            this.lab_Line.Size = new Size(1029, 15);
            this.lab_Line.TabIndex = 0;
          //  this.lab_Line.Text = "限高----------------------------------------------------------------------------------------------------------------------------";
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            base.AutoScaleDimensions = new SizeF(8f, 15f); 
            this.BackColor = Color.White;
            base.Controls.Add(this.p_Main);
            base.Margin = new Padding(4);
            base.Name = "CigrShow";
           // base.Size = new Size(876, 489);
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
            int layerHeight = 0;
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
                for (int i = 0; i < buttonList.Count; i++)
                {
                    buttonList[i].Visible = false;
                }
                Font font = this.buttonList[0].Font  ;  
                int ListIndex = 0;
                int TabeltIndex = 0;
                int colorIndex = 0;
                int normalHeight = 48;
                int normalWidth = 91;
                 
                int lastX = 0;
                int NormalCount = 1;
           
                foreach (var detail in tbinfo)
                {
                    //if(ListIndex >= 36)
                    //{
                    //    //FmMain.GetTaskInfo("包内烟数大于36！");
                    //    break;
                    //} 
                    buttonList[ListIndex].Text = "123";
                    buttonList[ListIndex].Visible = true;
                    buttonList[ListIndex].BackgroundImage = null;
                    buttonList[ListIndex].ForeColor = Color.Black;
                    buttonList[ListIndex].Font = font;
                    buttonList[ListIndex].TabIndex = TabeltIndex;
                    buttonList[ListIndex].BackColor = Color.Red;// ((detail.Speed == 0) ? Color.White : this.colorList[detail.TobaccoState].Color);
                    if(detail.CigType == "1")
                    {
                        buttonList[ListIndex].Height = normalHeight;
                        buttonList[ListIndex].Width = normalWidth;
                    }
                    else
                    {
                        buttonList[ListIndex].Height = (int)detail.TobaccoHeight;
                        buttonList[ListIndex].Width = (int)detail.TobaccoWidth;
                    } 
                    buttonList[ListIndex].AccessibleDescription = detail.CigType;
                    buttonList[ListIndex].Text = string.Concat(new string[]
                                {
                                    detail.GlobalIndex.ToString(),
                                    ".",
                                    detail.OrderIndex.ToString(),
                                    ".",
                                    detail.TobaccoName,
                                });
                    int x = 0;
                    int y = 0;

                    if (detail.CigType == "1")//常规烟
                    {

                        buttonList[ListIndex].Location = new Point(buttonList[ListIndex].Width + lastX, base.Height - buttonList[ListIndex].Height - layerHeight);
                        if (NormalCount % 6 == 0)
                        {
                            layerHeight = 48 * (NormalCount / 6);
                            lastX = -buttonList[ListIndex].Width;  
                            //buttonList[ListIndex].Location = new Point(buttonList[ListIndex].Width + lastX, base.Height - buttonList[ListIndex].Height + layerHeight);
                            // lastY = 0;
                        } 
                        //lastY += buttonList[ListIndex].Location.Y;
                        NormalCount++;
                        lastX += buttonList[ListIndex].Width;
                    }
                    else if(detail.CigType =="2")//异形烟
                    {
                        if (detail.DoubleTake == "21")//是双抓
                        {
                          
                            if (colorIndex == 1)//双抓第二条的时候
                            {
                                buttonList[ListIndex].BackColor = Color.White;
                                buttonList[ListIndex].Location = new Point((int)detail.PostionX + (int)(detail.TobaccoWidth / 2 )   , (int)detail.PostionY );
                                colorIndex = 0;
                            }
                            else
                            {
                                buttonList[ListIndex].Location = new Point((int)detail.PostionX - (int)(detail.TobaccoWidth / 2), (int)detail.PostionY );
                                buttonList[ListIndex].BackColor = Color.Red;
                                colorIndex++;
                            }
                        }
                        else
                        {
                            buttonList[ListIndex].Location = new Point((int)detail.PostionX  , (int)detail.PostionY );
                        }
                        if(detail.TobaccoState == 20)
                        {
                            buttonList[ListIndex].BackColor = Color.LightGreen;
                        }
                    } 
                    ListIndex++;
                    TabeltIndex++; 
                } 
            }
           
            int cigGap = GlobalPara.CigGap;//条烟之间间隙
            for (int i = 0; i < tbinfo.Count; i++)//每条烟的位置坐标都减去自身的宽度
            { 
                if (buttonList[i].AccessibleDescription == "1")
                {
                    int X = (int)(buttonList[i].Location.X - buttonList[i].Width);
                    buttonList[i].Location = new Point(X + cigGap, (buttonList[i].Location.Y - cigGap));
                } 
                if (buttonList[i].AccessibleDescription == "2")
                {
                    int X = (int)(buttonList[i].Location.X - Math.Ceiling((tbinfo[i].TobaccoWidth + cigGap) / 2));
                    buttonList[i].Location = new Point(X + cigGap,( buttonList[i].Location.Y  ) - (int)(tbinfo[i].NormalLayerNum * 48));
                } 
                
            }

          
            //if( list != null)
            //{
            //    decimal layer = list.NormalLayerNum;

            //    for (int i = 1; i <= layer; i++)
            //    {
            //        Button button = ButtonCreator.Create(this.p_Main , buttonList.Count + i);
            //        buttonList.Add(button);

            //    }
            //}
             
            


        }

        void CreatePosition(List<TobaccoInfo> tobaccoInfos,List<Button> buttons)
        {
            for (int i = 0; i < tobaccoInfos.Count; i++)
            {
                buttons[i].Text = "123";
                buttons[i].Visible = true;
                buttons[i].Text = string.Concat(new string[]
                              {
                                    tobaccoInfos[i].GlobalIndex.ToString(),
                                    ".",
                                     tobaccoInfos[i].OrderIndex.ToString(),
                                    ".",
                                     tobaccoInfos[i].TobaccoName,
                              });
            }
        }
        private void TobaccoShow_Resize(object sender, EventArgs e)
        {
            
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
            this.CreateButton(8,8);
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
  

        private int GetPositionIndex(int index)
        {
            return index;
        }
       
        private void btn_MouseEnter(object sender, EventArgs e)
        {
         
            Button btn = (Button)sender;
            tp_CodeInfo.SetToolTip(btn, buttonList[btn.TabIndex].Location.X + "  , " + (this.Height - buttonList[btn.TabIndex].Location.Y +"|"+ buttonList[btn.TabIndex].Height +","+ buttonList[btn.TabIndex].Width +"|" + buttonList[btn.TabIndex].Text));
          //  MessageBox.Show(buttonList[btn.TabIndex].Location.X + "  , " + buttonList[btn.TabIndex].Location.Y);
           // this.tp_CodeInfo.Show(button.ImageKey, button);
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
