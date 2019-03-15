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
            this.label1 = new System.Windows.Forms.Label();
            this.label_allpackageseq = new System.Windows.Forms.Label();
            this.Dgv_datainfo = new System.Windows.Forms.DataGridView();
            this.cigrShow1 = new PackageMachine.CigrShow();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_datainfo)).BeginInit();
            this.SuspendLayout();
            // 
            // label_packageseq
            // 
            this.label_packageseq.AutoSize = true;
            this.label_packageseq.Location = new System.Drawing.Point(521, 122);
            this.label_packageseq.Name = "label_packageseq";
            this.label_packageseq.Size = new System.Drawing.Size(71, 12);
            this.label_packageseq.TabIndex = 3;
            this.label_packageseq.Text = "当前第000包";
            // 
            // label_regioncode
            // 
            this.label_regioncode.AutoSize = true;
            this.label_regioncode.Location = new System.Drawing.Point(131, 13);
            this.label_regioncode.Name = "label_regioncode";
            this.label_regioncode.Size = new System.Drawing.Size(53, 12);
            this.label_regioncode.TabIndex = 4;
            this.label_regioncode.Text = "0000车组";
            // 
            // label_sortseq
            // 
            this.label_sortseq.AutoSize = true;
            this.label_sortseq.Location = new System.Drawing.Point(205, 13);
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
            this.label_customcode.Location = new System.Drawing.Point(382, 13);
            this.label_customcode.Name = "label_customcode";
            this.label_customcode.Size = new System.Drawing.Size(137, 12);
            this.label_customcode.TabIndex = 7;
            this.label_customcode.Text = "专卖证号：000000000000";
            // 
            // label_packnum
            // 
            this.label_packnum.AutoSize = true;
            this.label_packnum.Location = new System.Drawing.Point(521, 100);
            this.label_packnum.Name = "label_packnum";
            this.label_packnum.Size = new System.Drawing.Size(47, 12);
            this.label_packnum.TabIndex = 8;
            this.label_packnum.Text = "共000包";
            // 
            // button_last
            // 
            this.button_last.Location = new System.Drawing.Point(109, 63);
            this.button_last.Name = "button_last";
            this.button_last.Size = new System.Drawing.Size(75, 23);
            this.button_last.TabIndex = 10;
            this.button_last.Text = "上一包";
            this.button_last.UseVisualStyleBackColor = true;
            this.button_last.Click += new System.EventHandler(this.button_last_Click);
            // 
            // button_next
            // 
            this.button_next.Location = new System.Drawing.Point(213, 63);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(75, 23);
            this.button_next.TabIndex = 11;
            this.button_next.Text = "下一包";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // button_top
            // 
            this.button_top.Location = new System.Drawing.Point(16, 63);
            this.button_top.Name = "button_top";
            this.button_top.Size = new System.Drawing.Size(75, 23);
            this.button_top.TabIndex = 12;
            this.button_top.Text = "第一包";
            this.button_top.UseVisualStyleBackColor = true;
            this.button_top.Click += new System.EventHandler(this.button_top_Click);
            // 
            // button_end
            // 
            this.button_end.Location = new System.Drawing.Point(307, 63);
            this.button_end.Name = "button_end";
            this.button_end.Size = new System.Drawing.Size(78, 23);
            this.button_end.TabIndex = 13;
            this.button_end.Text = "最后一包";
            this.button_end.UseVisualStyleBackColor = true;
            this.button_end.Click += new System.EventHandler(this.button_end_Click);
            // 
            // button_skip
            // 
            this.button_skip.Location = new System.Drawing.Point(523, 61);
            this.button_skip.Name = "button_skip";
            this.button_skip.Size = new System.Drawing.Size(66, 23);
            this.button_skip.TabIndex = 14;
            this.button_skip.Text = "跳转";
            this.button_skip.UseVisualStyleBackColor = true;
            this.button_skip.Click += new System.EventHandler(this.button_skip_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(423, 63);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(89, 21);
            this.textBox1.TabIndex = 15;
            // 
            // label_allpacksortnum
            // 
            this.label_allpacksortnum.AutoSize = true;
            this.label_allpacksortnum.Location = new System.Drawing.Point(275, 13);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(521, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "共000条烟";
            // 
            // label_allpackageseq
            // 
            this.label_allpackageseq.AutoSize = true;
            this.label_allpackageseq.Location = new System.Drawing.Point(518, 197);
            this.label_allpackageseq.Name = "label_allpackageseq";
            this.label_allpackageseq.Size = new System.Drawing.Size(107, 12);
            this.label_allpackageseq.TabIndex = 19;
            this.label_allpackageseq.Text = "当前包装机第000包";
            // 
            // Dgv_datainfo
            // 
            this.Dgv_datainfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_datainfo.Location = new System.Drawing.Point(16, 105);
            this.Dgv_datainfo.Name = "Dgv_datainfo";
            this.Dgv_datainfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.Dgv_datainfo.RowTemplate.Height = 23;
            this.Dgv_datainfo.Size = new System.Drawing.Size(500, 380);
            this.Dgv_datainfo.TabIndex = 20;
            this.Dgv_datainfo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.Dgv_datainfo_CellFormatting);
            this.Dgv_datainfo.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.Dgv_datainfo_RowStateChanged);
            // 
            // cigrShow1
            // 
            this.cigrShow1.BackColor = System.Drawing.Color.White;
            this.cigrShow1.H = 0;
            this.cigrShow1.Location = new System.Drawing.Point(633, 34);
            this.cigrShow1.Margin = new System.Windows.Forms.Padding(4);
            this.cigrShow1.Name = "cigrShow1";
            this.cigrShow1.Size = new System.Drawing.Size(540, 451);
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
            this.Controls.Add(this.Dgv_datainfo);
            this.Controls.Add(this.label_allpackageseq);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_allpackageseq;
        private System.Windows.Forms.DataGridView Dgv_datainfo;
    }
}