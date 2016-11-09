<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewArtist.aspx.cs" Inherits="NewArtist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" Runat="Server">

    <asp:TextBox ID="tbArtist" runat="server"></asp:TextBox>
    <asp:DropDownList ID="ddlSelectYear" runat="server"></asp:DropDownList>
    <asp:DropDownList ID="ddlSelectCountry" runat="server"></asp:DropDownList>

</asp:Content>

