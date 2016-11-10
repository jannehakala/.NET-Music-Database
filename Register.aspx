<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Music Database | Register</title>
    <link href="~/CSS/style.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="errorMessageContainer" runat="server">
            <div id="errorMessage" runat="server"></div>
        </div>
        <div id="formContainerLoginRegister">
            <h1>Register</h1>
            <h3>Music Database</h3>
            Username:<br />
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br />
            Password:<br />
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox><br />
            Re-enter password:<br />
            <asp:TextBox ID="txtRePassword" TextMode="Password" runat="server"></asp:TextBox><br />
            <br />
            <asp:Button ID='btnRegisterLoginForm' CssClass='buttons' Text="Register" OnClick="btnRegisterLoginForm_Click" runat="server" /><br />
            <asp:Button ID='btnBackToLogin' CssClass='buttons' PostBackUrl="Login.aspx" Text="Back to Login" runat="server"/><br />
            <asp:Button ID='btnBackToMain' CssClass='buttons' PostBackUrl="Home.aspx" Text="Back to Music database" runat="server"/><br />
            <asp:Label ID="lblMessage" Font-Size="20px" ForeColor="LightGreen" runat="server"></asp:Label>
        </div>    
    </form>
</body>
</html>
