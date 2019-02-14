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
    public partial class FmMain : Form
    {
        public FmMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
           
        }
        private void pbInfo_Click(object sender, EventArgs e)
        {
            // ContrlCtrl(panelMain);
            FmInfo frm = new FmInfo();
            if (CheckExist(frm) == true)
            {
                frm.Dispose();
                frm = null;
                return;
            }
            frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            frm.Show();
            frm.Dock = DockStyle.Fill;
        }

        private void pbDx_Click(object sender, EventArgs e)
        {
           
        }
        
        private void pbUnionS_Click(object sender, EventArgs e)
        {
            
        }

        private void pbConnSet_Click(object sender, EventArgs e)
        {
           
        }

        private void pbSize_Click(object sender, EventArgs e)
        {
            
        }

        private bool CheckExist(Form frm)
        {
            bool blResult = false;
            for (int i = 0; i < MdiChildren.Length; i++)
            {
                if (MdiChildren[i].GetType().Name == frm.GetType().Name)
                {
                    Form tmpFrm = MdiChildren[i];
                    if (tmpFrm.Text == frm.Text)
                    {
                        blResult = true;
                        tmpFrm.Activate();
                    }
                    else if (frm.Text == "")
                    {
                        blResult = true;
                        tmpFrm.Activate();
                    }
                    else if (frm.GetType().Name.ToLower() == "FmInfo")
                    {
                        blResult = true;
                        tmpFrm.Activate();
                    }
                }
            }
            return blResult;
        }
    }
}
