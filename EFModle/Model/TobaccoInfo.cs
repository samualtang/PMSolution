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
        /// 
        /// </summary>
        public float PositionHeight { get; set; }

        public float PositionWidth { get; set; }

        public  string TobaccoName { get; set; }


        public float PositionHeightLast { get; set; }



        public float PositionWidthLast { get; set; }



    }
}
