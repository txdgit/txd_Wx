using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

namespace Business.Weixin
{
    /// <summary>
    /// 微信事件和消息处理
    /// </summary>
    public class WxHandle
    {

        private MessgeHandle _MessgeHandle = new MessgeHandle();

        private EventHandle _EventHandle = new EventHandle();

        /// <summary>
        /// 微信返回事件和消息
        /// </summary>
        /// <param name="strPost">微信返回的Post数据</param>
        public void Handle(HttpContext httpContent, string strPost)
        {
            string responseContent = string.Empty;

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(strPost);
            XmlNode xmlNodeMsgType = xmldoc.SelectSingleNode("/xml/MsgType");
            if (xmlNodeMsgType != null)
            {
                string strMsgType = xmlNodeMsgType.InnerText;
                if (strMsgType == "event")
                {
                    responseContent = _EventHandle.Handle(xmldoc);
                }
                else  //消息暂时不需要
                {
                    responseContent = _MessgeHandle.Handle(xmldoc);
                }
            }
            httpContent.Response.ContentEncoding = Encoding.UTF8;
            httpContent.Response.Write(responseContent);
            httpContent.Response.End();
        }
    }
}
