namespace PackageMachine
{
    partial class FmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmMain));
            this.label10 = new System.Windows.Forms.Label();
            this.gbSysDate = new System.Windows.Forms.GroupBox();
            this.lblTask = new System.Windows.Forms.Label();
            this.lblFinshiTask = new System.Windows.Forms.Label();
            this.lblRobotState = new System.Windows.Forms.Label();
            this.lblServerInfo = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mune = new System.Windows.Forms.Panel();
            this.pbstatus = new System.Windows.Forms.PictureBox();
            this.pbSize = new System.Windows.Forms.PictureBox();
            this.pbConnSet = new System.Windows.Forms.PictureBox();
            this.pbUnionS = new System.Windows.Forms.PictureBox();
            this.pbInfo = new System.Windows.Forms.PictureBox();
            this.pbmaintitle = new System.Windows.Forms.Panel();
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.pbStop = new System.Windows.Forms.PictureBox();
            this.pbStart = new System.Windows.Forms.PictureBox();
            this.pbTitle = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.gbSysDate.SuspendLayout();
            this.mune.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbstatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbConnSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnionS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).BeginInit();
            this.pbmaintitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 12);
            this.label10.TabIndex = 0;
            // 
            // gbSysDate
            // 
            this.gbSysDate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbSysDate.Controls.Add(this.lblTask);
            this.gbSysDate.Controls.Add(this.lblFinshiTask);
            this.gbSysDate.Controls.Add(this.lblRobotState);
            this.gbSysDate.Controls.Add(this.lblServerInfo);
            this.gbSysDate.Controls.Add(this.label10);
            this.gbSysDate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbSysDate.Location = new System.Drawing.Point(0, 703);
            this.gbSysDate.Name = "gbSysDate";
            this.gbSysDate.Size = new System.Drawing.Size(1284, 38);
            this.gbSysDate.TabIndex = 76;
            this.gbSysDate.TabStop = false;
            this.gbSysDate.Text = "机器人信息：";
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.Location = new System.Drawing.Point(547, 17);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(53, 12);
            this.lblTask.TabIndex = 4;
            this.lblTask.Text = "发送任务";
            // 
            // lblFinshiTask
            // 
            this.lblFinshiTask.AutoSize = true;
            this.lblFinshiTask.Location = new System.Drawing.Point(116, 17);
            this.lblFinshiTask.Name = "lblFinshiTask";
            this.lblFinshiTask.Size = new System.Drawing.Size(53, 12);
            this.lblFinshiTask.TabIndex = 3;
            this.lblFinshiTask.Text = "完成任务";
            // 
            // lblRobotState
            // 
            this.lblRobotState.AutoSize = true;
            this.lblRobotState.Location = new System.Drawing.Point(12, 17);
            this.lblRobotState.Name = "lblRobotState";
            this.lblRobotState.Size = new System.Drawing.Size(65, 12);
            this.lblRobotState.TabIndex = 2;
            this.lblRobotState.Text = "机器人状态";
            // 
            // lblServerInfo
            // 
            this.lblServerInfo.AutoSize = true;
            this.lblServerInfo.Location = new System.Drawing.Point(1260, 17);
            this.lblServerInfo.Name = "lblServerInfo";
            this.lblServerInfo.Size = new System.Drawing.Size(53, 12);
            this.lblServerInfo.TabIndex = 1;
            this.lblServerInfo.Text = "系统信息";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // mune
            // 
            this.mune.BackColor = System.Drawing.SystemColors.Control;
            this.mune.BackgroundImage = global::PackageMachine.Properties.Resources.菜单背景;
            this.mune.Controls.Add(this.pbstatus);
            this.mune.Controls.Add(this.pbSize);
            this.mune.Controls.Add(this.pbConnSet);
            this.mune.Controls.Add(this.pbUnionS);
            this.mune.Controls.Add(this.pbInfo);
            this.mune.Dock = System.Windows.Forms.DockStyle.Left;
            this.mune.Location = new System.Drawing.Point(0, 40);
            this.mune.Name = "mune";
            this.mune.Size = new System.Drawing.Size(76, 663);
            this.mune.TabIndex = 79;
            // 
            // pbstatus
            // 
            this.pbstatus.BackgroundImage = global::PackageMachine.Properties.Resources.尺寸维护;
            this.pbstatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbstatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbstatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbstatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbstatus.Image = global::PackageMachine.Properties.Resources.状态查询;
            this.pbstatus.Location = new System.Drawing.Point(0, 220);
            this.pbstatus.Name = "pbstatus";
            this.pbstatus.Size = new System.Drawing.Size(76, 56);
            this.pbstatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbstatus.TabIndex = 5;
            this.pbstatus.TabStop = false;
            this.pbstatus.Click += new System.EventHandler(this.pbstatus_Click);
            // 
            // pbSize
            // 
            this.pbSize.BackgroundImage = global::PackageMachine.Properties.Resources.尺寸维护;
            this.pbSize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbSize.Location = new System.Drawing.Point(0, 165);
            this.pbSize.Name = "pbSize";
            this.pbSize.Size = new System.Drawing.Size(76, 55);
            this.pbSize.TabIndex = 4;
            this.pbSize.TabStop = false;
            this.pbSize.Click += new System.EventHandler(this.pbSize_Click);
            // 
            // pbConnSet
            // 
            this.pbConnSet.BackgroundImage = global::PackageMachine.Properties.Resources.连接配置;
            this.pbConnSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbConnSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbConnSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbConnSet.Location = new System.Drawing.Point(0, 110);
            this.pbConnSet.Name = "pbConnSet";
            this.pbConnSet.Size = new System.Drawing.Size(76, 55);
            this.pbConnSet.TabIndex = 3;
            this.pbConnSet.TabStop = false;
            this.pbConnSet.Click += new System.EventHandler(this.pbConnSet_Click);
            // 
            // pbUnionS
            // 
            this.pbUnionS.BackgroundImage = global::PackageMachine.Properties.Resources.综合查询;
            this.pbUnionS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbUnionS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbUnionS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbUnionS.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbUnionS.Location = new System.Drawing.Point(0, 55);
            this.pbUnionS.Name = "pbUnionS";
            this.pbUnionS.Size = new System.Drawing.Size(76, 55);
            this.pbUnionS.TabIndex = 2;
            this.pbUnionS.TabStop = false;
            this.pbUnionS.Click += new System.EventHandler(this.pbUnionS_Click);
            // 
            // pbInfo
            // 
            this.pbInfo.BackgroundImage = global::PackageMachine.Properties.Resources.任务信息;
            this.pbInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbInfo.Location = new System.Drawing.Point(0, 0);
            this.pbInfo.Name = "pbInfo";
            this.pbInfo.Size = new System.Drawing.Size(76, 55);
            this.pbInfo.TabIndex = 0;
            this.pbInfo.TabStop = false;
            this.pbInfo.Click += new System.EventHandler(this.pbInfo_Click);
            // 
            // pbmaintitle
            // 
            this.pbmaintitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pbmaintitle.BackColor = System.Drawing.SystemColors.Control;
            this.pbmaintitle.BackgroundImage = global::PackageMachine.Properties.Resources.上层背景;
            this.pbmaintitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbmaintitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbmaintitle.Controls.Add(this.pbExit);
            this.pbmaintitle.Controls.Add(this.pbStop);
            this.pbmaintitle.Controls.Add(this.pbStart);
            this.pbmaintitle.Controls.Add(this.pbTitle);
            this.pbmaintitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbmaintitle.Location = new System.Drawing.Point(0, 0);
            this.pbmaintitle.Name = "pbmaintitle";
            this.pbmaintitle.Size = new System.Drawing.Size(1284, 40);
            this.pbmaintitle.TabIndex = 77;
            this.pbmaintitle.Paint += new System.Windows.Forms.PaintEventHandler(this.pbmaintitle_Paint);
            // 
            // pbExit
            // 
            this.pbExit.BackColor = System.Drawing.SystemColors.Highlight;
            this.pbExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbExit.BackgroundImage")));
            this.pbExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbExit.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbExit.Location = new System.Drawing.Point(466, 0);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(114, 38);
            this.pbExit.TabIndex = 8;
            this.pbExit.TabStop = false;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // pbStop
            // 
            this.pbStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbStop.BackgroundImage")));
            this.pbStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbStop.Cursor = System.Windows.Forms.Cursors.No;
            this.pbStop.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbStop.Location = new System.Drawing.Point(346, 0);
            this.pbStop.Name = "pbStop";
            this.pbStop.Size = new System.Drawing.Size(120, 38);
            this.pbStop.TabIndex = 7;
            this.pbStop.TabStop = false;
            this.pbStop.Click += new System.EventHandler(this.pbStop_Click);
            // 
            // pbStart
            // 
            this.pbStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbStart.BackgroundImage")));
            this.pbStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbStart.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbStart.Location = new System.Drawing.Point(234, 0);
            this.pbStart.Name = "pbStart";
            this.pbStart.Size = new System.Drawing.Size(112, 38);
            this.pbStart.TabIndex = 6;
            this.pbStart.TabStop = false;
            this.pbStart.Click += new System.EventHandler(this.pbStart_Click);
            // 
            // pbTitle
            // 
            this.pbTitle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbTitle.BackgroundImage")));
            this.pbTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbTitle.Location = new System.Drawing.Point(0, 0);
            this.pbTitle.Name = "pbTitle";
            this.pbTitle.Size = new System.Drawing.Size(234, 38);
            this.pbTitle.TabIndex = 3;
            this.pbTitle.TabStop = false;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // FmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 741);
            this.Controls.Add(this.mune);
            this.Controls.Add(this.pbmaintitle);
            this.Controls.Add(this.gbSysDate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FmMain";
            this.Text = "包装机系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FmMain_FormClosing);
            this.SizeChanged += new System.EventHandler(this.FmMain_SizeChanged);
            this.gbSysDate.ResumeLayout(false);
            this.gbSysDate.PerformLayout();
            this.mune.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbstatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbConnSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnionS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).EndInit();
            this.pbmaintitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbSize;
        private System.Windows.Forms.PictureBox pbConnSet;
        private System.Windows.Forms.PictureBox pbUnionS;
        private System.Windows.Forms.PictureBox pbInfo;
        private System.Windows.Forms.Panel mune;
        private System.Windows.Forms.PictureBox pbExit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pbmaintitle;
        private System.Windows.Forms.PictureBox pbStop;
        private System.Windows.Forms.PictureBox pbStart;
        private System.Windows.Forms.PictureBox pbTitle;
        private System.Windows.Forms.GroupBox gbSysDate;
        private System.Windows.Forms.Label lblServerInfo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.Label lblFinshiTask;
        private System.Windows.Forms.Label lblRobotState;
        private System.Windows.Forms.PictureBox pbstatus;
        private System.Windows.Forms.Timer timer2;
    }
}

