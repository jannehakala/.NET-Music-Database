<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Genres.aspx.cs" Inherits="Genres" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
    <br /><h1 id="pageHeader">Genres</h1>
    <asp:GridView ID="gvGenres" CssClass="query" OnRowDataBound="gvGenres_RowDataBound" runat="server">
    </asp:GridView>
    <asp:Label ID="lblMessages" runat="server"></asp:Label>
</asp:Content>

