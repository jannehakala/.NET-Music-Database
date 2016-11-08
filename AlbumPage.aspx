<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AlbumPage.aspx.cs" Inherits="AlbumPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
    <br /> <h1 id="pageheader"><asp:Label ID="lblAlbumName" runat="server"></asp:Label></h1>
    <asp:Image ID="albumImage" runat="server" />
    <asp:GridView ID="gvAlbumPage" CssClass="query" runat="server"></asp:GridView>
</asp:Content>

