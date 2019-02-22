namespace PackageMachine
{
    partial class FmCacheDetail
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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_Wait = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_Finish = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(92, 540);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "关闭";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(4, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "皮带缓存列表";
            // 
            // lb_Wait
            // 
            this.lb_Wait.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Wait.FormattingEnabled = true;
            this.lb_Wait.ItemHeight = 16;
            this.lb_Wait.Location = new System.Drawing.Point(3, 34);
            this.lb_Wait.Name = "lb_Wait";
            this.lb_Wait.Size = new System.Drawing.Size(252, 500);
            this.lb_Wait.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(262, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "抓起完成列表";
            this.label1.Visible = false;
            // 
            // lb_Finish
            // 
            this.lb_Finish.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Finish.FormattingEnabled = true;
            this.lb_Finish.ItemHeight = 16;
            this.lb_Finish.Location = new System.Drawing.Point(261, 34);
            this.lb_Finish.Name = "lb_Finish";
            this.lb_Finish.Size = new System.Drawing.Size(252, 500);
            this.lb_Finish.TabIndex = 6;
            this.lb_Finish.Visible = false;
            // 
            // FmCacheDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 575);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_Finish);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_Wait);
            this.Controls.Add(this.btn_Cancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FmCacheDetail";
            this.Text = "皮带信息";
            this.Load += new System.EventHandler(this.FmCacheDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Token: 0x0400006F RID: 111
        private global::System.Windows.Forms.Button btn_Cancel;

        // Token: 0x04000071 RID: 113
        private global::System.Windows.Forms.Label label2;

        // Token: 0x04000072 RID: 114
        private global::System.Windows.Forms.ListBox lb_Wait;
        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lb_Finish;
    }
}