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
        decimal gapWidth = 2; //烟之间间隙变量单位毫米
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
        /// 运算
        /// </summary>
        public string GetCigaretteOrderDate()
        {
            string date1 = System.DateTime.Now.ToString();
            PackageVo packageVo1;//当前条烟
            PackageVo packageVo2;//下一条烟
            PackageVo packageVo3;
            PackageVo packageVo4;

            List<PackageVo> PVO = new List<PackageVo>();
            Init();
            var date = alldata_header(3);//所有订单头
            List<PACKAGEINFO_All> newdatas = new List<PACKAGEINFO_All>();
            foreach (var item in date)
            {
                string sadfsfsdf;
                //取出当前订单的明细
                List<PACKAGEINFO_All> unnormalList = package_yxy(item.BILLCODE);
                List<PACKAGEINFO_All> normalList = package_cgy(item.BILLCODE);
                decimal sumcig = unnormalList.Sum(x => x.PACKAGEINFO.QUANTITY).Value;//
                for (int i = 0; i < unnormalList.Count; i++)
                {
                    if (i >= 4)
                    {
                        sadfsfsdf = unnormalList[i].PACKAGEINFO.CIGARETTENAME;
                    }
                    decimal widthx = 0; //平面x轴坐标
                    decimal highy = 0; //平面y轴坐标
                    int index = 0; //平面PackageVo下标
                    decimal currentWidth = unnormalList[i].IWIDTH ; //双、单抓烟宽
                    decimal currentHigh = unnormalList[i].IHEIGHT ; //双、单抓烟宽

                    packageVo1 = null;//当前条烟
                    packageVo2 = null;//下一条烟 
                    packageVo3 = null;//初始平面
                    packageVo4 = null;//

                    packageVo1 = new PackageVo();//当前条烟
                    packageVo2 = new PackageVo();//下一条烟 
                    packageVo3 = new PackageVo();//初始平面
                    packageVo4 = new PackageVo();//

                  

                    packageVo3.CigWidthX = 0;
                    packageVo3.CigHighY = 0;
                    packageVo3.CurrentHigh = currentHigh ;
                    packageVo3.CurrentWidth = currentWidth ;
                    packageVo3.DoubleTake = doubFlag;
                    packageVo3.GapWidth = gapWidth;
                    packageVo3.Highnum = highnum;

                    //其他参数信息
                    packageVo4.Allhigh = allhigh;
                    packageVo4.ORDERPACKAGENUM = ORDERPACKAGENUM;
                    packageVo4.Cignum = cignum;
                    packageVo4.ALLPACKAGESEQ = ALLPACKAGESEQ;
                    packageVo4.CIGSEQ = CIGSEQ;
                    packageVo4.GapWidth = gapWidth;//间隙
                    packageVo4.Width = width;
                    packageVo4.Orderqty = orderqty;
                    CIGSEQ++;//包内烟序

                    selPlane(sortN, unnormalList, packageVo3, i);
                    widthx = packageVo3.CigWidthX;//平面x轴坐标
                    highy = packageVo3.CigHighY;//平面Y轴坐标
                    index = packageVo3.Index;//平面下标
                    doubFlag = packageVo3.DoubleTake;//双抓标志
                    currentHigh = packageVo3.CurrentHigh;//单、双抓高度
                    currentWidth = packageVo3.CurrentWidth;//单、双抓宽度 

                    //若所有平面宽度不满足来烟宽度则跳出并记录当前对象数组数据存入当前订单的集合中并开始下一包异型烟
                    if (widthx == 0 && highy == 0)
                    {
                        if (normalList.Count> 0)
                        {
                            //匹配正常烟
                            //matchingNormalList = matchingNormal(PVO, normalList, packageVo4, sumN);
                            //PVO = (List<PackageVo>)matchingNormalList.("PVO");
                            //normalList = (List<PackageVo>)matchingNormalList.("normalList");
                            //PackageVo pVo = (PackageVo)matchingNormalList.("packageVo");
                            //CIGSEQ = pVo.CIGSEQ();
                            //cignum = pVo.Cignum();
                            //sumN = (int)matchingNormalList.("sumN");
                            //matchingNormalList.clear();
                        }
                        else
                        {
                            //纯异型烟
                            for (int j = 0; j < PVO.Count; j++)
                            {
                                PackageVo vo1 = PVO[i];
                                if (vo1.PACKAGEQTY == 0)
                                {
                                    vo1.PACKAGEQTY=CIGSEQ - 1;
                                    cignum = cignum + 1;
                                    vo1.Cignum = cignum;
                                }
                            }
                        }
                        //初始化数据
                        sortN = new List<PackageVo>();
                        pack = new PackageVo(); //初始数据
                        pack.SurplusWidth=width; //初始工位剩余宽度
                        pack.CigWidth=width; //初始工位宽度
                        pack.CigHighY=0;
                        pack.CigHigh=0;
                        pack.Index = 0;
                        pack.CigWidthX=Math.Ceiling(width/2);
                        sortN.Add(pack);
                        ALLPACKAGESEQ++;//整体包序
                        ORDERPACKAGENUM++;//订单包序、订单总包数
                        CIGSEQ = 1;//包序


                        //查找平面
                        selPlane(sortN, unnormalList, packageVo3, i); 
                        widthx = packageVo3.CigWidthX;
                        highy = packageVo3.CigHighY;
                        index = packageVo3.Index;
                        doubFlag = packageVo3.DoubleTake;
                        currentHigh = packageVo3.CurrentHigh;
                        currentWidth = packageVo3.CurrentWidth; 

                    }

                    //最低平面的平面高度+来烟高度 > umaxhigh+floatScope 超出限高允许的浮动范围,则跳出并记录当前对象数组数据存入当前订单的集合中并开始下一包异型烟
                    if (highy + currentHigh > umaxhigh + floatScope)
                    {
                        if (normalList.Count > 0)
                        {
                            //匹配正常烟
                            //matchingNormalList = matchingNormal(PVO, normalList, packageVo4, sumN);
                            //PVO = (List<PackageVo>)matchingNormalList.("PVO");
                            //normalList = (List<PackageVo>)matchingNormalList.("normalList");
                            //PackageVo pVo = (PackageVo)matchingNormalList.("packageVo");
                            //CIGSEQ = pVo.CIGSEQ();
                            //cignum = pVo.Cignum();
                            //sumN = (int)matchingNormalList.("sumN");
                            //matchingNormalList.clear();
                        }
                        else
                        {
                            //纯异型烟
                            for (int j = 0; j < PVO.Count(); j++)
                            {
                                PackageVo vo1 = PVO[j];
                                if (vo1.PACKAGEQTY == 0)
                                {
                                    vo1.PACKAGEQTY = CIGSEQ - 1;
                                    cignum = cignum + 1;
                                    vo1.Cignum = cignum;
                                }
                            }
                        }
                        //初始化数据
                        sortN = new List<PackageVo>();
                        pack = new PackageVo(); //初始数据
                        pack.SurplusWidth=width; //初始工位剩余宽度
                        pack.CigWidth=width; //初始工位宽度
                        pack.CigHighY=0;
                        pack.CigHigh=0;
                        pack.CigWidthX = Math.Ceiling(width / 2);
                        sortN.Add(pack);
                        ALLPACKAGESEQ++;
                        ORDERPACKAGENUM++;
                        CIGSEQ = 1;

                        //查找平面
                        selPlane(sortN, unnormalList, packageVo3, i);

                        widthx = packageVo3.CigWidthX;
                        highy = packageVo3.CigHighY;
                        index = packageVo3.Index;
                        doubFlag = packageVo3.DoubleTake;
                        currentHigh = packageVo3.CurrentHigh;
                        currentWidth = packageVo3.CurrentWidth;

                    }


                    //单抓
                    //loca数组记录来烟的顺序、宽、高、x、y、烟名字、当前平面剩余宽度 
                    //(x=((来烟宽度+gapWidth*2)/2)+(最低平面x轴坐标-((最低平面下层烟宽度+gapWidth*2)/2))+最低平面已用剩余平面，
                    //平面剩余宽度=来烟宽度,y=最低平面y轴坐标+来烟高度)
                    //并 计算当前最低平面剩余宽度(最低平面剩余宽度=最低平面剩余宽度-(来烟宽度+gapWidth*2));
                    packageVo1.Tasknum = unnormalList[i].PACKAGEINFO.TASKNUM;
                    packageVo1.Billcode = unnormalList[i].PACKAGEINFO.BILLCODE;
                    packageVo1.ALLPACKAGESEQ = ALLPACKAGESEQ;
                    packageVo1.Packageno = ORDERPACKAGENUM;
                    packageVo1.CigHigh = unnormalList[i].IHEIGHT ;
                    packageVo1.CigWidth = unnormalList[i].IWIDTH ;
                    packageVo1.CigLength = unnormalList[i].ILENGTH ;
                    packageVo1.CigHighY = packageVo3.CigHighY + packageVo3.CurrentHigh;
                    packageVo1.Cigarettecode = unnormalList[i].PACKAGEINFO.CIGARETTECODE;
                    packageVo1.CIGARETTENAME = unnormalList[i].PACKAGEINFO.CIGARETTENAME;
                    packageVo1.Pokenum = 1;
                    packageVo1.Cigtype = 2;
                    packageVo1.Orderdate = unnormalList[i].PACKAGEINFO.ORDERDATE;
                    packageVo1.Packageno = (int)unnormalList[i].PACKAGEINFO.EXPORT;
                    packageVo1.Orderqty = (int)unnormalList[i].PACKAGEINFO.QUANTITY;
                    if (doubFlag == "0")
                    {
                        packageVo1.DoubleTake = doubFlag;
                        packageVo1.CIGSEQ = CIGSEQ;
                        
                        //条烟的X坐标： （条烟宽度+两边间隙）/2 + （平面的X坐标-平面宽度/2） +已用宽度 
                        packageVo1.CigWidthX = Math.Ceiling((unnormalList[i].IWIDTH + (gapWidth * 2)) / 2)
                            + (sortN[index].CigWidthX - Math.Ceiling(sortN[index].CigWidth / 2)) + sortN[index].CigWidth - sortN[index].SurplusWidth;
                        
                        //条烟工位剩余宽度：烟宽+间隙*2 
                        packageVo1.SurplusWidth = packageVo1.CigWidth + gapWidth*2;
                    }
                    else
                    {
                        packageVo1.DoubleTake = doubFlag;
                        packageVo1.CIGSEQ = CIGSEQ;
                        packageVo1.CigWidthX = Math.Ceiling((unnormalList[i].IWIDTH + unnormalList[i + 1].IWIDTH + gapWidth * 2) / 2)
                            + (widthx - Math.Ceiling(sortN[index].CigWidth / 2)) + (sortN[index].CigWidth - sortN[index].SurplusWidth);

                        packageVo1.SurplusWidth = packageVo1.CigWidth + gapWidth;
                        
                        CIGSEQ++;

                        packageVo2.Orderdate = unnormalList[i + 1].PACKAGEINFO.ORDERDATE;
                        packageVo2.Packageno = (int)unnormalList[i + 1].PACKAGEINFO.EXPORT;
                        packageVo2.Orderqty = (int)unnormalList[i + 1].PACKAGEINFO.ORDERQUANTITY;
                        packageVo2.Cigtype = 2;
                        packageVo2.Pokenum = 1;
                        packageVo2.Tasknum = unnormalList[i + 1].PACKAGEINFO.TASKNUM ;
                        packageVo2.DoubleTake = doubFlag;
                        packageVo2.Billcode = unnormalList[i + 1].PACKAGEINFO.BILLCODE;
                        packageVo2.CIGSEQ = CIGSEQ;
                        packageVo2.Packageseq = ORDERPACKAGENUM;
                        packageVo2.ALLPACKAGESEQ = ALLPACKAGESEQ;
                        packageVo2.CigWidth = unnormalList[i + 1].IWIDTH ;
                        packageVo2.CigHigh = unnormalList[i + 1].IHEIGHT ;
                        packageVo2.CigLength = unnormalList[i + 1].ILENGTH ;
                        packageVo2.CigHighY = packageVo3.CurrentHigh + packageVo3.CigHighY;//卷烟Y
                        packageVo2.Cigarettecode = unnormalList[i + 1].PACKAGEINFO.CIGARETTECODE;
                        packageVo2.CIGARETTENAME = unnormalList[i + 1].PACKAGEINFO.CIGARETTENAME;
                        packageVo2.CigWidthX = packageVo1.CigWidthX;
                        packageVo2.SurplusWidth = packageVo2.CigWidth - gapWidth;

                    }

                    //重组平面
                    PackageVo vo = new PackageVo();
                    vo.DoubleTake = doubFlag;
                    vo.CurrentHigh = currentHigh;
                    vo.CurrentWidth = currentWidth;
                    vo.CigHighY = highy;
                    vo.Highnum = highnum;
                    vo.Widthnum = widthnum;
                    vo.GapWidth = gapWidth;
                    vo.Minwidth = minwidth;



                    ResetPlane(sortN, packageVo1, packageVo2, vo, index);
                    PVO.Add(packageVo1);//插入以算的数据
                    if (packageVo2.CigWidthX != 0)
                        PVO.Add(packageVo2);


                    //当订单数组中最后一条数据时匹配正常烟并初始化数据
                    if (i == unnormalList.Count - 1 || (doubFlag == "1" && i == unnormalList.Count - 2))
                    {
                        if (normalList != null)
                        {
                            //------------
                        }
                        else//纯异型烟
                        {
                            for (int j = 0; j < PVO.Count; j++)
                            {
                                PackageVo vo1 = PVO[j];
                                if (vo1.PACKAGEQTY == 0)
                                {
                                    vo1.PACKAGEQTY = CIGSEQ;
                                    cignum += 1;
                                    vo1.Cignum = cignum;
                                }
                            }
                        }

                        unnormalList = new List<PACKAGEINFO_All>();//初始化数据
                        sortN = new List<PackageVo>();//初始化平面数据
                        packageVo3.SurplusWidth = width;//初始工位剩余宽度
                        packageVo3.CigWidth = width;//初始工位宽度
                        packageVo3.CigHighY = 0;
                        packageVo3.CigHigh = 0;
                        packageVo3.Index = 0;
                        packageVo3.CigWidthX = Math.Ceiling(width / 2);
                        sortN.Add(packageVo3);
                        ALLPACKAGESEQ++;

                        if (normalList != null)
                        {
                            ORDERPACKAGENUM++;
                        }
                        else
                        {
                            //当订单内正常烟、异型烟都已计算完毕后插入订单总包数
                            for (int t = 0; t < PVO.Count; t++)
                            {
                                PackageVo vo1 = PVO[i];
                                if (vo1.ORDERPACKAGENUM == 0)
                                {
                                    vo1.ORDERPACKAGENUM = ORDERPACKAGENUM;
                                }
                            }
                            ORDERPACKAGENUM = 1;
                        }
                        CIGSEQ = 0;



                    }
                    //重置双抓标志
                    if (doubFlag == "1")
                    {
                        i = i + 1;
                        doubFlag = "0";
                    }

                }
                //纯正常烟包
                if (unnormalList.Count == 0 && normalList.Count != 0)
                {
                    PackageVo vo = new PackageVo();
                    vo.ALLPACKAGESEQ = ALLPACKAGESEQ;
                    vo.Cignum = cignum;
                    vo.Orderqty = orderqty;
                    vo.ORDERPACKAGENUM = ORDERPACKAGENUM;

                    //matchingNormalList = normalList(sumN, PVO, normalList, vo);
                    //PVO = (List<PackageVo>)matchingNormalList.("PVO");
                    //vo = (PackageVo)matchingNormalList.("packageVo");
                    //ALLPACKAGESEQ = vo.ALLPACKAGESEQ();
                    //ORDERPACKAGENUM = vo.ORDERPACKAGENUM();
                    //cignum = vo.Cignum();
                }

            }
            string date2 = System.DateTime.Now.ToString();

            DataInsert(PVO);
            return date1 + "  " + date2;
        }


        #region.
        //合包（匹配正常烟）
        public void matchingNormal(List<PackageVo> PVO, List<PackageVo> normalList, PackageVo packageVo, int sumN)
        {
            decimal maxHigh = new decimal(0);
            decimal sumwidth = new decimal(0);
            int sumCignum = 0;//记录异型烟数量
            for (int i = 0; i < PVO.Count(); i++)
            {
                PackageVo vo = PVO[i];
                if (vo.PACKAGEQTY == 0)
                {
                    if (maxHigh<vo.CigHighY) maxHigh = vo.CigHighY;
                    sumwidth = sumwidth+vo.SurplusWidth;
                    sumCignum++;
                }
            }
            //计算合包正常烟数量
            int tier = (int)(packageVo.Allhigh - Math.Floor(maxHigh / 49) * 6);
            int tier1 = (tier > 24) ? 24 : tier;
            if (sumwidth<=(packageVo.Width) )
            {
                tier1 = tier = (int)(18 + packageVo.Width - Math.Floor(sumwidth/ 91)) ;
                if ((sumN < 36 && sumN % 6 <= Math.Floor((packageVo.Width - sumwidth) / 91))
                        || sumN < 30)
                {
                    tier1 = tier = sumN;
                }
            }
            else if ((sumN < tier && tier % 6 != 0) || sumN == 0)
            {
                for (int i = 0; i < PVO.Count; i++)
                {
                    PackageVo vo = PVO[i];
                    if (vo.PACKAGEQTY == 0)
                    {
                        packageVo.Cignum = packageVo.Cignum + 1 ;
                        vo.Cignum=packageVo.Cignum;
                        vo.Pushspace=0;
                        vo.PACKAGEQTY=packageVo.CIGSEQ;
                        vo.Unionpackagestate=0;
                        vo.Cigtype=2;
                    }
                }
                tier1 = 0;
            }
            else if (sumN < tier && tier % 6 == 0)
            {
                tier1 = tier = sumN;
            }
            if (sumN - tier < 6 && sumN - tier != 0) tier1 = tier = tier - 6;
            if (tier != 0)
            {
                for (int n = 0; n < PVO.Count; n++)
                {
                    if (PVO[n].PACKAGEQTY == 0)
                    {
                        if (tier1 % 6 <= (int)(packageVo.Width-Math.Floor(sumwidth)/91) && packageVo.Width-sumwidth> 91 )
                        {
                            PVO[n].CigWidthX = packageVo.Width - packageVo.GapWidth - PVO[n].CigWidthX;
                        }
                        PVO[n].Cignum = packageVo.Cignum + tier + PVO[n].CIGSEQ;
                        PVO[n].Packageseq = packageVo.ORDERPACKAGENUM;
                        PVO[n].PACKAGEQTY = packageVo.CIGSEQ + tier;
                        PVO[n].Pushspace = tier % 6 == 0 ? tier / 6 : (tier / 6) + 1;
                        PVO[n].Unionpackagestate = 1;
                        PVO[n].Cigtype = 2;
                    }
                }
                sumN = sumN - tier;
                List<PackageVo> normalVoList = new List<PackageVo>();
                for (int j = 0; j < normalList.Count; j++)
                {
                    PackageVo vo1 = new PackageVo();
                    vo1.Cigarettecode=normalList[j].Cigarettecode;
                    vo1.CIGARETTENAME=normalList[j].CIGARETTENAME;
                    vo1.Billcode=normalList[j].Billcode;
                    vo1.Tasknum=normalList[j].Tasknum;
                    vo1.CigWidthX=0;
                    vo1.CigHigh=0;
                    vo1.Orderqty=packageVo.Orderqty;
                    vo1.Packageno=normalList[j].Packageno;
                    vo1.CigWidth=0;
                    vo1.CigHighY=0;
                    vo1.CigLength=0;
                    vo1.CigZ=0;
                    vo1.Cigtype=1;
                    vo1.Orderdate = normalList[j].Orderdate;
                    if (tier1 != 0 && normalList.Count != 0)
                    {
                        packageVo.Cignum =packageVo.Cignum + normalList[j].Pokenum;
                        vo1.Cignum=packageVo.Cignum;
                        vo1.PACKAGEQTY=packageVo.CIGSEQ + tier;
                        vo1.Pushspace = tier % 6 == 0 ? tier / 6 : tier / 6 + 1;
                        vo1.Unionpackagestate = 1;
                        vo1.Packageseq = packageVo.ORDERPACKAGENUM;
                        vo1.ALLPACKAGESEQ = packageVo.ALLPACKAGESEQ;
                        if (tier1 >= normalList[j].Pokenum) 
                        {
                            tier1 = tier1 - normalList[j].Pokenum;
                            vo1.Pokenum = normalList[j].Pokenum;
                            normalList.Remove(normalList[j]);
                        }
                        else
                        {
                            packageVo.Cignum=packageVo.Cignum - normalList[j].Pokenum + tier1;
                            normalList[j].Pokenum=normalList[j].Pokenum - tier1;
                            vo1.Pokenum=tier1;
                            vo1.Cignum=packageVo.Cignum;
                            tier1 = 0;
                        }
                        j = j - 1;
                        PVO.Add(vo1);
                    }
                }
                packageVo.Cignum = packageVo.Cignum + sumCignum;
            }
             
        }


        //单独正常烟
        public void normalList(int sumN, List<PackageVo> PVO, List<PackageVo> normalList, PackageVo packageVo)
        {
            int flagN = 0;//记录剩余条烟数量
                          //计算下一包正常烟包烟数量
            int flagEnd = flagN = (sumN > 36 && sumN < 42) ? (sumN / 2) : (sumN < 36) ? sumN : 36;
            List<PackageVo> normalVoList = new List<PackageVo>();
            for (int i = 0; i < normalList.Count ; i++)
            {
                PackageVo vo1 = new PackageVo();
                vo1.Cigarettecode = normalList[i].Cigarettecode;
                vo1.CIGARETTENAME = normalList[i].CIGARETTENAME;
                vo1.Billcode = normalList[i].Billcode;
                vo1.Tasknum = normalList[i].Tasknum;
                vo1.CigWidthX=0;
                vo1.CigHigh=0;
                vo1.CigWidth=0;
                vo1.CigHighY=0;
                vo1.CigLength=0;
                vo1.CigZ = 0;
                vo1.Packageno = normalList[i].Packageno;
                vo1.Cigtype = 1;
                vo1.Orderdate = normalList[i].Orderdate;
                vo1.Orderqty = packageVo.Orderqty;
                packageVo.Cignum = packageVo.Cignum + normalList[i].Pokenum;//条烟流水号
                vo1.Cignum = packageVo.Cignum;
                vo1.Pushspace = 0;
                vo1.Unionpackagestate = 0;
                vo1.Packageseq = packageVo.ORDERPACKAGENUM;
                vo1.ALLPACKAGESEQ = packageVo.ALLPACKAGESEQ;
                //当剩余条烟数量>=来烟pokenum则移除当前烟数据并减少剩余条烟数量
                if (flagN >= normalList[i].Pokenum)
                {
                    flagN = flagN - normalList[i].Pokenum;//更新剩余条烟数量
                    vo1.Pokenum=normalList[i].Pokenum;//存入正常烟数量
                    normalList.Remove(normalList[i]);
                }
                else
                {//剩余条烟<来烟pokenum则重置当前来烟pokenum数量
                    packageVo.Cignum = packageVo.Cignum - normalList[i].Pokenum + flagN;
                    normalList[i].Pokenum = normalList[i].Pokenum - flagN;
                    vo1.Pokenum = flagN;//存入正常烟数量
                    vo1.Cignum = packageVo.Cignum;
                    flagN = 0;//更新剩余条烟数量
                }
                normalVoList.Add(vo1);
                if (flagN == 0 || i == normalList.Count)
                {
                    //存入当前包总条烟数
                    foreach(var item in normalVoList)
                    {
                        PackageVo pl = new PackageVo();
                        if (pl.PACKAGEQTY == 0) pl.PACKAGEQTY=flagEnd;
                    }
                    PVO.AddRange(normalVoList);
                    if (i == normalList.Count())
                    {
                        for (int j = 0; j < PVO.Count; j++)
                        {
                            PackageVo vo = PVO[j];
                            //存入订单总包数
                            if (vo.ORDERPACKAGENUM == 0)
                            {
                                vo.ORDERPACKAGENUM = packageVo.ORDERPACKAGENUM;
                            }
                        }
                        packageVo.ORDERPACKAGENUM = 1;
                    }
                    else packageVo.ORDERPACKAGENUM = packageVo.ORDERPACKAGENUM + 1;
                    packageVo.ALLPACKAGESEQ = packageVo.ALLPACKAGESEQ + 1;
                    normalVoList = new List<PackageVo>();
                    sumN = sumN - flagEnd;
                    flagN = (sumN > 36 && sumN < 42) ? (sumN / 2) : (sumN < 36) ? sumN : 36;
                    flagEnd = flagN;
                }
                i = i - 1;
            }
        }

        #endregion


        /// <summary>
        /// 重组平面：合并平面与添加新平面
        /// </summary>
        /// <param name="sortN">平面的集合</param>
        /// <param name="packageVo1">第一条烟</param>
        /// <param name="packageVo2">第二条烟</param>
        /// <param name="packageVo">重组平面的变量（放置两条烟的底平面）</param>
        /// <param name="index">平面的下标</param>
        /// <returns></returns>
        public void ResetPlane(List<PackageVo> sortN, PackageVo packageVo1, PackageVo packageVo2, PackageVo packageVo, int index)
        {
            //若可用位置小于等于75 平面无可用位置  
            //则重新计算x轴坐标，并移除当前平面（空隙利用）
            if ((sortN[index].SurplusWidth- (packageVo.CurrentWidth +packageVo.GapWidth * 2) <= packageVo.Minwidth) )//-*****************1
            {
                //第一条卷烟的X轴=第一条卷烟的X轴+(当前平面的剩余宽度-（当前烟的宽度（可能两条）+两边间隙）)/2
                packageVo1.CigWidthX = packageVo1.CigWidthX + (sortN[index].SurplusWidth - Math.Ceiling(packageVo.CurrentWidth + packageVo.GapWidth * 2)) / 2;
                if (packageVo.DoubleTake == "1")
                {
                    //第二条卷烟的X轴=第一条卷烟的X轴
                    packageVo2.CigWidthX = packageVo1.CigWidthX;
                    //第二条卷烟的平面剩余宽度=第二条卷烟的平面剩余宽度+ （底平面剩余宽度-烟宽度（可能两条）+ 两边间隙*2）/2
                    packageVo2.SurplusWidth = packageVo2.SurplusWidth + Math.Ceiling((sortN[index].SurplusWidth - packageVo.CurrentWidth + packageVo.GapWidth * 2) / 2);
                }
                else
                {
                    packageVo1.SurplusWidth = packageVo1.SurplusWidth + Math.Ceiling((sortN[index].SurplusWidth - (packageVo.CurrentWidth + packageVo.GapWidth * 2)) / 2);
                }
                sortN.Remove(sortN[index]);
            }
            else
            {
                //可用位置大于75则重置平面可用宽度
                sortN[index].SurplusWidth = sortN[index].SurplusWidth - (packageVo.CurrentWidth + packageVo.GapWidth * 2);
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
                        : packageVo1.CigWidthX - Math.Ceiling((packageVo1.SurplusWidth + packageVo2.SurplusWidth) / 2) - sortN[m].CigWidthX;
                }
                else
                {
                    subX = packageVo.DoubleTake == "0"
                        ? packageVo1.CigWidthX + Math.Ceiling(packageVo1.SurplusWidth / 2) + Math.Ceiling(sortN[m].CigWidth / 2) - sortN[m].CigWidthX
                        : packageVo2.CigWidthX + Math.Ceiling((packageVo1.SurplusWidth + packageVo2.SurplusWidth) / 2) + Math.Ceiling(sortN[m].CigWidth / 2) - sortN[m].CigWidthX;
                }
                if (Math.Abs(sortN[m].CigHighY - packageVo.CurrentHigh + packageVo.Highy) <= packageVo.Highnum)
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
                        if (Math.Abs(subX) <= packageVo.Widthnum)//??为0？
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
             
        }






        /// <summary>
        /// 查找平面
        /// </summary>
        /// <param name="sortN">初始平面集合</param>
        /// <param name="unnormalList">订单明细</param>
        /// <param name="packageVo">初始参数</param>
        /// <param name="index">条烟索引</param>
        /// <returns></returns>
        public void selPlane(List<PackageVo> sortN, List<PACKAGEINFO_All> unnormalList, PackageVo packageVo, int i)
        {
            string sadfsfsdf;
            if (i >= 5)
            {
                sadfsfsdf = unnormalList[i].PACKAGEINFO.CIGARETTENAME;
            }
            PackageVo vo;
            //取最低平面的平面剩余宽度靠左摆放
            for (int m = 0; m < sortN.Count; m++)
            {
                vo = sortN[m];
                //判断 (最低平面的平面剩余宽度<来烟宽度) 则取>=来烟宽度的较低平面作为最低平面;
                if (vo.SurplusWidth >= unnormalList[i].IWIDTH + gapWidth * 2)//加2边间隙
                {
                    if (packageVo.CigWidthX == 0 && packageVo.CigHighY == 0)
                    {
                        packageVo.CigWidthX = vo.CigWidthX;
                        packageVo.CigHighY = vo.CigHighY;
                        packageVo.Index = m ;
                        continue;
                    }
                    if (packageVo.CigHighY > vo.CigHighY)
                    {
                        packageVo.CigWidthX = (int)vo.CigWidthX;
                        packageVo.CigHighY = (int)vo.CigHighY;
                        packageVo.Index = m;
                    }

                }
                //判断是否双抓
                if (packageVo.CigWidthX != 0 && packageVo.CigHighY != 0)
                {
                    if (i == unnormalList.Count - 1)
                    {
                        packageVo.DoubleTake = "0";
                    }
                    else
                    {
                        //|当前来烟高度-下一条来烟高度| < 允许高度差（3）      
                        //当前条烟与下条来烟是否双抓
                        if (Math.Abs(Convert.ToDecimal(unnormalList[i].IHEIGHT - unnormalList[i + 1].IHEIGHT)) <= highnum && unnormalList[i].DOUBLETAKE == "1"
                            && unnormalList[i + 1].DOUBLETAKE == "1")
                        {
                            //判断当前来烟与下条来烟是否双抓
                            if (sortN[packageVo.Index].SurplusWidth >= (unnormalList[i + 1].IWIDTH + unnormalList[i].IWIDTH) + packageVo.GapWidth * 2)
                            {
                                packageVo.DoubleTake = "1";
                                packageVo.CurrentHigh = unnormalList[i].IHEIGHT < unnormalList[i + 1].IHEIGHT ? unnormalList[i + 1].IHEIGHT : unnormalList[i].IHEIGHT;
                                packageVo.CurrentWidth = unnormalList[i].IWIDTH + unnormalList[i + 1].IWIDTH;
                            }
                        }
                        else
                        {
                            packageVo.DoubleTake = "0";
                        }
                    }
                }
                
            } 
        }




         





        public bool DataInsert(List<PackageVo> vos)
        {
            int ptid = maxPTID() + 1;
            using (Entities et=new Entities())
            {
                for (int i = 0; i < vos.Count; i++)
                {
                    vos[i].Ptid = ptid;
                    et.T_PACKAGE_TASK.Add(task(vos[i]));
                    ptid++;
                }
                if (et.SaveChanges()>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public T_PACKAGE_TASK task (PackageVo packageVo)
        {
            T_PACKAGE_TASK t = new T_PACKAGE_TASK();
            t.BILLCODE = packageVo.Billcode;
            t.ALLPACKAGESEQ = packageVo.ALLPACKAGESEQ;
            t.CIGARETTECODE = packageVo.Cigarettecode;
            t.CIGARETTENAME = packageVo.CIGARETTENAME;
            t.CIGHIGH = packageVo.CigHigh;

            t.CIGHIGHY = packageVo.CigHighY;
            t.CIGLENGTH= packageVo.CigLength;
            t.CIGNUM = packageVo.Cignum;
            t.CIGSEQ = packageVo.CIGSEQ;

            t.CIGSTATE = 10 ;
            t.CIGTYPE = packageVo.Cigtype.ToString();
            t.CIGWIDTH = packageVo.CigWidth;
            t.CIGWIDTHX = packageVo.CigWidthX;
            t.CIGZ = packageVo.CigZ;

            t.DOUBLETAKE = packageVo.DoubleTake;
            t.NORMAILSTATE = 10;
            t.NORMALQTY = packageVo.Pokenum;
            t.ORDERDATE = packageVo.Orderdate;

            t.ORDERPACKAGEQTY = packageVo.ORDERPACKAGENUM;
            t.ORDERQTY = packageVo.Orderqty;
            t.ORDERSEQ = packageVo.Orderseq;
            t.PACKAGENO = packageVo.Packageno;

            t.PACKAGEQTY = packageVo.PACKAGEQTY;
            t.PACKAGESEQ = packageVo.Packageseq;
            t.PACKTASKNUM = packageVo.Packtasknum;
            t.PTID = packageVo.Ptid;
            t.PUSHSPACE = packageVo.Pushspace;
            t.SORTNUM = packageVo.Tasknum;

            t.STATE = 10 ;
            t.UNIONPACKAGETAG = packageVo.Unionpackagestate;


            return t;
        }

        public int maxPTID()
        {
            using (Entities et =new Entities())
            {
                if (et.T_PACKAGE_TASK.Count() > 0)
                {
                    return (int)et.T_PACKAGE_TASK.Max(x => x.PTID);
                }
                else
                {
                    return 0;
                }
               
                 
            }
        }
 

public List< PACKAGEINFO_All> package_yxy(string BILLCODE)
        {
            using (Entities et=new Entities())
            {
                var data = et.V_PRODUCE_PACKAGEINFO.Where(x => x.BILLCODE == BILLCODE && x.ALLOWSORT == "非标").OrderBy(x => x.SENDTASKNUM).ThenBy(x => x.MACHINESEQ).ThenBy(x => x.TROUGHNUM).ToList();
                var list = (from item1 in data
                           join item2 in et.T_WMS_ITEM
                           on item1.CIGARETTECODE equals item2.ITEMNO
                           select new PACKAGEINFO_All{  PACKAGEINFO =item1, ILENGTH= item2.ILENGTH??0,  IWIDTH =item2.IWIDTH??0, IHEIGHT = item2.IHEIGHT??0,  DOUBLETAKE = item2.DOUBLETAKE }).ToList();
                return list;
            }
        }
        public List<PACKAGEINFO_All> package_cgy(string BILLCODE)
        {
            using (Entities et = new Entities())
            {
                var data = et.V_PRODUCE_PACKAGEINFO.Where(x => x.BILLCODE == BILLCODE && x.ALLOWSORT == "分拣").OrderBy(x => x.SENDTASKNUM).ThenBy(x => x.MACHINESEQ).ThenBy(x => x.TROUGHNUM).ToList();
                var list = (from item1 in data
                            join item2 in et.T_WMS_ITEM
                            on item1.CIGARETTECODE equals item2.ITEMNO
                            select new PACKAGEINFO_All { PACKAGEINFO = item1, ILENGTH = item2.ILENGTH??0, IWIDTH = item2.IWIDTH??0, IHEIGHT = item2.IHEIGHT??0, DOUBLETAKE = item2.DOUBLETAKE }).ToList();
                return list;
            }
        }


























        /// <summary>
        /// 
        /// </summary>
        /// <param name="packageno"></param>
        /// <returns></returns>
        public List<T_PRODUCE_PACKAGEINFO> alldata_header(decimal packageno)
        {
            using (Entities et = new Entities())
            {
                return et.V_PRODUCE_PACKAGEINFO.Where(x => x.EXPORT == packageno 
                && x.TASKNUM == 570833
                ).GroupBy(x => new { x.BILLCODE, x.EXPORT, x.TASKNUM })
                    .Select(x => new T_PRODUCE_PACKAGEINFO { BILLCODE = x.Key.BILLCODE, EXPORT = x.Key.EXPORT??0, TASKNUM = x.Key.TASKNUM }).ToList();
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
                return et.V_PRODUCE_PACKAGEINFO
                    .Where(x=> x.TASKNUM == 570833)
                    .OrderBy(x=>x.EXPORT).ThenBy(x=>x.TASKNUM).Select(x => x).ToList();
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
