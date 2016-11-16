<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GenrePage.aspx.cs" Inherits="GenrePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
    <br /><h1 id="pageHeader"><asp:Label ID="lblGenreName" runat="server"></asp:Label></h1>
    <asp:GridView ID="gvGenrePage" CssClass="query" OnRowDataBound="gvGenrePage_RowDataBound" runat="server"></asp:GridView>
    <asp:Label ID="lblMessages" runat="server"></asp:Label>
</asp:Content>

