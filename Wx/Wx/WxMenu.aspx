<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WxMenu.aspx.cs" Inherits="WebSite.Wx.WxMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBox1" runat="server" Height="78px" Width="570px"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="创　 建" OnClick="Button1_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="删　　除" OnClick="Button2_Click" />
        <br />
    
    </div>
    </form>
</body>
</html>
