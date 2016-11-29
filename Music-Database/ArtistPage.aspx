<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ArtistPage.aspx.cs" Inherits="ArtistPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
    <br /> <h1 id="pageHeader"><asp:Label ID="lblArtistName" runat="server"></asp:Label></h1>
    <asp:GridView ID="gvArtistPage" CssClass="query" OnRowDataBound="gvArtistPage_RowDataBound" runat="server" ></asp:GridView>
    <asp:Label ID="lblMessages" runat="server"></asp:Label>
</asp:Content>

