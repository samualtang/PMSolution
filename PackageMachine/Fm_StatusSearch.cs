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
    public partial class Fm_StatusSearch : Form
    {
        public Fm_StatusSearch()
        {
            InitializeComponent();
        }

        
        private void btn_search_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text.ToString();
            int values = 10;
            switch (cmb_status.SelectedIndex)
            {
                case 1:
                    values = vs1mer[0];
                    break;
                case 2:
                    values = vs1mer[1];
                    break;
                case 3:
                    values = vs1mer[2];
                    break;
                default:
                    break;
            }
            List<EFModle.Model.StatusModel> list = new List<EFModle.Model.StatusModel>();
            switch (cmb_type.SelectedIndex)
            {
                case 1:
                    list = Functions.BLL.DataStatusSearch.GetJQRTask(str,values);
                    break;
                case 2:
                    list = Functions.BLL.DataStatusSearch.GetBSLTask(str,values);
                    break;
                case 3:
                    list = Functions.BLL.DataStatusSearch.GetFBTask(str,values);
                    break;
                default:
                    list = Functions.BLL.DataStatusSearch.GetDefultTask(str);
                    break;
            }
            EFModle.Entities et = new EFModle.Entities();
            dataGridView1.DataSource = list;

            

        } 

        private static List<string> vs1dis = new List<string> { "全部","新增", "已发送", "已完成" };
        private static List<int> vs1mer = new List<int> { 10, 15, 20 };
        private static List<string> vs2dis = new List<string> { "全部","机器人", "倍速链", "翻版机" };
        private static List<int> vs2mer = new List<int> { 1, 2, 3 };


        private void Fm_StatusSearch_Load(object sender, EventArgs e)
        {
            cmb_type.DataSource = vs2dis;
            cmb_status.DataSource = vs1dis;
        } 
    }
}
