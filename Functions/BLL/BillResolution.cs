using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFModle;
using EFModle.Model;
using Functions.PubFunction;
namespace Functions.BLL
{
    public class BillResolution 
    {

        public BillResolution()
        {
     

        }
        public BillResolution(System.Drawing.Size size)
        {
            factor = Math.Sqrt(GlobalPara.BoxWidth * GlobalPara.BoxWidth + GlobalPara.BoxHeight * GlobalPara.BoxHeight) / Math.Sqrt(size.Width * size.Width + size.Height * size.Height);//比例系数

             factorX =    (double)size.Width /(double) GlobalPara.BoxWidth;//570 /770
            factorY = (double)size.Height /(double)GlobalPara.BoxWidth  ;//200 /400

        }

        //bool CrossLine(Rect r1, RECT r2)
        //{
        //    if (Math.Abs((r1.x1 + r1.x2) / 2 - (r2.x1 + r2.x2) / 2) < ((r1.x2 + r2.x2 - r1.x1 - r2.x1) / 2) && Math.Abs((r1.y1 + r1.y2) / 2 - (r2.y1 + r2.y2) / 2) < ((r1.y2 + r2.y2 - r1.y1 - r2.y1) / 2))
        //        return true;
        //    return false;
        //}
        double factor =1;//比例系数
        double factorX = 1;//比例系数
        double factorY = 1;//比例系数
        /// <summary>
        /// 包装机一共有多少包
        /// </summary>
        public int Length { get => (int)GetMaxLenght();   }
        /// <summary>
        /// 包装机编号
        /// </summary>
        int packageno = GlobalPara.PackageNo;

        decimal GetMaxLenght()
        {
            using (Entities en = new Entities())
            {

                var list = (from item in en.T_PACKAGE_TASK where item.PACKAGENO == packageno select item);
                    if(list.Count() > 0)
                {
                 return   list.Max(a => a.ALLPACKAGESEQ ?? 0);
                }
                else
                {
                    return 1;//这台包装机的最大包序

                } 
            }
        }


