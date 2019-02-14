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
            this.PanelCache = new System.Windows.Forms.Panel();
            this.lblFx = new System.Windows.Forms.Label();
            this.PanelCache.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelCache
            // 
            this.PanelCache.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelCache.Controls.Add(this.lblFx);
            this.PanelCache.Location = new System.Drawing.Point(12, 12);
            this.PanelCache.Name = "PanelCache";
            this.PanelCache.Size = new System.Drawing.Size(1426, 114);
            this.PanelCache.TabIndex = 0;
            // 
            // lblFx
            // 
            this.lblFx.AutoSize = true;
            this.lblFx.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lblFx.ForeColor = System.Drawing.Color.Red;
            this.lblFx.Location = new System.Drawing.Point(23, 0);
            this.lblFx.Name = "lblFx";
            this.lblFx.Size = new System.Drawing.Size(143, 20);
            this.lblFx.TabIndex = 0;
            this.lblFx.Text = "---进入包装机----->";
            // 
            // FmInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1450, 656);
            this.Controls.Add(this.PanelCache);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FmInfo";
            this.Text = "FmInfo";
            this.PanelCache.ResumeLayout(false);
            this.PanelCache.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelCache;
        private System.Windows.Forms.Label lblFx;
    }
}