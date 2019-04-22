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
        public static List<TaskList> QueryTaskList(string qureystr, string contentstr, int packageno)
        {
            decimal? content_decmail = 0;
            string content_string = contentstr;
            try
            {
                content_decmail = Convert.ToDecimal(contentstr);
            }
            catch (Exception e)
            {
                content_decmail = 0;
            }
            using (Entities et = new Entities())//取出所有数据
            {
                List<TaskList> taskLists = new List<TaskList>();
                if (string.IsNullOrWhiteSpace(contentstr))
                {

                    var lists =
                from lisitem in
                (from item in et.T_PRODUCE_ORDER
                 join item2 in et.T_PACKAGE_TASK
                 on item.BILLCODE equals item2.BILLCODE
                 where item2.PACKAGENO == packageno
                 select new TaskList
                 {
                     SORTNUM = item2.SORTNUM ?? 0,
                     CUSTOMERNAME = item.CUSTOMERNAME,
                     CUSTOMERCODE = item.CUSTOMERCODE,
                     REGIONCODE = item.REGIONCODE,
                     SORTSEQ = item.PRIORITY ?? 0,
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

                    return taskLists.OrderBy(x => x.SORTNUM).ToList();
                }
                else if (qureystr == "SORTNUM")
                {
                    var lists =
                            from lisitem in
                            (from item in et.T_PRODUCE_ORDER
                             join item2 in et.T_PACKAGE_TASK
                             on item.BILLCODE equals item2.BILLCODE
                             where item2.SORTNUM == content_decmail
                             && item2.PACKAGENO == packageno
                             select new TaskList
                             {
                                 SORTNUM = item2.SORTNUM ?? 0,
                                 CUSTOMERNAME = item.CUSTOMERNAME,
                                 CUSTOMERCODE = item.CUSTOMERCODE,
                                 REGIONCODE = item.REGIONCODE,
                                 SORTSEQ = item.PRIORITY ?? 0,
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

                    return taskLists.OrderBy(x => x.SORTNUM).ToList();
                }
                else
                {
                    var lists =
                        from lisitem in
                        (from item in et.T_PRODUCE_ORDER
                         join item2 in et.T_PACKAGE_TASK
                         on item.BILLCODE equals item2.BILLCODE
                         where item2.PACKAGENO == packageno &&( item2.BILLCODE.IndexOf(contentstr) >= 0 || item.COMPANYNAME.IndexOf(contentstr) >= 0 ||    
                         item.CUSTOMERCODE.IndexOf(contentstr)>= 0 ||item.CUSTOMERNAME.IndexOf(contentstr) >= 0 || 
                         item2.CIGARETTENAME.IndexOf(contentstr) >= 0 || item2.CIGARETTECODE.IndexOf(contentstr) >= 0)
                         select new TaskList
                         {
                             SORTNUM = item2.SORTNUM ?? 0,
                             CUSTOMERNAME = item.CUSTOMERNAME,
                             CUSTOMERCODE = item.CUSTOMERCODE,
                             REGIONCODE = item.REGIONCODE,
                             SORTSEQ = item.PRIORITY ?? 0,
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

                    return taskLists.OrderBy(x => x.SORTNUM).ToList();
                }
            }
        }
        /// <summary>
        /// 根据订单号来查询具体数据
        /// </summary>
        /// <param name="qureystr">任务号</param>
        /// <returns></returns>
        public static List<T_PACKAGE_TASK> QueryBySortnum(decimal qureystr)
        {
            List<T_PACKAGE_TASK> taskLists = new List<T_PACKAGE_TASK>();
            using (Entities et =new Entities())
            {
                var lists = et.T_PACKAGE_TASK.Where(x => x.SORTNUM == qureystr).Select(x => x).ToList();    

                return lists;
            }
        }
    }
}