        /// <summary>
        /// 根据包序返回订单详细
        /// </summary>
        /// <param name="List">订单信息</param>
        /// <param name="PackageIndex">包内序号</param> 
        /// <returns></returns>
        public List<TobaccoInfo> GetTobaccoInfoss(decimal packageNum, int Height)
        {
            List<TobaccoInfo> list = new List<TobaccoInfo>();
            using (Entities ne = new Entities())
            {
                var allInfo = (from item in ne.T_PACKAGE_TASK where item.ALLPACKAGESEQ == packageNum && item.PACKAGENO == packageno orderby item.CIGNUM select item).ToList();
                foreach (var item in allInfo)
                {
                    TobaccoInfo info = new TobaccoInfo
                    {
                        TobaccoName = item.CIGARETTENAME,
                        TobaccoLength = (float)Convert.ToDouble(item.CIGLENGTH),
                        TobaccoWidth = (float)Convert.ToDouble(item.CIGWIDTH)  ,
                        TobaccoHeight = (float)Convert.ToDouble(item.CIGHIGH)   ,
                        GlobalIndex = Convert.ToInt32(item.ALLPACKAGESEQ ?? 0),
                        CigNum = item.CIGNUM ?? 0,
                        DoubleTake = item.DOUBLETAKE,
                        SortNum = item.SORTNUM ?? 0,
                        OrderPackageQty = item.ORDERPACKAGEQTY ?? 0,
                        PackgeSeq = item.PACKAGESEQ ?? 0,
                        NormalLayerNum = item.PUSHSPACE ?? 0,
                        Speed = 1,
                        BillCode = item.BILLCODE,
                        CigQuantity = item.NORMALQTY ?? 0,
                        OrderIndex = Convert.ToInt32(item.CIGSEQ ?? 0),
                        CigType = item.CIGTYPE,//卷烟类型
                        PostionX =   (float)(item.CIGWIDTHX ?? 0),//坐标X
                        PostionY =  (Height - (float)Convert.ToDouble(item.CIGHIGHY ?? 0))//坐标Y  
                    }; 
                    list.Add(info);
                }
            }
            return list;
        }
        /// <summary>
        /// 根据任务包号 获取包内数据
        /// </summary>
        /// <param name="pmTaskNum">包号</param>
        /// <returns></returns>
        public List<TobaccoInfo> GetTobaccoInfos(decimal  pmTaskNum ,int Height)
        {
            List<TobaccoInfo> list = new List<TobaccoInfo>();
            using (Entities ne = new Entities())
            {
                var allInfo = (from item in ne.T_PACKAGE_TASK where item.PACKTASKNUM == pmTaskNum orderby item.CIGNUM select item).ToList();

                foreach (var item in allInfo)
                {
                    TobaccoInfo info = new TobaccoInfo
                    {
                        TobaccoName = item.CIGARETTENAME,
                        TobaccoLength = (float)Convert.ToDouble(item.CIGLENGTH),
                        TobaccoWidth = (float)Convert.ToDouble(item.CIGWIDTH),
                        TobaccoHeight = (float)Convert.ToDouble(item.CIGHIGH),
                        GlobalIndex = Convert.ToInt32(item.ALLPACKAGESEQ ?? 0),
                        CigNum = item.CIGNUM ?? 0,
                        DoubleTake = item.DOUBLETAKE,
                        SortNum = item.PACKTASKNUM ?? 0,
                        OrderPackageQty = item.ORDERPACKAGEQTY ?? 0,
                        PackgeSeq = item.PACKAGESEQ ?? 0,
                        NormalLayerNum = item.PUSHSPACE ?? 0,
                        Speed = 1,
                        BillCode = item.BILLCODE,
                        CigQuantity = item.NORMALQTY ?? 0,
                        OrderIndex = Convert.ToInt32(item.CIGSEQ ?? 0),
                        CigType = item.CIGTYPE,//卷烟类型
                        PostionX =  (float)(item.CIGWIDTHX ?? 0),//坐标X
                        PostionY =  (Height - (float)Convert.ToDouble(item.CIGHIGHY ?? 0))//坐标Y  
                    };
                    if (item.CIGTYPE == "1")//常规烟 
                    {

                    }
                    list.Add(info);
                }
            }
            return list;
        }


       
        public List<decimal> GetTaskAllInfo()
        {
            List<decimal> list = new List<decimal>();
            using(Entities en = new Entities())
            {
                

              
                var normalQty = (from item in en.T_PACKAGE_TASK where item.PACKAGENO == packageno && item.CIGTYPE =="1" select item).Distinct().Sum(a => a.NORMALQTY);
                var UnnormalQty = (from item in en.T_PACKAGE_TASK where item.PACKAGENO == packageno && item.CIGTYPE == "2" select item).Distinct().Sum(a => a.NORMALQTY);
                var orderQty = normalQty + UnnormalQty;// (from item in en.T_PACKAGE_TASK where item.PACKAGENO == packageno select item).Select(a => new { orderQty = a.ORDERQTY, billcode = a.BILLCODE }).Distinct().Sum(a => a.orderQty);
                var FinshQty = (from item in en.T_PACKAGE_TASK where item.PACKAGENO == packageno   select item).Distinct().Where(a => a.STATE == 20).Count();
                var NotFinshQty = (from item in en.T_PACKAGE_TASK where item.PACKAGENO == packageno   select item).Distinct().Where(a => a.STATE != 20).Count();

                list.Add(orderQty ?? 0);
                list.Add(normalQty ?? 0);
                list.Add(UnnormalQty ?? 0);
                list.Add(FinshQty  );
                list.Add(NotFinshQty  );

                return list;
            }
        }
        public List<TobaccoInfo> GetUnNormallSort(decimal packtasknum,int seq)
        {
            List<TobaccoInfo> list = new List<TobaccoInfo>();
            using (Entities en = new Entities())
            {
                var uninfo = (from item in en.T_PACKAGE_TASK
                              where item.PACKTASKNUM >= packtasknum && item .CIGSEQ >= seq && item.PACKAGENO == packageno && item.CIGTYPE == "2" && item.CIGSTATE ==10
                              orderby  item.PACKTASKNUM, item.CIGSEQ
                              select item).Take(200).ToList() ;
                foreach (var item in uninfo)
                {
                    TobaccoInfo info = new TobaccoInfo
                    {
                        TobaccoName = item.CIGARETTENAME,
                        TobaccoLength = (float)Convert.ToDouble(item.CIGLENGTH),
                        TobaccoWidth = (float)Convert.ToDouble(item.CIGWIDTH),
                        TobaccoHeight = (float)Convert.ToDouble(item.CIGHIGH),
                        GlobalIndex = Convert.ToInt32(item.ALLPACKAGESEQ ?? 0),
                        CigNum = item.CIGSEQ ?? 0,
                        NormalLayerNum = item.PUSHSPACE ?? 0,
                        Speed = 1,
                        OrderIndex = Convert.ToInt32(item.CIGSEQ ?? 0),
                        CigType = item.CIGTYPE,//卷烟类型 
                    };
                    list.Add(info);
                }
            }
            return list;
        }

