<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/_layout.Master" AutoEventWireup="true" CodeBehind="inventory_admin.aspx.cs" Inherits="WholesomeMVC.WebForms.inventory_admin" %>

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
			<div>
                <div class='tableauPlaceholder' id='viz1512711035664' style='position: relative'>
                    <noscript><a href='#'>
                        <img alt='Story 1 ' src='https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;De&#47;Dec7_0&#47;Story1&#47;1_rss.png' style='border: none' /></a></noscript>
                    <object class='tableauViz' style='display: none;'>
                        <param name='host_url' value='https%3A%2F%2Fpublic.tableau.com%2F' />
                        <param name='embed_code_version' value='3' />
                        <param name='site_root' value='' />
                        <param name='name' value='Dec7_0&#47;Story1' />
                        <param name='tabs' value='no' />
                        <param name='toolbar' value='yes' />
                        <param name='static_image' value='https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;De&#47;Dec7_0&#47;Story1&#47;1.png' />
                        <param name='animate_transition' value='yes' />
                        <param name='display_static_image' value='yes' />
                        <param name='display_spinner' value='yes' />
                        <param name='display_overlay' value='yes' />
                        <param name='display_count' value='yes' />
                        <param name='filter' value='publish=yes' />
                        <param name ='refresh' value='yes' />
                    </object>
                </div>
                <script type='text/javascript'>      
                    var divElement = document.getElementById('viz1512711035664');
                    var vizElement = divElement.getElementsByTagName('object')[0];
                    vizElement.style.width = '100%';
                    //vizElement.style.height = (divElement.offsetWidth * 0.75) + 'px';
                    vizElement.style.height = '1000px';
                    var scriptElement = document.createElement('script');
                    scriptElement.src = 'https://public.tableau.com/javascripts/api/viz_v1.js';
                    vizElement.parentNode.insertBefore(scriptElement, vizElement);     

					var container = document.getElementById('viz-client-container');
					container.style.width = '100%';
					container.style.height = '100%';
                </script>
			</div>
           

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
								</td>
							</tr>
							<tr>
								<th>Quantity (lbs)</th>
								<td>
									<asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
								</td>
							</tr>
						</tbody>
					</table>
					<div class="text-right">
						<asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-default btn-lg" OnClick="btnReset_Click" />
						<asp:Button ID="btnWhatif" runat="server" OnClick="btnWhatif_Click" Text="What If" CssClass="btn btn-primary btn-lg" />
					</div>
				</div>
			</div>
		</section>
	
</asp:Content>

<asp:Content ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript" src="/Scripts/Custom/jquery.matchHeight-min.js"></script>
    <script type="text/javascript" src="/Scripts/Custom/inventory_admin.js"></script>
</asp:Content>