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
    public partial class FmCacheDetail : Form
    {
        public FmCacheDetail(List<TobaccoInfo> list)
        {
            InitializeComponent();
            List_Info = list;
            StartPosition = FormStartPosition.CenterScreen;
        }
        public FmCacheDetail()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        List<EFModle.Model.TobaccoInfo> List_Info = new List<TobaccoInfo>();

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void FmCacheDetail_Load(object sender, EventArgs e)
        {
            foreach (var item in List_Info)
            {
                lb_Wait.Items.Add(item.GlobalIndex + "." + item.OrderIndex + "." + item.TobaccoName);
            }
        }
    }
}
