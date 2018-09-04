using BLL.Comm;
using Business.Weixin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace Eyue.Business.WxPay
{
    /// <summary>
    /// 支付结果通知回调处理类
    /// 负责接收微信支付后台发送的支付结果并对订单有效性进行验证，将验证结果反馈给微信支付后台
    /// </summary>
    public class ResultNotify : Notify
    {
      

        public ResultNotify(Page page) : base(page)
        {
         
        }

        public override void ProcessNotify()
        {
            LogHelper.Write("支付中：0000000");
            WxPayData notifyData = GetNotifyData(WxPayConfig.KEY);
            if (!notifyData.IsSet("transaction_id"))
            {
                Result(false, "支付结果中微信订单号不存在");
                return;
            }
            System.Threading.Thread lvThread = new System.Threading.Thread(OrderRun);
            lvThread.IsBackground = true;
            lvThread.Start(notifyData);

            Result(true, "OK");
            return;
        }

        private void OrderRun(object pvOjb)
        {
            WxPayData notifyData = pvOjb as WxPayData;

            //返回状态码  SUCCESS/FAIL  SUCCESS表示商户接收通知成功并校验成功
            string return_code = notifyData.GetValue("return_code").ToString();
            if (!return_code.ToLower().Equals("success"))
                return;

            //订单金额 金额必须除以100
            //string total_fee = notifyData.GetValue("total_fee").ToString();
            //openid
            string openid = notifyData.GetValue("openid").ToString();
            //我们配置的Josn数据
            //string attach = notifyData.GetValue("attach").ToString();

            //double lvWxTotal = double.Parse(total_fee)/100;

            //string transaction_id = notifyData.GetValue("transaction_id").ToString();//微信支付订单号

            try
            {
                LogHelper.Write("支付成功："+openid);
                new BLL.BLL.ActivityBLL().BuyGoods(openid);
            }
            catch (Exception ex)
            {
                LogHelper.Write("支付异常：" + ex.Message);
            }
           
        }

        private void Result(bool pvIsSuccess,string pvMsg)
        {
            LogHelper.Write("支付中：11111111111");
            WxPayData res = new WxPayData();
            res.SetValue("return_code", pvIsSuccess?"SUCCESS": "FAIL");
            res.SetValue("return_msg", pvMsg);
            page.Response.Write(res.ToXml());
            page.Response.End();
        }
    }
}
