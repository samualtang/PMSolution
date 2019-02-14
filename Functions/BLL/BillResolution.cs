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
        /// <summary>
        /// 取出订单信息
        /// </summary>
        /// <returns></returns>
        public List<Bill_Model> GetBillInfos()
        { 
            using (Entities en = new Entities())
            { 
                List<Bill_Model> list_BM = new List<Bill_Model>();
                var listTask = (from item in en.T_PACKAGE_TASK select item).Distinct().ToList();
                foreach (var item in listTask)
                {
                    Bill_Model bill_ = new Bill_Model(); 
                    var task = (from T_item in en.T_PACKAGE_TASK where T_item.SORTNUM == item.SORTNUM  select T_item).ToList();//获取单个任务信息
                    bill_.T_P_TASK = task;//单个任务集合
                    bill_.SortNum = item.SORTNUM ??0;
                    bill_.PackageSeqLength = (from l_item in en.T_PACKAGE_TASK select l_item).Max(a => a.ALLPACKAGESEQ) ?? 0;
                    list_BM.Add(bill_); 
                } 
                return list_BM;
            } 
        }
         
        /// <summary>
        /// 根据订单号包序返回订单详细
        /// </summary>
        /// <param name="List"></param>
        /// <param name="PackageIndex"></param>
        /// <param name="sortnum"></param>
        /// <returns></returns>
        public List<T_PACKAGE_TASK> GetTaskDetail(List<Bill_Model> List, int PackageIndex)
        {
            List<T_PACKAGE_TASK> t_s = new List<T_PACKAGE_TASK>();
            if (List != null)
            {
                foreach (var item in List)
                {
                    foreach (var detail in item.T_P_TASK.Where(a => a.ALLPACKAGESEQ == PackageIndex).ToList())
                    {
                        t_s.Add(detail);
                    }
                }
                return t_s;
            }
            else
            {
                return t_s;
            }
        }
    }
}
