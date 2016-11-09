<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Artists.aspx.cs" Inherits="Artists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
    <br /><h1 id="pageHeader">Artists</h1>

    <asp:Button ID="btnEdit" PostBackUrl="~/EditArtist.aspx" Text="Edit" runat="server" />

    <asp:GridView ID="gvArtist" CssClass="query" OnRowDataBound="gvArtist_RowDataBound" runat="server">
    </asp:GridView>

    <%--<asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <br />
            <asp:HyperLink ID="href1" Text="edit" NavigateUrl="~/About.aspx" runat="server"></asp:HyperLink>
        </ItemTemplate>
    </asp:Repeater>--%>
</asp:Content>

