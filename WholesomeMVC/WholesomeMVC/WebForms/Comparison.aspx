<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/WebForms/_layout.Master" CodeBehind="Comparison.aspx.cs" Inherits="WholesomeMVC.WebForms.Comparison" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="style" runat="server">
    <link href="/Content/Custom/comparison.css" rel="stylesheet" type="text/css" runat="server" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <br>
    <button runat="server" type="submit" class="btnexport2" onserverclick="btntable_Export">Export To Excel</button>
    <br>
    <asp:PlaceHolder runat="server" ID="compare"></asp:PlaceHolder>
</asp:Content>
