using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Weixin
{
    /// <summary>
    /// 微信服务号配置
    /// </summary>
    public class WxConfig
    {
        /// <summary>
        /// 公众号的唯一标识
        /// 公众号：wxa7f14cfe60dd3da6
        /// 订约号：wx65cdb9ccd6c8150f
        /// </summary>
        public readonly static string AppID = "wxa7f14cfe60dd3da6";

        /// <summary>
        /// 验证接口的密钥
        /// </summary>
        public readonly static string Token = "adong1618";
        /// <summary>
        /// 微信开发密钥
        /// 公众号：a8adcbb9b85aa0166113a7b3c10086dc
        /// 订约号：83683102b34afba5aa31e90d7d7b408e
        /// </summary>
        public readonly static string AppSecret = "a8adcbb9b85aa0166113a7b3c10086dc";
        /// <summary>
        ///
        /// </summary>
        public readonly static string SendTemplate = "ClnSjFrPJBhsoP6o9Y_IW2iTr9iQQD09YzFRuzibAeQ";
        
        /// <summary>
        /// 接口开发的Session值　保存两个小时
        /// </summary>
        public static string Access_Token { get; set; }

        /// <summary>
        /// 最后一次获取Session的时间，可以判断Session是否有效
        /// </summary>
        public static DateTime Access_Token_LastDate { get; set; }
    }
}
