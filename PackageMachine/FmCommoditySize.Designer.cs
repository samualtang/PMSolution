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
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_update = new System.Windows.Forms.Button();
            this.comboBox_doubletask = new System.Windows.Forms.ComboBox();
            this.lbl_doubletask = new System.Windows.Forms.Label();
            this.txt_height = new System.Windows.Forms.TextBox();
            this.lbl_height = new System.Windows.Forms.Label();
            this.txt_weight = new System.Windows.Forms.TextBox();
            this.lbl_weight = new System.Windows.Forms.Label();
            this.txt_lenght = new System.Windows.Forms.TextBox();
            this.lbl_lenght = new System.Windows.Forms.Label();
            this.txt_code = new System.Windows.Forms.TextBox();
            this.lbl_code = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_OrderInfo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGV_OrderInfo
            // 
            this.DGV_OrderInfo.AllowUserToAddRows = false;
            this.DGV_OrderInfo.AllowUserToDeleteRows = false;
            this.DGV_OrderInfo.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DGV_OrderInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_OrderInfo.Location = new System.Drawing.Point(12, 82);
            this.DGV_OrderInfo.Name = "DGV_OrderInfo";
            this.DGV_OrderInfo.ReadOnly = true;
            this.DGV_OrderInfo.RowTemplate.Height = 23;
            this.DGV_OrderInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect;
            this.DGV_OrderInfo.Size = new System.Drawing.Size(652, 428);
            this.DGV_OrderInfo.TabIndex = 4;
            this.DGV_OrderInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_OrderInfo_CellClick);
            this.DGV_OrderInfo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGV_OrderInfo_CellFormatting);
            // 
            // textBox_QueryText
            // 
            this.textBox_QueryText.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_QueryText.Location = new System.Drawing.Point(177, 20);
            this.textBox_QueryText.Name = "textBox_QueryText";
            this.textBox_QueryText.Size = new System.Drawing.Size(266, 23);
            this.textBox_QueryText.TabIndex = 5;
            // 
            // btn_Query
            // 
            this.btn_Query.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Query.Location = new System.Drawing.Point(508, 20);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(75, 23);
            this.btn_Query.TabIndex = 6;
            this.btn_Query.Text = "查  询";
            this.btn_Query.UseVisualStyleBackColor = true;
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "品牌名称：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_update);
            this.groupBox1.Controls.Add(this.comboBox_doubletask);
            this.groupBox1.Controls.Add(this.lbl_doubletask);
            this.groupBox1.Controls.Add(this.txt_height);
            this.groupBox1.Controls.Add(this.lbl_height);
            this.groupBox1.Controls.Add(this.txt_weight);
            this.groupBox1.Controls.Add(this.lbl_weight);
            this.groupBox1.Controls.Add(this.txt_lenght);
            this.groupBox1.Controls.Add(this.lbl_lenght);
            this.groupBox1.Controls.Add(this.txt_code);
            this.groupBox1.Controls.Add(this.lbl_code);
            this.groupBox1.Controls.Add(this.txt_name);
            this.groupBox1.Controls.Add(this.lbl_name);
            this.groupBox1.Location = new System.Drawing.Point(670, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 498);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // btn_update
            // 
            this.btn_update.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_update.Location = new System.Drawing.Point(109, 399);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(101, 36);
            this.btn_update.TabIndex = 34;
            this.btn_update.Text = "更  新";
            this.btn_update.UseVisualStyleBackColor = true;
            // 
            // comboBox_doubletask
            // 
            this.comboBox_doubletask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_doubletask.FormattingEnabled = true;
            this.comboBox_doubletask.Location = new System.Drawing.Point(84, 272);
            this.comboBox_doubletask.Name = "comboBox_doubletask";
            this.comboBox_doubletask.Size = new System.Drawing.Size(100, 20);
            this.comboBox_doubletask.TabIndex = 33;
            // 
            // lbl_doubletask
            // 
            this.lbl_doubletask.AutoSize = true;
            this.lbl_doubletask.Location = new System.Drawing.Point(42, 275);
            this.lbl_doubletask.Name = "lbl_doubletask";
            this.lbl_doubletask.Size = new System.Drawing.Size(29, 12);
            this.lbl_doubletask.TabIndex = 32;
            this.lbl_doubletask.Text = "双抓";
            // 
            // txt_height
            // 
            this.txt_height.Location = new System.Drawing.Point(84, 220);
            this.txt_height.Name = "txt_height";
            this.txt_height.ReadOnly = true;
            this.txt_height.Size = new System.Drawing.Size(100, 21);
            this.txt_height.TabIndex = 31;
            // 
            // lbl_height
            // 
            this.lbl_height.AutoSize = true;
            this.lbl_height.Location = new System.Drawing.Point(42, 223);
            this.lbl_height.Name = "lbl_height";
            this.lbl_height.Size = new System.Drawing.Size(29, 12);
            this.lbl_height.TabIndex = 30;
            this.lbl_height.Text = "高度";
            // 
            // txt_weight
            // 
            this.txt_weight.Location = new System.Drawing.Point(84, 170);
            this.txt_weight.Name = "txt_weight";
            this.txt_weight.ReadOnly = true;
            this.txt_weight.Size = new System.Drawing.Size(100, 21);
            this.txt_weight.TabIndex = 29;
            // 
            // lbl_weight
            // 
            this.lbl_weight.AutoSize = true;
            this.lbl_weight.Location = new System.Drawing.Point(42, 173);
            this.lbl_weight.Name = "lbl_weight";
            this.lbl_weight.Size = new System.Drawing.Size(29, 12);
            this.lbl_weight.TabIndex = 28;
            this.lbl_weight.Text = "宽度";
            // 
            // txt_lenght
            // 
            this.txt_lenght.Location = new System.Drawing.Point(84, 122);
            this.txt_lenght.Name = "txt_lenght";
            this.txt_lenght.ReadOnly = true;
            this.txt_lenght.Size = new System.Drawing.Size(100, 21);
            this.txt_lenght.TabIndex = 27;
            // 
            // lbl_lenght
            // 
            this.lbl_lenght.AutoSize = true;
            this.lbl_lenght.Location = new System.Drawing.Point(42, 125);
            this.lbl_lenght.Name = "lbl_lenght";
            this.lbl_lenght.Size = new System.Drawing.Size(29, 12);
            this.lbl_lenght.TabIndex = 26;
            this.lbl_lenght.Text = "长度";
            // 
            // txt_code
            // 
            this.txt_code.Location = new System.Drawing.Point(84, 77);
            this.txt_code.Name = "txt_code";
            this.txt_code.ReadOnly = true;
            this.txt_code.Size = new System.Drawing.Size(100, 21);
            this.txt_code.TabIndex = 25;
            // 
            // lbl_code
            // 
            this.lbl_code.AutoSize = true;
            this.lbl_code.Location = new System.Drawing.Point(18, 80);
            this.lbl_code.Name = "lbl_code";
            this.lbl_code.Size = new System.Drawing.Size(53, 12);
            this.lbl_code.TabIndex = 24;
            this.lbl_code.Text = "卷烟编码";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(84, 20);
            this.txt_name.Name = "txt_name";
            this.txt_name.ReadOnly = true;
            this.txt_name.Size = new System.Drawing.Size(202, 21);
            this.txt_name.TabIndex = 23;
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(18, 23);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(53, 12);
            this.lbl_name.TabIndex = 22;
            this.lbl_name.Text = "卷烟名称";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Query);
            this.groupBox2.Controls.Add(this.textBox_QueryText);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(652, 58);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "尺寸维护";
            // 
            // FmCommoditySize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(975, 522);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DGV_OrderInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FmCommoditySize";
            this.Text = "FmCommoditySize";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_OrderInfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_OrderInfo;
        private System.Windows.Forms.TextBox textBox_QueryText;
        private System.Windows.Forms.Button btn_Query;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.ComboBox comboBox_doubletask;
        private System.Windows.Forms.Label lbl_doubletask;
        private System.Windows.Forms.TextBox txt_height;
        private System.Windows.Forms.Label lbl_height;
        private System.Windows.Forms.TextBox txt_weight;
        private System.Windows.Forms.Label lbl_weight;
        private System.Windows.Forms.TextBox txt_lenght;
        private System.Windows.Forms.Label lbl_lenght;
        private System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.Label lbl_code;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}