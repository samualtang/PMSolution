using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using EFModle.Model;
//using PackLogic;
using PackageMachine.Code;

namespace PackageMachine
{
	// Token: 0x02000022 RID: 34
	public class TobaccoShow : UserControl
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600014C RID: 332 RVA: 0x000171F0 File Offset: 0x000153F0
		private int buttonCount
		{
			get
			{
				return this.lineCount * this.coloumCount;
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00017210 File Offset: 0x00015410
		public TobaccoShow()
		{
			this.InitializeComponent();
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
			//this.UesdBackImage = SysRuntimeParam.UesdBackImage;
			//this.UesdDifferBackImage = SysRuntimeParam.UesdDifferBackImage;
		}
      
		// Token: 0x0600014E RID: 334 RVA: 0x00017644 File Offset: 0x00015844
		private void CreateButton(int lineCount, int coloumCount)
		{
			this.lineCount = lineCount;
			this.coloumCount = coloumCount;
			this.buttonList = new List<Button>();
			int[][] sizeAndPosition = ButtonCreator.GetSizeAndPosition(base.Width + 2, base.Height + 2, 3, 4, lineCount, coloumCount);
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

		// Token: 0x0600014F RID: 335 RVA: 0x000177B4 File Offset: 0x000159B4
		private int GetPositionIndex(int index)
		{
			return index;
		}
        public void UpdateValue(List<TobaccoInfo> Linfo )
        {
           
            tbinfo = Linfo;
            this.UpdateTobaccoShow();
        }
        public List<TobaccoInfo> tbinfo = null;
        // Token: 0x06000151 RID: 337 RVA: 0x000178C8 File Offset: 0x00015AC8
        public void UpdateTobaccoShow( )
        {
            if ( buttonList == null)
            {
                this.CreateButton(7, 6);
            }
            else if ( buttonList.Count == 0)
            {
                this.CreateButton(7, 6);
            }
            else
            {
                foreach (ColorTobacco colorTobacco in this.colorList)
                {
                    colorTobacco.TobaccoName = "";
                }
                Font font = this.buttonList[0].Font;
                for (int j = 0; j < this.buttonList.Count; j++)
                {
                    this.buttonList[j].Visible = false;
                }

                float num = 530 * 200 / (float)(base.Width * base.Height);
                float num2 = 200 * (1f + num);
                int num3 = 0;
                int TabeltIndex = 0;
                TobaccoInfo detail;
                
                foreach (var item in tbinfo)
                {
                    detail = item;
                    this.buttonList[num3].Text = "123";
                    this.buttonList[num3].Visible = true;
                    this.buttonList[num3].BackgroundImage = null;
                    this.buttonList[num3].ForeColor = Color.Black;
                    this.buttonList[num3].Font = font;
                    this.buttonList[num3].TabIndex = TabeltIndex;
                    this.buttonList[num3].BackColor = ((detail.Speed == 0) ? Color.White : this.colorList[detail.TobaccoStatus].Color);
                    this.buttonList[num3].Height = (int)(detail.TobaccoHeight * (1f + num)); 
                    this.buttonList[num3].Width = (int)(detail.TobaccoWidth * (1f + num));
                    this.buttonList[num3].Top = this.p_Main.Height - (int)(detail.PositionHeight * (1f + num));
                    this.buttonList[num3].Left = this.p_Main.Width - (int)((detail.PositionWidth + detail.TobaccoWidth / 2f) * (1f + num));

                    this.buttonList[num3].Text = string.Concat(new string[]
                                {
                                    detail.GlobalIndex.ToString(),
                                    ".",
                                    detail.OrderIndex.ToString(),
                                    ".",
                                    detail.TobaccoName,
                                });

                    num3++;
                    TabeltIndex++;
                    break;
                }
            }
        }
 

		// Token: 0x06000154 RID: 340 RVA: 0x00018370 File Offset: 0x00016570
		private void TobaccoShow_Resize(object sender, EventArgs e)
		{
			//this.UpdateTobaccoShow();
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0001837A File Offset: 0x0001657A
		private void p_Main_MouseDoubleClick(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00018380 File Offset: 0x00016580
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

		// Token: 0x06000158 RID: 344 RVA: 0x000183CC File Offset: 0x000165CC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00018404 File Offset: 0x00016604
		private void InitializeComponent()
		{
			this.components = new Container();
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
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.p_Main);
			base.Margin = new Padding(4);
			base.Name = "TobaccoShow";
			base.Size = new Size(876, 489);
			base.Resize += this.TobaccoShow_Resize;
			this.p_Main.ResumeLayout(false);
			this.p_Main.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x0400014C RID: 332
		private List<Button> buttonList;
         

 
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

		// Token: 0x04000155 RID: 341
		private IContainer components = null;

		// Token: 0x04000156 RID: 342
		private Panel p_Main;

		// Token: 0x04000157 RID: 343
		private Timer timer1;

		// Token: 0x04000158 RID: 344
		private Label lab_Line;

		// Token: 0x04000159 RID: 345
		private ToolTip tp_CodeInfo;
	}
}
