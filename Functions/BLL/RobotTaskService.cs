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
   public class RobotTaskService
    {

      public  RobotTaskService()
        {
            packageno = GlobalPara.PackageNo;

        }
        /// <summary>
        /// 获取机器人任务
        /// </summary>
        /// <param name="ErrMsg">错误信息</param>
        /// <returns></returns>
        public object[] GetRobitInfo(out string ErrMsg)
        {
            try
            {
                ErrMsg = "";
                object[] ArrInfo = new object[12];
                for (int i = 0; i < ArrInfo.Length; i++)//初始化
                {
                    ArrInfo[i] = 0;
                }
                using (Entities en = new Entities())
                {
                    var query = (from item in en.T_PACKAGE_TASK
                                 where item.PACKAGENO == GlobalPara.PackageNo && item.STATE == 10
                                 orderby item.CIGNUM
                                 select item).Take(10).ToList();
                    if (query.Any())
                    {
                        int index = 0;//双抓的索引
                        foreach (var item in query)
                        {
                            if (item.DOUBLETAKE == "1")
                            {
                                ArrInfo = new object[23];
                                for (int i = 0; i < ArrInfo.Length; i++)//初始化
                                {
                                    ArrInfo[i] = 0;
                                }
                                ArrInfo[index * 12] =  "T,";//头部T 代表这是机器人任务
                                ArrInfo[index * 12 + 1] = item.PACKTASKNUM + ",";//包装机包号
                                ArrInfo[index * 12 + 2] = item.CIGSEQ + ",";//包内条烟流水号
                                ArrInfo[index * 12 + 3] = item.CIGWIDTHX + ",";//坐标X
                                ArrInfo[index * 12 + 4] = (GlobalPara.BoxWidth / 2) + ",";//坐标Y
                                ArrInfo[index * 12 + 5] = item.CIGHIGHY + ",";//坐标z
                                ArrInfo[index * 12 + 6] = item.DOUBLETAKE + ",";//是否双抓
                                ArrInfo[index * 12 + 7] = item.PACKAGEQTY + ",";//包内总数
                                ArrInfo[index * 12 + 8] = item.CIGARETTECODE + ",";//条烟编码
                                ArrInfo[index * 12 + 9] = item.CIGLENGTH + ",";//长
                                ArrInfo[index * 12 + 10] = item.CIGWIDTH + ",";//宽
                                ArrInfo[index * 12 + 11] = item.CIGHIGH + "|";//高
                                if (index == 2)//最多循环两次
                                {
                                    break;
                                }
                                index++;
                            }
                            else if (index == 1)//出现一条有双抓标志但是下一条没有双抓标志的，有异常
                            {
                                ErrMsg = "";
                                try
                                {
                                    ErrMsg = "出现一条有双抓标志但是下一条没有双抓标志的,任务流水号：" + query[1].SORTNUM;
                                }
                                catch (Exception ex)
                                {
                                    throw ex = new Exception(ErrMsg);
                                }
                            }
                            else
                            {
                                ArrInfo[0] = "T,";//头部T 代表这是机器人任务
                                ArrInfo[1] = item.PACKTASKNUM + ",";//任务流水号 
                                ArrInfo[2] = item.CIGNUM + ",";//包内条烟流水号
                                ArrInfo[3] = item.CIGWIDTHX + ",";//坐标X
                                ArrInfo[4] = (GlobalPara.BoxWidth / 2) + ",";//坐标Y
                                ArrInfo[5] = item.CIGHIGHY + ",";//坐标z
                                ArrInfo[6] = item.DOUBLETAKE + ",";//是否双抓
                                ArrInfo[7] = item.PACKAGEQTY + ",";//包内总数
                                ArrInfo[8] = item.CIGARETTECODE + ",";//条烟编码
                                ArrInfo[9] = item.CIGLENGTH + ",";//长
                                ArrInfo[10] = item.CIGWIDTH + ",";//宽
                                ArrInfo[11] = item.CIGHIGH;//高
                                break;//但抓的情况 只需要取一条的信息
                            }
                        } 
                    }
                    else//如果不包含元素， 任务已经做完
                    {
                        return  ArrInfo;
                    }
                }
                return ArrInfo;
            }
            catch (Exception ex )
            {

                throw ex = new Exception("连接数据库失败:"+ex.Message);
            } 
        }

        public bool GetTaskState(decimal state)
        {
            using(Entities en = new Entities())
            {
                var query = (from item in en.T_PACKAGE_TASK
                             where item.PACKAGENO == GlobalPara.PackageNo && item.STATE == state
                             orderby item.CIGNUM
                             select item).Take(10).ToList();
                if (query.Any())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void UpDateFinishTask(object[] task,out string ErrMsg)
        {
            ErrMsg = "";
            try
            { 
                decimal taskNum = Convert.ToDecimal(task[0]);
                int CigSeq = (int)task[1];
                using (Entities en = new Entities())
                { 
                    var query1 = (from item in en.T_PACKAGE_TASK
                                 where item.PACKTASKNUM == taskNum && item.PACKAGENO == packageno && item.CIGNUM == CigSeq
                                  select item).ToList();
                    if (query1.Any()  )
                    {
                        foreach (var item in query1)
                        { 
                            item.STATE = 20;
                        }
                        en.SaveChanges();
                    }
                    else
                    {
                        ErrMsg += "机器人:未找到任务号" + taskNum + ",和条烟流水号" + CigSeq;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrMsg += "机器人:任务服务类，更新完成任务方法，数据库连接失败:" + ex.Message;
                throw ex = new Exception(ErrMsg);
            }
        }
        int packageno = 0;
        /// <summary>
        /// 更新机器人条烟任务状态
        /// </summary>
        /// <param name="packagenum">包装机包号</param>
        /// <param name="state">状态（10：新增，15：已接收，20：完成）</param>
        /// <param name="cigseq">包内异型烟条烟流水号</param>
        public void UpdateRobitTaskCigState(decimal packagenum, decimal state, decimal cigseq)
        {
            using (Entities entity = new Entities())
            {
                //获取这个包号的条烟信息
                var query = (from item in entity.T_PACKAGE_TASK where item.PACKTASKNUM == packagenum && item.PACKAGENO == packageno && item.CIGNUM == cigseq select item).ToList();
                if (query.Any())
                {
                    foreach (var item in query)
                    {
                        item.CIGSTATE = state;//更新这个条烟的状态
                    }
                    entity.SaveChanges();
                }
                else
                {
                    throw new Exception("UpdateRobitTaskCigState,未找到改包装机包号" + packagenum + "条烟流水号:" + cigseq);
                }
            }
        }
        /// <summary>
        /// 任务定位  
        /// 更新这个包装机包号之前的包号为完成，这个包装机包号之后的为新增
        /// </summary>
        /// <param name="packagenum">包装机包号</param>
        public void UpdateTask(decimal packagenum)
        {
            using (Entities entity = new Entities())
            {
                //更新这个包号之前的任务为完成
                var query = (from item in entity.T_PACKAGE_TASK where item.PACKTASKNUM < packagenum && item.PACKAGENO == packageno select item).ToList();
                if (query.Any())
                {
                    foreach (var item in query)
                    {
                        item.STATE = 20;//合包状态
                        item.CIGSTATE = 20;//机器人条烟状态
                        item.NORMAILSTATE = 20;//常规烟翻盘状态
                    }
                    entity.SaveChanges();
                }
                else
                {
                    //throw new Exception("未查询到这个包号之前的任务信息");//有可能从第一个任务开始，这肯定会报错
                }
                //更新这个包号和之后的任务为新增
                var query1 = (from item in entity.T_PACKAGE_TASK where item.PACKTASKNUM >= packagenum && item.PACKAGENO == packageno select item).ToList();
                if (query.Any())
                {
                    foreach (var item in query1)
                    {
                        item.STATE = 10;//合包状态
                        item.CIGSTATE = 10;//机器人条烟状态
                        item.NORMAILSTATE = 10;//常规烟翻盘状态
                    }
                    entity.SaveChanges();
                }
                else
                {
                    throw new Exception("未查询到这个包号之前的任务信息");
                }
            }
        }

        public void UpdateTask(decimal Nomarlpackagenum,decimal unNomarlPackageNum)
        {
            using (Entities entity = new Entities())
            {
                //更新这个常规烟 包号之前的任务为完成
                var query = (from item in entity.T_PACKAGE_TASK where item.PACKTASKNUM < Nomarlpackagenum && item.PACKAGENO == packageno && item.CIGTYPE =="1" select item).ToList();
                if (query.Any())
                {
                    foreach (var item in query)
                    {
                        item.STATE = 20;//合包状态
                        item.CIGSTATE = 20;//机器人条烟状态
                        item.NORMAILSTATE = 20;//常规烟翻盘状态
                    }
                    entity.SaveChanges();
                }
                else
                {
                    //throw new Exception("未查询到这个包号之前的任务信息");//有可能从第一个任务开始，这肯定会报错
                }
                //更新这个包号和之后的任务为新增
                var query1 = (from item in entity.T_PACKAGE_TASK where item.PACKTASKNUM >= unNomarlPackageNum && item.PACKAGENO == packageno && item.CIGTYPE == "2"  select item).ToList();
                if (query.Any())
                {
                    foreach (var item in query1)
                    {
                        item.STATE = 10;//合包状态
                        item.CIGSTATE = 10;//机器人条烟状态
                        item.NORMAILSTATE = 10;//常规烟翻盘状态
                    }
                    entity.SaveChanges();
                }
                else
                {
                    throw new Exception("未查询到这个包号之前的任务信息");
                }
            }
        }
    }
}
