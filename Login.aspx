<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Music Database | Login</title>
    <link href="~/CSS/style.css" rel="Stylesheet" type="text/css" />
    <link rel="shortcut icon" href="http://www.iconeasy.com/icon/png/System/Frenzic%20System/Music.png" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="errorMessageContainer" runat="server">
            <div id="errorMessage" runat="server"></div>
        </div>

        <div id="formContainerLoginRegister">
            <h1>Music Database</h1>
            <h2>Login</h2>
            Username:<br />
            <asp:Panel runat="server" DefaultButton="btnRegisterLoginForm">
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br />
                Password:<br />
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox><br />
            </asp:Panel>
            <br />
            <a href="Register.aspx" class="accountQ">Don't have an account? Register here.</a><br />
            <a href="LoginAuthenticate.aspx" class="accountQ">Login with authentication.</a><br />
            <asp:Button ID='btnRegisterLoginForm' OnClick="btnLogin_Click" Text='Login' CssClass="buttons" runat="server" /><br />
            <asp:Button ID='btnBackToMain' CssClass='buttons' PostBackUrl="Home.aspx" Text="Back to Music database" runat="server"></asp:Button><br />
            <asp:Label ID="lblMessage" Font-Size="20px" ForeColor="LightGreen" runat="server"></asp:Label>
        </div>

    </form>
</body>
</html>
