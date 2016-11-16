<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Tracks.aspx.cs" Inherits="Tracks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="Server">
    <br />
    <h1 id="pageHeader">Tracks</h1>
    <asp:GridView ID="gvTracks" AutoGenerateSelectButton="false" CssClass="query" OnRowDataBound="gvTracks_RowDataBound" OnSelectedIndexChanged="gvTracks_SelectedIndexChanged" runat="server">
        <Columns>
            <asp:ButtonField CommandName="Select" HeaderText="Add" Text="+" />
        </Columns>
    </asp:GridView>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Label ID="lblHidden" runat="server" Text=""></asp:Label>
    <ajaxToolkit:ModalPopupExtender ID="mpeAddToPlaylist" runat="server" TargetControlID="lblHidden" PopupControlID="divPopUp"></ajaxToolkit:ModalPopupExtender>

    <div id="divPopUp">
        <div id="divPopUpInside">
            <h2>Add to playlist</h2>
            Create new playlist and add: <asp:TextBox ID="txtFileName" runat="server"></asp:TextBox><br />
            <br />
            <div id="btnDivCreate" class="buttonOK">
                <asp:Button ID="btnCreate" runat="server" CssClass="buttons" Text="Create and add" />
            </div>
            <br />
            Add to existing playlist:
        <asp:DropDownList ID="ddlPlaylistNames" runat="server"></asp:DropDownList><br />
            <br />
            <div id="btnAddDiv">
                <asp:Button ID="btnAdd" runat="server" CssClass="buttons" Text="Add" />
            </div>
        </div>
    </div>
    <asp:Label ID="lblMessages" runat="server"></asp:Label>
</asp:Content>
