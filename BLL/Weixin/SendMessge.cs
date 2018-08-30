using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Weixin
{
    public class SendMessge
    {
        public string Touser { get; set; }

        public string Template_id { get; set; }

        public string Title { get; set; }

        public string Keynote1 { get; set; }

        public string Keynote2 { get; set; }

        public string Keynote3 { get; set; }

        public string Keynote4 { get; set; }

        public string Remark { get; set; }

        /// <summary>
        /// 返回给微信文本消息
        /// </summary>
        public string Messge
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(" {");
                sb.Append("  \"touser\":\"" + Touser + "\",");
                sb.Append(" \"template_id\":\""+Template_id+"\",");
                sb.Append(" \"data\":{");
                sb.Append(" \"first\":{\"value\":\"" + Title + "\",\"color\":\"#FF0000\"},");
                if (!string.IsNullOrEmpty(Keynote1))
                    sb.Append(" \"keyword1\":{\"value\":\"" + Keynote1 + "\",\"color\":\"#173177\"},");
                if (!string.IsNullOrEmpty(Keynote2))
                    sb.Append(" \"keyword2\":{\"value\":\"" + Keynote2 + "\",\"color\":\"#173177\"},");
                if (!string.IsNullOrEmpty(Keynote3))
                    sb.Append(" \"keyword3\":{\"value\":\"" + Keynote3 + "\",\"color\":\"#FF0000\"},");
                if (!string.IsNullOrEmpty(Keynote4))
                    sb.Append(" \"keyword4\":{\"value\":\"" + Keynote4 + "\",\"color\":\"#173177\"},");
                sb.Append(" \"remark\":{\"value\":\""+Remark+"\"}");
                sb.Append(" }");
                sb.Append(" }");
                return sb.ToString();
            }
        }

    }
}
