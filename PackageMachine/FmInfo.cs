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
using Functions;

namespace PackageMachine
{
    public partial class FmInfo : Form
    {
        public FmInfo()
        {
            
            InitializeComponent();
           // asfc.controllInitializeSize(this);
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
 
        private void FmInfo_Resize(object sender, EventArgs e)
        {
            CompSizeChanged();
            cs.Location = new Point(this.Width - cs.Width - 4, Height - cs.Height-4);
            cs2.Location = new Point(   4, Height - cs2.Height - 4);
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           
            BindBillInfo(x:Convert.ToInt32(textBox1.Text),y: Convert.ToInt32(textBox2.Text));
          
        }
        void BindBillInfo(int packageIndex = 0 , int x = 0 , int y = 0)
        {
           
            List<TobaccoInfo> list = br.GetTobaccoInfos(bill_s, packageIndex,cs.H);
            LabBind( );
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
        void CompSizeChanged()
        {
            //float width =  Width;
            //float height = Height;
        
            //panelInfo.Size = new Size(Width - 20, Convert.ToInt32(Height * 0.15) );
            //cs.Size = new Size(Convert.ToInt32(Width * ((float)cs.Height / width)), Convert.ToInt32( Height * ((float)cs.Height / height )));

            //cs2.Size = new Size(Convert.ToInt32(Width * ((float)cs2.Height / width)), Convert.ToInt32(Height * ((float)cs2.Height / height)));
            //btnLast.Location = new Point(cs.Location.X, cs.Location.Y + btnLast.Height + 10);
            //btnnext.Location = new Point(Width - cs.Location.X + btnLast.Width, Height - cs.Location.Y);
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
         void LabBind()
        {
                lbllinename.Text = "线路名称："   ;
                lblcutcount.Text = "总包号："  ;
                lblcutcount.Text = "客户包数" ;
            
           

        }
        /// <summary>
        /// 总体长度
        /// </summary>
        public decimal GetLeng { get => bill_s[0].PackageSeqLength;   }

        private void FmInfo_SizeChanged(object sender, EventArgs e)
        {
           
        }
    }
}
