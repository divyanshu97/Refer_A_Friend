<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="tbxName" runat="server" ></asp:TextBox>
        <br />
        <asp:Label ID="lblPassword" runat="server" Text="PassWord"></asp:Label>

        <asp:TextBox ID="tbxPassword" runat="server" Type="password"></asp:TextBox>
        <br />
        <asp:Button ID="btnContinue" runat="server" OnClick="btnContinue_Click" Text="Login"/>
    </div>
    </form>
</body>
</html>
