using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Business.Weixin
{
    /// <summary>
    /// http 请求处理
    /// </summary>
    public class HttpHelper
    {
        /// <summary>
        /// http　GET请求
        /// </summary>
        /// <param name="url">url</param>
        /// <returns></returns>
        public static string Get(string url)
        {
            string outdata = "";
            try
            {
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
                CookieContainer cookieContainer = new CookieContainer();
                myHttpWebRequest.CookieContainer = cookieContainer;
                myHttpWebRequest.AllowAutoRedirect = true;
                myHttpWebRequest.Method = "GET";
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                Stream myResponseStream = myHttpWebResponse.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                outdata = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
            }
            catch 
            {
               
            }
            return outdata;
        }
        /// <summary>
        /// http　GET请求
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="indata">提交内容</param>
        /// <returns></returns>
        public static string Post(string url, string indata)
        {
            string outdata = "";
            try
            {
                byte[] date = Encoding.UTF8.GetBytes(indata);

                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
                CookieContainer cookieContainer = new CookieContainer();
                myHttpWebRequest.CookieContainer = cookieContainer;
                myHttpWebRequest.AllowAutoRedirect = true;
                myHttpWebRequest.Method = "POST";
                Stream myRequestStream = myHttpWebRequest.GetRequestStream();
                myRequestStream.Write(date, 0, date.Length);
                myRequestStream.Close();

                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                Stream myResponseStream = myHttpWebResponse.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                outdata = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
            }
            catch 
            {
               
            }
            return outdata;
        }

    }
}
