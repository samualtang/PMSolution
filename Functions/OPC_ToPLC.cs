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

        private Group shapeGroup3;
        private Group shapeGroup4;

        private Group spyGroup6;
        private Group shapeGroup7;
        private Group shapeGroup8;

        /// <summary>
        /// 是否已经在发送任务：true有，false没有
        /// </summary>
        public bool startatg = false;
        /// <summary>
        /// 创建opc连接
        /// </summary>
        public string[] CreateOPCServer()
        {
            string[] strmessage = new string[2];
            try
            {
                svrComponenttyp = Type.GetTypeFromProgID(SERVER_NAME);
                pIOPCServer = (IOPCServer)Activator.CreateInstance(svrComponenttyp);            //创建服务器连接对象
            }
            catch (ArgumentNullException)
            {
                strmessage[0] += "服务器对象创建失败,未能建立异型烟链板机plc连接，请检查plc连接与opc服务是否正常";
                strmessage[1] = "0";
                return strmessage;
            }
            catch (Exception ex)
            {
                strmessage[0] += ex;
                strmessage[1] = "0";
                return strmessage;
            }
            ShapeGroup1 = new Group(pIOPCServer, 1, "group1", 1, LOCALE_ID);           //创建组
            ShapeGroup1.addItem(ItemCollection.GetTaskStatusBySend_yxy());           //添加项到组  包装机异型烟链板机（合包）数据写入DB块
            ShapeGroup2 = new Group(pIOPCServer, 2, "group2", 1, LOCALE_ID);           //创建组
            ShapeGroup2.addItem(ItemCollection.GetTaskStatusByComplete_yxy());           //添加项到组  (合包)完成信号的DB块

            ShapeGroup3 = new Group(pIOPCServer, 3, "group3", 1, LOCALE_ID);           //创建组
            ShapeGroup3.addItem(ItemCollection.GetTaskStatusByComplete_cgy());           //添加项到组  翻板机完成信号的DB块
            ShapeGroup4 = new Group(pIOPCServer, 4, "group4", 1, LOCALE_ID);           //创建组
            ShapeGroup4.addItem(ItemCollection.GetTaskStatusBySend_cgy());           //添加项到组  包装机常规烟翻板数据写入DB块

            UnNormalGroup = new Group(pIOPCServer, 5, "group5", 1, LOCALE_ID);
            UnNormalGroup.addItem(ItemCollection.GetUnNormalWorkPlaceItem());

            SpyGroup6 = new Group(pIOPCServer, 6, "group6", 1, LOCALE_ID);  //创建监控标志位的
            SpyGroup6.addItem(ItemCollection.GetSpyStateItem());

            ShapeGroup7 = new Group(pIOPCServer, 7, "group7", 1, LOCALE_ID);  //翻板任务清空
            ShapeGroup7.addItem(ItemCollection.ClearAndStop_cgy());

            ShapeGroup8 = new Group(pIOPCServer, 8, "group8", 1, LOCALE_ID);  //倍速链任务清空
            ShapeGroup8.addItem(ItemCollection.ClearAndStop_yxy());
            
            strmessage[0] +="";//写入校验plc连接尝试结果
            strmessage[1] = "1";
            return strmessage;

        }

        /// <summary>
        /// 包装机异型烟链板机 任务发送
        /// </summary>
        public Group ShapeGroup1 { get => shapeGroup1; set => shapeGroup1 = value; }
        /// <summary>
        /// 包装机异型烟链板机 完成信号
        /// </summary>
        public Group ShapeGroup2 { get => shapeGroup2; set => shapeGroup2 = value; }
        /// <summary>
        /// 常规烟翻板 任务发送
        /// </summary>
        public Group ShapeGroup4 { get => shapeGroup4; set => shapeGroup4 = value; }
        /// <summary>
        /// 常规烟翻板 完成信号
        /// </summary>
        public Group ShapeGroup3 { get => shapeGroup3; set => shapeGroup3 = value; }
        /// <summary>
        /// 异形烟缓存工位工位
        /// </summary>
        public Group UnNormalGroup { get; set; }
        /// <summary>
        /// 标志位监控组
        /// </summary>
        public Group SpyGroup6 { get => spyGroup6; set => spyGroup6 = value; }
        /// <summary>
        /// 翻版任务清空
        /// </summary>
        public Group ShapeGroup7 { get => shapeGroup7; set => shapeGroup7 = value; }

        /// <summary>
        /// 倍速链任务清空
        /// </summary>
        public Group ShapeGroup8 { get => shapeGroup8; set => shapeGroup8 = value; }

        /// <summary>
        /// 检验opc连接  
        /// </summary>
        /// <returns></returns>
        public bool CheckYXYConnection()
        { 
            //包装机异型烟链板机（合包）plc连接状态
            int flag1 = SpyGroup6.ReadD(0).CastTo<int>(-1);//读取异型烟翻版标志
            if (flag1 == -1)
            {
                return false;
            }
            else
            {
               return true; 
            } 
        }

        /// <summary>
        /// 检查常规烟翻版连接是否成功
        /// </summary>
        /// <returns></returns>
        public bool CheckFbConnction()
        {
            int flag2 = SpyGroup6.ReadD(1).CastTo<int>(-1);//读取常规烟标志
            if (flag2 == -1)
            {
               return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 强制跳变任务交互区
        /// </summary>
        /// <returns></returns>
        public string timerSendTask()
        {
            string str = "";
            if (!startatg && SpyGroup6.ReadD(0).CastTo<int>(-1) != 1)//倍速链任务跳变
            {
                SpyGroup6.Write(2, 0);
                SpyGroup6.Write(0, 0);
                str = "异型烟倍速链：发送任务";
            }
            else
            {
                str += "异型烟倍速链：强制跳变失败";
            }
            if (!startatg && SpyGroup6.ReadD(1).CastTo<int>(-1) != 1)//常规烟任务跳变
            {
                SpyGroup6.Write(2, 1);
                SpyGroup6.Write(0, 1);
                str += "常规烟翻版：发送任务";
            }
            else
            {
                str += "常规烟翻版：强制跳变失败";
            }
            return str;
        }

        /// <summary>
        /// 开启程序时 读取异型烟所有任务完成区DB块的内容 并置数据库完成返回置完成的任务号数组
        /// </summary>
        /// <returns>步骤日志</returns>
        public string ReadAndWriteYXYTaskConpelte()
        {
            string strmessage = "读取异型烟倍速链完成信号块：";
            int[] result = new int[ItemCollection.GetTaskStatusByComplete_yxy().Count];
            for (int i = 0; i < result.Length; i++)
            {
                //读取完成标志
                result[i] = ShapeGroup2.ReadD(i).CastTo<int>(-1);
                //如果完成标志块内有大于0的值
                if (result[i] > 0)
                {
                    //strmessage += "读取到异型烟链板机电控DB块：" + ItemCollection.GetTaskStatusByComplete_yxy()[i] + "  值：" + result[i];
                    //数据库置完成该任务
                    bool tag = BLL.PLCDataGet.UpdataTaskcomplent_yxy(result[i] );
                    if (tag)
                    {
                        strmessage += "异型烟倍速链：任务包号 " + result[i] +   "，数据库已置完成";
                    }
                    else
                    {
                        strmessage += "异型烟倍速链：任务包号 " + result[i] + "，更新数据库失败";
                    }
                    //更新电控完成标志块
                    ShapeGroup2.Write(0, i);
                   // strmessage += "，电控PLC数据已重置\r\n";
                }
            }
            return strmessage;
        }
        /// <summary>
        /// 开启程序时 读取常规烟所有任务完成区DB块的内容 并置数据库完成返回置完成的任务号数组
        /// </summary>
        /// <returns>步骤日志</returns>
        public string ReadAndWriteCGYTaskConpelte()
        {
            string strmessage = "读取常规烟翻版完成信号块：";
            int[] result = new int[ItemCollection.GetTaskStatusByComplete_cgy().Count];
            for (int i = 0; i < result.Length; i++)
            {
                //读取完成标志
                result[i] = ShapeGroup3.ReadD(i).CastTo(-1);
                //如果完成标志块内有大于0的值
                if (result[i] > 0)
                {
                    //strmessage += "读取到常规烟翻板电控DB块：" + ItemCollection.GetTaskStatusByComplete_cgy()[i] + "  值：" + result[i];
                    //数据库置完成该任务
                    bool tag = BLL.PLCDataGet.UpdataTaskcomplent_cgy(result[i]);
                    if (tag)
                    {
                        strmessage +="常规烟翻版：任务包号 "+ result[i]+ "，数据库已置完成";
                    }
                    else
                    {
                        strmessage += "常规烟翻版：任务包号 " + result[i] + "，更新数据库失败";
                    }
                    //更新电控完成标志块
                    ShapeGroup3.Write(0, i);
                   // strmessage += "，电控PLC数据已重置/r/n";
                }
            }
            return strmessage;
        }
        /// <summary>
        /// 更新异型烟合包任务状态
        /// </summary>
        /// <param name="packageNum">任务包号</param>
        /// <param name="state">状态10新增，15电控接收，20完成</param>
        /// <returns></returns>
        public bool UpDateToYxyState(int packageNum,int state)
        {
            if (BLL.PLCDataGet.UpdataTask_yxy(packageNum, state))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 更新常规烟任务状态
        /// </summary>
        /// <param name="packageNum">任务包号</param>
        /// <param name="state">状态10新增，15电控接收，20完成</param>
        /// <returns></returns>
        public bool UpDateToCgyState(int packageNum, int state)
        {
            if (BLL.PLCDataGet.UpdataTask_cgy(packageNum, state))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 根据完成信号更新数据库单包任务
        /// </summary>
        /// <param name="packtasknum">完成任务号</param>
        /// <param name="index">当前完成任务号的DB块索引</param>
        /// <returns>完成/失败</returns>
        public string ReadAndWriteYXYTaskConpelte(int packtasknum,int index)
        {
            string strmessage = "异型烟倍速链：";
            if (BLL.PLCDataGet.UpdataTask_yxy(packtasknum))
            {
                strmessage += packtasknum + "号任务数据库更新完成成功";
                ShapeGroup2.Write(0, index);
                //strmessage += packtasknum + ",电控数据更新成功!";
            }
            else
            {
                strmessage += packtasknum + "号任务数据库更新完成失败";
            }
            return strmessage;
        }
        /// <summary>
        /// 根据完成信号更新数据库单包任务
        /// </summary>
        /// <param name="packtasknum">完成任务号</param>
        /// <param name="index">当前完成任务号的DB块索引</param>
        /// <returns>完成/失败</returns>
        public string ReadAndWriteCGYTaskConpelte(int packtasknum, int index)
        {
            string strmessage = "常规烟翻版：";
            if (BLL.PLCDataGet.UpdataTask_cgy(packtasknum))
            {
                strmessage += packtasknum + "号任务数据库更新完成成功";
                try
                {
                    ShapeGroup3.Write(0, index);
                    strmessage += packtasknum + ",电控数据更新成功!";
                }
                catch (Exception)
                {
                    ShapeGroup3.Write(0, index);
                    strmessage += packtasknum + ",电控数据更新失败!";
                }
            }
            else
            {
                strmessage += packtasknum + "号任务数据库更新完成失败";
            }
            return strmessage;
        }

        /// <summary>
        /// 写入异型烟链板机（合包）任务发送区DB块的内容
        /// </summary>
        /// <returns></returns>
        public async Task<string> WriteTaskSend_YXY()
        {
            startatg = true;
            string Strmessage ="";
            try
            { 
                 
                object[] vs = new object[ItemCollection.GetTaskStatusBySend_yxy().Count()];
                //取当前包装机未发送的的异型烟链板机（合包）任务
             aa: List<EFModle.T_PACKAGE_TASK> values = await Task.Run(() => BLL.PLCDataGet.GetAllNotSendTask_YXY(GlobalPara.PackageNo));
                if (values.Count > 0)
                {
                    //取最小任务号(要发送的任务)
                    decimal packtasknum = values.Min(x => x.PACKTASKNUM).Value;
                    //取出要发送的异型烟数量
                    int AllYXY = values.Where(x => x.PACKTASKNUM == packtasknum && x.CIGTYPE == "2").Count();
                    //取出要发送的合包常规烟数量
                    int AllCG = Convert.ToInt32(values.Where(x => x.PACKTASKNUM == packtasknum && x.CIGTYPE == "1").Sum(X => X.NORMALQTY));
                    //其他不需要统计的数据
                    EFModle.T_PACKAGE_TASK task = values.Where(x => x.PACKTASKNUM == packtasknum).FirstOrDefault();

                    vs[0] = Convert.ToInt32(task.PACKTASKNUM); //包号1
                    vs[1] = AllYXY;//数量2
                    vs[2] = Convert.ToInt32(task.UNIONPACKAGETAG); //合包标志3
                    vs[3] = Convert.ToInt32(task.PUSHSPACE); //推烟位置（层数） 4
                    vs[4] = AllCG;//合包数量
                    vs[5] = 0;//预留 
                    vs[6] = 0;//预留 
                    vs[7] = 1;//交互标志
                    if (AllYXY > 0)//如果是非纯常规烟订单
                    {
                        ShapeGroup1.SyncWrite(vs);
                        //BLL.PLCDataGet.WriteReceive_YXY((int)packtasknum);//测试用的  
                        Strmessage = "异型烟倍速链：：\r\n任务号：" + vs[0] + "，异型烟数量：" + vs[1] + "，合包标志：" +
                            vs[2] + "，合包常规烟数：" + vs[4] + "，推烟位置：" + vs[3] + "，接收标志：" + vs[7];
                    }
                    else
                    {
                        BLL.PLCDataGet.WriteReceive_YXY((int)packtasknum);
                        Strmessage = await WriteTaskSend_YXY();
                    }
                }
                else
                {
                    Strmessage = "异型烟倍速链：当前没有可发送的任务！10秒之后再次获取";
                    Thread.Sleep(10000);
                    goto aa;
                }
                startatg = false;
            }
            catch (Exception ex)
            {
                writeLog.Write(ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != null)
                {
                    writeLog.Write(ex.InnerException.Message);
                }
                Strmessage += "异型烟倍速链：发生异常，10秒后重新发送任务；";
                DateTime endtime = DateTime.Now.AddSeconds(10);
                Thread.Sleep(10000);
                await WriteTaskSend_YXY();//异常后重新发送  没有考虑失败暂停
            }
            return Strmessage;
        }

        /// <summary>
        /// 写入常规烟 任务发送区DB块的内容
        /// </summary>
        /// <returns></returns>
        public async Task< string> WriteTaskSend_CGY()
        {
            startatg = true;
            string Strmessage = "";
            try
            {
                object[] vs = new object[ItemCollection.GetTaskStatusBySend_cgy().Count()];

                //取当前包装机未发送的的异型烟链板机（合包）任务
               aa: List<EFModle.T_PACKAGE_TASK> values = await Task.Run(() => BLL.PLCDataGet.GetAllNotSendTask_CGY(GlobalPara.PackageNo));
                if (values.Count > 0)
                {
                    //取最小任务号(要发送的任务)
                    decimal packtasknum = values.Min(x => x.PACKTASKNUM).Value;
                    //取出要发送的异型烟数量  不判断包类型
                    int AllYXY = values.Where(x => x.PACKTASKNUM == packtasknum && x.CIGTYPE == "2").Count();
                    //取出要发送的合包常规烟数量
                    int AllCG = Convert.ToInt32(values.Where(x => x.PACKTASKNUM == packtasknum && x.CIGTYPE == "1").Sum(X => X.NORMALQTY));
                    //其他不需要统计的数据
                    EFModle.T_PACKAGE_TASK task = values.Where(x => x.PACKTASKNUM == packtasknum).FirstOrDefault();

                    vs[0] = Convert.ToInt32(task.PACKTASKNUM); //包任务号
                    vs[1] = AllCG;//包内烟条数
                    vs[2] = Convert.ToInt32(task.UNIONPACKAGETAG); //合包标志
                    vs[3] = AllYXY;//合包数量（异型烟）
                    vs[6] = 1;//交互标志

                    //if (AllCG > 0)//如果是非纯常规烟订单
                    //{
                        //BLL.PLCDataGet.WriteReceive_CGY((int)packtasknum);//测试用的  
                        ShapeGroup4.SyncWrite(vs);
                        Strmessage = "常规烟翻版：\r\n任务号：" + vs[0] + "，常规烟数量：" + vs[1] + "，合包标志：" +
                            vs[2] + "，合包异型烟数：" + vs[3] + "，接收标志：" + vs[6];
                    //}
                    //else
                    //{
                    //    BLL.PLCDataGet.WriteReceive_CGY((int)packtasknum);
                    //    await WriteTaskSend_YXY();
                    //}
                }
                else
                {
                    Strmessage = "常规烟翻版：当前没有可发送常规烟的任务！10秒之后再次获取";
                    Thread.Sleep(10000);
                    goto aa;
                }
            }

            catch (Exception ex)
            {
                writeLog.Write(ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != null)
                {
                    writeLog.Write(ex.InnerException.Message);
                }
                Strmessage += "常规烟翻版：发生异常，从新发送任务；";
                DateTime endtime = DateTime.Now.AddSeconds(10);
                Thread.Sleep(10000);
                await WriteTaskSend_CGY();//异常后重新发送  没有考虑失败暂停
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
                strmessage = "异型烟倍速链：任务包号：" + packtasknum + " 已接收";
                return strmessage;
            }
            else
            {
                strmessage = "异型烟倍速链：任务包号：" + packtasknum + " 数据库更新失败！任务包号未能更新成接收状态！";
                return strmessage;
            }
            
                
            
            
        }


        /// <summary>
        /// 倍速链任务清空
        /// </summary>
        /// <returns></returns>
        public async Task<bool> ClearPLCDataBSL()
        {
            string Strmessage = "清空倍速链数据：";
            try
            {
                object[] vs = new object[ItemCollection.ClearAndStop_yxy().Count()];
                vs[0] = 1;
                ShapeGroup8.SyncWrite(vs);
                Strmessage += "清空数据中:" + System.DateTime.Now.ToLongTimeString() + "写入标志1 成功";
                while (true)
                {
                    if (ShapeGroup8.Read(0).ToString() == "1")
                    {
                        Thread.Sleep(200);
                    }
                    else
                    {
                        break;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                writeLog.Write(ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != null)
                {
                    writeLog.Write(ex.InnerException.Message);
                }
                Strmessage += "清空倍速链数据失败";
                if (ShapeGroup8 == null)
                {
                    Strmessage += "PLC连接未成功建立！请等待连接建立成功后再试！";
                }
                return false;
            }
            finally
            {
                writeLog.Write(Strmessage);
            }
        }


        /// <summary>
        /// 翻板任务清空
        /// </summary>
        /// <returns></returns>
        public async Task<bool> ClearPLCDataFB()
        {
            string Strmessage = "清空翻板数据：";
            try
            {
                object[] vs = new object[ItemCollection.ClearAndStop_cgy().Count()];
                vs[0] = 1;
                ShapeGroup7.SyncWrite(vs);
                Strmessage += "清空数据中:" + System.DateTime.Now.ToLongTimeString() + "写入标志1 成功!";
                while (true)
                {
                    if (ShapeGroup7.Read(0).ToString() == "1")
                    {
                        Thread.Sleep(200);
                    }
                    else
                    {
                        break;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                writeLog.Write(ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != null)
                {
                    writeLog.Write(ex.InnerException.Message);
                }
                Strmessage += "清空翻板数据失败!";
                if (ShapeGroup8 == null)
                {
                    Strmessage += "PLC连接未成功建立！请等待连接建立成功后再试！";
                }
                return false;
            }
            finally
            {
                writeLog.Write(Strmessage);
            }
        }
    }
}