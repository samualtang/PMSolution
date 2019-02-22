using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFModle;
using EFModle.Model;
using Functions.PubFunction;
namespace Functions.BLL
{
   public class BillResolution
    {
        /// <summary>
        /// 取出订单信息
        /// </summary>
        /// <returns></returns>
        public List<Bill_Model> GetBillInfos(int packageNo)
        { 
            using (Entities en = new Entities())
            { 
                List<Bill_Model> list_BM = new List<Bill_Model>();
                var listTask = (from item in en.T_PACKAGE_TASK where item.PACKAGENO == packageNo select item).Distinct().ToList();
                foreach (var item in listTask)
                {
                    Bill_Model bill_ = new Bill_Model();  
                    bill_.T_P_TASK =  item   ;//单个任务集合
                    bill_.SortNum = item.SORTNUM ??0;
                    bill_.AllPackageSeq = item.ALLPACKAGESEQ ?? 0;
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
        public List<TobaccoInfo> GetTobaccoInfos( int PackageIndex , int Height )
        {
            List<TobaccoInfo> list = new List<TobaccoInfo>();
            int packageno = int.Parse(GlobalPara.GetConnectionStringsConfig("PackageNo"));
                List<T_PACKAGE_TASK> t_s = new List<T_PACKAGE_TASK>();
                foreach (var item in GetBillInfos(packageno).Where(a => a.AllPackageSeq == PackageIndex).ToList())
                {
                     
                        t_s.Add(item.T_P_TASK);
                    
                }
                foreach (var item in t_s)
                {
                    TobaccoInfo info = new TobaccoInfo
                    {
                        TobaccoName = item.CIGARETTENAME,
                        TobaccoLength = (float)Convert.ToDouble(item.CIGLENGTH),
                        TobaccoWidth = (float)Convert.ToDouble(item.CIGWIDTH),
                        TobaccoHeight = (float)Convert.ToDouble(item.CIGHIGH),
                        GlobalIndex = Convert.ToInt32(item.ALLPACKAGESEQ ?? 0),
                        CigNum = item.CIGNUM ?? 0,
                        Speed = 1,
                        OrderIndex = Convert.ToInt32(item.CIGSEQ ?? 0),
                        CigType = item.CIGTYPE,//卷烟类型
                        PostionX = (float)Convert.ToDouble(Math.Ceiling(item.CIGWIDTHX ?? 0)),//坐标X
                        PostionY = Height - (float)Convert.ToDouble(item.CIGHIGHY ?? 0)//坐标Y 
                    };
                    list.Add(info);
                }
                return list;
         
        }

        public List<TobaccoInfo> GetUnNormallSort (  int CigNum)
        {
            List<TobaccoInfo> list = new List<TobaccoInfo>();
            using(Entities en = new Entities())
            {
                var uninfo = (from item in en.T_PACKAGE_TASK where item.CIGNUM > CigNum
                              orderby item.CIGNUM select item).ToList();
                foreach (var item in uninfo)
                {
                    TobaccoInfo info = new TobaccoInfo
                    {
                        TobaccoName = item.CIGARETTENAME,
                        TobaccoLength = (float)Convert.ToDouble(item.CIGLENGTH),
                        TobaccoWidth = (float)Convert.ToDouble(item.CIGWIDTH),
                        TobaccoHeight = (float)Convert.ToDouble(item.CIGHIGH),
                        GlobalIndex = Convert.ToInt32(item.ALLPACKAGESEQ ?? 0),
                        CigNum = item.CIGNUM ?? 0,
                        Speed = 1,
                        OrderIndex = Convert.ToInt32(item.CIGSEQ ?? 0),
                        CigType = item.CIGTYPE,//卷烟类型 
                    };
                    list.Add(info);
                }
            }  
            return list;
        }




    }
}
