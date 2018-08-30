using Eyue.Business.WxPay;
using System;
using System.Collections.Generic;
using System.Web;

namespace Eyue.Business.WxPay
{
    public class Refund
    {
        /***
        * 申请退款完整业务流程逻辑
        * @param transaction_id 微信订单号（优先使用）
        * @param out_trade_no 商户订单号
        * @param total_fee 订单总金额
        * @param refund_fee 退款金额
        * @return 退款结果（xml格式）
        */
        public void Run(string transaction_id, string refund_fee,string pvOpenID, string pvPath)
        {
            if (string.IsNullOrEmpty(transaction_id) || string.IsNullOrEmpty(refund_fee) || string.IsNullOrEmpty(pvOpenID))
                return;
            double lvRefund = 0;
            double.TryParse(refund_fee, out lvRefund);
            if (lvRefund <= 0) return;
            int lvRefundFee = (int)(lvRefund * 100);
            try
            {
                WxPayData data = new WxPayData();
                ////微信订单号存在的条件下，则已微信订单号为准
                //data.SetValue("transaction_id", transaction_id);
                //微信订单号不存在，才根据商户订单号去退款
                data.SetValue("out_trade_no", transaction_id);
                WxPayApi lvWxPayApi = new WxPayApi();

                data.SetValue("total_fee", lvRefundFee);//订单总金额
                data.SetValue("refund_fee", lvRefundFee);//退款金额
                data.SetValue("out_refund_no", lvWxPayApi.GenerateOutTradeNo());//随机生成商户退款单号
                data.SetValue("op_user_id", WxPayConfig.MCHID);//操作员，默认为商户号

                WxPayData result = lvWxPayApi.Refund(data,6, pvPath);//提交退款申请给API，接收返回数据
            }
            catch (Exception ex)
            {
               
            }
            return;
        }
    }
}