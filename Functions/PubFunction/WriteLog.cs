﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Functions
{
    public class WriteLog
    {
        private int fileSize;
        private string fileLogPath;
        private string logFileName;
        public static WriteLog log;
        public static WriteLog GetLog()
        {
            if (log == null)
                log = new WriteLog();
            return log;
        }
        private WriteLog()
        {
            //初始化大于399M日志文件将自动删除;

            this.fileSize = 2048 * 1024 * 200;//50M   2048 * 1024 * 200= 419430000字节(b)=399.9996185兆字节(mb)

            //默认路径

            this.fileLogPath = Application.StartupPath + "\\log\\";
            this.logFileName = "log" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
        }

        public int FileSize
        {
            set
            {
                fileSize = value;
            }
            get
            {
                return fileSize;
            }
        }

        public string FileLogPath
        {
            set
            {
                this.fileLogPath = value;
            }
            get
            {
                return this.fileLogPath;
            }
        }

        public string LogFileName
        {
            set
            {
                this.logFileName = value;
            }
            get
            {
                return this.logFileName;
            }
        }

        object flag = new object();

        public void Write(string Message)
        {
            lock (flag)
            {
                this.Write(this.logFileName, Message);
            }
        }

        public void Write(string LogFileName, string Message)
        {

            //DirectoryInfo path=new DirectoryInfo(LogFileName);
            //如果日志文件目录不存在,则创建
            if (!Directory.Exists(this.fileLogPath))
            {
                Directory.CreateDirectory(this.fileLogPath);
            }

            FileInfo finfo = new FileInfo(this.fileLogPath + LogFileName);
            if (finfo.Exists && finfo.Length > fileSize)
            {
                finfo.Delete();
            }
            try
            {
                FileStream fs = new FileStream(this.fileLogPath + LogFileName, FileMode.Append);
                StreamWriter strwriter = new StreamWriter(fs);
                try
                {

                    DateTime d = DateTime.Now;
                    strwriter.WriteLine("时间:" + d.ToString());
                    strwriter.WriteLine(Message);
                    strwriter.WriteLine();
                    strwriter.Flush();
                }
                catch (Exception ee)
                {
                    Console.WriteLine("日志文件写入失败信息:" + ee.ToString());
                }
                finally
                {
                    strwriter.Close();
                    strwriter = null;
                    fs.Close();
                    fs = null;
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine("日志文件没有打开,详细信息如下:"+ee.Message);
            }
        }
         
    }
}
