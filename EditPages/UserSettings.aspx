<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserSettings.aspx.cs" Inherits="User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="Server">
    <script>
        function button_click(objTextBox, objBtnID) {
            if (window.event.keyCode == 13) {
                document.getElementById(objBtnID).focus();
                document.getElementById(objBtnID).click();
            }
        }
    </script>
    <br />
    <h1 id="pageHeader" runat="server">User settings</h1>
    ﻿﻿﻿<div id="changePass">
        <h3 id="userName" runat="server"></h3>
        <h3>Change password:</h3>

        <asp:Panel runat="server" DefaultButton="btnChangePassword">
            Old password:<br />
            <asp:TextBox ID="txtOldPassword" TextMode="Password" runat="server"/><br /><br />
            New password:
        <br />
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" /><br />
            Re-enter new password:<br />
            <asp:TextBox ID="txtRePassword" TextMode="Password" runat="server" /><br />
        </asp:Panel><br />
        <asp:Button ID="btnChangePassword" CssClass="buttons updateButton" Text="Change password" OnClick="btnChangePassword_Click"
             runat="server"></asp:Button><br />
    </div>
    <br />
    <asp:Label ID="lblMessages" runat="server" />
</asp:Content>

