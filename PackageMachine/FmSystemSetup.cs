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
            textBox_CigGap.Text = Functions.PubFunction.GlobalPara.CigGap.ToString();
            textBox_BoxHeight.Text = Functions.PubFunction.GlobalPara.BoxHeight.ToString();
            textBox_BoxWidth.Text = Functions.PubFunction.GlobalPara.BoxWidth.ToString();
            textBox_BoxLenght.Text = Functions.PubFunction.GlobalPara.BoxLenght.ToString();
            textBox_RobitPlc_Ip.Text = Functions.PubFunction.GlobalPara.RobitPlc_Ip.ToString();
            textBox_RobitPlc_Port.Text = Functions.PubFunction.GlobalPara.RobitPlc_Port.ToString();
            textBox_Opc_Name.Text = Functions.PubFunction.GlobalPara.Opc_Name.ToString();


        }

        private void btn_updateLinkString_Click(object sender, EventArgs e)
        {
            try
            {
                Functions.PubFunction.GlobalPara.PackageNo = Convert.ToInt32(textBox_packageno.Text);
                Functions.PubFunction.GlobalPara.BoxHeight = Convert.ToInt32(textBox_BoxHeight.Text);
                Functions.PubFunction.GlobalPara.BoxLenght = Convert.ToInt32(textBox_BoxLenght.Text);
                Functions.PubFunction.GlobalPara.BoxWidth = Convert.ToInt32(textBox_BoxWidth.Text);
                Functions.PubFunction.GlobalPara.CigGap = Convert.ToInt32(textBox_CigGap.Text);
                Functions.PubFunction.GlobalPara.RobitPlc_Ip = textBox_RobitPlc_Ip.Text;
                Functions.PubFunction.GlobalPara.RobitPlc_Port = textBox_RobitPlc_Port.Text;
                Functions.PubFunction.GlobalPara.Opc_Name = textBox_Opc_Name.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
                
            }
            
            
        }
    }
}
