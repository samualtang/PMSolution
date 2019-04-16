using EFModle.Model;
using Functions;
using Functions.BLL;
using Functions.Model;
using Functions.PubFunction;
using General;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Group = Functions.Model.Group;

namespace PackageMachine
{
    public partial class FmInfo : Form
    {
        //FmTest ft = new FmTest();
        public FmInfo()
        {

            InitializeComponent();
            ftd = new FmTaskDetail();
            Func += ChangeControlEnabled;
            handle += updateListBox;
            GetGroup = GetOpcServerGroup;
            GetFinshiTask = MoveQueueElem;
            listBtn.Add(btngw7);
            listBtn.Add(btngw6);
            listBtn.Add(btngw5);
            listBtn.Add(btngw4);
            listBtn.Add(btngw3);
            listBtn.Add(btngw2);
            listBtn.Add(btngw1);

            // AutoScroll = true; 
        }
        /// <summary>
        /// OPC服务器
        /// </summary> 
        Group opcGroup, opcGroup7, opcFinshGroup;
        /// <summary>
        /// 常规烟翻版任务号
        /// </summary>
        public static decimal FbPackageNum { get; set; }
        /// <summary>
        /// 获取OPC组
        /// </summary>
        public static Func<Group, Group, Group, int> GetGroup;

        public static Func<decimal, int> GetFinshiTask;
        /// <summary>
        /// 取消按钮使用(传入1停用，传入2使用)
        /// </summary>
        public static Func<int, int> Func;
        /// <summary>
        /// 存入缓存工位的包号
        /// </summary>
        Queue queue = new Queue(7);
        /// <summary>
        /// 界面工位按钮显示集合
        /// </summary>
        List<Button> listBtn = new List<Button>();
        /// <summary>
        /// 订单
        /// </summary>
        List<TaskList> taskl;
        private void FmInfo_Load(object sender, EventArgs e)
        {

            Loading.Masklayer(this, delegate () { LoadFucn(); });
            // ft.Show();
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
        int GetOpcServerGroup(Group group, Group group7, Group finshiGroup)
        {
            if (group != null)
            {
                opcGroup = group;
                opcGroup7 = group7;
                opcFinshGroup = finshiGroup;
                opcGroup.callback = OnDataChange; 
                return 1;
            }
            else
            {

                GetTaskInfo("任务信息界面：OPC服务获取失败，将无法获取异形烟缓存工位信息！");
                return 0;
            }
        }
        /// <summary>
        /// opc监控PLC中的值，当发生改变时进入
        /// </summary>
        /// <param name="group"></param>
        /// <param name="clientId"></param>
        /// <param name="values"></param>
        public void OnDataChange(int group, int[] clientId, object[] values)
        {
            if (group == 5)//存入缓存工位信息
            {
                for (int i = 0; i < clientId.Length; i++)
                {
                    int tempvalue = int.Parse((values[i].ToString()));
                    if (tempvalue > 1)
                    {
                        try
                        {
                            // ChangeBtnInfo(tempvalue, true);
                            //if (queue.Count == 7)
                            //{ 
                            //   GetTaskInfo("异形烟缓存工位,包号" + queue.Dequeue() + "完成，队列移除该包号");
                            //    listBtn[7].AccessibleName = "";
                            //} 

                            queue.Enqueue(tempvalue);//将新取到的包号 存入 
                            ChangeBtnInfo(queue);
                        }
                        catch (Exception ex)

                        {
                            // GetTaskInfo("缓存工位队列不包含任何元素" + ex.Message);
                        }
                    }
                    //else { GetTaskInfo("读取缓存工位值异常，值为："+tempvalue); }
                }
            }
 
        }
        int MoveQueueElem(decimal task)
        {
            try
            {
                if (task > 0)
                {
                    queue.Dequeue();
                    ChangeBtnInfo(queue);
                }
            }
            catch (Exception)
            {

                 
            }
          
            return 0;
        }
        /// <summary>
        /// 根据包号 改变按钮显示信息
        /// </summary>
        /// <param name="qe"></param>
        void ChangeBtnInfo(Queue qe  )
        {
            int index = qe.Count   ;
            var newqe = qe.ToArray();
            for (int j = index-1; j >= 0; j--)
            {
                listBtn[j].Text = newqe[j].ToString() ;
                listBtn[j].AccessibleName = newqe[j].ToString();
                listBtn[j].BackColor = Color.LightGreen; 
            }
            foreach (var item in listBtn)
            {
                if (string.IsNullOrWhiteSpace(item.AccessibleName))
                {
                    item.BackColor = Color.Red;
                    item.AccessibleName = "";
                }
            }
        }
        /// <summary>
        /// 载入时做的事情
        /// </summary>
        void LoadFucn()
        {
            Hrs += BindBillInfo;
            HrsUbs += BindUInfo;
            br = new BillResolution(cs.Size);
            //异型烟缓存
            HrsUbs(1,0); 
            //垛型展示
            Hrs(1, 0);
         
        }
        BillResolution br;
 
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
            //if(Convert.ToInt32( textBox1.Text) > br.Length)
            //{
            //     pkIndex = br.Length;
            //    textBox1.Text = pkIndex.ToString();
            //}
           int  packagenum = Convert.ToInt32(textBox1.Text); 
            BindBillInfo(  packagenum,1);
           
            //BindBillInfo(x:Convert.ToInt32(textBox1.Text),y: Convert.ToInt32(textBox2.Text));

        }
        /// <summary>
        /// 根据当前包装机，的整体包序，和条烟流水号获取数据显示到
        /// </summary>
        /// <param name="packageIndex"></param>
        /// <param name="CinNum"></param>
        /// <param name="flag">标志， 0：安装包序查询， 1：任务号查询 ；默认0</param>
        void BindBillInfo(int packageIndex = 0, int flag = 0)
        {
            List<TobaccoInfo> list = new List<TobaccoInfo>() ;
            if (flag == 0)
            {
                list = br.GetTobaccoInfoss(packageIndex, cs.Height);
            }
            else if(flag == 1 )
            {

                list = br.GetTobaccoInfos(packageIndex, cs.Height);

            } 
            if (list.Any())
            { 
                cs.UpdateValue(list);
                var firstList = list.FirstOrDefault();
                var task = FmOrderInofFun.QueryTaskList("", firstList.BillCode, GlobalPara.PackageNo).FirstOrDefault() ;
                if(task != null)
                {
                    lblcutcode.Text = "任务流水号：" + task.SORTNUM;
                    lbllinename.Text = "线路名称：" + task.REGIONCODE;
                    lblcutname.Text = "客户名称" + task.CUSTOMERNAME;
                    lblcuscode.Text = "客户编码" + task.CUSTOMERCODE;
                    lblcutcount.Text = "客户包数：" + firstList.PackgeSeq + "/" + firstList.OrderPackageQty;
                    lblallcount.Text = "总 包 号:" + firstList.GlobalIndex + "/" + br.Length;
                } 
                LabBind();
            } 
        }
        /// <summary>
        /// 根据当前包装机，的整体包序，和条烟流水号获取数据显示到异型烟缓存
        /// </summary>
        /// <param name="cigNum"></param> 
        void BindUInfo(int CinNum = 0,int flag = 0)
        {
            List<TobaccoInfo> UN_list = br.GetUnNormallSort(CinNum);
            if (UN_list.Any())
            {
                cce1.UpdateValue(UN_list);
            } 
        } 
        /// <summary>
        /// 当前索引
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
        /// <summary>
        /// 信息显示到界面 和记录到日记
        /// </summary>
        /// <param name="Info"></param>
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
          
