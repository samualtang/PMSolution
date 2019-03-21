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

         

        List<PackageVo> sortN = new List<PackageVo>();

        PackageVo pack = new PackageVo(); //初始数据


        /// <summary>
        /// 初始数据 平面
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
                    PackageVo nowtask = new PackageVo();//当前条烟
                    PackageVo nexttask = new PackageVo();//下一条烟

                    PackageVo matching = new PackageVo();

                    matching.CigWidthX = 0;
                    matching.CigHighY = 0;
                    matching.CurrentHigh = xydata[i].IHEIGHT ?? 0;
                    matching.CurrentWidth = xydata[i].IWIDTH ?? 0;
                    matching.DoubleTake = doubFlag;
                    matching.GapWidth = gapWidth;
                    matching.Highnum = highnum;

                    PackageVo newmatching = packageVo(sortN, xydata, matching, i);

                    //若所有平面宽度不满足来烟宽度则跳出并记录当前对象数组数据存入当前订单的集合中并开始下一包异型烟
                    if (newmatching.CigWidthX == 0 && newmatching.CigHighY == 0)
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
                    nowtask.Tasknum = xydata[i].PACKAGEINFO.TASKNUM ?? 0;
                    nowtask.Billcode = xydata[i].PACKAGEINFO.BILLCODE;
                    nowtask.ALLPACKAGESEQ = ALLPACKAGESEQ;
                    nowtask.Packageno = ORDERPACKAGENUM;
                    nowtask.CigHigh = xydata[i].IHEIGHT ?? 0;
                    nowtask.CigWidth = xydata[i].IWIDTH ?? 0;
                    nowtask.CigLength = xydata[i].ILENGTH ?? 0;
                    nowtask.CigHighY = matching.CigHighY+matching.CurrentHigh;
                    nowtask.Cigarettecode = xydata[i].PACKAGEINFO.CIGARETTECODE;
                    nowtask.CIGARETTENAME = xydata[i].PACKAGEINFO.CIGARETTENAME;
                    nowtask.Pokenum = 1;
                    nowtask.Cigtype = 2;
                    nowtask.Orderdate = xydata[i].PACKAGEINFO.ORDERDATE;
                    nowtask.Packageno = (int)xydata[i].PACKAGEINFO.EXPORT;
                    nowtask.Orderqty = (int)xydata[i].PACKAGEINFO.QUANTITY;
                    if (doubFlag == "0")
                    {
                        nowtask.DoubleTake = doubFlag;
                        nowtask.CIGSEQ = CIGSEQ;
                        //条烟的X坐标： 条烟宽度的一半 + （平面的X坐标-平面宽度/2） +已用宽度 
                        nowtask.CigWidthX = ((xydata[i].IWIDTH / 2) + (newmatching.CigWidthX - sortN[i].CigWidth / 2) + (sortN[i].CigWidth - sortN[i].SurplusWidth)) ?? 0;
                        //条烟工位剩余宽度：烟宽+间隙*2 
                        nowtask.SurplusWidth = nowtask.CigWidth + nowtask.GapWidth;
                    }
                    else
                    {
                        nowtask.DoubleTake = doubFlag;
                        nowtask.CIGSEQ = CIGSEQ;
                        nowtask.CigWidth = ((xydata[i].IWIDTH / 2) + (newmatching.CigWidthX - sortN[i].CigWidth / 2) + (sortN[i].CigWidth - sortN[i].SurplusWidth)) ?? 0;


                        //packageVo1.setCigWidthX((unnormalList.get(i).getCigWidth().add(unnormalList.get(i + 1).getCigWidth())
                         //   .add(gapWidth.multiply(new BigDecimal(2)))).divide(new BigDecimal(2), 0, BigDecimal.ROUND_CEILING)
                        //    .add(widthx.subtract(sortN.get(index).getCigWidth().divide(new BigDecimal(2), 0, BigDecimal.ROUND_CEILING)))
                       //     .add(sortN.get(index).getCigWidth().subtract(sortN.get(index).getSurplusWidth())));

                        //packageVo1.setSurplusWidth(packageVo1.getCigWidth().add(gapWidth));

                        CIGSEQ++;

                        nexttask.Orderdate = xydata[i + 1].PACKAGEINFO.ORDERDATE;
                        nexttask.Packageno = (int)xydata[i + 1].PACKAGEINFO.EXPORT;
                        nexttask.Orderqty = (int)xydata[i + 1].PACKAGEINFO.ORDERQUANTITY;
                        nexttask.Cigtype = 2;
                        nexttask.Pokenum = 1;
                        nexttask.Tasknum = xydata[i + 1].PACKAGEINFO.TASKNUM ?? 0;
                        nexttask.DoubleTake = doubFlag;
                        nexttask.Billcode = xydata[i + 1].PACKAGEINFO.BILLCODE;
                        nexttask.CIGSEQ = CIGSEQ;
                        nexttask.Packageseq = ORDERPACKAGENUM;
                        nexttask.ALLPACKAGESEQ = ALLPACKAGESEQ;
                        nexttask.CigWidth = xydata[i + 1].IWIDTH ?? 0;
                        nexttask.CigHigh = xydata[i + 1].IHEIGHT ?? 0;
                        nexttask.CigLength = xydata[i + 1].ILENGTH ?? 0;
                        nexttask.CigHighY = matching.CurrentHigh + matching.CigHighY;//卷烟Y
                        nexttask.Cigarettecode = xydata[i + 1].PACKAGEINFO.CIGARETTECODE;
                        nexttask.CIGARETTENAME = xydata[i + 1].PACKAGEINFO.CIGARETTENAME;
                        nexttask.CigWidthX = nowtask.CigWidthX;
                        nexttask.SurplusWidth = nexttask.CigWidth + gapWidth;
                         
                       }

                    //重组平面
                    PackageVo vo = new PackageVo();
                    vo.DoubleTake = matching.DoubleTake;
                    vo.CurrentHigh = matching.CurrentHigh;
                    vo.CurrentWidth = matching.CurrentWidth;
                    vo.CigHighY = matching.CigHighY;
                    vo.Highnum = matching.Highnum;
                    vo.GapWidth = matching.GapWidth;
                    vo.Widthnum = matching.Widthnum;
                    vo.GapWidth = gapWidth;
                    vo.Minwidth = minwidth;



                    var result = ResetPlane(sortN,nowtask,nexttask, matching, i);
                     

                }
            }
        }









 
        
        /// <summary>
        /// 重组平面：合并平面与添加新平面
        /// </summary>
        /// <param name="sortN">平面的集合</param>
        /// <param name="packageVo1">第一条烟</param>
        /// <param name="packageVo2">第二条烟</param>
        /// <param name="packageVo">重组平面的变量（放置两条烟的底平面）</param>
        /// <param name="index">平面的下标</param>
        /// <returns></returns>
        public List<PackageVo> ResetPlane(List<PackageVo> sortN, PackageVo packageVo1, PackageVo packageVo2, PackageVo packageVo, int index)
        {
            List<PackageVo> xy = new List<PackageVo>();
            //若可用位置小于等于75 平面无可用位置  
            //则重新计算x轴坐标，并移除当前平面（空隙利用）
            if ((sortN[index].SurplusWidth- (packageVo.CurrentWidth +packageVo.GapWidth * 2) <= packageVo.Minwidth) )
            {
                //第一条卷烟的X轴=第一条卷烟的X轴+当前平面的剩余宽度-（当前烟的宽度（可能两条）+两边间隙）/2
                packageVo1.CigWidthX = packageVo1.CigWidthX + sortN[index].SurplusWidth - Math.Ceiling((packageVo.CurrentWidth + packageVo.GapWidth * 2) / 2);
                if (packageVo.DoubleTake == "1")
                {
                    //第二条卷烟的X轴=第一条卷烟的X轴
                    packageVo2.CigWidthX = packageVo1.CigWidthX;
                    //第二条卷烟的平面剩余宽度=第二条卷烟的平面剩余宽度+ （底平面剩余宽度-烟宽度（可能两条）+ 两边间隙*2）/2
                    packageVo2.SurplusWidth = packageVo2.SurplusWidth + Math.Ceiling((sortN[index].SurplusWidth - packageVo.CurrentWidth + packageVo.GapWidth) / 2);
                }
                else
                {
                    packageVo1.SurplusWidth = packageVo1.SurplusWidth + sortN[index].SurplusWidth - Math.Ceiling((packageVo.CurrentWidth + packageVo.GapWidth * 2) / 2);
                }
                sortN.Remove(sortN[index]);
            }
            else
            {
                //可用位置大于75则重置平面可用宽度
                sortN[index].SurplusWidth = sortN[index].SurplusWidth - packageVo.CurrentWidth + packageVo.GapWidth / 2;
            }
            int flagT = 0;
            int indexSortN = -1;//记录平面下标
            for (int m = 0; m < sortN.Count; m++)
            {
                decimal subX = 0;
                if (sortN[m].CigWidthX <= packageVo1.CigWidthX)
                {
                    subX = packageVo.DoubleTake == "0"
                        ? packageVo1.CigWidthX - Math.Ceiling(packageVo1.SurplusWidth / 2) - Math.Ceiling(sortN[m].CigWidth / 2) - sortN[m].CigWidthX
                        : packageVo1.CigWidthX - packageVo1.SurplusWidth + Math.Ceiling(packageVo2.SurplusWidth / 2) - sortN[m].CigWidthX;
                }
                else
                {
                    subX = packageVo.DoubleTake == "0"
                        ? packageVo1.CigWidthX + Math.Ceiling(packageVo1.SurplusWidth / 2) + Math.Ceiling(sortN[m].CigWidth / 2) - sortN[m].CigWidthX
                        : packageVo2.CigWidthX + packageVo1.SurplusWidth + Math.Ceiling(packageVo2.SurplusWidth / 2) + Math.Ceiling(sortN[m].CigWidth / 2) - sortN[m].CigWidthX;
                }
                if (Math.Abs(sortN[m].CigWidthX - packageVo.CurrentWidth + packageVo.Highy) <= packageVo.Highnum)
                {
                    if (indexSortN != -1)
                    {
                        if ((sortN[indexSortN].CigWidthX + Math.Ceiling(sortN[indexSortN].CigWidth / 2) + Math.Ceiling(sortN[m].CigWidth / 2)) == sortN[m].CigWidthX)
                        {
                            sortN[indexSortN].CigWidth = sortN[indexSortN].CigWidth + sortN[m].CigWidth;
                            sortN[indexSortN].CigWidthX = sortN[indexSortN].CigWidthX + Math.Ceiling(sortN[m].CigWidth / 2);
                            sortN[indexSortN].SurplusWidth = sortN[indexSortN].SurplusWidth + sortN[m].SurplusWidth;
                            if (sortN[indexSortN].CigHighY <= sortN[m].CigHighY)
                            {
                                sortN[indexSortN].CigHighY = sortN[m].CigHighY;
                            }
                            sortN.Remove(sortN[m]);
                        }
                    }
                    else
                    {
                        if (Math.Abs(subX) <= packageVo.Widthnum)
                        {
                            if (subX < 0 || sortN[m].SurplusWidth < sortN[m].CigWidth)
                            {
                                break;
                            }
                            decimal cWidth = packageVo.DoubleTake == "0" ? packageVo1.SurplusWidth : packageVo1.SurplusWidth + packageVo2.SurplusWidth;
                            sortN[m].CigWidth = sortN[m].CigWidth + cWidth + Math.Abs(subX);
                            if (sortN[m].CigWidthX < packageVo1.CigWidthX)
                            {
                                sortN[m].CigWidthX = sortN[m].CigWidthX + Math.Ceiling((cWidth + Math.Abs(subX)) / 2);
                            }
                            else
                            {
                                sortN[m].CigWidthX = sortN[m].CigWidthX - Math.Ceiling((cWidth + Math.Abs(subX)) / 2);
                            }
                            sortN[m].SurplusWidth = sortN[m].SurplusWidth + cWidth + Math.Abs(subX);
                            if (sortN[m].CigHighY < packageVo.CurrentHigh + packageVo.Highy)
                            {
                                sortN[m].CigHighY = packageVo.CurrentHigh + packageVo.Highy;
                            }
                            if (indexSortN == -1)
                            {
                                indexSortN = m;
                            }
                            flagT = 1;
                        }
                    }
                }
                else if (Math.Abs(subX) < packageVo.Widthnum)//合并空隙并重新计算平面x轴，将空隙合并至低平面
                {
                    if (sortN[m].CigHighY < packageVo.CurrentHigh + packageVo.Highy)
                    {
                        sortN[m].SurplusWidth = sortN[m].SurplusWidth + Math.Abs(subX);
                        if (subX < 0)
                            sortN[m].CigWidthX = sortN[m].CigWidthX - Math.Ceiling(Math.Abs(subX) / 2);
                        else
                            sortN[m].CigWidthX = sortN[m].CigWidthX + Math.Ceiling(Math.Abs(subX) / 2);
                    }
                    else
                    {
                        packageVo1.SurplusWidth = packageVo1.SurplusWidth + Math.Abs(subX);
                        if (subX < 0)
                            packageVo1.CigWidthX = packageVo1.CigWidthX + Math.Ceiling(Math.Abs(subX) / 2);
                        else
                            packageVo1.CigWidthX = packageVo1.CigWidthX + Math.Ceiling(Math.Abs(subX) / 2);
                        if (packageVo.DoubleTake == "1")
                            packageVo2.CigWidthX = packageVo1.CigWidthX;
                    }
                }
            }
            //无平面可合并时创建一个新平面插入平面数组
            if (flagT == 0)
            {
                PackageVo vo = new PackageVo();
                if (packageVo.DoubleTake =="0")//单抓
                {
                    vo.CigWidth = packageVo1.SurplusWidth;
                    vo.SurplusWidth = packageVo1.SurplusWidth;
                    vo.CigHighY = packageVo.CurrentHigh + packageVo.Highy;
                    vo.CigWidthX = packageVo1.CigWidthX;
                }
                else//双抓
                {
                    vo.CigWidth = packageVo1.SurplusWidth + packageVo2.SurplusWidth;
                    vo.SurplusWidth = packageVo1.SurplusWidth + packageVo2.SurplusWidth;
                    vo.CigHighY = packageVo.CurrentHigh + packageVo.CigHighY;
                    vo.CigWidthX = packageVo1.CigWidthX;
                }
                sortN.Add(vo);//存入平面数组
            }
            xy.AddRange(sortN);
            xy.Add(packageVo1);
            xy.Add(packageVo2);

            return xy;
        }






        /// <summary>
        /// 查找平面
        /// </summary>
        /// <param name="packageVo">初始平面集合</param>
        /// <param name="data">订单明细</param>
        /// <param name="matching">初始参数</param>
        /// <param name="index">条烟索引</param>
        /// <returns></returns>
        public PackageVo packageVo(List<PackageVo> packageVo, List<PACKAGEINFO_YXY> data, PackageVo matching, int index)
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
                        vo.DoubleTake = "0";
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
