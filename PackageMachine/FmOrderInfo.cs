using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Functions.BLL;
using Functions.FormDataModle;

namespace PackageMachine
{
    public partial class FmOrderInfo : Form
    {
        public FmOrderInfo()
        {
            InitializeComponent();

            DataBind();
        }

        int packageno;
        EFModle.Model.TaskList task = null;

        public void DataBind()
        {
            comboBox_QueryCriteria.DataSource = FmOrderInfoFunCmbox.TitleList();
            //查询条件下拉框绑定值
            comboBox_QueryCriteria.DisplayMember = "title";
            comboBox_QueryCriteria.ValueMember = "content";
            try
            {
                packageno = Convert.ToInt32(ConfigurationManager.ConnectionStrings["packageno"]);
            }
            catch (Exception)
            { 
                throw;
            }
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            task = null;
            task = new EFModle.Model.TaskList();
            DGV_OrderInfo.DataSource = null;
            DGV_OrderInfo.DataSource = FmOrderInofFun.QueryTaskList(comboBox_QueryCriteria.SelectedValue.ToString(),textBox_QueryText.Text, packageno);

            DGV_OrderInfo.ColumnHeadersVisible = true;
            DGV_OrderInfo.Columns[0].HeaderText = "任务号";
            DGV_OrderInfo.Columns[0].Width = 70;
            DGV_OrderInfo.Columns[1].HeaderText = "客户名称";
            DGV_OrderInfo.Columns[1].Width = 280;
            DGV_OrderInfo.Columns[2].HeaderText = "专卖证号";
            DGV_OrderInfo.Columns[2].Width = 105;
            DGV_OrderInfo.Columns[3].HeaderText = "车组号";
            DGV_OrderInfo.Columns[3].Width = 70;
            DGV_OrderInfo.Columns[4].HeaderText = "户 序";
            DGV_OrderInfo.Columns[4].Width = 60;
            DGV_OrderInfo.Columns[5].HeaderText = "订单总包数";
            DGV_OrderInfo.Columns[5].Width = 95;
            DGV_OrderInfo.Columns[6].HeaderText = "订单总烟量";
            DGV_OrderInfo.Columns[6].Width = 95;
            DGV_OrderInfo.Columns[7].Visible = false;
            DGV_OrderInfo.Columns[8].Visible = false;
            DGV_OrderInfo.ClearSelection();
        }

        private void 查看明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void contextMenuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
             
        }
         
    
        private void DGV_OrderInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                task.REGIONCODE = DGV_OrderInfo.Rows[e.RowIndex].Cells[3].Value.ToString();
                task.CUSTOMERCODE = DGV_OrderInfo.Rows[e.RowIndex].Cells[2].Value.ToString();
                task.CUSTOMERNAME = DGV_OrderInfo.Rows[e.RowIndex].Cells[1].Value.ToString();
                task.SORTSEQ = Convert.ToDecimal(DGV_OrderInfo.Rows[e.RowIndex].Cells[4].Value.ToString());
                task.ORDERPACKAGEQTY = Convert.ToDecimal(DGV_OrderInfo.Rows[e.RowIndex].Cells[5].Value.ToString());
                task.ALLQTY = Convert.ToDecimal(DGV_OrderInfo.Rows[e.RowIndex].Cells[6].Value.ToString());
                task.SORTNUM = Convert.ToDecimal(DGV_OrderInfo.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            
        }

        private void DGV_OrderInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (task==null)
            {
                MessageBox.Show("请点击数据区域！");
                return;
            }
            if (task.CUSTOMERNAME == null)
            {
                MessageBox.Show("请选择订单！");
                return;
            }
            Fm_Orderinfo fm = new Fm_Orderinfo(task);
            fm.Show();
        }
    }
}
