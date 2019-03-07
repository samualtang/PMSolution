using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModle.Model
{
    public class CustomerModle
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string Billcode { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string Customercode { get; set; } 
        /// <summary>
        /// 客户名称
        /// </summary>
        public string Customername { get; set; }
        /// <summary>
        /// 车组
        /// </summary>
        public string Regioncode { get; set; }
        /// <summary>
        /// 户序
        /// </summary>
        public string Priority { get; set; }
        /// <summary>
        /// 订单总量
        /// </summary>
        public string Orderquantity { get; set; }
    }
}
