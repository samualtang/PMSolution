using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModle.Model
{
    public class TobaccoInfo
    {
        public TobaccoInfo()
        {

        }
        /// <summary>
        /// 包装机全局索引
        /// </summary>
        public int GlobalIndex { get; set; }
        /// <summary>
        /// 订单条烟索引
        /// </summary>
        public int OrderIndex { get; set; }
        /// <summary>
        /// 任务流水号
        /// </summary>
        public decimal SortNum { get; set; }
        /// <summary>
        /// 条烟流水号
        /// </summary>
        public int CigNum {get;set;}
        /// <summary>
        /// 卷烟类型
        /// </summary>
        public string CigType { get; set; }
        /// <summary>
        /// 速度
        /// </summary>
        public float Speed { get; set; }
        /// <summary>
        /// 条烟长
        /// </summary>
        public float TobaccoLength { get; set; }
        /// <summary>
        /// 条烟宽
        /// </summary>
        public float TobaccoWidth { get; set; }
        /// <summary>
        /// 条烟高
        /// </summary>
        public float TobaccoHeight { get; set; }
        /// <summary>
        /// 卷烟状态
        /// </summary>
        public int TobaccoStatus { get; set; }

        /// <summary>
        /// 卷烟高的位置
        /// </summary>
        public float PositionHeight { get; set; }
        /// <summary>
        /// 卷烟宽的位置
        /// </summary> 
        public float PositionWidth { get; set; }

        /// <summary>
        /// 卷烟名称
        /// </summary>
        public  string TobaccoName { get; set; }

        /// <summary>
        /// 卷烟最终显示高度位置
        /// </summary>
        public float PositionHeightLast { get; set; } 
        /// <summary>
        /// 卷烟最终显示宽度位置
        /// </summary>
        public float PositionWidthLast { get; set; }

        /// <summary>
        /// 坐标X
        /// </summary>
        public float PostionX { get; set; }
        /// <summary>
        /// 坐标Y
        /// </summary>
        public float PostionY { get; set; }
        /// <summary>
        /// 坐标Z
        /// </summary>
        public float PostionZ { get; set; }
        /// <summary>
        /// 单个订单
        /// </summary>
        public T_PACKAGE_TASK tASK;

    }

    public  class UnNormalInfo
    {  
    }
}
