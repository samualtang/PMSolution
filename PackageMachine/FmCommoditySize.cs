using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFModle.Model;
using Functions.BLL;

namespace PackageMachine
{
    public partial class FmCommoditySize : Form
    {
        public FmCommoditySize()
        {
            InitializeComponent();
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            databinging();
        }
        void databinging()
        {
            DGV_OrderInfo.ColumnHeadersVisible = true;
            DGV_OrderInfo.RowHeadersVisible = false;

            DGV_OrderInfo.DataSource = FmCommoditySizeFun.Commodity(textBox_QueryText.Text);
             
            DGV_OrderInfo.Columns[0].HeaderText = "品牌名称";
            DGV_OrderInfo.Columns[0].Width = 180;
            DGV_OrderInfo.Columns[1].HeaderText = "品牌编码";
            DGV_OrderInfo.Columns[1].Width = 100;
            DGV_OrderInfo.Columns[2].HeaderText = "高度";
            DGV_OrderInfo.Columns[2].Width = 60;
            DGV_OrderInfo.Columns[3].HeaderText = "宽度";
            DGV_OrderInfo.Columns[3].Width = 60;
            DGV_OrderInfo.Columns[4].HeaderText = "长度";
            DGV_OrderInfo.Columns[4].Width = 60;
            DGV_OrderInfo.Columns[5].HeaderText = "双抓";
            DGV_OrderInfo.Columns[5].Width = 60;
            DGV_OrderInfo.Columns[6].HeaderText = "横放";
            DGV_OrderInfo.Columns[6].Width = 60;

            TextboxDataClear();
        }
      

        private void btn_update_Click(object sender, EventArgs e)
        {
            CommoditySize commoditySize = new CommoditySize();
            commoditySize.ITEMNO = txt_code.Text;
            commoditySize.ITEMNAME = txt_name.Text;
            try
            {
                commoditySize.ILENGTH = Convert.ToDecimal(txt_lenght.Text);
                commoditySize.IWIDTH = Convert.ToDecimal(txt_weight.Text);
                commoditySize.IHEIGHT = Convert.ToDecimal(txt_height.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确格式的长、宽、高！");
                return;
            }
            switch ( comboBox_cdtype.SelectedIndex)
            {
                case 0:
                    commoditySize.CDTYPE = 0;
                    break;
                case 1:
                    commoditySize.CDTYPE = 1;
                    break;
                default:
                    commoditySize.CDTYPE = 0;
                    break;
            }
            switch (comboBox_doubletask.SelectedIndex)
            {
                case 0:
                    commoditySize.DOUBLETAKE = "0";
                    break;
                case 1:
                    commoditySize.DOUBLETAKE = "1";
                    break;
                default:
                    commoditySize.DOUBLETAKE = "";
                    break;
            }
            DialogResult result = MessageBox.Show("确认修改" + commoditySize.ITEMNAME + "的尺寸信息？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            string str = FmCommoditySizeFun.UpdateCommodity(commoditySize) == true ? "更新成功！" : "更新失败！";
            MessageBox.Show(str);
            databinging();
        }

        private void TextboxDataClear()
        {
            txt_code.Text = null;
            txt_height.Text = null;
            txt_lenght.Text = null;
            txt_name.Text = null;
            txt_weight.Text = null;
        }

        private void DGV_OrderInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( e.RowIndex > -1 )
            {
                txt_name.Text = DGV_OrderInfo.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_code.Text = DGV_OrderInfo.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_lenght.Text = DGV_OrderInfo.Rows[e.RowIndex].Cells[4].Value.ToString();
                txt_weight.Text = DGV_OrderInfo.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_height.Text = DGV_OrderInfo.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBox_doubletask.Items.Clear();
                comboBox_doubletask.Items.AddRange(FmCommoditySizeFun.doubletasklist());
                comboBox_cdtype.Items.Clear();
                comboBox_cdtype.Items.AddRange(FmCommoditySizeFun.HFtasklist());

                if (DGV_OrderInfo.Rows[e.RowIndex].Cells[5].Value == null)
                {
                    comboBox_doubletask.SelectedIndex = 0;
                }
                else
                {
                    switch (DGV_OrderInfo.Rows[e.RowIndex].Cells[5].Value.ToString())
                    {
                        case "0":
                            comboBox_doubletask.SelectedIndex = 0;
                            break;
                        case "1":
                            comboBox_doubletask.SelectedIndex = 1;
                            break;
                        default:
                            MessageBox.Show("选取超出索引！");
                            break;
                    }
                }
                if (DGV_OrderInfo.Rows[e.RowIndex].Cells[6].Value == null)
                {
                    comboBox_cdtype.SelectedIndex = 0;
                }
                else
                {
                    switch (DGV_OrderInfo.Rows[e.RowIndex].Cells[6].Value.ToString())
                    {
                        case "0":
                            comboBox_cdtype.SelectedIndex = 0;
                            break;
                        case "1":
                            comboBox_cdtype.SelectedIndex = 1;
                            break;
                        default:
                            MessageBox.Show("选取超出索引！");
                            break;
                    }
                }
            }
            
        }

        private void DGV_OrderInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                e.Value = Convert.ToInt32(e.Value) == 1 ? "双抓" : "";
            }
            if (e.ColumnIndex == 6)
            {
                e.Value = Convert.ToInt32(e.Value) == 1 ? "横放" : "";
            }
        }
    }
}
