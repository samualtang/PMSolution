namespace PackageMachine
{
    partial class FmInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

    
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnnext = new System.Windows.Forms.Button();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.lblCache = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblcutcount = new System.Windows.Forms.Label();
            this.lblcutname = new System.Windows.Forms.Label();
            this.lblcutcode = new System.Windows.Forms.Label();
            this.lblallcount = new System.Windows.Forms.Label();
            this.lblorderdate = new System.Windows.Forms.Label();
            this.lbllinename = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.list_date = new System.Windows.Forms.ListBox();
            this.cce1 = new PackageMachine.CigrCache();
            this.cs = new PackageMachine.CigrShow();
            this.panelInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(199, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(291, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(431, 37);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 1;
            this.textBox2.Visible = false;
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(11, 35);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(75, 23);
            this.btnLast.TabIndex = 2;
            this.btnLast.Text = "上一个";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnnext
            // 
            this.btnnext.Location = new System.Drawing.Point(92, 35);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(75, 23);
            this.btnnext.TabIndex = 2;
            this.btnnext.Text = "下一个";
            this.btnnext.UseVisualStyleBackColor = true;
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            // 
            // panelInfo
            // 
            this.panelInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInfo.Controls.Add(this.gbInfo);
            this.panelInfo.Controls.Add(this.btnnext);
            this.panelInfo.Controls.Add(this.btnLast);
            this.panelInfo.Controls.Add(this.button1);
            this.panelInfo.Controls.Add(this.textBox1);
            this.panelInfo.Controls.Add(this.textBox2);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(1194, 90);
            this.panelInfo.TabIndex = 5;
            // 
            // lblCache
            // 
            this.lblCache.AutoSize = true;
            this.lblCache.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lblCache.Location = new System.Drawing.Point(24, 25);
            this.lblCache.Name = "lblCache";
            this.lblCache.Size = new System.Drawing.Size(114, 20);
            this.lblCache.TabIndex = 7;
            this.lblCache.Text = "异形烟缓存皮带";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cce1);
            this.panel1.Controls.Add(this.lblCache);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1018, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 608);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblcutcount);
            this.panel2.Controls.Add(this.lblcutname);
            this.panel2.Controls.Add(this.lblcutcode);
            this.panel2.Controls.Add(this.lblallcount);
            this.panel2.Controls.Add(this.lblorderdate);
            this.panel2.Controls.Add(this.lbllinename);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1018, 122);
            this.panel2.TabIndex = 9;
            // 
            // lblcutcount
            // 
            this.lblcutcount.AutoSize = true;
            this.lblcutcount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcutcount.ForeColor = System.Drawing.Color.Red;
            this.lblcutcount.Location = new System.Drawing.Point(507, 57);
            this.lblcutcount.Name = "lblcutcount";
            this.lblcutcount.Size = new System.Drawing.Size(115, 21);
            this.lblcutcount.TabIndex = 19;
            this.lblcutcount.Text = "客户包数：2-2";
            // 
            // lblcutname
            // 
            this.lblcutname.AutoSize = true;
            this.lblcutname.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcutname.ForeColor = System.Drawing.Color.Red;
            this.lblcutname.Location = new System.Drawing.Point(21, 62);
            this.lblcutname.Name = "lblcutname";
            this.lblcutname.Size = new System.Drawing.Size(154, 21);
            this.lblcutname.TabIndex = 18;
            this.lblcutname.Text = "客户名称：芙蓉兴盛";
            // 
            // lblcutcode
            // 
            this.lblcutcode.AutoSize = true;
            this.lblcutcode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcutcode.ForeColor = System.Drawing.Color.Red;
            this.lblcutcode.Location = new System.Drawing.Point(21, 33);
            this.lblcutcode.Name = "lblcutcode";
            this.lblcutcode.Size = new System.Drawing.Size(251, 21);
            this.lblcutcode.TabIndex = 17;
            this.lblcutcode.Text = "任务流水号：2=》430101119472";
            // 
            // lblallcount
            // 
            this.lblallcount.AutoSize = true;
            this.lblallcount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblallcount.ForeColor = System.Drawing.Color.Red;
            this.lblallcount.Location = new System.Drawing.Point(507, 33);
            this.lblallcount.Name = "lblallcount";
            this.lblallcount.Size = new System.Drawing.Size(163, 21);
            this.lblallcount.TabIndex = 16;
            this.lblallcount.Text = "总 包 号：1844-1119";
            // 
            // lblorderdate
            // 
            this.lblorderdate.AutoSize = true;
            this.lblorderdate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblorderdate.ForeColor = System.Drawing.Color.Black;
            this.lblorderdate.Location = new System.Drawing.Point(507, 11);
            this.lblorderdate.Name = "lblorderdate";
            this.lblorderdate.Size = new System.Drawing.Size(284, 21);
            this.lblorderdate.TabIndex = 15;
            this.lblorderdate.Text = "订单日期：2019/1/28（包装机任务） ";
            // 
            // lbllinename
            // 
            this.lbllinename.AutoSize = true;
            this.lbllinename.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbllinename.ForeColor = System.Drawing.Color.Black;
            this.lbllinename.Location = new System.Drawing.Point(21, 11);
            this.lbllinename.Name = "lbllinename";
            this.lbllinename.Size = new System.Drawing.Size(202, 21);
            this.lbllinename.TabIndex = 14;
            this.lbllinename.Text = "线路名称：0207[201-129] ";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 212);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(491, 486);
            this.panel3.TabIndex = 10;
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.list_date);
            this.gbInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbInfo.Location = new System.Drawing.Point(1060, 0);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(132, 88);
            this.gbInfo.TabIndex = 84;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "任务信息";
            // 
            // list_date
            // 
            this.list_date.BackColor = System.Drawing.SystemColors.Control;
            this.list_date.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_date.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.list_date.FormattingEnabled = true;
            this.list_date.ItemHeight = 17;
            this.list_date.Items.AddRange(new object[] {
            "数据库连接成功。。。"});
            this.list_date.Location = new System.Drawing.Point(3, 19);
            this.list_date.Name = "list_date";
            this.list_date.Size = new System.Drawing.Size(126, 66);
            this.list_date.TabIndex = 0;
            this.list_date.Click += new System.EventHandler(this.list_date_Click);
            // 
            // cce1
            // 
            this.cce1.BackColor = System.Drawing.Color.White;
            this.cce1.Location = new System.Drawing.Point(11, 48);
            this.cce1.Name = "cce1";
            this.cce1.Size = new System.Drawing.Size(137, 526);
            this.cce1.TabIndex = 6;
            // 
            // cs
            // 
            this.cs.BackColor = System.Drawing.Color.White;
            this.cs.H = 489;
            this.cs.Location = new System.Drawing.Point(500, 248);
            this.cs.Margin = new System.Windows.Forms.Padding(4);
            this.cs.Name = "cs";
            this.cs.Size = new System.Drawing.Size(511, 437);
            this.cs.TabIndex = 3;
            this.cs.W = 540;
            // 
            // FmInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1194, 698);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.cs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FmInfo";
            this.Text = "下一个";
            this.Load += new System.EventHandler(this.FmInfo_Load);
            this.SizeChanged += new System.EventHandler(this.FmInfo_SizeChanged);
            this.Resize += new System.EventHandler(this.FmInfo_Resize);
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnnext;
        private CigrShow cs;

        private System.Windows.Forms.Panel panelInfo;
        private CigrCache cce1;
        private System.Windows.Forms.Label lblCache;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblcutcount;
        private System.Windows.Forms.Label lblcutname;
        private System.Windows.Forms.Label lblcutcode;
        private System.Windows.Forms.Label lblallcount;
        private System.Windows.Forms.Label lblorderdate;
        private System.Windows.Forms.Label lbllinename;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.ListBox list_date;
    }
    
}