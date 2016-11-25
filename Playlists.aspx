<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" enableEventValidation="false" AutoEventWireup="true" CodeFile="Playlists.aspx.cs" Inherits="Playlists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">

    <br />
    <h1 id="pageHeader">Playlists</h1>
    <asp:DropDownList ID="ddlPlaylistNames" OnSelectedIndexChanged="ddlPlaylistNames_SelectedIndexChanged" AutoPostBack="true" CssClass="comboPlaylists" runat="server"></asp:DropDownList>
    
    <asp:Button id="btnAddPlaylist" style="margin-left:20px;" Text="Add a new playlist" OnClick="btnAddPlaylist_Click" 
        CssClass="buttons addButton" runat="server"> 
    </asp:Button>
    
    <asp:Button id="btnDeletePlaylist" style="margin-left:5px;" Text="Delete a playlist" OnClick="btnDeletePlaylist_Click" OnClientClick="return confirm('Are you sure you want to delete this playlist?');" 
        CssClass="buttons deleteButton buttonDeletePlaylist" runat="server"> 
    </asp:Button><br /><br />
    
    
    <asp:GridView ID="gvPlaylist" CssClass="query" OnSelectedIndexChanged="gvPlaylist_SelectedIndexChanged" OnRowDataBound="gvPlaylist_RowDataBound" runat="server">
        <Columns>
            <asp:ButtonField CommandName="Select" HeaderText="Remove" Text="X" />
        </Columns>
    </asp:GridView>
    <div class="video">
        <asp:Label ID="lblMessages" runat="server"></asp:Label><br /><br />
        <asp:Label ID="lblTrackName" runat="server" Font-Size="16"></asp:Label><br />
        <iframe id="youtubeVideo" allowfullscreen="allowfullscreen" width="700" height="400" src="" runat="server"></iframe>
    </div>
    
</asp:Content>

