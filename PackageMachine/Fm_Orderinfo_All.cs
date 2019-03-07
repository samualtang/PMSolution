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

using EFModle.Model;

namespace PackageMachine
{
    public partial class Fm_Orderinfo_All : Form
    {
        EFModle.Model.TaskList task = new EFModle.Model.TaskList();
        /// <summary>
        /// 整个订单数据
        /// </summary>
        List<EFModle.T_PACKAGE_TASK> data1 = new List<EFModle.T_PACKAGE_TASK>();

        /// <summary>
        /// 当前包序
        /// </summary>
        decimal SORTSEQ;
        /// <summary>
        /// 订单总包数
        /// </summary>
        decimal ORDERPACKAGEQTY;

        public Fm_Orderinfo_All()
        {
            //this.task = task;
            InitializeComponent();

            //ORDERPACKAGEQTY = task.ORDERPACKAGEQTY;
            //SORTSEQ = task.SORTSEQ;

            //label_sortnum.Text = "任务号：" + task.SORTNUM;
            //label_regioncode.Text = "车组号：" + task.REGIONCODE;
            //label_sortseq.Text = "户序：" + task.SORTSEQ.ToString();
            //label_customcode.Text = "专卖证号：" + task.CUSTOMERCODE;
            //label_packnum.Text = "总包数：" + task.ORDERPACKAGEQTY.ToString();
            //label_customername.Text = "客户名称：" + task.CUSTOMERNAME;
            //label_allpacksortnum.Text = "总条数：" + task.ALLQTY;
            //label_packageseq.Text = "当前第：" + task.SORTSEQ + "包";
            br = new BillResolution();
            //加载整个订单数据
            data1 = FmOrderInofFun.QueryBySortnum(task.SORTNUM);

        }
         
        /// <summary>
        /// 获取数据绑定 数据控件datagridview
        /// </summary>
        /// <param name="falg">操作类型：1上一包，2下一包，3第一包，4最后一包</param>
        public void getvalues(int falg)
        {
            switch (falg)
            {
                case 1:
                    //上一包
                    SORTSEQ--;
                    break;
                case 2:
                    //下一包
                    SORTSEQ++;
                    break;
                case 3:
                    //第一包
                    SORTSEQ = 1;
                    break;
                case 4:
                    //最后一包
                    SORTSEQ = ORDERPACKAGEQTY;
                    break;
            }
            //获取总包数
            if (SORTSEQ <= ORDERPACKAGEQTY && SORTSEQ > 0)
            {
                Dgv_datainfo.DataSource = data1.Where(x => x.PACKAGESEQ == SORTSEQ).OrderBy(x => x.CIGNUM).Select(x => new { x.CIGARETTENAME, x.CIGARETTECODE, x.CIGNUM });
                Dgv_datainfo.ColumnHeadersVisible = true;
                Dgv_datainfo.Columns[0].HeaderText = "卷烟名称";
                Dgv_datainfo.Columns[0].Width = 300;
                Dgv_datainfo.Columns[1].HeaderText = "卷烟编码";
                Dgv_datainfo.Columns[1].Width = 105;
                Dgv_datainfo.Columns[2].HeaderText = "条烟流水号";
                Dgv_datainfo.Columns[2].Width = 105;
            }
        }




        int pkIndex = 1;
        public decimal GetLeng
        {
            get => br.Length;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (pkIndex <= GetLeng)
            {
                pkIndex++;
                if (GetLeng >= pkIndex)
                {
                    BindBillInfo(pkIndex);
                }
                else
                {
                    pkIndex = int.Parse(GetLeng.ToString());
                    MessageBox.Show("已经是最后一个订单的了");
                }

            }
        }

        private void cigrShow1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pkIndex >= 1)
            {
                pkIndex--;
                if (pkIndex >= 1)
                {

                    BindBillInfo(packageIndex: pkIndex);
                }
                else
                {
                    pkIndex = 1;
                    MessageBox.Show("已经是第一个订单的了");
                }

            }
        }
        BillResolution br = null;
        void BindBillInfo(int packageIndex = 0, int CinNum = 0)
        {

            List<TobaccoInfo> list = br.GetTobaccoInfos(packageIndex, cigrShow1.Height); 
            cigrShow1.UpdateValue(list);
            label_sortnum.Text = "任务号："+list.Select(x => x.SortNum).FirstOrDefault().ToString();
            label_billcode.Text = "订单号："+list.Select(x => x.BillCode).FirstOrDefault();
            CustomerModle customerModles = br.GetCustomerInfos(list.Select(x => x.BillCode).FirstOrDefault());

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                pkIndex = int.Parse(textBox1.Text);
                BindBillInfo(pkIndex);
            }
        }

        private void Fm_Orderinfo_All_Load(object sender, EventArgs e)
        {
             
            pkIndex = 1;
            BindBillInfo(1); 
             
        }
    }

}

