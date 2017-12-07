<%@ Page Language="C#" MasterPageFile="~/WebForms/_layout.Master" AutoEventWireup="True" CodeBehind="system_settings.aspx.cs" Inherits="WholesomeMVC.WebForms.system_settings" %>

<asp:Content runat="server" ContentPlaceHolderID="style">
    <link href="/Content/Custom/system_settings.css" rel="stylesheet" type="text/css" runat="server" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="body">
	<section>
		<div class="row">
			<div class="col-sm-4 text-center">
				<div class="panel panel-default text-center banner-button">
					<asp:Image ID="image_algorithm" runat="server" />
					<asp:Button ID="button_algorithm" runat="server" CssClass="btn btn-success btn-lg btn-block" data-toggle="modal" data-target="#modal_algorithm" />
				</div>
			</div>

			<div class="col-sm-4 text-center">
				<div class="panel panel-default text-center banner-button">
					<asp:Image ID="image_tier" runat="server" />
					<asp:Button ID="button_tier" runat="server" CssClass="btn btn-success btn-lg btn-block" data-toggle="modal" data-target="#modal_tier" />
				</div>
			</div>

			<div class="col-sm-4 text-center">
				<div class="panel panel-default text-center banner-button">
					<asp:Image ID="image_color" runat="server" />
					<asp:Button ID="button_color" runat="server" CssClass="btn btn-success btn-lg btn-block" data-toggle="modal" data-target="#modal_color" />
				</div>
			</div>
		</div>
	</section>

	<!-- modals -->
	<section>
		<!-- for algorithm -->
		<div class="modal fade" id="modal_algorithm" role="dialog">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal">&times;</button>
						<h4 id="title_algorithm" runat="server" class="modal-title"></h4>
					</div>
					<div class="modal-body">
						<h4>Please select which food label you would like to use</h4>
						<div class="radio">
							<label>
								<input type="radio" name="optradio">
								Old Food Label
							</label>
						</div>
						<div class="radio">
							<label>
								<input type="radio" name="optradio">
								New Food Label
							</label>
						</div>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
						<button type="button" class="btn btn-success" data-dismiss="modal">Save Changes</button>
					</div>
				</div>
			</div>
		</div>

		<!-- for tier -->
		<div class="modal fade" id="modal_tier" role="dialog">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal">&times;</button>
						<h4 class="modal-title">Edit Index Tiers</h4>
					</div>
					<div class="modal-body">

						<img src="images/green.png" alt="color gradient" height="60" width="500" class="center-block">
						<label runat="server" class="checkbox-inline">
							<input type="text" id="lblNine" runat="server" value=">42.67"></label>
						<label runat="server" class="checkbox-inline">
							<input type="text" id="lblEight" runat="server" value=">35.33"></label>
						<label runat="server" class="checkbox-inline">
							<input type="text" id="lblSeven" runat="server" value=">28"></label>

						<img src="images/yellow.png" alt="color gradient" height="60" width="500" class="center-block">
						<label runat="server" class="checkbox-inline">
							<input type="text" id="lblSix" runat="server" value=">20.22"></label>
						<label runat="server" class="checkbox-inline">
							<input type="text" id="lblFive" runat="server" value=">12.44"></label>
						<label runat="server" class="checkbox-inline">
							<input type="text" id="lblFour" runat="server" value=">4.66"></label>

						<img src="images/red.png" alt="color gradient" height="60" width="500" class="center-block">
						<label runat="server" class="checkbox-inline">
							<input type="text" id="lblThree" runat="server" value=">2.33"></label>
						<label runat="server" class="checkbox-inline">
							<input type="text" id="lblTwo" runat="server" value="0"></label>
						<label runat="server" class="checkbox-inline">
							<input type="text" value="Negative" runat="server" id="lblOne"></label>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
						<button runat="server" onserverclick="btnSaveValues" class="btn btn-success" type="submit" data-dismiss="modal">Save Changes</button>
					</div>
				</div>
			</div>
		</div>

		<!-- for color -->
		<div class="modal fade" id="modal_color" role="dialog">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal">&times;</button>
						<h4 class="modal-title">Edit Color Gradient</h4>
					</div>

					<div class="modal-body">
						<div class="form-group row">
							<label for="example-color-input" class="col-2 col-form-label">Edit Shade of Green</label>
							<div class="col-10">
								<input class="form-control" type="color" value="#004700" id="color-input-green">
							</div>
						</div>
						<div class="form-group row">
							<label for="example-color-input" class="col-2 col-form-label">Edit Shade of Yellow</label>
							<div class="col-10">
								<input class="form-control" type="color" value="#F7E800" id="color-input-yellow">
							</div>
						</div>
						<div class="form-group row">
							<label for="example-color-input" class="col-2 col-form-label">Edit Shade of Red</label>
							<div class="col-10">
								<input class="form-control" type="color" value="#ED1C24" id="color-input-red">
							</div>
						</div>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
						<button type="button" class="btn btn-success" data-dismiss="modal">Save Changes</button>
					</div>
				</div>
			</div>
		</div>
	</section>
</asp:Content>