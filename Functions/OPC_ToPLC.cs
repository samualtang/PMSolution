using Functions.Model;
using Functions.PubFunction;
using OpcRcw.Da;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 


namespace Functions
{
    public class OPC_ToPLC
    {
        public const string SERVER_NAME = "OPC.SimaticNET";       // local server name //OPC服务器名称
        public const string GROUP_NAME = "grp1";                  // Group name //组名
        public const int LOCALE_ID = 0x409;                       // LOCALE FOR ENGLISH. 
        public IOPCServer pIOPCServer;                     //定义opcServer对象.opc服务器接口指针
        public Group ShapeGroup1, ShapeGroup2;
        public Type svrComponenttyp;                       //服务器类型
        public Guid iidRequiredInterface = typeof(IOPCItemMgt).GUID;

        public WriteLog writeLog = WriteLog.GetLog();

        /// <summary>
        /// 创建opc连接
        /// </summary>
        public void ConnectionToPLCYXY()
        {
            svrComponenttyp = Type.GetTypeFromProgID(SERVER_NAME);
            pIOPCServer = (IOPCServer)Activator.CreateInstance(svrComponenttyp);            //创建服务器连接对象

            ShapeGroup1 = new Group(pIOPCServer, 1, "group1", 1, LOCALE_ID);           //创建组
            ShapeGroup1.addItem(ItemCollection.GetTaskStatusBySend());           //添加项到组  包装机异型烟链板机（合包）数据写入DB块
            ShapeGroup2 = new Group(pIOPCServer, 1, "group2", 2, LOCALE_ID);           //创建组
            ShapeGroup2.addItem(ItemCollection.GetTaskStatusByComplete());           //添加项到组  (合包)完成信号的DB块
            ShapeGroup1.callback += OnDataChange;
            ShapeGroup2.callback += OnDataChange;
        }
        /// <summary>
        /// 包装机异型烟链板机数据写入DB块的数组
        /// </summary>
        public readonly decimal[] DbIndexBySend = new decimal[ItemCollection.GetTaskStatusBySend().Count()];
        /// <summary>
        /// 完成信号的DB块的数组
        /// </summary>
        public readonly decimal[] DbIndexByConpelte = new decimal[ItemCollection.GetTaskStatusByComplete().Count()];

        /// <summary>
        /// 检验opc连接  
        /// </summary>
        /// <returns></returns>
        public bool[] CheckConnection()
        {
            bool[] vs = new bool[2];
            //包装机异型烟链板机（合包）plc连接状态
            int flag1 = ShapeGroup1.ReadD(Convert.ToInt32(DbIndexBySend[0])).CastTo<int>(-1);
            if (flag1 == -1)
            {
                vs[0] = false; 
            }
            else
            {
                vs[0] = true;
            }

            //********************************

            return vs;
        }
        //读取任务发送区DB块的内容
        public string ReadTaskSend()
        {
            return "";
        }

        /// <summary>
        /// 开启程序时 读取异型烟所有任务完成区DB块的内容 并置数据库完成返回置完成的任务号数组
        /// </summary>
        /// <returns></returns>
        public string[] ReadAndWriteYXYTaskConpelte()
        {
            string[] vs = new string[10];
            int[] result = new int[10];
            for (int i = 0; i < DbIndexByConpelte.Count(); i++)
            {
                //读取完成标志
                result[i] = ShapeGroup2.ReadD(Convert.ToInt32(DbIndexByConpelte[i])).CastTo<int>(-1);
                //如果完成标志块内有大于0的值
                if (result[i] > 0)
                {
                    //数据库置完成该任务
                    using (EFModle.Entities et =new EFModle.Entities())
                    {
                        List<EFModle.T_PACKAGE_TASK> lists = et.T_PACKAGE_TASK.Where(x => x.PACKTASKNUM == result[i]).Select(x => x).ToList();
                        foreach (var item in lists)
                        {
                            item.STATE = 20;
                        }
                    }
                    //更新电控完成标志块
                    ShapeGroup2.Write(0, i);
                    vs[i] = "读取到电控DB块：" + DbIndexByConpelte[i] + "  值：" + result[i];
                }
            }
            return vs;
        }


        /// <summary>
        /// 写入异型烟链板机（合包）任务发送区DB块的内容
        /// </summary>
        /// <returns></returns>
        public void WriteTaskSend_YXY()
        {
            int[] vs = new int[DbIndexBySend.Length];
            using (EFModle.Entities et = new EFModle.Entities())
            {
                //取当前包装机未发送的的异型烟链板机（合包）任务
                List<EFModle.T_PACKAGE_TASK> values = et.T_PACKAGE_TASK.Where(x => x.STATE == 10 && x.PACKAGENO == GlobalPara.PackageNo).ToList();
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
                for (int i = 0; i < DbIndexBySend.Length; i++)
                {
                    ShapeGroup1.SyncWrite(vs[i], i);

                }
            }
        }
        //读取任务交互标志位
        public string ReadSendFlag()
        {
            return "";
        }

        /// <summary>
        /// plc数据发生改变时触发事件
        /// </summary>
        /// <param name="group">plc的DB块组</param>
        /// <param name="clientId">DB块集合</param>
        /// <param name="values">返回的值</param>
        public void OnDataChange(int group, int[] clientId, object[] values)
        {
            if (group == 1)
            {

            }
            if (group == 2)
            {

            }
        }
 
    }
}