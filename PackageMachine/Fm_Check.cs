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
    public partial class Fm_Check : Form
    {
        public Fm_Check()
        {
            InitializeComponent();
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            if (Functions.PubFunction.GlobalPara.OpenCheckPwd == txt_pwd.Text)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("验证密码错误！");
            }
        }
    }
}
