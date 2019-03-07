using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using Functions;

namespace PackageMachine
{
    public partial class FmSystemSetup : Form
    {
        public FmSystemSetup()
        {
            InitializeComponent();
        }
         
        private void btn_linktest_Click(object sender, EventArgs e)
        { 
            
        }

        private void FmSystemSetup_Load(object sender, EventArgs e)
        {
            textBox_packageno.Text = Functions.PubFunction.GlobalPara.PackageNo.ToString();


        }

        private void btn_updateLinkString_Click(object sender, EventArgs e)
        {
            Functions.PubFunction.GlobalPara.PackageNo = Convert.ToInt32(textBox_packageno.Text);

        }
    }
}
