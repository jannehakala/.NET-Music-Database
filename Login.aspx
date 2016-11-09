<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Music Database | Login</title>
    <link href="~/CSS/style.css" rel="Stylesheet" type="text/css" />

    <script>
        function button_click(objTextBox, objBtnID) {
            if (window.event.keyCode == 13) {
                document.getElementById(objBtnID).focus();
                document.getElementById(objBtnID).click();
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="errorMessageContainer">
            <div id="errorMessage" runat="server"></div>
        </div>
        <div id="formContainerLoginRegister">
            <h1>Login</h1>
            <h3>Music Database</h3>
            Username:<br />
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br />
            Password:<br />
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox><br />
            <br />
            <a href="Register.aspx" id="accountQ">Don't have an account? Register here.</a><br />
            <asp:Button ID='btnRegisterLoginForm' OnClick="btnLogin_Click" Text='Login' CssClass="buttons" runat="server" /><br />
            <asp:Button ID='btnBackToMain' CssClass='buttons' PostBackUrl="Home.aspx" Text="Back to Music database" runat="server"></asp:Button>
        </div>
    </form>
</body>
</html>
