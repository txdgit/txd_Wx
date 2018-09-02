using Business.Weixin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wx.Wx
{
    public partial class Kf : System.Web.UI.Page
    {
        private WxHelper _WxHelper = new WxHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _WxHelper.LoadWx();
                this.TextBox1.Text = WxConfig.Access_Token;
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=" + WxConfig.Access_Token;
            string json = "{\"touser\":\"ozpkJ1MjHFm9f9W_HNCQ3tkRIIts\", \"msgtype\":\"text\",\"text\":{\"content\":\"abc   <a href='http://www.qq.com' >点击跳</a>\"}}";
            this.TextBox1.Text = HttpHelper.Post(url, json);
        }
    }
}