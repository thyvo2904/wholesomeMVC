<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/_layout.Master" AutoEventWireup="True" CodeBehind="indexresult.aspx.cs" Inherits="WholesomeMVC.WebForms.indexresult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="style" runat="server">
    <link href="/Content/Custom/indexresult.css" rel="stylesheet" type="text/css" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
	<section>
		<h3><asp:Literal ID="search_summary" runat="server" /></h3>

		<!-- grid view of search result panels -->
		<div id="search_results" runat="server" class="row"></div>

		<!-- Modal for expanded view -->
		<div class="modal fade" id="expanded_view" tabindex="-1" role="dialog" aria-labelledby="expanded view">
			<div class="modal-dialog modal-sm" role="document">
				<div class="modal-content">
					<asp:ScriptManager runat="server" EnablePartialRendering="true"></asp:ScriptManager>
					<asp:UpdatePanel runat="server">
						<ContentTemplate>
							<div id="modal_header" runat="server" class="modal-header">
								<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
								<h4 class='panel-title equal-height'>
									<asp:Label ID="lblFoodName" runat="server"></asp:Label>
								</h4>
								<h4>
									<strong>
										ND_Score:
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
										<label for="lblCeresStatus"><asp:Label Text="" runat="server" /></label>
										<asp:TextBox ID="txtCeresStatus" CssClass="form-control" runat="server"></asp:TextBox>
									</div>
									<div class="form-group" runat="server">
										<label for="txtCeresNumber"><asp:Label Text="Ceres Number" runat="server" /></label>
										<asp:TextBox ID="txtCeresNumber" CssClass="form-control" runat="server" placeholder="12345..."></asp:TextBox>
									</div>
									<div class="form-group" runat="server">
										<label for="txtCeresDescription"><asp:Label Text="Ceres Description" runat="server" /></label>
										<asp:TextBox ID="txtCeresDescription" CssClass="form-control" runat="server" placeholder="Item description..."></asp:TextBox><br>
									</div>
								</div>
							</div>
							<div class="modal-footer">
								<asp:Button Text="Close" runat="server" CssClass="btn btn-default" data-dismiss="modal" type="button" />
								<asp:Button Text="Compare Item" runat="server" ID="btnCompare" CssClass="btn btn-success" OnClick="CompareItem" />
								<asp:Button Text="Save" runat="server" ID="btnSaveItem" CssClass="btn btn-success" OnClick="btnSaveItem_Click" />
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
    <script type="text/javascript" src="/Scripts/Custom/indexresult.js"></script>
</asp:Content>