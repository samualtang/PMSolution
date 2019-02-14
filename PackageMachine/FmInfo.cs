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

namespace PackageMachine
{
    public partial class FmInfo : Form
    {
        public FmInfo()
        {
            
            InitializeComponent();
            //bill_s = br.GetBillInfos();//取出整个订单
            cs = new CigrShow();
            cs.W = 876;
            cs.H = 489;
            cs.Size = new Size(876, 489);
            this.Controls.Add(cs);
            func();
        }
        CigrShow cs; 
        List<Bill_Model> bill_s;
        BillResolution br = new BillResolution();
        void GetTobaccoCache(List<TobaccoInfo> tInfo)
        {
            List<TobaccoInfo> list = tInfo;
            float lastHeight = 0f;
            float lastWidth = 0f;
            float abc = 0f;
            foreach (var item in list)
            {
                item.PositionHeight = lastHeight + item.TobaccoHeight;
                item.PositionWidth = lastWidth + item.TobaccoWidth;
                lastHeight += item.TobaccoHeight;
                lastWidth += item.TobaccoWidth; 
                item.PositionHeightLast = item.PostionY; 
                item.PositionWidthLast =  item.PostionX ;
                if(item.OrderIndex >= 3)
                {
                    abc += item.TobaccoWidth;
                    item.PositionWidthLast = abc;
                }
                 
            }
            cs.UpdateValue(list); 
        }

        private void FmInfo_Resize(object sender, EventArgs e)
        {
            //btnLast.Location = new Point(Width - cs.Width - 20, btnLast.Location.Y);

            //btnnext.Location = new Point(Width - cs.Width - 20, btnnext.Location.Y);
            cs.Location = new Point(this.Width - cs.Width - 4, Height - cs.Height-4);
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           
            func(x:Convert.ToInt32(textBox1.Text),y: Convert.ToInt32(textBox2.Text));
          
        }
        void func(int packageIndex = 0 , int x = 0 , int y = 0)
        {
           
            List<TobaccoInfo> list = new List<TobaccoInfo>();
            //List<T_PACKAGE_TASK> t_s = br.GetTaskDetail(bill_s, packageIndex);
            //foreach (var item in t_s)
            //{
            //    TobaccoInfo info = new TobaccoInfo();
            //    info.TobaccoName = item.CIGARETTENAME;
            //    info.TobaccoLength = (float)Convert.ToDouble(item.CIGLENGTH);
            //    info.TobaccoWidth = (float)Convert.ToDouble(item.CIGWIDTH);
            //    info.TobaccoHeight = (float)Convert.ToDouble(item.CIGHIGH);
            //    info.GlobalIndex = Convert.ToInt32(item.CIGNUM ?? 0);
            //    info.Speed = 1;
            //    info.OrderIndex = Convert.ToInt32(item.PACKAGEQTY ?? 0);
            //    info.PostionX = (float)Convert.ToDouble(item.CIGWIDTHX ?? 0);//坐标X
            //    info.PostionY = cs.H - (float)Convert.ToDouble(item.CIGHIGHY ?? 0) - 9;//坐标Y
            //    list.Add(info);

            //}
            //for (int i = 0; i <2; i++)
            //{
            //    TobaccoInfo info = new TobaccoInfo();
            //    info.GlobalIndex = i + 1;
            //    info.OrderIndex = i + 1;
            //    info.TobaccoLength = 90;
            //    info.TobaccoWidth = 120;
            //    info.TobaccoHeight = 27;
            //    info.PostionX = info.TobaccoWidth     - x; //cs.H - info.PositionHeight;
            //    info.PostionY = cs.H - info.TobaccoHeight -9   - y;// cs.W - info.PositionWidth; 
            //    if (i % 2 == 0)
            //    {
            //        info.Speed = 1;
            //    }
            //    else
            //    {
            //        info.Speed = 1;
            //    }
            //    if( i == 1)
            //    {
            //        info.PostionX = info.TobaccoWidth - x - info.TobaccoWidth;
            //        info.PostionY = cs.H - info.TobaccoHeight - 9 - y - info.TobaccoHeight  ;
            //    }
            //    info.TobaccoName = "测试" + (i + 1);
            //    list.Add(info);
            //}

            GetTobaccoCache(list);
        }
        /// <summary>
        /// 索引
        /// </summary>
        int pkIndex = 0;
        private void btnLast_Click(object sender, EventArgs e)
        {
            if(bill_s.Count > 0 && pkIndex >= 0)
            {
                pkIndex--;
                if (pkIndex <= 0)
                {
                   
                    func(packageIndex: pkIndex);
                }
                else
                {
                    pkIndex = 0;
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
                    func(pkIndex);
                }
                else
                {
                    pkIndex =int.Parse( GetLeng.ToString());
                    MessageBox.Show("已经是最后一个订单的了");
                }
                
            }
        }
         
        /// <summary>
        /// 总体长度
        /// </summary>
        public decimal GetLeng { get => bill_s[0].PackageSeqLength;   }
    }
}
