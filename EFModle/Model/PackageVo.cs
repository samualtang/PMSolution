using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModle.Model
{
    public class PackageVo
    {
        /*
        /// <summary>
        /// 烟之间间隙变量单位毫米
        /// </summary>
        public decimal gapWidth { get; set; }
        /// <summary>
        /// 允许超出限高的浮动范围单位毫米
        /// </summary>
        public decimal floatScope { get; set; }
        /// <summary>
        /// 异型烟限高单位毫米
        /// </summary>
        public decimal umaxhigh { get; set; }
        /// <summary>
        /// 同一平面中允许的烟高度差(双抓高度差)
        /// </summary>
        public decimal highnum { get; set; }
        /// <summary>
        /// 同一平面中允许烟之间相隔宽度差
        /// </summary>
        public decimal widthnum { get; set; }
        /// <summary>
        /// 同一平面中允许烟之间相隔宽度差
        /// </summary>
        public decimal minwidth { get; set; }
        /// <summary>
        /// 总高度
        /// </summary>
        public decimal allhigh { get; set; }
        /// <summary>
        /// 工位宽度
        /// </summary>
        public decimal width { get; set; }
        */
        /// <summary>
        /// 每包卷烟顺序
        /// </summary>
        public decimal CIGSEQ { get; set; }
        /// <summary>
        /// 条烟流水号
        /// </summary>
        public decimal cignum { get; set; }
        /// <summary>
        /// 订单总包数
        /// </summary>
        public decimal ORDERPACKAGENUM { get; set; }
        /// <summary>
        /// 整体包序
        /// </summary>
        public decimal ALLPACKAGESEQ { get; set; }
        /// <summary>
        /// 双抓标志位
        /// </summary>
        public decimal doubFlag { get; set; }
        /// <summary>
        /// 订单总条烟数
        /// </summary>
        public decimal orderqty { get; set; }
        /// <summary>
        /// 包装机号
        /// </summary>
        public decimal packageno { get; set; }
        public decimal cigname { get; set; }
        public decimal cigcode { get; set; }

        /// <summary>
        /// 初始工位宽度
        /// </summary>
        public decimal CigWidth { get; set; }
        /// <summary>
        /// 初始工位剩余宽度
        /// </summary>
        public decimal SurplusWidth { get; set; }
        /// <summary>
        /// X
        /// </summary>
        public decimal CigWidthX { get; set; }
        /// <summary>
        /// Y
        /// </summary>
        public decimal CigHighY { get; set; }
        /// <summary>
        /// Y
        /// </summary>
        public decimal Index { get; set; }

    }
}
