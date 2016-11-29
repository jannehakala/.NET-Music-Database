<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CompanyPage.aspx.cs" Inherits="CompanyPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">
    <br /><h1 id="pageHeader"><asp:Label ID="lblCompanyName" runat="server"></asp:Label></h1>
    <asp:GridView ID="gvCompanyPage" CssClass="query" OnRowDataBound="gvCompanyPage_RowDataBound" runat="server"></asp:GridView>
    <asp:Label ID="lblMessages" runat="server"></asp:Label>
</asp:Content>

