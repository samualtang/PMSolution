namespace PackageMachine
{
    partial class FmTaskLocate
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
            this.gbcgy = new System.Windows.Forms.GroupBox();
            this.txtBsul = new System.Windows.Forms.TextBox();
            this.txtCigseq = new System.Windows.Forms.TextBox();
            this.txtYxy = new System.Windows.Forms.TextBox();
            this.txtFb = new System.Windows.Forms.TextBox();
            this.lblbsl = new System.Windows.Forms.Label();
            this.btnDw = new System.Windows.Forms.Button();
            this.lblYxy = new System.Windows.Forms.Label();
            this.lblcgy = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblinfo = new System.Windows.Forms.Label();
            this.gbcgy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbcgy
            // 
            this.gbcgy.Controls.Add(this.txtBsul);
            this.gbcgy.Controls.Add(this.txtCigseq);
            this.gbcgy.Controls.Add(this.txtYxy);
            this.gbcgy.Controls.Add(this.txtFb);
            this.gbcgy.Controls.Add(this.lblbsl);
            this.gbcgy.Controls.Add(this.btnDw);
            this.gbcgy.Controls.Add(this.lblYxy);
            this.gbcgy.Controls.Add(this.lblcgy);
            this.gbcgy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbcgy.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbcgy.Location = new System.Drawing.Point(12, 62);
            this.gbcgy.Name = "gbcgy";
            this.gbcgy.Size = new System.Drawing.Size(555, 170);
            this.gbcgy.TabIndex = 0;
            this.gbcgy.TabStop = false;
            this.gbcgy.Text = "操作";
            // 
            // txtBsul
            // 
            this.txtBsul.Location = new System.Drawing.Point(201, 61);
            this.txtBsul.Name = "txtBsul";
            this.txtBsul.Size = new System.Drawing.Size(109, 23);
            this.txtBsul.TabIndex = 2;
            // 
            // txtCigseq
            // 
            this.txtCigseq.Location = new System.Drawing.Point(434, 97);
            this.txtCigseq.Name = "txtCigseq";
            this.txtCigseq.Size = new System.Drawing.Size(109, 23);
            this.txtCigseq.TabIndex = 2;
            // 
            // txtYxy
            // 
            this.txtYxy.Location = new System.Drawing.Point(201, 96);
            this.txtYxy.Name = "txtYxy";
            this.txtYxy.Size = new System.Drawing.Size(109, 23);
            this.txtYxy.TabIndex = 2;
            // 
            // txtFb
            // 
            this.txtFb.Location = new System.Drawing.Point(201, 21);
            this.txtFb.Name = "txtFb";
            this.txtFb.Size = new System.Drawing.Size(109, 23);
            this.txtFb.TabIndex = 2;
            // 
            // lblbsl
            // 
            this.lblbsl.AutoSize = true;
            this.lblbsl.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lblbsl.Location = new System.Drawing.Point(6, 61);
            this.lblbsl.Name = "lblbsl";
            this.lblbsl.Size = new System.Drawing.Size(189, 20);
            this.lblbsl.TabIndex = 0;
            this.lblbsl.Text = "异型烟倍速链从任务包号：";
            // 
            // btnDw
            // 
            this.btnDw.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDw.Location = new System.Drawing.Point(221, 132);
            this.btnDw.Name = "btnDw";
            this.btnDw.Size = new System.Drawing.Size(75, 23);
            this.btnDw.TabIndex = 1;
            this.btnDw.Text = "定位";
            this.btnDw.UseVisualStyleBackColor = true;
            this.btnDw.Click += new System.EventHandler(this.btnDw_Click);
            // 
            // lblYxy
            // 
            this.lblYxy.AutoSize = true;
            this.lblYxy.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lblYxy.Location = new System.Drawing.Point(6, 99);
            this.lblYxy.Name = "lblYxy";
            this.lblYxy.Size = new System.Drawing.Size(433, 20);
            this.lblYxy.TabIndex = 0;
            this.lblYxy.Text = "异型烟机器人从任务包号：                               包内条烟流水号：";
            // 
            // lblcgy
            // 
            this.lblcgy.AutoSize = true;
            this.lblcgy.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lblcgy.Location = new System.Drawing.Point(21, 21);
            this.lblcgy.Name = "lblcgy";
            this.lblcgy.Size = new System.Drawing.Size(174, 20);
            this.lblcgy.TabIndex = 0;
            this.lblcgy.Text = "常规烟翻板从任务包号：";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblinfo
            // 
            this.lblinfo.AutoSize = true;
            this.lblinfo.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lblinfo.Location = new System.Drawing.Point(8, 9);
            this.lblinfo.Name = "lblinfo";
            this.lblinfo.Size = new System.Drawing.Size(225, 20);
            this.lblinfo.TabIndex = 0;
            this.lblinfo.Text = "testestestestetstetstestestest";
            // 
            // FmTaskLocate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(573, 244);
            this.Controls.Add(this.gbcgy);
            this.Controls.Add(this.lblinfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FmTaskLocate";
            this.Text = "任务定位";
            this.gbcgy.ResumeLayout(false);
            this.gbcgy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbcgy;
        private System.Windows.Forms.Label lblYxy;
        private System.Windows.Forms.Label lblcgy;
        private System.Windows.Forms.TextBox txtYxy;
        private System.Windows.Forms.TextBox txtFb;
        private System.Windows.Forms.Button btnDw;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtBsul;
        private System.Windows.Forms.Label lblbsl;
        private System.Windows.Forms.TextBox txtCigseq;
        private System.Windows.Forms.Label lblinfo;
    }
}