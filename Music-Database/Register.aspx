<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Music Database | Register</title>
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
            <h2>Register</h2>
            Username:<br />
            <asp:Panel runat="server" DefaultButton="btnRegisterLoginForm">
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br />
                Password:<br />
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox><br />
                Re-enter password:<br />
                <asp:TextBox ID="txtRePassword" TextMode="Password" runat="server"></asp:TextBox><br />
            </asp:Panel>
            <br />
            <asp:Button ID='btnRegisterLoginForm' CssClass='buttons buttonsLoginRegister btnRegisterLoginForm' Text="Register" OnClick="btnRegisterLoginForm_Click" runat="server" /><br />
            <asp:Button ID='btnBackToLogin' CssClass='buttons buttonsLoginRegister btnBackToLogin' PostBackUrl="Login.aspx" Text="Back to Login" runat="server" /><br />
            <asp:Button ID='btnBackToMain' CssClass='buttons buttonsLoginRegister btnBackToMain' PostBackUrl="Home.aspx" Text="Back to Music database" runat="server" /><br />
            <asp:Label ID="lblMessage" Font-Size="20px" ForeColor="LightGreen" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
