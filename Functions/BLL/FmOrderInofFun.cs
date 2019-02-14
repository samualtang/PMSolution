using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFModle.Model;
using EFModle;

namespace Functions.BLL
{
    public class FmOrderInofFun
    {
        /// <summary>
        /// 查询订单信息（第一部分条件得到的结果）
        /// </summary>
        /// <returns></returns>
        public List<TaskList> QueryTaskList(string list, string s)
        {
            using (Entities et = new Entities())
            {
                List<TaskList> taskLists = new List<TaskList>();
                var lists = from item in et.T_PRODUCE_TASK
                         join item2 in et.T_PACKAGE_TASK
                         on item.SORTNUM equals item2.SORTNUM
                         select new TaskList
                         {
                             SORTNUM = Convert.ToDecimal(item2.SORTNUM),
                             CUSTOMERNAME = item.CUSTOMERNAME,
                             CUSTOMERCODE = item.CUSTOMERCODE,
                             REGIONCODE = item.REGIONCODE,
                             ORDERSEQ = Convert.ToDecimal(item2.PACKAGESEQ),
                             ORDERPACKAGEQTY = Convert.ToDecimal(item2.ORDERPACKAGEQTY),
                             ALLPACKAGESEQ = Convert.ToDecimal(item2.ALLPACKAGESEQ)
                         };
                foreach (var item in lists)
                {
                    TaskList taskList = new TaskList();
                    taskList.SORTNUM = item.SORTNUM;
                    taskList.CUSTOMERCODE = item.CUSTOMERCODE;
                    taskList.CUSTOMERNAME = item.CUSTOMERNAME;
                    taskList.REGIONCODE = item.REGIONCODE;
                    taskList.ORDERSEQ = item.ORDERSEQ;
                    taskList.ORDERPACKAGEQTY = item.ORDERPACKAGEQTY;
                    taskList.ALLPACKAGESEQ = item.ALLPACKAGESEQ; 
                    taskLists.Add(taskList);
                }
                return taskLists;
            }
        }

    }
}
