using BLL.BLL;
using Common;
using Eyue.Business.WxPay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.WxPay
{
    public partial class Pay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string content = Request.QueryString["c"];
                if (string.IsNullOrEmpty(content))
                {
                    Response.Write("Ex-" + "页面传参出错,请返回重试11");
                    return;
                }
                try
                {
                    content = System.Web.HttpUtility.UrlDecode(content);

                    WXOrderInfo lvWXOrderInfo = JsonHelper.JsonDeserialize<WXOrderInfo>(content);

                    if (lvWXOrderInfo == null || string.IsNullOrEmpty(lvWXOrderInfo.OpenID) || string.IsNullOrEmpty(lvWXOrderInfo.PayMoney))
                    {
                        Response.Write("Ex-" + "页面传参出错,请返回重试22");
                        return;
                    }

                    //若传递了相关参数，则调统一下单接口，获得后续相关接口的入口参数
                    JsApiPay jsApiPay = new JsApiPay(this);

                    jsApiPay.openid = lvWXOrderInfo.OpenID;
                    jsApiPay.total_fee = (int)(double.Parse(lvWXOrderInfo.PayMoney) * 100);

                    content = "999";

                    //JSAPI支付预处理
                    WxPayData unifiedOrderResult = jsApiPay.GetUnifiedOrderResult(content, lvWXOrderInfo.Title);

                    string lvWxJsApiParam = jsApiPay.GetJsApiParameters();//获取H5调起JS API参数   

                    //在页面上显示订单信息
                    Response.Write(lvWxJsApiParam + "÷" + content);
                    return;
                }
                catch (Exception ex)
                {
                    Response.Write("Ex1-" + ex.Message);
                    return;
                }
            }
        }


    }
}