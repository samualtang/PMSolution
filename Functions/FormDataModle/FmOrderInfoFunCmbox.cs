using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFModle.Model;

namespace Functions.FormDataModle
{
    public class FmOrderInfoFunCmbox
    {
        /// <summary>
        /// 订单查询界面：订单查询条件下拉框值
        /// </summary>
        /// <returns></returns>
        public static List<OrderInfoCmbox> TitleList() 
        {
            List<OrderInfoCmbox> orderInfoCmboxes = new List<OrderInfoCmbox>(); 
            orderInfoCmboxes.Add(new OrderInfoCmbox() { TITLE = "任务号", CONTENT = "SORTNUM" });
            orderInfoCmboxes.Add(new OrderInfoCmbox() { TITLE = "客户名称", CONTENT = "CUSTOMERNAME" });
            orderInfoCmboxes.Add(new OrderInfoCmbox() { TITLE = "专卖证号", CONTENT = "CUSTOMERCODE" });
            orderInfoCmboxes.Add(new OrderInfoCmbox() { TITLE = "车组号", CONTENT = "REGIONCODE" });
            orderInfoCmboxes.Add(new OrderInfoCmbox() { TITLE = "卷烟名称", CONTENT = "CIGARETTENAME" });
            orderInfoCmboxes.Add(new OrderInfoCmbox() { TITLE = "卷烟编码", CONTENT = "CIGARETTECODE" }); 
            return orderInfoCmboxes;
        }
    }
}
