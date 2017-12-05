<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/_layout.Master" AutoEventWireup="true" CodeBehind="indexresult.aspx.cs" Inherits="WholesomeMVC.WebForms.indexresult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="style" runat="server">
    <link href="/Content/Custom/indexresult.css" rel="stylesheet" type="text/css" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
	<section>
		<h3><asp:Literal Text="Filter" runat="server" /></h3>
		<div class="row">
			<div class="col-xs-6 col-sm-4 col-md-2 text-center">
				<div class="panel panel-default text-center filter-button">
					<asp:Image ID="image_grain" runat="server" />
					<asp:Button ID="button_grain" Text="Grain" runat="server" CssClass="btn btn-default btn-block" />
				</div>
			</div>
			<div class="col-xs-6 col-sm-4 col-md-2 text-center">
				<div class="panel panel-default text-center filter-button">
					<asp:Image ID="image_vegetables" runat="server" />
					<asp:Button ID="button_vegetables" Text="Vegetables" runat="server" CssClass="btn btn-default btn-block" />
				</div>
			</div>
			<div class="col-xs-6 col-sm-4 col-md-2 text-center">
				<div class="panel panel-default text-center filter-button">
					<asp:Image ID="image_fruit" runat="server" />
					<asp:Button ID="button_fruit" runat="server" CssClass="btn btn-default btn-block" />
				</div>
			</div>
			<div class="col-xs-6 col-sm-4 col-md-2 text-center">
				<div class="panel panel-default text-center filter-button">
					<asp:Image ID="image_dairy" runat="server" />
					<asp:Button ID="button_dairy" runat="server" CssClass="btn btn-default btn-block" />
				</div>
			</div>
			<div class="col-xs-6 col-sm-4 col-md-2 text-center">
				<div class="panel panel-default text-center filter-button">
					<asp:Image ID="image_baby_food" runat="server" />
					<asp:Button ID="button_baby_food" runat="server" CssClass="btn btn-default btn-block" />
				</div>
			</div>
			<div class="col-xs-6 col-sm-4 col-md-2 text-center">
				<div class="panel panel-default text-center filter-button">
					<asp:Image ID="image_beverages" runat="server" />
					<asp:Button ID="button_beverages" runat="server" CssClass="btn btn-default btn-block" />
				</div>
			</div>
		</div>
	</section>

	<section>
		<h3><asp:Literal ID="search_summary" runat="server" /></h3>
		<h4><asp:Literal ID="filter_applied" runat="server" /></h4>
		<div id="search_results" runat="server" class="row">
			<div class='col-sm-6 col-md-4 col-lg-3'>
				<div class='panel panel-default'>
					<div class='panel-body'>
						<h4 class='panel-title equal-height'>{1}
						</h4>
						<h4><strong>ND_Score: {2}</strong></h4>
						<button class='btn btn-success btn-block'>Expand</button>
					</div>
				</div>
			</div>
<%--			OnSelectedIndexChanged="gridSearchResults_SelectedIndexChanged"
			OnRowDataBound="OnRowDataBound"--%>
			<asp:GridView
				ID="gridSearchResults"
				runat="server"
				AutoGenerateColumns="false"
				Width="660px"
				Visible="true"
				CssClass="myGridStyle"
				PagerStyle-CssClass="pgr"
				EmptyDataText="Please use the search bar to locate food items">
				<Columns>
					<asp:BoundField DataField="NDBno" HeaderText="NDBno" />
					<asp:BoundField DataField="Name" HeaderText="Item" />
					<asp:BoundField DataField="ND score" HeaderText="ND Score" />
					<asp:CommandField ShowSelectButton="True" SelectText="Expand" />
				</Columns>
				<EmptyDataRowStyle Font-Size="30px" />
				<PagerStyle CssClass="pgr"></PagerStyle>
			</asp:GridView>
		</div>
	</section>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript" src="/Scripts/Custom/jquery.matchHeight-min.js"></script>
    <script type="text/javascript" src="/Scripts/Custom/indexresult.js"></script>
</asp:Content>