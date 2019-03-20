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
    public class PACKAGEINFO_YXY
    {
        public V_PRODUCE_PACKAGEINFO PACKAGEINFO { get; set; }

        public decimal? ILENGTH { get; set; }
        public decimal? IWIDTH { get; set; }
        public decimal? IHEIGHT { get; set; }
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
        /// 平面高
        /// </summary>
        public decimal CurrentHigh { get; set; }
        /// <summary>
        /// 平面宽
        /// </summary>
        public decimal CurrentWidth { get; set; }
        /// <summary>
        /// 双爪
        /// </summary>
        public string DoubleTake { get; set; }
        /// <summary>
        /// 已用宽度
        /// </summary>
        public decimal GapWidth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Highnum { get; set; }
        /// <summary>
        /// 条烟索引
        /// </summary>
        public int Index { get; set; }
    }

}
