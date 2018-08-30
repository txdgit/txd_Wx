using Business.Weixin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Wx.Wx
{
    /// <summary>
    /// Index 的摘要说明
    /// </summary>
    public class Index : IHttpHandler
    {
        private WxHandle _WxHandle = new WxHandle();

        private WxHelper _WxHelper = new WxHelper();

        public void ProcessRequest(HttpContext context)
        {
            string signature = HttpContext.Current.Request.QueryString["signature"];
            string timestamp = HttpContext.Current.Request.QueryString["timestamp"];
            string nonce = HttpContext.Current.Request.QueryString["nonce"];

            // 验证是否为微信接入数据   也做首次的配置使用 
            if (_WxHelper.DeveloperAuthentication(timestamp, nonce, signature))
            {
                string postString = string.Empty;
                if (HttpContext.Current.Request.HttpMethod.ToUpper() == "POST")
                {
                    //这里做微信接入进来的数据处理
                    using (Stream stream = HttpContext.Current.Request.InputStream)
                    {
                        Byte[] postBytes = new Byte[stream.Length];
                        stream.Read(postBytes, 0, (Int32)stream.Length);
                        postString = Encoding.UTF8.GetString(postBytes);
                        _WxHandle.Handle(HttpContext.Current, postString);
                    }
                }
                else
                {
                    string strReBack = HttpContext.Current.Request.QueryString["echostr"];
                    HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
                    HttpContext.Current.Response.Write(strReBack);
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}