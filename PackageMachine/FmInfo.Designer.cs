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
            this.btnJump = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtInTask = new System.Windows.Forms.TextBox();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnnext = new System.Windows.Forms.Button();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblcutcount = new System.Windows.Forms.Label();
            this.btnRemake = new System.Windows.Forms.Button();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.list_date = new System.Windows.Forms.ListBox();
            this.lblcutname = new System.Windows.Forms.Label();
            this.lblallcount = new System.Windows.Forms.Label();
            this.lblcuscode = new System.Windows.Forms.Label();
            this.lblcutcode = new System.Windows.Forms.Label();
            this.lbllinename = new System.Windows.Forms.Label();
            this.btnAuto = new System.Windows.Forms.Button();
            this.lblCache = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.plcrtl = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblNotFish = new System.Windows.Forms.Label();
            this.panelLb = new System.Windows.Forms.Panel();
            this.btngw8 = new System.Windows.Forms.Button();
            this.btngw9 = new System.Windows.Forms.Button();
            this.panelUN = new System.Windows.Forms.Panel();
            this.btngw7 = new System.Windows.Forms.Button();
            this.btngw6 = new System.Windows.Forms.Button();
            this.btngw5 = new System.Windows.Forms.Button();
            this.btngw2 = new System.Windows.Forms.Button();
            this.btngw4 = new System.Windows.Forms.Button();
            this.btngw1 = new System.Windows.Forms.Button();
            this.btngw3 = new System.Windows.Forms.Button();
            this.lblCigCount = new System.Windows.Forms.Label();
            this.lblUnNormal = new System.Windows.Forms.Label();
            this.lblNormalcOUNT = new System.Windows.Forms.Label();
            this.lbFinsh = new System.Windows.Forms.Label();
            this.lblDxdetail = new System.Windows.Forms.Label();
            this.lblGwcx = new System.Windows.Forms.Label();
            this.cce1 = new PackageMachine.CigrCache();
            this.cs2 = new PackageMachine.CigrShow();
            this.cs = new PackageMachine.CigrShow();
            this.button1 = new System.Windows.Forms.Button();
            this.panelInfo.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.plcrtl.SuspendLayout();
            this.panelLb.SuspendLayout();
            this.panelUN.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnJump
            // 
            this.btnJump.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnJump.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJump.Location = new System.Drawing.Point(432, 50);
            this.btnJump.Name = "btnJump";
            this.btnJump.Size = new System.Drawing.Size(75, 23);
            this.btnJump.TabIndex = 0;
            this.btnJump.Text = "查询";
            this.btnJump.UseVisualStyleBackColor = true;
            this.btnJump.Click += new System.EventHandler(this.btnJump_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(326, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 1;
            // 
            // txtInTask
            // 
            this.txtInTask.Location = new System.Drawing.Point(346, 3);
            this.txtInTask.Name = "txtInTask";
            this.txtInTask.Size = new System.Drawing.Size(100, 23);
            this.txtInTask.TabIndex = 1;
            this.txtInTask.Visible = false;
            // 
            // btnLast
            // 
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLast.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLast.Location = new System.Drawing.Point(95, 50);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(75, 23);
            this.btnLast.TabIndex = 2;
            this.btnLast.Text = "上一包";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnnext
            // 
            this.btnnext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnnext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnnext.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnnext.Location = new System.Drawing.Point(184, 50);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(75, 23);
            this.btnnext.TabIndex = 2;
            this.btnnext.Text = "下一包";
            this.btnnext.UseVisualStyleBackColor = true;
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            // 
            // panelInfo
            // 
            this.panelInfo.Controls.Add(this.label2);
            this.panelInfo.Controls.Add(this.label1);
            this.panelInfo.Controls.Add(this.lblcutcount);
            this.panelInfo.Controls.Add(this.btnRemake);
            this.panelInfo.Controls.Add(this.gbInfo);
            this.panelInfo.Controls.Add(this.lblcutname);
            this.panelInfo.Controls.Add(this.lblallcount);
            this.panelInfo.Controls.Add(this.btnnext);
            this.panelInfo.Controls.Add(this.lblcuscode);
            this.panelInfo.Controls.Add(this.lblcutcode);
            this.panelInfo.Controls.Add(this.btnLast);
            this.panelInfo.Controls.Add(this.btnJump);
            this.panelInfo.Controls.Add(this.textBox1);
            this.panelInfo.Controls.Add(this.lbllinename);
            this.panelInfo.Controls.Add(this.txtInTask);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelInfo.Location = new System.Drawing.Point(0, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(1194, 90);
            this.panelInfo.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(264, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 89;
            this.label2.Text = "任务号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 16.25F);
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 30);
            this.label1.TabIndex = 88;
            this.label1.Text = "任务操作：";
            // 
            // lblcutcount
            // 
            this.lblcutcount.AutoSize = true;
            this.lblcutcount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcutcount.ForeColor = System.Drawing.Color.Indigo;
            this.lblcutcount.Location = new System.Drawing.Point(765, 32);
            this.lblcutcount.Name = "lblcutcount";
            this.lblcutcount.Size = new System.Drawing.Size(115, 21);
            this.lblcutcount.TabIndex = 19;
            this.lblcutcount.Text = "客户包数：0-0";
            // 
            // btnRemake
            // 
            this.btnRemake.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemake.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRemake.Location = new System.Drawing.Point(8, 50);
            this.btnRemake.Name = "btnRemake";
            this.btnRemake.Size = new System.Drawing.Size(75, 23);
            this.btnRemake.TabIndex = 86;
            this.btnRemake.Text = "任务定位";
            this.btnRemake.UseVisualStyleBackColor = true;
            this.btnRemake.Click += new System.EventHandler(this.btnRemake_Click);
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.list_date);
            this.gbInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbInfo.Location = new System.Drawing.Point(1019, 0);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(175, 90);
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
            this.list_date.Location = new System.Drawing.Point(3, 19);
            this.list_date.Name = "list_date";
            this.list_date.Size = new System.Drawing.Size(169, 68);
            this.list_date.TabIndex = 0;
            this.list_date.Click += new System.EventHandler(this.list_date_Click);
            // 
            // lblcutname
            // 
            this.lblcutname.AutoSize = true;
            this.lblcutname.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcutname.ForeColor = System.Drawing.Color.Indigo;
            this.lblcutname.Location = new System.Drawing.Point(549, 32);
            this.lblcutname.Name = "lblcutname";
            this.lblcutname.Size = new System.Drawing.Size(130, 21);
            this.lblcutname.TabIndex = 18;
            this.lblcutname.Text = "客户名称：XXXX";
            // 
            // lblallcount
            // 
            this.lblallcount.AutoSize = true;
            this.lblallcount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblallcount.ForeColor = System.Drawing.Color.Black;
            this.lblallcount.Location = new System.Drawing.Point(765, 3);
            this.lblallcount.Name = "lblallcount";
            this.lblallcount.Size = new System.Drawing.Size(154, 21);
            this.lblallcount.TabIndex = 16;
            this.lblallcount.Text = "总 包 号：0000-000";
            // 
            // lblcuscode
            // 
            this.lblcuscode.AutoSize = true;
            this.lblcuscode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcuscode.ForeColor = System.Drawing.Color.Indigo;
            this.lblcuscode.Location = new System.Drawing.Point(549, 61);
            this.lblcuscode.Name = "lblcuscode";
            this.lblcuscode.Size = new System.Drawing.Size(171, 21);
            this.lblcuscode.TabIndex = 15;
            this.lblcuscode.Text = "客户编码：000000000";
            // 
            // lblcutcode
            // 
            this.lblcutcode.AutoSize = true;
            this.lblcutcode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcutcode.ForeColor = System.Drawing.Color.Indigo;
            this.lblcutcode.Location = new System.Drawing.Point(765, 59);
            this.lblcutcode.Name = "lblcutcode";
            this.lblcutcode.Size = new System.Drawing.Size(137, 21);
            this.lblcutcode.TabIndex = 17;
            this.lblcutcode.Text = "任务号：0000000";
            // 
            // lbllinename
            // 
            this.lbllinename.AutoSize = true;
            this.lbllinename.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbllinename.ForeColor = System.Drawing.Color.Black;
            this.lbllinename.Location = new System.Drawing.Point(549, 4);
            this.lbllinename.Name = "lbllinename";
            this.lbllinename.Size = new System.Drawing.Size(117, 21);
            this.lbllinename.TabIndex = 14;
            this.lbllinename.Text = "线路名称：000";
            // 
            // btnAuto
            // 
            this.btnAuto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAuto.Location = new System.Drawing.Point(133, 5);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(75, 23);
            this.btnAuto.TabIndex = 87;
            this.btnAuto.Text = "自动获取";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Visible = false;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
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
            // plcrtl
            // 
            this.plcrtl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plcrtl.Controls.Add(this.lblInfo);
            this.plcrtl.Controls.Add(this.btnAuto);
            this.plcrtl.Controls.Add(this.lblNotFish);
            this.plcrtl.Controls.Add(this.panelLb);
            this.plcrtl.Controls.Add(this.panelUN);
            this.plcrtl.Controls.Add(this.lblCigCount);
            this.plcrtl.Controls.Add(this.lblUnNormal);
            this.plcrtl.Controls.Add(this.lblNormalcOUNT);
            this.plcrtl.Controls.Add(this.lbFinsh);
            this.plcrtl.Dock = System.Windows.Forms.DockStyle.Top;
            this.plcrtl.Location = new System.Drawing.Point(0, 90);
            this.plcrtl.Name = "plcrtl";
            this.plcrtl.Size = new System.Drawing.Size(1018, 181);
            this.plcrtl.TabIndex = 9;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblInfo.Font = new System.Drawing.Font("微软雅黑", 16.25F);
            this.lblInfo.Location = new System.Drawing.Point(3, 2);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(123, 30);
            this.lblInfo.TabIndex = 87;
            this.lblInfo.Text = "工位信息：";
            // 
            // lblNotFish
            // 
            this.lblNotFish.AutoSize = true;
            this.lblNotFish.BackColor = System.Drawing.Color.LightBlue;
            this.lblNotFish.Font = new System.Drawing.Font("微软雅黑", 16.25F);
            this.lblNotFish.Location = new System.Drawing.Point(761, 125);
            this.lblNotFish.Name = "lblNotFish";
            this.lblNotFish.Size = new System.Drawing.Size(187, 30);
            this.lblNotFish.TabIndex = 0;
            this.lblNotFish.Text = "未包装数量：      ";
            // 
            // panelLb
            // 
            this.panelLb.BackColor = System.Drawing.Color.LightBlue;
            this.panelLb.Controls.Add(this.btngw8);
            this.panelLb.Controls.Add(this.btngw9);
            this.panelLb.Location = new System.Drawing.Point(455, 25);
            this.panelLb.Name = "panelLb";
            this.panelLb.Size = new System.Drawing.Size(269, 63);
            this.panelLb.TabIndex = 86;
            // 
            // btngw8
            // 
            this.btngw8.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btngw8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btngw8.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btngw8.Location = new System.Drawing.Point(160, 9);
            this.btngw8.Name = "btngw8";
            this.btngw8.Size = new System.Drawing.Size(93, 47);
            this.btngw8.TabIndex = 0;
            this.btngw8.Text = "合包";
            this.btngw8.UseVisualStyleBackColor = false;
            this.btngw8.Click += new System.EventHandler(this.gbtnw1_Click);
            // 
            // btngw9
            // 
            this.btngw9.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btngw9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btngw9.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btngw9.Location = new System.Drawing.Point(54, 9);
            this.btngw9.Name = "btngw9";
            this.btngw9.Size = new System.Drawing.Size(93, 47);
            this.btngw9.TabIndex = 0;
            this.btngw9.Text = "翻版";
            this.btngw9.UseVisualStyleBackColor = false;
            this.btngw9.Click += new System.EventHandler(this.gbtnw1_Click);
            // 
            // panelUN
            // 
            this.panelUN.BackColor = System.Drawing.Color.LightBlue;
            this.panelUN.Controls.Add(this.btngw7);
            this.panelUN.Controls.Add(this.btngw6);
            this.panelUN.Controls.Add(this.btngw5);
            this.panelUN.Controls.Add(this.btngw2);
            this.panelUN.Controls.Add(this.btngw4);
            this.panelUN.Controls.Add(this.btngw1);
            this.panelUN.Controls.Add(this.btngw3);
            this.panelUN.Location = new System.Drawing.Point(7, 87);
            this.panelUN.Name = "panelUN";
            this.panelUN.Size = new System.Drawing.Size(717, 71);
            this.panelUN.TabIndex = 86;
            // 
            // btngw7
            // 
            this.btngw7.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btngw7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btngw7.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btngw7.Location = new System.Drawing.Point(608, 11);
            this.btngw7.Name = "btngw7";
            this.btngw7.Size = new System.Drawing.Size(93, 47);
            this.btngw7.TabIndex = 0;
            this.btngw7.Text = "工位7";
            this.btngw7.UseVisualStyleBackColor = false;
            this.btngw7.Click += new System.EventHandler(this.gbtnw1_Click);
            this.btngw7.MouseEnter += new System.EventHandler(this.btngw1_MouseEnter);
            // 
            // btngw6
            // 
            this.btngw6.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btngw6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btngw6.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btngw6.Location = new System.Drawing.Point(502, 11);
            this.btngw6.Name = "btngw6";
            this.btngw6.Size = new System.Drawing.Size(93, 47);
            this.btngw6.TabIndex = 0;
            this.btngw6.Text = "工位6";
            this.btngw6.UseVisualStyleBackColor = false;
            this.btngw6.Click += new System.EventHandler(this.gbtnw1_Click);
            this.btngw6.MouseEnter += new System.EventHandler(this.btngw1_MouseEnter);
            // 
            // btngw5
            // 
            this.btngw5.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btngw5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btngw5.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btngw5.Location = new System.Drawing.Point(403, 11);
            this.btngw5.Name = "btngw5";
            this.btngw5.Size = new System.Drawing.Size(93, 47);
            this.btngw5.TabIndex = 0;
            this.btngw5.Text = "工位5";
            this.btngw5.UseVisualStyleBackColor = false;
            this.btngw5.Click += new System.EventHandler(this.gbtnw1_Click);
            this.btngw5.MouseEnter += new System.EventHandler(this.btngw1_MouseEnter);
            // 
            // btngw2
            // 
            this.btngw2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btngw2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btngw2.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btngw2.Location = new System.Drawing.Point(106, 11);
            this.btngw2.Name = "btngw2";
            this.btngw2.Size = new System.Drawing.Size(93, 47);
            this.btngw2.TabIndex = 0;
            this.btngw2.Text = "工位2";
            this.btngw2.UseVisualStyleBackColor = false;
            this.btngw2.Click += new System.EventHandler(this.gbtnw1_Click);
            this.btngw2.MouseEnter += new System.EventHandler(this.btngw1_MouseEnter);
            // 
            // btngw4
            // 
            this.btngw4.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btngw4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btngw4.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btngw4.Location = new System.Drawing.Point(304, 11);
            this.btngw4.Name = "btngw4";
            this.btngw4.Size = new System.Drawing.Size(93, 47);
            this.btngw4.TabIndex = 0;
            this.btngw4.Text = "工位4";
            this.btngw4.UseVisualStyleBackColor = false;
            this.btngw4.Click += new System.EventHandler(this.gbtnw1_Click);
            this.btngw4.MouseEnter += new System.EventHandler(this.btngw1_MouseEnter);
            // 
            // btngw1
            // 
            this.btngw1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btngw1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btngw1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btngw1.Location = new System.Drawing.Point(7, 11);
            this.btngw1.Name = "btngw1";
            this.btngw1.Size = new System.Drawing.Size(93, 47);
            this.btngw1.TabIndex = 0;
            this.btngw1.Text = "工位1";
            this.btngw1.UseVisualStyleBackColor = false;
            this.btngw1.Click += new System.EventHandler(this.gbtnw1_Click);
            this.btngw1.MouseEnter += new System.EventHandler(this.btngw1_MouseEnter);
            // 
            // btngw3
            // 
            this.btngw3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btngw3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btngw3.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btngw3.Location = new System.Drawing.Point(205, 11);
            this.btngw3.Name = "btngw3";
            this.btngw3.Size = new System.Drawing.Size(93, 47);
            this.btngw3.TabIndex = 0;
            this.btngw3.Text = "工位3";
            this.btngw3.UseVisualStyleBackColor = false;
            this.btngw3.Click += new System.EventHandler(this.gbtnw1_Click);
            this.btngw3.MouseEnter += new System.EventHandler(this.btngw1_MouseEnter);
            // 
            // lblCigCount
            // 
            this.lblCigCount.AutoSize = true;
            this.lblCigCount.BackColor = System.Drawing.Color.LightBlue;
            this.lblCigCount.Font = new System.Drawing.Font("微软雅黑", 16.25F);
            this.lblCigCount.Location = new System.Drawing.Point(763, 5);
            this.lblCigCount.Name = "lblCigCount";
            this.lblCigCount.Size = new System.Drawing.Size(186, 30);
            this.lblCigCount.TabIndex = 0;
            this.lblCigCount.Text = "卷烟总量：         ";
            // 
            // lblUnNormal
            // 
            this.lblUnNormal.AutoSize = true;
            this.lblUnNormal.BackColor = System.Drawing.Color.LightBlue;
            this.lblUnNormal.Font = new System.Drawing.Font("微软雅黑", 16.25F);
            this.lblUnNormal.Location = new System.Drawing.Point(761, 65);
            this.lblUnNormal.Name = "lblUnNormal";
            this.lblUnNormal.Size = new System.Drawing.Size(187, 30);
            this.lblUnNormal.TabIndex = 0;
            this.lblUnNormal.Text = "异型烟总量：      ";
            // 
            // lblNormalcOUNT
            // 
            this.lblNormalcOUNT.AutoSize = true;
            this.lblNormalcOUNT.BackColor = System.Drawing.Color.LightBlue;
            this.lblNormalcOUNT.Font = new System.Drawing.Font("微软雅黑", 16.25F);
            this.lblNormalcOUNT.Location = new System.Drawing.Point(763, 35);
            this.lblNormalcOUNT.Name = "lblNormalcOUNT";
            this.lblNormalcOUNT.Size = new System.Drawing.Size(187, 30);
            this.lblNormalcOUNT.TabIndex = 0;
            this.lblNormalcOUNT.Text = "常规烟总量：      ";
            // 
            // lbFinsh
            // 
            this.lbFinsh.AutoSize = true;
            this.lbFinsh.BackColor = System.Drawing.Color.LightBlue;
            this.lbFinsh.Font = new System.Drawing.Font("微软雅黑", 16.25F);
            this.lbFinsh.Location = new System.Drawing.Point(761, 95);
            this.lbFinsh.Name = "lbFinsh";
            this.lbFinsh.Size = new System.Drawing.Size(187, 30);
            this.lbFinsh.TabIndex = 0;
            this.lbFinsh.Text = "已包装数量：      ";
            // 
            // lblDxdetail
            // 
            this.lblDxdetail.AutoSize = true;
            this.lblDxdetail.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblDxdetail.Font = new System.Drawing.Font("微软雅黑", 16.25F);
            this.lblDxdetail.Location = new System.Drawing.Point(10, 310);
            this.lblDxdetail.Name = "lblDxdetail";
            this.lblDxdetail.Size = new System.Drawing.Size(167, 30);
            this.lblDxdetail.TabIndex = 88;
            this.lblDxdetail.Text = "合包垛型明细：";
            // 
            // lblGwcx
            // 
            this.lblGwcx.AutoSize = true;
            this.lblGwcx.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblGwcx.Font = new System.Drawing.Font("微软雅黑", 16.25F);
            this.lblGwcx.Location = new System.Drawing.Point(533, 310);
            this.lblGwcx.Name = "lblGwcx";
            this.lblGwcx.Size = new System.Drawing.Size(167, 30);
            this.lblGwcx.TabIndex = 88;
            this.lblGwcx.Text = "缓存工位明细：";
            // 
            // cce1
            // 
            this.cce1.BackColor = System.Drawing.Color.White;
            this.cce1.Location = new System.Drawing.Point(11, 48);
            this.cce1.Name = "cce1";
            this.cce1.Size = new System.Drawing.Size(137, 526);
            this.cce1.TabIndex = 6;
            // 
            // cs2
            // 
            this.cs2.BackColor = System.Drawing.Color.White;
            this.cs2.H = 489;
            this.cs2.Location = new System.Drawing.Point(538, 357);
            this.cs2.Margin = new System.Windows.Forms.Padding(4);
            this.cs2.Name = "cs2";
            this.cs2.Size = new System.Drawing.Size(473, 328);
            this.cs2.TabIndex = 3;
            this.cs2.W = 540;
            // 
            // cs
            // 
            this.cs.BackColor = System.Drawing.Color.White;
            this.cs.H = 489;
            this.cs.Location = new System.Drawing.Point(13, 357);
            this.cs.Margin = new System.Windows.Forms.Padding(4);
            this.cs.Name = "cs";
            this.cs.Size = new System.Drawing.Size(473, 328);
            this.cs.TabIndex = 3;
            this.cs.W = 540;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(400, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 89;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FmInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1194, 698);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblGwcx);
            this.Controls.Add(this.lblDxdetail);
            this.Controls.Add(this.plcrtl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.cs2);
            this.Controls.Add(this.cs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FmInfo";
            this.Text = "下一个";
            this.Load += new System.EventHandler(this.FmInfo_Load);
            this.SizeChanged += new System.EventHandler(this.FmInfo_SizeChanged);
            this.Resize += new System.EventHandler(this.FmInfo_Resize);
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.gbInfo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.plcrtl.ResumeLayout(false);
            this.plcrtl.PerformLayout();
            this.panelLb.ResumeLayout(false);
            this.panelUN.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnJump;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtInTask;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnnext;
        private CigrShow cs;

        private System.Windows.Forms.Panel panelInfo;
        private CigrCache cce1;
        private System.Windows.Forms.Label lblCache;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel plcrtl;
        private System.Windows.Forms.Label lblcutcount;
        private System.Windows.Forms.Label lblcutname;
        private System.Windows.Forms.Label lblcutcode;
        private System.Windows.Forms.Label lblallcount;
        private System.Windows.Forms.Label lblcuscode;
        private System.Windows.Forms.Label lbllinename;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.ListBox list_date;
        private System.Windows.Forms.Label lblNotFish;
        private System.Windows.Forms.Label lbFinsh;
        private System.Windows.Forms.Label lblUnNormal;
        private System.Windows.Forms.Label lblNormalcOUNT;
        private System.Windows.Forms.Label lblCigCount;
        private System.Windows.Forms.Button btnRemake;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Button btngw5;
        private System.Windows.Forms.Button btngw4;
        private System.Windows.Forms.Button btngw3;
        private System.Windows.Forms.Button btngw2;
        private System.Windows.Forms.Button btngw6;
        private System.Windows.Forms.Button btngw9;
        private System.Windows.Forms.Button btngw8;
        private System.Windows.Forms.Button btngw7;
        private System.Windows.Forms.Button btngw1;
        private System.Windows.Forms.Panel panelLb;
        private System.Windows.Forms.Panel panelUN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblDxdetail;
        private System.Windows.Forms.Label label2;
        private CigrShow cs2;
        private System.Windows.Forms.Label lblGwcx;
        private System.Windows.Forms.Button button1;
    }
    
}