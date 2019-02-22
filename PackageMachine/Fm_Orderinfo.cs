using Functions.BLL;
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
    public partial class Fm_Orderinfo : Form
    {
        EFModle.Model.TaskList task = new EFModle.Model.TaskList();
        public Fm_Orderinfo(EFModle.Model.TaskList task)
        {
            this.task = task;
            InitializeComponent();
            label_regioncode.Text = "车组号：" + task.REGIONCODE;
            label_sortseq.Text = "户序：" + task.SORTSEQ.ToString();
            label_customcode.Text = "专卖证号：" + task.CUSTOMERCODE;
            label_packnum.Text = "总包数："+task.ORDERPACKAGEQTY.ToString();
            label_customername.Text = "客户名称："+task.CUSTOMERNAME;
            label_allpacksortnum.Text = "总条数：" + task.ALLQTY;
        }
        private void Fm_Orderinfo_Load(object sender, EventArgs e)
        {
            
        }

        void ddd()
        {
             
            //cigrShow1.UpdateValue()
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //BillResolution dd = new BillResolution();
            //dd.GetTobaccoInfos()
        }

       
    }
}
