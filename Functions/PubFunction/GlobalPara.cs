using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
        static int BackHash2;
        /// <summary>
        /// 和上次做对比 相同返回 真 反之 假
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
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
        public static bool JugValueEqualsLastOne2(string info)
        {
            try
            {
                int newHash = info.GetHashCode();
                if (BackHash2 != newHash)
                {
                    BackHash2 = newHash;
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
        private static string key = "abcd1234";
        #region DES加密
        public static string EncryptString(string pToEncrypt)
        {

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);





            des.Key = UTF8Encoding.UTF8.GetBytes(key);

            des.IV = UTF8Encoding.UTF8.GetBytes(key);

            MemoryStream ms = new MemoryStream();

            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);



            cs.Write(inputByteArray, 0, inputByteArray.Length);

            cs.FlushFinalBlock();



            StringBuilder ret = new StringBuilder();

            foreach (byte b in ms.ToArray())
            {

                ret.AppendFormat("{0:X2}", b);

            }

            ret.ToString();

            return ret.ToString();

        }

#endregion



        #region DES解密

        public static string DecryptString(string pToDecrypt)
        {

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();



            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];

            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {

                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));

                inputByteArray[x] = (byte)i;

            }



            des.Key = UTF8Encoding.UTF8.GetBytes(key);

            des.IV = UTF8Encoding.UTF8.GetBytes(key);

            MemoryStream ms = new MemoryStream();

            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);

            cs.FlushFinalBlock();



            StringBuilder ret = new StringBuilder();



            return Encoding.UTF8.GetString(ms.ToArray());

        }

        #endregion
    }

} 


