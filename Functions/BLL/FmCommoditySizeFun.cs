using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFModle;
using EFModle.Model;

namespace Functions.BLL
{
    /// <summary>
    /// 商品尺寸维护类
    /// </summary>
    public class FmCommoditySizeFun
    {
        /// <summary>
        /// 双抓下拉列表绑定值
        /// </summary>
        /// <returns></returns>
        public static string[] doubletasklist()
        {
            string[] vs = new string[2];
            vs[0] = "否";
            vs[1] = "是";
            return vs;
        }
        /// <summary>
        /// 双抓下拉列表绑定值
        /// </summary>
        /// <returns></returns>
        public static string[] HFtasklist()
        {
            string[] vs = new string[2];
            vs[0] = "否";
            vs[1] = "是";
            return vs;
        }
        /// <summary>
        /// 读取品牌信息
        /// </summary>
        /// <param name="CommodityName"></param>
        /// <returns></returns>
        public static List<CommoditySize> Commodity(string CommodityName)
        {
            using (Entities et = new Entities())
            {
                return et.T_WMS_ITEM.Where(x => x.ITEMNAME.IndexOf(CommodityName)>=0 || x.ITEMNO.IndexOf(CommodityName) >=0)
                    .Select(x => new CommoditySize { ITEMNAME = x.ITEMNAME, ITEMNO = x.ITEMNO, ILENGTH = x.ILENGTH ?? 0 , IWIDTH = x.IWIDTH ?? 0 , IHEIGHT = x.IHEIGHT ?? 0 , DOUBLETAKE =x.DOUBLETAKE }).ToList();
            }
        }

        /// <summary>
        /// 修改尺寸
        /// </summary>
        /// <param name="commodity">商品</param>
        /// <returns></returns>
        public static bool UpdateCommodity(CommoditySize commodity)
        {
            using (Entities et = new Entities())
            {
                var commoditys = et.T_WMS_ITEM.Where(x => x.ITEMNO == commodity.ITEMNO).Select(x => x).FirstOrDefault();
                commoditys.IHEIGHT = commodity.IHEIGHT;
                commoditys.ILENGTH = commodity.ILENGTH;
                commoditys.ITEMNAME = commodity.ITEMNAME;
                commoditys.IWIDTH = commodity.IWIDTH;
                commoditys.DOUBLETAKE = commodity.DOUBLETAKE;
                int res = et.SaveChanges();

                return res > 0 ? true : false; ;
            }
        }
    }
}
