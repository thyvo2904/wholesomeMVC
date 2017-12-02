<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/_layout.Master" AutoEventWireup="true" CodeBehind="manual_input.aspx.cs" Inherits="WholesomeMVC.manual_input1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    <asp:Literal ID="page_title" runat="server"></asp:Literal>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="style" runat="server">
    <link href="/Content/Custom/manual_input.css" rel="stylesheet" type="text/css" runat="server" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <section class="row text-center">
		<h2><asp:Label ID="body_title" runat="server" /></h2>
		<hr />
    </section>

    <section class="row">
		<section class="col-lg-offset-2 col-lg-8">
			<asp:HiddenField ID="view_mode" runat="server" ClientIDMode="Static" />
			<asp:HiddenField ID="error_message" runat="server" ClientIDMode="Static" />

			<h4><asp:Label ID="body_description" runat="server" /></h4>

			<!-- switch buttons for old/new view mode -->
			<ul class="nav nav-tabs">
				<li id="old_li"><a href="#" onclick="switchView()">Old</a></li>
				<li id="new_li"><a href="#" onclick="switchView()">New</a></li>
			</ul>

			<!-- old view mode -->
			<section id="old_view">
				<!-- result -->
				<div class="col-lg-12">
					<div class="form-group">
						<label class="control-label">
							<asp:Label ID="label_score0" runat="server" />
						</label>

						<span class="help-block">
							<asp:Label ID="label_score_help0" runat="server" />
						</span>

						<h1 id="txtindex0_wrapper" runat="server" class="form-control-static text-primary">
							<strong><asp:Label ID="txtindex0" runat="server" /></strong>
						</h1>
					</div>
				</div>

				<!-- basic info -->
				<div class="col-md-6">
					<hr />
					<div class="form-group">
						<label for="txtKcal0" class="control-label">
							<asp:Label ID="label_txtKcal0" runat="server" />
						</label>
						<div>
							<asp:TextBox ID="txtKcal0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
						</div>
					</div>

					<div class="form-group">
						<label for="txtKcal0" class="control-label">
							<asp:Label ID="label_txtsatfat0" runat="server" />
						</label>
						<div class="input-group">
							<span class="input-group-addon">g</span>
							<asp:TextBox ID="txtsatfat0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
						</div>
					</div>

					<div class="form-group">
						<label for="txtsodium0" class="control-label">
							<asp:Label ID="label_txtsodium0" runat="server" />
						</label>
						<div class="input-group">
							<span class="input-group-addon">mg</span>
							<asp:TextBox ID="txtsodium0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
						</div>
					</div>

					<div class="form-group">
						<label for="txtfiber0" class="control-label">
							<asp:Label ID="label_txtfiber0" runat="server" />
						</label>
						<div class="input-group">
							<span class="input-group-addon">g</span>
							<asp:TextBox ID="txtfiber0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
						</div>
					</div>

					<div class="form-group">
						<label for="txtsugar0" class="control-label">
							<asp:Label ID="label_txtsugar0" runat="server" />
						</label>
						<div class="input-group">
							<span class="input-group-addon">g</span>
							<asp:TextBox ID="txtsugar0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
						</div>
					</div>

					<div class="form-group">
						<label for="txtprotein0" class="control-label">
							<asp:Label ID="label_txtprotein0" runat="server" />
						</label>
						<div class="input-group">
							<span class="input-group-addon">g</span>
							<asp:TextBox ID="txtprotein0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
						</div>
					</div>
				</div>

				<!-- detail info -->
				<div class="col-md-6">
					<hr />
					<div class="form-group">
						<label for="txtva0" class="control-label">
							<asp:Label ID="label_txtva0" runat="server" />
						</label>
						<div class="input-group">
							<span class="input-group-addon">%</span>
							<asp:TextBox ID="txtva0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
						</div>
					</div>

					<div class="form-group">
						<label for="txtvc0" class="control-label">
							<asp:Label ID="label_txtvc0" runat="server" />
						</label>
						<div class="input-group">
							<span class="input-group-addon">%</span>
							<asp:TextBox ID="txtvc0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
						</div>
					</div>

					<div class="form-group">
						<label for="txtcalcium0" class="control-label">
							<asp:Label ID="label_txtcalcium0" runat="server" />
						</label>
						<div class="input-group">
							<span class="input-group-addon">%</span>
							<asp:TextBox ID="txtcalcium0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
						</div>
					</div>

					<div class="form-group">
						<label for="txtiron0" class="control-label">
							<asp:Label ID="label_txtiron0" runat="server" />
						</label>
						<div class="input-group">
							<span class="input-group-addon">%</span>
							<asp:TextBox ID="txtiron0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
						</div>
					</div>

					<div class="form-group">
						<hr />
						<asp:Button ID="button_calculate0" runat="server" CssClass="btn btn-success btn-lg btn-block" OnClick="Calculate0" />
						<asp:Button ID="button_reset0" runat="server" CssClass="btn btn-danger btn-lg btn-block" OnClick="Reset0" />
					</div>
				</div>
			</section>

			<!-- new view mode -->
			<section id="new_view">
				<!-- result -->
				<div class="col-lg-12">
					<div class="form-group">
						<label class="control-label">
							<asp:Label ID="label_score1" runat="server" />
						</label>

						<span class="help-block">
							<asp:Label ID="label_score_help1" runat="server" />
						</span>

						<h1 id="txtindex1_wrapper" runat="server" class="form-control-static text-primary">
							<strong><asp:Label ID="txtindex1" runat="server" /></strong>
						</h1>
					</div>
				</div>

				<!-- basic info -->
				<div class="col-md-6">
					<hr />
					<div class="form-group">
						<label for="txtKcal1" class="control-label">
							<asp:Label ID="label_txtKcal1" runat="server" />
						</label>
						<div>
							<asp:TextBox ID="txtKcal1" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
						</div>
					</div>

					<div class="form-group">
						<label for="txtsatfat1" class="control-label">
							<asp:Label ID="label_txtsatfat1" runat="server" />
						</label>
						<div class="input-group">
							<span class="input-group-addon">g</span>
							<asp:TextBox ID="txtsatfat1" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
						</div>
					</div>

					<div class="form-group">
						<label for="txtsodium1" class="control-label">
							<asp:Label ID="label_txtsodium1" runat="server" />
						</label>
						<div class="input-group">
							<span class="input-group-addon">mg</span>
							<asp:TextBox ID="txtsodium1" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
						</div>
					</div>

					<div class="form-group">
						<label for="txtfiber1" class="control-label">
							<asp:Label ID="label_txtfiber1" runat="server" />
						</label>
						<div class="input-group">
							<span class="input-group-addon">g</span>
							<asp:TextBox ID="txtfiber1" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
						</div>
					</div>

					<div class="form-group">
						<label for="txtsugar1" class="control-label">
							<asp:Label ID="label_txtsugar1" runat="server" />
						</label>
						<div class="input-group">
							<span class="input-group-addon">g</span>
							<asp:TextBox ID="txtsugar1" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
						</div>
					</div>

					<div class="form-group">
						<label for="txtprotein0" class="control-label">
							<asp:Label ID="label_txtprotein1" runat="server" />
						</label>
						<div class="input-group">
							<span class="input-group-addon">g</span>
							<asp:TextBox ID="txtprotein1" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
						</div>
					</div>
				</div>

				<!-- detail info -->
				<div class="col-md-6">
					<hr />
					<div class="form-group">
						<label for="txtvd1" class="control-label">
							<asp:Label ID="label_txtvd1" runat="server" />
						</label>
						<div class="input-group">
							<span class="input-group-addon">mg</span>
							<asp:TextBox ID="txtvd1" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
						</div>
					</div>

					<div class="form-group">
						<label for="txtcalcium1" class="control-label">
							<asp:Label ID="label_txtcalcium1" runat="server" />
						</label>
						<div class="input-group">
							<span class="input-group-addon">mg</span>
							<asp:TextBox ID="txtcalcium1" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
						</div>
					</div>

					<div class="form-group">
						<label for="txtiron1" class="control-label">
							<asp:Label ID="label_txtiron1" runat="server" />
						</label>
						<div class="input-group">
							<span class="input-group-addon">mg</span>
							<asp:TextBox ID="txtiron1" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
						</div>
					</div>

					<div class="form-group">
						<label for="txtpotassium" class="control-label">
							<asp:Label ID="label_txtpotassium" runat="server" />
						</label>
						<div class="input-group">
							<span class="input-group-addon">mg</span>
							<asp:TextBox ID="txtpotassium" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
						</div>
					</div>

					<!-- buttons -->
					<div class="form-group">
						<hr />
						<asp:Button ID="button_calculate1" runat="server" CssClass="btn btn-success btn-lg btn-block" OnClick="Calculate1" />
						<asp:Button ID="button_reset1" runat="server" CssClass="btn btn-danger btn-lg btn-block" OnClick="Reset1" />
					</div>
				</div>
			</section>
		</section>
	</section>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript" src="/Scripts/Custom/manual_input.js"></script>
</asp:Content>