using Business.Weixin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.Wx
{
    public partial class WxMenu : System.Web.UI.Page
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.TextBox1.Text != "adong1618")
            {
                this.TextBox1.Text = "密码错误";
                return;
            }
            StreamReader sr = new StreamReader(Server.MapPath("/XmlConfig/WxMenu.txt"), Encoding.UTF8);
            string res = sr.ReadToEnd();
            sr.Dispose();
            sr.Close();

            this.TextBox1.Text = HttpHelper.Post(string.Format(WxUrlConfig.Create_Menu_Url, WxConfig.Access_Token), res);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (this.TextBox1.Text != "adong1618")
            {
                this.TextBox1.Text = "密码错误";
                return;
            }
           this.TextBox1.Text= HttpHelper.Get(string.Format(WxUrlConfig.Delete_Menu_Url, WxConfig.Access_Token));
        }
    }
}