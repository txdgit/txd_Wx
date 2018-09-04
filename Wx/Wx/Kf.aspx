<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kf.aspx.cs" Inherits="Wx.Wx.Kf" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBox1" runat="server" Height="131px" Width="266px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="增加" />
&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="上传" OnClick="Button1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonMsg" runat="server" Text="消息" />
    
    </div>
    </form>
</body>
</html>
