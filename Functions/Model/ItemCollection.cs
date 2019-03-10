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
        public static List<string> GetTaskStatusBySend()  //5个
        {
            List<string> list = new List<string>();
            list.Add("S7:[PackAgeConnection1]DB1,DINT0");//包号
            list.Add("S7:[PackAgeConnection1]DB1,W4");//数量
            list.Add("S7:[PackAgeConnection1]DB1,W6");//合单标志
            list.Add("S7:[PackAgeConnection1]DB1,W8");//推烟位置（层数）
            list.Add("S7:[PackAgeConnection1]DB1,W10");//交互标志


            return list;
        }

        /// <summary>
        /// 完成信号的DB块 10个
        /// </summary>
        /// <returns></returns>
        public static List<string> GetTaskStatusByComplete()  //10个
        {
            List<string> list = new List<string>();
            for (int i = 0; i < 40; i += 4)
            {
                list.Add("S7:[PackAgeConnection1]DB1,DINT" + i);
            }
            
            return list;
        }
    }
}
