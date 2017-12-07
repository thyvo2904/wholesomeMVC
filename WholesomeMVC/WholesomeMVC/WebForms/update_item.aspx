<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/WebForms/_layout.Master" CodeBehind="update_item.aspx.cs" Inherits="WholesomeMVC.WebForms.update_item" %>
         
<asp:Content ContentPlaceHolderID="style" runat="server">
	<link href="/Content/Vendor/footable.bootstrap.min.css" rel="stylesheet" type="text/css" />
	<link href="/Content/Custom/update_item.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ContentPlaceHolderID="body" runat="server">
	<section>
		<div class="row">
			<div class="col-sm-offset-3 col-sm-6">
				<div class="input-group">
					<asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search"></asp:TextBox>
					<span class="input-group-btn">
						<asp:Button ID="btnSearch" runat="server" Text="Search USDA" CssClass="btn btn-default" />
					</span>
				</div>
			</div>
		</div>
	</section>

	<section>
		<!-- nav to change between old/new/usda view -->
		<h3><asp:Literal ID="view_mode" runat="server" /></h3>
		<ul class="nav nav-pills" id="view_nav">
			<li role="presentation"><a id="link_old_view" href="#">Manual: Old Label</a></li>
			<li role="presentation"><a id="link_new_view" href="#">Manual: New Label</a></li>
			<li role="presentation"><a id="link_usda_view" href="#">USDA</a></li>
		</ul>

		<!-- Search items will show here -->
		<h3><asp:Literal ID="search_summary" runat="server" /></h3>
		<asp:GridView
			ID="gridMatchedCeresIDS" 
			runat="server" 
			CssClass="table table-bordered table-hover"
			OnRowDataBound="ceresMatchedOnRowDataBound"
			AutoGenerateColumns="False"
			ClientIDMode="Static"
			RowStyle-Wrap="false">
			<Columns>
				<asp:BoundField DataField="CeresID" HeaderText="CeresID" />
				<asp:BoundField DataField="Ceres_Name" HeaderText="Ceres_Name" />
				<asp:BoundField DataField="USDA Number" HeaderText="NDBno" />
				<asp:BoundField DataField="Name" HeaderText="Name" />
				<asp:BoundField DataField="ND score" HeaderText="ND Score" />
			</Columns>
		</asp:GridView>
		<asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>

		<!-- hack to expand modal after postback -->
		<asp:HiddenField runat="server" ID="hidden_ceresid" ClientIDMode="Static"></asp:HiddenField>
		<asp:HiddenField runat="server" ID="hidden_ceres_name" ClientIDMode="Static"></asp:HiddenField>
		<asp:HiddenField runat="server" ID="hidden_ndbno" ClientIDMode="Static"></asp:HiddenField>
		<asp:HiddenField runat="server" ID="hidden_view_mode" ClientIDMode="Static"></asp:HiddenField>
		<asp:Button runat="server" ID="button_expand_item" OnClick="ExpandItem" ClientIDMode="Static" CssClass="hidden" />
		
		<!-- dependency for ajax, need to be placed before UpdatePanels -->
		<asp:ScriptManager runat="server" EnablePartialRendering="true"></asp:ScriptManager>

		<!-- Modal for expanded old view -->
		<div class="modal fade" id="expanded_old_view" tabindex="-1" role="dialog" aria-labelledby="expanded view">
			<div class="modal-dialog modal-sm" role="document">
				<div class="modal-content">
					<asp:UpdatePanel runat="server">
						<ContentTemplate>
							<div class="modal-header">
								<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
								<h4 class='panel-title equal-height'>
									<strong>
										<asp:Literal ID="lblOldFoodName" runat="server"></asp:Literal>
									</strong>
								</h4>
							</div>

							<div runat="server" id="nd_old_score_panel" class="modal-body">
								<h4>
									<strong>ND_Score:
									<asp:Label runat="server" ID="lblOldIndexResult"></asp:Label>
									</strong>
								</h4>
							</div>

							<div class="modal-body">
								<h4><strong>Nutrition Facts</strong></h4>
								<table class="table form-horizontal">
									<tbody>
										<tr class='fatter'>
											<th>Calories</th>
											<td>
												<asp:TextBox ID="txtOldKCal" runat="server" CssClass="form-control"></asp:TextBox>
											</td>
											<td></td>
										</tr>
										<tr class='fat'>
											<th>Saturated Fat</th>
											<td>
												<asp:TextBox ID="txtOldSaturatedFat" runat="server" CssClass="form-control"></asp:TextBox>
											</td>
											<td>g</td>
										</tr>
										<tr>
											<th>Sodium</th>
											<td>
												<asp:TextBox ID="txtOldSodium" runat="server" CssClass="form-control"></asp:TextBox>
											</td>
											<td>g</td>
										</tr>
										<tr>
											<th>Dietary Fiber</th>
											<td>
												<asp:TextBox ID="txtOldFiber" runat="server" CssClass="form-control"></asp:TextBox>
											</td>
											<td>g</td>
										</tr>
										<tr>
											<th>Total Sugars</th>
											<td>
												<asp:TextBox ID="txtOldTotalSugar" runat="server" CssClass="form-control"></asp:TextBox>
											</td>
											<td>g</td>
										</tr>
										<tr>
											<th>Protein</th>
											<td>
												<asp:TextBox ID="txtOldProtein" runat="server" CssClass="form-control"></asp:TextBox>
											</td>
											<td>g</td>
										</tr>
										<tr class='fatter'>
											<th>Vitamin A</th>
											<td>
												<asp:TextBox ID="txtOldVitaminA" runat="server" CssClass="form-control"></asp:TextBox>
											</td>
											<td>IU</td>
										</tr>
										<tr>
											<th>Vitamin C</th>
											<td>
												<asp:TextBox ID="txtOldVitaminC" runat="server" CssClass="form-control"></asp:TextBox>
											</td>
											<td>IU</td>
										</tr>
										<tr>
											<th>Calcium</th>
											<td>
												<asp:TextBox ID="txtOldCalcium" runat="server" CssClass="form-control"></asp:TextBox>
											</td>
											<td>mg</td>
										</tr>
										<tr>
											<th>Iron</th>
											<td>
												<asp:TextBox ID="txtOldIron" runat="server" CssClass="form-control"></asp:TextBox>
											</td>
											<td>mg</td>
                                            </tr>
										<tr>
                                            <th>Category</th>
											<td>
												<asp:DropDownList ID="ddlFBCategories" runat="server">
													<asp:ListItem>Baby</asp:ListItem>
													<asp:ListItem>Beverage</asp:ListItem>
													<asp:ListItem>Bread</asp:ListItem>
													<asp:ListItem>Cereal/Brk</asp:ListItem>
													<asp:ListItem>complete</asp:ListItem>
													<asp:ListItem>Condiment</asp:ListItem>
													<asp:ListItem>dairy</asp:ListItem>
													<asp:ListItem>dessert</asp:ListItem>
													<asp:ListItem>Dough</asp:ListItem>
													<asp:ListItem>Dressing</asp:ListItem>
													<asp:ListItem>Entree</asp:ListItem>
													<asp:ListItem>Fruit/veg</asp:ListItem>
													<asp:ListItem>Fruits</asp:ListItem>
													<asp:ListItem>Grain</asp:ListItem>
													<asp:ListItem>Juice</asp:ListItem>
													<asp:ListItem>Mixed/Asst</asp:ListItem>
													<asp:ListItem>NF</asp:ListItem>
													<asp:ListItem>Non-Dairy</asp:ListItem>
													<asp:ListItem>Nutrition</asp:ListItem>
													<asp:ListItem>Pasta</asp:ListItem>
													<asp:ListItem>Pro-Meat</asp:ListItem>
													<asp:ListItem>Pro-Non</asp:ListItem>
													<asp:ListItem>Rice</asp:ListItem>
													<asp:ListItem>Salvage</asp:ListItem>
													<asp:ListItem>Snack</asp:ListItem>
													<asp:ListItem>Vegetables</asp:ListItem>
												</asp:DropDownList>
											</td>
										</tr>
									</tbody>
								</table>

								<hr />
								<div>
									<div class="form-group">
										<label for="txtOldCeresNumber">
											<asp:Literal Text="Ceres Number" runat="server" />
										</label>
										<p>
											<asp:Literal ID="txtOldCeresNumber" runat="server"></asp:Literal>
										</p>
									</div>
									<div class="form-group">
										<label for="txtOldCeresDescription">
											<asp:Literal Text="Ceres Description" runat="server" />
										</label>
										<p>
											<asp:Literal ID="txtOldCeresDescription" runat="server"></asp:Literal>
										</p>
									</div>
								</div>
							</div>
							<div class="modal-footer">
								<asp:Button Text="Close" runat="server" CssClass="btn btn-default" data-dismiss="modal" type="button" />

								<asp:Button ID="btnCalculateOldNRF6" OnClick="btnCalculateOldNRF6_Click" runat="server"  Text="Calculate" CssClass="btn btn-primary" type="button" />
								<asp:Button ID="btnSaveOldItem" OnClick="btnOldSaveItem_Click" runat="server" Text="Save" CssClass="btn btn-success" type="button" />
							</div>
						</ContentTemplate>
						<Triggers>
							<asp:AsyncPostBackTrigger ControlID="button_expand_item" EventName="Click" />
						</Triggers>
					</asp:UpdatePanel>
				</div>
			</div>
		</div>

		<!-- Modal for expanded new view -->
		<div class="modal fade" id="expanded_new_view" tabindex="-1" role="dialog" aria-labelledby="expanded view">
			<div class="modal-dialog modal-sm" role="document">
				<div class="modal-content">
					<asp:UpdatePanel runat="server">
						<ContentTemplate>
							<div class="modal-header">
								<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
								<h4 class='panel-title equal-height'>
									<strong>
										<asp:Literal ID="lblNewFoodName" runat="server"></asp:Literal>
									</strong>
								</h4>
							</div>

							<div runat="server" id="nd_new_score_panel" class="modal-body">
								<h4>
									<strong>ND_Score:
									<asp:Label runat="server" ID="lblNewIndexResult"></asp:Label>
									</strong>
								</h4>
							</div>

							<div class="modal-body">
								<h4><strong>Nutrition Facts</strong></h4>
								<table class="table form-horizontal">
									<tbody>
										<tr class='fatter'>
											<th>Calories</th>
											<td>
												<asp:TextBox ID="txtNewKCal" runat="server" CssClass="form-control"></asp:TextBox>
											</td>
											<td>g</td>
										</tr>
										<tr class='fat'>
											<th>Saturated Fat</th>
											<td>
												<asp:TextBox ID="txtNewSaturatedFat" runat="server" CssClass="form-control"></asp:TextBox>
											</td>
											<td>g</td>
										</tr>
										<tr>
											<th>Sodium</th>
											<td>
												<asp:TextBox ID="txtNewSodium" runat="server" CssClass="form-control"></asp:TextBox>
											</td>
											<td>g</td>
										</tr>
										<tr>
											<th>Dietary Fiber</th>
											<td>
												<asp:TextBox ID="txtNewFiber" runat="server" CssClass="form-control"></asp:TextBox>
											</td>
											<td>g</td>
										</tr>
										<tr>
											<th>Added Sugars</th>
											<td>
												<asp:TextBox ID="txtNewAddedSugar" runat="server" CssClass="form-control"></asp:TextBox>
											</td>
											<td>g</td>
										</tr>
										<tr>
											<th>Protein</th>
											<td>
												<asp:TextBox ID="txtNewProtein" runat="server" CssClass="form-control"></asp:TextBox>
											</td>
											<td>g</td>
										</tr>
										<tr class='fatter'>
											<th>Vitamin D</th>
											<td>
												<asp:TextBox ID="txtNewVitaminD" runat="server" CssClass="form-control"></asp:TextBox>
											</td>
											<td>%</td>
										</tr>
										<tr>
											<th>Calcium</th>
											<td>
												<asp:TextBox ID="txtNewCalcium" runat="server" CssClass="form-control"></asp:TextBox>
											</td>
											<td>%</td>
										</tr>
										<tr>
											<th>Iron</th>
											<td>
												<asp:TextBox ID="txtNewIron" runat="server" CssClass="form-control"></asp:TextBox>
											</td>
											<td>%</td>
										</tr>
										<tr>
											<th>Potassium</th>
											<td>
												<asp:TextBox ID="txtNewPotassium" runat="server" CssClass="form-control"></asp:TextBox>
											</td>
											<td>%</td>
										</tr>
									</tbody>
								</table>

								<hr />
								<div>
									<div class="form-group">
										<label for="txtNewCeresNumber">
											<asp:Literal Text="Ceres Number" runat="server" />
										</label>
										<p>
											<asp:Literal ID="txtNewCeresNumber" runat="server"></asp:Literal>
										</p>
									</div>
									<div class="form-group">
										<label for="txtNewCeresDescription">
											<asp:Literal Text="Ceres Description" runat="server" />
										</label>
										<p>
											<asp:Literal ID="txtNewCeresDescription" runat="server"></asp:Literal>
										</p>
									</div>
								</div>
							</div>
							<div class="modal-footer">
								<asp:Button Text="Close" runat="server" CssClass="btn btn-default" data-dismiss="modal"  ClientIDMode="Static" type="button" />
								<asp:Button ID="btnCalculateNewNRF6" runat="server" Text="Calculate" CssClass="btn btn-primary" />
								<asp:Button ID="btnSaveNewItem"  runat="server" Text="Save" CssClass="btn btn-success" />
							</div>
						</ContentTemplate>
						<Triggers>
							<asp:AsyncPostBackTrigger ControlID="button_expand_item" EventName="Click" />
						</Triggers>
					</asp:UpdatePanel>
				</div>
			</div>
		</div>

		<!-- Modal for add item view -->
		<div class="modal fade" id="add_item_view" tabindex="-1" role="dialog" aria-labelledby="expanded view">
			<div class="modal-dialog modal-sm" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h4 class='panel-title equal-height'>
							<strong>
								<asp:Literal ID="lblAddItem" runat="server" Text="Add New Item"></asp:Literal>
							</strong>
						</h4>
					</div>

					<div class="modal-body">
						<ul class="nav nav-tabs">
							<li role="presentation"><a id="link_add_manual" href="#">Manual Input</a></li>
							<li role="presentation"><a id="link_add_usda_match" href="#">Closest USDA Match</a></li>
						</ul>
						<br	/>
						<table id="add_manual_view" class="table form-horizontal">
							<tbody>
								<tr class="thin-air">
									<th>Item Number</th>
									<td>
										<asp:TextBox ID="txtAddItemNumber" runat="server" CssClass="form-control"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<th>CERES Description</th>
									<td>
										<asp:TextBox ID="txtAddCeresDescription" runat="server" CssClass="form-control"></asp:TextBox>
									</td>
								</tr>
							</tbody>
						</table>
						<table id="add_usda_match_view" class="table form-horizontal">
							<tbody>
								<tr class="thin-air">
									<th>Search A Similar Item</th>
									<td>
										<asp:TextBox ID="txtSearchUsdaSimilar" runat="server" CssClass="form-control"></asp:TextBox>
									</td>
								</tr>
							</tbody>
						</table>
					</div>
					<div class="modal-footer">
						<asp:Button Text="Close" runat="server" CssClass="btn btn-default" data-dismiss="modal" type="button" />
						<asp:Button ID="btnAddItem" runat="server" Text="Add Item" CssClass="btn btn-success" type="button" />
					</div>
				</div>
			</div>
		</div>
	</section>

	<div class="wrapper">
		<div id="divitem">
			<%--<td><asp:TextBox ID="txtNumber" runat="server"></asp:TextBox>
				<asp:RequiredFieldValidator ControlToValidate="txtNumber" ID="chkItemNumber" runat="server" ValidationGroup="UpdateItem" ErrorMessage="(Required)"></asp:RequiredFieldValidator></td> </tr>--%>
			<%--<select id="ddlMatchedCeresID" runat="server" name="Matched Ceres ID's">--%>
			<%--</select>--%>
		</div>
	</div>


	<div id="divgridview" style="display: none">
		<h4>Search a Similar Item:</h4>
		<div>
			<asp:TextBox ID="txtSearchDescription" runat="server"></asp:TextBox>
		</div>
		<div>
			<asp:Button ID="btnUpdateItem" runat="server" Text="Update Item" CssClass="btncss" OnClick="btnUpdateItem_Click" ValidationGroup="UpdateItem" />
		</div>
		<%--<asp:GridView ID="gridUSDAChoices" runat="server" OnRowDataBound="gridUSDAChoices_RowDataBound" AutoGenerateColumns="false" onselectedindexchanged="gridSearchResults_SelectedIndexChanged" HorizontalAlign="Center">
