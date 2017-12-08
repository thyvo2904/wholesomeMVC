<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/_layout.Master" AutoEventWireup="true" CodeBehind="recent.aspx.cs" Inherits="WholesomeMVC.WebForms.recent" %>

<asp:Content ContentPlaceHolderID="style" runat="server">
    <link href="/Content/Custom/recent.css" rel="stylesheet" type="text/css" runat="server" />
</asp:Content>

<asp:Content ContentPlaceHolderID="body" runat="server">
	<!-- hack to make on-server-generated buttons work -->
	<asp:HiddenField runat="server" ID="hidden_item_index" ClientIDMode="Static" />
	<asp:HiddenField runat="server" ID="error_message" ClientIDMode="Static" />
	<asp:HiddenField runat="server" ID="success_message" ClientIDMode="Static" />

	<section>
		<h4><asp:Label ID="label_recent_items" runat="server" /></h4>
		<section id="section_recent_items" runat="server" class="row"></section>
	</section>
</asp:Content>

<asp:Content ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript" src="/Scripts/Custom/recent.js"></script>
</asp:Content>