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

        public BillResolution()
        {
            using(Entities en = new Entities())
            {
                packageno = GlobalPara.PackageNo;
                var list = (from item in en.T_PACKAGE_TASK where item.PACKAGENO == packageno select item).ToList();
                if(list != null && list.Count >0)
                {
                    Length = (int)list.Max(a => a.ALLPACKAGESEQ ?? 0);

                }
                else
                {
                    Length =  1;
                }
               
            }
        }

        public int Length { get; }
        int packageno = 0;
        /// <summary>
        /// 根据订单号包序返回订单详细
        /// </summary>
        /// <param name="List">订单信息</param>
        /// <param name="PackageIndex">包内序号</param> 
        /// <returns></returns>
        public List<TobaccoInfo> GetTobaccoInfos( int PackageIndex , int Height )
        {
            List<TobaccoInfo> list = new List<TobaccoInfo>(); 
            using (Entities ne = new Entities())
            {
                var allInfo = (from item in ne.T_PACKAGE_TASK where item.ALLPACKAGESEQ == PackageIndex && item .PACKAGENO == packageno orderby item.CIGNUM select item).ToList() ;

                foreach (var item in allInfo)
                {
                    TobaccoInfo info = new TobaccoInfo
                    {
                        TobaccoName = item.CIGARETTENAME,
                        TobaccoLength = (float)Convert.ToDouble(item.CIGLENGTH),
                        TobaccoWidth = (float)Convert.ToDouble(item.CIGWIDTH),
                        TobaccoHeight = (float)Convert.ToDouble(item.CIGHIGH),
                        GlobalIndex = Convert.ToInt32(item.ALLPACKAGESEQ ?? 0),
                        CigNum = item.CIGNUM ?? 0,
                        DoubleTake = item.DOUBLETAKE  ,
                        SortNum = item.SORTNUM ?? 0,
                       
                        Speed = 1,
                        OrderIndex = Convert.ToInt32(item.CIGSEQ ?? 0),
                        CigType = item.CIGTYPE,//卷烟类型
                        PostionX = (float)Convert.ToDouble(Math.Ceiling(item.CIGWIDTHX ?? 0)),//坐标X
                        PostionY = Height - (float)Convert.ToDouble(item.CIGHIGHY ?? 0)//坐标Y  
                    };
                    if(item .CIGTYPE == "1")//常规烟 
                    {

                    }
                    list.Add(info);
                }
            

            } 
                return list;
         
        }

        public List<TobaccoInfo> GetUnNormallSort (  int CigNum)
        {
            List<TobaccoInfo> list = new List<TobaccoInfo>();
            using(Entities en = new Entities())
            {
                var uninfo = (from item in en.T_PACKAGE_TASK where item.CIGNUM > CigNum && item.PACKAGENO == packageno
                              orderby item.CIGNUM select item).ToList().Take(25);
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
