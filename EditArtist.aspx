<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditArtist.aspx.cs" Inherits="EditArtist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="Server">
    <br />
    <button id="btnBack" class="buttons" runat="server" onserverclick="btnBack_ServerClick"><i class='fa fa-arrow-left fa-lg'></i></button>

    <h1 id="pageHeader">Edit or Add new</h1>

    <asp:GridView ID="gvEditArtist" OnSelectedIndexChanged="gvEditArtist_SelectedIndexChanged" CssClass="query" OnRowDataBound="gvEditArtist_RowDataBound" runat="server">
        <Columns>
            <asp:ButtonField CommandName="Select" HeaderText="Edit" Text="Select" />
        </Columns>
    </asp:GridView>
    <asp:RegularExpressionValidator ID="regexpName" runat="server"     
                                    ErrorMessage="No special characters." 
                                    ControlToValidate="txtArtistName"     
                                    ValidationExpression="^[\w{.,'}+:?®©-]+$" />
    <div id="editFields">
        <span>Name:</span><br />
        <asp:Panel runat="server" DefaultButton="btnAdd">
            <asp:TextBox ID="txtArtistName" runat="server"></asp:TextBox>
        </asp:Panel>
        <br />
        <br />
        <span>Select year:</span><br />
        <asp:DropDownList ID="ddlSelectYear" CssClass="comboYear" runat="server"></asp:DropDownList>
        <br />
        <br />
        <span>Select country:</span><br />
        <asp:DropDownList ID="ddlSelectCountry" CssClass="comboCountry" runat="server"></asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btnAdd" Text="Add artist" CssClass="buttons addButton" OnClick="btnAdd_Click" runat="server" />
        <br />
        <asp:Button ID="btnSave" Text="Save changes" CssClass="buttons updateButton" OnClick="btnSave_Click" runat="server" />
        <br />
        <asp:Button ID="btnDelete" Text="Delete artist" CssClass="buttons deleteButton" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete this artist ?')" runat="server" /><br />
        <br />
        <asp:Label ID="lblMessages" Text="Select artist to edit." runat="server" Font-Size="15"></asp:Label>
    </div>
</asp:Content>

