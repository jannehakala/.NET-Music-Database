<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ArtistPage.aspx.cs" Inherits="ArtistPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
    <br /> <h2><asp:Label ID="lblArtistName" runat="server"></asp:Label></h2>
    <asp:GridView ID="gvArtistPage" CssClass="query" OnRowDataBound="gvArtistPage_RowDataBound" runat="server" ></asp:GridView>
</asp:Content>

