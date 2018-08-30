using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Weixin
{
    /// <summary>
    /// 文本消息
    /// </summary>
    public class MessgeText
    {
        /// <summary>
        /// 接收对象
        /// </summary>
        public string ToUserName { get; set; }

        /// <summary>
        /// 发送对象
        /// </summary>
        public string FromUserName { get; set; }

        /// <summary>
        /// 消息创建时间 （整型） 
        /// </summary>
        public string CreateTime { get { return DateTime.Now.Ticks.ToString(); } }

        /// <summary>
        /// 消息类型
        /// </summary>
        public string MsgType { get { return "text"; } }

        /// <summary>
        /// 文本消息内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 返回给微信文本消息
        /// </summary>
        public string Messge
        {
            get
            {

                return string.Format(@"<xml>
                             <ToUserName><![CDATA[{0}]]></ToUserName>
                             <FromUserName><![CDATA[{1}]]></FromUserName>
                             <CreateTime>{2}</CreateTime>
                             <MsgType><![CDATA[text]]></MsgType>
                             <Content><![CDATA[{3}]]></Content>
                             </xml>", ToUserName, FromUserName, CreateTime, Content);
            }
        }



    }
}
