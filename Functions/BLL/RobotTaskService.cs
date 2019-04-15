using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFModle;
using EFModle.Model;
using Functions.PubFunction;
namespace Functions.BLL
{
   public class RobotTaskService:ReadExcel
    {

      public  RobotTaskService()
        {
            packageno = GlobalPara.PackageNo;
            //GetT_PACKAGE_TASKByExcel();
        }
    
        List<T_PACKAGE_TASK> de = new List<T_PACKAGE_TASK>();
        List<T_PACKAGE_TASK> GetT_PACKAGE_TASKByExcel()
        {
         
            string path = Directory.GetCurrentDirectory() + "\\4.3数据.xlsx";
            DataSet ds = LoadDataExcel(path,"Sheet1");
           
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                T_PACKAGE_TASK t_ = new T_PACKAGE_TASK();
                t_.PTID = ds.Tables[0].Rows[j].ItemArray[0].CastTo<decimal>(-1);
                t_.BILLCODE = ds.Tables[0].Rows[j].ItemArray[1].CastTo<string>();
                t_.ORDERSEQ = ds.Tables[0].Rows[j].ItemArray[2].CastTo<decimal>(-1);
                t_.PACKAGESEQ = ds.Tables[0].Rows[j].ItemArray[3].CastTo<decimal>(-1);
                t_.CIGARETTECODE = ds.Tables[0].Rows[j].ItemArray[4].CastTo<string>();
                t_.CIGARETTENAME = ds.Tables[0].Rows[j].ItemArray[5].CastTo<string>();
                t_.PACKAGEQTY = ds.Tables[0].Rows[j].ItemArray[6].CastTo<decimal>(-1);
                t_.CIGSEQ = ds.Tables[0].Rows[j].ItemArray[7].CastTo<decimal>(-1);
                t_.CIGHIGH = ds.Tables[0].Rows[j].ItemArray[8].CastTo<decimal>(-1);
                t_.CIGWIDTH = ds.Tables[0].Rows[j].ItemArray[9].CastTo<decimal>(-1);
                t_.CIGLENGTH = ds.Tables[0].Rows[j].ItemArray[10].CastTo<decimal>(-1);
                t_.CIGWIDTHX = ds.Tables[0].Rows[j].ItemArray[11].CastTo<decimal>(-1);
                t_.CIGHIGHY = ds.Tables[0].Rows[j].ItemArray[12].CastTo<decimal>(-1);
                t_.SORTNUM = ds.Tables[0].Rows[j].ItemArray[13].CastTo<decimal>(-1);
                t_.ALLPACKAGESEQ = ds.Tables[0].Rows[j].ItemArray[14].CastTo<decimal>(-1);
                t_.ORDERPACKAGEQTY = ds.Tables[0].Rows[j].ItemArray[15].CastTo<decimal>(-1);
                t_.ORDERQTY = ds.Tables[0].Rows[j].ItemArray[16].CastTo<decimal>(-1);
                t_.PACKAGENO= ds.Tables[0].Rows[j].ItemArray[17].CastTo<decimal>(-1);
                t_.PACKTASKNUM= ds.Tables[0].Rows[j].ItemArray[18].CastTo<decimal>(-1);
                t_.CIGNUM= ds.Tables[0].Rows[j].ItemArray[19].CastTo<decimal>(-1);
                t_.CIGTYPE= ds.Tables[0].Rows[j].ItemArray[20].CastTo<string>();
                t_.DOUBLETAKE= ds.Tables[0].Rows[j].ItemArray[21].CastTo<string>();
                t_.STATE= ds.Tables[0].Rows[j].ItemArray[22].CastTo<decimal>(-1);
                t_.ORDERDATE= ds.Tables[0].Rows[j].ItemArray[23].CastTo<DateTime>();
                t_.PUSHSPACE = ds.Tables[0].Rows[j].ItemArray[24].CastTo<decimal>(-1);
                t_.UNIONPACKAGETAG = ds.Tables[0].Rows[j].ItemArray[25].CastTo<decimal>(-1);
                t_.CIGSTATE = ds.Tables[0].Rows[j].ItemArray[26].CastTo<decimal>(-1);
                t_.NORMAILSTATE= ds.Tables[0].Rows[j].ItemArray[27].CastTo<decimal>(-1);
                t_.NORMALQTY= ds.Tables[0].Rows[j].ItemArray[28].CastTo<decimal>(-1);
                de.Add(t_);
            }

