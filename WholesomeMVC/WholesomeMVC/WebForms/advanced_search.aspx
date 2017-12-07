<%@ Page Language="C#" MasterPageFile="~/WebForms/_layout.Master" AutoEventWireup="True" CodeBehind="advanced_search.aspx.cs" Inherits="WholesomeMVC.WebForms.advanced_search" %>

<asp:Content runat="server" ContentPlaceHolderID="style">

</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="body">
	<!-- search panel -->
	<section class="container" id="search-panel">
		<div class="row">
			<div class="col-sm-4">
				<asp:DropDownList
					ID="ddlCategory"
					runat="server"
					CssClass="btn btn-default btn-lg dropdown-toggle equal-height"
					AppendDataBoundItems="True"
					OnSelectedIndexChanged="Page_Load"
					DataSourceID="Category"
					DataTextField="FdGrp_Desc"
					Style="width: 100%;"
					DataValueField="FdGrp_Desc">
					<asp:ListItem Selected="True">Select a category</asp:ListItem>
				</asp:DropDownList>
				<asp:SqlDataSource
					ID="SqlDataSource1"
					runat="server"
					ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
					SelectCommand="SELECT [FdGrp_Desc] FROM [FD_GROUP]"></asp:SqlDataSource>
			</div>

			<div class="col-sm-8">
				<div class="input-group input-group-lg">
					<asp:TextBox ID="txtAdvSearch" runat="server" CssClass="form-control typeahead equal-height" autocomplete="off"></asp:TextBox>
					<span class="input-group-btn">
						<button type="submit" class="btn btn-default equal-height" runat="server" onserverclick="btnAdvSearch_Click">
							<span class="glyphicon glyphicon-search"></span>
						</button>
					</span>
				</div>
			</div>
		</div>
	</section>

	<!-- search option panel -->
	<section class="container">
		<div class="row">
			<div class="col-sm-4">
				<div class="panel panel-default">
					<div class="panel-heading">
						<h3 class="panel-title">Data Source:</h3>
					</div>
					<div class="panel-body">
						<div class="checkbox">
							<label>
								<input id="cbxAPI" type="checkbox" runat="server">
								API
							</label>
						</div>
						<div class="checkbox">
							<label>
								<input id="cbxCeres" type="checkbox" runat="server">
								Ceres Database
							</label>
						</div>
					</div>
				</div>
			</div>
			<div class="col-sm-4">
				<div class="panel panel-default">
					<div class="panel-heading">
						<h3 class="panel-title">Data Source:</h3>
					</div>
					<div class="panel-body">
						<div class="checkbox">
							<label>
								<input id="cbxFoodname" type="checkbox" runat="server">
								Food Name
							</label>
						</div>
						<div class="checkbox">
							<label>
								<input id="cbxRelevance" type="checkbox" runat="server" />
								Relevance
							</label>
						</div>
					</div>
				</div>
			</div>
			<div class="col-sm-4">
				<div class="panel panel-default">
					<div class="panel-heading">
						<h3 class="panel-title">Data Source:</h3>
					</div>
					<div class="panel-body">
						<div class="checkbox">
							<label>
								<input id="cbxStandard" type="checkbox" runat="server" />
								Standard Reference
							</label>
						</div>
						<div class="checkbox">
							<label>
								<input id="cbxBranded" type="checkbox" runat="server" />
								Branded Reference
							</label>
						</div>
					</div>
				</div>
			</div>
		</div>
	</section>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="script">
    <script type="text/javascript" src="/Scripts/Vendor/jquery.matchHeight-min.js"></script>
    <script type="text/javascript" src="/Scripts/Custom/advanced_search.js"></script>
</asp:Content>
