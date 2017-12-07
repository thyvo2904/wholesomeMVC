<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/_layout.Master" AutoEventWireup="true" CodeBehind="manual_input.aspx.cs" Inherits="WholesomeMVC.WebForms.manual_input" %>

<asp:Content ContentPlaceHolderID="style" runat="server">
    <link href="/Content/Custom/manual_input.css" rel="stylesheet" type="text/css" runat="server" />
</asp:Content>

<asp:Content ContentPlaceHolderID="body" runat="server">
    <section class="row">
		<section class="col-lg-offset-2 col-lg-8">
			<asp:HiddenField ID="view_mode" runat="server" ClientIDMode="Static" />
			<asp:HiddenField ID="error_message" runat="server" ClientIDMode="Static" />

			<h4><asp:Label ID="body_description" runat="server" /></h4>

			<!-- switch buttons for old/new view mode -->
			<ul class="nav nav-pills" id="view_nav">
				<li role="presentation"><a id="old_li">Old Label</a></li>
				<li role="presentation"><a id="new_li">New Label</a></li>
			</ul>

			<hr />

			<!-- old view mode -->
			<section id="old_view">
				<!-- result -->
				<div class="form-group">
					<h4>
						<label class="control-label">
							<asp:Label ID="label_score0" runat="server" />
						</label>
					</h4>

					<span class="help-block">
						<asp:Label ID="label_score_help0" runat="server" />
					</span>

					<h1 id="txtindex0_wrapper" runat="server" class="form-control-static text-primary">
						<strong><asp:Label ID="txtindex0" runat="server" /></strong>
					</h1>
				</div>

				<hr />

				<!-- form -->
				<h4><strong>Nutrition Facts</strong></h4>
				<table class="table form-horizontal">
					<tbody>
						<tr class='fatter'>
							<th>Calories</th>
							<td></td>
							<td>
								<asp:TextBox ID="txtKcal0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
							</td>
						</tr>
						<tr class='fat'>
							<th>Saturated Fat</th>
							<td>g</td>
							<td>
								<asp:TextBox ID="txtsatfat0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<th>Sodium</th>
							<td>g</td>
							<td>
								<asp:TextBox ID="txtsodium0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<th>Dietary Fiber</th>
							<td>g</td>
							<td>
								<asp:TextBox ID="txtfiber0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<th>Total Sugars</th>
							<td>g</td>
							<td>
								<asp:TextBox ID="txtsugar0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<th>Protein</th>
							<td>g</td>
							<td>
								<asp:TextBox ID="txtprotein0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
							</td>
						</tr>
						<tr class='fatter'>
							<th>Vitamin A</th>
							<td>IU</td>
							<td>
								<asp:TextBox ID="txtva0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<th>Vitamin C</th>
							<td>IU</td>
							<td>
								<asp:TextBox ID="txtvc0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<th>Calcium</th>
							<td>mg</td>
							<td>
								<asp:TextBox ID="txtcalcium0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<th>Iron</th>
							<td>mg</td>
							<td>
								<asp:TextBox ID="txtiron0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
							</td>
						</tr>
					</tbody>
				</table>
				<div class="form-group text-right">
					<hr />
					<asp:Button ID="button_reset0" runat="server" CssClass="btn btn-danger btn-lg" OnClick="Reset0" />
					<asp:Button ID="button_calculate0" runat="server" CssClass="btn btn-success btn-lg" OnClick="Calculate0" />
				</div>
			</section>

			<!-- new view mode -->
			<section id="new_view">
				<!-- result -->
				<div class="form-group">
					<h4>
						<label class="control-label">
							<asp:Label ID="label_score1" runat="server" />
						</label>
					</h4>

					<span class="help-block">
						<asp:Label ID="label_score_help1" runat="server" />
					</span>

					<h1 id="txtindex1_wrapper" runat="server" class="form-control-static text-primary">
						<strong><asp:Label ID="txtindex1" runat="server" /></strong>
					</h1>
				</div>

				<hr />

				<!-- form -->
				<h4><strong>Nutrition Facts</strong></h4>
				<table class="table form-horizontal">
					<tbody>
						<tr class='fatter'>
							<th>Calories</th>
							<td></td>
							<td>
								<asp:TextBox ID="txtKcal1" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
							</td>
						</tr>
						<tr class='fat'>
							<th>Saturated Fat</th>
							<td>g</td>
							<td>
								<asp:TextBox ID="txtsatfat1" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<th>Sodium</th>
							<td>g</td>
							<td>
								<asp:TextBox ID="txtsodium1" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<th>Dietary Fiber</th>
							<td>g</td>
							<td>
								<asp:TextBox ID="txtfiber1" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<th>Added Sugars</th>
							<td>g</td>
							<td>
								<asp:TextBox ID="txtsugar1" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<th>Protein</th>
							<td>g</td>
							<td>
								<asp:TextBox ID="txtprotein1" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
							</td>
						</tr>
						<tr class='fatter'>
							<th>Vitamin D</th>
							<td>%</td>
							<td>
								<asp:TextBox ID="txtvd1" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<th>Calcium</th>
							<td>%</td>
							<td>
								<asp:TextBox ID="txtcalcium1" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<th>Iron</th>
							<td>%</td>
							<td>
								<asp:TextBox ID="txtiron1" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<th>Potassium</th>
							<td>%</td>
							<td>
								<asp:TextBox ID="txtpotassium" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
							</td>
						</tr>
					</tbody>
				</table>

				<!-- buttons -->
				<div class="form-group text-right">
					<hr />
					<asp:Button ID="button_reset1" runat="server" CssClass="btn btn-danger btn-lg" OnClick="Reset1" />
					<asp:Button ID="button_calculate1" runat="server" CssClass="btn btn-success btn-lg" OnClick="Calculate1" />
				</div>
			</section>
		</section>
	</section>
</asp:Content>

<asp:Content ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript" src="/Scripts/Custom/manual_input.js"></script>
</asp:Content>