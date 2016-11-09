﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditArtist.aspx.cs" Inherits="EditArtist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="Server">
    <br />
    <h1 id="pageHeader">Edit or Add new</h1>
        <asp:GridView ID="gvEditArtist" CssClass="query" runat="server">
        </asp:GridView>

    <div class="editFields">
        <p>Name</p>
        <asp:TextBox ID="tbArtistName" runat="server"></asp:TextBox> <br />
        <p>Select year</p>
        <asp:DropDownList ID="ddlSelectYear" runat="server"></asp:DropDownList> <br />
        <p>Select country</p>
        <asp:DropDownList ID="ddlSelectCountry" runat="server"></asp:DropDownList> <br />
        <asp:Button ID="btnAdd" Text="Add artist" runat="server" /> <br />
        <asp:Button ID="btnSave" Text="Save changes" runat="server" /> <br />
        <asp:Button ID="btnDelete" Text="Delete artist" runat="server" />
    </div>

</asp:Content>