        public void CallBackTBJ()
        {
            using(Entities en  = new Entities())
            {
                //获取当前包装机的数据
             
             
                //获取当前包装机最大条烟流水号
                var cALLBACKs = (from item in en.T_PACKAGE_CALLBACK where item.PACKAGENUM == packageno select item).ToList();
                decimal maxCigNum = 1;
                decimal maxSortnum = 0;
                if (cALLBACKs.Any())
                {
                    maxCigNum = cALLBACKs.Max(a => a.CIGNUM);
                    maxSortnum = cALLBACKs.Max(a => a.SORTNUM);//获取最大的任务号
                }
                //根据最大任务号开始获取数据（作用：如果在掉电或者断网的情况，无需全部重新生成，接着生成就OK了）
                var pagTask = (from item in en.T_PACKAGE_TASK where item.PACKAGENO == packageno && item.SORTNUM >= maxSortnum orderby item.PACKTASKNUM, item.CIGSEQ select item).ToList();


                //避免重复生成 
                foreach (var item in cALLBACKs.Where(a => a.SORTNUM == maxSortnum).ToList())
                {
                    en.T_PACKAGE_CALLBACK.Remove(item);
                } 
                en.SaveChanges();
          
                //获取包装机视图
                var needInfo = (from item in en.V_PRODUCE_PACKAGEINFO where item.EXPORT == packageno orderby item.TASKNUM select item).ToList(); 


               


            
                foreach (var item in pagTask)
                {
                    T_PACKAGE_CALLBACK tb = new T_PACKAGE_CALLBACK();
                    var firstTask = needInfo.Where(a => a.BILLCODE == item.BILLCODE).FirstOrDefault();//订单信息
                 
                    if(item.NORMALQTY > 1)//如果条烟数量大于1 则需要拆分成一条一条的记录
                    {
                        for (int i = 1; i <= item.NORMALQTY; i++)//
                        {
                            tb = new T_PACKAGE_CALLBACK();
                            tb.BILLCODE = item.BILLCODE;//订单
                            tb.ROUTEPACKAGENUM = pagTask.Where(a=> a.REGIONCODE == item.REGIONCODE).Max(a=> a.ALLPACKAGESEQ);//车组总包数
                            tb.ORDERPACKAGENUM = pagTask.Where(a => a.PACKTASKNUM == item.PACKTASKNUM).Max(a => a.PACKAGEQTY);//订单总包数
                            tb.PACKAGESEQ = item.PACKAGESEQ;//订单内包序
                            tb.CIGARETTEQTY = 1;//品牌条烟数 
                            tb.SHAPEDNUM = pagTask.Where(a => a.PACKTASKNUM == item.PACKTASKNUM && a.CIGTYPE == "2").Sum(a => a.NORMALQTY);//订单异型烟数量
                            tb.CIGARETTECODE = item.CIGARETTECODE;//卷烟编码
                            tb.CIGARETTENAME = item.CIGARETTENAME;//卷烟名称
                            tb.ROUTECODE = item.REGIONCODE.ToString();//车组编号
                            tb.PACKAGEQTY = item.PACKAGEQTY;//包内条烟数量
                            tb.ORDERDATE = item.ORDERDATE;//订单日期
                            tb.LINECODE =item.MIANBELT.ToString();//线路编号
                            tb.ORDERCOUNT = 0;//车组内订单数
                            tb.ORDERSEQ = firstTask.SORTSEQ;//订单户序 firstTask.SORTSEQ 
                            tb.CIGSEQ = item.CIGSEQ;//条烟顺序
                            tb.EXPORT = item.PACKAGENO ?? 0;//出口号（包装机号    ）
                            tb.PACKAGENUM = item.PACKAGENO;// 包装机号    
                            tb.ORDERQUANTITY = item.ORDERQTY;//订单总数
                            tb.ADDRESS = firstTask.CONTACTADDRESS;//订单地址
                            tb.CUSTOMERNAME = firstTask.CUSTOMERNAME;//客户名称
                            tb.CUSTOMERNO = firstTask.CUSTOMERCODE;//客户编码                          //////////////////////////// Convert.ToDateTime(time).ToString("yy-MM-dd",System.Globalization.DateTimeFormatInfo.InvariantInfo)
                            tb.ORDERURL =  firstTask.URL;//客户URL   
                            tb.ORDERAMOUNT = firstTask.TOTALAMOUNT;//订单总金额；
                            tb.PAYFLAG = firstTask.CUSTTYPE;//结算状态  
                            tb.SEQ = item.ALLPACKAGESEQ;//整齐包序
                            tb.UNIONTASKPACKAGENUM = GetBillPackNum(en, item.BILLCODE, 0);//合包总包数  
                            tb.NORMALPACKAGENUM = GetBillPackNum(en, item.BILLCODE, 1);//常规烟总包数
                            tb.UNNORMALPACKAGENUM = GetBillPackNum(en, item.BILLCODE, 2);//异型烟总包数  
                            tb.SORTNUM = item.SORTNUM ?? 0;//流水号
                            tb.CIGNUM = maxCigNum++;// 订单 条烟流水号   每台包装机从1 增长 
                            tb.SYNSEQ = item.SYNSEQ; 
                            en.T_PACKAGE_CALLBACK.Add(tb);
                            en.SaveChanges();
                        }
                    }
                    else
                    {
                        tb.BILLCODE = item.BILLCODE;//订单
                        tb.ROUTEPACKAGENUM = pagTask.Where(a => a.REGIONCODE == item.REGIONCODE).Max(a => a.ALLPACKAGESEQ);//车组总包数
                        tb.ORDERPACKAGENUM = pagTask.Where(a => a.PACKTASKNUM == item.PACKTASKNUM).Max(a => a.PACKAGEQTY);//订单总包数
                        tb.PACKAGESEQ = item.PACKAGESEQ;//订单内包序
                        tb.CIGARETTEQTY = item.NORMALQTY;//品牌条烟数
                        tb.SHAPEDNUM = pagTask.Where(a => a.PACKTASKNUM == item.PACKTASKNUM && a.CIGTYPE == "2").Sum(a => a.NORMALQTY);//订单异型烟数量
                        tb.CIGARETTECODE = item.CIGARETTECODE;//卷烟编码
                        tb.CIGARETTENAME = item.CIGARETTENAME;//卷烟名称
                        tb.CIGARETTETYPE = item.CIGTYPE;//卷烟类型
                        tb.ROUTECODE = firstTask.REGIONCODE;//车组编号
                        tb.PACKAGEQTY = item.PACKAGEQTY;//包内条烟数量
                        tb.ORDERDATE = item.ORDERDATE;//订单日期
                        tb.LINECODE = item.MIANBELT.ToString();//线路编号
                        tb.ORDERCOUNT = 0;//车组内订单数
                        tb.ORDERSEQ = firstTask.SORTSEQ;//订单户序 firstTask.SORTSEQ 
                        tb.CIGSEQ = item.CIGSEQ;//条烟顺序
                        tb.EXPORT = item.PACKAGENO ?? 0;//出口号（包装机号    ）
                        tb.PACKAGENUM = item.PACKAGENO;// 包装机号    
                        tb.ORDERQUANTITY = item.ORDERQTY;//订单总数
                        tb.ADDRESS = firstTask.CONTACTADDRESS;//订单地址
                        tb.CUSTOMERNAME = firstTask.CUSTOMERNAME;//客户名称
                        tb.CUSTOMERNO = firstTask.CUSTOMERCODE;//客户编码                          //////////////////////////// Convert.ToDateTime(time).ToString("yy-MM-dd",System.Globalization.DateTimeFormatInfo.InvariantInfo)
                        tb.ORDERURL = firstTask.URL;//客户URL   
                        tb.ORDERAMOUNT = firstTask.TOTALAMOUNT;//订单总金额；
                        tb.PAYFLAG = firstTask.CUSTTYPE;//结算状态  
                        tb.SEQ = item.ALLPACKAGESEQ;//整齐包序
                        tb.UNIONTASKPACKAGENUM = GetBillPackNum(en, item.BILLCODE, 0);//合包总包数  
                        tb.NORMALPACKAGENUM = GetBillPackNum(en, item.BILLCODE, 1);//常规烟总包数
                        tb.UNNORMALPACKAGENUM = GetBillPackNum(en,item.BILLCODE,2);//异型烟总包数  
                        tb.SORTNUM = item.SORTNUM ?? 0;//流水号
                        tb.CIGNUM = maxCigNum++;// 每台包装机从1 增长 
                        tb.SYNSEQ = item.SYNSEQ;//批次号   
                        en.T_PACKAGE_CALLBACK.Add(tb);
                    }
                    en.SaveChanges();
                }
              
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="en"></param>
        /// <param name="billcode"></param>
        /// <param name="flag">0 合包，1 常规烟， 2 异型烟</param>
        /// <returns></returns>
        decimal GetBillPackNum(Entities en, string billcode , int flag)
        {
            var bill = (from item in en.T_PACKAGE_TASK where item.BILLCODE == billcode orderby item.PACKAGESEQ, item.CIGSEQ select item).ToList();
            var grouppack = bill.Select(a => new { packtasknum = a.PACKTASKNUM }).Distinct().ToList();/// .GroupBy(a => new { packtasknum = a.PACKTASKNUM }).ToList();//一共多少包
            int index = 0;
            switch (flag)
            {
                case 0://合包
                    index = 0;
                    foreach (var item in grouppack)
                    {
                        if(bill.Where(a=> a.PACKTASKNUM == item.packtasknum && a.CIGTYPE == "1").Count() > 0 && bill.Where(a => a.PACKTASKNUM == item.packtasknum && a.CIGTYPE == "2").Count() > 0)
                        {
                            index++;
                        }
                    } 
                    return index;
                case 1: //常规烟
                    index = 0;
                    foreach (var item in grouppack)
                    {
                        if (bill.Where(a => a.PACKTASKNUM == item.packtasknum && a.CIGTYPE == "2").Count() == 0 )
                        {
                            index++;
                        }
                    } 
                    return index;
                    
                case 2://异型烟
                    index = 0;
                    foreach (var item in grouppack)
                    {
                        if (bill.Where(a => a.PACKTASKNUM == item.packtasknum && a.CIGTYPE == "1").Count() == 0)
                        {
                            index++;
                        }
                    }
                    return index; 
                default:
                    return 0;
                  
            }

        }
        /// <summary>
        /// 返回客户信息
        /// </summary>
        /// <param name="billcode">订单号</param>
        /// <returns></returns>
        public CustomerModle GetCustomerInfos(string billcode)
        {
            CustomerModle list = new CustomerModle();
            using (Entities et = new Entities())
            {
                if (!string.IsNullOrWhiteSpace(billcode))
                {
                     
                    list = (from iten in et.T_PRODUCE_ORDER_H where iten.BILLCODE == billcode select new CustomerModle { Billcode = iten.BILLCODE, Customername = iten.CUSTOMERNAME, Customercode = iten.CUSTOMERCODE }).FirstOrDefault();
                }
            }
            return list;


        } 
         
        /// <summary>
        /// 自动获取任务
        /// </summary>
        /// <param name="ErrMsg"></param>
        public   void AutoGetTask(out string ErrMsg)
        {
            ErrMsg = "";
            try
            { 
                using (Entities en = new Entities())
                { 
                    //取出订单日期
                    var task = (from ITEM in en.T_PRODUCE_ORDER select ITEM).GroupBy(a => a.ORDERDATE).Select(a => new { orderdate = a.Key }).FirstOrDefault();
                    if (task != null)
                    {
                        int allCount = 0;
                        //根据包装机和日期和包装机接收状态取出批次号
                        var synseq = (from item in en.T_PRODUCE_SYNSEQ select item).Where(a => a.ORDERDATE == task.orderdate && a.PACKAGENO == packageno && a.PMSTATE == "1").GroupBy(a => a.SYNSEQ).Select(a => new { synseq = a.Key }).FirstOrDefault();
                        if (synseq != null)
                        { 
                            //根据包装机 批次号 订单日期 获取 订单信息 
                            var orderinfo = (from item in en.V_PRODUCE_PACKAGEINFO select item).Where(a => a.EXPORT == packageno && a.TASKNUM > GlobalPara.SortNum && a.SYNSEQ == synseq.synseq && a.ORDERDATE == task.orderdate).ToList();
                            int i = 0;
                            if (orderinfo.Any() )
                            {
                                i++;
                                int pcount = 0;

                                List<T_PACKAGE_TASK> p_task = new List<T_PACKAGE_TASK>();
                                foreach (var v_orderinfo in orderinfo)//获取订单详情
                                {
                                    allCount = allCount + 1;
                                    pcount = pcount + 1;
                                    T_PACKAGE_TASK temp = new T_PACKAGE_TASK();
                                    var ptid = en.Database.SqlQuery<decimal>("select s_package_task.nextval from dual").ToList().FirstOrDefault();
                                    temp.PTID = ptid;
                                    temp.CIGARETTECODE = v_orderinfo.CIGARETTECODE;
                                    T_WMS_ITEM tempItem = GetItemByCode(v_orderinfo.CIGARETTECODE);
                                    temp.CIGARETTENAME = tempItem.ITEMNAME;
                                    temp.CIGHIGH = tempItem.IHEIGHT;
                                    temp.CIGWIDTH = tempItem.IWIDTH;
                                    temp.BILLCODE = v_orderinfo.BILLCODE;
                                    temp.SORTNUM = v_orderinfo.TASKNUM;
                                    temp.CIGNUM = allCount;
                                    temp.CIGSEQ = pcount;
                                    temp.PACKAGESEQ = packageno;
                                    temp.ALLPACKAGESEQ = 0;
                                    temp.PACKAGENO = packageno;
                                    temp.CIGTYPE = "2";
                                    temp.STATE = 0;//0 新增  10 确定
                                    temp.CIGZ = Convert.ToDecimal(tempItem.DOUBLETAKE);
                                    GlobalPara.SortNum = v_orderinfo.TASKNUM ;  //存入这一批次最大任务号 
                                    p_task.Add(temp);
                                } 
                            }
                            else
                            {
                                ErrMsg += "包装机任务信息条数为：" + orderinfo.Count();
                            }
                        }
                        else
                        {
                            ErrMsg += "批次号为空";
                        }

                    }
                    else
                    {
                        ErrMsg += "订单日期为空";
                    }
                }
            }
            catch (Exception ex)
            {
                ErrMsg += "错误：未连接至数据库"+ex.Message;
            }
        }
   

        public   T_WMS_ITEM GetItemByCode(String code)
        {
            using (Entities entity = new Entities())
            {
                var query = (from item in entity.T_WMS_ITEM where item.ITEMNO == code && item.ITEMNO.Length == 7 select item).FirstOrDefault();
                return query;
            }
        }
    }
    

}
