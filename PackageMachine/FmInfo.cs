using EFModle.Model;
using Functions.BLL;
using General;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackageMachine
{
    public partial class FmInfo : Form
    {
        FmTest ft = new FmTest();
        public FmInfo()
        {
            
            InitializeComponent();
            cs.H = 450;
            cs.W = 540;
            Hrs += BindBillInfo;
            ftd = new FmTaskDetail();
            handle += updateListBox;
            ft.Show();
           // AutoScroll = true; 
        }
        //AutoSizeFormClass asfc = new AutoSizeFormClass();
        private void FmInfo_Load(object sender, EventArgs e)
        {

            //asfc.controllInitializeSize(this);
           // LoadFucn();
             Loading.Masklayer(this, delegate () { LoadFucn(); });

        }
        void LoadFucn()
        {
          //取出整个订单 
            BindBillInfo(packageIndex: 1);
           
        }
       
        BillResolution br = new BillResolution();
 
        private void FmInfo_Resize(object sender, EventArgs e)
        {
            CompSizeChanged();
            cce1.Height = Convert.ToInt32(Width * 0.45);
            //cs2.Location = new Point(   4, Height - cs2.Height - 4); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                return;
            }
            pkIndex = Convert.ToInt32(textBox1.Text);
           BindBillInfo(packageIndex: pkIndex);
           
            //BindBillInfo(x:Convert.ToInt32(textBox1.Text),y: Convert.ToInt32(textBox2.Text));

        }
        void BindBillInfo(int packageIndex = 0 ,int CinNum = 0  )
        {
           
            List<TobaccoInfo> list = br.GetTobaccoInfos( packageIndex,cs.Height );
            if( list!= null && list .Count > 0)
            {

          
            List<TobaccoInfo> UN_list = br.GetUnNormallSort( CinNum);
            lblcutcode.Text = "任务流水号：" + list.FirstOrDefault().SortNum;
             cce1.UpdateValue(UN_list);
            cs.UpdateValue(list);
    
            LabBind();
            }


        }
        /// <summary>
        /// 索引
        /// </summary>
        int pkIndex = 1;
        private void btnLast_Click(object sender, EventArgs e)
        {
            if(  pkIndex >= 1)
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

        #region   任务的信息 在主窗体显示
        FmTaskDetail ftd;
        delegate void HandleUpDate(string info);
        private delegate void HandleDelegate(string strshow);
        static HandleUpDate handle;
        public static void GetTaskInfo(string Info)
        {

            // FmTaskDetail.GetTaskInfo_Detail(Info);
            handle(Info);
        }
        //void upDateList(string info)
        //{

        //    updateListBox(info);
        //}

        public void updateListBox(string info)
        {
            String time = DateTime.Now.ToLongTimeString();

            if (this.list_date.InvokeRequired)
            {

                this.list_date.Invoke(new HandleDelegate(updateListBox), info);
            }
            else
            {
                ftd.updateListBox(info);
                this.list_date.Items.Insert(0, time + "    " + info);

            }
        }
        #endregion
        void CompSizeChanged()
        {
            float width =  Width;
            float height = Height;
        
            //panelInfo.Size = new Size(Width - 20, Convert.ToInt32(Height * 0.15) );

            int widthToCs = Convert.ToInt32(Width * (0.5));
            if( widthToCs > 500)
            {
                cs.Size = new Size(520, Convert.ToInt32(Height * 0.65));
            }
            else
            {
                cs.Size = new Size(widthToCs, Convert.ToInt32(Height * 0.65));
            }
            if(cs.Created)
            {
                BindBillInfo(packageIndex: pkIndex);
            }
            panel2.Height = (Height - panelInfo.Height - cs.Height) -20;
            panel3.Width = (Width - panel1.Width - cs.Width) - 20;
            gbInfo.Width = panel1.Width;
            //cce1.Size = new Size(Convert.ToInt32(Width * 0.1), Convert.ToInt32(Height * 0.80));
            //cce1.Top = panelInfo.Height + 40; 
            //lblCache.Top = panelInfo.Height+20;
            cs.Location = new Point(this.Width - cs.Width - 4 - panel1.Width, Height - cs.Height - 4);
            
            //cs2.Size = new Size(Convert.ToInt32(Width * ((float)cs2.Height / width)), Convert.ToInt32(Height * ((float)cs2.Height / height)));
            //btnLast.Location = new Point(cs.Location.X, cs.Location.Y + btnLast.Height + 10);
            //btnnext.Location = new Point(Width - cs.Location.X + btnLast.Width, Height - cs.Location.Y); 
        }
        private void btnnext_Click(object sender, EventArgs e)
        {
            
            if (  pkIndex <= GetLeng)
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
        public decimal GetLeng
        {

            get => br.Length;
            //{
                
                //if (bill_s.Count == 0) return 1; else { return bill_s[0].PackageSeqLength; };
            //}
        }

        private void FmInfo_SizeChanged(object sender, EventArgs e)
        {
         
            //asfc.controlAutoSize(this);
        }
        /// <summary>
        /// 自动更新跺
        /// </summary>
        /// <param name="packageIndex"></param>
        /// <param name="cigNum"></param>
        public async static void AutoRefreshShow(int packageIndex, int cigNum)
        {
           
            Hrs(packageIndex, cigNum);
            await Task.Delay(0);  
        }
        delegate void HandeleRefrshShow(int p, int c);
        static  HandeleRefrshShow Hrs;

        private void list_date_Click(object sender, EventArgs e)
        {
            if(ftd != null)
            {
                ftd.StartPosition = FormStartPosition.CenterScreen;
                ftd.Show();
            }
        }
    }
}
