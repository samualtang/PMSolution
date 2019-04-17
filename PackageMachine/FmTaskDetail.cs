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
    public partial class FmTaskDetail : Form
    {
        public FmTaskDetail()
        {
            InitializeComponent();
            handle += GetTaskInfo_Detail;
            cbIsorNo.Checked = true;
            this.TopMost = true;
        }
      
      
        private void FmTaskDetail_Load(object sender, EventArgs e)
        {
 
        }


        delegate void HandleUpDate(string info);
        private delegate void HandleDelegate(string strshow);
        static HandleUpDate handle;
        public static void GetTaskInfo_Detail(string Info)
        {
            handle(Info);
        }
        public void updateListBox(string info)
        {
            String time = DateTime.Now.ToLongTimeString();

            if (this.list_date.InvokeRequired)
            {

                this.list_date.Invoke(new HandleDelegate(updateListBox), info);
            }
            else
            {
                this.list_date.Items.Insert(0, time + "    " + info);

            }
        }

        private void FmTaskDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true ;
            return;
        }

        private void FmTaskDetail_Resize(object sender, EventArgs e)
        {
            list_date.Height = (int)( this.Height * 0.8);
        }

        private void cbIsorNo_Click(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                TopMost = false;
            }
        }

        private void cbBsl_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
