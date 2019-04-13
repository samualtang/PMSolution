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
        /// 更新合包任务状态  异型烟
        /// </summary>
        /// <param name="vs">包任务号</param>
        /// <returns></returns>
        public static bool UpdataTask_yxy(int vs   )
        {
            //数据库置完成该任务
            using (Entities et = new Entities())
            {
                List<T_PACKAGE_TASK> lists = et.T_PACKAGE_TASK.Where(x => x.PACKTASKNUM == vs).Select(x => x).ToList();
                if (lists.Count <= 0)
                {
                    return false;
                }
                foreach (var item in lists)
                {
                    if (item.STATE == 15)
                    {
                        item.STATE = 20;
                    }
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

        public static bool UpdataTask_yxy(int packageNUm,int state)
        {
            using (Entities en = new Entities())
            {
                List<T_PACKAGE_TASK> lists = en.T_PACKAGE_TASK.Where(x => x.PACKTASKNUM == packageNUm).Select(x => x).ToList();
                if (!lists.Any())
                {
                    return false;
                }
                foreach (var item in lists)
                {
                    if (item.STATE == 10)//等于新增，才更新成接收状态
                    {
                        item.STATE = state;
                    }
                }
                if (en.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static bool UpdataTask_cgy(int packageNUm, int state)
        {
            using (Entities en = new Entities())
            {
                List<T_PACKAGE_TASK> lists = en.T_PACKAGE_TASK.Where(x => x.PACKTASKNUM == packageNUm).Select(x => x).ToList();
                if (!lists.Any())
                {
                    return false;
                }
                foreach (var item in lists)
                {
                    if (item.NORMAILSTATE == 10)//等于新增，才更新成接收状态
                    {
                        item.NORMAILSTATE = state;
                    }
                }
                if (en.SaveChanges() > 0)
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
        /// 更新合包任务状态  常规烟
        /// </summary>
        /// <param name="vs">包任务号</param>
        /// <returns></returns>
        public static bool UpdataTask_cgy(int vs)
        {
            //数据库置完成该任务
            using (Entities et = new Entities())
            {
                List<T_PACKAGE_TASK> lists = et.T_PACKAGE_TASK.Where(x => x.PACKTASKNUM == vs).Select(x => x).ToList();
                if (lists.Count <= 0)
                {
                    return false;
                }
                foreach (var item in lists)
                {
                    if (item.NORMAILSTATE == 15)
                    {
                        item.NORMAILSTATE = 20;
                    }
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
        /// 获取数据库内未发送的任务 异型烟
        /// </summary>
        /// <param name="PackageNo">包装机号</param>
        /// <returns></returns>
        public static List< T_PACKAGE_TASK> GetAllNotSendTask_YXY(int PackageNo)
        {            
            using (Entities et = new Entities())
            {
                return et.T_PACKAGE_TASK.Where(x => x.STATE == 10 && x.PACKAGENO == PackageNo).ToList();
            }
        }
        /// <summary>
        /// 获取数据库内未发送的任务 异型烟
        /// </summary>
        /// <param name="PackageNo">包装机号</param>
        /// <returns></returns>
        public static List<T_PACKAGE_TASK> GetAllNotSendTask_CGY(int PackageNo)
        {
            using (Entities et = new Entities())
            {
                return et.T_PACKAGE_TASK.Where(x => x.NORMAILSTATE == 10 && x.PACKAGENO == PackageNo).OrderBy(x => x.PACKTASKNUM).ToList();
            }
        }
        /// <summary>
        /// 根据接收信号的任务，数据库置接收  异型烟
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
                    if (item.STATE == 10)
                    {
                        item.STATE = 15;
                    }
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
        /// 根据接收信号的任务，数据库置接收  常规烟
        /// </summary>
        /// <param name="Packtasknum"></param>
        /// <returns></returns>
        public static bool WriteReceive_CGY(int Packtasknum)
        {
            using (Entities et = new Entities())
            {
                List<T_PACKAGE_TASK> lists = et.T_PACKAGE_TASK.Where(x => x.PACKTASKNUM == Packtasknum).Select(x => x).ToList();
                foreach (var item in lists)
                {
                    if (item.NORMAILSTATE == 10)
                    {
                        item.NORMAILSTATE = 15;
                    }
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
