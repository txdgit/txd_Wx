using BLL.BLL;
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
            string json = "{\"touser\":\"ozpkJ1MjHFm9f9W_HNCQ3tkRIIts\", \"msgtype\":\"image\",\"image\":{\"media_id\":\""+ this.TextBox1.Text + "\"}}";
            this.TextBox1.Text = HttpHelper.Post(url, json);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string a = @"C:\web\Upload\20180901\ozpkJ1MjHFm9f9W_HNCQ3tkRIIts.jpg";
           // this.TextBox1.Text = new InviteBll().UploadImg(a);
        }
    }
}