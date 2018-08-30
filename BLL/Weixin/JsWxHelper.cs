using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace Business.Weixin
{
    /// <summary>
    /// JS 微信处理类
    /// </summary>
    public class JSWxHelper
    {
        private WxHelper _WxHelper = new WxHelper();

        public JSWxHelper(Page page)
        {
            _WxHelper.LoadWx();
            GetJsapiTicket();
            AppId = WxConfig.AppID;
            Timestamp = _WxHelper.GenerateTimeStamp();
            NonceStr = _WxHelper.GenerateNonceStr();

            Signature = GetSignature(page);
        }

        public JSWxHelper()
        { 
            
        }

        /// <summary>
        /// 得到签名
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        private string GetSignature(Page page)
        {
            string url = page.Request.Url.ToString();
            
            string rawstring = "jsapi_ticket=" + JSWxConfig.Jsapi_Ticket + "&noncestr=" + NonceStr + "&timestamp=" + Timestamp + "&url=" + url + "";

            return _WxHelper.SHA1Check(rawstring).ToLower();
        }

        /// <summary>
        /// 必填，公众号的唯一标识
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 必填，生成签名的时间戳
        /// </summary>
        public string Timestamp { get; set; }
        /// <summary>
        /// 必填，生成签名的随机串
        /// </summary>
        public string NonceStr { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string Signature { get; set; }

      

        /// <summary>
        /// 得到临时票据
        /// </summary>
        private void GetJsapiTicket()
        {
            if (string.IsNullOrEmpty(JSWxConfig.Jsapi_Ticket) || (DateTime.Now - JSWxConfig.Ticket_Last_Date).TotalMinutes > 100)
            {
                string strRes = HttpHelper.Get(string.Format(WxUrlConfig.Get_JsapiTicket_Url, WxConfig.Access_Token));
                JObject jObject = (JObject)JsonConvert.DeserializeObject(strRes);
                JSWxConfig.Jsapi_Ticket = jObject["ticket"].ToString();
                JSWxConfig.Ticket_Last_Date = DateTime.Now;
            }

        }
    }
}
