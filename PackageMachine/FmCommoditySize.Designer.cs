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
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_code = new System.Windows.Forms.TextBox();
            this.lbl_code = new System.Windows.Forms.Label();
            this.txt_lenght = new System.Windows.Forms.TextBox();
            this.lbl_lenght = new System.Windows.Forms.Label();
            this.txt_weight = new System.Windows.Forms.TextBox();
            this.lbl_weight = new System.Windows.Forms.Label();
            this.txt_height = new System.Windows.Forms.TextBox();
            this.lbl_height = new System.Windows.Forms.Label();
            this.lbl_doubletask = new System.Windows.Forms.Label();
            this.comboBox_doubletask = new System.Windows.Forms.ComboBox();
            this.btn_update = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_OrderInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_OrderInfo
            // 
            this.DGV_OrderInfo.AllowUserToAddRows = false;
            this.DGV_OrderInfo.AllowUserToDeleteRows = false;
            this.DGV_OrderInfo.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DGV_OrderInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_OrderInfo.Location = new System.Drawing.Point(31, 82);
            this.DGV_OrderInfo.Name = "DGV_OrderInfo";
            this.DGV_OrderInfo.ReadOnly = true;
            this.DGV_OrderInfo.RowTemplate.Height = 23;
            this.DGV_OrderInfo.Size = new System.Drawing.Size(633, 357);
            this.DGV_OrderInfo.TabIndex = 4;
            this.DGV_OrderInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_OrderInfo_CellClick);
            // 
            // textBox_QueryText
            // 
            this.textBox_QueryText.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_QueryText.Location = new System.Drawing.Point(188, 36);
            this.textBox_QueryText.Name = "textBox_QueryText";
            this.textBox_QueryText.Size = new System.Drawing.Size(266, 23);
            this.textBox_QueryText.TabIndex = 5;
            // 
            // btn_Query
            // 
            this.btn_Query.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Query.Location = new System.Drawing.Point(519, 36);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(75, 23);
            this.btn_Query.TabIndex = 6;
            this.btn_Query.Text = "查  询";
            this.btn_Query.UseVisualStyleBackColor = true;
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "品牌名称：";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(695, 87);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(53, 12);
            this.lbl_name.TabIndex = 9;
            this.lbl_name.Text = "卷烟名称";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(761, 84);
            this.txt_name.Name = "txt_name";
            this.txt_name.ReadOnly = true;
            this.txt_name.Size = new System.Drawing.Size(202, 21);
            this.txt_name.TabIndex = 10;
            // 
            // txt_code
            // 
            this.txt_code.Location = new System.Drawing.Point(761, 141);
            this.txt_code.Name = "txt_code";
            this.txt_code.ReadOnly = true;
            this.txt_code.Size = new System.Drawing.Size(100, 21);
            this.txt_code.TabIndex = 12;
            // 
            // lbl_code
            // 
            this.lbl_code.AutoSize = true;
            this.lbl_code.Location = new System.Drawing.Point(695, 144);
            this.lbl_code.Name = "lbl_code";
            this.lbl_code.Size = new System.Drawing.Size(53, 12);
            this.lbl_code.TabIndex = 11;
            this.lbl_code.Text = "卷烟编码";
            // 
            // txt_lenght
            // 
            this.txt_lenght.Location = new System.Drawing.Point(761, 186);
            this.txt_lenght.Name = "txt_lenght";
            this.txt_lenght.Size = new System.Drawing.Size(100, 21);
            this.txt_lenght.TabIndex = 14;
            // 
            // lbl_lenght
            // 
            this.lbl_lenght.AutoSize = true;
            this.lbl_lenght.Location = new System.Drawing.Point(719, 189);
            this.lbl_lenght.Name = "lbl_lenght";
            this.lbl_lenght.Size = new System.Drawing.Size(29, 12);
            this.lbl_lenght.TabIndex = 13;
            this.lbl_lenght.Text = "长度";
            // 
            // txt_weight
            // 
            this.txt_weight.Location = new System.Drawing.Point(761, 234);
            this.txt_weight.Name = "txt_weight";
            this.txt_weight.Size = new System.Drawing.Size(100, 21);
            this.txt_weight.TabIndex = 16;
            // 
            // lbl_weight
            // 
            this.lbl_weight.AutoSize = true;
            this.lbl_weight.Location = new System.Drawing.Point(719, 237);
            this.lbl_weight.Name = "lbl_weight";
            this.lbl_weight.Size = new System.Drawing.Size(29, 12);
            this.lbl_weight.TabIndex = 15;
            this.lbl_weight.Text = "宽度";
            // 
            // txt_height
            // 
            this.txt_height.Location = new System.Drawing.Point(761, 284);
            this.txt_height.Name = "txt_height";
            this.txt_height.Size = new System.Drawing.Size(100, 21);
            this.txt_height.TabIndex = 18;
            // 
            // lbl_height
            // 
            this.lbl_height.AutoSize = true;
            this.lbl_height.Location = new System.Drawing.Point(719, 287);
            this.lbl_height.Name = "lbl_height";
            this.lbl_height.Size = new System.Drawing.Size(29, 12);
            this.lbl_height.TabIndex = 17;
            this.lbl_height.Text = "高度";
            // 
            // lbl_doubletask
            // 
            this.lbl_doubletask.AutoSize = true;
            this.lbl_doubletask.Location = new System.Drawing.Point(719, 339);
            this.lbl_doubletask.Name = "lbl_doubletask";
            this.lbl_doubletask.Size = new System.Drawing.Size(29, 12);
            this.lbl_doubletask.TabIndex = 19;
            this.lbl_doubletask.Text = "双抓";
            // 
            // comboBox_doubletask
            // 
            this.comboBox_doubletask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_doubletask.FormattingEnabled = true;
            this.comboBox_doubletask.Location = new System.Drawing.Point(761, 336);
            this.comboBox_doubletask.Name = "comboBox_doubletask";
            this.comboBox_doubletask.Size = new System.Drawing.Size(100, 20);
            this.comboBox_doubletask.TabIndex = 20;
            // 
            // btn_update
            // 
            this.btn_update.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_update.Location = new System.Drawing.Point(862, 403);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(101, 36);
            this.btn_update.TabIndex = 21;
            this.btn_update.Text = "更  新";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // FmCommoditySize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(975, 522);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.comboBox_doubletask);
            this.Controls.Add(this.lbl_doubletask);
            this.Controls.Add(this.txt_height);
            this.Controls.Add(this.lbl_height);
            this.Controls.Add(this.txt_weight);
            this.Controls.Add(this.lbl_weight);
            this.Controls.Add(this.txt_lenght);
            this.Controls.Add(this.lbl_lenght);
            this.Controls.Add(this.txt_code);
            this.Controls.Add(this.lbl_code);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.label2);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.Label lbl_code;
        private System.Windows.Forms.TextBox txt_lenght;
        private System.Windows.Forms.Label lbl_lenght;
        private System.Windows.Forms.TextBox txt_weight;
        private System.Windows.Forms.Label lbl_weight;
        private System.Windows.Forms.TextBox txt_height;
        private System.Windows.Forms.Label lbl_height;
        private System.Windows.Forms.Label lbl_doubletask;
        private System.Windows.Forms.ComboBox comboBox_doubletask;
        private System.Windows.Forms.Button btn_update;
    }
}