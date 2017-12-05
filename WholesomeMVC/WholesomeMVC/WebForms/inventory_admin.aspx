<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/_layout.Master" AutoEventWireup="true" CodeBehind="inventory_admin.aspx.cs" Inherits="WholesomeMVC.WebForms.inventory_admin" %>

<asp:Content ContentPlaceHolderID="style" runat="server">
    <link href="/Content/Custom/recent.css" rel="stylesheet" type="text/css" runat="server" />
</asp:Content>

<asp:Content ContentPlaceHolderID="body" runat="server">
	<section id="content_header" class="row">
		<nav class="navbar navbar-inverse">
			<ul class="nav nav-pills">
				<li><a href="#" class="active">Current Inventory</a></li>
				<li><a href="Settings.aspx">Settings</a></li>
				<li><a href="account_management.aspx">Account Management</a></li>
				<li><a href="#">History</a></li>
				<li><a href="Item_Management.aspx">Item Management</a></li>
			</ul>
		</nav>

		<section>
			<!-- chart #1 -->
			<h4><asp:Label ID="chart_1_header" runat="server" /></h4>
			<div>
				<div class="tableauPlaceholder" id="viz1511793104500" style="position: relative">
					<noscript>
						<a href="#">
							<img alt="Dashboard 1 " src="https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;Bo&#47;Book1_26426&#47;Dashboard1&#47;1_rss.png" style="border: none" />
						</a>
					</noscript>
					<object class="tableauViz" style="display: none;">
						<param name="host_url" value="https%3A%2F%2Fpublic.tableau.com%2F" />
						<param name="embed_code_version" value="3" />
						<param name="site_root" value="" />
						<param name="name" value="Book1_26426&#47;Dashboard1" />
						<param name="tabs" value="no" />
						<param name="toolbar" value="yes" />
						<param name="static_image" value="https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;Bo&#47;Book1_26426&#47;Dashboard1&#47;1.png" />
						<param name="animate_transition" value="yes" />
						<param name="display_static_image" value="yes" />
						<param name="display_spinner" value="yes" />
						<param name="display_overlay" value="yes" />
						<param name="display_count" value="yes" />
						<param name="filter" value="publish=yes" />
					</object>
				</div>
				<script type="text/javascript">
					// set up tableu
					var divElement = document.getElementById('viz1511793104500');
					var vizElement = divElement.getElementsByTagName('object')[0];
					vizElement.style.width = "100%";
					vizElement.style.height = "900px";
					var scriptElement = document.createElement("script");
					scriptElement.src = "https://public.tableau.com/javascripts/api/viz_v1.js";
					vizElement.parentNode.insertBefore(scriptElement, vizElement);
				</script>
			</div>

			<!-- chart #2 -->
			<h4><asp:Label ID="chart_2_header" runat="server" /></h4>
			<div>
				<div class="tableauPlaceholder" id="viz1511793214964" style="position: relative">
					<noscript>
						<a href="#">
							<img alt="Inventory Timeline " src="https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;In&#47;InventoryTimeLine&#47;Sheet1&#47;1_rss.png" style="border: none;" />
						</a>
					</noscript>
					<object class="tableauViz" style="display: none;">
						<param name="host_url" value="https%3A%2F%2Fpublic.tableau.com%2F" />
						<param name="embed_code_version" value="3" />
						<param name="site_root" value="" />
						<param name="name" value="InventoryTimeLine&#47;Sheet1" />
						<param name="tabs" value="no" />
						<param name="toolbar" value="yes" />
						<param name="static_image" value="https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;In&#47;InventoryTimeLine&#47;Sheet1&#47;1.png" />
						<param name="animate_transition" value="yes" />
						<param name="display_static_image" value="yes" />
						<param name="display_spinner" value="yes" />
						<param name="display_overlay" value="yes" />
						<param name="display_count" value="yes" />
					</object>
				</div>
				<script type="text/javascript">
					// set up tableu
					var divElement = document.getElementById('viz1511793214964');
					var vizElement = divElement.getElementsByTagName('object')[0];

					vizElement.style.width = "100%";
					vizElement.style.height = (divElement.offsetWidth * 0.75) + 'px';

					var scriptElement = document.createElement("script");
					scriptElement.src = "https://public.tableau.com/javascripts/api/viz_v1.js";
					vizElement.parentNode.insertBefore(scriptElement, vizElement);
				</script>
			</div>
		</section>
	</section>
</asp:Content>

<asp:Content ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript" src="/Scripts/Custom/jquery.matchHeight-min.js"></script>
    <script type="text/javascript" src="/Scripts/Custom/inventory_admin.js"></script>
</asp:Content>