<Columns>
<asp:BoundField DataField ="NDBno" HeaderText ="NDBno"/>
<asp:BoundField DataField ="Name" HeaderText ="Name"/>
<asp:BoundField DataField ="Food Group" HeaderText ="Food Group"/>
<asp:BoundField DataField ="ND score" HeaderText ="ND Score" />
<asp:commandfield showselectbutton="True" selectText ="Select"/>
</Columns>
</asp:GridView>--%>
		<%--<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">--%>

		<%--</asp:Content>--%>
	</div>

	<div>
		<asp:Label ID="lblFBCategories" Visible="false" runat="server" Text="Choose a Food Bank Category"></asp:Label>
		
		<asp:Button ID="btnSelectFBCategory" runat="server" OnClick="btnSelectFBCategory_Click" Text="Select" Visible="False" />
	</div>
</asp:Content>
    
 <asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
<%--	
	 <script src="Fb_categories.js"></script>

	 <link href="/css/additem.css" rel="stylesheet" type="text/css" runat="server" />
	 <link href="Fb_category.css" rel="stylesheet" type="text/css" runat="server" />
--%>
	
	<script type="text/javascript" src="/Scripts/Vendor/moment.min.js"></script>
	<script type="text/javascript" src="/Scripts/Vendor/footable.min.js"></script>
    <script type="text/javascript" src="/Scripts/Custom/update_item.js"></script>
 </asp:Content>

