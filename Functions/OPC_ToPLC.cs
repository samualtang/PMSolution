using Functions.Model;
using Functions.PubFunction;
using OpcRcw.Da;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks; 


namespace Functions
{
    public class OPC_ToPLC
    {
        public const string SERVER_NAME = "OPC.SimaticNET";       // local server name //OPC服务器名称
        public const string GROUP_NAME = "grp1";                  // Group name //组名
        public const int LOCALE_ID = 0x409;                       // LOCALE FOR ENGLISH. 
        public IOPCServer pIOPCServer;                     //定义opcServer对象.opc服务器接口指针
        public Type svrComponenttyp;                       //服务器类型
        public Guid iidRequiredInterface = typeof(IOPCItemMgt).GUID;

        public WriteLog writeLog = WriteLog.GetLog();
        private Group shapeGroup1;
        private Group shapeGroup2;
        /// <summary>
        /// 是否开始自动发送过任务：true有，false没有
        /// </summary>
        private bool startatg = false;
        /// <summary>
        /// 创建opc连接
        /// </summary>
        public string[] ConnectionToPLCYXY()
        {
            string[] strmessage =new string[2];
            try
            {
                svrComponenttyp = Type.GetTypeFromProgID(SERVER_NAME);
                pIOPCServer = (IOPCServer)Activator.CreateInstance(svrComponenttyp);            //创建服务器连接对象

                ShapeGroup1 = new Group(pIOPCServer, 1, "group1", 1, LOCALE_ID);           //创建组
                ShapeGroup1.addItem(ItemCollection.GetTaskStatusBySend_yxy());           //添加项到组  包装机异型烟链板机（合包）数据写入DB块
                ShapeGroup2 = new Group(pIOPCServer, 1, "group2", 2, LOCALE_ID);           //创建组
                ShapeGroup2.addItem(ItemCollection.GetTaskStatusByComplete_yxy());           //添加项到组  (合包)完成信号的DB块

                strmessage[0] += CheckConnection();
                strmessage[1] = "1";
                return strmessage;
            }
            catch (ArgumentNullException ex)
            {
                strmessage[0] += "未能建立plc连接，请检查是否安装opc服务";
                strmessage[1] = "0";
                return strmessage;
            }
            catch (Exception ex)
            {
                strmessage[0] += "plc连接建立失败；"+ex.Message;
                strmessage[1] = "0";
                return strmessage;
            }    
        }


        public Group ShapeGroup1 { get => shapeGroup1; set => shapeGroup1 = value; }
        public Group ShapeGroup2 { get => shapeGroup2; set => shapeGroup2 = value; }

        /// <summary>
        /// 检验opc连接  
        /// </summary>
        /// <returns></returns>
        public string CheckConnection()
        {
            string strmssage = "";
            //包装机异型烟链板机（合包）plc连接状态
            int flag1 = ShapeGroup1.ReadD(0).CastTo<int>(-1);
            if (flag1 == -1)
            {
                strmssage += "异型烟链板机plc连接失败！";
            }
            else
            {
                strmssage += "异型烟链板机plc连接成功！";
            }
            strmssage += "/r/n" + ReadAndWriteYXYTaskConpelte();//获取所有缓存的完成信号
            //强制跳变任务发送区标志


            return strmssage;
        }

        public string timerSendTask()
        {
            if (!startatg && ShapeGroup1.ReadD(7).CastTo<int>(-1) != 1)
            {
                ShapeGroup1.Write(2, 0);
                ShapeGroup1.Write(0, 0);
            }
            return "发送异型烟链板机任务";
        }

        /// <summary>
        /// 开启程序时 读取异型烟所有任务完成区DB块的内容 并置数据库完成返回置完成的任务号数组
        /// </summary>
        /// <returns>步骤日志</returns>
        public string ReadAndWriteYXYTaskConpelte()
        {
            string strmessage = "";
            int[] result = new int[10];
            for (int i = 0; i < ItemCollection.GetTaskStatusByComplete_yxy().Count(); i++)
            {
                //读取完成标志
                result[i] = ShapeGroup2.ReadD(i).CastTo<int>(-1);
                //如果完成标志块内有大于0的值
                if (result[i] > 0)
                {
                    strmessage += "读取到电控DB块：" + ItemCollection.GetTaskStatusByComplete_yxy()[i] + "  值：" + result[i];
                    //数据库置完成该任务
                    bool tag = BLL.PLCDataGet.UpdataTask(result[i]);
                    if (tag)
                    {
                        strmessage += "，数据库已置完成";
                    }                    
                    
                    //更新电控完成标志块
                    ShapeGroup2.Write(0, i);
                    strmessage += "，电控PLC数据已重置/r/n";
                }
            }
            return strmessage;
        }

