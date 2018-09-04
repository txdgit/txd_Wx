<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Wx.WxPay.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>购买资料</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
    <script src="/Js/jquery-2.1.4.js?4" type="text/javascript"></script>
    <script src="/Js/WxPay.js?4"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="OpenID" Value="" runat="server" />
    </form>
</body>
</html>
<script type="text/javascript"> 
    $(document).ready(function () {
        onSumbit111();
    });

    function onSumbit111()
    {
        PayData($("#OpenID").val(), 1.99, "购买资料");
        PayTest();

        return false;
    }
   
</script>