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
           
            this.p_Main.Dock = DockStyle.Fill;
            this.p_Main.Location = new Point(0, 0);
            this.p_Main.Margin = new Padding(4);
            this.p_Main.Name = "p_Main";
            this.p_Main.Size = new Size(W, H);
            this.p_Main.TabIndex = 0; 
            this.lab_Line.AutoSize = true;
            this.lab_Line.Location = new Point(0, 88); 
            this.lab_Line.Margin = new Padding(4, 0, 4, 0);
            this.lab_Line.Name = "lab_Line";
            this.lab_Line.Size = new Size(1029, 15);
            this.lab_Line.TabIndex = 0;
           
            this.lab_Line.Text = "限高----------------------------------------------------------------------------------------------------------------------------";
            lab_Line.BackColor = Color.Transparent;
            lab_Line.Parent = p_Main;
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
            this.p_Main.Controls.Add(this.lab_Line);
            ShowLoad();
        }



        /// <summary>
        /// 更新垛型显示层
        /// </summary>
        /// <param name="ListInfo">卷烟垛型信息</param>\
        /// <param name="type">显示类型（0为全部），1为常规烟，2为异形烟</param>
        public void UpdateValue(List<TobaccoInfo> ListInfo,int type = 0)
        { 
            tbinfo = SecondaryCalculation(ListInfo);
            switch (type)
            { 
                case 1:
                    tbinfo = tbinfo.Where(a => a.CigType == "1").ToList();
                    break;
                case 2:
                    tbinfo = tbinfo.Where(a => a.CigType == "2").ToList();
                    break; 
            }
            if(tbinfo .Count > 64)
            {
                FmInfo.GetTaskInfo("包内条数大于64,实际数量：" + tbinfo.Count + "，包烟流水号：" + tbinfo[0].GlobalIndex);
                
                return;
            }
            this.UpdateTobaccoShow( );
        }

      
        /// <summary>
        /// 显示层算法实现
        /// </summary>
         void UpdateTobaccoShow( )
        {
          
            int layerHeight = 0; //常规烟有多少层
            int AddHeight =  0;
            int AddWidth = 0;
            if (!buttonList.Any())
            {
                CreateButton(6, 6);
            }
            else
            {
                for (int i = 0; i < buttonList.Count; i++)
                {
                    buttonList[i].Visible = false;
                }
                Font font = this.buttonList[0].Font;
                int ListIndex = 0;
                int TabeltIndex = 0;
                int colorIndex = 0;
                int normalHeight = 48;
                int normalWidth = 91;
                int lastX = 0;
                int NormalCount = 1;
                int normalIndex = 1;
                foreach (var detail in tbinfo)
                {
                    buttonList[ListIndex].Text = "123";
                    buttonList[ListIndex].Visible = true;
                    buttonList[ListIndex].BackgroundImage = null;
                    buttonList[ListIndex].ForeColor = Color.Black;
                    buttonList[ListIndex].Font = font;
                    buttonList[ListIndex].TabIndex = TabeltIndex;
                    if (detail.CigType == "1")
                    {
                        buttonList[ListIndex].Height = normalHeight + AddHeight;
                        buttonList[ListIndex].Width = normalWidth + AddWidth;
                        buttonList[ListIndex].Text = string.Concat(new string[]
                               {
                                    detail.GlobalIndex.ToString(),
                                    ".",
                                   normalIndex++.ToString(),
                                    ".",
                                    detail.TobaccoName,
                               });
                        buttonList[ListIndex].BackColor = Color.Gray;
                    }
                    else
                    {
                        buttonList[ListIndex].Height = (int)detail.TobaccoHeight + AddHeight;
                        buttonList[ListIndex].Width = (int)detail.TobaccoWidth + AddWidth;
                        buttonList[ListIndex].Text = string.Concat(new string[]
                               {
                                    detail.GlobalIndex.ToString(),
                                    ".",
                                    detail.OrderIndex.ToString(),
                                    ".",
                                    detail.TobaccoName,
                               });
                        buttonList[ListIndex].BackColor = Color.White;
                    }
                    buttonList[ListIndex].AccessibleDescription = detail.CigType; 
                    if (detail.CigType == "1")//常规烟
                    {
                        buttonList[ListIndex].Location = new Point(buttonList[ListIndex].Width + lastX, base.Height - buttonList[ListIndex].Height - layerHeight);
                        if (NormalCount % 6 == 0)
                        {
                            layerHeight = (48 + AddHeight) * (NormalCount / 6);
                            lastX = -buttonList[ListIndex].Width;
                        }
                        NormalCount++;
                        lastX += buttonList[ListIndex].Width;
                    }
                    else if (detail.CigType == "2")//异形烟
                    {
                        if (detail.DoubleTake == "1")//是双抓
                        {

                            if (colorIndex == 1)//双抓第二条的时候
                            {
                                buttonList[ListIndex].BackColor = Color.Yellow;
                                buttonList[ListIndex].Location = new Point((int)detail.PostionX + (int)(detail.TobaccoWidth / 2), (int)detail.PostionY);
                                colorIndex = 0;
                            }
                            else
                            {
                                buttonList[ListIndex].Location = new Point((int)detail.PostionX - (int)(detail.TobaccoWidth / 2), (int)detail.PostionY);
                                buttonList[ListIndex].BackColor = Color.Yellow;
                                colorIndex++;
                            }
                        }
                        else
                        {
                            buttonList[ListIndex].Location = new Point((int)detail.PostionX, (int)detail.PostionY);
                        }
                        if (detail.TobaccoState == 20)
                        {
                            buttonList[ListIndex].BackColor = Color.LightGreen;
                        }
                    }
                    ListIndex++;
                    TabeltIndex++;
                }
            }



            if(tbinfo.Where(a => a.CigType == "1").Count() > 0 && tbinfo.Where(a => a.CigType == "2").Count() > 0)//合包
            {
                tbinfo[0].NormalLayerNum = tbinfo[0].NormalLayerNum -1;
            }
              else if (tbinfo.Where(a => a.CigType == "1").Count() == 0)//纯异型烟
            {
                tbinfo[0].NormalLayerNum = 0  ;
            }
            else if (tbinfo.Where(a => a.CigType == "2").Count() == 0)//纯常规烟
            {
                tbinfo[0].NormalLayerNum = 0;
            }

            int cigGap = GlobalPara.CigGap;//条烟之间间隙
            for (int i = 0; i < tbinfo.Count; i++)//每条烟的位置坐标都减去自身的宽度
            { 
                if (buttonList[i].AccessibleDescription == "1")
                {
                    int X = (int)(buttonList[i].Location.X - buttonList[i].Width);
                    buttonList[i].Location = new Point(X + cigGap, (buttonList[i].Location.Y ));
                } 
                if (buttonList[i].AccessibleDescription == "2")
                {
                    int X = (int)((buttonList[i].Location.X ) - (buttonList[i].Width) / 2);
                    buttonList[i].Location = new Point(X + cigGap+AddWidth, (buttonList[i].Location.Y  ) - ((int)tbinfo[0].NormalLayerNum) * (48+AddHeight  ) -AddHeight);
                }
                
            }
            //foreach (var item in buttonList)
            //{
            //    if (item.Location.X > 0)
            //    {
            //        if (item.AccessibleDescription == "2")
            //        {
            //            int x = item.Location.X;// + AddWidth / 2;
            //            int y = item.Location.Y - AddHeight;
            //            item.Location = new Point(x, y);
            //        }

            //    }
            //}
            //MessageBox.Show("" + p_Main.Width + "|" + p_Main.Height);
        }
        List<TobaccoInfo> SecondaryCalculation(List<TobaccoInfo> list)
        {
            List<TobaccoInfo> Newlist = new List<TobaccoInfo>();
          
            if (list.Any())
            {
                foreach (var item in list)
                {
                    if (item.CigType == "1")//常规烟
                    {
                        if (item.CigQuantity > 1)
                        {
                            int index =(int) item.CigQuantity;
                            for (int i = 0; i < index ; i++)//看常规烟数量有多少条
                            {
                                item.CigQuantity = 1; 
                                Newlist.Add(item);
                             
                            }
                        }
                        else
                        { 
                            Newlist.Add(item);
                         
                        } 
                    }
                    else
                    {
                        Newlist.Add(item);
                    } 
                }
            }
            return Newlist;
        }
    
        private void TobaccoShow_Resize(object sender, EventArgs e)
        {
           // lab_Line.Location = new Point(lab_Line.Location.X,  p_Main.Height /4  );
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
                button.Click += Button_Click;
                this.buttonList.Add(button);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            MessageBox.Show("" + btn.Location.X + " | " + btn.Location.Y + " | " + btn.Width + " | " + btn.Height +" | "+base.Height);
        }

        private int GetPositionIndex(int index)
        {
            return index;
        }
       
        private void btn_MouseEnter(object sender, EventArgs e)
        {
         
            Button btn = (Button)sender;
            tp_CodeInfo.SetToolTip(btn, buttonList[btn.TabIndex].Location.X + "  , " + (this.Height - buttonList[btn.TabIndex].Location.Y +"|"+ buttonList[btn.TabIndex].Height +","+ buttonList[btn.TabIndex].Width +"|" + buttonList[btn.TabIndex].Text));
        
        }

    
        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button win = (Button)sender;
            this.tp_CodeInfo.Hide(win);
        }
        // Token: 0x0400014C RID: 332
        private List<Button> buttonList;

        public int W { get; set; }
        public int H { get; set; }


 
        private int lineCount;
 
        private int coloumCount;



         
        private List<ColorTobacco> colorList = new List<ColorTobacco>();
          
       
        private Panel p_Main; 
        private Timer timer1; 
        private Label lab_Line; 
        private ToolTip tp_CodeInfo;

        public List<TobaccoInfo> tbinfo = null;
    }
}
