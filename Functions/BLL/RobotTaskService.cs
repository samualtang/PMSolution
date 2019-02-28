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
        public object[] GetRobotInfo(out string ErrMsg)
        {
            try
            {
                ErrMsg = "";
                object[] ArrInfo = new object[11];
                for (int i = 0; i < ArrInfo.Length; i++)//初始化
                {
                    ArrInfo[i] = 0;
                }
                using (Entities en = new Entities())
                {
                    var query = (from item in en.T_PACKAGE_TASK
                                 where item.PACKAGENO == GlobalPara.PackageNo && item.STATE == 10
                                 orderby item.CIGNUM
                                 select item).ToList();
                    if (query != null)
                    {
                        int index = 0;//双抓的索引
                        foreach (var item in query)
                        {
                            if (item.DOUBLETAKE == "1")
                            {
                                ArrInfo = new object[22];
                                for (int i = 0; i < ArrInfo.Length; i++)//初始化
                                {
                                    ArrInfo[i] = 0;
                                }
                                ArrInfo[index * 11] = item.PACKTASKNUM + ",";//任务流水号 
                                ArrInfo[index * 11 + 1] = item.CIGSEQ + ",";//包内条烟流水号
                                ArrInfo[index * 11 + 2] = item.CIGWIDTHX + ",";//坐标X
                                ArrInfo[index * 11 + 3] = (GlobalPara.BoxWidth / 2) + ",";//坐标Y
                                ArrInfo[index * 11 + 4] = item.CIGHIGHY + ",";//坐标z
                                ArrInfo[index * 11 + 5] = item.DOUBLETAKE + ",";//是否双抓
                                ArrInfo[index * 11 + 6] = item.PACKAGEQTY + ",";//包内总数
                                ArrInfo[index * 11 + 7] = item.CIGARETTECODE + ",";//条烟编码
                                ArrInfo[index * 11 + 8] = item.CIGLENGTH + ",";//长
                                ArrInfo[index * 11 + 9] = item.CIGWIDTH + ",";//宽
                                ArrInfo[index * 11 + 10] = item.CIGHIGH + "|";//高
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
                                    ErrMsg = "出现一条有双抓标志但是下一条没有双抓标志的,任务号：" + query[1].SORTNUM;
                                }
                                catch (Exception ex)
                                {
                                    throw ex = new Exception(ErrMsg);
                                }
                            }
                            else
                            {
                                ArrInfo[0] = item.PACKTASKNUM + ",";//任务流水号 
                                ArrInfo[1] = item.CIGNUM + ",";//包内条烟流水号
                                ArrInfo[2] = item.CIGWIDTHX + ",";//坐标X
                                ArrInfo[3] = (GlobalPara.BoxWidth / 2) + ",";//坐标Y
                                ArrInfo[4] = item.CIGHIGHY + ",";//坐标z
                                ArrInfo[5] = item.DOUBLETAKE + ",";//是否双抓
                                ArrInfo[6] = item.PACKAGEQTY + ",";//包内总数
                                ArrInfo[7] = item.CIGARETTECODE + ",";//条烟编码
                                ArrInfo[8] = item.CIGLENGTH + ",";//长
                                ArrInfo[9] = item.CIGWIDTH + ",";//宽
                                ArrInfo[10] = item.CIGHIGH;//高
                                break;//但抓的情况 只需要取一条的信息
                            }
                        }

                    }
                }
                return ArrInfo;
            }
            catch (Exception ex )
            {

                throw ex = new Exception("连接数据失败:"+ex.Message);
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
                    var query = (from item in en.T_PACKAGE_TASK
                                 where item.PACKTASKNUM == taskNum && item.CIGSEQ == CigSeq
                                 select item).ToList();
                    if (query != null && query.Count > 0)
                    {
                        foreach (var item in query)
                        {
                            item.FINISHTIME = DateTime.Now;
                            item.STATE = 20;
                        }
                        en.SaveChanges();
                    }
                    else
                    {
                        ErrMsg += "未找到任务号" + taskNum + ",和条烟流水号" + CigSeq;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrMsg += "机器人任务服务类，更新完成任务方法，数据库连接失败:" + ex.Message;
                throw ex = new Exception(ErrMsg);
            }
        }
    }
}
