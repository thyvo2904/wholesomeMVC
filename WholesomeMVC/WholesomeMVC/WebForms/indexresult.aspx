<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/_layout.Master" AutoEventWireup="True" CodeBehind="indexresult.aspx.cs" Inherits="WholesomeMVC.WebForms.indexresult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="style" runat="server">
    <link href="/Content/Custom/indexresult.css" rel="stylesheet" type="text/css" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
	<section>
		<h3><asp:Literal ID="search_summary" runat="server" /></h3>

		<nav aria-label="Page navigation">
			<ul class="pagination"></ul>
		</nav>

			<!-- grid view of search result panels -->
		<ul id="search_results" runat="server" class="row search_results">
		</ul>

		<!-- Modal for expanded view -->
		<div class="modal fade" id="expanded_view" tabindex="-1" role="dialog" aria-labelledby="expanded view">
			<div class="modal-dialog modal-sm" role="document">
				<div class="modal-content">
					<asp:ScriptManager runat="server" EnablePartialRendering="true"></asp:ScriptManager>
					<asp:UpdatePanel runat="server">
						<ContentTemplate>
							<div runat="server" class="modal-header">
								<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
								<h4 class='panel-title equal-height'>
									<asp:Label ID="lblFoodName" runat="server"></asp:Label>
								</h4>
							</div>

							<div runat="server" id="nd_score_panel" class="modal-body">
								<h4>
									<strong>ND_Score:
									<asp:Label runat="server" ID="lblIndexResult"></asp:Label>
									</strong>
								</h4>
							</div>

							<div class="modal-body">
								<h4><strong>Nutrition Facts</strong></h4>
								<table class='table table-condensed table-hover'>
									<tbody>
										<tr class='fatter'>
											<th>Calories</th>
											<td><asp:Label ID="txtcalories" runat="server" /></td>
											<td></td>
										</tr>
										<tr class='fat'>
											<th>Saturated Fat</th>
											<td><asp:Label ID="txtsatfat" runat="server" /></td>
											<td>g</td>
										</tr>
										<tr>
											<th>Sodium</th>
											<td><asp:Label ID="txtsodium" runat="server" /></td>
											<td>g</td>
										</tr>
										<tr>
											<th>Dietary Fiber</th>
											<td><asp:Label ID="txtfiber" runat="server" /></td>
											<td>g</td>
										</tr>
										<tr>
											<th>Total Sugars</th>
											<td><asp:Label ID="txtsugar" runat="server" /></td>
											<td>g</td>
										</tr>
										<tr>
											<th>Protein</th>
											<td><asp:Label ID="txtprotein" runat="server" /></td>
											<td>g</td>
										</tr>
										<tr class='fatter'>
											<th>Vitamin A</th>
											<td><asp:Label ID="txtva" runat="server" /></td>
											<td>IU</td>
										</tr>
										<tr>
											<th>Vitamin C</th>
											<td><asp:Label ID="txtvc" runat="server" /></td>
											<td>IU</td>
										</tr>
										<tr>
											<th>Calcium</th>
											<td><asp:Label ID="txtcalcium" runat="server" /></td>
											<td>mg</td>
										</tr>
										<tr>
											<th>Iron</th>
											<td><asp:Label ID="txtiron" runat="server" /></td>
											<td>mg</td>
										</tr>
									</tbody>
								</table>

								<div id="sook" runat="server">
									<hr />
									<div class="form-group" runat="server">
										<label for="ddlFBCategories"><asp:Label Text="Categories" runat="server" /></label>
										<p>
											<asp:DropDownList ID="ddlFBCategories" runat="server" ClientIDMode="Static">
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
										</p>
									</div>
									<div class="form-group" runat="server">
										<label for="lblCeresStatus"><asp:Label Text="Ceres Status" runat="server" /></label>
										<p>
											<asp:Label ID="txtCeresStatus" runat="server" CssClass="form-control-static"></asp:Label>
										</p>
									</div>
									<div class="form-group" runat="server">
										<label for="txtCeresNumber"><asp:Label Text="Ceres Number" runat="server" /></label>
										<p>
											<asp:TextBox ID="txtCeresNumber" CssClass="form-control" runat="server" placeholder="12345..."></asp:TextBox>
										</p>
									</div>
									<div class="form-group" runat="server">
										<label for="txtCeresDescription"><asp:Label Text="Ceres Description" runat="server" /></label>
										<p>
											<asp:TextBox ID="txtCeresDescription" CssClass="form-control" runat="server" placeholder="Item description..."></asp:TextBox><br>
										</p>
									</div>
								</div>
							</div>
							<div class="modal-footer">
								<asp:Button Text="Close" runat="server" CssClass="btn btn-default" data-dismiss="modal" type="button" />
								<asp:Button Text="Compare Item" runat="server" ID="btnCompare" CssClass="btn btn-success" OnClick="CompareItem" />
								<asp:Button Text="Save" runat="server" ID="btnSaveItem" CssClass="btn btn-success" OnClick="btnSaveItem_Click" />
                                <asp:Button Text="Update" runat="server" ID="btnUpdate" CssClass="btn btn-success" OnClick="btnUpdate_Click" />
							</div>
							<!-- hack to make on-server-generated buttons work -->
							<asp:HiddenField runat="server" ID="lblNdbno" ClientIDMode="Static"></asp:HiddenField>
							<asp:HiddenField runat="server" ID="lblName" ClientIDMode="Static"></asp:HiddenField>
							<asp:Button runat="server" ID="button_expand_item" OnClick="ExpandItem" ClientIDMode="Static" CssClass="hidden" />
						</ContentTemplate>
						<Triggers>
							<asp:AsyncPostBackTrigger ControlID="button_expand_item" EventName="Click" />
						</Triggers>
					</asp:UpdatePanel>
				</div>
			</div>
		</div>
	</section>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
	<script type="text/javascript" src="/Scripts/Vendor/jquery.easyPaginate.js"></script>
    <script type="text/javascript" src="/Scripts/Custom/indexresult.js"></script>
</asp:Content>