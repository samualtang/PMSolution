using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions.BLL
{
    public class DataStatusSearch
    {
        /*
         *
            select k.billcode,r.customername, k.packtasknum,k.cigtype,k.cigseq,k.cigarettename,
            k.normalqty,k.cigstate,k.state,k.normailstate 
            from t_package_task k join t_produce_order r on k.billcode = r.billcode
            order by k.packtasknum,k.cigtype,k.cigseq
         * 
         */
        /// <summary>
        /// 最小的任务号
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static decimal GetPackTaskNum(EFModle.Entities et, string str)
        {

            var data = (from item in et.T_PRODUCE_ORDER
                        where item.CUSTOMERNAME.IndexOf(str) >= 0
                        group item by item.BILLCODE into bill
                        select bill.Key).ToList();
            List<decimal> vs = new List<decimal>();
            foreach (var item in data)
            {
                var MinBillcode = (from it in et.T_PACKAGE_TASK
                                   where it.BILLCODE.IndexOf(item) >= 0
                                   && it.PACKAGENO == PubFunction.GlobalPara.PackageNo
                                   group it by it.PACKTASKNUM into val
                                   orderby val.Key
                                   select val.Key).FirstOrDefault();
                if (MinBillcode != null)
                {
                    vs.Add(MinBillcode.Value);
                }
            }
            if (!(vs.Count>0))
                return 0;
            else
                return vs.Min();
        }


        /// <summary>
        /// 倍速链状态
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static List<EFModle.Model.StatusModel> GetBSLTask(string str,decimal status)
        {
            using (EFModle.Entities et =new EFModle.Entities())
            {
                decimal packtasknum = GetPackTaskNum(et, str);
                var data = (from item in et.T_PACKAGE_TASK
                             join item2 in et.T_PRODUCE_ORDER
                             on item.BILLCODE equals item2.BILLCODE
                             where item.STATE == status
                             && item.PACKAGENO == PubFunction.GlobalPara.PackageNo
                             && item.PACKTASKNUM >= packtasknum
                            orderby item.PACKTASKNUM,item.CIGTYPE,item.CIGSEQ
                             select new EFModle.Model.StatusModel {  billcode = item.BILLCODE, customername = item2.CUSTOMERNAME,packtasknum = item.PACKTASKNUM, cigtype = item.CIGTYPE, cigseq = item.CIGSEQ,cigarettename = item.CIGARETTENAME,normalqty = item.NORMALQTY,cigstate = item.CIGSTATE,state = item.STATE,normailstate = item.NORMAILSTATE}
                             ).Take(500).ToList();

                return data;
            }
        }
        /// <summary>
        /// 翻板状态
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static List<EFModle.Model.StatusModel> GetFBTask(string str, decimal status)
        {
            using (EFModle.Entities et = new EFModle.Entities())
            {
                decimal packtasknum = GetPackTaskNum(et, str);
                var data = (from item in et.T_PACKAGE_TASK
                            join item2 in et.T_PRODUCE_ORDER
                            on item.BILLCODE equals item2.BILLCODE
                            where item.NORMAILSTATE == status
                            && item.PACKAGENO == PubFunction.GlobalPara.PackageNo
                             && item.PACKTASKNUM >= packtasknum
                            orderby item.PACKTASKNUM, item.CIGTYPE, item.CIGSEQ
                            select new EFModle.Model.StatusModel { billcode = item.BILLCODE, customername = item2.CUSTOMERNAME, packtasknum = item.PACKTASKNUM, cigtype = item.CIGTYPE, cigseq = item.CIGSEQ, cigarettename = item.CIGARETTENAME, normalqty = item.NORMALQTY, cigstate = item.CIGSTATE, state = item.STATE, normailstate = item.NORMAILSTATE }
                            ).Take(500).ToList();

                return data;
            }
        }
        /// <summary>
        /// 机器人状态
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static List<EFModle.Model.StatusModel> GetJQRTask(string str,decimal status)
        {
            using (EFModle.Entities et = new EFModle.Entities())
            {
                decimal packtasknum = GetPackTaskNum(et, str);
                var data = (from item in et.T_PACKAGE_TASK
                            join item2 in et.T_PRODUCE_ORDER
                            on item.BILLCODE equals item2.BILLCODE
                            where item.CIGSTATE == status
                            && item.PACKAGENO == PubFunction.GlobalPara.PackageNo
                             && item.PACKTASKNUM >= packtasknum
                            orderby item.PACKTASKNUM, item.CIGTYPE, item.CIGSEQ
                            select new EFModle.Model.StatusModel { billcode = item.BILLCODE, customername = item2.CUSTOMERNAME, packtasknum = item.PACKTASKNUM, cigtype = item.CIGTYPE, cigseq = item.CIGSEQ, cigarettename = item.CIGARETTENAME, normalqty = item.NORMALQTY, cigstate = item.CIGSTATE, state = item.STATE, normailstate = item.NORMAILSTATE }
                            ).Take(500).ToList();

                return data;
            }
        }

        /// <summary>
        /// 默认状态
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static List<EFModle.Model.StatusModel> GetDefultTask(string str)
        {
            using (EFModle.Entities et = new EFModle.Entities())
            {
                decimal packtasknum = GetPackTaskNum(et, str);
                var data = (from item in et.T_PACKAGE_TASK
                            join item2 in et.T_PRODUCE_ORDER
                            on item.BILLCODE equals item2.BILLCODE
                            where item.PACKAGENO == PubFunction.GlobalPara.PackageNo
                             && item.PACKTASKNUM >= packtasknum
                            orderby item.PACKTASKNUM, item.CIGTYPE, item.CIGSEQ
                            select new EFModle.Model.StatusModel { billcode = item.BILLCODE, customername = item2.CUSTOMERNAME, packtasknum = item.PACKTASKNUM, cigtype = item.CIGTYPE, cigseq = item.CIGSEQ, cigarettename = item.CIGARETTENAME, normalqty = item.NORMALQTY, cigstate = item.CIGSTATE, state = item.STATE, normailstate = item.NORMAILSTATE }
                            ).Take(500).ToList();

                return data;
            }
        }
    }
}
