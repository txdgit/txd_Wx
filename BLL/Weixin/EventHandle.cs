using BLL.Weixin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Business.Weixin
{
    /// <summary>
    /// 事件处理
    /// </summary>
    public class EventHandle
    {
        public EventHandle()
        {
           
        }

        /// <summary>
        /// 事件处理
        /// </summary>
        /// <param name="xmldoc"></param>
        /// <returns></returns>
        public string Handle(XmlDocument xmldoc)
        {
            string res = string.Empty;
            string strEvent = xmldoc.SelectSingleNode("/xml/Event").InnerText;
            switch (strEvent)
            {
                case "CLICK":
                    res = ClickHandle(xmldoc);
                    break;
                case "subscribe"://关注
                    res = Subscribe(xmldoc);
                    break;
                case "unsubscribe"://取消关注
                    UnSubscribe(xmldoc);
                    break;
                default:
                    break;
            }
            return res;
        }

        /// <summary>
        /// 关注
        /// </summary>
        private string Subscribe(XmlDocument xmldoc)
        {
            MessgeText messgeText = new MessgeText();
            messgeText.ToUserName = xmldoc.SelectSingleNode("/xml/FromUserName").InnerText;
            messgeText.FromUserName = xmldoc.SelectSingleNode("/xml/ToUserName").InnerText;
            string lvParenOpenID = xmldoc.SelectSingleNode("/xml/EventKey").InnerText;
            if (!string.IsNullOrEmpty(lvParenOpenID))
                lvParenOpenID = lvParenOpenID.Split('_')[1];
            else
                lvParenOpenID = "";
            messgeText.Content = MsgContent.Subscribe();
            return messgeText.Messge;
        }
        /// <summary>
        /// 取消关注
        /// </summary>
        private void UnSubscribe(XmlDocument xmldoc)
        {
            string openID = xmldoc.SelectSingleNode("/xml/FromUserName").InnerText;
            new BLL.BLL.UserInfoBll().Delete(openID);
        }

        /// <summary>
        /// 菜单点击事件
        /// </summary>
        /// <param name="xmldoc"></param>
        /// <returns></returns>
        private string ClickHandle(XmlDocument xmldoc)
        {
            MessgeText messgeText = new MessgeText();
            messgeText.ToUserName = xmldoc.SelectSingleNode("/xml/FromUserName").InnerText;
            messgeText.FromUserName = xmldoc.SelectSingleNode("/xml/ToUserName").InnerText;
            string strEventKey = xmldoc.SelectSingleNode("/xml/EventKey").InnerText;
            switch (strEventKey)
            {
                case "HongBao":
                    messgeText.Content = MsgContent.HongBao();
                    break;
                case "Free":
                    messgeText.Content = MsgContent.Free();
                    break;
                default:
                    messgeText.Content = "我只能默认了……。"+ strEventKey;
                    break;
            }

            return messgeText.Messge;
        }

        
    }
}
