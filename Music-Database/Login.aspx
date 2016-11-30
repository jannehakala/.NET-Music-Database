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
        <div>
            <div id="errorMessageContainer" runat="server">
                <div id="errorMessage" runat="server"></div>
            </div>
            <div id="formContainerLoginRegister">
                <asp:Login ID="loginAuthenticate" runat="server" OnAuthenticate="login_Authenticate" TitleText="Music Database - Login">

                    <LayoutTemplate>

                        <div class="formLogin" runat="server">
                            <h1 style="">Music Database</h1>
                            <h2>Login</h2>
                            Username:<br />
                            <asp:Panel runat="server" DefaultButton="btnLogin">
                                <asp:TextBox ID="UserName" runat="server"></asp:TextBox><br />
                                Password:<br />
                                <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>

                            </asp:Panel>
                            <br />
                            <a href="Register.aspx" class="accountQ">Don't have an account? Register here.</a><br />
                            <asp:Button ID="btnLogin" runat="server" CommandName="Login" CssClass="buttons buttonsLoginRegister btnRegisterLoginForm" Text="Login" ValidationGroup="loginAuthenticate" /><br />
                            <asp:Button ID='btnBackToMain' CssClass='buttons buttonsLoginRegister btnBackToMain' PostBackUrl="Home.aspx" Text="Back to Music database" runat="server" /><br />
                            

                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ValidationGroup="loginAuthenticate"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ValidationGroup="loginAuthenticate"></asp:RequiredFieldValidator>
                        </div>
                    </LayoutTemplate>
                </asp:Login>
                <asp:LinkButton ID="btnLoginGuest" Text="View as a guest." runat="server" CausesValidation="False" OnClick="btnLoginGuest_Click">         
                </asp:LinkButton><br />
                <asp:Label ID="lblMessages" Font-Size="20px" ForeColor="LightGreen" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
