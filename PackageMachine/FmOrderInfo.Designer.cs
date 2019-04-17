namespace PackageMachine
{
    partial class FmOrderInfo
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
            this.components = new System.ComponentModel.Container();
            this.textBox_QueryText = new System.Windows.Forms.TextBox();
            this.groupBox_order = new System.Windows.Forms.GroupBox();
            this.btn_Query = new System.Windows.Forms.Button();
            this.comboBox_QueryCriteria = new System.Windows.Forms.ComboBox();
            this.DGV_OrderInfo = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.查看明细ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_alltime_title = new System.Windows.Forms.Label();
            this.groupBox_efficiency = new System.Windows.Forms.GroupBox();
            this.lbl_Remainingtime_content = new System.Windows.Forms.Label();
            this.lbl_Efficiency_content = new System.Windows.Forms.Label();
            this.lbl_SurplusQty_content = new System.Windows.Forms.Label();
            this.lbl_allpacknum_content = new System.Windows.Forms.Label();
            this.lbl_alltime_content = new System.Windows.Forms.Label();
            this.lbl_Efficiency_title = new System.Windows.Forms.Label();
            this.lbl_Other_time = new System.Windows.Forms.Label();
            this.linklbl_Otherreasons = new System.Windows.Forms.LinkLabel();
            this.lbl_Remainingtime_title = new System.Windows.Forms.Label();
            this.lbl_SurplusQty_title = new System.Windows.Forms.Label();
            this.lbl_allpacknum_title = new System.Windows.Forms.Label();
            this.groupBox_order.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_OrderInfo)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox_efficiency.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_QueryText
            // 
            this.textBox_QueryText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_QueryText.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_QueryText.Location = new System.Drawing.Point(572, 36);
            this.textBox_QueryText.Name = "textBox_QueryText";
            this.textBox_QueryText.Size = new System.Drawing.Size(314, 23);
            this.textBox_QueryText.TabIndex = 2;
            // 
            // groupBox_order
            // 
            this.groupBox_order.Controls.Add(this.btn_Query);
            this.groupBox_order.Controls.Add(this.groupBox_efficiency);
            this.groupBox_order.Controls.Add(this.comboBox_QueryCriteria);
            this.groupBox_order.Controls.Add(this.DGV_OrderInfo);
            this.groupBox_order.Controls.Add(this.textBox_QueryText);
            this.groupBox_order.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_order.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox_order.Location = new System.Drawing.Point(0, 0);
            this.groupBox_order.Name = "groupBox_order";
            this.groupBox_order.Size = new System.Drawing.Size(1139, 463);
            this.groupBox_order.TabIndex = 3;
            this.groupBox_order.TabStop = false;
            this.groupBox_order.Text = "订单信息";
            // 
            // btn_Query
            // 
            this.btn_Query.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Query.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Query.Location = new System.Drawing.Point(1008, 36);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(75, 23);
            this.btn_Query.TabIndex = 5;
            this.btn_Query.Text = "查  询";
            this.btn_Query.UseVisualStyleBackColor = true;
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // comboBox_QueryCriteria
            // 
            this.comboBox_QueryCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_QueryCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_QueryCriteria.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_QueryCriteria.FormattingEnabled = true;
            this.comboBox_QueryCriteria.Location = new System.Drawing.Point(424, 36);
            this.comboBox_QueryCriteria.Name = "comboBox_QueryCriteria";
            this.comboBox_QueryCriteria.Size = new System.Drawing.Size(121, 25);
            this.comboBox_QueryCriteria.TabIndex = 4;
            // 
            // DGV_OrderInfo
            // 
            this.DGV_OrderInfo.AllowUserToAddRows = false;
            this.DGV_OrderInfo.AllowUserToDeleteRows = false;
            this.DGV_OrderInfo.AllowUserToResizeRows = false;
            this.DGV_OrderInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_OrderInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_OrderInfo.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DGV_OrderInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_OrderInfo.ColumnHeadersVisible = false;
            this.DGV_OrderInfo.ContextMenuStrip = this.contextMenuStrip1;
            this.DGV_OrderInfo.Location = new System.Drawing.Point(6, 86);
            this.DGV_OrderInfo.MultiSelect = false;
            this.DGV_OrderInfo.Name = "DGV_OrderInfo";
            this.DGV_OrderInfo.ReadOnly = true;
            this.DGV_OrderInfo.RowTemplate.Height = 23;
            this.DGV_OrderInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_OrderInfo.Size = new System.Drawing.Size(1127, 371);
            this.DGV_OrderInfo.TabIndex = 3;
            this.DGV_OrderInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_OrderInfo_CellClick);
            this.DGV_OrderInfo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DGV_OrderInfo_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看明细ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            this.contextMenuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.contextMenuStrip1_MouseDown);
            // 
            // 查看明细ToolStripMenuItem
            // 
            this.查看明细ToolStripMenuItem.Name = "查看明细ToolStripMenuItem";
            this.查看明细ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.查看明细ToolStripMenuItem.Text = "查看明细";
            this.查看明细ToolStripMenuItem.Click += new System.EventHandler(this.查看明细ToolStripMenuItem_Click);
            // 
            // lbl_alltime_title
            // 
            this.lbl_alltime_title.AutoSize = true;
            this.lbl_alltime_title.Location = new System.Drawing.Point(17, 77);
            this.lbl_alltime_title.Name = "lbl_alltime_title";
            this.lbl_alltime_title.Size = new System.Drawing.Size(68, 17);
            this.lbl_alltime_title.TabIndex = 4;
            this.lbl_alltime_title.Text = "开机时长：";
            // 
            // groupBox_efficiency
            // 
            this.groupBox_efficiency.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox_efficiency.Controls.Add(this.lbl_Remainingtime_content);
            this.groupBox_efficiency.Controls.Add(this.lbl_Efficiency_content);
            this.groupBox_efficiency.Controls.Add(this.lbl_SurplusQty_content);
            this.groupBox_efficiency.Controls.Add(this.lbl_allpacknum_content);
            this.groupBox_efficiency.Controls.Add(this.lbl_alltime_content);
            this.groupBox_efficiency.Controls.Add(this.lbl_Efficiency_title);
            this.groupBox_efficiency.Controls.Add(this.lbl_Other_time);
            this.groupBox_efficiency.Controls.Add(this.linklbl_Otherreasons);
            this.groupBox_efficiency.Controls.Add(this.lbl_Remainingtime_title);
            this.groupBox_efficiency.Controls.Add(this.lbl_SurplusQty_title);
            this.groupBox_efficiency.Controls.Add(this.lbl_allpacknum_title);
            this.groupBox_efficiency.Controls.Add(this.lbl_alltime_title);
            this.groupBox_efficiency.Location = new System.Drawing.Point(828, 136);
            this.groupBox_efficiency.Name = "groupBox_efficiency";
            this.groupBox_efficiency.Size = new System.Drawing.Size(299, 245);
            this.groupBox_efficiency.TabIndex = 5;
            this.groupBox_efficiency.TabStop = false;
            this.groupBox_efficiency.Text = "效率统计";
            this.groupBox_efficiency.Visible = false;
            // 
            // lbl_Remainingtime_content
            // 
            this.lbl_Remainingtime_content.AutoSize = true;
            this.lbl_Remainingtime_content.Location = new System.Drawing.Point(122, 199);
            this.lbl_Remainingtime_content.Name = "lbl_Remainingtime_content";
            this.lbl_Remainingtime_content.Size = new System.Drawing.Size(141, 17);
            this.lbl_Remainingtime_content.TabIndex = 15;
            this.lbl_Remainingtime_content.Text = "小时/分钟{需要可以配置}";
            // 
            // lbl_Efficiency_content
            // 
            this.lbl_Efficiency_content.AutoSize = true;
            this.lbl_Efficiency_content.Location = new System.Drawing.Point(98, 165);
            this.lbl_Efficiency_content.Name = "lbl_Efficiency_content";
            this.lbl_Efficiency_content.Size = new System.Drawing.Size(172, 17);
            this.lbl_Efficiency_content.TabIndex = 14;
            this.lbl_Efficiency_content.Text = "包效率；条效率{需要可以配置}";
            // 
            // lbl_SurplusQty_content
            // 
            this.lbl_SurplusQty_content.AutoSize = true;
            this.lbl_SurplusQty_content.Location = new System.Drawing.Point(98, 136);
            this.lbl_SurplusQty_content.Name = "lbl_SurplusQty_content";
            this.lbl_SurplusQty_content.Size = new System.Drawing.Size(182, 17);
            this.lbl_SurplusQty_content.TabIndex = 13;
            this.lbl_SurplusQty_content.Text = "数量/包；数量/条{需要可以配置}";
            // 
            // lbl_allpacknum_content
            // 
            this.lbl_allpacknum_content.AutoSize = true;
            this.lbl_allpacknum_content.Location = new System.Drawing.Point(98, 107);
            this.lbl_allpacknum_content.Name = "lbl_allpacknum_content";
            this.lbl_allpacknum_content.Size = new System.Drawing.Size(182, 17);
            this.lbl_allpacknum_content.TabIndex = 12;
            this.lbl_allpacknum_content.Text = "数量/包；数量/条{需要可以配置}";
            // 
            // lbl_alltime_content
            // 
            this.lbl_alltime_content.AutoSize = true;
            this.lbl_alltime_content.Location = new System.Drawing.Point(98, 77);
            this.lbl_alltime_content.Name = "lbl_alltime_content";
            this.lbl_alltime_content.Size = new System.Drawing.Size(141, 17);
            this.lbl_alltime_content.TabIndex = 11;
            this.lbl_alltime_content.Text = "小时/分钟{需要可以配置}";
            // 
            // lbl_Efficiency_title
            // 
            this.lbl_Efficiency_title.AutoSize = true;
            this.lbl_Efficiency_title.Location = new System.Drawing.Point(17, 165);
            this.lbl_Efficiency_title.Name = "lbl_Efficiency_title";
            this.lbl_Efficiency_title.Size = new System.Drawing.Size(68, 17);
            this.lbl_Efficiency_title.TabIndex = 10;
            this.lbl_Efficiency_title.Text = "包装效率：";
            // 
            // lbl_Other_time
            // 
            this.lbl_Other_time.AutoSize = true;
            this.lbl_Other_time.Location = new System.Drawing.Point(206, 31);
            this.lbl_Other_time.Name = "lbl_Other_time";
            this.lbl_Other_time.Size = new System.Drawing.Size(61, 17);
            this.lbl_Other_time.TabIndex = 9;
            this.lbl_Other_time.Text = "时间/分钟";
            // 
            // linklbl_Otherreasons
            // 
            this.linklbl_Otherreasons.AutoSize = true;
            this.linklbl_Otherreasons.Location = new System.Drawing.Point(183, 17);
            this.linklbl_Otherreasons.Name = "linklbl_Otherreasons";
            this.linklbl_Otherreasons.Size = new System.Drawing.Size(104, 17);
            this.linklbl_Otherreasons.TabIndex = 8;
            this.linklbl_Otherreasons.TabStop = true;
            this.linklbl_Otherreasons.Text = "其他原因停机时间";
            // 
            // lbl_Remainingtime_title
            // 
            this.lbl_Remainingtime_title.AutoSize = true;
            this.lbl_Remainingtime_title.Location = new System.Drawing.Point(17, 199);
            this.lbl_Remainingtime_title.Name = "lbl_Remainingtime_title";
            this.lbl_Remainingtime_title.Size = new System.Drawing.Size(92, 17);
            this.lbl_Remainingtime_title.TabIndex = 7;
            this.lbl_Remainingtime_title.Text = "预计剩余时间：";
            // 
            // lbl_SurplusQty_title
            // 
            this.lbl_SurplusQty_title.AutoSize = true;
            this.lbl_SurplusQty_title.Location = new System.Drawing.Point(17, 136);
            this.lbl_SurplusQty_title.Name = "lbl_SurplusQty_title";
            this.lbl_SurplusQty_title.Size = new System.Drawing.Size(68, 17);
            this.lbl_SurplusQty_title.TabIndex = 6;
            this.lbl_SurplusQty_title.Text = "剩余数量：";
            // 
            // lbl_allpacknum_title
            // 
            this.lbl_allpacknum_title.AutoSize = true;
            this.lbl_allpacknum_title.Location = new System.Drawing.Point(17, 107);
            this.lbl_allpacknum_title.Name = "lbl_allpacknum_title";
            this.lbl_allpacknum_title.Size = new System.Drawing.Size(68, 17);
            this.lbl_allpacknum_title.TabIndex = 5;
            this.lbl_allpacknum_title.Text = "已包总数：";
            // 
            // FmOrderInfo
            // 
            this.AcceptButton = this.btn_Query;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1139, 463);
            this.Controls.Add(this.groupBox_order);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FmOrderInfo";
            this.Text = "综合查询";
            this.groupBox_order.ResumeLayout(false);
            this.groupBox_order.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_OrderInfo)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox_efficiency.ResumeLayout(false);
            this.groupBox_efficiency.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_QueryText;
        private System.Windows.Forms.GroupBox groupBox_order;
        private System.Windows.Forms.Button btn_Query;
        private System.Windows.Forms.ComboBox comboBox_QueryCriteria;
        private System.Windows.Forms.DataGridView DGV_OrderInfo;
        private System.Windows.Forms.Label lbl_alltime_title;
        private System.Windows.Forms.GroupBox groupBox_efficiency;
        private System.Windows.Forms.Label lbl_allpacknum_title;
        private System.Windows.Forms.Label lbl_Efficiency_title;
        private System.Windows.Forms.Label lbl_Other_time;
        private System.Windows.Forms.LinkLabel linklbl_Otherreasons;
        private System.Windows.Forms.Label lbl_Remainingtime_title;
        private System.Windows.Forms.Label lbl_SurplusQty_title;
        private System.Windows.Forms.Label lbl_Remainingtime_content;
        private System.Windows.Forms.Label lbl_Efficiency_content;
        private System.Windows.Forms.Label lbl_SurplusQty_content;
        private System.Windows.Forms.Label lbl_allpacknum_content;
        private System.Windows.Forms.Label lbl_alltime_content;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 查看明细ToolStripMenuItem;
    }
}