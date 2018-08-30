using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Weixin
{
    /// <summary>
    /// js sdk 配置
    /// </summary>
    public class JSWxConfig
    {
        /// <summary>
        /// JS接口的临时票据
        /// </summary>
        public static string Jsapi_Ticket { get; set; }
        /// <summary>
        /// 票据 存放时间
        /// </summary>
        public static DateTime Ticket_Last_Date { get; set; }


    }
}
