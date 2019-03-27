using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModle.Model
{
    /// <summary>
    /// 订单详情（条记录）
    /// </summary>
    public class PACKAGEINFO_All
    {
        public V_PRODUCE_PACKAGEINFO PACKAGEINFO { get; set; }

        public decimal ILENGTH { get; set; }
        public decimal IWIDTH { get; set; }
        public decimal IHEIGHT { get; set; }
        public string DOUBLETAKE { get; set; }
    }

    /// <summary>
    /// 分配信息
    /// </summary>
    public class Matching
    {
        /// <summary>
        /// 平面X
        /// </summary>
        public int CigWidthX { get; set; }
        /// <summary>
        /// 平面Y
        /// </summary>
        public int CigHighY { get; set; }
        /// <summary>
        /// 当前烟高
        /// </summary>
        public decimal CurrentHigh { get; set; }
        /// <summary>
        /// 烟宽
        /// </summary>
        public decimal CurrentWidth { get; set; }
        /// <summary>
        /// 双抓
        /// </summary>
        public string DoubleTake { get; set; }
        /// <summary>
        /// 间隙
        /// </summary>
        public decimal GapWidth { get; set; }
        /// <summary>
        /// 同一平面允许的双抓高度差
        /// </summary>
        public decimal Highnum { get; set; }
        /// <summary>
        /// 条烟索引
        /// </summary>
        public int Index { get; set; }
    }








    public class T_PRODUCE_PACKAGEINFO
    {
        public decimal TASKNUM { get; set; }
        public decimal EXPORT { get; set; }
        public string REGIONCODE { get; set; }
        public string REGIONNAME { get; set; }
        public string CONTACTADDRESS { get; set; }
        public string SORTDATE { get; set; }
        public DateTime ORDERDATE { get; set; }
        public int PRIORITY { get; set; }
        public string CUSTOMERNAME { get; set; }
        public string CUSTOMERCODE { get; set; }
        public string BILLCODE { get; set; }
        public string CIGARETTECODE { get; set; }
        public string CIGARETTENAME { get; set; }
        public decimal QUANTITY { get; set; }
        public string ALLOWSORT { get; set; }
        public decimal SORTSEQ { get; set; }
        public decimal MACHINESEQ { get; set; }
        public string TROUGHNUM { get; set; }
        public decimal ORDERCOUNT { get; set; }
        public decimal SEQ { get; set; }
        public string URL { get; set; }
        public decimal SENDSEQ { get; set; }
        public decimal SENDTASKNUM { get; set; }
        public decimal POKEID { get; set; }
        public string CUSTTYPE { get; set; }
        public decimal TOTALAMOUNT { get; set; }
        public string COMPLAINNUM { get; set; }
        public string SERVICENUM { get; set; }
        public decimal SYNSEQ { get; set; }
        public decimal ORDERQUANTITY { get; set; }
    }
}
