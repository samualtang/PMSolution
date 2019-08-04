using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModle.Model
{
    public class StatusModel
    {
        public string billcode { get; set; }
        public string customername { get; set; }
        public decimal? packtasknum { get; set; }
        public string cigtype { get; set; }
        public decimal? cigseq { get; set; }

        public string cigarettename { get; set; }
        public decimal? normalqty { get; set; }
        public decimal? cigstate { get; set; }
        public decimal? state { get; set; }
        public decimal? normailstate { get; set; }
    }
}
