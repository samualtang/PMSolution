using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Functions.PubFunction
{
    public class CommunicationWithPLC_test
    {
        SerialPort sp_PLC = new SerialPort();
        /// <summary>
        /// 串口通信的方式发送数据到plc
        /// </summary>
        /// <param name="CommandStr">命令字符串</param>
        /// <param name="SpPlc">串口对象</param>
        /// <returns></returns>
        public byte[] SendPLC(string CommandStr, SerialPort SpPlc)
        {
            byte[] return_bytes = new byte[25];
            byte[] confirm_bytes;
            byte[] confirm_send_bytes = { 0x10, 0x02, 0x00, 0x5C, 0x5E, 0x16 };
            List<byte> commandlist = ByteToHexStrClass.HexStringToByteArray(CommandStr).ToList();

            
            //计算和校验
            int sum = 0;
            for (int i = 4; i < commandlist.Count; i++)
            {
                sum = sum + commandlist[i];
            }

            sum = sum % 256;

            commandlist.Add(BitConverter.GetBytes(sum)[0]);
            commandlist.Add(0x16);

            byte[] command = commandlist.ToArray();
            sp_PLC.DiscardInBuffer();
            sp_PLC.DiscardOutBuffer();
            sp_PLC.Write(command, 0, command.Count());
            System.Threading.Thread.Sleep(100);

            confirm_bytes = new byte[sp_PLC.BytesToRead];
            sp_PLC.Read(confirm_bytes, 0, confirm_bytes.Length);

            if (confirm_bytes.Length == 1 && confirm_bytes[0] == 0xE5)
            {
                sp_PLC.Write(confirm_send_bytes, 0, 6);
                System.Threading.Thread.Sleep(200);

                return_bytes = new byte[sp_PLC.BytesToRead];
                sp_PLC.Read(return_bytes, 0, return_bytes.Length);
            }

            return return_bytes;

        }

 
        
    }

} 