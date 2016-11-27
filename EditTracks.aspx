<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditTracks.aspx.cs" Inherits="EditTracks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
    <br />
    <button id="btnBack" class="buttons" runat="server" onserverclick="btnBack_ServerClick"><i class='fa fa-arrow-left fa-lg'></i></button>

    <h1 id="pageHeader">Edit or Add a new Track</h1>

    <asp:GridView ID="gvEditTracks" OnSelectedIndexChanged="gvEditTracks_SelectedIndexChanged" CssClass="query" OnRowDataBound="gvEditTracks_RowDataBound" runat="server">
        <Columns>
            <asp:ButtonField CommandName="Select" HeaderText="Edit" Text="Select" />
        </Columns>
    </asp:GridView>
    <asp:RegularExpressionValidator ID="regexpName" runat="server"     
                                    ErrorMessage="No special characters." 
                                    ControlToValidate="txtTrackName"     
                                    ValidationExpression="^[\w{.,'}+ :?®©-]+$" />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"     
                                    ErrorMessage="No special characters." 
                                    ControlToValidate="txtNumber"     
                                    ValidationExpression="^[0-9]*$" />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"     
                                    ErrorMessage="No special characters." 
                                    ControlToValidate="txtLength"     
                                    ValidationExpression="^[0-9+:]*$" />
    <div id="editFields">
        <span>Name:</span><br />
        <asp:Panel runat="server" DefaultButton="btnAdd">
            <asp:TextBox ID="txtTrackName" runat="server"></asp:TextBox>
        </asp:Panel>
        <br />
        <br />
        <span>Select an artist:</span><br />
        <asp:DropDownList ID="ddlSelectArtist" CssClass="comboBox" runat="server"></asp:DropDownList>
        <br />
        <br />
        <span>Select an album:</span><br />
        <asp:DropDownList ID="ddlSelectAlbum" CssClass="comboBox" runat="server"></asp:DropDownList>
        <br />
        <br />
        <span>Select a year:</span><br />
        <asp:DropDownList ID="ddlSelectYear" CssClass="comboBox" runat="server"></asp:DropDownList>
        <br />
        <br /> 
        <span>Select a genre:</span><br />
        <asp:DropDownList ID="ddlSelectGenre" CssClass="comboBox" runat="server"></asp:DropDownList>
        <br />
        <br />
        <span>Youtube link:</span><br />
        <asp:Panel runat="server" DefaultButton="btnAdd">
            <asp:TextBox ID="txtTubeLink" placeholder="https://www.youtube.com/watch?v=" style="width: 350px" runat="server"></asp:TextBox>
        </asp:Panel>
        <span>Number:</span><br />
        <asp:Panel runat="server" DefaultButton="btnAdd">
            <asp:TextBox ID="txtNumber" runat="server"></asp:TextBox>
        </asp:Panel>   
        <span>Length:</span><br />
        <asp:Panel runat="server" DefaultButton="btnAdd">
            <asp:TextBox ID="txtLength" placeholder="00:00:00" runat="server"></asp:TextBox>
        </asp:Panel>      
        <asp:Button ID="btnAdd" Text="Add a track" CssClass="buttons addButton" OnClick="btnAdd_Click" runat="server" />
        <br />
        <asp:Button ID="btnSave" Text="Save changes" CssClass="buttons updateButton" OnClick="btnSave_Click" runat="server" />
        <br />
        <asp:Button ID="btnDelete" Text="Delete track" CssClass="buttons deleteButton" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete this track ?')" runat="server" /><br />
        <br />
        <asp:Label ID="lblMessages" Text="Select a track to edit." runat="server" Font-Size="15"></asp:Label>
    </div>
</asp:Content>

