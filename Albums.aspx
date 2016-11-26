<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Albums.aspx.cs" Inherits="Albums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="Server">
    <br />
    <h1 id="pageHeader" class="pageName">Albums</h1>

    <asp:Button ID="btnEdit" CssClass="buttons updateButton" PostBackUrl="~/EditAlbums.aspx" Text="Edit" runat="server" />
    <asp:GridView ID="gvAlbums" CssClass="query" runat="server" OnRowDataBound="gvAlbums_RowDataBound">
    </asp:GridView>
    <asp:Label ID="lblMessages" runat="server"></asp:Label>
</asp:Content>