            return de;
        }
        /// <summary>
        /// 获取机器人任务
        /// </summary>
        /// <param name="ErrMsg">错误信息</param>
        /// <returns></returns>
        public string GetRobotInfo(out string ErrMsg)
        {
            try
            {
                ErrMsg = ""; //错误信息
                string info = ""; //任务信息
                using (Entities en = new Entities())
                {
                    var query = (from item in en.T_PACKAGE_TASK
                                 where item.PACKAGENO == GlobalPara.PackageNo && item.CIGSTATE == 10
                                 orderby item.CIGNUM
                                 select item).Take(10).ToList();
                    if (query.Any())
                    {
                        int index = 0;//双抓的索引
                        foreach (var item in query)
                        {
                            if (item.DOUBLETAKE == "1")
                            {

                                if (index == 0)
                                {
                                    info += "T,";//头部T 代表这是机器人任务
                                }
                                info += item.PACKTASKNUM.ToString().PadLeft(10, '0') + ",";//任务流水号 
                                info += item.CIGNUM.ToString().PadLeft(2, '0') + ",";//包内条烟流水号
                                info +=Convert.ToInt32(item.CIGWIDTHX).ToString().PadLeft(3, '0') + ",";// item.CIGWIDTHX + ",";// item.CIGWIDTHX + ",";//坐标X
                                info += 183.ToString().PadLeft(3, '0') + ","; //GlobalPara.BoxLenght/2 + ",";// (GlobalPara.BoxWidth / 2) + ",";//坐标Y
                                info += Convert.ToInt32(item.CIGHIGHY).ToString().PadLeft(3, '0') + ",";// item.CIGHIGHY + ",";// item.CIGHIGHY + ",";//坐标z
                                info += item.DOUBLETAKE + ",";//是否双抓
                                info += item.PACKAGEQTY.ToString().PadLeft(2, '0') + ","; ;//包内总数
                                info += item.CIGARETTECODE + ","; ;//条烟编码
                                info += item.CIGLENGTH.ToString().PadLeft(3, '0') + ","; ;//长
                                info += item.CIGWIDTH.ToString().PadLeft(3, '0') + ","; ;//宽
                                if (index == 0)
                                {
                                    info += item.CIGHIGH.ToString().PadLeft(3, '0') + "|";//高 
                                }
                                else
                                {
                                    info += item.CIGHIGH.ToString().PadLeft(3, '0');//高
                                }
                                if (index == 1)//最多循环两次
                                {
                                    break;
                                }
                                index++;
                            }
                            else if (index == 1)//出现一条有双抓标志但是下一条没有双抓标志的，有异常
                            {
                                ErrMsg = "";

                                ErrMsg = "出现一条有双抓标志但是下一条没有双抓标志的,任务流水号：" + query[1].SORTNUM;

                                throw new Exception(ErrMsg);

                            }
                            else
                            {
                                info += "T,";//头部T 代表这是机器人任务
                                info += item.PACKTASKNUM.ToString().PadLeft(10, '0') + ",";//任务流水号 
                                info += item.CIGNUM.ToString().PadLeft(2, '0') + ",";//包内条烟流水号
                                info += Convert.ToInt32(item.CIGWIDTHX).ToString().PadLeft(3, '0') + ",";// item.CIGWIDTHX + ",";// item.CIGWIDTHX + ",";//坐标X
                                info += 183.ToString().PadLeft(3, '0') + ","; //GlobalPara.BoxLenght/2 + ",";// (GlobalPara.BoxWidth / 2) + ",";//坐标Y
                                info += Convert.ToInt32(item.CIGHIGHY).ToString().PadLeft(3, '0') + ",";// item.CIGHIGHY + ",";// item.CIGHIGHY + ",";//坐标z
                                info += item.DOUBLETAKE + ",";//是否双抓
                                info += item.PACKAGEQTY.ToString().PadLeft(2, '0') + ","; ;//包内总数
                                info += item.CIGARETTECODE + ","; ;//条烟编码
                                info += item.CIGLENGTH.ToString().PadLeft(3, '0') + ","; ;//长
                                info += item.CIGWIDTH.ToString().PadLeft(3, '0') + ","; ;//宽
                                info += item.CIGHIGH.ToString().PadLeft(3, '0');
                                break;//但抓的情况 只需要取一条的信息
                            }
                        }
                    }
                    else//如果不包含元素， 任务已经做完
                    {
                        return info;
                    }
                    return info;
                }
            }
            catch (Exception ex)
            {

                throw ex = new Exception("连接数据库失败:" + ex.Message);
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

        public void UpDateFinishTask(string[] task, out string ErrMsg)
        {
            ErrMsg = "";
            try
            { 
                decimal taskNum = Convert.ToDecimal(task[0]);
                int CigSeq = int.Parse(task[1].ToString());
                using (Entities en = new Entities())
                {
                    var query1 = (from item in en.T_PACKAGE_TASK
                              where item.PACKTASKNUM == taskNum && item.PACKAGENO == packageno && item.CIGNUM == CigSeq
                              select item).ToList();
                if (query1.Any())
                {
                    foreach (var item in query1)
                    {
                        item.CIGSTATE = 20;
                    }

                    en.SaveChanges();//更新数据库
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
        ///  任务定位  
        /// 更新这个包装机包号之前的包号为完成，这个包装机包号之后的为新增 ,置新增的时候包括这个任务重新开始
        /// </summary>
        /// <param name="packagenum">机械手包号</param>
        /// <param name="cigseq">条烟流水号</param>
        /// <param name="fbTaskNum">翻版包号</param>
        /// <param name="yxyTaskNum">倍速链包号</param>
        /// <returns></returns>
        public bool TaskLocate(decimal packagenum,decimal cigseq,decimal fbTaskNum,decimal yxyTaskNum)
        {
            try
            {
                using (Entities entity = new Entities())
                {
                    //更新这个包号之前的任务为完成(不包括）
                    var query = (from item in entity.T_PACKAGE_TASK where item.PACKTASKNUM < packagenum && item.CIGSEQ < cigseq && item.CIGSTATE != 20 && item.PACKAGENO == packageno select item).ToList();
                    if (query.Any())
                    {
                        foreach (var item in query)
                        {
                            item.CIGSTATE = 20;//机器人条烟状态 
                        }
                    }
                    else
                    {
                        //throw new Exception("未查询到这个包号之前的任务信息");//有可能从第一个任务开始，这肯定会报错
                    }
                    //更新这个包号和之后的任务为新增（包括）
                    var query1 = (from item in entity.T_PACKAGE_TASK where item.PACKTASKNUM >= packagenum && item.CIGSEQ >= cigseq && item.PACKAGENO == packageno select item).ToList();
                    if (query.Any())
                    {
                        query1.ForEach(a => { a.CIGSTATE = 10; });

                    }

                    var fbQuery1 = (from item in entity.T_PACKAGE_TASK where item.PACKTASKNUM < fbTaskNum && item.CIGTYPE == "1" && item.PACKAGENO == packageno select item).ToList();
                    if (fbQuery1.Any())
                    {
                        fbQuery1.ForEach(a => { a.NORMAILSTATE = 20; });
                    }
                    //常规烟 翻版状态更新成信息 大于这个任务号的
                    var fbQuery2 = (from item in entity.T_PACKAGE_TASK where item.PACKTASKNUM >= fbTaskNum && item.CIGTYPE == "1" && item.PACKAGENO == packageno select item).ToList();
                    if (fbQuery2.Any())
                    {
                        fbQuery2.ForEach(a => { a.NORMAILSTATE = 10; });
                    }
                    //倍速链
                    //合包标志更新成完成 小于这个任务号的）
                    var yxyQuery1 = (from item in entity.T_PACKAGE_TASK where item.PACKTASKNUM < yxyTaskNum && item.CIGTYPE == "2" && item.PACKAGENO == packageno select item).ToList();
                    if (yxyQuery1.Any())
                    {
                        yxyQuery1.ForEach(a => { a.STATE = 20; });
                    }
                    //合包标志更新成新增大于这个任务号的）
                    var yxyQuery2 = (from item in entity.T_PACKAGE_TASK where item.PACKTASKNUM >= yxyTaskNum && item.CIGTYPE == "2" && item.PACKAGENO == packageno select item).ToList();
                    if (yxyQuery2.Any())
                    {
                        yxyQuery2.ForEach(a => { a.STATE = 10; });
                    }

                    if (entity.SaveChanges() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    } 
                }
            }
            catch (Exception ex)
            {

                throw new Exception("条烟定位失败，错误："+ex.Message);
            }
        }


        public bool CheckPackageTaskNum(decimal packagenum, decimal cigseq, decimal fbTaskNum, decimal yxyTaskNum,out string ErrInfo)
        {
            ErrInfo = "";
            using (Entities en = new Entities())
            {
                var Robot = (from item in en.T_PACKAGE_TASK where item.PACKTASKNUM == packagenum && item.CIGSEQ == cigseq select item).ToList().Any();
                if(!Robot)
                {
                    ErrInfo += "机器人：未找到任务号："+ packagenum +"，和条烟流水号"+ cigseq; 
                }
                var fb = (from item in en.T_PACKAGE_TASK where item.PACKTASKNUM == fbTaskNum select item).ToList().Any();
                if (!fb)
                {
                    ErrInfo += "\r\n翻版：未找到任务号：" + packagenum   ; 
                }
                var bsl = (from item in en.T_PACKAGE_TASK where item.PACKTASKNUM == yxyTaskNum select item).ToList().Any();
                if (!bsl)
                {
                    ErrInfo += "\r\n倍速链：未找到任务号：" + yxyTaskNum; 
                }
                if (string.IsNullOrWhiteSpace(ErrInfo)) 
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// 更新翻版和异型烟任务状态
        /// </summary>
        /// <param name="entities">实体</param>
        /// <param name="fbTaskNUm">目标翻版任务号</param>
        /// <param name="yxyTaskNum">目标异型烟任务号</param>
        /// <returns></returns>
        bool  UpdataFb(Entities entities,decimal  fbTaskNUm ,decimal yxyTaskNum)
        {
            //翻版 
            //常规烟翻版状态更新成完成 小于这个任务号的
           var fbQuery1=  (from item in entities.T_PACKAGE_TASK where item.PACKTASKNUM < fbTaskNUm && item.CIGTYPE == "1" && item.PACKAGENO == packageno select item).ToList();
            if (fbQuery1.Any())
            {
                fbQuery1.ForEach(a => { a.NORMAILSTATE = 20; });
            }
            //常规烟 翻版状态更新成信息 大于这个任务号的
           var fbQuery2= (from item in entities.T_PACKAGE_TASK where item.PACKTASKNUM >= fbTaskNUm && item.CIGTYPE == "1" && item.PACKAGENO == packageno select item).ToList();
            if (fbQuery2.Any())
            {
                fbQuery2.ForEach(a => { a.NORMAILSTATE = 10; });
            }
            //倍速链
            //合包标志更新成完成 小于这个任务号的）
            var yxyQuery1 = (from item in entities.T_PACKAGE_TASK where item.PACKTASKNUM < yxyTaskNum && item.CIGTYPE == "2" && item.PACKAGENO == packageno select item).ToList();
            if(yxyQuery1 .Any())
            {
                yxyQuery1.ForEach(a => { a.STATE = 20; });
            }
            //合包标志更新成新增大于这个任务号的）
           var yxyQuery2= (from item in entities.T_PACKAGE_TASK where item.PACKTASKNUM >= yxyTaskNum && item.CIGTYPE == "2" && item.PACKAGENO == packageno select item).ToList();
            if( yxyQuery2.Any())
            {
                yxyQuery2.ForEach(a => { a.STATE = 10; });
            }
            if( entities.SaveChanges ()> 0)//更新数据库
            {
                return true;
            }
            else
            {
                return false;
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
