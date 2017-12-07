<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/_layout.Master" AutoEventWireup="true" CodeBehind="inventory_admin.aspx.cs" Inherits="WholesomeMVC.WebForms.inventory_admin" %>

<asp:Content ContentPlaceHolderID="style" runat="server">
    <link href="/Content/Custom/recent.css" rel="stylesheet" type="text/css" runat="server" />
    <style type="text/css">
        .auto-style2 {
            width: 270px;
        }
        .auto-style3 {
            width: 158px;
        }
        .auto-style4 {
            width: 158px;
            height: 67px;
        }
        .auto-style5 {
            width: 270px;
            height: 67px;
        }
        .auto-style6 {
            height: 67px;
        }
        .auto-style7 {
            width: 158px;
            height: 47px;
        }
        .auto-style8 {
            width: 270px;
            height: 47px;
        }
        .auto-style9 {
            height: 47px;
        }
    </style>
</asp:Content>

<asp:Content ContentPlaceHolderID="body" runat="server">
	<section id="content_header">
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
	</section>

		<section>
			<!-- chart #1 -->
			<h4><asp:Label ID="chart_1_header" runat="server" /></h4>
			<div>
                <div class='tableauPlaceholder' id='viz1512618751938' style='position: relative'>
                    <noscript><a href='#'>
                        <img alt='Dashboard 1 ' src='https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;De&#47;Dec6&#47;Dashboard1&#47;1_rss.png' style='border: none' /></a></noscript>
                    <object class='tableauViz' style='display: none;'>
                        <param name='host_url' value='https%3A%2F%2Fpublic.tableau.com%2F' />
                        <param name='embed_code_version' value='3' />
                        <param name='site_root' value='' />
                        <param name='name' value='Dec6&#47;Dashboard1' />
                        <param name='tabs' value='no' />
                        <param name='toolbar' value='no' />
                        <param name='static_image' value='https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;De&#47;Dec6&#47;Dashboard1&#47;1.png' />
                        <param name='animate_transition' value='yes' />
                        <param name='display_static_image' value='yes' />
                        <param name='display_spinner' value='yes' />
                        <param name='display_overlay' value='yes' />
                        <param name='display_count' value='yes' />
                        <param name='filter' value='publish=yes' />
                    </object>
                </div>
                <script type='text/javascript'>                    
                    var divElement = document.getElementById('viz1512618751938');
                    var vizElement = divElement.getElementsByTagName('object')[0];
                    vizElement.style.width = '100%';
                    vizElement.style.height = (divElement.offsetWidth * 0.75) + 'px';
                    var scriptElement = document.createElement('script');
                    scriptElement.src = 'https://public.tableau.com/javascripts/api/viz_v1.js';
                    vizElement.parentNode.insertBefore(scriptElement, vizElement);               

                </script>
			</div>
            <div>
                <table style="width: 50%;">
                    <tr>
                        <td class="auto-style4">Cere&#39;s Item:</td>
                        <td class="auto-style5">
                            <asp:DropDownList ID="ddlCereItem" runat="server" DataSourceID="SqlDataSource1" DataTextField="Description" DataValueField="Description" Height="27px">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Description] FROM [Wholesome_Item]"></asp:SqlDataSource>
                        </td>
                        <td class="auto-style6">
                            <asp:SqlDataSource ID="constr2" runat="server" ConnectionString="<%$ ConnectionStrings:constr2 %>" SelectCommand="SELECT [FBC_CODE] FROM [FB_FOOD] ORDER BY [FBC_CODE]"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7">Food Bank Food Group:</td>
                        <td class="auto-style8">
                            <asp:DropDownList ID="ddlFBGroup" runat="server" DataSourceID="constr2" DataTextField="FBC_CODE" DataValueField="FBC_CODE" Height="32px">
                                <asp:ListItem>BABY</asp:ListItem>
                                <asp:ListItem>BEVERAGE</asp:ListItem>
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="auto-style9"></td>
                    </tr>
                    <tr>
                        <td class="auto-style3">Quantity (lbs):</td>
                        <td class="auto-style2">
                            <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnWhatif" runat="server" OnClick="btnWhatif_Click" Text="What If" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">&nbsp;</td>
                        <td class="auto-style2">&nbsp;</td>
                        <td>
                            <asp:Button ID="btnReset" runat="server" Text="Reset" />
                        </td>
                    </tr>
                </table>
            </div>
			<!-- chart #2 -->
			<h4><asp:Label ID="chart_2_header" runat="server" /></h4>
			<div>

			</div>
		</section>
	</section>
</asp:Content>

<asp:Content ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript" src="/Scripts/Custom/jquery.matchHeight-min.js"></script>
    <script type="text/javascript" src="/Scripts/Custom/inventory_admin.js"></script>
</asp:Content>