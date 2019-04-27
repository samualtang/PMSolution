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
        /// 包装机全局索引  整体包序
        /// </summary>
        public int GlobalIndex { get; set; }

        /// <summary>
        /// 订单编码
        /// </summary>
        public string BillCode { get; set; }
        /// <summary>
        /// 订单条烟索引   订单内包序
        /// </summary>
        public int OrderIndex { get; set; }
        /// <summary>
        /// 条烟流水号
        /// </summary>
        public decimal CigNum { get; set; }
        /// <summary>
        /// 条烟数量
        /// </summary>
        public decimal CigQuantity { get; set; }
        /// <summary>
        /// 任务流水号
        /// </summary>
        public decimal SortNum { get; set; }

        /// <summary>
        /// 订单内包序
        /// </summary>
        public decimal PackgeSeq { get; set; }
        /// <summary>
        /// 订单总包数
        /// </summary>
       public decimal OrderPackageQty { get; set; }
        /// <summary>
        /// 卷烟类型
        /// </summary>
        public string CigType { get; set; }
        /// <summary>
        /// 双抓
        /// </summary>
        public string DoubleTake { get; set; }
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
        /// 任务包号
        /// </summary>
        public decimal PacktaskNum { get; set; }
        /// <summary>
        /// 条烟高
        /// </summary>
        public float TobaccoHeight { get; set; }
        /// <summary>
        /// 卷烟状态  包装状态
        /// </summary>
        public decimal TobaccoState { get; set; } 

        /// <summary>
        /// 卷烟名称
        /// </summary>
        public  string TobaccoName { get; set; }
        /// <summary>
        /// 卷烟编码
        /// </summary>
        public string TobaccoCode { get; set; }
        /// <summary>
        /// 坐标X
        /// </summary>
        public float PostionX { get; set; }
        /// <summary>
        /// 常规烟层数
        /// </summary>
        public decimal NormalLayerNum { get; set; }
        /// <summary>
        /// 坐标Y
        /// </summary>
        public float PostionY { get; set; }
        /// <summary>
        /// 坐标Z
        /// </summary>
        public float PostionZ { get; set; }
        ///// <summary>
        ///// 单个订单
        ///// </summary>
        //public T_PACKAGE_TASK tASK;

    }

    public  class RouteDetail
    {  
        //车组
       public string Region { get; set; }
        //包数
        public decimal PackageCount { get; set; }
    }
}
