<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/_layout.Master" AutoEventWireup="true" CodeBehind="recent.aspx.cs" Inherits="WholesomeMVC.WebForms.recent" %>

<asp:Content ContentPlaceHolderID="style" runat="server">
    <link href="/Content/Custom/recent.css" rel="stylesheet" type="text/css" runat="server" />
</asp:Content>

<asp:Content ContentPlaceHolderID="body" runat="server">
	<section>
		<h4><asp:Label ID="label_color_scale_legend" runat="server" /></h4>
		<div class="row">
			<div class="col-md-offset-1 col-md-10">
				<asp:Image ID="image_color_scale_legend" runat="server" CssClass="img-responsive img-rounded" />
			</div>
		</div>
	</section>

	<section>
		<h4><asp:Label ID="label_recent_items" runat="server" /></h4>
		<section id="section_recent_items" runat="server" class="row equal"></section>
	</section>
</asp:Content>

<asp:Content ContentPlaceHolderID="script" runat="server">
</asp:Content>