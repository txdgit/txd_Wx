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
            sb.AppendLine("支付宝发红包啦！人人可领，天天可领！");
            sb.AppendLine("复制此消息，打开支付宝领红包！RwqKgu99hK ");
            sb.AppendLine("😋😋😋  ");
            return sb.ToString();
        }

        public static string Free()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("敬请期待，我们真正准备！");
           
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
            sb.AppendLine("🎉🎉🎉🎉🎉😋😋😋");
            //sb.AppendLine("有精彩文章！还有免费的红包等你抢！！！");
            //sb.AppendLine("😋😋😋");
            return sb.ToString();
        }
    }
}
