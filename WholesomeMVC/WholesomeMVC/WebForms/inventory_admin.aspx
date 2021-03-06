﻿<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/_layout.Master" AutoEventWireup="true" CodeBehind="inventory_admin.aspx.cs" Inherits="WholesomeMVC.WebForms.inventory_admin" %>

<asp:Content ContentPlaceHolderID="style" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="body" runat="server">
	<%--<section id="content_header">
		<nav class="navbar">
			<h4>Quick Links</h4>
			<ul class="footer-link">
				<li><a href="#" class="active">Current Item Overview</a></li>
				<li>&bull;</li>
				<li><a href="Settings.aspx">Settings</a></li>
				<li>&bull;</li>
				<li><a href="account_management.aspx">Account Management</a></li>
				<li>&bull;</li>
				<li><a href="#">History</a></li>
				<li>&bull;</li>
				<li><a href="Item_Management.aspx">Item Management</a></li>
			</ul>
		</nav>
	</section>--%>

		<section>
			<!-- chart #1 -->
			<h4><asp:Label ID="chart_1_header" runat="server" /></h4>
            <script type='text/javascript' src='https://us-east-1.online.tableau.com/javascripts/api/viz_v1.js'></script>
            <div class='tableauPlaceholder' style='width: 1000px; height: 827px;'>
                <object class='tableauViz' width='1000' height='827' style='display: none;'>
                    <param name='host_url' value='https%3A%2F%2Fus-east-1.online.tableau.com%2F' />
                    <param name='embed_code_version' value='2' />
                    <param name='site_root' value='&#47;t&#47;wholesomeinc' />
                    <param name='name' value='inventory&#47;Story2' />
                    <param name='tabs' value='no' />
                    <param name='toolbar' value='yes' />
                    <param name='showAppBanner' value='false' />
                    <param name='showShareOptions' value='true' />
                    <param name='refresh' value='yes' />
                </object>
            </div>
           <%-- <script type='text/javascript' src='https://us-east-1.online.tableau.com/javascripts/api/viz_v1.js'></script>
            <div class='tableauPlaceholder' style='width: 1024px; height:1000px;'>
                <object class='tableauViz' width='1024' height='1000' style='display: none;'>
                    <param name='host_url' value='https%3A%2F%2Fus-east-1.online.tableau.com%2F' />
                    <param name='embed_code_version' value='2' />
                    <param name='site_root' value='&#47;t&#47;wholesomeinc' />
                    <param name='name' value='inventory&#47;Story2' />
                    <param name='tabs' value='no' />
                    <param name='toolbar' value='yes' />
                    <param name='showAppBanner' value='false' />
                    <param name='showShareOptions' value='true' />
                    <param name='refresh' value='yes' />
                </object>
            </div>
           --%>
           

			<div class="row">
				<div class="col-md-6">
					<h4><asp:Label ID="whatif_header" runat="server" /></h4>
					<table class="table form-horizontal">
						<tbody>
							<tr>
								<th>Cere&#39;s Item</th>
								<td>
									<asp:DropDownList
										ID="ddlCereItem"
										runat="server"
										CssClass="selectpicker equal-height"
										data-width="100%"
										data-live-search="true"
										title="Select a category"
										DataSourceID="SqlDataSource1"
										DataTextField="Description"
										DataValueField="Description">
									</asp:DropDownList>
									<asp:SqlDataSource
										ID="SqlDataSource1"
										runat="server"
										ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
										SelectCommand="SELECT [Description] FROM [Wholesome_Item]"></asp:SqlDataSource>
								    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCereItem" ErrorMessage="Required" ForeColor="Red" ValidationGroup="btnWhatif"></asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<th>FB Food Group</th>
								<td>
									<asp:DropDownList
										ID="ddlFBGroup"
										runat="server"
										CssClass="selectpicker equal-height"
										data-width="100%"
										data-live-search="true"
										title="Select a category"
										DataSourceID="SqlDataSource2"
										DataTextField="FBC_CODE"
										DataValueField="FBC_CODE">
									</asp:DropDownList>
									<asp:SqlDataSource
										ID="SqlDataSource2"
										runat="server"
										ConnectionString="<%$ ConnectionStrings:constr2 %>"
										SelectCommand="SELECT [FBC_CODE] FROM [FB_FOOD] ORDER BY [FBC_CODE]"></asp:SqlDataSource>
								    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlFBGroup" ErrorMessage="Required" ForeColor="Red" ValidationGroup="btnWhatif"></asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<th>Quantity (lbs)</th>
								<td>
									<asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
								    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Required" ForeColor="Red" ValidationGroup="btnWhatif"></asp:RequiredFieldValidator>
								</td>
							</tr>
						</tbody>
					</table>
					<div class="text-right">
						<asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-default btn-lg" OnClick="btnReset_Click" />
						<asp:Button ID="btnWhatif" runat="server" OnClick="btnWhatif_Click" Text="What If" CssClass="btn btn-primary btn-lg" ValidationGroup="btnWhatif" />
					</div>
				</div>
			</div>
		</section>
	
</asp:Content>

<asp:Content ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript" src="/Scripts/Custom/jquery.matchHeight-min.js"></script>
    <script type="text/javascript" src="/Scripts/Custom/inventory_admin.js"></script>
</asp:Content>