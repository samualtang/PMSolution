using HslCommunication;
using HslCommunication.ModBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Functions.BLL
{
   public class Modbus:WriteLog
    {
        private ModbusTcpNet busTcpClient = null;
        private string adds = "192.168.100.1";
        private int port = 502;
 
        public bool Connection()
        {
            busTcpClient?.ConnectClose();
            busTcpClient = new ModbusTcpNet(adds, port, 1);
            busTcpClient.AddressStartWithZero = false;
            OperateResult connect = busTcpClient.ConnectServer();
            if(connect.IsSuccess)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        List<string> listAdds = new List<string>();
        public void DisConnection()
        {
            if( busTcpClient!= null)
            {

                busTcpClient.ConnectClose();
            }
        }
        public  async void ReadAsync()
        {
          
            while (true)
            {
                await Task.Run( ()=> WriteInfo());
                System.Threading.Thread.Sleep(500);
            }
        }
        int[] info = new int[2];
 
         
        int newValue = 0;
        int oldValue = 0;
 
        public void WriteInfo()
        {
            var arr = Read(); 
            if (arr[0]  != newValue)
            {
                MWrite("机器人新值："+arr[0]); 
            } 
            if (arr[1] != oldValue)
            {
                MWrite("机器人上一个值：" + arr[1]); 
            }
        }

        public int[] Read()
        {
           
           
            OperateResult<int> a = busTcpClient.ReadInt32("12299");//1 2
            OperateResult<int> b = busTcpClient.ReadInt32("12301");//0 1
            
            info[0] = a.Content; 
            info[1] = b.Content; 
            return info;
             
        }
        public  void MWrite(  string Message)
        {
            base.Write("机器人记录"+ DateTime.Now.ToString("yyyyMMdd") + ".txt", Message);
        }
    }
}
