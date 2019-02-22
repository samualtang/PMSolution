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
            this.Dgv_datainfo = new System.Windows.Forms.DataGridView();
            this.label_packsortnum = new System.Windows.Forms.Label();
            this.label_regioncode = new System.Windows.Forms.Label();
            this.label_sortseq = new System.Windows.Forms.Label();
            this.label_customername = new System.Windows.Forms.Label();
            this.label_customcode = new System.Windows.Forms.Label();
            this.label_packnum = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label_allpacksortnum = new System.Windows.Forms.Label();
            this.cigrShow1 = new PackageMachine.CigrShow();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_datainfo)).BeginInit();
            this.SuspendLayout();
            // 
            // Dgv_datainfo
            // 
            this.Dgv_datainfo.AllowUserToAddRows = false;
            this.Dgv_datainfo.AllowUserToDeleteRows = false;
            this.Dgv_datainfo.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Dgv_datainfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_datainfo.Location = new System.Drawing.Point(12, 100);
            this.Dgv_datainfo.Name = "Dgv_datainfo";
            this.Dgv_datainfo.ReadOnly = true;
            this.Dgv_datainfo.RowTemplate.Height = 23;
            this.Dgv_datainfo.Size = new System.Drawing.Size(500, 371);
            this.Dgv_datainfo.TabIndex = 0;
            // 
            // label_packsortnum
            // 
            this.label_packsortnum.AutoSize = true;
            this.label_packsortnum.Location = new System.Drawing.Point(621, 74);
            this.label_packsortnum.Name = "label_packsortnum";
            this.label_packsortnum.Size = new System.Drawing.Size(71, 12);
            this.label_packsortnum.TabIndex = 3;
            this.label_packsortnum.Text = "当前第000包";
            // 
            // label_regioncode
            // 
            this.label_regioncode.AutoSize = true;
            this.label_regioncode.Location = new System.Drawing.Point(10, 13);
            this.label_regioncode.Name = "label_regioncode";
            this.label_regioncode.Size = new System.Drawing.Size(53, 12);
            this.label_regioncode.TabIndex = 4;
            this.label_regioncode.Text = "0000车组";
            // 
            // label_sortseq
            // 
            this.label_sortseq.AutoSize = true;
            this.label_sortseq.Location = new System.Drawing.Point(103, 13);
            this.label_sortseq.Name = "label_sortseq";
            this.label_sortseq.Size = new System.Drawing.Size(47, 12);
            this.label_sortseq.TabIndex = 5;
            this.label_sortseq.Text = "第000户";
            // 
            // label_customername
            // 
            this.label_customername.AutoSize = true;
            this.label_customername.Location = new System.Drawing.Point(452, 13);
            this.label_customername.Name = "label_customername";
            this.label_customername.Size = new System.Drawing.Size(203, 12);
            this.label_customername.TabIndex = 6;
            this.label_customername.Text = "客户名称：***********************";
            // 
            // label_customcode
            // 
            this.label_customcode.AutoSize = true;
            this.label_customcode.Location = new System.Drawing.Point(280, 13);
            this.label_customcode.Name = "label_customcode";
            this.label_customcode.Size = new System.Drawing.Size(137, 12);
            this.label_customcode.TabIndex = 7;
            this.label_customcode.Text = "专卖证号：000000000000";
            // 
            // label_packnum
            // 
            this.label_packnum.AutoSize = true;
            this.label_packnum.Location = new System.Drawing.Point(1154, 74);
            this.label_packnum.Name = "label_packnum";
            this.label_packnum.Size = new System.Drawing.Size(47, 12);
            this.label_packnum.TabIndex = 8;
            this.label_packnum.Text = "共000包";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "上一包";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(213, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "下一包";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 63);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "第一包";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(307, 63);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(78, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "最后一包";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(518, 63);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(66, 23);
            this.button5.TabIndex = 14;
            this.button5.Text = "跳转";
            this.button5.UseVisualStyleBackColor = true;
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
            this.label_allpacksortnum.Location = new System.Drawing.Point(173, 13);
            this.label_allpacksortnum.Name = "label_allpacksortnum";
            this.label_allpacksortnum.Size = new System.Drawing.Size(71, 12);
            this.label_allpacksortnum.TabIndex = 16;
            this.label_allpacksortnum.Text = "总条数：000";
            // 
            // cigrShow1
            // 
            this.cigrShow1.BackColor = System.Drawing.Color.White;
            this.cigrShow1.H = 0;
            this.cigrShow1.Location = new System.Drawing.Point(518, 100);
            this.cigrShow1.Margin = new System.Windows.Forms.Padding(4);
            this.cigrShow1.Name = "cigrShow1";
            this.cigrShow1.Size = new System.Drawing.Size(707, 371);
            this.cigrShow1.TabIndex = 9;
            this.cigrShow1.W = 0;
            // 
            // Fm_Orderinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1237, 483);
            this.Controls.Add(this.label_allpacksortnum);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cigrShow1);
            this.Controls.Add(this.label_packnum);
            this.Controls.Add(this.label_customcode);
            this.Controls.Add(this.label_customername);
            this.Controls.Add(this.label_sortseq);
            this.Controls.Add(this.label_regioncode);
            this.Controls.Add(this.label_packsortnum);
            this.Controls.Add(this.Dgv_datainfo);
            this.Name = "Fm_Orderinfo";
            this.Text = "订单详情";
            this.Load += new System.EventHandler(this.Fm_Orderinfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_datainfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Dgv_datainfo;
        private System.Windows.Forms.Label label_packsortnum;
        private System.Windows.Forms.Label label_regioncode;
        private System.Windows.Forms.Label label_sortseq;
        private System.Windows.Forms.Label label_customername;
        private System.Windows.Forms.Label label_customcode;
        private System.Windows.Forms.Label label_packnum;
        private CigrShow cigrShow1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_allpacksortnum;
    }
}