using Business.Weixin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wx.WxPay
{
    public partial class Index : System.Web.UI.Page
    {
        private WebWxHelper _WebWxHelper = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    _WebWxHelper = new WebWxHelper(this.Page);
                    this.OpenID.Value = _WebWxHelper.OpenID;
                }
                catch (Exception ex)
                {
                    Response.Write("ex=" + ex.Message);
                }
            }
        }
    }
}