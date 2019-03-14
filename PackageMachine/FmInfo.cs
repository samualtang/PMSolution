using EFModle.Model;
using Functions;
using Functions.BLL;
using General;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
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
            ftd = new FmTaskDetail();
            Func += ChangeControlEnabled;
            handle += updateListBox;
            // AutoScroll = true; 
        }
        /// <summary>
        /// 取消按钮使用(传入1停用，传入2使用)
        /// </summary>
        public static Func<int,int> Func;
        //AutoSizeFormClass asfc = new AutoSizeFormClass();
        private void FmInfo_Load(object sender, EventArgs e)
        {
            cs.H = 450;
            cs.W = 540;
            Hrs += BindBillInfo;
           
         
            ft.Show(); 
            Loading.Masklayer(this, delegate () { LoadFucn(); }); 
        }

        /// <summary>
        /// 控制启用是否启用按钮
        /// </summary>
        /// <param name="flage">1是禁用，2是启用</param>
        /// <returns></returns>
        int ChangeControlEnabled(int flage)
        {
            if (flage == 1)
            {
                btnLast.Cursor = Cursors.No;
                btnnext.Cursor = Cursors.No;
                btnJump.Cursor = Cursors.No;
                btnRemake.Cursor = Cursors.No; 
                return 0;
            }
            else if (flage == 2) 
            {
                btnLast.Cursor = Cursors.Hand;
                btnnext.Cursor = Cursors.Hand;
                btnJump.Cursor = Cursors.Hand;
                btnRemake.Cursor = Cursors.Hand;
                return 0;
            }
            return 1;
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
        
          
        }

        private void btnJump_Click(object sender, EventArgs e)
        {
            if (btnLast.Cursor == Cursors.No)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                return;
            }
            if(Convert.ToInt32( textBox1.Text) > br.Length)
            {
                 pkIndex = br.Length;
                textBox1.Text = pkIndex.ToString();
            }
            pkIndex = Convert.ToInt32(textBox1.Text);
           BindBillInfo(packageIndex: pkIndex);
           
            //BindBillInfo(x:Convert.ToInt32(textBox1.Text),y: Convert.ToInt32(textBox2.Text));

        }
        /// <summary>
        /// 根据当前包装机，的整体包序，和条烟流水号获取数据显示到
        /// </summary>
        /// <param name="packageIndex"></param>
        /// <param name="CinNum"></param>
        void BindBillInfo(int packageIndex = 0 )
        { 
            List<TobaccoInfo> list = br.GetTobaccoInfos( packageIndex,cs.Height );
            if (list.Any())
            { 
                lblcutcode.Text = "任务流水号：" + list.FirstOrDefault().SortNum;
                lblcutcount.Text = "客户包数："+list.FirstOrDefault().PackgeSeq  +"/" + list.FirstOrDefault().OrderPackageQty;
                lblallcount.Text = "总 包 号:" + list.FirstOrDefault().GlobalIndex + "/" + br.Length; 
                cs.UpdateValue(list);
                LabBind();
            } 
        }
        void BindUInfo(int CinNum = 0)
        {
            List<TobaccoInfo> UN_list = br.GetUnNormallSort(CinNum);
            if (UN_list.Any())
            {
                cce1.UpdateValue(UN_list);
            } 
        }
    
        /// <summary>
        /// 索引
        /// </summary>
        int pkIndex = 1;
        private void btnLast_Click(object sender, EventArgs e)
        { 
            if(btnLast.Cursor == Cursors.No)
            {
                return;
            }
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
            WriteLog.GetLog().Write(Info);
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
            if (widthToCs > 500)
            {
                cs.Size = new Size(555, Convert.ToInt32(Height * 0.65));
            }
            else
            {
                cs.Size = new Size(widthToCs, Convert.ToInt32(Height * 0.65));
            }
            if (cs.Created)
            {
                BindBillInfo(packageIndex: pkIndex);
            }
            panel2.Height = (Height - panelInfo.Height - cs.Height) -20;
            panel3.Width = (Width - panel1.Width - cs.Width) - 20;
            gbInfo.Width = panel1.Width;
            cce1.Height = Convert.ToInt32(Width * 0.45); 
            cs.Location = new Point(this.Width - cs.Width - 4 - panel1.Width, Height - cs.Height - 4); 
        }
        private void btnnext_Click(object sender, EventArgs e)
        {
            if (btnLast.Cursor == Cursors.No)
            {
                return;
            }
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
            
            var list = br.GetTaskAllInfo();
            if (list.Any())
            {
                lblCigCount.Text = "卷烟总量："+ list.Distinct().Sum(a=> a.ORDERQTY)   ;
                lblNormalcOUNT.Text = "常规烟总量：" +list.Where(a=> a.CIGTYPE =="2" ) .Sum(a=> a.NORMALQTY) ;
                lblUnNormal.Text = "异型烟总量：" + list.Where(a => a.CIGTYPE == "1").Sum(a => a.NORMALQTY);
                lbFinsh.Text = "已包装数量：" + list.Distinct().Where(a => a.UNIONPACKAGETAG == 20).Count();
                lblNotFish.Text = "未包装数量：" + list.Distinct().Where(a => a.UNIONPACKAGETAG != 20).Count();

            } 
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
        public  static void AutoRefreshShow(int packageIndex, int cigNum)
        { 
            Hrs(packageIndex);   
        }
        delegate void HandeleRefrshShow(int p);
        static  HandeleRefrshShow Hrs;

        private void list_date_Click(object sender, EventArgs e)
        {
            if(ftd != null)
            {
                ftd.StartPosition = FormStartPosition.CenterScreen;
                ftd.Show();
            }
        }
        FmTaskLocate fmTask;
        private void btnRemake_Click(object sender, EventArgs e)
        {
            if (btnLast.Cursor == Cursors.No)
            {
                return;
            }
            if ( fmTask == null)
            {
                fmTask = new FmTaskLocate();
                fmTask.StartPosition = FormStartPosition.CenterScreen;
                fmTask.ShowDialog();
            }
            else
            {
                fmTask.StartPosition = FormStartPosition.CenterScreen;
                fmTask.ShowDialog();
            }

        }

        private void btnAuto_Click(object sender, EventArgs e)
        {

        }
    }
}
