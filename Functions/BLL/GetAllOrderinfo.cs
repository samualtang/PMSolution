using EFModle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFModle;

namespace Functions.BLL
{
    public static class GetAllOrderinfo
    {
        public static TaskList task(decimal packagetask)
        {
            using (Entities et = new Entities())
            {
                var value = et.T_PACKAGE_TASK.Where(x => x.PACKTASKNUM == packagetask).FirstOrDefault();
                var result = et.V_PRODUCE_PACKAGEINFO.Where(x => x.BILLCODE == value.BILLCODE).FirstOrDefault();
                TaskList tasklist = new TaskList();
                tasklist.SORTNUM = result.TASKNUM;
                tasklist.REGIONCODE = result.REGIONCODE;
                tasklist.SORTSEQ = result.SORTSEQ ?? 0;
                tasklist.ORDERPACKAGEQTY = result.ORDERQUANTITY ?? 0;
                tasklist.CUSTOMERNAME = result.CUSTOMERNAME;
                tasklist.CUSTOMERCODE = result.CUSTOMERCODE;
                tasklist.ALLQTY = result.ORDERQUANTITY ?? 0;
                tasklist.ALLPACKAGENUM = value.ALLPACKAGESEQ ?? 0;
                tasklist.PACKAGENUM = value.PACKAGESEQ ?? 0;
                return tasklist;
            }

        }
        public static decimal GetMaxAllpackageseq()
        {
            using (Entities et = new Entities())
            {
                return et.T_PACKAGE_TASK.Max(x => x.ALLPACKAGESEQ).Value;
            }
        }
        public static decimal GetMinAllpackageseq()
        {
            using (Entities et = new Entities())
            {
                return et.T_PACKAGE_TASK.Min(x => x.ALLPACKAGESEQ).Value;
            }
        }
        /// <summary>
        /// 根据订单号来查询具体数据
        /// </summary>
        /// <param name="qureystr">任务号</param>
        /// <returns></returns>
        public static List<T_PACKAGE_TASK> QueryBypacknum(decimal allpacknum)
        {
            List<T_PACKAGE_TASK> taskLists = new List<T_PACKAGE_TASK>();
            using (Entities et = new Entities())
            {
                var lists = et.T_PACKAGE_TASK.Where(x => x.ALLPACKAGESEQ == allpacknum).Select(x => x).ToList();

                return lists;
            }
        }
        public static string[] GetLabelData(decimal seq)
        {
            string[] str = new string[11];
            using (Entities et = new Entities())
            {
                var data = et.T_PACKAGE_TASK.Where(x => x.ALLPACKAGESEQ == seq).ToList();
                str[0] = data.Select(x => x.ALLPACKAGESEQ).FirstOrDefault().ToString();
                str[1] = data.Select(x => x.PACKAGESEQ).FirstOrDefault().ToString();
                str[2] = data.Where(x => x.CIGTYPE == "1").Sum(x => x.NORMALQTY).ToString();
                str[3] = data.Where(x => x.CIGTYPE == "2").Sum(x => x.NORMALQTY).ToString();

                decimal sortnum = data.Select(x => x.SORTNUM).FirstOrDefault() ?? 0;
                var data2 = et.V_PRODUCE_PACKAGEINFO.Where(x => x.TASKNUM == sortnum).FirstOrDefault();
                str[4] = data2.TASKNUM.ToString();
                str[5] = data2.REGIONCODE.ToString();
                str[6] = data2.SORTSEQ.ToString();
                str[7] = data2.ORDERQUANTITY.ToString();
                str[8] = data2.CUSTOMERCODE.ToString();
                str[9] = data2.CUSTOMERNAME.ToString();
                str[10] = data2.ORDERQUANTITY.ToString();
            }
            return str;
        }
    }
}
