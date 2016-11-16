<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Albums.aspx.cs" Inherits="Albums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
    <br /><h1 id="pageHeader">Albums</h1>
    <asp:GridView ID="gvAlbums" CssClass="query" runat="server" OnRowDataBound="gvAlbums_RowDataBound">

    </asp:GridView>
    <asp:Label ID="lblMessages" runat="server"></asp:Label>
</asp:Content>

