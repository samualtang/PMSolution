using System.Collections.Generic;

namespace Functions.Model
{
    public static class ItemCollection
    {
        /// <summary>
        /// 包装机异型烟链板机数据写入DB块 5个
        /// </summary>
        /// <returns></returns>
        public static List<string> GetTaskStatusBySend_yxy()  //8个
        {
            string S7Name = PubFunction.GlobalPara.Opc_Nameyxy;
            List<string> list = new List<string>();
            list.Add(S7Name + "DB3,DINT0");//包号  0
            list.Add(S7Name + "DB3,W4");//数量 1
            list.Add(S7Name + "DB3,W6");//合包标志 2
            list.Add(S7Name + "DB3,W8");//合包数量 3
            list.Add(S7Name + "DB3,W12");//推烟位置（层数） 4
            list.Add(S7Name + "DB3,DINT14");//预留  5
            list.Add(S7Name + "DB3,W18");//预留  6
            list.Add(S7Name + "DB3,W20");//交互标志  7
            return list;
        }
        public static List<string> GetSpyStateItem()
        {
            string S7Name1 = PubFunction.GlobalPara.Opc_Nameyxy;
            string S7Name2 = PubFunction.GlobalPara.Opc_Namecgy;
            List<string> list = new List<string>();
            list.Add(S7Name1 + "DB3,W20");//异型烟倍速链交互标志
            list.Add(S7Name2 + "DB1,W516");//常规烟翻版交互标志
            return list;
        }
        /// <summary>
        /// 包装机异型烟链板机完成信号的DB块 10个
        /// </summary>
        /// <returns></returns>
        public static List<string> GetTaskStatusByComplete_yxy()  //10个
        {
            string S7Name = PubFunction.GlobalPara.Opc_Nameyxy;
            List<string> list = new List<string>();
            for (int i = 0; i < 60; i += 4)
            {
                list.Add(S7Name + "DB30,DINT" +(40 + i));
            }
            return list;
        }
        /// <summary>
        /// 包装机常规烟翻板机数据写入DB块  --7个
        /// </summary>
        /// <returns></returns>
        public static List<string> GetTaskStatusBySend_cgy()
        {
            string S7Name = PubFunction.GlobalPara.Opc_Namecgy;
            List<string> list = new List<string>();
            list.Add(S7Name + "DB1,DINT500");//整包任务号0 
            list.Add(S7Name + "DB1,W504");//包内烟条数1
            list.Add(S7Name + "DB1,W506");//合包标志2
            list.Add(S7Name + "DB1,W508");//合包数量3
            list.Add(S7Name + "DB1,DINT510");//预留4
            list.Add(S7Name + "DB1,W514");//预留5
            list.Add(S7Name + "DB1,W516");//接收标志6

            return list;
        }
        /// <summary>
        /// 包装机常规烟翻板机完成信号的DB块  --10个
        /// </summary>
        /// <returns></returns>
        public static List<string> GetTaskStatusByComplete_cgy()
        {
            string S7Name = PubFunction.GlobalPara.Opc_Namecgy;//10个
            List<string> list = new List<string>();
            for (int i = 0; i < 40; i += 4)
            {
                list.Add(S7Name + "DB1,DINT" + (530 + i ));
            }
            return list;
        }

        /// <summary>
        /// 获取异形烟缓存工位信息
        /// </summary>
        /// <returns></returns>
        public static List<string> GetUnNormalWorkPlaceItem()
        {
            string S7Name = PubFunction.GlobalPara.Opc_Nameyxy;
            string S7Name1 = PubFunction.GlobalPara.Opc_Namecgy;//10个
            List<string> list = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                list.Add(S7Name + "DB8,DINT"+ (i *12));//包号
                //list.Add(S7Name + "DB8,INT" +( 4 + (i * 12)));//数量
                //list.Add(S7Name + "DB8,INT" + (6 + (i * 12)));//合单标志
                //list.Add(S7Name + "DB8,INT" + (8 + (i * 12)));//推烟位置
                //list.Add(S7Name + "DB8,INT" +( 10 + (i * 12)));//顺序标志
            }
           

            list.Add(S7Name1 + "DB1,DINT1260");//常规烟拨杆一  位置 8
            list.Add(S7Name1 + "DB1,DINT1260");//常规烟拨杆二  位置9
            list.Add(S7Name + "DB6,DINT0");//机器人 任务号w  位置 10
            return list;
        }

        public static List<string> ClearAndStop_cgy()
        {
            string S7Name = PubFunction.GlobalPara.Opc_Nameyxy;
            string S7Name1 = PubFunction.GlobalPara.Opc_Nameyxy;
            List<string> list = new List<string>();
            list.Add(S7Name + "DB30,W518");//常规烟翻版 清空任务 0
            list.Add(S7Name + "DB30,W520");//常规烟翻版 停止设备运行 1

            list.Add(S7Name1 + "DB7,DINT12");//异型烟倍速链 任务号 2
            list.Add(S7Name1 + "DB7,W16");//异型烟倍速链 清空 3
            list.Add(S7Name1 + "DB7,W18");//异型烟倍速链 急停 4
            return list;
        }

        public static List<string> ClearAndStop_yxy()
        {
            string S7Name = PubFunction.GlobalPara.Opc_Nameyxy;
            List<string> list = new List<string>();
            
            return list;
        }
        public static List<string> newFuc()
        {
            List<string> list = new List<string>();
            list.Add("DB3.DINT0");
            list.Add("DB3.W4");


            list.Add("DB3.W6");
            list.Add("DB3.W8");
            list.Add("DB3.W12");


            list.Add("DB3.DINT14");
            list.Add("DB3.W18");
            list.Add("DB3.W20");




            return list;
        }
        public static List<string> newFuc2()
        {
             
            List<string> list = new List<string>();
            list.Add("DB30.DINT0");


            list.Add("DB30.W4");
            list.Add("DB30.W6");
            list.Add("DB30.W8");


            list.Add("DB30.W10");
            return list;
        }
    }
}
