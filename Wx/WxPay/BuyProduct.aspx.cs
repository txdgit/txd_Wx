using Business.Weixin;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.Wx
{
    public partial class BuyProduct : System.Web.UI.Page
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