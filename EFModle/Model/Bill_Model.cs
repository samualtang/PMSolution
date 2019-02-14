using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModle.Model
{
    public class Bill_Model
    {
        /// <summary>
        /// 任务流水号
        /// </summary>
        public decimal SortNum { get; set; } 
        public  decimal PackageSeqLength { get; set; }
        /// <summary>
        /// 任务
        /// </summary>
        public List<T_PACKAGE_TASK> T_P_TASK;
    }
}
