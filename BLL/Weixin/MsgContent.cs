using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Weixin
{
    public class MsgContent
    {

        public static string HongBao()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("【支付宝红包】");
            sb.AppendLine("🎉🎉🎉🎉🎉🎉🎉🎉🎉");
            sb.AppendLine("最高可领99元！！还有机会额外获得专享红包哦！");
            sb.AppendLine("复制此消息，打开最新版支付宝就能领取！du6DSV99JX  ");
            sb.AppendLine("🌻🌻🌻明天继续领！😋😋😋  ");
            return sb.ToString();
        }
        /// <summary>
        /// 关注
        /// </summary>
        /// <returns></returns>
        public static string Subscribe()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("欢迎您加入【欢乐人生168】");
            sb.AppendLine("🎉🎉🎉🎉🎉🎉🎉🎉🎉");
            sb.AppendLine("有精彩文章！还有免费的红包等你抢！！！");
            sb.AppendLine("😋😋😋");
            return sb.ToString();
        }
    }
}
