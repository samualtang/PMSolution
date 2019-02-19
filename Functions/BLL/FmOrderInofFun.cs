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
        /// <param name="qureystr">查询条件</param>
        /// <param name="contentstr">查询内容</param>
        /// <param name="packageno">包装机编号</param>
        /// <returns></returns>
        public static List<TaskList> QueryTaskList(string qureystr, string contentstr,int packageno)
        {
            decimal? content = 0;
            try
            {
                content = Convert.ToDecimal(contentstr);
            }
            catch (Exception e)
            {
                
            }
            using (Entities et = new Entities())
            {
                List<TaskList> taskLists = new List<TaskList>();
                var lists =
                    from lisitem in
                    (from item in et.T_PRODUCE_TASK
                     join item2 in et.T_PACKAGE_TASK
                     on item.SORTNUM equals item2.SORTNUM
                     where item.BILLCODE.Contains( contentstr) || item.COMPANYNAME.Contains(contentstr) || item.CUSTOMERCODE.Contains(contentstr) 
                     || item.SORTNUM== content || item2.CIGARETTENAME.Contains(contentstr) || item2.CIGARETTECODE.Contains(contentstr)
                     select new TaskList
                     {
                         SORTNUM = item2.SORTNUM ?? 0,
                         CUSTOMERNAME = item.CUSTOMERNAME,
                         CUSTOMERCODE = item.CUSTOMERCODE,
                         REGIONCODE = item.REGIONCODE,
                         SORTSEQ = item.SORTSEQ ?? 0,
                         ORDERPACKAGEQTY = item2.ORDERPACKAGEQTY ?? 0,
                         ALLQTY = item2.ORDERQTY ?? 0
                     })
                    group lisitem by new { lisitem.REGIONCODE, lisitem.SORTNUM, lisitem.CUSTOMERCODE, lisitem.CUSTOMERNAME, lisitem.SORTSEQ, lisitem.ORDERPACKAGEQTY, lisitem.ALLQTY }
                     into dates
                    select new { dates.Key, dates }.Key;


                foreach (var item in lists)
                {
                    TaskList taskList = new TaskList();
                    taskList.SORTNUM = item.SORTNUM;
                    taskList.CUSTOMERCODE = item.CUSTOMERCODE;
                    taskList.CUSTOMERNAME = item.CUSTOMERNAME;
                    taskList.REGIONCODE = item.REGIONCODE;
                    taskList.SORTSEQ = item.SORTSEQ;
                    taskList.ORDERPACKAGEQTY = item.ORDERPACKAGEQTY;
                    taskList.ALLQTY = item.ALLQTY; 
                    taskLists.Add(taskList); 
                }
                return taskLists;
            }
        }

    }
}
