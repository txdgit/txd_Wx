using BLL.Comm;
using Eyue.Business.WxPay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wx.WxPay
{
    public partial class PayNotify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LogHelper.Write("支付中：---------");
            ResultNotify resultNotify = new ResultNotify(this);
            resultNotify.ProcessNotify();
        }
    }
}