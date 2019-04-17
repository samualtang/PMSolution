﻿using System;
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
            Functions.BLL.PackageService2 packageAlgorithm = new Functions.BLL.PackageService2();
            packageAlgorithm.GetAllOrder(1);
            MessageBox.Show(d1 + "   " + DateTime.Now.ToString());
        }
    }
}
