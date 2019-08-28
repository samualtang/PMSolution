using EFModle.Model;
using Functions.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

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

        int pkIndex = 1;
        public Fm_Orderinfo(EFModle.Model.TaskList task)
        {
            this.task = task;
            InitializeComponent();
            br = new BillResolution(cigrShow1.Size);
            ORDERPACKAGEQTY = task.ORDERPACKAGEQTY;
            
            label_sortnum.Text = "任务号：" + task.SORTNUM;
            label_regioncode.Text = "车组号：" + task.REGIONCODE;
            label_sortseq.Text = "户序：" + task.SORTSEQ.ToString();
            label_customcode.Text = "专卖证号：" + task.CUSTOMERCODE;
            label_packnum.Text = "总包数：" + task.ORDERPACKAGEQTY.ToString();
            label_customername.Text = "客户名称：" + task.CUSTOMERNAME;
            label_allpacksortnum.Text = "总条数：" + task.ALLQTY;
            label_packageseq.Text = "当前订单第：1包"; 

             //加载整个订单数据
             data1 = FmOrderInofFun.QueryBySortnum(task.SORTNUM);
            MaxAllpackageseq = (int)data1.Max(x => x.ALLPACKAGESEQ).Value;
            MinAllpackageseq = (int)data1.Min(x => x.ALLPACKAGESEQ).Value;
            
            label_allpackageseq.Text = "当前包装机共：" + br.Length + "包";
            label_nowpackageseq.Text = "当前包装机第：" + MinAllpackageseq + "包";

            decimal PACKAGENUM = (decimal)data1.Where(x => x.ALLPACKAGESEQ == MinAllpackageseq).Select(x => x.PACKTASKNUM).FirstOrDefault();
            label_packagetasknum.Text = "包装机任务号：" + PACKAGENUM.ToString();
        }

        BillResolution br;
        private void Fm_Orderinfo_Load(object sender, EventArgs e)
        {
            pkIndex = MinAllpackageseq;
            BindBillInfo(pkIndex);
            GetValues();
            labelChange();
        }
        /// <summary>
        /// DataType： GetValues类型 整包1  /常规2  /异型3  /整个订单4
        /// </summary>
        int DataType = 1;
        /// <summary>
        /// 获取数据绑定 数据控件datagridview 
        /// </summary>
        public void GetValues(bool tag = false)
        {
            if (tag)
            {
                return;
            }
            SORTSEQ = pkIndex;
            //获最大包数 最小包数
            if (SORTSEQ <= MaxAllpackageseq && SORTSEQ >= MinAllpackageseq)
            {
                switch (DataType)
                {
                    case 1:
                        Dgv_datainfo.DataSource = data1.Where(x => x.ALLPACKAGESEQ == SORTSEQ).OrderBy(x => x.CIGNUM).Select(x => new { x.CIGARETTENAME, x.CIGARETTECODE, CIGTYPE = x.CIGTYPE == "1" ? "常规烟" : "异型烟", x.NORMALQTY, x.PACKAGESEQ }).ToList();
                        break;
                    case 2:
                        Dgv_datainfo.DataSource = data1.Where(x => x.ALLPACKAGESEQ == SORTSEQ && x.CIGTYPE == "1").OrderBy(x => x.CIGNUM).Select(x => new { x.CIGARETTENAME, x.CIGARETTECODE, CIGTYPE = x.CIGTYPE == "1" ? "常规烟" : "异型烟", x.NORMALQTY, x.PACKAGESEQ }).ToList();
                        break;
                    case 3:
                        Dgv_datainfo.DataSource = data1.Where(x => x.ALLPACKAGESEQ == SORTSEQ && x.CIGTYPE == "2").OrderBy(x => x.CIGNUM).Select(x => new { x.CIGARETTENAME, x.CIGARETTECODE, CIGTYPE = x.CIGTYPE == "1" ? "常规烟" : "异型烟", x.NORMALQTY, x.PACKAGESEQ }).ToList();
                        break;
                    case 4:
                        Dgv_datainfo.DataSource = data1.OrderBy(x => x.PACKTASKNUM).ThenBy(x=>x.CIGNUM).Select(x => new { x.CIGARETTENAME, x.CIGARETTECODE, CIGTYPE = x.CIGTYPE == "1" ? "常规烟" : "异型烟" , x.NORMALQTY, x.PACKAGESEQ }).ToList();
                        break;
                    default:
                        break;
                }

                this.Dgv_datainfo.AutoGenerateColumns = true;
                Dgv_datainfo.Columns[0].HeaderText = "卷烟名称";
                Dgv_datainfo.Columns[0].Width = 150;
                Dgv_datainfo.Columns[1].HeaderText = "卷烟编码";
                Dgv_datainfo.Columns[1].Width = 90;
                Dgv_datainfo.Columns[2].HeaderText = "条烟类型";
                Dgv_datainfo.Columns[2].Width = 90;
                Dgv_datainfo.Columns[3].HeaderText = "烟条数";
                Dgv_datainfo.Columns[3].Width = 80;
                Dgv_datainfo.Columns[4].HeaderText = "包序号";
                Dgv_datainfo.Columns[4].Width = 80;
            }
            label_allcig.Text = "共"+data1.Where(x => x.ALLPACKAGESEQ == pkIndex).Select(x => x.PACKAGEQTY).FirstOrDefault() + "条烟";
            label_packagetasknum.Text = "包装机任务号：" + data1.Where(x => x.ALLPACKAGESEQ == pkIndex).Select(x => x.PACKTASKNUM).FirstOrDefault();
        }
        /// <summary>
        /// 获取数据绑定 数据控件datagridview
        /// </summary>
        public void GetValuesAll()
        {
            SORTSEQ = pkIndex;
            //获最大包数 最小包数
            if (SORTSEQ <= MaxAllpackageseq && SORTSEQ >= MinAllpackageseq)
            {

                Dgv_datainfo.DataSource = data1.Where(x => x.ALLPACKAGESEQ == SORTSEQ).Select(x => new { x.CIGARETTENAME, x.CIGARETTECODE, x.CIGTYPE, x.NORMALQTY, x.PACKAGESEQ }).ToList();
                this.Dgv_datainfo.AutoGenerateColumns = true;
                //string sss = Dgv_datainfo.Columns.Count.ToString();
                //string rrr = Dgv_datainfo.Rows.Count.ToString();
                Dgv_datainfo.Columns[0].HeaderText = "卷烟名称";
                Dgv_datainfo.Columns[0].Width = 150;
                Dgv_datainfo.Columns[1].HeaderText = "卷烟编码";
                Dgv_datainfo.Columns[1].Width = 90;
                Dgv_datainfo.Columns[2].HeaderText = "条烟类型";
                Dgv_datainfo.Columns[2].Width = 90;
                Dgv_datainfo.Columns[3].HeaderText = "烟条数";
                Dgv_datainfo.Columns[3].Width = 80;
                Dgv_datainfo.Columns[4].HeaderText = "包序号";
                Dgv_datainfo.Columns[4].Width = 80;
            }
            label_allcig.Text = data1.Where(x => x.ALLPACKAGESEQ == pkIndex).Select(x => x.PACKAGEQTY).FirstOrDefault() + "条烟";
        }


        private void cigrShow1_Load(object sender, EventArgs e)
        {

        }
        private void Dgv_datainfo_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }


        void BindBillInfo(int packageIndex = 0, int CinNum = 0)
        {

            List<TobaccoInfo> list = br.GetTobaccoInfoss(packageIndex, cigrShow1.Height);
            cigrShow1.UpdateValue(list);
        }
        private void button_last_Click(object sender, EventArgs e)
        {
            if (pkIndex >= MinAllpackageseq)
            {
                if (pkIndex > MinAllpackageseq)
                {
                    pkIndex --;
                    BindBillInfo(packageIndex: pkIndex);
                    if (checkBox_display.Checked)
                    {
                        GetValues(true);
                    }
                    else
                    {
                        GetValues();
                    }
                    labelChange();
                }
                else
                {
                    MessageBox.Show("已经是单内第一个订单了");
                }

            }
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            if (pkIndex <= MaxAllpackageseq)
            {
                pkIndex++;
                if (MaxAllpackageseq >= pkIndex)
                {
                    BindBillInfo(pkIndex);
                    if (checkBox_display.Checked)
                    {
                        GetValues(true);
                    }
                    else
                    {
                        GetValues();
                    }
                    labelChange();
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
                try
                {
                    pkIndex = int.Parse(textBox1.Text) + MinAllpackageseq - 1;//订单内包序处理为包装机整体包序
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (pkIndex >= MinAllpackageseq && pkIndex <= MaxAllpackageseq)//如果在订单内的包序
                {
                    BindBillInfo(pkIndex);
                    labelChange();
                }
                else if (pkIndex < MinAllpackageseq)//如果小于订单内的包序
                {
                    textBox1.Text = "1";
                    pkIndex = MinAllpackageseq;
                    BindBillInfo(pkIndex);
                    labelChange();
                }
                else if (pkIndex > MaxAllpackageseq)//如果大于订单内的包序
                {
                    textBox1.Text = (MaxAllpackageseq - MinAllpackageseq + 1).ToString();
                    pkIndex = MaxAllpackageseq;
                    BindBillInfo(pkIndex);
                    labelChange();
                }
            }
        }

        private void button_top_Click(object sender, EventArgs e)
        {
            if (pkIndex > MinAllpackageseq)
            {
                pkIndex = MinAllpackageseq;
                BindBillInfo(pkIndex);
                if (checkBox_display.Checked)
                    {
                        GetValues(true);
                    }
                    else
                    {
                        GetValues();
                    }
                labelChange();
            }
            else
            {
                MessageBox.Show("已经是订单内第一包了");
            }
        }
        /// <summary>
        /// 界面label控件数据刷新
        /// </summary>
        void labelChange()
        {
            label_nowpackageseq.Text = "当前包装机第：" + pkIndex + "包";
            label_packageseq.Text = "当前订单第：" + (pkIndex - MinAllpackageseq + 1) + "包";
            label_normul.Text = "常规烟：" + data1.Where(x => x.ALLPACKAGESEQ == pkIndex && x.CIGTYPE == "1").Sum(x => x.NORMALQTY).ToString();
            label_unnormul.Text = "异型烟：" + data1.Where(x => x.ALLPACKAGESEQ == pkIndex && x.CIGTYPE == "2").Sum(x => x.NORMALQTY).ToString();
        }

        private void button_end_Click(object sender, EventArgs e)
        {
            if (pkIndex < MaxAllpackageseq)
            {
                pkIndex = MaxAllpackageseq;
                BindBillInfo(pkIndex);
                if (checkBox_display.Checked)
                {
                    GetValues(true);
                }
                else
                {
                    GetValues();
                }
                labelChange();
            }
            else
            {
                MessageBox.Show("已经是订单内最后一包了");
            }

        }
        
        private void checkBox_display_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_display.Checked)
            {
                DataType = 4;
                GetValues();
                radioButton_all.Checked = true;
            }
            else
            {
                DataType = 1;
                GetValues();
            }
        }

        private void radioButton_cgy_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_cgy.Checked)
            {
                DataType = 2;
                checkBox_display.Checked = false;
                GetValues();
            }
        }
        private void radioButton_yxy_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_yxy.Checked)
            {
                DataType = 3;
                checkBox_display.Checked = false;
                GetValues();
            }
        }
        private void radioButton_all_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_all.Checked)
            {
                DataType = 1;
                GetValues();
            }
        }
    }

}
