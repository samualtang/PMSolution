namespace PackageMachine
{
    partial class Fm_Orderinfo
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
            this.label_packageseq = new System.Windows.Forms.Label();
            this.label_regioncode = new System.Windows.Forms.Label();
            this.label_sortseq = new System.Windows.Forms.Label();
            this.label_customername = new System.Windows.Forms.Label();
            this.label_customcode = new System.Windows.Forms.Label();
            this.label_packnum = new System.Windows.Forms.Label();
            this.button_last = new System.Windows.Forms.Button();
            this.button_next = new System.Windows.Forms.Button();
            this.button_top = new System.Windows.Forms.Button();
            this.button_end = new System.Windows.Forms.Button();
            this.button_skip = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label_allpacksortnum = new System.Windows.Forms.Label();
            this.label_sortnum = new System.Windows.Forms.Label();
            this.label_allcig = new System.Windows.Forms.Label();
            this.label_allpackageseq = new System.Windows.Forms.Label();
            this.Dgv_datainfo = new System.Windows.Forms.DataGridView();
            this.checkBox_display = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_all = new System.Windows.Forms.RadioButton();
            this.radioButton_yxy = new System.Windows.Forms.RadioButton();
            this.radioButton_cgy = new System.Windows.Forms.RadioButton();
            this.label_normul = new System.Windows.Forms.Label();
            this.label_unnormul = new System.Windows.Forms.Label();
            this.label_nowpackageseq = new System.Windows.Forms.Label();
            this.cigrShow1 = new PackageMachine.CigrShow();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_datainfo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_packageseq
            // 
            this.label_packageseq.AutoSize = true;
            this.label_packageseq.Location = new System.Drawing.Point(625, 120);
            this.label_packageseq.Name = "label_packageseq";
            this.label_packageseq.Size = new System.Drawing.Size(83, 12);
            this.label_packageseq.TabIndex = 3;
            this.label_packageseq.Text = "当前第：000包";
            // 
            // label_regioncode
            // 
            this.label_regioncode.AutoSize = true;
            this.label_regioncode.Location = new System.Drawing.Point(145, 13);
            this.label_regioncode.Name = "label_regioncode";
            this.label_regioncode.Size = new System.Drawing.Size(53, 12);
            this.label_regioncode.TabIndex = 4;
            this.label_regioncode.Text = "0000车组";
            // 
            // label_sortseq
            // 
            this.label_sortseq.AutoSize = true;
            this.label_sortseq.Location = new System.Drawing.Point(232, 13);
            this.label_sortseq.Name = "label_sortseq";
            this.label_sortseq.Size = new System.Drawing.Size(47, 12);
            this.label_sortseq.TabIndex = 5;
            this.label_sortseq.Text = "第000户";
            // 
            // label_customername
            // 
            this.label_customername.AutoSize = true;
            this.label_customername.Location = new System.Drawing.Point(10, 34);
            this.label_customername.Name = "label_customername";
            this.label_customername.Size = new System.Drawing.Size(203, 12);
            this.label_customername.TabIndex = 6;
            this.label_customername.Text = "客户名称：***********************";
            // 
            // label_customcode
            // 
            this.label_customcode.AutoSize = true;
            this.label_customcode.Location = new System.Drawing.Point(438, 13);
            this.label_customcode.Name = "label_customcode";
            this.label_customcode.Size = new System.Drawing.Size(137, 12);
            this.label_customcode.TabIndex = 7;
            this.label_customcode.Text = "专卖证号：000000000000";
            // 
            // label_packnum
            // 
            this.label_packnum.AutoSize = true;
            this.label_packnum.Location = new System.Drawing.Point(625, 96);
            this.label_packnum.Name = "label_packnum";
            this.label_packnum.Size = new System.Drawing.Size(59, 12);
            this.label_packnum.TabIndex = 8;
            this.label_packnum.Text = "共：000包";
            // 
            // button_last
            // 
            this.button_last.Location = new System.Drawing.Point(718, 47);
            this.button_last.Name = "button_last";
            this.button_last.Size = new System.Drawing.Size(75, 28);
            this.button_last.TabIndex = 10;
            this.button_last.Text = "上一包";
            this.button_last.UseVisualStyleBackColor = true;
            this.button_last.Click += new System.EventHandler(this.button_last_Click);
            // 
            // button_next
            // 
            this.button_next.Location = new System.Drawing.Point(813, 47);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(75, 28);
            this.button_next.TabIndex = 11;
            this.button_next.Text = "下一包";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // button_top
            // 
            this.button_top.Location = new System.Drawing.Point(625, 47);
            this.button_top.Name = "button_top";
            this.button_top.Size = new System.Drawing.Size(75, 28);
            this.button_top.TabIndex = 12;
            this.button_top.Text = "第一包";
            this.button_top.UseVisualStyleBackColor = true;
            this.button_top.Click += new System.EventHandler(this.button_top_Click);
            // 
            // button_end
            // 
            this.button_end.Location = new System.Drawing.Point(907, 47);
            this.button_end.Name = "button_end";
            this.button_end.Size = new System.Drawing.Size(78, 28);
            this.button_end.TabIndex = 13;
            this.button_end.Text = "最后一包";
            this.button_end.UseVisualStyleBackColor = true;
            this.button_end.Click += new System.EventHandler(this.button_end_Click);
            // 
            // button_skip
            // 
            this.button_skip.Location = new System.Drawing.Point(1108, 47);
            this.button_skip.Name = "button_skip";
            this.button_skip.Size = new System.Drawing.Size(66, 28);
            this.button_skip.TabIndex = 14;
            this.button_skip.Text = "跳转";
            this.button_skip.UseVisualStyleBackColor = true;
            this.button_skip.Click += new System.EventHandler(this.button_skip_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1012, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(89, 21);
            this.textBox1.TabIndex = 15;
            // 
            // label_allpacksortnum
            // 
            this.label_allpacksortnum.AutoSize = true;
            this.label_allpacksortnum.Location = new System.Drawing.Point(317, 13);
            this.label_allpacksortnum.Name = "label_allpacksortnum";
            this.label_allpacksortnum.Size = new System.Drawing.Size(71, 12);
            this.label_allpacksortnum.TabIndex = 16;
            this.label_allpacksortnum.Text = "总条数：000";
            // 
            // label_sortnum
            // 
            this.label_sortnum.AutoSize = true;
            this.label_sortnum.Location = new System.Drawing.Point(10, 13);
            this.label_sortnum.Name = "label_sortnum";
            this.label_sortnum.Size = new System.Drawing.Size(95, 12);
            this.label_sortnum.TabIndex = 17;
            this.label_sortnum.Text = "任务号：0000000";
            // 
            // label_allcig
            // 
            this.label_allcig.AutoSize = true;
            this.label_allcig.Location = new System.Drawing.Point(746, 120);
            this.label_allcig.Name = "label_allcig";
            this.label_allcig.Size = new System.Drawing.Size(47, 12);
            this.label_allcig.TabIndex = 18;
            this.label_allcig.Text = "000条烟";
            // 
            // label_allpackageseq
            // 
            this.label_allpackageseq.AutoSize = true;
            this.label_allpackageseq.Location = new System.Drawing.Point(623, 13);
            this.label_allpackageseq.Name = "label_allpackageseq";
            this.label_allpackageseq.Size = new System.Drawing.Size(119, 12);
            this.label_allpackageseq.TabIndex = 19;
            this.label_allpackageseq.Text = "当前包装机共：000包";
            // 
            // Dgv_datainfo
            // 
            this.Dgv_datainfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_datainfo.Location = new System.Drawing.Point(12, 96);
            this.Dgv_datainfo.Name = "Dgv_datainfo";
            this.Dgv_datainfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.Dgv_datainfo.RowTemplate.Height = 23;
            this.Dgv_datainfo.Size = new System.Drawing.Size(601, 385);
            this.Dgv_datainfo.TabIndex = 20;
            // 
            // checkBox_display
            // 
            this.checkBox_display.AutoSize = true;
            this.checkBox_display.Location = new System.Drawing.Point(314, 74);
            this.checkBox_display.Name = "checkBox_display";
            this.checkBox_display.Size = new System.Drawing.Size(96, 16);
            this.checkBox_display.TabIndex = 21;
            this.checkBox_display.Text = "显示全部明细";
            this.checkBox_display.UseVisualStyleBackColor = true;
            this.checkBox_display.CheckedChanged += new System.EventHandler(this.checkBox_display_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(623, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "包内垛型：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_all);
            this.groupBox1.Controls.Add(this.radioButton_yxy);
            this.groupBox1.Controls.Add(this.radioButton_cgy);
            this.groupBox1.Location = new System.Drawing.Point(16, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 36);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // radioButton_all
            // 
            this.radioButton_all.AutoSize = true;
            this.radioButton_all.Checked = true;
            this.radioButton_all.Location = new System.Drawing.Point(191, 14);
            this.radioButton_all.Name = "radioButton_all";
            this.radioButton_all.Size = new System.Drawing.Size(47, 16);
            this.radioButton_all.TabIndex = 26;
            this.radioButton_all.TabStop = true;
            this.radioButton_all.Text = "全部";
            this.radioButton_all.UseVisualStyleBackColor = true;
            this.radioButton_all.CheckedChanged += new System.EventHandler(this.radioButton_all_CheckedChanged);
            // 
            // radioButton_yxy
            // 
            this.radioButton_yxy.AutoSize = true;
            this.radioButton_yxy.Location = new System.Drawing.Point(96, 14);
            this.radioButton_yxy.Name = "radioButton_yxy";
            this.radioButton_yxy.Size = new System.Drawing.Size(59, 16);
            this.radioButton_yxy.TabIndex = 25;
            this.radioButton_yxy.Text = "异型烟";
            this.radioButton_yxy.UseVisualStyleBackColor = true;
            this.radioButton_yxy.CheckedChanged += new System.EventHandler(this.radioButton_yxy_CheckedChanged);
            // 
            // radioButton_cgy
            // 
            this.radioButton_cgy.AutoSize = true;
            this.radioButton_cgy.Location = new System.Drawing.Point(6, 14);
            this.radioButton_cgy.Name = "radioButton_cgy";
            this.radioButton_cgy.Size = new System.Drawing.Size(59, 16);
            this.radioButton_cgy.TabIndex = 24;
            this.radioButton_cgy.Text = "常规烟";
            this.radioButton_cgy.UseVisualStyleBackColor = true;
            this.radioButton_cgy.CheckedChanged += new System.EventHandler(this.radioButton_cgy_CheckedChanged);
            // 
            // label_normul
            // 
            this.label_normul.AutoSize = true;
            this.label_normul.Location = new System.Drawing.Point(841, 120);
            this.label_normul.Name = "label_normul";
            this.label_normul.Size = new System.Drawing.Size(59, 12);
            this.label_normul.TabIndex = 24;
            this.label_normul.Text = "常规烟000";
            // 
            // label_unnormul
            // 
            this.label_unnormul.AutoSize = true;
            this.label_unnormul.Location = new System.Drawing.Point(938, 120);
            this.label_unnormul.Name = "label_unnormul";
            this.label_unnormul.Size = new System.Drawing.Size(59, 12);
            this.label_unnormul.TabIndex = 25;
            this.label_unnormul.Text = "异型烟000";
            // 
            // label_nowpackageseq
            // 
            this.label_nowpackageseq.AutoSize = true;
            this.label_nowpackageseq.Location = new System.Drawing.Point(811, 13);
            this.label_nowpackageseq.Name = "label_nowpackageseq";
            this.label_nowpackageseq.Size = new System.Drawing.Size(119, 12);
            this.label_nowpackageseq.TabIndex = 26;
            this.label_nowpackageseq.Text = "当前包装机第：000包";
            // 
            // cigrShow1
            // 
            this.cigrShow1.BackColor = System.Drawing.Color.White;
            this.cigrShow1.H = 0;
            this.cigrShow1.Location = new System.Drawing.Point(625, 173);
            this.cigrShow1.Margin = new System.Windows.Forms.Padding(4);
            this.cigrShow1.Name = "cigrShow1";
            this.cigrShow1.Size = new System.Drawing.Size(555, 308);
            this.cigrShow1.TabIndex = 9;
            this.cigrShow1.W = 0;
            this.cigrShow1.Load += new System.EventHandler(this.cigrShow1_Load);
            // 
            // Fm_Orderinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1186, 488);
            this.Controls.Add(this.label_nowpackageseq);
            this.Controls.Add(this.label_unnormul);
            this.Controls.Add(this.label_normul);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_display);
            this.Controls.Add(this.Dgv_datainfo);
            this.Controls.Add(this.label_allpackageseq);
            this.Controls.Add(this.label_allcig);
            this.Controls.Add(this.label_sortnum);
            this.Controls.Add(this.label_allpacksortnum);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_skip);
            this.Controls.Add(this.button_end);
            this.Controls.Add(this.button_top);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.button_last);
            this.Controls.Add(this.cigrShow1);
            this.Controls.Add(this.label_packnum);
            this.Controls.Add(this.label_customcode);
            this.Controls.Add(this.label_customername);
            this.Controls.Add(this.label_sortseq);
            this.Controls.Add(this.label_regioncode);
            this.Controls.Add(this.label_packageseq);
            this.Name = "Fm_Orderinfo";
            this.Text = "订单详情";
            this.Load += new System.EventHandler(this.Fm_Orderinfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_datainfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_packageseq;
        private System.Windows.Forms.Label label_regioncode;
        private System.Windows.Forms.Label label_sortseq;
        private System.Windows.Forms.Label label_customername;
        private System.Windows.Forms.Label label_customcode;
        private System.Windows.Forms.Label label_packnum;
        private CigrShow cigrShow1;
        private System.Windows.Forms.Button button_last;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.Button button_top;
        private System.Windows.Forms.Button button_end;
        private System.Windows.Forms.Button button_skip;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_allpacksortnum;
        private System.Windows.Forms.Label label_sortnum;
        private System.Windows.Forms.Label label_allcig;
        private System.Windows.Forms.Label label_allpackageseq;
        private System.Windows.Forms.DataGridView Dgv_datainfo;
        private System.Windows.Forms.CheckBox checkBox_display;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_all;
        private System.Windows.Forms.RadioButton radioButton_yxy;
        private System.Windows.Forms.RadioButton radioButton_cgy;
        private System.Windows.Forms.Label label_normul;
        private System.Windows.Forms.Label label_unnormul;
        private System.Windows.Forms.Label label_nowpackageseq;
    }
}