            int widthToCs = Convert.ToInt32(Width * (0.5)); 
            if (cs.Created)
            {
                // BindBillInfo(packageIndex: pkIndex); 
            }
            else
            {
                cs.Size = new Size(555, 6 * 48 + 20);
            }
            if (cs2.Created)
            {

            }
            else
            {
                cs2.Size = new Size(555, 6 * 48 + 20);
            }
          //  panel3.Width = (Width - panel1.Width - cs.Width) - 20;
            gbInfo.Width = panel1.Width;
            cce1.Height = Convert.ToInt32(Width * 0.50); 
            cs.Location = new Point(5, Height - cs.Height - 4);
            cs2.Location = new Point(plcrtl.Width - cs2.Width -5, Height - cs.Height - 4);
            // plcrtl.Height = this.Height - panelInfo.Height - cs.Height  - 120 ; 
            ChangeLabelLocation( );
            lblDxdetail.Location = new Point(10, cs.Location.Y -40 );
            lblGwcx.Location = new Point(cs2.Location.X, cs.Location.Y - 40);
            // panelUN.Location = new Point();
        }
        /// <summary>
        /// 改变文本显示位置
        /// </summary>
        void ChangeLabelLocation( )
        {
            int allHeight = 0;
            int height = 3; //;plcrtl.Height +panelInfo.Height +20;
            int left = plcrtl.Width - 256;

            lblCigCount.Top = height;// panelInfo.Height+ height;
            lblCigCount.Left = left;

            allHeight += lblCigCount.Height;
            lblNormalcOUNT.Top =    height + allHeight;
            lblNormalcOUNT.Left = left;

            allHeight += lblNormalcOUNT.Height;
            lblUnNormal.Top =   height + allHeight;
            lblUnNormal.Left = left;

            allHeight += lblUnNormal.Height;
            lbFinsh.Top =   height + allHeight;
            lbFinsh.Left = left;

            allHeight += lbFinsh.Height;
            lblNotFish.Top =  height + allHeight;
            lblNotFish.Left = left;



            lblallcount.Left = left;//总包号
            lblcutcode.Left = left;//流水号
            lblcutcount.Left = left;//客户包数 

            lbllinename.Left = panelInfo.Width / 2 - 50;
            lblcuscode.Left = panelInfo.Width / 2 - 50; 
            lblcutname.Left = panelInfo.Width / 2 - 50; 
        }
        private void btnnext_Click(object sender, EventArgs e)
        {
            if (btnLast.Cursor == Cursors.No)
            {
                return;
            }
            if (  pkIndex <= br.Length)
            {
                pkIndex++;
                if (br.Length >= pkIndex )
                { 
                    BindBillInfo(pkIndex);
                }
                else
                {
                    pkIndex =int.Parse(br.Length.ToString());
                    MessageBox.Show("已经是最后一个订单的了");
                }
               
            }
        }
         void LabBind()
        {
            
            var list = br.GetTaskAllInfo();
            if (list.Any())
            {
                    lblCigCount.Text = "卷烟总量：" + list[0];// list.Distinct().Sum(a => a.ORDERQTY);
                    lblNormalcOUNT.Text = "常规烟总量：" + list[1];// list.Where(a => a.CIGTYPE == "2").Sum(a => a.NORMALQTY);
                    lblUnNormal.Text = "异型烟总量：" + list[2];// list.Where(a => a.CIGTYPE == "1").Sum(a => a.NORMALQTY);
                    lbFinsh.Text = "已包装数量：" + list[3];// list.Distinct().Where(a => a.UNIONPACKAGETAG == 20).Count();
                    lblNotFish.Text = "未包装数量：" + list[4]; //list.Distinct().Where(a => a.UNIONPACKAGETAG != 20).Count();
            } 
        }
        /// <summary>
        /// 总体长度
        /// </summary>
 

