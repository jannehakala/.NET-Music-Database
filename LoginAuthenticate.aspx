<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginAuthenticate.aspx.cs" Inherits="LoginAuthenticate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login | Authenticate</title>
    <link href="~/CSS/style.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="formContainerLoginRegister">
            <asp:Login ID="loginAuthenticate" runat="server" OnAuthenticate="login1_Authenticate" TitleText="Music Database - Login">
            </asp:Login>
            <asp:LinkButton ID="btnLoginGuest" Text="Login as Guest." runat="server" CausesValidation="False" OnClick="btnLoginGuest_Click">         
            </asp:LinkButton>
        </div>
    </form>
</body>
</html>
