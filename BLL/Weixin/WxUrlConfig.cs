using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Weixin
{
    /// <summary>
    /// 微信接口URL配置
    /// </summary>
    public class WxUrlConfig
    {
        /// <summary>
        /// 获取微信开发的Access_Token　
        /// </summary>
        public static string Get_Access_Token_Url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + WxConfig.AppID + "&secret=" + WxConfig.AppSecret;
        /// <summary>
        /// 创建微信菜单URl 必须access_token赋值
        /// </summary>
        public static string Create_Menu_Url = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}";
        /// <summary>
        /// 删除微信菜单URl 必须access_token赋值
        /// </summary>
        public static string Delete_Menu_Url = "https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}";

        /// <summary>
        /// 获取页面OpenID，AccessToken　必须Code赋值　
        /// </summary>
        public static string Get_OpenIDAndAccessToken_Url = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + WxConfig.AppID + "&secret=" + WxConfig.AppSecret + "&code={0}&grant_type=authorization_code";

        /// <summary>
        /// 页面认证地址　　必须redirect_uri赋值
        /// </summary>
        public static string Get_Authorize_Url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + WxConfig.AppID + "&redirect_uri={0}&response_type=code&scope=snsapi_base&state=1#wechat_redirect";

        /// <summary>
        /// 得到JsapiTicket 必须access_token赋值
        /// </summary>
        public static string Get_JsapiTicket_Url = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi";

        /// <summary>
        /// 下载多媒体文件　必须access_token、media_id赋值
        /// </summary>
        public static string DownloadImage_Url = "http://file.api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}";
        /// <summary>
        /// 获取用户基本信息（包括UnionID机制）  必须access_token、openid赋值
        /// </summary>
        public static string Get_UserInfo_Url = "https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN";
        /// <summary>
        /// 发送模板消息    必须access_token赋值
        /// </summary>
        public static string Get_SendMessage_Url = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}";
    }
}
