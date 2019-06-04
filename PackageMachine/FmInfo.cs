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
            br = new BillResolution(cs.Size);
            label3.Text = "|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n|\r\n";
            Func += ChangeControlEnabled;
            handle += updateListBox;
            GetGroup = GetOpcServerGroup;
            cbCgyOrNot.Checked = true;
            AddListBtn();
            FuncAutoRefsh = AutoRefshRobotShow;
            CheckFlag = true; 
            
            // AutoScroll = true; 
        } 
        /// <summary>
        /// 机器人工位单击事件
        /// </summary>
        Thread thToClike;
        /// <summary>
        /// OPC服务器
        /// </summary> 
        Group opcGroup, opcGroup7;
        /// <summary>
        /// 常规烟翻版任务号
        /// </summary> 
        public static decimal FbPackageNum { get; set; }
        /// <summary>
        /// 获取OPC组
        /// </summary>
        public static Func<Group, Group, int> GetGroup;
        /// <summary>
        /// 自动刷新委托
        /// </summary>
        public static Func<int> FuncAutoRefsh;
        /// <summary>
        /// 取消按钮使用(传入1停用，传入2使用)
        /// </summary>
        public static Func<int, int> Func;
 
        /// <summary>
        /// 界面工位按钮显示集合
        /// </summary>
        List<Button> listBtn = new List<Button>();

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
        int GetOpcServerGroup(Group group, Group group7)
        {
            if (group != null)
            {
                opcGroup = group;
                opcGroup7 = group7; 
                opcGroup.callback = OnDataChange;
                ChangeListBtn();

                
                return 1;
            }
            else
            {

                GetTaskInfo("任务信息界面：OPC服务创建失败，将无法获取异形烟缓存工位信息！");
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
                    //if (tempvalue > 1)
                    //{
                        try
                        {
                            ChangeListBtn(); 
                        }
                        catch (Exception ex)

                        {
                             GetTaskInfo("缓存工位队列不包含任何元素" + ex.Message);
                        }
                    //}
                    //else { GetTaskInfo("读取缓存工位值异常，值为："+tempvalue); }
                }
            }
 
        }

      
        /// <summary>
        /// 更改工位（button）显示
        /// </summary>
        void ChangeListBtn()
        {
            int j = 0;
            int index = 1;
            Button btn = null;
            for (int i = listBtn.Count()-1; i >= 0; i--)//10 9 8 7 6
            {
                var values = opcGroup.ReadD(j).CastTo("0");//7
                if(j<= 6)
                {
                    btn = listBtn[i-4];
                }
                else
                {
             
                    btn = listBtn[i+3+index];
                    index+=2;
                } 
                if (values == "0" || string.IsNullOrWhiteSpace(values))
                {
                    if(btn.Name == "btnRobt")
                    {
                        btn.Text = "机器人工位" ;
                        btn.BackColor = Color.Gray;
                        btn.Cursor = Cursors.No;
                        gbtnw1_Click(btnRobt, null); 
                    }
                    else
                    { 
                        if(btn.Name.Contains("8")  )
                        { 
                            btn.Text = "拨杆一";
                            btn.BackColor = Color.Gray;
                            btn.Cursor = Cursors.No;
                        }
                        else if (btn.Name.Contains("9"))
                        {
                            btn.Text = "拨杆二" ;
                            btn.BackColor = Color.Gray;
                            btn.Cursor = Cursors.No;
                        }
                        else if (btn.Name.Contains("10"))
                        {
                            btn.Text = "拨杆三" ;
                            btn.BackColor = Color.Gray;
                            btn.Cursor = Cursors.No;
                        }
                        else
                        { 
                            btn.Text = "工位" + (j + 1);
                            btn.BackColor = Color.Gray;
                            btn.Cursor = Cursors.No;
                        }
                    }
                }
                else
                {
                    

                    if ( btn.Name=="btngw9")//如果是合包处工位任务号不同 就把这个任务移到拨杆三的位置
                    {
                        textBox1.Text = values;
                        ChangeButton3(values); 
                    }
                    if (btn.Name != "btngw10")//如果是合包处工位任务号不同 就把这个任务移到拨杆三的位置
                    {
                        btn.Text = values;
                        btn.BackColor = Color.LightGreen;
                        btn.Cursor = Cursors.Hand;
                    }
                   
                    //if (btn.Name == "btnRobt")//如果是机器人 则单击一次 刷新
                    //{
                    //    gbtnw1_Click(btnRobt, null);

                    //}
                }
                j++;
            }

        }
        object lockobj = new object();
        void ChangeButton3(string text )
        {
            lock (lockobj)
            { 
                if (text != btngw9.Text)//如果新的数据 和旧数据不一样
                {
                    btngw10.Text = btngw9.Text; //就把旧数据赋值给 拨杆三
                    btngw10.BackColor = Color.LightGreen;
                    btngw10.Cursor = Cursors.Hand;
                }
                else if (!Regex.IsMatch(text, @"^[+-]?\d*[.]?\d*$"))//如果不包含数字
                {
                    btngw10.Text = "拨杆三";
                    btngw10.BackColor = Color.Gray;
                    btngw10.Cursor = Cursors.No;
                }
            }
            //else
            //{
            //    btngw10.Text = "拨杆三";
            //    btngw10.BackColor = Color.Gray;
            //    btngw10.Cursor = Cursors.No;
            //}

        }
        /// <summary>
        /// 添加工位（button）到集合
        /// </summary>
        void AddListBtn()
        {

            listBtn.Add(btngw7);//0
            listBtn.Add(btngw6);//1
            listBtn.Add(btngw5);//2
            listBtn.Add(btngw4);//3
            listBtn.Add(btngw3);//4
            listBtn.Add(btngw2);//5
            listBtn.Add(btngw1);//6
            listBtn.Add(btngw8);//拨杆一7
            listBtn.Add(btngw9);//拨杆二8
            listBtn.Add(btngw10);//拨杆三9
            listBtn.Add(btnRobt);//机器人10
        }
        /// <summary>
        /// 传入标志，标记是否能点击 
        /// </summary>
        /// <param name="flag">真为启用，假为禁用</param>
        void EnbaleContrls(bool flag)
        {
            foreach (var item in listBtn)
            {
                if (flag)
                {
                    item.Enabled = true;
                }
                else
                {
                    item.Enabled = false;
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
         
            //异型烟缓存
            HrsUbs(1,1,0); 
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
            Fm_Orderinfo_All all = null;
            try
            {
                all = new Fm_Orderinfo_All(Convert.ToDecimal(textBox1.Text));
            }
            catch (Exception)
            {
                 
            }
            if (all == null)
            {
                return;
            }
            all.Show();
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
                    lblcutcode.Text = "任务流水号：" + firstList.PacktaskNum;
                    lbllinename.Text = "线路名称：" + task.REGIONCODE;
                    lblcutname.Text = "客户名称：" + task.CUSTOMERNAME;
                    lblcuscode.Text = "客户编码：" + task.CUSTOMERCODE;
                    lblcutcount.Text = "客户包数：" + firstList.PackgeSeq + "/" + firstList.OrderPackageQty;
                    lblallcount.Text = "总 包 号：" + firstList.GlobalIndex + "/" + br.Length;
                    //lblRcOUNT.Text = "车组包数："+"/";
                } 
              
            }
            LabBind();
        }
        /// <summary>
        /// 根据当前包装机，的整体包序，和条烟流水号获取数据显示到异型烟缓存
        /// </summary>
        /// <param name="cigNum"></param> 
        void BindUInfo(decimal CinNum = 1,int cigseq = 1,int flag = 0)
        {
            List<TobaccoInfo> UN_list = br.GetUnNormallSort(CinNum, cigseq);
            if (UN_list.Any())
            {
                cce1.UpdateValue(UN_list );
            }
            else
            {
                cce1.ClearData();
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

                if (info.Substring(0,5).Contains("异型烟"))
                {
                    ftd.updateListBox(info);
                }
                else if ( info.Substring(0, 5).Contains("常规烟") || info.Substring(0, 5).Contains("机器人"))
                {
                    ftd.updateCgyListBox(info);
                }
                else
                    {
                    ftd.updateListBox(info);
                }
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

            cs.Location = new Point(5, Height - cs.Height - 4);//和包工位位置
            cs2.Location = new Point(plcrtl.Width - cs2.Width -5, Height - cs.Height - 4);//缓存工位明细
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
            lblRcOUNT.Left = left;//车组包数

            lbllinename.Left = panelInfo.Width / 2 - 50;//线路名称
            lblcuscode.Left = panelInfo.Width / 2 - 50; //客户名称
            lblcutname.Left = panelInfo.Width / 2 - 50; //客户编号
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
                    lblCigCount.Text = "总卷烟数量：" + list[0];// list.Distinct().Sum(a => a.ORDERQTY);
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
        public static void AutoRefreshUnShow(decimal packagenum,int seq)
        {
            HrsUbs(packagenum, seq, 1);
        }
         /// <summary>
         /// 自动刷新
         /// </summary>
         /// <param name="p"></param>
         /// <param name="f">0：包序，1：任务号</param>
        delegate void HandeleRefrshShow(int p,int f);
        delegate void HandeleRefrshUssShow(decimal packtasknum, int cigseq, int f);
        static  HandeleRefrshShow Hrs;
        static HandeleRefrshUssShow HrsUbs;
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
            // var arr = br.GetReadyTaskNum();//索引1 为 合包处的任务号，  索引 2，3 对应的是 机器人任务号 和条烟流水号
            try
            {
                if (Regex.IsMatch(listBtn[8].Text, @"^[+-]?\d*[.]?\d*$"))//如果拨杆2按钮内容不为文字
                {
                    Hrs(Convert.ToInt32(listBtn[8].Text), 1);
                }
                else
                {
                    if (Regex.IsMatch(listBtn[7].Text, @"^[+-]?\d*[.]?\d*$"))//如果拨杆1按钮内容不为文字
                    {
                        Hrs(Convert.ToInt32(listBtn[7].Text), 1);
                    }
                    else
                    {

                        Hrs(1, 0);
                    }
                }

                if (Regex.IsMatch(listBtn[10].Text, @"^[+-]?\d*[.]?\d*$"))//如果机器人工位按钮内容不为文字
                {
                    HrsUbs(Convert.ToDecimal(listBtn[10].Text), 1, 1);
                }
                else
                {
                    HrsUbs(1, 1, 0);
                }
            }
            catch (Exception)
            {

                throw;
            }
            

        }
         
        private void btnRouteSerch_Click(object sender, EventArgs e)
        {
          var list =  br.GetRegionPackageNum();
            string info = "";
            if( list.Any())
            {
                foreach (var item in list)
                {
                    info += "车组：" + item.Region + ",包数：" + item.PackageCount + "\r\n";
                }
            }
            if (!string.IsNullOrEmpty(info))
            {
                MessageBox.Show(info,"车组包数查询,车组数："+list.Count());
            }
        }
  
        bool CheckFlag = true;

        private void cbAutoRefsh_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckFlag)
            { 
                EnbaleContrls(false);
                gbtnw1_Click(btnRobt, null);//单击机器人工位
                 CheckFlag = false;


            }
            else
            { 
                EnbaleContrls(true);
                CheckFlag = true;
            }
        }
        /// <summary>
        /// 自动刷新机器人工位跺型
        /// </summary>
        /// <returns></returns>
        int AutoRefshRobotShow()
        {
            if (!CheckFlag)
            {
                gbtnw1_Click(btnRobt, null);
            }
            return 0;
        }

        private void gbtnw1_Click(object sender, EventArgs e)
        {
            decimal pmNum = 0;
            Button btn = (Button)sender;
            if (btn.Cursor == Cursors.No)
            {
                return;
            }
            try
            {
                pmNum = Convert.ToDecimal(btn.Text);
            }
            catch (Exception)
            {


            } 
            if (pmNum > 0)
            {
                if (Regex.IsMatch(btn.Text, @"^[+-]?\d*[.]?\d*$"))
                {

                    var list = br.GetTobaccoInfos(pmNum, cs2.Height);
                    if (list.Any())
                    {
                        if (btn.Name == "btngw7")//工位7 就显示全部
                        {

                            cs2.UpdateValue(list, 0);
                        }

                        else
                        {
                            if (cbCgyOrNot.Checked)
                            {
                                cs2.UpdateValue(list, 0);
                            }
                            else
                            {

                                cs2.UpdateValue(list, 2);
                            }
                        }
                    }
                    else { GetTaskInfo("显示界面：未找到任务号:" + pmNum); };

                }
                else
                {
                    GetTaskInfo("显示界面：工位" + btn.Name + "的包号不为数值类型" + btn.Text);
                }
            }

        }
        private void timeToClike_Tick(object sender, EventArgs e)
        {
          
        }

        private void btngw1_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
           // tp_CodeInfo.SetToolTip(btn, "");
        }
    }
 
}
