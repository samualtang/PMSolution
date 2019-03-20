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
        public int CigWidthX { get; set; }
        public int CigHighY { get; set; }
        public decimal CurrentHigh { get; set; }
        public decimal CurrentWidth { get; set; }
        public string DoubleTake { get; set; }
        public decimal GapWidth { get; set; }
        public decimal Highnum { get; set; }
        public int Index { get; set; }
    }

}
