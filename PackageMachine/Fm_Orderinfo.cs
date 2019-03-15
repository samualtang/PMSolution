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

using Functions.BLL;
using EFModle.Model;

namespace PackageMachine
{
    public partial class Fm_Orderinfo : Form
    {
        EFModle.Model.TaskList task = new EFModle.Model.TaskList();
        /// <summary>
        /// 整个订单数据
        /// </summary>
        List<EFModle.T_PACKAGE_TASK> data1 = new List<EFModle.T_PACKAGE_TASK>();
        /// <summary>
        /// 当前包序(整体)
        /// </summary>
        decimal SORTSEQ;
        /// <summary>
        /// 订单总包数
        /// </summary>
        decimal ORDERPACKAGEQTY;
        /// <summary>
        /// 订单内最大整体序号
        /// </summary>
        int MaxAllpackageseq;
        /// <summary>
        /// 订单内最小整体序号
        /// </summary>
        int MinAllpackageseq;

        public Fm_Orderinfo(EFModle.Model.TaskList task)
        {
            this.task = task;
            InitializeComponent();

            ORDERPACKAGEQTY = task.ORDERPACKAGEQTY;

            label_sortnum.Text = "任务号：" + task.SORTNUM;
            label_regioncode.Text = "车组号：" + task.REGIONCODE;
            label_sortseq.Text = "户序：" + task.SORTSEQ.ToString();
            label_customcode.Text = "专卖证号：" + task.CUSTOMERCODE;
            label_packnum.Text = "总包数：" + task.ORDERPACKAGEQTY.ToString();
            label_customername.Text = "客户名称：" + task.CUSTOMERNAME;
            label_allpacksortnum.Text = "总条数：" + task.ALLQTY;
            label_packageseq.Text = "当前订单内第：" + task.SORTSEQ + "包";

            //加载整个订单数据
            data1 = FmOrderInofFun.QueryBySortnum(task.SORTNUM);
            MaxAllpackageseq = (int)data1.Max(x => x.ALLPACKAGESEQ).Value;
            MinAllpackageseq = (int)data1.Min(x => x.ALLPACKAGESEQ).Value;
            SORTSEQ = MinAllpackageseq;

            label_allpackageseq.Text = "当前订单内第：" + MaxAllpackageseq + "包";
        }
        private void Fm_Orderinfo_Load(object sender, EventArgs e)
        {
            pkIndex = MinAllpackageseq;
            BindBillInfo(pkIndex);
            getvalues(3);
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
                    SORTSEQ = MinAllpackageseq;
                    break;
                case 4:
                    //最后一包
                    SORTSEQ = MaxAllpackageseq;
                    break;
            }
            //获取总包数
            if (SORTSEQ <= ORDERPACKAGEQTY && SORTSEQ > 0)
            {

                Dgv_datainfo.DataSource = data1.Where(x => x.ALLPACKAGESEQ == SORTSEQ).Select(x => new { x.CIGARETTENAME, x.CIGARETTECODE, x.CIGNUM, x.CIGTYPE, x.ALLPACKAGESEQ }).ToList();
                this.Dgv_datainfo.AutoGenerateColumns = true;
                //string sss = Dgv_datainfo.Columns.Count.ToString();
                //string rrr = Dgv_datainfo.Rows.Count.ToString();
                Dgv_datainfo.Columns[0].HeaderText = "卷烟名称";
                Dgv_datainfo.Columns[0].Width = 150;
                Dgv_datainfo.Columns[1].HeaderText = "卷烟编码";
                Dgv_datainfo.Columns[1].Width = 90;
                Dgv_datainfo.Columns[2].HeaderText = "条烟流水号";
                Dgv_datainfo.Columns[2].Width = 90;
                Dgv_datainfo.Columns[3].HeaderText = "条烟类型";
                Dgv_datainfo.Columns[3].Width = 80;
            }
        }




        int pkIndex = 1;
        public decimal GetLeng
        {
            get => br.Length;
        }


        private void cigrShow1_Load(object sender, EventArgs e)
        {

        }
        private void Dgv_datainfo_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }


        BillResolution br = new BillResolution();
        void BindBillInfo(int packageIndex = 0, int CinNum = 0)
        {

            List<TobaccoInfo> list = br.GetTobaccoInfos(packageIndex, cigrShow1.Height);
            cigrShow1.UpdateValue(list);
        }
        private void button_last_Click(object sender, EventArgs e)
        {
            if (pkIndex >= MinAllpackageseq)
            {
                if (pkIndex >= MinAllpackageseq)
                {
                    pkIndex --;
                    BindBillInfo(packageIndex: pkIndex);
                }
                else
                {
                    MessageBox.Show("已经是单内第一个订单了");
                }

            }
            getvalues(1);
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            if (pkIndex <= MaxAllpackageseq)
            {
                pkIndex++;
                if (MaxAllpackageseq >= pkIndex)
                {
                    BindBillInfo(pkIndex);
                    getvalues(2);
                }
                else
                {
                    pkIndex = MaxAllpackageseq;
                    MessageBox.Show("已经是订单内最后一包了");
                }
            }
        }

        private void button_skip_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                pkIndex = int.Parse(textBox1.Text) + MinAllpackageseq;
                if (pkIndex >= MinAllpackageseq && pkIndex <= MaxAllpackageseq)
                {
                    BindBillInfo(pkIndex);
                }
            }
        }

        private void button_top_Click(object sender, EventArgs e)
        {
            if (pkIndex > MinAllpackageseq)
            {
                pkIndex = MinAllpackageseq;
                BindBillInfo(pkIndex);
                getvalues(3);
            }
            else
            {
                MessageBox.Show("已经是订单内第一包了");
            }
        }

        private void button_end_Click(object sender, EventArgs e)
        {
            if (pkIndex < MaxAllpackageseq)
            {
                pkIndex = MaxAllpackageseq;
                BindBillInfo(pkIndex);
                getvalues(4);
            }
            else
            {
                MessageBox.Show("已经是订单内最后一包了");
            }

        }

        private void Dgv_datainfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (e.Value.ToString() =="2")
                {
                    e.Value = "异型烟";
                }
                else
                {
                    e.Value = "常规烟";
                }
            }
        }
    }

}
