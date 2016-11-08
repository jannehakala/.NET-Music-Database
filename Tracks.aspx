<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Tracks.aspx.cs" Inherits="Tracks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
    <br /><h1 id="pageHeader">Tracks</h1>
    <asp:GridView ID="gvTracks" CssClass="query" OnRowDataBound="gvTracks_RowDataBound" runat="server">

    </asp:GridView>
</asp:Content>

