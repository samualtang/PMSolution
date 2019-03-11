using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Functions.Model
{
    public static class ItemCollection
    {
        /// <summary>
        /// 包装机异型烟链板机数据写入DB块 5个
        /// </summary>
        /// <returns></returns>
        public static List<string> GetTaskStatusBySend()  //8个
        {
            string S7Name = PubFunction.GlobalPara.Opc_Name;
            List<string> list = new List<string>();
            list.Add(S7Name + "DB1,DINT0");//包号  0
            list.Add(S7Name + "DB1,W4");//数量 1
            list.Add(S7Name + "DB1,W6");//合包标志 2
            list.Add(S7Name + "DB1,W8");//合包数量 3
            list.Add(S7Name + "DB1,W12");//推烟位置（层数） 4
            list.Add(S7Name + "DB1,DINT14");//预留  5
            list.Add(S7Name + "DB1,W18");//预留  6
            list.Add(S7Name + "DB1,W20");//交互标志  7
            return list;
        }

        /// <summary>
        /// 完成信号的DB块 10个
        /// </summary>
        /// <returns></returns>
        public static List<string> GetTaskStatusByComplete()  //10个
        {
            string S7Name = PubFunction.GlobalPara.Opc_Name;
            List<string> list = new List<string>();
            for (int i = 0; i < 40; i += 4)
            {
                list.Add(S7Name + "DB30,DINT" + i);
            }
            return list;
        }
    }
}
