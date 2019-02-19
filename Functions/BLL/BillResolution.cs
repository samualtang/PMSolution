using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFModle;
using EFModle.Model;
namespace Functions.BLL
{
   public class BillResolution
    {
        /// <summary>
        /// 取出订单信息
        /// </summary>
        /// <returns></returns>
        public List<Bill_Model> GetBillInfos()
        { 
            using (Entities en = new Entities())
            { 
                List<Bill_Model> list_BM = new List<Bill_Model>();
                var listTask = (from item in en.T_PACKAGE_TASK select item).Distinct().ToList();
                foreach (var item in listTask)
                {
                    Bill_Model bill_ = new Bill_Model(); 
                    var task = (from T_item in en.T_PACKAGE_TASK where T_item.SORTNUM == item.SORTNUM  select T_item).ToList();//获取单个任务信息
                    bill_.T_P_TASK = task;//单个任务集合
                    bill_.SortNum = item.SORTNUM ??0;
                    bill_.PackageSeqLength = (from l_item in en.T_PACKAGE_TASK select l_item).Max(a => a.ALLPACKAGESEQ) ?? 0;
                    list_BM.Add(bill_); 
                } 
                return list_BM;
            } 
        }
         
        /// <summary>
        /// 根据订单号包序返回订单详细
        /// </summary>
        /// <param name="List">订单信息</param>
        /// <param name="PackageIndex">包内序号</param> 
        /// <returns></returns>
        public List<TobaccoInfo> GetTobaccoInfos(List<Bill_Model> List, int PackageIndex , int Height,int Packageno)
        {
            List<TobaccoInfo> list = new List<TobaccoInfo>(); 
            if (List != null)
            {
                List<T_PACKAGE_TASK> t_s = new List<T_PACKAGE_TASK>();
                foreach (var item in List)
                {
                    foreach (var detail in item.T_P_TASK.Where(a => a.ALLPACKAGESEQ == PackageIndex && a.PACKAGENO == Packageno).ToList())
                    {
                        t_s.Add(detail);
                    }
                }
                foreach (var item in t_s)
                {
                    TobaccoInfo info = new TobaccoInfo();
                    info.TobaccoName = item.CIGARETTENAME;
                    info.TobaccoLength = (float)Convert.ToDouble(item.CIGLENGTH);
                    info.TobaccoWidth = (float)Convert.ToDouble(item.CIGWIDTH);
                    info.TobaccoHeight = (float)Convert.ToDouble(item.CIGHIGH);
                    info.GlobalIndex = Convert.ToInt32(item.CIGNUM ?? 0);
                    info.Speed = 1;
                    info.OrderIndex = Convert.ToInt32(item.PACKAGEQTY ?? 0);
                    info.CigType = item.CIGTYPE;//卷烟类型
                    info.PostionX = (float)Convert.ToDouble(item.CIGWIDTHX ?? 0) * 2;//坐标X
                    info.PostionY = Height - (float)Convert.ToDouble(item.CIGHIGHY ?? 0);//坐标Y 
                    list.Add(info);
                }
                return list;
            }
            else
            {
                return list;
            }
        }

 
    }
}
