using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecialShapeSmoke.Model
{
    public static class ItemCollection
    { 


        public static List<string> GetTaskStatusByShapeItem()//包装机 异型烟推烟数据
        {
            List<string> list = new List<string>();
            list.Add("S7:[PackAgeConnection]DB1,DINT0");//包号
            list.Add("S7:[PackAgeConnection]DB1,W4");//数量
            list.Add("S7:[PackAgeConnection]DB1,W6");//合单标志
            list.Add("S7:[PackAgeConnection]DB1,W8");//推烟位置（层数）
            list.Add("S7:[PackAgeConnection]DB1,W10");//交互标志


            return list;
        }

      
    }
}
