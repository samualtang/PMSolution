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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmInfo));
            this.btnJump = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtInTask = new System.Windows.Forms.TextBox();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnnext = new System.Windows.Forms.Button();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.btnAuto = new System.Windows.Forms.Button();
            this.lblcutcount = new System.Windows.Forms.Label();
            this.btnRemake = new System.Windows.Forms.Button();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.list_date = new System.Windows.Forms.ListBox();
            this.lblcutname = new System.Windows.Forms.Label();
            this.lblcutcode = new System.Windows.Forms.Label();
            this.lblallcount = new System.Windows.Forms.Label();
            this.lblorderdate = new System.Windows.Forms.Label();
            this.lbllinename = new System.Windows.Forms.Label();
            this.lblCache = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.plcrtl = new System.Windows.Forms.Panel();
            this.gbtnw6 = new System.Windows.Forms.Button();
            this.gbtnw5 = new System.Windows.Forms.Button();
            this.gbtnw9 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbtnw8 = new System.Windows.Forms.Button();
            this.gbtnw7 = new System.Windows.Forms.Button();
            this.gbtnw4 = new System.Windows.Forms.Button();
            this.gbtnw3 = new System.Windows.Forms.Button();
            this.gbtnw2 = new System.Windows.Forms.Button();
            this.lblNotFish = new System.Windows.Forms.Label();
            this.lbFinsh = new System.Windows.Forms.Label();
            this.lblUnNormal = new System.Windows.Forms.Label();
            this.lblNormalcOUNT = new System.Windows.Forms.Label();
            this.lblCigCount = new System.Windows.Forms.Label();
            this.gbtnw1 = new System.Windows.Forms.Button();
            this.panelUN = new System.Windows.Forms.Panel();
            this.panelLb = new System.Windows.Forms.Panel();
            this.cce1 = new PackageMachine.CigrCache();
            this.cs = new PackageMachine.CigrShow();
            this.panelInfo.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.plcrtl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnJump
            // 
            this.btnJump.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnJump.Location = new System.Drawing.Point(363, 36);
            this.btnJump.Name = "btnJump";
            this.btnJump.Size = new System.Drawing.Size(75, 23);
            this.btnJump.TabIndex = 0;
            this.btnJump.Text = "跳转";
            this.btnJump.UseVisualStyleBackColor = true;
            this.btnJump.Click += new System.EventHandler(this.btnJump_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(257, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 1;
            // 
            // txtInTask
            // 
            this.txtInTask.Location = new System.Drawing.Point(536, 39);
            this.txtInTask.Name = "txtInTask";
            this.txtInTask.Size = new System.Drawing.Size(100, 21);
            this.txtInTask.TabIndex = 1;
            this.txtInTask.Visible = false;
            // 
            // btnLast
            // 
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLast.Location = new System.Drawing.Point(87, 36);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(75, 23);
            this.btnLast.TabIndex = 2;
            this.btnLast.Text = "上一个";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnnext
            // 
            this.btnnext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnnext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnnext.Location = new System.Drawing.Point(176, 36);
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
            this.panelInfo.Controls.Add(this.btnAuto);
            this.panelInfo.Controls.Add(this.lblcutcount);
            this.panelInfo.Controls.Add(this.btnRemake);
            this.panelInfo.Controls.Add(this.gbInfo);
            this.panelInfo.Controls.Add(this.lblcutname);
            this.panelInfo.Controls.Add(this.btnnext);
            this.panelInfo.Controls.Add(this.lblcutcode);
            this.panelInfo.Controls.Add(this.btnLast);
            this.panelInfo.Controls.Add(this.lblallcount);
            this.panelInfo.Controls.Add(this.btnJump);
            this.panelInfo.Controls.Add(this.lblorderdate);
            this.panelInfo.Controls.Add(this.textBox1);
            this.panelInfo.Controls.Add(this.lbllinename);
            this.panelInfo.Controls.Add(this.txtInTask);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(1194, 90);
            this.panelInfo.TabIndex = 5;
            // 
            // btnAuto
            // 
            this.btnAuto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAuto.Location = new System.Drawing.Point(6, 60);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(75, 23);
            this.btnAuto.TabIndex = 87;
            this.btnAuto.Text = "自动获取";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Visible = false;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // lblcutcount
            // 
            this.lblcutcount.AutoSize = true;
            this.lblcutcount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcutcount.ForeColor = System.Drawing.Color.Red;
            this.lblcutcount.Location = new System.Drawing.Point(824, 59);
            this.lblcutcount.Name = "lblcutcount";
            this.lblcutcount.Size = new System.Drawing.Size(115, 21);
            this.lblcutcount.TabIndex = 19;
            this.lblcutcount.Text = "客户包数：0-0";
            // 
            // btnRemake
            // 
            this.btnRemake.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemake.Location = new System.Drawing.Point(6, 36);
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
            this.gbInfo.Location = new System.Drawing.Point(1017, 0);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(175, 88);
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
            this.list_date.Size = new System.Drawing.Size(169, 66);
            this.list_date.TabIndex = 0;
            this.list_date.Click += new System.EventHandler(this.list_date_Click);
            // 
            // lblcutname
            // 
            this.lblcutname.AutoSize = true;
            this.lblcutname.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcutname.ForeColor = System.Drawing.Color.Red;
            this.lblcutname.Location = new System.Drawing.Point(642, 59);
            this.lblcutname.Name = "lblcutname";
            this.lblcutname.Size = new System.Drawing.Size(130, 21);
            this.lblcutname.TabIndex = 18;
            this.lblcutname.Text = "客户名称：XXXX";
            // 
            // lblcutcode
            // 
            this.lblcutcode.AutoSize = true;
            this.lblcutcode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcutcode.ForeColor = System.Drawing.Color.Red;
            this.lblcutcode.Location = new System.Drawing.Point(642, 35);
            this.lblcutcode.Name = "lblcutcode";
            this.lblcutcode.Size = new System.Drawing.Size(169, 21);
            this.lblcutcode.TabIndex = 17;
            this.lblcutcode.Text = "任务流水号：0000000";
            // 
            // lblallcount
            // 
            this.lblallcount.AutoSize = true;
            this.lblallcount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblallcount.ForeColor = System.Drawing.Color.Red;
            this.lblallcount.Location = new System.Drawing.Point(824, 35);
            this.lblallcount.Name = "lblallcount";
            this.lblallcount.Size = new System.Drawing.Size(154, 21);
            this.lblallcount.TabIndex = 16;
            this.lblallcount.Text = "总 包 号：0000-000";
            // 
            // lblorderdate
            // 
            this.lblorderdate.AutoSize = true;
            this.lblorderdate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblorderdate.ForeColor = System.Drawing.Color.Black;
            this.lblorderdate.Location = new System.Drawing.Point(824, 11);
            this.lblorderdate.Name = "lblorderdate";
            this.lblorderdate.Size = new System.Drawing.Size(191, 21);
            this.lblorderdate.TabIndex = 15;
            this.lblorderdate.Text = "订单日期：yyyy/mm/dd ";
            // 
            // lbllinename
            // 
            this.lbllinename.AutoSize = true;
            this.lbllinename.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbllinename.ForeColor = System.Drawing.Color.Black;
            this.lbllinename.Location = new System.Drawing.Point(642, 14);
            this.lbllinename.Name = "lbllinename";
            this.lbllinename.Size = new System.Drawing.Size(117, 21);
            this.lbllinename.TabIndex = 14;
            this.lbllinename.Text = "线路名称：000";
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
            this.plcrtl.Controls.Add(this.gbtnw6);
            this.plcrtl.Controls.Add(this.gbtnw5);
            this.plcrtl.Controls.Add(this.gbtnw9);
            this.plcrtl.Controls.Add(this.pictureBox1);
            this.plcrtl.Controls.Add(this.gbtnw8);
            this.plcrtl.Controls.Add(this.gbtnw7);
            this.plcrtl.Controls.Add(this.gbtnw4);
            this.plcrtl.Controls.Add(this.gbtnw3);
            this.plcrtl.Controls.Add(this.gbtnw1);
            this.plcrtl.Controls.Add(this.gbtnw2);
            this.plcrtl.Controls.Add(this.panelLb);
            this.plcrtl.Controls.Add(this.panelUN);
            this.plcrtl.Dock = System.Windows.Forms.DockStyle.Top;
            this.plcrtl.Location = new System.Drawing.Point(0, 90);
            this.plcrtl.Name = "plcrtl";
            this.plcrtl.Size = new System.Drawing.Size(1018, 172);
            this.plcrtl.TabIndex = 9;
            // 
            // gbtnw6
            // 
            this.gbtnw6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gbtnw6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbtnw6.Location = new System.Drawing.Point(509, 88);
            this.gbtnw6.Name = "gbtnw6";
            this.gbtnw6.Size = new System.Drawing.Size(83, 47);
            this.gbtnw6.TabIndex = 0;
            this.gbtnw6.Text = "工位6";
            this.gbtnw6.UseVisualStyleBackColor = false;
            this.gbtnw6.Click += new System.EventHandler(this.gbtnw1_Click);
            // 
            // gbtnw5
            // 
            this.gbtnw5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gbtnw5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbtnw5.Location = new System.Drawing.Point(420, 88);
            this.gbtnw5.Name = "gbtnw5";
            this.gbtnw5.Size = new System.Drawing.Size(83, 47);
            this.gbtnw5.TabIndex = 0;
            this.gbtnw5.Text = "工位5";
            this.gbtnw5.UseVisualStyleBackColor = false;
            this.gbtnw5.Click += new System.EventHandler(this.gbtnw1_Click);
            // 
            // gbtnw9
            // 
            this.gbtnw9.BackColor = System.Drawing.Color.Gray;
            this.gbtnw9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbtnw9.Location = new System.Drawing.Point(509, 24);
            this.gbtnw9.Name = "gbtnw9";
            this.gbtnw9.Size = new System.Drawing.Size(83, 47);
            this.gbtnw9.TabIndex = 0;
            this.gbtnw9.Text = "常规烟";
            this.gbtnw9.UseVisualStyleBackColor = false;
            this.gbtnw9.Click += new System.EventHandler(this.gbtnw1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(738, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 50);
            this.pictureBox1.TabIndex = 85;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // gbtnw8
            // 
            this.gbtnw8.BackColor = System.Drawing.Color.Gray;
            this.gbtnw8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbtnw8.Location = new System.Drawing.Point(607, 24);
            this.gbtnw8.Name = "gbtnw8";
            this.gbtnw8.Size = new System.Drawing.Size(83, 47);
            this.gbtnw8.TabIndex = 0;
            this.gbtnw8.Text = "合包";
            this.gbtnw8.UseVisualStyleBackColor = false;
            this.gbtnw8.Click += new System.EventHandler(this.gbtnw1_Click);
            // 
            // gbtnw7
            // 
            this.gbtnw7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gbtnw7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbtnw7.Location = new System.Drawing.Point(607, 88);
            this.gbtnw7.Name = "gbtnw7";
            this.gbtnw7.Size = new System.Drawing.Size(83, 47);
            this.gbtnw7.TabIndex = 0;
            this.gbtnw7.Text = "工位7";
            this.gbtnw7.UseVisualStyleBackColor = false;
            this.gbtnw7.Click += new System.EventHandler(this.gbtnw1_Click);
            // 
            // gbtnw4
            // 
            this.gbtnw4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gbtnw4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbtnw4.Location = new System.Drawing.Point(331, 88);
            this.gbtnw4.Name = "gbtnw4";
            this.gbtnw4.Size = new System.Drawing.Size(83, 47);
            this.gbtnw4.TabIndex = 0;
            this.gbtnw4.Text = "工位4";
            this.gbtnw4.UseVisualStyleBackColor = false;
            this.gbtnw4.Click += new System.EventHandler(this.gbtnw1_Click);
            // 
            // gbtnw3
            // 
            this.gbtnw3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gbtnw3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbtnw3.Location = new System.Drawing.Point(242, 88);
            this.gbtnw3.Name = "gbtnw3";
            this.gbtnw3.Size = new System.Drawing.Size(83, 47);
            this.gbtnw3.TabIndex = 0;
            this.gbtnw3.Text = "工位3";
            this.gbtnw3.UseVisualStyleBackColor = false;
            this.gbtnw3.Click += new System.EventHandler(this.gbtnw1_Click);
            // 
            // gbtnw2
            // 
            this.gbtnw2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gbtnw2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbtnw2.Location = new System.Drawing.Point(153, 88);
            this.gbtnw2.Name = "gbtnw2";
            this.gbtnw2.Size = new System.Drawing.Size(83, 47);
            this.gbtnw2.TabIndex = 0;
            this.gbtnw2.Text = "工位2";
            this.gbtnw2.UseVisualStyleBackColor = false;
            this.gbtnw2.Click += new System.EventHandler(this.gbtnw1_Click);
            // 
            // lblNotFish
            // 
            this.lblNotFish.AutoSize = true;
            this.lblNotFish.BackColor = System.Drawing.Color.LightGreen;
            this.lblNotFish.Font = new System.Drawing.Font("微软雅黑", 16.25F);
            this.lblNotFish.Location = new System.Drawing.Point(25, 385);
            this.lblNotFish.Name = "lblNotFish";
            this.lblNotFish.Size = new System.Drawing.Size(187, 30);
            this.lblNotFish.TabIndex = 0;
            this.lblNotFish.Text = "未包装数量：      ";
            // 
            // lbFinsh
            // 
            this.lbFinsh.AutoSize = true;
            this.lbFinsh.BackColor = System.Drawing.Color.LightGreen;
            this.lbFinsh.Font = new System.Drawing.Font("微软雅黑", 16.25F);
            this.lbFinsh.Location = new System.Drawing.Point(25, 355);
            this.lbFinsh.Name = "lbFinsh";
            this.lbFinsh.Size = new System.Drawing.Size(187, 30);
            this.lbFinsh.TabIndex = 0;
            this.lbFinsh.Text = "已包装数量：      ";
            // 
            // lblUnNormal
            // 
            this.lblUnNormal.AutoSize = true;
            this.lblUnNormal.BackColor = System.Drawing.Color.LightGreen;
            this.lblUnNormal.Font = new System.Drawing.Font("微软雅黑", 16.25F);
            this.lblUnNormal.Location = new System.Drawing.Point(25, 325);
            this.lblUnNormal.Name = "lblUnNormal";
            this.lblUnNormal.Size = new System.Drawing.Size(187, 30);
            this.lblUnNormal.TabIndex = 0;
            this.lblUnNormal.Text = "异型烟总量：      ";
            // 
            // lblNormalcOUNT
            // 
            this.lblNormalcOUNT.AutoSize = true;
            this.lblNormalcOUNT.BackColor = System.Drawing.Color.LightGreen;
            this.lblNormalcOUNT.Font = new System.Drawing.Font("微软雅黑", 16.25F);
            this.lblNormalcOUNT.Location = new System.Drawing.Point(27, 295);
            this.lblNormalcOUNT.Name = "lblNormalcOUNT";
            this.lblNormalcOUNT.Size = new System.Drawing.Size(187, 30);
            this.lblNormalcOUNT.TabIndex = 0;
            this.lblNormalcOUNT.Text = "常规烟总量：      ";
            // 
            // lblCigCount
            // 
            this.lblCigCount.AutoSize = true;
            this.lblCigCount.BackColor = System.Drawing.Color.LightGreen;
            this.lblCigCount.Font = new System.Drawing.Font("微软雅黑", 16.25F);
            this.lblCigCount.Location = new System.Drawing.Point(27, 265);
            this.lblCigCount.Name = "lblCigCount";
            this.lblCigCount.Size = new System.Drawing.Size(186, 30);
            this.lblCigCount.TabIndex = 0;
            this.lblCigCount.Text = "卷烟总量：         ";
            // 
            // gbtnw1
            // 
            this.gbtnw1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gbtnw1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbtnw1.Location = new System.Drawing.Point(62, 88);
            this.gbtnw1.Name = "gbtnw1";
            this.gbtnw1.Size = new System.Drawing.Size(83, 47);
            this.gbtnw1.TabIndex = 0;
            this.gbtnw1.Text = "工位1";
            this.gbtnw1.UseVisualStyleBackColor = false;
            this.gbtnw1.Click += new System.EventHandler(this.gbtnw1_Click);
            // 
            // panelUN
            // 
            this.panelUN.BackColor = System.Drawing.Color.Chocolate;
            this.panelUN.Location = new System.Drawing.Point(47, 77);
            this.panelUN.Name = "panelUN";
            this.panelUN.Size = new System.Drawing.Size(657, 71);
            this.panelUN.TabIndex = 86;
            // 
            // panelLb
            // 
            this.panelLb.BackColor = System.Drawing.Color.Chocolate;
            this.panelLb.Location = new System.Drawing.Point(495, 15);
            this.panelLb.Name = "panelLb";
            this.panelLb.Size = new System.Drawing.Size(209, 63);
            this.panelLb.TabIndex = 86;
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
            this.cs.Location = new System.Drawing.Point(691, 385);
            this.cs.Margin = new System.Windows.Forms.Padding(4);
            this.cs.Name = "cs";
            this.cs.Size = new System.Drawing.Size(320, 300);
            this.cs.TabIndex = 3;
            this.cs.W = 540;
            // 
            // FmInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1194, 698);
            this.Controls.Add(this.plcrtl);
            this.Controls.Add(this.lblNotFish);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.cs);
            this.Controls.Add(this.lbFinsh);
            this.Controls.Add(this.lblCigCount);
            this.Controls.Add(this.lblNormalcOUNT);
            this.Controls.Add(this.lblUnNormal);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Label lblorderdate;
        private System.Windows.Forms.Label lbllinename;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.ListBox list_date;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNotFish;
        private System.Windows.Forms.Label lbFinsh;
        private System.Windows.Forms.Label lblUnNormal;
        private System.Windows.Forms.Label lblNormalcOUNT;
        private System.Windows.Forms.Label lblCigCount;
        private System.Windows.Forms.Button btnRemake;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Button gbtnw5;
        private System.Windows.Forms.Button gbtnw4;
        private System.Windows.Forms.Button gbtnw3;
        private System.Windows.Forms.Button gbtnw2;
        private System.Windows.Forms.Button gbtnw6;
        private System.Windows.Forms.Button gbtnw9;
        private System.Windows.Forms.Button gbtnw8;
        private System.Windows.Forms.Button gbtnw7;
        private System.Windows.Forms.Button gbtnw1;
        private System.Windows.Forms.Panel panelLb;
        private System.Windows.Forms.Panel panelUN;
    }
    
}