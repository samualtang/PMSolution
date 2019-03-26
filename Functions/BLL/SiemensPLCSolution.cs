using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HslCommunication;
using HslCommunication.Profinet.Siemens;
 


namespace Functions.BLL
{
    public class SiemensPLCSolution:IDisposable
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="siemensServer">传入西门子服务器</param>
        /// <param name="vs">地址</param>
        public SiemensPLCSolution(SiemensS7Net siemensServer, List<string> vs)
        {
           
            Vs = vs; 
            
            SiemensTcpNet = siemensServer;
            OperateResult connect = SiemensTcpNet.ConnectServer();
            if (!connect.IsSuccess)
            {
                throw new Exception("初始化失败！"+ connect.Message);
            }
             
        }
        private SiemensS7Net SiemensTcpNet = null;
        private SiemensPLCS siemensPLCSelected = SiemensPLCS.S1200;
         
 
        /// <summary>
        /// String 格式：DB地址+类型+加上位置,地址和类型之间用.隔开 如： DB30.Dint0   
        /// </summary>
        public List<string> Vs { get; }
        public string Adds { get; }
        public byte Slot { get; }
        public byte Rack { get; }

     
        
        /// <summary>
        /// 返回地址集合的长度
        /// </summary>
        /// <returns></returns>
        public int ListCount
        {
            get
            {
                if (Vs.Any())
                {
                    return Vs.Count;

                }
                else
                {
                    return -1;
                }
            }
        } 
        public bool ConnClose()
        {
            if (SiemensTcpNet != null)
            {
                OperateResult connect = SiemensTcpNet.ConnectClose();
                if (connect.IsSuccess)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    
        /// <param name="vs"></param> 
        /// <summary>
        /// 读取指定块的值
        /// </summary>
        public object Read(int index)
        {
            try
            {

         
            object result;
            var item = Vs[index];
            var arr = item.Trim().Split('.');
            if (arr.Length > 1)
            {
                string types = Regex.Replace(arr[1], "[0-9]", "", RegexOptions.IgnoreCase).Trim();//获取地址块的类型
                switch (types.ToLower())
                {
                    case "bool":
                        result = SiemensTcpNet.ReadBool(GetNewItem(item)).Content;
                            break;
                    case "byte":
                        result = SiemensTcpNet.ReadByte(GetNewItem(item)).Content;
                            break;
                    case "short":
                        result = SiemensTcpNet.ReadInt16(GetNewItem(item)).Content;
                            break;
                    case "w"://ushort
                        result = SiemensTcpNet.ReadUInt16(GetNewItem(item)).Content;
                        break;
                    case "dint":     
                          result = SiemensTcpNet.ReadInt32(GetNewItem(item)).Content;
                         break;
                    case "uint":
                        result = SiemensTcpNet.ReadUInt32(GetNewItem(item)).Content;
                        break;
                    case "long":
                        result = SiemensTcpNet.ReadInt64(GetNewItem(item)).Content;
                            break;
                    case "ulong":
                        result = SiemensTcpNet.ReadUInt64(GetNewItem(item)).Content;
                            break;
                    case "real":
                        result = SiemensTcpNet.ReadFloat(GetNewItem(item)).Content;
                            break;
                    case "double":
                        result = SiemensTcpNet.ReadDouble(GetNewItem(item)).Content;
                            break;
                    case "string":
                        result = SiemensTcpNet.ReadString(GetNewItem(item),10).Content;
                            break;
                    default:
                        result = -1;
                        break;
                }
                return result;
            }

            return  -1;
            } 
            catch (Exception)
            {

                return -1;
            }
        }
        /// <summary>
        /// 写入DB块
        /// </summary>
        /// <param name="values">地址 如 DB.30</param>
        /// <param name="index">地址的位置</param>
        public void Write(object values, int index)
        {
            try
            {
                var item = Vs[index];
                var arr = item.Trim().Split('.');
                if (arr.Length > 1)
                {
                    string types = Regex.Replace(arr[1], "[0-9]", "", RegexOptions.IgnoreCase).Trim();//获取地址块的类型

                    switch (types.ToLower())
                    {
                        case "bool":
                            SiemensTcpNet.Write(GetNewItem(item), Convert.ToBoolean(values));
                            break;
                        case "byte":
                            SiemensTcpNet.Write(GetNewItem(item), Convert.ToByte(values));
                            break;
                        case "short":
                            SiemensTcpNet.Write(GetNewItem(item), short.Parse(values.ToString()));
                            break;
                        case "w"://ushort
                            SiemensTcpNet.Write(GetNewItem(item), ushort.Parse(values.ToString()));
                            break;
                        case "dint":
                            SiemensTcpNet.Write(GetNewItem(item), Convert.ToInt32(values));
                            break;
                        case "uint":
                            SiemensTcpNet.Write(GetNewItem(item), uint.Parse(values.ToString()));
                            break;
                        case "long":
                            SiemensTcpNet.Write(GetNewItem(item), long.Parse(values.ToString()));
                            break;
                        case "ulong":
                            SiemensTcpNet.Write(GetNewItem(item), ulong.Parse(values.ToString()));
                            break;
                        case "real":
                            SiemensTcpNet.Write(GetNewItem(item), float.Parse(values.ToString()));
                            break;
                        case "double":
                            SiemensTcpNet.Write(GetNewItem(item), double.Parse(values.ToString()));
                            break;
                        case "string":
                            SiemensTcpNet.Write(GetNewItem(item), values.ToString());
                            break;

                    }

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         /// <summary>
         /// 
         /// </summary>
         /// <param name="values">对应整块DB块的值</param>
         /// <param name="index"></param>
        public void Write(object[] values, int index)
        {
            try
            {
                if (values.Length == Vs.Count)
                {
                    for (int i = 0; i < ListCount; i++)
                    {
                        var item = Vs[i];
                        var arr = item.Trim().Split('.');
                        if (arr.Length > 1)
                        {
                            string types = Regex.Replace(arr[1], "[0-9]", "", RegexOptions.IgnoreCase).Trim();//获取地址块的类型
                            checked {
                            switch (types.ToLower())
                            {
                                case "bool":
                                    SiemensTcpNet.Write(GetNewItem(item), Convert.ToBoolean(values[i]));
                                    break;
                                case "byte":
                                    SiemensTcpNet.Write(GetNewItem(item), Convert.ToByte(values[i]));
                                    break;
                                case "short":
                                    SiemensTcpNet.Write(GetNewItem(item), short.Parse(values[i].ToString()));
                                    break;
                                case "w"://ushort
                                    SiemensTcpNet.Write(GetNewItem(item), ushort.Parse(values[i].ToString()));
                                    break;
                                case "dint":
                                    SiemensTcpNet.Write(GetNewItem(item), Convert.ToInt32(values[i]));
                                    break;
                                case "uint":
                                    SiemensTcpNet.Write(GetNewItem(item), uint.Parse(values[i].ToString()));
                                    break;
                                case "long":
                                    SiemensTcpNet.Write(GetNewItem(item), long.Parse(values[i].ToString()));
                                    break;
                                case "ulong":
                                    SiemensTcpNet.Write(GetNewItem(item), ulong.Parse(values[i].ToString()));
                                    break;
                                case "real":
                                    SiemensTcpNet.Write(GetNewItem(item), float.Parse(values[i].ToString()));
                                    break;
                                case "double":
                                    SiemensTcpNet.Write(GetNewItem(item), double.Parse(values[i].ToString()));
                                    break;
                                case "string":
                                    SiemensTcpNet.Write(GetNewItem(item), values[i].ToString());
                                    break;

                            }
                            }
                        }
                    } 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        string GetNewItem(string oldString)
        {
            string newStr = "";
            var a = oldString.Trim().Split('.');
            if (a.Length > 1)
            {
                newStr = Regex.Replace(a[1], "[a-z]", "", RegexOptions.IgnoreCase).Trim();
            }
            newStr = a[0] + "." + newStr;
            return newStr;
        }

        public void Dispose()
        {
            ConnClose();
        }
    }

 
   
}
