using EFModle;
using EFModle.Model;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Functions.BLL
{
    public class PackageService
    {


        /// <summary>
        /// 获取数据 计算
        /// </summary>
        /// <param name="packageNo"></param>
        public void GetAllOrder(decimal packageNo)
        {
            int allCount = 0;
            using (Entities entity = new Entities())
            {
                //var Packtasknum = entity.Database.SqlQuery( );
                //所有订单明细
                /*var query1 = (from item in entity.V_PRODUCE_PACKAGEINFO
                             where item.EXPORT == packageNo //&& item.BILLCODE == "CS10384689"
                             group item by new { item.BILLCODE, item.TASKNUM } into allcode
                             select new { allcode.Key.BILLCODE, allcode.Key.TASKNUM }).OrderBy(x => x.TASKNUM).ToList();
*/
                DateTime TIEM = new DateTime();
                DateTime TIEM2 = new DateTime();
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "yyyy-MM-dd";
                TIEM = Convert.ToDateTime("2019-03-21", format);
                TIEM2 = Convert.ToDateTime("2019-03-22", format);

                var query = (from item in entity.T_UN_TASK_H
                             where item.PACKAGEMACHINE == packageNo && item.ORDERDATE >= TIEM && item.ORDERDATE <= TIEM2 && item.BILLCODE == "CS10384689"
                             orderby item.SORTNUM
                             select item).ToList();



                //查询ptid值
                decimal ptid = entity.T_PACKAGE_TASK.Count() > 0 ? entity.T_PACKAGE_TASK.Max(x => x.PTID) + 1 : 1;
                if (query != null)
                {
                    int i = 0;
                    foreach (var v in query)
                    {
                        i++;
                        int pcount = 0;
                        List<T_PACKAGE_TASK> task = new List<T_PACKAGE_TASK>();
                        //当期订单明细
                        var query2 = (from item2 in entity.T_UN_POKE_H where item2.BILLCODE == v.BILLCODE orderby item2.SENDTASKNUM, item2.MACHINESEQ, item2.TROUGHNUM select item2).ToList();

                        //var query2 = (from item2 in entity.V_PRODUCE_PACKAGEINFO where item2.BILLCODE == v.BILLCODE orderby item2.SENDTASKNUM, item2.MACHINESEQ, item2.TROUGHNUM select item2).ToList();
                        if (query2 != null)
                        {
                            //遍历订单数据存入集合
                            foreach (var v2 in query2)
                            {
                                allCount = allCount + 1;
                                pcount = pcount + 1;
                                T_PACKAGE_TASK temp = new T_PACKAGE_TASK();
                                temp.PTID = ptid;
                                temp.CIGARETTECODE = v2.CIGARETTECODE;
                                T_WMS_ITEM tempItem = ItemService.GetItemByCode(v2.CIGARETTECODE);
                                temp.CIGARETTENAME = tempItem.ITEMNAME;
                                temp.CIGHIGH = tempItem.IHEIGHT;
                                temp.CIGWIDTH = tempItem.IWIDTH;
                                temp.CIGWIDTH = tempItem.IWIDTH;
                                temp.CIGLENGTH = tempItem.ILENGTH;
                                temp.BILLCODE = v2.BILLCODE;
                                temp.SORTNUM = v2.TASKNUM;
                                temp.CIGNUM = allCount;
                                temp.CIGSEQ = pcount;
                                temp.PACKAGESEQ = packageNo;
                                temp.ALLPACKAGESEQ = 0;
                                temp.PACKAGENO = v2.PACKAGEMACHINE;//v2.EXPORT;
                                temp.CIGTYPE = "2";
                                temp.STATE = 0;//0 新增  10 确定
                                temp.NORMALQTY = 1;
                                temp.NORMAILSTATE = 10;
                                temp.UNIONPACKAGETAG = 0;
                                temp.DOUBLETAKE = "0";
                                //temp.ORDERSEQ = v2.PRIORITY;
                                //temp.ORDERQTY = v2.ORDERQUANTITY;
                                temp.CIGSTATE = 10;
                                task.Add(temp);
                                ptid++;
                            }
                            allpackagenum++;
                            GenPackageInfo(task, entity); 
                            foreach (var item in task)
                            {
                                //item.ORDERPACKAGEQTY = task.GroupBy(x => x.PACKAGESEQ ?? 0).Count();
                                //item.PACKAGEQTY = task.
                                entity.T_PACKAGE_TASK.Add(item);
                            }
                            if (i == 5)
                            {
                                entity.SaveChanges();
                                i = 0;
                            }

                        }

                    }
                    entity.SaveChanges();
                }
            }
        }

        int packageWidth = 530;//宽
        int packageHeight = 196 + 4;//20浮动
        int jx = 5;//间隙
        decimal deviation = 3;//高度误差

        int taskCount = 6;//一次参与计算的条数
        int allpackagenum = 0;
        public static T DeepCopyByReflect<T>(T obj)
        {
            //如果是字符串或值类型则直接返回
            if (obj is string || obj.GetType().IsValueType) return obj;
            object retval = Activator.CreateInstance(obj.GetType());
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo field in fields)
            {
                try { field.SetValue(retval, DeepCopyByReflect(field.GetValue(obj))); }
                catch { }
            }
            return (T)retval;
        }

        /// <summary>
        /// 计算包装机数据
        /// </summary>
        /// <param name="task">条烟集合</param>
        /// <param name="entity">数据库实体</param>
        public void GenPackageInfo(List<T_PACKAGE_TASK> task, Entities entity)//
        {
            diclist.Clear();//清空平面
            List<PackageArea> list = new List<PackageArea>();//平面集合
            PackageArea area = new PackageArea();//创建平面
            area.width = packageWidth;//平面宽（初始）
            area.height = 0;//平面高（初始）
            //area.beginx = jx;

            //序号，最小X坐标,最大X坐标，平面宽度
            area.cigaretteList = new List<Cigarette>() { new Cigarette() { CigaretteNo = 0, fromx = 0, tox = packageWidth, width = packageWidth } };//平面集合， 算烟
            //插入初始平面
            list.Add(area);

            List<PackageArea> list1 = new List<PackageArea>(list);
            diclist.Push(list1);//插入初始平面到临时平面集合
            CalcPackage(task, list);


        }
        /// <summary>
        /// 重计平面
        /// </summary>
        /// <param name="list">平面集合</param>
        /// <param name="area"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="cigseq"></param>
        /// <param name="unit"></param>
        public void CalcArea(List<PackageArea> list, PackageArea area, decimal width, decimal height, decimal cigseq, AreaUnit unit)
        {
            list.Remove(area);

            PackageArea areal = new PackageArea();
            PackageArea areaC = new PackageArea();
            PackageArea arear = new PackageArea();

            areal.left = area.left;
            areal.right = areaC;
            areal.beginx = area.beginx;
            areal.width = unit.beginx;
            areal.height = area.height;
            List<Cigarette> temp = area.cigaretteList.Where(x => x.index < unit.begin).ToList();
            areal.cigaretteList = new List<Cigarette>();
            areal.cigaretteList.AddRange(temp);
            #region
            //if (area.left != null)
            //{
            //    area.left.right = areal;
            //    if (Math.Abs(area.left.height - areal.height) <= deviation)
            //    {
            //        areal.left = area.left.left;
            //        areal.beginx = area.left.beginx;
            //        areal.cigaretteList = area.left.cigaretteList;
            //        areal.cigaretteList.AddRange(areal.cigaretteList);
            //            //(new Cigarette() { CigaretteNo = cigseq, fromx = area.left.width, tox = area.left.width + width, width = width });
            //        areal.width = area.left.width + areal.width;
            //        if (areal.height < area.left.height)
            //        {
            //            areal.height = area.left.height;
            //        }
            //        list.Remove(area.left);
            //    }
            //}
            #endregion
            areaC.left = areal;
            areaC.beginx = area.beginx + unit.beginx;
            areaC.height = height;
            areaC.width = width;
            areaC.cigaretteList = new List<Cigarette> { new Cigarette() { CigaretteNo = cigseq, fromx = 0, tox = width, width = width } };
            areaC.right = arear;
            arear.left = areaC;
            arear.beginx = areaC.beginx + width;
            arear.width = area.width - width - unit.beginx;
            arear.height = area.height;
            arear.right = area.right;
            Cigarette tempC = area.cigaretteList.Where(x => x.index == unit.begin).FirstOrDefault();
            if (tempC.width < width)
            {

                arear.cigaretteList = area.cigaretteList.Where(x => x.index > unit.begin).ToList();
                arear.cigaretteList[0].width -= (width - tempC.width);
            }
            else
            {
                arear.cigaretteList = area.cigaretteList.Where(x => x.index >= unit.begin).ToList();
                arear.cigaretteList[0].width -= width;
            }
            //arear.cigaretteList[0].tox = arear.width;
            //arear.cigaretteList[0].width = arear.width;
            if (area.right != null)
            {
                area.right.left = arear;
            }
            list.Add(areal);
            list.Add(areaC);
            list.Add(arear);
        }
        /// <summary>
        /// 重新计算平面
        /// </summary>
        /// <param name="list"></param>
        /// <param name="area"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="cigseq"></param>
        public void calcArea(List<PackageArea> list, PackageArea area, decimal width, decimal height, decimal cigseq)
        {
            list.Remove(area);

            PackageArea areal = new PackageArea();//左边的平面
            PackageArea arear = new PackageArea();//右边的平面

            areal.left = area.left;
            areal.right = arear;
            areal.beginx = area.beginx;//加间隙 +jx  如果平面高为0 则设间隙，否则不设
            areal.width = width;//加间隙+jx
            areal.height = height;

            areal.cigaretteList = new List<Cigarette> { new Cigarette() { CigaretteNo = cigseq, fromx = 0, tox = width, width = width } };//
            if (area.left != null && list.Contains(area.left))
            {
                area.left.right = areal;
                if (Math.Abs(area.left.height - areal.height) <= deviation)
                {


                    areal.beginx = area.left.beginx;
                    areal.cigaretteList = CopyCigaretteList(area.left.cigaretteList);
                    areal.cigaretteList.Add(new Cigarette() { CigaretteNo = cigseq, fromx = area.left.width, tox = area.left.width + width, width = width });
                    areal.width = area.left.width + areal.width;//加间隙  待加
                    if (areal.height < area.left.height)
                    {
                        areal.height = area.left.height;
                    }
                    if (areal.beginx == 0)
                    {
                        areal.left = null;
                    }
                    list.Remove(area.left);
                }
            }
            arear.left = areal;
            arear.beginx = areal.beginx + areal.width;
            arear.width = area.width - width;//+jx * 2
            arear.height = area.height;
            arear.right = area.right;
            arear.cigaretteList = CopyCigaretteList(area.cigaretteList);
            //if (arear.cigaretteList.Count > 1)
            //{

            if (width > area.cigaretteList[0].width + jx * 2)
            {
                arear.cigaretteList.RemoveAt(0);
                arear.cigaretteList[0].width -= (width - area.cigaretteList[0].width);
            }
            else
            {

                arear.cigaretteList[0].width = (area.cigaretteList[0].width - width);//-间隙*2 
            }
            //}
            //else
            //{
            //    arear.cigaretteList[0].width = arear.cigaretteList[0].width - width;
            //}

            list.Add(areal);
            list.Add(arear);
        }
        /// <summary>
        /// 临时平面集合
        /// </summary>
        public Stack<List<PackageArea>> diclist = new Stack<List<PackageArea>>();
        /// <summary>
        /// 回滚平面数据
        /// </summary>
        /// <param name="list"></param>
        /// <param name="bigList"></param>
        /// <returns></returns>
        public List<PackageArea> RollBackList(List<PackageArea> list, List<T_PACKAGE_TASK> bigList)
        {
            var tempCode = "";
            var doubleTake = "0";
            foreach (var item in bigList)
            {
                if (item.CIGARETTECODE != tempCode)
                {

                    list = diclist.Pop();

                    tempCode = item.CIGARETTECODE;
                    doubleTake = item.DOUBLETAKE;
                }
                else if (item.DOUBLETAKE != "1" || (item.DOUBLETAKE == "1" && doubleTake != "1"))
                {
                    list = diclist.Pop();
                    doubleTake = item.DOUBLETAKE;
                }
                else
                {
                    tempCode = "";//一次双抓后重新计算
                }

            }
            return diclist.Peek();
        }
        //最小条烟宽度
        decimal minWidth = 75;
        /// <summary>
        /// 临时卷烟集合
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<Cigarette> CopyCigaretteList(List<Cigarette> list)
        {
            List<Cigarette> clist = new List<Cigarette>();
            foreach (var it in list)
            {
                Cigarette ct = new Cigarette();
                ct.CigaretteNo = it.CigaretteNo;
                ct.fromx = it.fromx;
                ct.tox = it.tox;
                ct.width = it.width;
                ct.index = it.index;
                clist.Add(ct);
            }
            return clist;

        }

        public List<PackageArea> CopyList(List<PackageArea> list)
        {
            List<PackageArea> list1 = new List<PackageArea>();
            foreach (var item in list)
            {
                PackageArea t = new PackageArea();
                t.height = item.height;
                t.width = item.width;
                t.isscan = item.isscan;
                t.left = item.left;
                t.right = item.right;
                if (item.cigaretteList != null)
                {
                    List<Cigarette> clist = new List<Cigarette>();
                    foreach (var it in item.cigaretteList)
                    {
                        Cigarette ct = new Cigarette();
                        ct.CigaretteNo = it.CigaretteNo;
                        ct.fromx = it.fromx;
                        ct.tox = it.tox;
                        ct.width = it.width;
                        ct.index = it.index;
                        clist.Add(ct);
                    }
                    t.cigaretteList = clist;
                }
                list1.Add(item);
            }
            return list1;
        }
        /// <summary>
        /// 计算平面
        /// </summary>
        /// <param name="task">条烟集合</param>
        /// <param name="list">平面集合</param>
        public void CalcPackage(List<T_PACKAGE_TASK> task, List<PackageArea> list)
        {
            int packageNO = 1;
            var templist = task.Where(x => x.STATE == 0).ToList().Take(taskCount).ToList();  //为0的未计算数据 暂每次取6条


            if (templist != null && templist.Count > 0)
            {
                //不为空，且存在状态为0
                while (templist.Where(x => x.STATE == 10) != null && templist.Where(x => x.STATE != 10).Count() > 0)
                {
                    // templist = templist.Where(x => x.STATE != 10).ToList();
                    decimal minHeight = 0;
                    //平面集合内未标记删除且大于75最宽度的平面，且数量大于0
                    if (list.Where(x => x.isscan == 0 && x.width > minWidth) != null && list.Where(x => x.isscan == 0 && x.width > minWidth).Count() > 0)
                    {
                        //最小高度 = 标记未删除的最低平面高度
                        minHeight = list.Where(x => x.isscan == 0 && x.width > minWidth).Min(x => x.height);
                    }
                    else
                    {

                        decimal sciseq = templist.Where(x => x.STATE != 10).Min(x => x.CIGSEQ) ?? 0;
                        List<T_PACKAGE_TASK> bigList = templist.Where(x => x.STATE == 10 && x.CIGSEQ > sciseq).OrderBy(x => x.CIGSEQ).ToList();//有大于当前序号已排好的烟
                        if (bigList != null && bigList.Count > 0)
                        {
                            bigList = templist.Where(x => x.STATE == 10).OrderBy(x => x.CIGSEQ).ToList();

                            //list.Clear();

                            list = RollBackList(list, bigList);
                            list.ForEach(x => x.isscan = 0);
                            templist.ForEach(x => { x.PACKAGESEQ = 0; x.STATE = 0; x.DOUBLETAKE = "0"; });
                            templist = templist.Where(x => x.CIGSEQ <= sciseq).ToList();
                            minHeight = list.Where(x => x.isscan == 0 && x.width > minWidth).Min(x => x.height);
                            //List<PackageArea> list1 = new List<PackageArea>(list);
                            //diclist.Push(list1);
                        }
                        else
                        { 
                            packageNO += 1;
                            allpackagenum += 1;
                            list.Clear();
                            diclist.Clear();
                            PackageArea areainit = new PackageArea();
                            areainit.width = packageWidth;
                            areainit.height = 0;
                            //areainit.beginx = jx;
                            areainit.cigaretteList = new List<Cigarette>() { new Cigarette() { CigaretteNo = 0, fromx = 0, tox = packageWidth, width = packageWidth } };
                            list.Add(areainit);

                            diclist.Push(CopyList(list));
                        }

                    }
                    //找到最底平面
                    PackageArea area = list.Find(x => x.height == minHeight && x.isscan == 0 && x.width > minWidth);
                    area = list.FindAll(x => x.beginx == area.beginx && x.isscan == 0 && x.width > minWidth).OrderByDescending(x => x.height).FirstOrDefault();
                    //是否有连续的相同品牌的烟存入集合（即获取双抓数据）   --没有判断不同品牌？
                    List<ItemGroup> allGroupList = templist.Where(x => x.STATE != 10).GroupBy(x => x.CIGARETTECODE).Select(x => new ItemGroup() { CigaretteCode = x.Key, Total = x.Count() }).ToList();
                    //存入6条烟中 数量大于1的条烟品牌和数量记录
                    List<ItemGroup> groupList = allGroupList.FindAll(x => x.Total > 1);

                    foreach (var item in groupList)//循环连续品牌条烟列表
                    {
                        //取两条
                        var doubleList = templist.Where(x => x.STATE != 10 && x.CIGARETTECODE == item.CigaretteCode).Take(2).ToList();
                        decimal a = doubleList[0].CIGSEQ ?? 0;
                        decimal b = doubleList[1].CIGSEQ ?? 0;
                        if (Math.Abs(a - b) != 1)//如果不是连续的两条烟
                        {
                            item.Total = 100;//标记删除
                        }
                    }
                    groupList.RemoveAll(x => x.Total == 100);//删除标记的品牌和数量

                    String tempcode = "";
                    decimal tempWidth = 0;
                    decimal gdc = 0;//高度差
                    List<AreaUnit> unit = new List<AreaUnit>();//双抓平面
                    AreaUnit tempunit = null;
                    if (groupList != null && groupList.Count > 0)//优先双抓 而且是宽度大的先抓
                    {
                        //  List<Cigarette> cigList = area.cigaretteList;
                        foreach (var v in groupList)
                        {
                            unit.Clear();
                            T_PACKAGE_TASK temptask = templist.Find(x => x.CIGARETTECODE == v.CigaretteCode);
                            decimal cgiseq = templist.Where(x => x.CIGARETTECODE == v.CigaretteCode && x.STATE != 10).FirstOrDefault().CIGSEQ ?? 0;//获取条烟序号   *个人觉得会有第1条为a与3、4为a有问题

                            if (temptask.CIGWIDTH * 2 <= area.width && area.height + temptask.CIGHIGH < packageHeight)//双抓小于最低平面宽度,同时小于整包高度  +2个间隙
                            {
                                int i = 0;

                                decimal flag = 1;
                                decimal lastflag = 0;
                                decimal beginx = 0;
                                foreach (var item in area.cigaretteList)//遍历平面得卷烟集合，条烟不能放在序号比当前大得条烟上
                                {
                                    item.index = i;
                                    if (cgiseq < item.CigaretteNo)
                                    {
                                        flag = 0;//如果大，标记不可放
                                    }
                                    else
                                    {
                                        flag = 1;
                                    }
                                    if (lastflag == 1 && flag == 1)//若上一个卷烟平面和当前找到的平面上都可放
                                    {

                                        AreaUnit u = unit.ElementAt(unit.Count - 1);
                                        u.width += item.width;
                                        u.end = i;


                                    }
                                    else if (lastflag == 0 && flag == 1)//若上一个卷烟平面不可放，但当前找到的平面上可放
                                    {
                                        AreaUnit cell = new AreaUnit();
                                        cell.width = item.width;
                                        cell.begin = i;
                                        cell.end = i;
                                        cell.beginx = beginx;
                                        unit.Add(cell);
                                    }

                                    lastflag = flag;

                                    beginx += item.width;

                                    i++;
                                }
                                foreach (var cell in unit)
                                {
                                    if (temptask.CIGWIDTH * 2 <= cell.width)
                                    {
                                        if (tempWidth <= temptask.CIGWIDTH)//
                                        {
                                            if (tempWidth == temptask.CIGWIDTH)//
                                            {

                                                if (area.left != null)
                                                {


                                                    //看左边高度差 取相差小的
                                                    if (Math.Abs(area.height + temptask.CIGHIGH ?? 0 - area.left.height) - Math.Abs(gdc) < 0)
                                                    {
                                                        tempWidth = temptask.CIGWIDTH ?? 0;
                                                        tempcode = v.CigaretteCode;
                                                        gdc = area.height + temptask.CIGHIGH ?? 0 - area.left.height;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                tempWidth = temptask.CIGWIDTH ?? 0;
                                                tempcode = v.CigaretteCode;
                                                if (area.left != null)
                                                {
                                                    gdc = area.height + temptask.CIGHIGH ?? 0 - area.left.height;
                                                }
                                            }
                                        }
                                        tempunit = cell;
                                        break;
                                    }
                                }

                            }
                        }
                    }
                    if (tempcode != "" && tempunit != null)
                    {
                        var chooseItem = templist.FindAll(x => x.CIGARETTECODE == tempcode && x.STATE != 10).OrderBy(x => x.CIGSEQ).Take(2).ToList();
                        decimal width = 0;
                        decimal height = 0;
                        decimal cigseq = 0;

                        foreach (var v in chooseItem)
                        {
                            v.PACKAGESEQ = packageNO;
                            v.CIGWIDTHX = area.beginx + tempunit.beginx + v.CIGWIDTH +jx;//两条当做一条 +jx
                            v.CIGHIGHY = area.height + v.CIGHIGH;
                            v.STATE = 10;
                            v.DOUBLETAKE = "1";
                            v.ALLPACKAGESEQ = allpackagenum;
                            width += (v.CIGWIDTH ?? 0) +jx;//+jx
                            height = (area.height + v.CIGHIGH ?? 0);
                            cigseq = v.CIGSEQ ?? 0;
                        }
                        //更新area
                        if (tempunit.begin == 0)
                        {
                            calcArea(list, area, width, height, cigseq);
                        }
                        else
                        {
                            CalcArea(list, area, width, height, cigseq, tempunit);
                        }

                        diclist.Push(CopyList(list));
                    }
                    else
                    {

                        tempWidth = 0;
                        gdc = 0;//高度差
                        unit.Clear();
                        foreach (var v in allGroupList)
                        {
                            T_PACKAGE_TASK temptask = templist.Find(x => x.CIGARETTECODE == v.CigaretteCode && x.STATE != 10);
                            int i = 0;
                            unit.Clear();
                            decimal flag = 1;
                            decimal lastflag = 0;
                            decimal beginx = 0;
                            foreach (var item in area.cigaretteList)
                            {
                                item.index = i;
                                if (temptask.CIGSEQ < item.CigaretteNo)
                                {
                                    flag = 0;
                                }
                                else
                                {
                                    flag = 1;
                                }
                                if (lastflag == 1 && flag == 1)
                                {

                                    AreaUnit u = unit.ElementAt(unit.Count - 1);
                                    u.width += item.width;
                                    u.end = i;


                                }
                                else if (lastflag == 0 && flag == 1)
                                {
                                    AreaUnit cell = new AreaUnit();
                                    cell.width = item.width;
                                    cell.begin = i;
                                    cell.end = i;
                                    cell.beginx = beginx;
                                    unit.Add(cell);
                                }

                                lastflag = flag;

                                beginx += item.width;

                                i++;
                            }
                            if (temptask.CIGWIDTH +jx*2 <= area.width && area.height + temptask.CIGHIGH < packageHeight)
                            {
                                foreach (var cell in unit)
                                {
                                    if (temptask.CIGWIDTH +jx*2 <= cell.width) //后面的seq必须大于已放的才能放
                                    {

                                        if (tempWidth <= temptask.CIGWIDTH +jx*2)
                                        {
                                            if (tempWidth == temptask.CIGWIDTH + jx*2)
                                            {

                                                if (area.left != null)
                                                {


                                                    //看左边高度差 取相差小的
                                                    if (Math.Abs(area.height + temptask.CIGHIGH ?? 0 - area.left.height) - Math.Abs(gdc) < 0)
                                                    {
                                                        tempWidth = temptask.CIGWIDTH ?? 0 + jx *2;
                                                        tempcode = v.CigaretteCode;
                                                        gdc = area.height + temptask.CIGHIGH ?? 0 - area.left.height;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                tempWidth = temptask.CIGWIDTH ?? 0 +jx *2;
                                                tempcode = v.CigaretteCode;
                                                if (area.left != null)
                                                {
                                                    gdc = area.height + temptask.CIGHIGH ?? 0 - area.left.height;
                                                }
                                            }

                                        }
                                        tempunit = cell;
                                        break;
                                    }
                                }
                            }



                        }
                        if (tempcode != "" && tempunit != null)
                        {
                            var chooseItem = templist.FindAll(x => x.CIGARETTECODE == tempcode && x.STATE != 10).OrderBy(x => x.CIGSEQ).FirstOrDefault();
                            decimal width = 0;
                            decimal height = 0;
                            decimal cigseq = 0;


                            chooseItem.PACKAGESEQ = packageNO;
                            chooseItem.CIGWIDTHX = area.beginx + tempunit.beginx + chooseItem.CIGWIDTH / 2 +jx;


                            chooseItem.CIGHIGHY = area.height + chooseItem.CIGHIGH;
                            chooseItem.STATE = 10;
                            chooseItem.ALLPACKAGESEQ = allpackagenum;
                            width += (chooseItem.CIGWIDTH ?? 0) +jx*2;
                            height = (area.height + chooseItem.CIGHIGH ?? 0);
                            cigseq = chooseItem.CIGSEQ ?? 0;
                            //更新area
                            //更新area
                            if (tempunit.begin == 0)
                            {
                                calcArea(list, area, width, height, cigseq);
                            }
                            else
                            {
                                CalcArea(list, area, width, height, cigseq, tempunit);
                            }
                            diclist.Push(CopyList(list));


                        }
                        else
                        {
                            area.isscan = 1;
                        }

                    }


                    if (templist.Where(x => x.STATE != 10) == null || templist.Where(x => x.STATE != 10).Count() == 0)

                    {
                        list.ForEach(x => x.isscan = 0);
                        templist = task.Where(x => x.STATE != 10).ToList().Take(taskCount).ToList();
                    }
                    foreach (var it in templist)
                    {
                        if (it.CIGSEQ == 9)
                        {
                            string ddd = templist[0].CIGARETTENAME;
                            break;
                        }
                    }

                }
            }

        }








    }
}
