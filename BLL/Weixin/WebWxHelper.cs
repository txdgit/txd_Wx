using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.UI;

namespace Business.Weixin
{
    /// <summary>
    /// 页面微信处理类
    /// </summary>
    public class WebWxHelper
    {
        /// <summary>
        /// openid用于调用统一下单接口
        /// </summary>
        public string OpenID { get; set; }
        /// <summary>
        /// access_token用于获取用户信息，js函数入口参数
        /// </summary>
        public string Access_Token { get; set; }

        /// <summary>
        /// 只有在用户将公众号绑定到微信开放平台帐号后
        /// </summary>
        public string Unionid { get; set; }

        /// <summary>
        /// Code 是通过接口获取OpenID和Access_Token　的凭据
        /// </summary>
        private string Code { get; set; }

        /// <summary>
        /// 根据CODE查询用户　OpenID和Access_Token
        /// </summary>
        /// <param name="page"></param>
        public WebWxHelper(Page page)
        {
            GetOpenidAndAccessToken(page);
        }
        /// <summary>
        /// 根据CODE查询用户　OpenID和Access_Token
        /// </summary>
        /// <param name="page"></param>
        private void GetOpenidAndAccessToken(Page page)
        {
            Code = page.Request.QueryString["code"];
            string strRes = HttpHelper.Get(string.Format(WxUrlConfig.Get_OpenIDAndAccessToken_Url, Code));
            JObject jObject = (JObject)JsonConvert.DeserializeObject(strRes);

            Access_Token = jObject["access_token"].ToString();
            OpenID = jObject["openid"].ToString();
            if (jObject["unionid "] != null)
            {
                Unionid = jObject["unionid "].ToString();
            }
        }
    }
}
