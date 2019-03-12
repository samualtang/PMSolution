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
            this.lblrotcount = new System.Windows.Forms.Label();
            this.gbNormail = new System.Windows.Forms.GroupBox();
            this.lblcutcount = new System.Windows.Forms.Label();
            this.lblfbcount = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblcutname = new System.Windows.Forms.Label();
            this.lblcutcode = new System.Windows.Forms.Label();
            this.lblallcount = new System.Windows.Forms.Label();
            this.lblpackageCOunt = new System.Windows.Forms.Label();
            this.lblorderdate = new System.Windows.Forms.Label();
            this.lbllinename = new System.Windows.Forms.Label();
            this.gbCache = new System.Windows.Forms.GroupBox();
            this.gbUnnorl = new System.Windows.Forms.GroupBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.gbSysDate = new System.Windows.Forms.GroupBox();
            this.lblServerInfo = new System.Windows.Forms.Label();
            this.mune = new System.Windows.Forms.Panel();
            this.pbSize = new System.Windows.Forms.PictureBox();
            this.pbConnSet = new System.Windows.Forms.PictureBox();
            this.pbUnionS = new System.Windows.Forms.PictureBox();
            this.pbInfo = new System.Windows.Forms.PictureBox();
            this.pbmaintitle = new System.Windows.Forms.Panel();
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.pbStop = new System.Windows.Forms.PictureBox();
            this.pbStart = new System.Windows.Forms.PictureBox();
            this.pbTitle = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox4.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.gbSysDate.SuspendLayout();
            this.mune.SuspendLayout();
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
            // lblrotcount
            // 
            this.lblrotcount.AutoSize = true;
            this.lblrotcount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblrotcount.ForeColor = System.Drawing.Color.Red;
            this.lblrotcount.Location = new System.Drawing.Point(1106, 63);
            this.lblrotcount.Name = "lblrotcount";
            this.lblrotcount.Size = new System.Drawing.Size(124, 21);
            this.lblrotcount.TabIndex = 7;
            this.lblrotcount.Text = "机器人数量：12";
            // 
            // gbNormail
            // 
            this.gbNormail.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbNormail.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbNormail.Location = new System.Drawing.Point(0, 234);
            this.gbNormail.Name = "gbNormail";
            this.gbNormail.Size = new System.Drawing.Size(293, 205);
            this.gbNormail.TabIndex = 6;
            this.gbNormail.TabStop = false;
            this.gbNormail.Text = "常规烟工位";
            // 
            // lblcutcount
            // 
            this.lblcutcount.AutoSize = true;
            this.lblcutcount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcutcount.ForeColor = System.Drawing.Color.Red;
            this.lblcutcount.Location = new System.Drawing.Point(289, 75);
            this.lblcutcount.Name = "lblcutcount";
            this.lblcutcount.Size = new System.Drawing.Size(115, 21);
            this.lblcutcount.TabIndex = 6;
            this.lblcutcount.Text = "客户包数：2-2";
            // 
            // lblfbcount
            // 
            this.lblfbcount.AutoSize = true;
            this.lblfbcount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblfbcount.ForeColor = System.Drawing.Color.Red;
            this.lblfbcount.Location = new System.Drawing.Point(1106, 39);
            this.lblfbcount.Name = "lblfbcount";
            this.lblfbcount.Size = new System.Drawing.Size(108, 21);
            this.lblfbcount.TabIndex = 8;
            this.lblfbcount.Text = "翻版数量：30";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblfbcount);
            this.groupBox4.Controls.Add(this.lblrotcount);
            this.groupBox4.Controls.Add(this.lblcutcount);
            this.groupBox4.Controls.Add(this.lblcutname);
            this.groupBox4.Controls.Add(this.lblcutcode);
            this.groupBox4.Controls.Add(this.lblallcount);
            this.groupBox4.Controls.Add(this.lblpackageCOunt);
            this.groupBox4.Controls.Add(this.lblorderdate);
            this.groupBox4.Controls.Add(this.lbllinename);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(0, 100);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(962, 134);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "订单信息";
            // 
            // lblcutname
            // 
            this.lblcutname.AutoSize = true;
            this.lblcutname.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcutname.ForeColor = System.Drawing.Color.Red;
            this.lblcutname.Location = new System.Drawing.Point(32, 104);
            this.lblcutname.Name = "lblcutname";
            this.lblcutname.Size = new System.Drawing.Size(154, 21);
            this.lblcutname.TabIndex = 5;
            this.lblcutname.Text = "客户名称：芙蓉兴盛";
            // 
            // lblcutcode
            // 
            this.lblcutcode.AutoSize = true;
            this.lblcutcode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcutcode.ForeColor = System.Drawing.Color.Red;
            this.lblcutcode.Location = new System.Drawing.Point(32, 75);
            this.lblcutcode.Name = "lblcutcode";
            this.lblcutcode.Size = new System.Drawing.Size(235, 21);
            this.lblcutcode.TabIndex = 4;
            this.lblcutcode.Text = "客户代码：2=》430101119472";
            // 
            // lblallcount
            // 
            this.lblallcount.AutoSize = true;
            this.lblallcount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblallcount.ForeColor = System.Drawing.Color.Red;
            this.lblallcount.Location = new System.Drawing.Point(289, 51);
            this.lblallcount.Name = "lblallcount";
            this.lblallcount.Size = new System.Drawing.Size(163, 21);
            this.lblallcount.TabIndex = 3;
            this.lblallcount.Text = "总 包 号：1844-1119";
            // 
            // lblpackageCOunt
            // 
            this.lblpackageCOunt.AutoSize = true;
            this.lblpackageCOunt.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpackageCOunt.ForeColor = System.Drawing.Color.Red;
            this.lblpackageCOunt.Location = new System.Drawing.Point(32, 51);
            this.lblpackageCOunt.Name = "lblpackageCOunt";
            this.lblpackageCOunt.Size = new System.Drawing.Size(163, 21);
            this.lblpackageCOunt.TabIndex = 2;
            this.lblpackageCOunt.Text = "总 包 号：1844-1119";
            // 
            // lblorderdate
            // 
            this.lblorderdate.AutoSize = true;
            this.lblorderdate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblorderdate.ForeColor = System.Drawing.Color.Black;
            this.lblorderdate.Location = new System.Drawing.Point(289, 29);
            this.lblorderdate.Name = "lblorderdate";
            this.lblorderdate.Size = new System.Drawing.Size(284, 21);
            this.lblorderdate.TabIndex = 1;
            this.lblorderdate.Text = "订单日期：2019/1/28（包装机任务） ";
            // 
            // lbllinename
            // 
            this.lbllinename.AutoSize = true;
            this.lbllinename.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbllinename.ForeColor = System.Drawing.Color.Black;
            this.lbllinename.Location = new System.Drawing.Point(32, 29);
            this.lbllinename.Name = "lbllinename";
            this.lbllinename.Size = new System.Drawing.Size(202, 21);
            this.lbllinename.TabIndex = 0;
            this.lbllinename.Text = "线路名称：0207[201-129] ";
            // 
            // gbCache
            // 
            this.gbCache.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCache.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbCache.Location = new System.Drawing.Point(0, 0);
            this.gbCache.Name = "gbCache";
            this.gbCache.Size = new System.Drawing.Size(962, 100);
            this.gbCache.TabIndex = 4;
            this.gbCache.TabStop = false;
            this.gbCache.Text = "皮带缓存";
            // 
            // gbUnnorl
            // 
            this.gbUnnorl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbUnnorl.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbUnnorl.Location = new System.Drawing.Point(293, 234);
            this.gbUnnorl.Name = "gbUnnorl";
            this.gbUnnorl.Size = new System.Drawing.Size(669, 205);
            this.gbUnnorl.TabIndex = 7;
            this.gbUnnorl.TabStop = false;
            this.gbUnnorl.Text = "异型烟工位";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.gbUnnorl);
            this.panelMain.Controls.Add(this.gbNormail);
            this.panelMain.Controls.Add(this.groupBox4);
            this.panelMain.Controls.Add(this.gbCache);
            this.panelMain.Location = new System.Drawing.Point(176, 112);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(962, 439);
            this.panelMain.TabIndex = 80;
            this.panelMain.Visible = false;
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
            this.gbSysDate.Controls.Add(this.lblServerInfo);
            this.gbSysDate.Controls.Add(this.label10);
            this.gbSysDate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbSysDate.Location = new System.Drawing.Point(0, 703);
            this.gbSysDate.Name = "gbSysDate";
            this.gbSysDate.Size = new System.Drawing.Size(1362, 38);
            this.gbSysDate.TabIndex = 76;
            this.gbSysDate.TabStop = false;
            this.gbSysDate.Text = "系统信息：";
            // 
            // lblServerInfo
            // 
            this.lblServerInfo.AutoSize = true;
            this.lblServerInfo.Location = new System.Drawing.Point(36, 17);
            this.lblServerInfo.Name = "lblServerInfo";
            this.lblServerInfo.Size = new System.Drawing.Size(53, 12);
            this.lblServerInfo.TabIndex = 1;
            this.lblServerInfo.Text = "系统信息";
            // 
            // mune
            // 
            this.mune.BackColor = System.Drawing.SystemColors.Control;
            this.mune.BackgroundImage = global::PackageMachine.Properties.Resources.菜单背景;
            this.mune.Controls.Add(this.pbSize);
            this.mune.Controls.Add(this.pbConnSet);
            this.mune.Controls.Add(this.pbUnionS);
            this.mune.Controls.Add(this.pbInfo);
            this.mune.Dock = System.Windows.Forms.DockStyle.Left;
            this.mune.Location = new System.Drawing.Point(0, 80);
            this.mune.Name = "mune";
            this.mune.Size = new System.Drawing.Size(134, 623);
            this.mune.TabIndex = 79;
            // 
            // pbSize
            // 
            this.pbSize.BackgroundImage = global::PackageMachine.Properties.Resources.尺寸维护;
            this.pbSize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbSize.Location = new System.Drawing.Point(0, 270);
            this.pbSize.Name = "pbSize";
            this.pbSize.Size = new System.Drawing.Size(134, 90);
            this.pbSize.TabIndex = 4;
            this.pbSize.TabStop = false;
            this.pbSize.Click += new System.EventHandler(this.pbSize_Click);
            // 
            // pbConnSet
            // 
            this.pbConnSet.BackgroundImage = global::PackageMachine.Properties.Resources.连接配置;
            this.pbConnSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbConnSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbConnSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbConnSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbConnSet.Location = new System.Drawing.Point(0, 180);
            this.pbConnSet.Name = "pbConnSet";
            this.pbConnSet.Size = new System.Drawing.Size(134, 90);
            this.pbConnSet.TabIndex = 3;
            this.pbConnSet.TabStop = false;
            this.pbConnSet.Click += new System.EventHandler(this.pbConnSet_Click);
            // 
            // pbUnionS
            // 
            this.pbUnionS.BackgroundImage = global::PackageMachine.Properties.Resources.综合查询;
            this.pbUnionS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbUnionS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbUnionS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbUnionS.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbUnionS.Location = new System.Drawing.Point(0, 90);
            this.pbUnionS.Name = "pbUnionS";
            this.pbUnionS.Size = new System.Drawing.Size(134, 90);
            this.pbUnionS.TabIndex = 2;
            this.pbUnionS.TabStop = false;
            this.pbUnionS.Click += new System.EventHandler(this.pbUnionS_Click);
            // 
            // pbInfo
            // 
            this.pbInfo.BackgroundImage = global::PackageMachine.Properties.Resources.任务信息;
            this.pbInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbInfo.Location = new System.Drawing.Point(0, 0);
            this.pbInfo.Name = "pbInfo";
            this.pbInfo.Size = new System.Drawing.Size(134, 90);
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
            this.pbmaintitle.Size = new System.Drawing.Size(1362, 80);
            this.pbmaintitle.TabIndex = 77;
            // 
            // pbExit
            // 
            this.pbExit.BackColor = System.Drawing.SystemColors.Highlight;
            this.pbExit.BackgroundImage = global::PackageMachine.Properties.Resources.退出系统;
            this.pbExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbExit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbExit.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbExit.Location = new System.Drawing.Point(513, 0);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(114, 78);
            this.pbExit.TabIndex = 8;
            this.pbExit.TabStop = false;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // pbStop
            // 
            this.pbStop.BackgroundImage = global::PackageMachine.Properties.Resources.暂停任务;
            this.pbStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbStop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbStop.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbStop.Location = new System.Drawing.Point(393, 0);
            this.pbStop.Name = "pbStop";
            this.pbStop.Size = new System.Drawing.Size(120, 78);
            this.pbStop.TabIndex = 7;
            this.pbStop.TabStop = false;
            this.pbStop.Click += new System.EventHandler(this.pbStop_Click);
            // 
            // pbStart
            // 
            this.pbStart.BackgroundImage = global::PackageMachine.Properties.Resources.开始任务;
            this.pbStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbStart.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbStart.Location = new System.Drawing.Point(275, 0);
            this.pbStart.Name = "pbStart";
            this.pbStart.Size = new System.Drawing.Size(118, 78);
            this.pbStart.TabIndex = 6;
            this.pbStart.TabStop = false;
            this.pbStart.Click += new System.EventHandler(this.pbStart_Click);
            // 
            // pbTitle
            // 
            this.pbTitle.BackgroundImage = global::PackageMachine.Properties.Resources.标题;
            this.pbTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbTitle.Location = new System.Drawing.Point(0, 0);
            this.pbTitle.Name = "pbTitle";
            this.pbTitle.Size = new System.Drawing.Size(275, 78);
            this.pbTitle.TabIndex = 3;
            this.pbTitle.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // FmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.mune);
            this.Controls.Add(this.pbmaintitle);
            this.Controls.Add(this.gbSysDate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FmMain";
            this.Text = "包装机系统";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.gbSysDate.ResumeLayout(false);
            this.gbSysDate.PerformLayout();
            this.mune.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblrotcount;
        private System.Windows.Forms.GroupBox gbNormail;
        private System.Windows.Forms.Label lblcutcount;
        private System.Windows.Forms.Label lblfbcount;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblcutname;
        private System.Windows.Forms.Label lblcutcode;
        private System.Windows.Forms.Label lblallcount;
        private System.Windows.Forms.Label lblpackageCOunt;
        private System.Windows.Forms.Label lblorderdate;
        private System.Windows.Forms.Label lbllinename;
        private System.Windows.Forms.GroupBox gbCache;
        private System.Windows.Forms.GroupBox gbUnnorl;
        private System.Windows.Forms.Panel panelMain;
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
    }
}

