using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModle.Model
{
    /// <summary>
    /// 卷烟平面
    /// </summary>
    public class PackageArea
    {
        /// <summary>
        /// 平面宽度
        /// </summary>
        public decimal width = 0;
        /// <summary>
        /// 平面高度
        /// </summary>
        public decimal height = 0;
        /// <summary>
        /// 平面开始起点X坐标
        /// </summary>
        public decimal beginx = 0;
        /// <summary>
        /// 左平面
        /// </summary>
        public PackageArea left;
        /// <summary>
        /// 右平面
        /// </summary>
        public PackageArea right;
        /// <summary>
        /// 平面内的卷烟集合
        /// </summary>
        public List<Cigarette> cigaretteList;
        /// <summary>
        /// 计算标志
        /// </summary>
        public decimal isscan = 0;
    }
    /// <summary>
    /// 卷烟
    /// </summary>
    public class Cigarette
    {
        /// <summary>
        /// 卷烟序号
        /// </summary>
        public decimal CigaretteNo;
        /// <summary>
        /// 宽度
        /// </summary>
        public decimal width;
        /// <summary>
        /// 最小X坐标
        /// </summary>
        public decimal fromx;
        /// <summary>
        /// 最大X坐标
        /// </summary>
        public decimal tox;
        /// <summary>
        /// 平面条烟索引
        /// </summary>
        public decimal index;
    }
    /// <summary>
    /// 
    /// </summary>
    public class AreaUnit
    {
        /// <summary>
        /// 宽度
        /// </summary>
        public decimal width;
        /// <summary>
        /// 
        /// </summary>
        public decimal begin;
        /// <summary>
        /// 
        /// </summary>
        public decimal end;
        /// <summary>
        /// 开始坐标
        /// </summary>
        public decimal beginx;

    }
    /// <summary>
    /// 平面组
    /// </summary>
    public class ItemGroup
    {
        /// <summary>
        /// 卷烟
        /// </summary>
        public String CigaretteCode { get; set; }
        /// <summary>
        /// 条烟数
        /// </summary>
        public decimal Total { get; set; }
    }
}
