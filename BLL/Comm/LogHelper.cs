using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL.Comm
{
    /// <summary>
    /// 写日志
    /// </summary>
    public class LogHelper
    {
        /// <summary>
        /// 日志地址
        /// </summary>
        private static string LogPath = ConfigurationManager.AppSettings["LogPath"];

        /// <summary>
        /// 写文件锁
        /// </summary>
        private static object LockObj = new object();

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="content">日志内容</param>
        public static void Write(string content)
        {
            new LogHelper().WriteAsync(content);
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="content">日志内容</param>
        public async void WriteAsync(string content)
        {
            await Task.Run(() =>
            {
                lock (LockObj)
                {
                    FileMode fileMode = FileMode.OpenOrCreate;
                    string filePath = LogPath + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    if (File.Exists(filePath))
                        fileMode = FileMode.Append;
                    FileStream fs = new FileStream(filePath, fileMode);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "-->" + content);
                    sw.Dispose();
                    sw.Close();
                    fs.Dispose();
                    fs.Close();
                }
            });
        }

    }
}
