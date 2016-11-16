<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Playlists.aspx.cs" Inherits="Playlists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">

    <br />
    <h1 id="pageHeader">Playlists</h1>
    <asp:GridView ID="gvPlaylist" CssClass="query" runat="server">
    </asp:GridView>
</asp:Content>

