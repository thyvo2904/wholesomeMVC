<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/_layout.Master" AutoEventWireup="true" CodeBehind="manual_input.aspx.cs" Inherits="WholesomeMVC.manual_input1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    <asp:Literal ID="page_title" runat="server"></asp:Literal>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="style" runat="server">
    <link href="/Content/Custom/manual_input.css" rel="stylesheet" type="text/css" runat="server" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <section class="row text-center">
		<asp:Image ID="image_calculator" runat="server" />
		<h2><asp:Label ID="body_title" runat="server" /></h2>
		<h4><asp:Label ID="body_description" runat="server" /></h4>
		<hr />
    </section>

    <section class="row">
        <section class="col-lg-offset-2 col-lg-8">
            <asp:HiddenField ID="view_mode" runat="server" ClientIDMode="Static" />

			<!-- switch buttons for old/new view mode -->
            <ul class="nav nav-tabs">
                <li id="old_li"><a href="#" onclick="switchView()">Old</a></li>
                <li id="new_li"><a href="#" onclick="switchView()">New</a></li>
            </ul>

			<!-- old view mode -->
            <section id="old_view" class="form-horizontal">
				<!-- result -->
                <div class="form-group">
                    <label class="col-sm-2 control-label">
                        <asp:Label ID="label_score" runat="server" />
                    </label>

                    <p class="col-sm-10 form-control-static text-primary">
                        <strong><asp:Label ID="txtndex" runat="server" Text="0.0" /></strong>
                    </p>

                    <span class="col-sm-offset-2 col-sm-10 help-block">
                        <asp:Label ID="label_score_help" runat="server" />
                    </span>
                </div>

				<!-- basic info -->
				<hr />
                <div class="form-group">
                    <label for="txtKcal0" class="col-sm-2 control-label">
						<asp:Label ID="label_txtKcal0" runat="server" />
                    </label>
					<div class="col-sm-10">
						<asp:TextBox ID="txtKcal0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
					</div>
                </div>

                <div class="form-group">
                    <label for="txtKcal0" class="col-sm-2 control-label">
						<asp:Label ID="label_txtsatfat0" runat="server" />
                    </label>
					<div class="col-sm-10 input-group">
						<span class="input-group-addon">g</span>
						<asp:TextBox ID="txtsatfat0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
					</div>
                </div>

                <div class="form-group">
                    <label for="txtsodium0" class="col-sm-2 control-label">
						<asp:Label ID="label_txtsodium0" runat="server" />
                    </label>
					<div class="col-sm-10 input-group">
						<span class="input-group-addon">mg</span>
						<asp:TextBox ID="txtsodium0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
					</div>
                </div>

                <div class="form-group">
                    <label for="txtfiber0" class="col-sm-2 control-label">
						<asp:Label ID="label_txtfiber0" runat="server" />
                    </label>
					<div class="col-sm-10 input-group">
						<span class="input-group-addon">g</span>
						<asp:TextBox ID="txtfiber0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
					</div>
                </div>

                <div class="form-group">
                    <label for="txtsugar0" class="col-sm-2 control-label">
						<asp:Label ID="label_txtsugar0" runat="server" />
                    </label>
					<div class="col-sm-10 input-group">
						<span class="input-group-addon">g</span>
						<asp:TextBox ID="txtsugar0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
					</div>
                </div>

                <div class="form-group">
                    <label for="txtprotein0" class="col-sm-2 control-label">
						<asp:Label ID="label_txtprotein0" runat="server" />
                    </label>
					<div class="col-sm-10 input-group">
						<span class="input-group-addon">g</span>
						<asp:TextBox ID="txtprotein0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
					</div>
                </div>

				<!-- detail info -->
				<hr />
                <div class="form-group">
                    <label for="txtva0" class="col-sm-2 control-label">
						<asp:Label ID="label_txtva0" runat="server" />
                    </label>
					<div class="col-sm-10 input-group">
						<span class="input-group-addon">%</span>
						<asp:TextBox ID="txtva0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
					</div>
                </div>

                <div class="form-group">
                    <label for="txtvc0" class="col-sm-2 control-label">
						<asp:Label ID="label_txtvc0" runat="server" />
                    </label>
					<div class="col-sm-10 input-group">
						<span class="input-group-addon">%</span>
						<asp:TextBox ID="txtvc0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
					</div>
                </div>

                <div class="form-group">
                    <label for="txtcalcium0" class="col-sm-2 control-label">
						<asp:Label ID="label_txtcalcium0" runat="server" />
                    </label>
					<div class="col-sm-10 input-group">
						<span class="input-group-addon">%</span>
						<asp:TextBox ID="txtcalcium0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
					</div>
                </div>

                <div class="form-group">
                    <label for="txtiron0" class="col-sm-2 control-label">
						<asp:Label ID="label_txtiron0" runat="server" />
                    </label>
					<div class="col-sm-10 input-group">
						<span class="input-group-addon">%</span>
						<asp:TextBox ID="txtiron0" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
					</div>
                </div>
            </section>

            <section id="new_view">
                New View
            </section>
        </section>
    </section>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript" src="/Scripts/Custom/manual_input.js"></script>
</asp:Content>