<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HandleValidationError.aspx.cs" Inherits="HandleValidationError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
    <asp:Label ID="lblMessage" ForeColor="Red" Text="You have entered some dangerous characters!" runat="server" Font-Size="20"></asp:Label><br /><br />
    <asp:Label ID="lblRedirect" Text="You will be redirected to home." runat="server"></asp:Label>
</asp:Content>

