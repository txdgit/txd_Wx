<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuyProduct.aspx.cs" Inherits="WebSite.Wx.BuyProduct" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>打赏中心</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <script src="/Js/jquery-2.1.4.js?4" type="text/javascript"></script>
    <script src="/Js/WxPay.js?4"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="OpenID" Value="" runat="server" />
        <br /><br /><br />
        打赏金额：<input type="number" id="numberID" value="1" /><br /><br /><br />
        <button type="button" onclick="return onSumbit111();">确认支付</button>
    </form>
</body>
</html>
<script type="text/javascript">
    function onSumbit111()
    {
        PayData($("#OpenID").val(), $("#numberID").val(), "打赏金额");
        PayTest();

        return false;
    }
   
</script>
