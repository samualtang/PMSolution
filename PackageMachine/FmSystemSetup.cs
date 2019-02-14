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

namespace PackageMachine.From
{
    public partial class FmSystemSetup : Form
    {
        public FmSystemSetup()
        {
            InitializeComponent();
        }
         
        private void btn_linktest_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();
            dataBase.Open();
            
            MessageBox.Show(dataBase.ConnState());
            dataBase.Close(); 
        }
    }
}
