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
    public partial class t1 : Form
    {
        public t1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Functions.PackageAlgorithm packageAlgorithm = new Functions.PackageAlgorithm();
            MessageBox.Show(packageAlgorithm.GetCigaretteOrderDate());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string d1 = System.DateTime.Now.ToString();
            Functions.BLL.PackageService packageAlgorithm = new Functions.BLL.PackageService();
            packageAlgorithm.GetAllOrder(5);
            MessageBox.Show(d1 + "   " + DateTime.Now.ToString());
        }
    }
}
