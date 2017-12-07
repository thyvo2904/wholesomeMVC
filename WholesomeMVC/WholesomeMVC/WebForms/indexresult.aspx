<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/_layout.Master" AutoEventWireup="true" CodeBehind="indexresult.aspx.cs" Inherits="WholesomeMVC.WebForms.indexresult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="style" runat="server">
    <link href="/Content/Custom/indexresult.css" rel="stylesheet" type="text/css" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
	<%--<section>
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
	</section>--%>

	<section>
	</section>

	<section>
		<h3><asp:Literal ID="search_summary" runat="server" /></h3>
		<%--<h4><asp:Literal ID="filter_applied" runat="server" /></h4>--%>
	    <%--<section id="content_header">
		<h4><asp:Label ID="label_color_scale_legend" runat="server" /></h4>
		<div class="row">
			<div class="col-md-offset-1 col-md-10">
				<asp:Image ID="image_color_scale_legend" runat="server" CssClass="img-responsive img-rounded" />
			</div>
		</div>
	</section>--%>

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

								<hr />
								<div>
                                    <div class="form-group" id="sook" runat="server">
										<label for="lblCeresStatus"><asp:Label Text="" runat="server" /></label>
										<asp:TextBox ID="txtCeresStatus" CssClass="form-control" runat="server"></asp:TextBox>
									</div>
									<div class="form-group" id="sook1" runat="server">
										<label for="txtCeresNumber"><asp:Label Text="Ceres Number" runat="server" /></label>
										<asp:TextBox ID="txtCeresNumber" CssClass="form-control" runat="server" placeholder="12345..."></asp:TextBox>
									</div>
									<div class="form-group" id="sook2" runat="server">
										<label for="txtCeresDescription"><asp:Label Text="Ceres Description" runat="server" /></label>
										<asp:TextBox ID="txtCeresDescription" CssClass="form-control" runat="server" placeholder="Item description..."></asp:TextBox><br>
                                        <button type="button" class="btn btn-sm btn-default" id="btnSaveItem" runat="server" onserverclick="btnSaveItem_Click"><span class="glyphicon glyphicon-floppy-saved"></span>Save</button></span>
									</div>
								</div>
							</div>
							<div class="modal-footer">
								<asp:Button Text="Close" runat="server" CssClass="btn btn-default" data-dismiss="modal" type="button" />
								<asp:Button Text="Compare Item" runat="server" ID="btnCompare" CssClass="btn btn-success" OnClick="CompareItem" />
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
    <script type="text/javascript" src="/Scripts/Vendor/jquery.matchHeight-min.js"></script>
    <script type="text/javascript" src="/Scripts/Custom/indexresult.js"></script>
</asp:Content>