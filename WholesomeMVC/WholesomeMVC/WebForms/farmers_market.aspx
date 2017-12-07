<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/WebForms/_layout.Master" CodeBehind="Farmers_Market.aspx.cs" Inherits="WholesomeMVC.WebForms.Farmers_Market" %>

<asp:Content ContentPlaceHolderID="style" runat="server">
	<link href="/Content/Vendor/footable.bootstrap.min.css" rel="stylesheet" type="text/css" />
	<link href="/Content/Custom/farmers_market.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ContentPlaceHolderID="body" runat="server">
	<section class="row">
		<h4 class="text-center">
			<asp:Literal ID="lblFarmersMarket" runat="server"></asp:Literal>
		</h4>
		<div class="col-sm-offset-3 col-sm-6">
			<div class="input-group input-group-lg">
				<asp:TextBox ID="txtFarmersMarket" runat="server" CssClass="form-control typeahead equal-height" placeholder="22807"></asp:TextBox>
				<span class="input-group-btn">
					<asp:Button ID="btnSearchFarmersMarket" runat="server" CssClass="btn btn-default equal-height" Text="Search" ClientIDMode="Static" OnClick="btnSearchFarmersMarket_Click" />
				</span>
			</div>
		</div>
	</section>

	<section class="row">
		<h3><asp:Literal ID="search_summary" runat="server" /></h3>
		<asp:GridView
			ID="gridFarmersMarket"
			runat="server"
			AutoGenerateColumns="false"
			ClientIDMode="Static"
			CssClass="table table-bordered table-hover"
			RowStyle-Wrap="false"
			OnSelectedIndexChanged="gridFarmersMarket_SelectedIndexChanged">
			<Columns>
				<asp:BoundField DataField="ID" HeaderText="ID" />
				<asp:BoundField DataField="Distance" HeaderText="Distance (miles)" />
				<asp:BoundField DataField="Market_Name" HeaderText="Market Name" />
				<asp:CommandField ShowSelectButton="True" SelectText="Select" />
			</Columns>
		</asp:GridView>
	</section>

	<section runat="server" id="google_map_section" class="row">
		<div class="page-header">
			<h3>
				<asp:Literal ID="lblFarmersMarketName" runat="server" Text=""></asp:Literal>
				<small>
					<asp:Literal ID="lblFarmersMarketLocation" runat="server" Text=""></asp:Literal>
				</small>
			</h3>
		</div>
		<div>
		<iframe
			runat="server"
			height="450"
			width="100%"
			frameborder="0"
			style="border: 0"
			id="farmersMarketIFrame">
		</iframe>
		</div>
	</section>
</asp:Content>

<asp:Content ContentPlaceHolderID="script" runat="server">
	<script type="text/javascript" src="/Scripts/Vendor/moment.min.js"></script>
	<script type="text/javascript" src="/Scripts/Vendor/footable.min.js"></script>
    <script type="text/javascript" src="/Scripts/Custom/farmers_market.js"></script>
</asp:Content>