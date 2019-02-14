using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFModle;
using EFModle.Model;
namespace Functions.BLL
{
   public class BillResolution
    {
        public List<TobaccoInfo> GetTobaccoInfos()
        {
            List<TobaccoInfo> list = new List<TobaccoInfo>();
            using (Entities en = new Entities())
            {
                var sortnum = (from item in en.T_PRODUCE_POKE orderby item.SORTNUM select item).FirstOrDefault();
                var order = (from item in en.T_PRODUCE_TASK where item.SORTNUM == sortnum.SORTNUM select item).ToList();//获取一个订单
                var unnormal = (from item in en.T_UN_POKE
                                join item2 in en.T_PRODUCE_SORTTROUGH on item.TROUGHNUM equals item2.TROUGHNUM
                                where item.SORTNUM == sortnum.SORTNUM orderby item.MACHINESEQ
                                select item).ToList();//获取异型烟
            }
            return list;
        }
    }
}
