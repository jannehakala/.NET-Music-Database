﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RecordCompanies.aspx.cs" Inherits="RecordCompanies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
    <br /><h1 id="pageHeader" class="pageName">Record Companies</h1>
    <asp:Button ID="btnEdit" CssClass="buttons updateButton" PostBackUrl="~/EditPages/EditRecordCompanies.aspx" Text="Edit" runat="server" />
    <asp:GridView ID="gvRecordCompanies" OnRowDataBound="gvRecordCompanies_RowDataBound" CssClass="query" runat="server">
    </asp:GridView>
    <asp:Label ID="lblMessages" runat="server"></asp:Label>
</asp:Content>

