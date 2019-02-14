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
    public partial class FmOrderInfo : Form
    {
        public FmOrderInfo()
        {
            InitializeComponent();
            //查询条件下拉框绑定值
            comboBox_QueryCriteria.DisplayMember ="";
            comboBox_QueryCriteria.ValueMember ="";
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            //string querystr = textBox_QueryText.Text;
            
        }
    }
}
