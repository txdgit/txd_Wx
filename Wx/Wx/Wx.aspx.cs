using Business.Weixin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wx.Wx
{
    public partial class Wx : System.Web.UI.Page
    {
        private string url = "http://zy168.shop/Wx/Error.aspx";

        private string ProductUrl = "http://zy168.shop/WxPay/BuyProduct.aspx";

        private string GoUrl = "http://zy168.shop/WxPay/Index.aspx";

        private string type = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            type = Request["type"];
            switch (type)
            {
              
                case "1":
                    url = ProductUrl;
                    break;
                case "2":
                    url = GoUrl;
                    break;
            }

            url = string.Format(WxUrlConfig.Get_Authorize_Url, url);
            Response.Redirect(url);
        }
    }
}