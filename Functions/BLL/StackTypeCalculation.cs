using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFModle.Model;
using EFModle;

namespace Functions.BLL
{
   public static class StackTypeCalculation
    {
        static int packageNo = global::Functions.PubFunction.GlobalPara.PackageNo;
        public static List<TobaccoInfo> GetInfos()
        {
            try
            { 
                List<TobaccoInfo> list = new List<TobaccoInfo>();
                using (Entities en = new Entities())
                {
                    List<decimal> all_sortnum = GetAllSortNum(en);//获取所有顺序号 
                    foreach (var sortnum in all_sortnum)
                    {
                        var order = (from task in en.T_PRODUCE_POKESEQ
                                     join wmsitem in en.T_WMS_ITEM on task.CIGARETTECODE equals wmsitem.ITEMNO
                                     where task.SORTNUM == sortnum && task.PACKAGEMACHINE == packageNo
                                     orderby task.POKEID
                                     select new TobaccoInfo
                                     {
                                         SortNum = task.SORTNUM ?? 0,
                                         CigQuantity = task.POKENUM??0,
                                         TobaccoName = wmsitem.ITEMNAME,
                                         TobaccoCode = wmsitem.ITEMNO,
                                         TobaccoLength = (float)wmsitem.ILENGTH,
                                         TobaccoHeight = (float)wmsitem.IHEIGHT,
                                         TobaccoWidth = (float)wmsitem.IWIDTH,
                                         CigType = "1"
                                      }  ).ToList();//获取常规烟 订单
                        var un_order = (from un_task in en.T_UN_POKE
                                        join wmsitem in en.T_WMS_ITEM on un_task.CIGARETTECODE equals wmsitem.ITEMNO
                                        where  un_task.SORTNUM == sortnum && un_task.PACKAGEMACHINE == packageNo  
                                        orderby un_task.MACHINESEQ,un_task.TROUGHNUM
                                        select new TobaccoInfo {
                                            SortNum = un_task .SORTNUM ?? 0,
                                            CigQuantity = un_task.POKENUM ?? 0,
                                            TobaccoName = wmsitem.ITEMNAME,
                                            TobaccoCode = wmsitem.ITEMNO,
                                            TobaccoLength =(float) wmsitem.ILENGTH,
                                            TobaccoHeight =(float)wmsitem.IHEIGHT ,
                                            TobaccoWidth = (float)wmsitem.IWIDTH ,
                                            CigType = "2" }).ToList();//获取异型烟 订单 
                        foreach (var item in order.Union(un_order).ToList())
                        { 
                            list.Add(item);
                        } 
                    }   
                }  
                return list;
            }
            catch (Exception ex)
            {
                ex = new Exception("1报错位置：垛型计算类，获取订单信息方法。错误信息：" + ex.Message);
                throw ex;
            }
          
        }
        
        /// <summary>
        /// 获取顺序号
        /// </summary>
        /// <returns></returns>
        private static List<decimal> GetAllSortNum(Entities en)
        {
            try
            { 
                List<decimal> list_decimal = new List<decimal>();

                decimal MaxSortNum = 1;// PubFunction.GlobalPara.SortNum;//获取最大顺序号
                var list_sortnum = (from item in en.T_PRODUCE_POKE where item .PACKAGEMACHINE == packageNo && item.SORTNUM > MaxSortNum select item) ;
                var list_un_sortnum = (from item in en.T_UN_POKE where item.PACKAGEMACHINE == packageNo && item.SORTNUM > MaxSortNum select item);
                if (list_sortnum != null && list_un_sortnum != null)
                {
                    list_sortnum.Distinct().ToList();
                    list_un_sortnum.Distinct() .ToList();
                     
                    List<decimal> list1 = new List<decimal>();
                    foreach (var item in list_sortnum)
                    {
                        list1.Add(item.SORTNUM ?? 0);
                    }

                    List<decimal> list2 = new List<decimal>();
                    foreach (var item in list_un_sortnum)
                    {
                        list2.Add(item.SORTNUM ?? 0);
                    } 
                    var list3 =  list1.Union(list2).ToList();

                    foreach (var item in list3)
                    {
                        list_decimal.Add(item );
                    }
                    PubFunction.GlobalPara.SortNum = list_decimal.Max();//将最大的顺序号存入
                }
                return list_decimal.OrderBy(a=> a).ToList();
               
            }
            catch (Exception ex)
            {
                ex = new Exception("0报错位置：计算垛型类，获取顺序号方法出错，错误：" + ex.Message);
                throw ex;
            }
        }


        public static void CalculationStack(List<TobaccoInfo> list)
        {

            decimal normal = list.Sum(a => a.CigQuantity);
        }
    }
}
