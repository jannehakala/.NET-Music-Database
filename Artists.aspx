<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Artists.aspx.cs" Inherits="Artists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
    <br /><h1 id="pageHeader">Artists</h1>
    <asp:GridView ID="gvArtist" CssClass="query" OnRowDataBound="gvArtist_RowDataBound" runat="server">

    </asp:GridView>
</asp:Content>

