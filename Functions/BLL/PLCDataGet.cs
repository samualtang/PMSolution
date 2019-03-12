using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFModle; 

namespace Functions.BLL
{
    public static class PLCDataGet
    {
        /// <summary>
        /// 更新合包任务状态
        /// </summary>
        /// <param name="vs">包任务号</param>
        /// <returns></returns>
        public static bool UpdataTask(int vs)
        {
            //数据库置完成该任务
            using (Entities et = new Entities())
            {
                List<T_PACKAGE_TASK> lists = et.T_PACKAGE_TASK.Where(x => x.PACKTASKNUM == vs).Select(x => x).ToList();
                foreach (var item in lists)
                {
                    item.STATE = 20;
                }
                if (et.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 获取数据库内未发送的任务
        /// </summary>
        /// <param name="PackageNo">包装机号</param>
        /// <returns></returns>
        public static List< T_PACKAGE_TASK> GetAllNotSendTask(int PackageNo)
        {            
            using (Entities et = new Entities())
            {
                return et.T_PACKAGE_TASK.Where(x => x.STATE == 10 && x.PACKAGENO == PackageNo).ToList();
            }
        }
        /// <summary>
        /// 根据接收信号的任务，数据库置接收
        /// </summary>
        /// <param name="Packtasknum"></param>
        /// <returns></returns>
        public static bool WriteReceive_YXY(int Packtasknum)
        {
            using (Entities et = new Entities())
            {
                List<T_PACKAGE_TASK> lists = et.T_PACKAGE_TASK.Where(x => x.PACKTASKNUM == Packtasknum).Select(x => x).ToList();
                foreach (var item in lists)
                {
                    item.STATE = 15;
                }
                if (et.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
