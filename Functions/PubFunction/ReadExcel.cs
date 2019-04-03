using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions.PubFunction
{
   public class ReadExcel
    {
        /// <summary>
        /// 读取Excel数据
        /// </summary>
        /// <param name="Path">文件路径</param>
        /// <param name="cellName">工作表名称</param>
        /// <returns></returns>
        public static DataSet LoadDataExcel(string Path,string cellName)
        {
            string strConn = "Provider=Microsoft.Ace.OleDb.12.0;data source=" + Path + ";Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();

            string strExcel = "select * from ["+cellName+"$]";
            OleDbDataAdapter myDa = new OleDbDataAdapter(strExcel, conn);

            DataSet myDs = new DataSet();
            myDa.Fill(myDs);
            myDa.Dispose();
            conn.Close();
            return myDs;
        }
    }
}
