using Business.Weixin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL
{
    public  class ActivityBLL
    {
        public string FirstMsg()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("赠送《懒人健身法 每周两小时 在家就能练出好身材 刘洹健身教程》<a href='http://www.qq.com'>点击这里</a>查看详情。");
            sb.AppendLine("【免费方法】将下面的邀请卡转发到微信群或朋友圈，2个小伙伴扫码关注后，会自动弹出资料链接。");
            sb.AppendLine("【土豪通道】不方便转发的同学可以<a href='http://www.qq.com'>点击这里付费</a>即可直接查看资料。");
            return sb.ToString();
        }

        public void SendText(string OpenID,string content)
        {
            new WxHelper().LoadWx();
            string url = string.Format(WxUrlConfig.Msg_Send_Url, WxConfig.Access_Token);
            string json = "{\"touser\":\"+OpenID+\", \"msgtype\":\"text\",\"text\":{\"content\":\""+ content + "\"}}";
            HttpHelper.Post(url, json);
        }

        public void SendImg(string OpenID, string media_id)
        {
            new WxHelper().LoadWx();
            string url = string.Format(WxUrlConfig.Msg_Send_Url, WxConfig.Access_Token);
            string json = "{\"touser\":\"+OpenID+\", \"msgtype\":\"image\",\"image\":{\"media_id\":\"" + media_id + "\"}}";
            HttpHelper.Post(url, json);
        }
    }
}
