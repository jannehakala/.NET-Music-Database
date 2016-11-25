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
    <ajaxToolkit:ModalPopupExtender ID="mpeAddToPlaylist" runat="server" TargetControlID="lblMessages" PopupControlID="divPopUp"></ajaxToolkit:ModalPopupExtender>
    <div id="divPopUp">
        <div id="divPopUpInside">

            <h2 id="trackNamePopUp" runat="server"></h2>
            Add track to a new playlist:
            <asp:Panel runat="server" DefaultButton="btnCreate">
                <asp:TextBox ID="txtFileName" runat="server"></asp:TextBox><br /><br />
            </asp:Panel>
            
            <div id="btnDivCreate" class="buttonOK">
                <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" CssClass="buttons btnCreate" Text="Create and add" />
            </div>
            <br />
            Add track to an existing playlist:
        <asp:DropDownList ID="ddlPlaylistNames" CssClass="comboPlaylists" runat="server"></asp:DropDownList><br />
            <br />
            <div id="btnAddDiv">
                <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" CssClass="buttons btnAdd" Text="Add" />
                <asp:Button ID="btnCancelAdd" runat="server" OnClick="btnCancelAdd_Click" CssClass="buttons btnCancelAdd" Text="Cancel" />
            </div>
            <br />
            <asp:Label ID="lblMessagePopUp" ForeColor="Red" runat="server"></asp:Label>
        </div>
    </div>
    <asp:Label ID="lblMessages" runat="server"></asp:Label>
</asp:Content>