        /// <summary>
        /// 根据完成信号更新数据库单包任务
        /// </summary>
        /// <param name="packtasknum">完成任务号</param>
        /// <param name="index">当前完成任务号的DB块索引</param>
        /// <returns>完成/失败</returns>
        public string ReadAndWriteYXYTaskConpelte(int packtasknum,int index)
        {
            string strmessage = "";
            if (BLL.PLCDataGet.UpdataTask(packtasknum))
            {
                strmessage = packtasknum + "号任务数据库更新完成成功";
                ShapeGroup2.Write(0, index);
                strmessage += packtasknum + ",电控数据更新成功!";
            }
            else
            {
                strmessage = packtasknum + "号任务数据库更新完成失败";
            }
            return strmessage;
        }

        /// <summary>
        /// 写入异型烟链板机（合包）任务发送区DB块的内容
        /// </summary>
        /// <returns></returns>
        public string WriteTaskSend_YXY()
        {
            startatg = true;
            string Strmessage ="";
            try
            {
                object[] vs = new object[ItemCollection.GetTaskStatusBySend_yxy().Count()];
                using (EFModle.Entities et = new EFModle.Entities())
                {
                    //取当前包装机未发送的的异型烟链板机（合包）任务
                    List<EFModle.T_PACKAGE_TASK> values = BLL.PLCDataGet.GetAllNotSendTask(GlobalPara.PackageNo);
                    
                    //取最小任务号(要发送的任务)
                    decimal packtasknum = values.Min(x => x.PACKTASKNUM).Value;
                    //取出要发送的异型烟数量
                    int AllYXY = values.Where(x => x.PACKTASKNUM == packtasknum && x.CIGTYPE == "2").Count();
                    //取出要发送的合包常规烟数量
                    int AllCG = Convert.ToInt32(values.Where(x => x.PACKTASKNUM == packtasknum && x.CIGTYPE == "1").Sum(X => X.NORMALQTY));
                    //其他不需要统计的数据
                    EFModle.T_PACKAGE_TASK task = values.Where(x => x.PACKTASKNUM == packtasknum).FirstOrDefault();

                    vs[0] = Convert.ToInt32(task.PACKTASKNUM); //包号
                    vs[1] = AllYXY;//数量
                    vs[2] = Convert.ToInt32(task.UNIONPACKAGETAG); //合包标志
                    vs[3] = AllCG;//合包数量
                    vs[4] = Convert.ToInt32(task.PUSHSPACE);//推烟位置（层数）
                    vs[5] = 0;//预留 
                    vs[6] = 0;//预留 
                    vs[7] = 1;//交互标志

                    ShapeGroup1.SyncWrite(vs);
                    Strmessage = "写入异型烟链板机：/r/n任务号：" + vs[0] + "，异型烟数量：" + vs[1] + "，合包标志：" +
                        vs[2] + "，合包常规烟数：" + vs[3] + "，推烟位置：" + vs[4] + "，接收标志：" + vs[7];
                } 
            }
            catch (Exception ex)
            {
                writeLog.Write(ex.Message);  
                if (ex.InnerException != null && ex.InnerException.Message != null)
                {
                    writeLog.Write(ex.InnerException.Message);  
                }
                Strmessage += "发生异常，从新发送任务；";
                DateTime endtime = DateTime.Now.AddSeconds(10);
                Thread.Sleep(10000);
                WriteTaskSend_YXY();//异常后重新发送  没有考虑失败暂停
            }
            return Strmessage;
        }

        /// <summary>
        /// 根据接收信号的任务，数据库置接收 更改标志位
        /// </summary>
        /// <param name="packtasknum"></param>
        public string WriteDBReceive_YXY(int packtasknum)
        {
            string strmessage = "";
            if (BLL.PLCDataGet.WriteReceive_YXY(packtasknum))//如果数据库更新成功
            {  
                strmessage = "异型烟链板机任务号：" + packtasknum + "已接收";
                return strmessage;
            }
            else
            {
                strmessage = "异型烟链板机任务号：" + packtasknum + "数据库更新失败！未更改电控标志位数据";
                return strmessage;
            }
            
                
            
            
        }              
 
    }
}