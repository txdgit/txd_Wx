using BLL.BLL;
using BLL.Weixin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Business.Weixin
{
    /// <summary>
    /// 消息处理
    /// </summary>
    public class MessgeHandle
    {
        /// <summary>
        /// 消息处理
        /// </summary>
        /// <param name="xmldoc"></param>
        /// <returns></returns>
        public string Handle(XmlDocument xmldoc)
        {
            MessgeText messgeText = new MessgeText();
            messgeText.ToUserName = xmldoc.SelectSingleNode("/xml/FromUserName").InnerText;
            messgeText.FromUserName = xmldoc.SelectSingleNode("/xml/ToUserName").InnerText;
            messgeText.Content = "您们的信息已收到，我们会及时回复😋";
            new UserInfoBll().Update(messgeText.ToUserName);
            return messgeText.Messge;
        }

    
    }
}
