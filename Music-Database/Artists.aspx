﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Artists.aspx.cs" Inherits="Artists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
    <br />
    <h1 id="pageHeader" class="pageName">Artists</h1>

    <asp:Button ID="btnEdit" CssClass="buttons updateButton" PostBackUrl="~/EditPages/EditArtist.aspx" Text="Edit" runat="server" />

    <asp:GridView ID="gvArtist" CssClass="query" OnRowDataBound="gvArtist_RowDataBound" runat="server">
    </asp:GridView>
    <asp:Label ID="lblMessages" runat="server"></asp:Label>

</asp:Content>

