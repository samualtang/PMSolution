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
        public decimal width = 0;
        public decimal height = 0;
        public decimal beginx = 0;
        public PackageArea left;
        public PackageArea right;
        public List<Cigarette> cigaretteList;
        public decimal isscan = 0;
    }
    /// <summary>
    /// 卷烟
    /// </summary>
    public class Cigarette
    {
        public decimal CigaretteNo;
        public decimal width;
        public decimal fromx;
        public decimal tox;
        public decimal index;
    }
    /// <summary>
    /// 
    /// </summary>
    public class AreaUnit
    {
        public decimal width;
        public decimal begin;
        public decimal end;
        public decimal beginx;

    }
    public class ItemGroup
    {
        public String CigaretteCode { get; set; }
        public decimal Total { get; set; }
    }
}
