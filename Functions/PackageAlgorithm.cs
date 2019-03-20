using EFModle;
using EFModle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Functions
{
    public class PackageAlgorithm
    {
        decimal gapWidth = 5; //烟之间间隙变量单位毫米
        decimal floatScope = 4; //允许超出限高的浮动范围单位毫米
        decimal umaxhigh = 196; //异型烟限高单位毫米
        decimal highnum = 3; //同一平面中允许的烟高度差(双抓高度差)
        decimal widthnum = 30; //同一平面中允许烟之间相隔宽度差
        decimal minwidth = 75; //同一平面中允许烟之间相隔宽度差
        decimal allhigh = 294;
        decimal width = 546;//工位宽度
        int CIGSEQ = 0;// 每包卷烟顺序
        int cignum = 0;
        int ORDERPACKAGENUM = 1; //订单总包数
        int ALLPACKAGESEQ = 1; //订单总包数
        string doubFlag = "0"; //双抓标志位
        int orderqty = 0;//订单总条烟数
        int packageno = 0;

        
        //查询所有订单
        List<PackageVo> sortN = new List<PackageVo>();

        PackageVo pack = new PackageVo(); //初始数据


        /// <summary>
        /// 初始数据
        /// </summary>
        public void Init()
        {
            pack.CigWidth = width;
            pack.SurplusWidth = width;
            pack.CigWidthX = Math.Ceiling(width / 2);
            pack.CigHighY = 0;
            sortN.Add(pack);
        }
        /// <summary>
        /// 运算异型烟 
        /// </summary>
        public void GetYXCigaretteOrderDate()
        {
            Init();
            var date = allyxydata_header(1);//所有异型烟订单头
            List<PACKAGEINFO_YXY> newdatas = new List<PACKAGEINFO_YXY>();
            foreach (var item in date)
            {
                //取出当前订单的明细
                List<PACKAGEINFO_YXY> xydata = package_yxy(item.BILLCODE);
                decimal sumcig = xydata.Sum(x => x.PACKAGEINFO.QUANTITY).Value;//
                for (int i = 0; i < xydata.Count; i++)
                {
                    T_PACKAGE_TASK nowtask = new T_PACKAGE_TASK();//当前条烟
                    T_PACKAGE_TASK nexttask = new T_PACKAGE_TASK();//下一条烟

                    Matching matching = new Matching();

                    matching.CigWidthX = 0;
                    matching.CigHighY = 0;
                    matching.CurrentHigh = xydata[i].IHEIGHT ?? 0;
                    matching.CurrentWidth = xydata[i].IWIDTH  ?? 0;
                    matching.DoubleTake = doubFlag;
                    matching.GapWidth = gapWidth;
                    matching.Highnum = highnum;

                    Matching newmatching = packageVo(sortN, xydata, matching, i);

                    //若所有平面宽度不满足来烟宽度则跳出并记录当前对象数组数据存入当前订单的集合中并开始下一包异型烟
                    if (newmatching.CigWidthX == 0 && newmatching.CigHighY ==0)
                    {
                        //if (!normalList.isEmpty())
                        //{
                        //    //匹配正常烟
                        //    matchingNormalList = matchingNormal(PVO, normalList, packageVo4, sumN);
                        //    PVO = (List<PackageVo>)matchingNormalList.get("PVO");
                        //    normalList = (List<PackageVo>)matchingNormalList.get("normalList");
                        //    PackageVo pVo = (PackageVo)matchingNormalList.get("packageVo");
                        //    CIGSEQ = pVo.getCIGSEQ();
                        //    cignum = pVo.getCignum();
                        //    sumN = (int)matchingNormalList.get("sumN");
                        //    matchingNormalList.clear();
                        //}
                        //else
                        //{
                            //纯异型烟
                                                                                    //for (int j = 0; j < PVO.size(); j++)
                                                                                    //{
                                                                                    //    PackageVo vo1 = PVO.get(j);
                                                                                    //    if (vo1.getPACKAGEQTY() == 0)
                                                                                    //    {
                                                                                    //        vo1.setPACKAGEQTY(CIGSEQ - 1);
                                                                                    //        cignum = cignum + 1;
                                                                                    //        vo1.setCignum(cignum);
                                                                                    //    }
                                                                                    //}
                        //}
                    }

                    //单抓
                    //loca数组记录来烟的顺序、宽、高、x、y、烟名字、当前平面剩余宽度 
                    //(x=((来烟宽度+gapWidth*2)/2)+(最低平面x轴坐标-((最低平面下层烟宽度+gapWidth*2)/2))+最低平面已用剩余平面，
                    //平面剩余宽度=来烟宽度,y=最低平面y轴坐标+来烟高度)
                    //并 计算当前最低平面剩余宽度(最低平面剩余宽度=最低平面剩余宽度-(来烟宽度+gapWidth*2));
                    nowtask.SORTNUM = xydata[i].PACKAGEINFO.TASKNUM;
                    nowtask.BILLCODE= xydata[i].PACKAGEINFO.BILLCODE;
                    nowtask.ALLPACKAGESEQ = ALLPACKAGESEQ;
                    nowtask.PACKAGENO = ORDERPACKAGENUM;
                    nowtask.CIGHIGH = xydata[i].IHEIGHT;
                    nowtask.CIGWIDTH = xydata[i].IWIDTH;
                    nowtask.CIGLENGTH = xydata[i].ILENGTH;
                    nowtask.CIGHIGHY = matching.CigHighY;
                    nowtask.CIGARETTECODE = xydata[i].PACKAGEINFO.CIGARETTECODE;
                    nowtask.CIGARETTENAME = xydata[i].PACKAGEINFO.CIGARETTENAME;
                    nowtask.NORMALQTY = 1;
                    nowtask.CIGTYPE = "3";
                    nowtask.ORDERDATE = xydata[i].PACKAGEINFO.ORDERDATE;
                    nowtask.PACKAGENO = xydata[i].PACKAGEINFO.EXPORT;
                    nowtask.ORDERQTY = xydata[i].PACKAGEINFO.QUANTITY;
//                    if (doubFlag=="0")
//                    {
//                        nowtask.DOUBLETAKE = doubFlag;
//                        nowtask.CIGSEQ = CIGSEQ;
//                        //条烟宽度的一半 + （平面的X坐标-平面宽度） +已用宽度 
//                        nowtask.CIGWIDTHX = (xydata[i].IWIDTH/2)+ newmatching.CigHighY + newmatching.CurrentWidth
//;
//                        packageVo1.setCigWidthX(((unnormalList.get(i).getCigWidth().add(gapWidth.multiply(new BigDecimal(2))))
//                            .divide(new BigDecimal(2), 0, BigDecimal.ROUND_CEILING)).add(widthx.subtract(sortN.get(index).getCigWidth()
//                            .divide(new BigDecimal(2), 0, BigDecimal.ROUND_CEILING))).add(sortN.get(index).getCigWidth()
//                            .subtract(sortN.get(index).getSurplusWidth())));
//                        packageVo1.setSurplusWidth(packageVo1.getCigWidth().add(gapWidth.multiply(new BigDecimal(2))));
//                    }
//                    else
//                    {
//                        packageVo1.setDoubleTake(doubFlag);
//                        packageVo1.setCIGSEQ(CIGSEQ);
//                        packageVo1.setCigWidthX((unnormalList.get(i).getCigWidth().add(unnormalList.get(i + 1).getCigWidth()).add(gapWidth.multiply(new BigDecimal(2)))).divide(new BigDecimal(2), 0, BigDecimal.ROUND_CEILING).add(widthx.subtract(sortN.get(index).getCigWidth().divide(new BigDecimal(2), 0, BigDecimal.ROUND_CEILING))).add(sortN.get(index).getCigWidth().subtract(sortN.get(index).getSurplusWidth())));
//                        packageVo1.setSurplusWidth(packageVo1.getCigWidth().add(gapWidth));

//                        CIGSEQ++;
//                        packageVo2.setOrderdate(unnormalList.get(i).getOrderdate());
//                        packageVo2.setPackageno(unnormalList.get(i + 1).getPackageno());
//                        packageVo2.setOrderqty(orderqty);
//                        packageVo2.setCigtype(2);
//                        packageVo2.setPokenum(1);
//                        packageVo2.setTasknum(unnormalList.get(i + 1).getTasknum());
//                        packageVo2.setDoubleTake(doubFlag);
//                        packageVo2.setBillcode(unnormalList.get(i + 1).getBillcode());
//                        packageVo2.setCIGSEQ(CIGSEQ);
//                        packageVo2.setPackageseq(ORDERPACKAGENUM);
//                        packageVo2.setALLPACKAGESEQ(ALLPACKAGESEQ);
//                        packageVo2.setCigWidth(unnormalList.get(i + 1).getCigWidth());
//                        packageVo2.setCigHigh(unnormalList.get(i + 1).getCigHigh());
//                        packageVo2.setCigLength(unnormalList.get(i + 1).getCigLength());
//                        packageVo2.setCigHighY(highy.add(packageVo1.getCigHigh()));
//                        packageVo2.setCigarettecode(unnormalList.get(i + 1).getCigarettecode());
//                        packageVo2.setCIGARETTENAME(unnormalList.get(i + 1).getCIGARETTENAME());
//                        packageVo2.setSurplusWidth(packageVo2.getCigWidth().add(gapWidth));
//                        packageVo2.setCigWidthX(packageVo1.getCigWidthX());
//                    }
                }


            }
        }





















        /// <summary>
        /// 查找平面
        /// </summary>
        /// <param name="packageVo">初始平面集合</param>
        /// <param name="data">订单明细</param>
        /// <param name="matching">初始参数</param>
        /// <param name="index">条烟索引</param>
        /// <returns></returns>
        public Matching packageVo(List<PackageVo> packageVo, List<PACKAGEINFO_YXY> data, Matching matching, int index)
        {
            //取最低平面的平面剩余宽度靠左摆放
            for (int m = 0; m < packageVo.Count; m++)
            {
                PackageVo vo = packageVo[m];
                //判断 (最低平面的平面剩余宽度<来烟宽度) 则取>=来烟宽度的较低平面作为最低平面;
                if (vo.SurplusWidth >= data[index].IWIDTH + gapWidth * 2)//加2边间隙
                {
                    if (matching.CigWidthX == 0 && matching.CigHighY == 0)
                    {
                        matching.CigWidthX = (int)(vo.CigWidthX);
                        matching.CigHighY = (int)(vo.CigHighY);
                        matching.Index = (int)(vo.Index);
                        continue;
                    }
                    if (matching.CigHighY > vo.CigHighY)
                    {
                        matching.CigWidthX = (int)vo.CigWidthX;
                        matching.CigHighY = (int)vo.CigHighY;
                        matching.Index = m;
                    }

                }
                //判断是否双抓
                if (vo.CigWidthX != 0 && vo.CigHighY != 0)
                {
                    if (index == data.Count - 1)
                    {
                        vo.doubFlag = 0;
                    }
                    else
                    {
                        //|当前来烟高度-下一条来烟高度| < 允许高度差（3）      
                        //当前条烟与下条来烟是否双抓
                        if (Math.Abs(Convert.ToDecimal(data[index].IHEIGHT - data[index + 1].IHEIGHT)) <= highnum && data[index].DOUBLETAKE == "1"
                            && data[index + 1].DOUBLETAKE == "1")
                        {
                            //判断当前来烟与下条来烟是否双抓
                            if (vo.SurplusWidth >= data[index].IWIDTH + data[index + 1].IWIDTH + gapWidth * 2)
                            {
                                matching.DoubleTake = "1";
                                matching.CurrentHigh = (decimal)(data[index].IHEIGHT < data[index + 1].IHEIGHT ? data[index + 1].IHEIGHT : data[index].IHEIGHT);
                                matching.CurrentWidth = (decimal)(data[index].IHEIGHT + data[index + 1].IHEIGHT);
                            }
                        }
                        else
                        {
                            matching.DoubleTake = "0";
                        }
                    }
                }
            }
            return matching;
        }




         







 

        public List< PACKAGEINFO_YXY> package_yxy(string BILLCODE)
        {
            using (Entities et=new Entities())
            {
                var data = et.V_PRODUCE_PACKAGEINFO.Where(x => x.BILLCODE == BILLCODE && x.ALLOWSORT == "非标").OrderBy(x => x.SENDTASKNUM).ThenBy(x => x.MACHINESEQ).ThenBy(x => x.TROUGHNUM).ToList();
                var list = (from item1 in data
                           join item2 in et.T_WMS_ITEM
                           on item1.CIGARETTECODE equals item2.ITEMNO
                           select new PACKAGEINFO_YXY{  PACKAGEINFO =item1, ILENGTH= item2.ILENGTH,  IWIDTH =item2.IWIDTH, IHEIGHT = item2.IHEIGHT,  DOUBLETAKE = item2.DOUBLETAKE }).ToList();
                return list;
            }
        }




























        public List<V_PRODUCE_PACKAGEINFO> allyxydata_header(decimal EXPORT)
        {
            using (Entities et = new Entities())
            {
                return et.V_PRODUCE_PACKAGEINFO.Where(x => x.EXPORT == packageno && x.EXPORT == EXPORT).GroupBy(x => new { x.BILLCODE, x.EXPORT, x.TASKNUM })
                    .Select(x => new V_PRODUCE_PACKAGEINFO { BILLCODE = x.Key.BILLCODE, EXPORT = x.Key.EXPORT, TASKNUM = x.Key.TASKNUM }).ToList();
            }
        }

        /// <summary>
        /// 所有分拣数据  包装机
        /// </summary>
        /// <returns></returns>
        public List<EFModle.V_PRODUCE_PACKAGEINFO> alldata(decimal packageno)
        {
            using (EFModle.Entities et= new EFModle.Entities())
            {
                return et.V_PRODUCE_PACKAGEINFO.Where(x => x.EXPORT == packageno).Select(x => x).ToList();
            }
        }
        /// <summary>
        /// 所有分拣数据
        /// </summary>
        /// <returns></returns>
        public List<EFModle.V_PRODUCE_PACKAGEINFO> alldata()
        {
            using (EFModle.Entities et = new EFModle.Entities())
            {
                return et.V_PRODUCE_PACKAGEINFO.OrderBy(x=>x.EXPORT).ThenBy(x=>x.TASKNUM).Select(x => x).ToList();
            }
        }
        /// <summary>
        /// 所有异型烟分拣数据  包装机
        /// </summary>
        /// <returns></returns>
        public List<EFModle.V_PRODUCE_PACKAGEINFO> yxydata(decimal packageno)
        {
            using (EFModle.Entities et = new EFModle.Entities())
            {
                return et.V_PRODUCE_PACKAGEINFO.Where(x => x.EXPORT == packageno && x.ALLOWSORT== "非标").Select(x => x).ToList();
            }
        }
        /// <summary>
        /// 所有异型烟分拣数据
        /// </summary>
        /// <returns></returns>
        public List<EFModle.V_PRODUCE_PACKAGEINFO> yxydata()
        {
            using (EFModle.Entities et = new EFModle.Entities())
            {
                return et.V_PRODUCE_PACKAGEINFO.Where(x => x.ALLOWSORT == "非标").Select(x => x).ToList();
            }
        }
        /// <summary>
        /// 所有常规烟分拣数据  包装机
        /// </summary>
        /// <returns></returns>
        public List<EFModle.V_PRODUCE_PACKAGEINFO> cgydata(decimal packageno)
        {
            using (EFModle.Entities et = new EFModle.Entities())
            {
                return et.V_PRODUCE_PACKAGEINFO.Where(x => x.EXPORT == packageno && x.ALLOWSORT == "分拣").Select(x => x).ToList();
            }
        }
        /// <summary>
        /// 所有常规烟分拣数据
        /// </summary>
        /// <returns></returns>
        public List<EFModle.V_PRODUCE_PACKAGEINFO> cgydata()
        {
            using (EFModle.Entities et = new EFModle.Entities())
            {
                return et.V_PRODUCE_PACKAGEINFO.Where(x => x.ALLOWSORT == "分拣").Select(x => x).ToList();
            }
        }
    }
}
