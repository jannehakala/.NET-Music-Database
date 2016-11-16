<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" enableEventValidation="false" AutoEventWireup="true" CodeFile="Playlists.aspx.cs" Inherits="Playlists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">

    <br />
    <h1 id="pageHeader">Playlists</h1>
    <asp:DropDownList ID="ddlPlaylistNames" OnSelectedIndexChanged="ddlPlaylistNames_SelectedIndexChanged" AutoPostBack="true" CssClass="comboPlaylists" runat="server"></asp:DropDownList>
    <button id="btnDeletePlaylist" type="submit" onserverclick="btnDeletePlaylist_Click" 
        class="buttons deleteButton buttonDeletePlaylist" runat="server">
        <i class="fa fa-trash" aria-hidden="true" style="font-size: 20px;color: white"></i>
    </button><br /><br />
    
    <asp:GridView ID="gvPlaylist" CssClass="query" OnRowDataBound="gvPlaylist_RowDataBound" runat="server">
    </asp:GridView>
    <div class="video">
        <asp:Label ID="lblTrackName" runat="server" Font-Size="16"></asp:Label><br />
        <iframe id="youtubeVideo" allowfullscreen="allowfullscreen" width="700" height="400" src="" runat="server"></iframe>
    </div>
    <asp:Label ID="lblMessages" runat="server"></asp:Label>
</asp:Content>

