function PayTest() {
    if (typeof WeixinJSBridge == "undefined") {
        if (document.addEventListener) {
            document.addEventListener('WeixinJSBridgeReady', PayFun, false);
        }
        else if (document.attachEvent) {
            document.attachEvent('WeixinJSBridgeReady', PayFun);
            document.attachEvent('onWeixinJSBridgeReady', PayFun);
        }
    }
    else {
        PayFun();
    }
}

function PayFun() {
    if (mvPayData == null) {
        alert("数据封装有误!");
        return;
    }
    $.ajax({
        async: false,
        url: "/WxPay/Pay.aspx?c=" + encodeURI(mvPayData) + "&a=" + Math.random(),
        success: function (result) {
            //alert("result:" + result);
            try {
                var Data = result.split("÷");
                var JosnObj = eval("[" + Data[0] + "]");
                PaySumbit(JosnObj[0]);
            } catch (e) {
                alert("支付异常！！");
            }
        }
    });
}

function PaySumbit(JosnObj) {
    WeixinJSBridge.invoke('getBrandWCPayRequest', {
        "appId": JosnObj.appId,
        "timeStamp": JosnObj.timeStamp,
        "nonceStr": JosnObj.nonceStr,
        "package": JosnObj.package,
        "signType": JosnObj.signType,
        "paySign": JosnObj.paySign
    },
                        function (res) {
                            if (res.err_msg.indexOf('ok') >= 0) {
                                alert("打赏成功，我们会更加努力！");
                                WeixinJSBridge.call('closeWindow');
                                return;
                            }
                            if (res.err_msg.indexOf('cancel') >= 0) {
                                alert("支付已取消");
                                return;
                            }
                            if (res.err_msg.indexOf('fail') >= 0) {
                                alert("支付失败，请联系客服！");
                                return;
                            }
                            //alert(res.err_code + res.err_desc + res.err_msg);
                            return;
                        });
}



var mvPayData = null;

function PayData(OpenID, BuyNumber, Title) {
    var t = "{";
    t += "'OpenID':'" + OpenID + "',";
    t += "'ProductNo':'6666',";
    t += "'PayMoney':'" + BuyNumber + "',";
    t += "'Title':'" + Title + "'";
    t += "}";
    mvPayData = t;
    return t;
}
