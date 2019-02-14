using EFModle.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFModle;
using Functions.BLL;
using General;

namespace PackageMachine
{
    public partial class FmInfo : Form
    {
        public FmInfo()
        {
            
            InitializeComponent();
           
        }
        private void FmInfo_Load(object sender, EventArgs e)
        { 
            Loading.Masklayer(this, delegate () { LoadFucn(); });
        }
        void LoadFucn()
        {
            bill_s = br.GetBillInfos();//取出整个订单 
            BindBillInfo(packageIndex: 1);
        }
        List<Bill_Model> bill_s;
        BillResolution br = new BillResolution();
        //void GetTobaccoCache(List<TobaccoInfo> tInfo)
        //{
        //    List<TobaccoInfo> list = tInfo;
        //    //float lastHeight = 0f;
        //    //float lastWidth = 0f;
        //    //float abc = 0f;
        //    foreach (var item in list)
        //    {
        //        //item.PositionHeight = lastHeight + item.TobaccoHeight;
        //        //item.PositionWidth = lastWidth + item.TobaccoWidth;
        //        //lastHeight += item.TobaccoHeight;
        //        //lastWidth += item.TobaccoWidth; 
        //        item.PositionHeightLast = item.PostionY; 
        //        item.PositionWidthLast =  item.PostionX ; 
                 
        //    }
        //    cs.UpdateValue(list); 
        //}

        private void FmInfo_Resize(object sender, EventArgs e)
        { 
             cs.Location = new Point(this.Width - cs.Width - 4, Height - cs.Height-4);
            cs2.Location = new Point(   4, Height - cs2.Height - 4);

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           
            BindBillInfo(x:Convert.ToInt32(textBox1.Text),y: Convert.ToInt32(textBox2.Text));
          
        }
        void BindBillInfo(int packageIndex = 0 , int x = 0 , int y = 0)
        {
           
            List<TobaccoInfo> list = new List<TobaccoInfo>();
            List<T_PACKAGE_TASK> t_s = br.GetTaskDetail(bill_s, packageIndex);
            foreach (var item in t_s)
            {
                TobaccoInfo info = new TobaccoInfo();
                info.TobaccoName = item.CIGARETTENAME;
                info.TobaccoLength = (float)Convert.ToDouble(item.CIGLENGTH);
                info.TobaccoWidth = (float)Convert.ToDouble(item.CIGWIDTH);
                info.TobaccoHeight = (float)Convert.ToDouble(item.CIGHIGH);
                info.GlobalIndex = Convert.ToInt32(item.CIGNUM ?? 0);
                info.Speed = 1;
                info.OrderIndex = Convert.ToInt32(item.PACKAGEQTY ?? 0);
                info.PostionX = (float)Convert.ToDouble(item.CIGWIDTHX ?? 0)  ;//坐标X
                info.PostionY = cs.H - (float)Convert.ToDouble(item.CIGHIGHY ?? 0)   ;//坐标Y 
                list.Add(info); 
            }
            LabBind(t_s);
            cs.UpdateValue(list);
            
        }
        /// <summary>
        /// 索引
        /// </summary>
        int pkIndex = 1;
        private void btnLast_Click(object sender, EventArgs e)
        {
            if(bill_s.Count > 0 && pkIndex >= 1)
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

        private void btnnext_Click(object sender, EventArgs e)
        {
            if (bill_s.Count > 0 && pkIndex <= GetLeng)
            {
                pkIndex++;
                if (GetLeng  >= pkIndex )
                { 
                    BindBillInfo(pkIndex);
                }
                else
                {
                    pkIndex =int.Parse( GetLeng.ToString());
                    MessageBox.Show("已经是最后一个订单的了");
                }
               
            }
        }
         void LabBind(List<T_PACKAGE_TASK> t_s)
        {
            foreach (var item in t_s)
            {
                lbllinename.Text = "线路名称："   ;
                lblcutcount.Text = "总包号：" + item.ALLPACKAGESEQ;
                lblcutcount.Text = "客户包数" +item.ORDERPACKAGEQTY +"-"+ item.PACKAGESEQ;
            
            }

        }
        /// <summary>
        /// 总体长度
        /// </summary>
        public decimal GetLeng { get => bill_s[0].PackageSeqLength;   }

   
    }
}
