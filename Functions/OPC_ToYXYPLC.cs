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
    public class OPC_ToYXYPLC
    {
        public const string SERVER_NAME = "OPC.SimaticNET";       // local server name //OPC服务器名称
        public const string GROUP_NAME = "grp1";                  // Group name //组名
        public const int LOCALE_ID = 0x409;                       // LOCALE FOR ENGLISH. 
        public IOPCServer pIOPCServer;                     //定义opcServer对象.opc服务器接口指针
        public Group ShapeGroup1, ShapeGroup2;
        public Type svrComponenttyp;                       //服务器类型
        public Guid iidRequiredInterface = typeof(IOPCItemMgt).GUID;

        /// <summary>
        /// 创建opc连接
        /// </summary>
        public void ConnectionToPLCYXY()
        {
            svrComponenttyp = Type.GetTypeFromProgID(SERVER_NAME);
            pIOPCServer = (IOPCServer)Activator.CreateInstance(svrComponenttyp);            //创建服务器连接对象

            ShapeGroup1 = new Group(pIOPCServer, 1, "group1", 1, LOCALE_ID);           //创建组
            ShapeGroup1.addItem(ItemCollection.GetTaskStatusBySend());           //添加项到组  包装机异型烟链板机数据写入DB块
            ShapeGroup2 = new Group(pIOPCServer, 1, "group2", 1, LOCALE_ID);           //创建组
            ShapeGroup2.addItem(ItemCollection.GetTaskStatusByComplete());           //添加项到组  完成信号的DB块
             
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
        public bool CheckConnection()
        {
            int flag = ShapeGroup1.ReadD(Convert.ToInt32(DbIndexBySend[0])).CastTo<int>(-1);
            if (flag == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //读取任务发送区DB块的内容
        public string ReadTaskSend()
        {
            return "";
        }

        /// <summary>
        /// 开启程序时 读取所有任务完成区DB块的内容 并置数据库完成返回置完成的任务号数组
        /// </summary>
        /// <returns></returns>
        public int[] ReadAndWriteTaskConpelte()
        {
            int[] result = new int[10];
            for (int i = 0; i < DbIndexByConpelte.Count(); i++)
            {
                //读取完成标志
                result[i] = ShapeGroup2.ReadD(Convert.ToInt32(DbIndexByConpelte[i])).CastTo<int>(-1);
                if (result[i] > 0)
                {
                    //数据库置完成
                    //----------------------------------------------------------------------
                    //更新完成标志
                    ShapeGroup2.Write(0, i);
                }
            }
            return result;
        }


        //写入任务发送区DB块的内容
        public string WriteTaskSend()
        { 
            return "";
        }
        //读取任务交互标志位
        public string ReadSendFlag()
        {
            return "";
        }
        public void OnSendDataChange(int group, int[] clientId, object[] values)
        {
            if (group == 4)
            {

            }
        }
 
    }
}