namespace PackageMachine
{
    partial class FmCommoditySize
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
            this.DGV_OrderInfo = new System.Windows.Forms.DataGridView();
            this.textBox_QueryText = new System.Windows.Forms.TextBox();
            this.btn_Query = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_OrderInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_OrderInfo
            // 
            this.DGV_OrderInfo.AllowUserToAddRows = false;
            this.DGV_OrderInfo.AllowUserToDeleteRows = false;
            this.DGV_OrderInfo.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DGV_OrderInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_OrderInfo.Location = new System.Drawing.Point(45, 128);
            this.DGV_OrderInfo.Name = "DGV_OrderInfo";
            this.DGV_OrderInfo.RowTemplate.Height = 23;
            this.DGV_OrderInfo.Size = new System.Drawing.Size(537, 341);
            this.DGV_OrderInfo.TabIndex = 4;
            // 
            // textBox_QueryText
            // 
            this.textBox_QueryText.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_QueryText.Location = new System.Drawing.Point(104, 78);
            this.textBox_QueryText.Name = "textBox_QueryText";
            this.textBox_QueryText.Size = new System.Drawing.Size(266, 23);
            this.textBox_QueryText.TabIndex = 5;
            this.textBox_QueryText.Text = "请输入卷烟名称/卷烟编码";
            // 
            // btn_Query
            // 
            this.btn_Query.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Query.Location = new System.Drawing.Point(409, 78);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(75, 23);
            this.btn_Query.TabIndex = 6;
            this.btn_Query.Text = "查  询";
            this.btn_Query.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "尺寸维护";
            // 
            // FmCommoditySize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 522);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Query);
            this.Controls.Add(this.textBox_QueryText);
            this.Controls.Add(this.DGV_OrderInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FmCommoditySize";
            this.Text = "FmCommoditySize";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_OrderInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_OrderInfo;
        private System.Windows.Forms.TextBox textBox_QueryText;
        private System.Windows.Forms.Button btn_Query;
        private System.Windows.Forms.Label label1;
    }
}