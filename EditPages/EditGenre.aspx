<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditGenre.aspx.cs" Inherits="EditGenre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
     <br />
    <button id="btnBack" class="buttons" runat="server" onserverclick="btnBack_ServerClick"><i class='fa fa-arrow-left fa-lg'></i></button>

    <h1 id="pageHeader">Edit or Add a new Genre</h1>

    <asp:GridView ID="gvEditGenre" OnSelectedIndexChanged="gvEditGenre_SelectedIndexChanged" CssClass="query" OnRowDataBound="gvEditGenre_RowDataBound" runat="server">
        <Columns>
            <asp:ButtonField CommandName="Select" HeaderText="Edit" Text="Select" />
        </Columns>
    </asp:GridView>
    <asp:RegularExpressionValidator ID="regexpName" runat="server"     
                                    ErrorMessage="No special characters." 
                                    ControlToValidate="txtGenreName"     
                                    ValidationExpression="^[\w{.,'}+ :?®©-]+$" />
    <div id="editFields">
        <span>Name:</span><br />
        <asp:Panel runat="server" DefaultButton="btnAdd">
            <asp:TextBox ID="txtGenreName" runat="server"></asp:TextBox>
        </asp:Panel>
        <br />
        <br />
        <asp:Button ID="btnAdd" Text="Add a genre" CssClass="buttons addButton" OnClick="btnAdd_Click" runat="server" />
        <br />
        <asp:Button ID="btnSave" Text="Save changes" CssClass="buttons updateButton" OnClick="btnSave_Click" runat="server" />
        <br />
        <asp:Button ID="btnDelete" Text="Delete genre" CssClass="buttons deleteButton" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete this genre ?')" runat="server" /><br />
        <br />
        <asp:Label ID="lblMessages" Text="Select a genre to edit." runat="server" Font-Size="15"></asp:Label>
    </div>
</asp:Content>

