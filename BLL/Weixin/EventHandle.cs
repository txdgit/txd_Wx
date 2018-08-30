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
                case "Query":
                    messgeText.Content = Query(messgeText.ToUserName);
                    break;
                case "Code":
                    messgeText.Content = GetDynamicCode(messgeText.ToUserName);
                    break;
                case "Contact":
                    messgeText.Content = Contact();
                    break;
                default:
                    messgeText.Content = "我只能默认了……。"+ strEventKey;
                    break;
            }

            return messgeText.Messge;
        }


        private string GetDynamicCode(string openID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("动态码：");
            sb.Append(" \r\n  请保密并确认本人操作！");
            return sb.ToString();
        }

        private string Sign(string openid)
        {
            try
            {
               
                return "签到成功，获得" + 0 + "分！\t\n \t\n 请明天继续哦！";
            }
            catch (Exception ex)
            {
                return "系统正在维护，请稍候再来！";
            }

        }

        private string Query(string openid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("尊敬的用户您好：　\t\n \t\n");
           
            return sb.ToString();
        }

      

        private string Contact()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("联系客服 \t\n");
            sb.Append("    QQ1：537012601 \t\n");
            sb.Append("    QQ2：537012600 \t\n");
            return sb.ToString();
        }
    }
}