        private void FmInfo_SizeChanged(object sender, EventArgs e)
        {
          
        }
        /// <summary>
        /// 自动更新烟跺
        /// </summary>
        /// <param name="packageIndex"></param>
        /// <param name="cigNum"></param>
        public  static void AutoRefreshShow(int packagenum)
        { 
            Hrs(packagenum, 1);   
        }
        /// <summary>
        /// 自动更新异型烟
        /// </summary>
        /// <param name="packageIndex"></param>
        /// <param name="cigNum"></param>
        public static void AutoRefreshUnShow(int packagenum)
        {
            HrsUbs(packagenum, 1);
        }
         /// <summary>
         /// 自动刷新
         /// </summary>
         /// <param name="p"></param>
         /// <param name="f">0：包序，1：任务号</param>
        delegate void HandeleRefrshShow(int p,int f);
        static  HandeleRefrshShow Hrs;
        static HandeleRefrshShow HrsUbs;
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
                fmTask = new FmTaskLocate(opcGroup7)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
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

        private void gbtnw1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender; 
            if (queue.Count > 0)
            {
                decimal pmNum = Convert.ToDecimal(btn.Text);
                if (Regex.IsMatch(btn.Text, @"^[+-]?\d*[.]?\d*$"))
                {
                    var list = br.GetTobaccoInfos(pmNum, cs2.Height);
                    // cs.UpdateValue(list, 2);
                    if( btn.Name == "btngw7")//工位7 就显示全部
                    {
                        cs2.UpdateValue(list,0);
                    }
                    else
                    {
                        cs2.UpdateValue(list, 2);
                    }
                  
                }
                else
                {
                    GetTaskInfo("显示界面：工位" + btn.Name + "的包号不为数值类型" + btn.Text);
                }
            }
        }
        private ToolTip tp_CodeInfo;

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Width + "   " + Height);
        }

        private void btngw1_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
           // tp_CodeInfo.SetToolTip(btn, "");
        }
    }
    
}
