namespace PackageMachine
{
    partial class Fm_Orderinfo_All
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
            this.label_nowpackageseq = new System.Windows.Forms.Label();
            this.label_unnormul = new System.Windows.Forms.Label();
            this.label_normul = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_all = new System.Windows.Forms.RadioButton();
            this.radioButton_yxy = new System.Windows.Forms.RadioButton();
            this.radioButton_cgy = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_display = new System.Windows.Forms.CheckBox();
            this.Dgv_datainfo = new System.Windows.Forms.DataGridView();
            this.label_allpackageseq = new System.Windows.Forms.Label();
            this.label_allcig = new System.Windows.Forms.Label();
            this.label_sortnum = new System.Windows.Forms.Label();
            this.label_allpacksortnum = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_skip = new System.Windows.Forms.Button();
            this.button_next = new System.Windows.Forms.Button();
            this.button_last = new System.Windows.Forms.Button();
            this.button_end = new System.Windows.Forms.Button();
            this.button_top = new System.Windows.Forms.Button();
            this.cigrShow1 = new PackageMachine.CigrShow();
            this.label_SumCignum = new System.Windows.Forms.Label();
            this.label_customcode = new System.Windows.Forms.Label();
            this.label_customername = new System.Windows.Forms.Label();
            this.label_sortseq = new System.Windows.Forms.Label();
            this.label_regioncode = new System.Windows.Forms.Label();
            this.label_packageseq = new System.Windows.Forms.Label();
            this.label_packtasknum = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_datainfo)).BeginInit();
            this.SuspendLayout();
            // 
            // label_nowpackageseq
            // 
            this.label_nowpackageseq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_nowpackageseq.AutoSize = true;
            this.label_nowpackageseq.Location = new System.Drawing.Point(809, 10);
            this.label_nowpackageseq.Name = "label_nowpackageseq";
            this.label_nowpackageseq.Size = new System.Drawing.Size(119, 12);
            this.label_nowpackageseq.TabIndex = 50;
            this.label_nowpackageseq.Text = "当前包装机第：000包";
            // 
            // label_unnormul
            // 
            this.label_unnormul.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_unnormul.AutoSize = true;
            this.label_unnormul.Location = new System.Drawing.Point(936, 117);
            this.label_unnormul.Name = "label_unnormul";
            this.label_unnormul.Size = new System.Drawing.Size(59, 12);
            this.label_unnormul.TabIndex = 49;
            this.label_unnormul.Text = "异型烟000";
            // 
            // label_normul
            // 
            this.label_normul.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_normul.AutoSize = true;
            this.label_normul.Location = new System.Drawing.Point(839, 117);
            this.label_normul.Name = "label_normul";
            this.label_normul.Size = new System.Drawing.Size(59, 12);
            this.label_normul.TabIndex = 48;
            this.label_normul.Text = "常规烟000";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_all);
            this.groupBox1.Controls.Add(this.radioButton_yxy);
            this.groupBox1.Controls.Add(this.radioButton_cgy);
            this.groupBox1.Location = new System.Drawing.Point(14, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 36);
            this.groupBox1.TabIndex = 47;
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
            this.radioButton_all.Click += new System.EventHandler(this.radioButton_all_CheckedChanged);
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
            this.radioButton_yxy.Click += new System.EventHandler(this.radioButton_yxy_CheckedChanged);
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
            this.radioButton_cgy.Click += new System.EventHandler(this.radioButton_cgy_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(621, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 46;
            this.label1.Text = "包内垛型：";
            // 
            // checkBox_display
            // 
            this.checkBox_display.AutoSize = true;
            this.checkBox_display.Location = new System.Drawing.Point(312, 71);
            this.checkBox_display.Name = "checkBox_display";
            this.checkBox_display.Size = new System.Drawing.Size(96, 16);
            this.checkBox_display.TabIndex = 45;
            this.checkBox_display.Text = "显示全部明细";
            this.checkBox_display.UseVisualStyleBackColor = true;
            this.checkBox_display.Click += new System.EventHandler(this.checkBox_display_CheckedChanged);
            // 
            // Dgv_datainfo
            // 
            this.Dgv_datainfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Dgv_datainfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_datainfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_datainfo.Location = new System.Drawing.Point(10, 93);
            this.Dgv_datainfo.Name = "Dgv_datainfo";
            this.Dgv_datainfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.Dgv_datainfo.RowTemplate.Height = 23;
            this.Dgv_datainfo.Size = new System.Drawing.Size(601, 385);
            this.Dgv_datainfo.TabIndex = 44;
            // 
            // label_allpackageseq
            // 
            this.label_allpackageseq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_allpackageseq.AutoSize = true;
            this.label_allpackageseq.Location = new System.Drawing.Point(621, 10);
            this.label_allpackageseq.Name = "label_allpackageseq";
            this.label_allpackageseq.Size = new System.Drawing.Size(119, 12);
            this.label_allpackageseq.TabIndex = 43;
            this.label_allpackageseq.Text = "当前包装机共：000包";
            // 
            // label_allcig
            // 
            this.label_allcig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_allcig.AutoSize = true;
            this.label_allcig.Location = new System.Drawing.Point(744, 117);
            this.label_allcig.Name = "label_allcig";
            this.label_allcig.Size = new System.Drawing.Size(47, 12);
            this.label_allcig.TabIndex = 42;
            this.label_allcig.Text = "000条烟";
            // 
            // label_sortnum
            // 
            this.label_sortnum.AutoSize = true;
            this.label_sortnum.Location = new System.Drawing.Point(8, 10);
            this.label_sortnum.Name = "label_sortnum";
            this.label_sortnum.Size = new System.Drawing.Size(95, 12);
            this.label_sortnum.TabIndex = 41;
            this.label_sortnum.Text = "任务号：0000000";
            // 
            // label_allpacksortnum
            // 
            this.label_allpacksortnum.AutoSize = true;
            this.label_allpacksortnum.Location = new System.Drawing.Point(315, 10);
            this.label_allpacksortnum.Name = "label_allpacksortnum";
            this.label_allpacksortnum.Size = new System.Drawing.Size(71, 12);
            this.label_allpacksortnum.TabIndex = 40;
            this.label_allpacksortnum.Text = "总条数：000";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(1010, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(89, 21);
            this.textBox1.TabIndex = 39;
            // 
            // button_skip
            // 
            this.button_skip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_skip.Location = new System.Drawing.Point(1106, 44);
            this.button_skip.Name = "button_skip";
            this.button_skip.Size = new System.Drawing.Size(66, 28);
            this.button_skip.TabIndex = 38;
            this.button_skip.Text = "跳转";
            this.button_skip.UseVisualStyleBackColor = true;
            this.button_skip.Click += new System.EventHandler(this.button_skip_Click);
            // 
            // button_next
            // 
            this.button_next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_next.Location = new System.Drawing.Point(811, 44);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(75, 28);
            this.button_next.TabIndex = 35;
            this.button_next.Text = "下一包";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // button_last
            // 
            this.button_last.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_last.Location = new System.Drawing.Point(716, 44);
            this.button_last.Name = "button_last";
            this.button_last.Size = new System.Drawing.Size(75, 28);
            this.button_last.TabIndex = 34;
            this.button_last.Text = "上一包";
            this.button_last.UseVisualStyleBackColor = true;
            this.button_last.Click += new System.EventHandler(this.button_last_Click);
            // 
            // button_end
            // 
            this.button_end.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_end.Location = new System.Drawing.Point(905, 44);
            this.button_end.Name = "button_end";
            this.button_end.Size = new System.Drawing.Size(78, 28);
            this.button_end.TabIndex = 37;
            this.button_end.Text = "最后一包";
            this.button_end.UseVisualStyleBackColor = true;
            this.button_end.Click += new System.EventHandler(this.button_end_Click);
            // 
            // button_top
            // 
            this.button_top.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_top.Location = new System.Drawing.Point(623, 44);
            this.button_top.Name = "button_top";
            this.button_top.Size = new System.Drawing.Size(75, 28);
            this.button_top.TabIndex = 36;
            this.button_top.Text = "第一包";
            this.button_top.UseVisualStyleBackColor = true;
            this.button_top.Click += new System.EventHandler(this.button_top_Click);
            // 
            // cigrShow1
            // 
            this.cigrShow1.BackColor = System.Drawing.Color.White;
            this.cigrShow1.H = 0;
            this.cigrShow1.Location = new System.Drawing.Point(623, 170);
            this.cigrShow1.Margin = new System.Windows.Forms.Padding(4);
            this.cigrShow1.Name = "cigrShow1";
            this.cigrShow1.Size = new System.Drawing.Size(555, 308);
            this.cigrShow1.TabIndex = 33;
            this.cigrShow1.W = 0;
            // 
            // label_SumCignum
            // 
            this.label_SumCignum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_SumCignum.AutoSize = true;
            this.label_SumCignum.Location = new System.Drawing.Point(623, 93);
            this.label_SumCignum.Name = "label_SumCignum";
            this.label_SumCignum.Size = new System.Drawing.Size(59, 12);
            this.label_SumCignum.TabIndex = 32;
            this.label_SumCignum.Text = "共：000条";
            // 
            // label_customcode
            // 
            this.label_customcode.AutoSize = true;
            this.label_customcode.Location = new System.Drawing.Point(436, 10);
            this.label_customcode.Name = "label_customcode";
            this.label_customcode.Size = new System.Drawing.Size(137, 12);
            this.label_customcode.TabIndex = 31;
            this.label_customcode.Text = "专卖证号：000000000000";
            // 
            // label_customername
            // 
            this.label_customername.AutoSize = true;
            this.label_customername.Location = new System.Drawing.Point(230, 36);
            this.label_customername.Name = "label_customername";
            this.label_customername.Size = new System.Drawing.Size(203, 12);
            this.label_customername.TabIndex = 30;
            this.label_customername.Text = "客户名称：***********************";
            // 
            // label_sortseq
            // 
            this.label_sortseq.AutoSize = true;
            this.label_sortseq.Location = new System.Drawing.Point(230, 10);
            this.label_sortseq.Name = "label_sortseq";
            this.label_sortseq.Size = new System.Drawing.Size(47, 12);
            this.label_sortseq.TabIndex = 29;
            this.label_sortseq.Text = "第000户";
            // 
            // label_regioncode
            // 
            this.label_regioncode.AutoSize = true;
            this.label_regioncode.Location = new System.Drawing.Point(143, 10);
            this.label_regioncode.Name = "label_regioncode";
            this.label_regioncode.Size = new System.Drawing.Size(53, 12);
            this.label_regioncode.TabIndex = 28;
            this.label_regioncode.Text = "0000车组";
            // 
            // label_packageseq
            // 
            this.label_packageseq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_packageseq.AutoSize = true;
            this.label_packageseq.Location = new System.Drawing.Point(623, 117);
            this.label_packageseq.Name = "label_packageseq";
            this.label_packageseq.Size = new System.Drawing.Size(83, 12);
            this.label_packageseq.TabIndex = 27;
            this.label_packageseq.Text = "当前第：000包";
            // 
            // label_packtasknum
            // 
            this.label_packtasknum.AutoSize = true;
            this.label_packtasknum.Location = new System.Drawing.Point(8, 36);
            this.label_packtasknum.Name = "label_packtasknum";
            this.label_packtasknum.Size = new System.Drawing.Size(137, 12);
            this.label_packtasknum.TabIndex = 51;
            this.label_packtasknum.Text = "包装机任务号：00000000";
            // 
            // Fm_Orderinfo_All
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 488);
            this.Controls.Add(this.label_packtasknum);
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
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.button_last);
            this.Controls.Add(this.button_end);
            this.Controls.Add(this.button_top);
            this.Controls.Add(this.cigrShow1);
            this.Controls.Add(this.label_SumCignum);
            this.Controls.Add(this.label_customcode);
            this.Controls.Add(this.label_customername);
            this.Controls.Add(this.label_sortseq);
            this.Controls.Add(this.label_regioncode);
            this.Controls.Add(this.label_packageseq);
            this.Name = "Fm_Orderinfo_All";
            this.Text = "所有订单垛型";
            this.Load += new System.EventHandler(this.Fm_Orderinfo_All_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_datainfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_nowpackageseq;
        private System.Windows.Forms.Label label_unnormul;
        private System.Windows.Forms.Label label_normul;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_all;
        private System.Windows.Forms.RadioButton radioButton_yxy;
        private System.Windows.Forms.RadioButton radioButton_cgy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_display;
        private System.Windows.Forms.DataGridView Dgv_datainfo;
        private System.Windows.Forms.Label label_allpackageseq;
        private System.Windows.Forms.Label label_allcig;
        private System.Windows.Forms.Label label_sortnum;
        private System.Windows.Forms.Label label_allpacksortnum;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_skip;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.Button button_last;
        private System.Windows.Forms.Button button_end;
        private System.Windows.Forms.Button button_top;
        private CigrShow cigrShow1;
        private System.Windows.Forms.Label label_SumCignum;
        private System.Windows.Forms.Label label_customcode;
        private System.Windows.Forms.Label label_customername;
        private System.Windows.Forms.Label label_sortseq;
        private System.Windows.Forms.Label label_regioncode;
        private System.Windows.Forms.Label label_packageseq;
        private System.Windows.Forms.Label label_packtasknum;
    }
}