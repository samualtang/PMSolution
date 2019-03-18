using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFModle;

namespace EFModle.Model
{
    public class TaskList
    {
        //任务号、客户名称、专卖证号、车组号、订单内包序、订单总包数、包装机整体包序  
        /// <summary>
        /// 任务号
        /// </summary>
        public decimal SORTNUM { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CUSTOMERNAME { get; set; }

        /// <summary>
        /// 专卖证号
        /// </summary>
        public string CUSTOMERCODE { get; set; }

        /// <summary>
        /// 车组号
        /// </summary>
        public string REGIONCODE { get; set; }

        /// <summary>
        /// 户序
        /// </summary>
        public decimal SORTSEQ { get; set; }

        /// <summary>
        /// 订单总包数
        /// </summary>
        public decimal ORDERPACKAGEQTY { get; set; }

        /// <summary>
        /// 订单总烟量
        /// </summary>
        public decimal ALLQTY { get; set; }
    }

}
