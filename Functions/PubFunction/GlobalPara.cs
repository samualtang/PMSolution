using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Functions.PubFunction
{
    public static class GlobalPara
    {
        static string file = System.Windows.Forms.Application.ExecutablePath;
        static System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(file);
        /// <summary>
        /// 条烟间隙 默认2
        /// </summary>
        public static int CigGap
        {
            get
            {
                if (config != null)
                {
                    try
                    {
                        int result = Convert.ToInt32(config.AppSettings.Settings["CigGap"].Value.ToString());
                        if (result > 0)
                        {
                            return result;
                        }
                        else
                        {
                            return 2;
                        }
                    }
                    catch (Exception)
                    {

                        return 2;
                    }

                }
                else
                {
                    return 2;
                }
            }
            set
            {
                if (config != null)
                {
                    config.AppSettings.Settings["CigGap"].Value = value.ToString();
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
            }
        }
        /// <summary>
        /// 工位高
        /// </summary>
        public static int BoxHeight {
            get
            {
                if (config != null)
                {
                    try
                    {
                        int result = Convert.ToInt32(config.AppSettings.Settings["BoxHeight"].Value.ToString());
                        if (result > 0)
                        {
                            return result;
                        }
                        else
                        {
                            return 2;
                        }
                    }
                    catch (Exception)
                    {

                        return 2;
                    }

                }
                else
                {
                    return 2;
                }
            }
            set
            {
                if (config != null)
                {
                    config.AppSettings.Settings["BoxHeight"].Value = value.ToString();
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
            }
        }
        /// <summary>
        /// 工位宽
        /// </summary>
        public static int BoxWidth { get
            {
                if (config != null)
                {
                    try
                    {
                        int result = Convert.ToInt32(config.AppSettings.Settings["BoxWidth"].Value.ToString());
                        if (result > 0)
                        {
                            return result;
                        }
                        else
                        {
                            return 2;
                        }
                    }
                    catch (Exception)
                    {

                        return 2;
                    }

                }
                else
                {
                    return 2;
                }
            }
            set
            {
                if (config != null)
                {
                    config.AppSettings.Settings["BoxWidth"].Value = value.ToString();
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
            }
        }
        /// <summary>
        /// 工位长
        /// </summary>
        public static int BoxLenght { get
            {
                if (config != null)
                {
                    try
                    {
                        int result = Convert.ToInt32(config.AppSettings.Settings["BoxLenght"].Value.ToString());
                        if (result > 0)
                        {
                            return result;
                        }
                        else
                        {
                            return 2;
                        }
                    }
                    catch (Exception)
                    {

                        return 2;
                    }

                }
                else
                {
                    return 2;
                }
            }
            set
            {
                if (config != null)
                {
                    config.AppSettings.Settings["BoxLenght"].Value = value.ToString();
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
            }
        }
        /// <summary>
        /// 包装机
        /// </summary>
        public static int PackageNo { get
            {
                if (config != null)
                {
                    try
                    {
                        int result = Convert.ToInt32(config.AppSettings.Settings["PackageNo"].Value.ToString());
                        if (result > 0 && result <= 8)
                        {
                            return result;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                    catch (Exception)
                    {

                        return 1;
                    }

                }
                else
                {
                    return 1;
                }
            }
            set
            {
                if (config != null)//存入包装机号
                {
                    config.AppSettings.Settings["PackageNo"].Value = value.ToString();
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
            }
        }
        /// <summary>
        /// 最大顺序号
        /// </summary>
        public static decimal SortNum
        {
            get
            {
                if (config != null)
                {
                    try
                    {
                        decimal result = Convert.ToDecimal(config.AppSettings.Settings["SortNum"].Value.ToString());
                        if (result > 0)
                        {
                            return result;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                    catch (Exception)
                    {

                        return 1;
                    }

                }
                else
                {
                    return 1;
                }
            }
            set
            {
                if (config != null)//存入最大顺序号
                {
                    config.AppSettings.Settings["SortNum"].Value = value.ToString();
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
            }
        }

        /// <summary>
        /// 机器人PLC_Ip地址
        /// </summary>
        public static string RobitPlc_Ip
        {
            get
            {
                if (config != null)
                {
                    try
                    {
                        string result = config.AppSettings.Settings["RotitIp"].Value.ToString();
                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            return result;
                        }
                        else
                        {
                            return "错误的IP地址";
                        }
                    }
                    catch (Exception)
                    {

                        return "错误的IP地址";
                    }

                }
                else
                {
                    return "错误的IP地址";
                }

            }
            set
            {
                if (config != null)
                {
                    config.AppSettings.Settings["RotitIp"].Value = value.ToString();
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
            }
        }
        /// <summary>
        /// 机器人PLC端口
        /// </summary>
        public static string RobitPlc_Port { get
            {
                if (config != null)
                {
                    try
                    {
                        string result = config.AppSettings.Settings["RotitPort"].Value.ToString();
                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            return result;
                        }
                        else
                        {
                            return "错误的端口";
                        }
                    }
                    catch (Exception)
                    {

                        return "错误的端口";
                    }

                }
                else
                {
                    return "错误的端口";
                }

            }
            set
            {
                if (config != null)
                {
                    config.AppSettings.Settings["RotitPort"].Value = value.ToString();
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
            }
        }
        public  static int GlbobaIndex { get; set; }    
        /// <summary>
        /// opc服务别名 异型烟
        /// </summary>
        public static string Opc_Nameyxy
        {
            get
            {
                if (config != null)
                {
                    try
                    {
                        string result = config.AppSettings.Settings["OpcName_yxy"].Value.ToString();
                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            return result;
                        }
                        else
                        {
                            return "错误的opc服务名称";
                        }
                    }
                    catch (Exception)
                    {

                        return "错误的opc服务名称";
                    }

                }
                else
                {
                    return "错误的opc服务名称";
                }

            }
            set
            {
                if (config != null)
                {
                    config.AppSettings.Settings["OpcName_yxy"].Value = value.ToString();
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
            }
        }
        /// <summary>
        /// opc服务别名 异型烟
        /// </summary>
        public static string Opc_Namecgy
        {
            get
            {
                if (config != null)
                {
                    try
                    {
                        string result = config.AppSettings.Settings["OpcName_cgy"].Value.ToString();
                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            return result;
                        }
                        else
                        {
                            return "错误的opc服务名称";
                        }
                    }
                    catch (Exception)
                    {

                        return "错误的opc服务名称";
                    }

                }
                else
                {
                    return "错误的opc服务名称";
                }

            }
            set
            {
                if (config != null)
                {
                    config.AppSettings.Settings["OpcName_cgy"].Value = value.ToString();
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
            }
        }
        static int BackHash;
        public static bool JugValueEqualsLastOne(string info)
        {
            try
            {
                int newHash = info.GetHashCode();
                if(BackHash != newHash)
                {
                    BackHash = newHash;
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }

} 


