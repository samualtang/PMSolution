using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackageMachine
{
    public partial class Fm_Login : Form
    {
        public Fm_Login()
        {
            InitializeComponent();
        }
        private bool iscancel = false;

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (Functions.PubFunction.GlobalPara.OpenCheckUid == txt_uid.Text && Functions.PubFunction.GlobalPara.OpenCheckPwd == txt_pwd.Text)
            {
                DialogResult = DialogResult
                    .OK;
            }
            else
            {
                MessageBox.Show("账号或密码错误！");
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            try
            {
                iscancel = true;
                this.Close();
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
