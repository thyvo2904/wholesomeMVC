<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/WebForms/_layout.Master" CodeBehind="comparison.aspx.cs" Inherits="WholesomeMVC.WebForms.comparison" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="style" runat="server">
    <link href="/Content/Custom/comparison.css" rel="stylesheet" type="text/css" runat="server" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
	<div>
		<asp:Button Text="Export To Excel" runat="server" OnClick="btntable_Export" CssClass="btn btn-success btn-lg" />
	</div>
	<div>
		<hr />
		<asp:PlaceHolder runat="server" ID="compare"></asp:PlaceHolder>
	</div>
</asp:Content>
