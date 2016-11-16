<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AlbumPage.aspx.cs" Inherits="AlbumPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
    <h1 id="albumTitle"><asp:Label ID="lblAlbumName" runat="server"></asp:Label></h1>
    <asp:Image ID="albumImage" CssClass="albumImage" runat="server" /><br />
    from artist <asp:Hyperlink  id="artistLink" CssClass="artistLinkCss" runat="server" ></asp:Hyperlink>
    <asp:Label ID="lblAlbumInfo" runat="server"></asp:Label><br /><br />
    <asp:GridView ID="gvAlbumPage" CssClass="query" OnRowDataBound="gvAlbumPage_RowDataBound" runat="server"></asp:GridView>
    <div class="video">
        <asp:Label ID="lblTrackName" runat="server" Font-Size="16"></asp:Label><br />
        <iframe id="youtubeVideo" allowfullscreen="allowfullscreen" width="700" height="400" src="" runat="server"></iframe>
    </div>
    <asp:Label ID="lblMessages" runat="server"></asp:Label>
</asp:Content>

