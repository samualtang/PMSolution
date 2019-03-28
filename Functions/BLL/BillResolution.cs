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
        /// 根据订单号包序返回订单详细
        /// </summary>
        /// <param name="List">订单信息</param>
        /// <param name="PackageIndex">包内序号</param> 
        /// <returns></returns>
        public List<TobaccoInfo> GetTobaccoInfos(int PackageIndex, int Height)
        {
            List<TobaccoInfo> list = new List<TobaccoInfo>();
            using (Entities ne = new Entities())
            {
                var allInfo = (from item in ne.T_PACKAGE_TASK where item.ALLPACKAGESEQ == PackageIndex && item.PACKAGENO == packageno orderby item.CIGNUM select item).ToList();

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
                        SortNum = item.SORTNUM ?? 0,
                        OrderPackageQty = item.ORDERPACKAGEQTY ?? 0,
                        PackgeSeq = item.PACKAGESEQ ?? 0,
                        NormalLayerNum = item.PUSHSPACE ?? 0,
                        Speed = 1,
                        BillCode = item.BILLCODE,
                        CigQuantity = item.NORMALQTY ?? 0,
                        OrderIndex = Convert.ToInt32(item.CIGSEQ ?? 0),
                        CigType = item.CIGTYPE,//卷烟类型
                        PostionX = (float)( item.CIGWIDTHX ?? 0 ) ,//坐标X
                        PostionY = Height - (float)Convert.ToDouble(item.CIGHIGHY ?? 0)//坐标Y  
                    };
                    list.Add(info);
                } 
            }
            return list; 
        }

        public List<TobaccoInfo> GetTobaccoInfoss(decimal packageNum, int Height)
        {
            List<TobaccoInfo> list = new List<TobaccoInfo>();
            using (Entities ne = new Entities())
            {
                var allInfo = (from item in ne.T_PACKAGE_TASK where item.PACKTASKNUM == packageNum && item.PACKAGENO == packageno orderby item.CIGNUM select item).ToList();
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
                        SortNum = item.SORTNUM ?? 0,
                        OrderPackageQty = item.ORDERPACKAGEQTY ?? 0,
                        PackgeSeq = item.PACKAGESEQ ?? 0,
                        NormalLayerNum = item.PUSHSPACE ?? 0,
                        Speed = 1,
                        CigQuantity = item.NORMALQTY ?? 0,
                        OrderIndex = Convert.ToInt32(item.CIGSEQ ?? 0),
                        CigType = item.CIGTYPE,//卷烟类型
                        PostionX = (float)(item.CIGWIDTHX ?? 0),//坐标X
                        PostionY = Height - (float)Convert.ToDouble(item.CIGHIGHY ?? 0)//坐标Y  
                    }; 
                    list.Add(info);
                }
            }
            return list;
        }
        /// <summary>
        /// 根据包号 获取包内数据
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
                        SortNum = item.SORTNUM ?? 0,
                        OrderPackageQty = item.ORDERPACKAGEQTY ?? 0,
                        PackgeSeq = item.PACKAGESEQ ?? 0,
                        NormalLayerNum = item.PUSHSPACE ?? 0,
                        Speed = 1,
                        CigQuantity = item.NORMALQTY ?? 0,
                        OrderIndex = Convert.ToInt32(item.CIGSEQ ?? 0),
                        CigType = item.CIGTYPE,//卷烟类型
                        PostionX = (float)(item.CIGWIDTHX ?? 0),//坐标X
                        PostionY = Height - (float)Convert.ToDouble(item.CIGHIGHY ?? 0)//坐标Y  
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
                

                var orderQty = (from item in en.T_PACKAGE_TASK where item.PACKAGENO == packageno select item).Distinct().Sum(a => a.ORDERQTY);
                var normalQty = (from item in en.T_PACKAGE_TASK where item.PACKAGENO == packageno && item.CIGTYPE =="1" select item).Distinct().Sum(a => a.NORMALQTY);
                var UnnormalQty = (from item in en.T_PACKAGE_TASK where item.PACKAGENO == packageno && item.CIGTYPE == "2" select item).Distinct().Sum(a => a.NORMALQTY);
                var FinshQty = (from item in en.T_PACKAGE_TASK where item.PACKAGENO == packageno   select item).Distinct().Where(a => a.CIGSTATE == 20).Count();
                var NotFinshQty = (from item in en.T_PACKAGE_TASK where item.PACKAGENO == packageno   select item).Distinct().Where(a => a.CIGSTATE != 20).Count();

                list.Add(orderQty ?? 0);
                list.Add(normalQty ?? 0);
                list.Add(UnnormalQty ?? 0);
                list.Add(FinshQty  );
                list.Add(NotFinshQty  );

                return list;
            }
        }
        public List<TobaccoInfo> GetUnNormallSort(int CigNum)
        {
            List<TobaccoInfo> list = new List<TobaccoInfo>();
            using (Entities en = new Entities())
            {
                var uninfo = (from item in en.T_PACKAGE_TASK
                              where item.CIGNUM > CigNum && item.PACKAGENO == packageno && item.CIGTYPE == "2"
                              orderby item.CIGNUM
                              select item) .Take(40);
                foreach (var item in uninfo)
                {
                    TobaccoInfo info = new TobaccoInfo
                    {
                        TobaccoName = item.CIGARETTENAME,
                        TobaccoLength = (float)Convert.ToDouble(item.CIGLENGTH),
                        TobaccoWidth = (float)Convert.ToDouble(item.CIGWIDTH),
                        TobaccoHeight = (float)Convert.ToDouble(item.CIGHIGH),
                        GlobalIndex = Convert.ToInt32(item.ALLPACKAGESEQ ?? 0),
                        CigNum = item.CIGNUM ?? 0,
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
