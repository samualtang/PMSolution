using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModle.Model
{
    public class PackageVo
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Ptid { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string Billcode{ get; set; }
        /// <summary>
        /// 户序
        /// </summary>
        public int Orderseq{ get; set; }
        /// <summary>
        /// 订单包序
        /// </summary>
        public int Packageseq{ get; set; }
        /// <summary>
        /// 订单总包数
        /// </summary>
        public int ORDERPACKAGENUM{ get; set; } //
        /// <summary>
        /// 卷烟编码
        /// </summary>
        public string Cigarettecode{ get; set; }//卷烟编码
        /// <summary>
        /// 卷烟名称
        /// </summary>
        public string CIGARETTENAME{ get; set; } //卷烟名称
        /// <summary>
        /// 每包条烟数
        /// </summary>
        public int PACKAGEQTY{ get; set; } //每包条烟数
        /// <summary>
        /// 每包卷烟顺序
        /// </summary>
        public int CIGSEQ { get; set; }
        /// <summary>
        /// 卷烟高度
        /// </summary>
        public decimal CigHigh{ get; set; }
        /// <summary>
        /// 卷烟宽度  /  平面宽度
        /// </summary>
        public decimal CigWidth{ get; set; }
        /// <summary>
        /// 卷烟长度
        /// </summary>
        public decimal CigLength{ get; set; }
        /// <summary>
        /// 卷烟y轴坐标
        /// </summary>
        public decimal CigHighY{ get; set; } //
        /// <summary>
        /// 卷烟x轴坐标
        /// </summary>
        public decimal CigWidthX{ get; set; }
        /// <summary>
        /// 卷烟z轴坐标
        /// </summary>
        public decimal CigZ{ get; set; }
        /// <summary>
        /// 平面剩余宽度
        /// </summary>
        public decimal SurplusWidth{ get; set; }
        /// <summary>
        /// 正常烟高度
        /// </summary>
        public decimal NormalCigHigh{ get; set; }
        public decimal SubWidth{ get; set; }
        /// <summary>
        /// 整体包序
        /// </summary>
        public int ALLPACKAGESEQ{ get; set; }
        /// <summary>
        /// 是否双抓（0：单抓，1双抓）
        /// </summary>
        public string DoubleTake{ get; set; }
        /// <summary>
        /// 条烟流水号
        /// </summary>
        public int Cignum{ get; set; }
        /// <summary>
        /// 订单任务号
        /// </summary>
        public decimal Tasknum{ get; set; }
        /// <summary>
        /// 订单日期
        /// </summary>
        public DateTime? Orderdate{ get; set; }
        /// <summary>
        /// 推烟层数
        /// </summary>
        public int Pushspace{ get; set; }
        /// <summary>
        /// 合包标志
        /// </summary>
        public int Unionpackagestate{ get; set; }
        /// <summary>
        /// 卷烟类型
        /// </summary>
        public int Cigtype{ get; set; }
        /// <summary>
        /// 正常烟条数
        /// </summary>
        public int Pokenum{ get; set; }
        /// <summary>
        /// 当前平面的Y轴坐标
        /// </summary>
        public decimal Highy{ get; set; }
        /// <summary>
        /// 同一平面中允许烟之间相隔宽度差  间隔
        /// </summary>
        public decimal Widthnum{ get; set; }//----------------------
        /// <summary>
        /// 总宽度  工位宽度  
        /// </summary>
        public decimal Width{ get; set; }//----------------------
        /// <summary>
        /// 订单总量
        /// </summary>
        public int Orderqty{ get; set; }
        /// <summary>
        /// 包装机任务号
        /// </summary>
        public int Packtasknum{ get; set; }
        /// <summary>
        /// 包装机号
        /// </summary>
        public int Packageno{ get; set; } 	
        /// <summary>
        /// 当前烟宽度（可能单双抓）
        /// </summary>
        public decimal CurrentWidth{ get; set; }
        /// <summary>
        /// 当前高度（双爪取最高）
        /// </summary>
        public decimal CurrentHigh{ get; set; }
        /// <summary>
        /// 条烟间间隙 两边5mm  双抓之间无间隙  与旁边的有
        /// </summary>
        public decimal GapWidth{ get; set; }
        /// <summary>
        /// 条烟索引
        /// </summary>
        public int Index{ get; set; }
        /// <summary>
        /// 同一平面允许的高度差于 双抓允许的高度差
        /// </summary>
        public decimal Highnum{ get; set; }
        /// <summary>
        /// 总高度(正常烟)
        /// </summary>
        public decimal Allhigh{ get; set; }
        /// <summary>
        /// 同一平面中允许烟之间相隔宽度差 最小宽度差
        /// </summary>
        public decimal Minwidth{ get; set; }

    }
}
