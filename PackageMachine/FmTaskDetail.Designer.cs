namespace PackageMachine
{
    partial class FmTaskDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmTaskDetail));
            this.list_date = new System.Windows.Forms.ListBox();
            this.lblcheck = new System.Windows.Forms.Label();
            this.cbIsorNo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // list_date
            // 
            this.list_date.BackColor = System.Drawing.SystemColors.Control;
            this.list_date.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.list_date.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.list_date.FormattingEnabled = true;
            this.list_date.ItemHeight = 17;
            this.list_date.Location = new System.Drawing.Point(0, 116);
            this.list_date.Name = "list_date";
            this.list_date.Size = new System.Drawing.Size(845, 344);
            this.list_date.TabIndex = 1;
            // 
            // lblcheck
            // 
            this.lblcheck.AutoSize = true;
            this.lblcheck.Location = new System.Drawing.Point(12, 9);
            this.lblcheck.Name = "lblcheck";
            this.lblcheck.Size = new System.Drawing.Size(89, 12);
            this.lblcheck.TabIndex = 2;
            this.lblcheck.Text = "保持前端显示：";
            // 
            // cbIsorNo
            // 
            this.cbIsorNo.AutoSize = true;
            this.cbIsorNo.Location = new System.Drawing.Point(107, 9);
            this.cbIsorNo.Name = "cbIsorNo";
            this.cbIsorNo.Size = new System.Drawing.Size(15, 14);
            this.cbIsorNo.TabIndex = 3;
            this.cbIsorNo.UseVisualStyleBackColor = true;
            this.cbIsorNo.Click += new System.EventHandler(this.cbIsorNo_Click);
            // 
            // FmTaskDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 460);
            this.Controls.Add(this.cbIsorNo);
            this.Controls.Add(this.lblcheck);
            this.Controls.Add(this.list_date);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FmTaskDetail";
            this.Text = "任务详情";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FmTaskDetail_FormClosing);
            this.Load += new System.EventHandler(this.FmTaskDetail_Load);
            this.Resize += new System.EventHandler(this.FmTaskDetail_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox list_date;
        private System.Windows.Forms.Label lblcheck;
        private System.Windows.Forms.CheckBox cbIsorNo;
    }
}