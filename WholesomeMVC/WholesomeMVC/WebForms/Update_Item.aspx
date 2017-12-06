<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/WebForms/_layout.Master" CodeBehind="update_item.aspx.cs" Inherits="WholesomeMVC.WebForms.update_item" %>
         
<asp:Content ContentPlaceHolderID="style" runat="server">
	<link href="/Content/Vendor/footable.bootstrap.min.css" rel="stylesheet" type="text/css" />
	<link href="/Content/Custom/update_item.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ContentPlaceHolderID="body" runat="server">
  <div class="wrapper">
     <div id="divitem">
        <%--<asp:Label ID="Label10" runat="server" Text="Method of Nutrition Entry:"></asp:Label>
               <asp:DropDownList ID="ddlMethod" AutoPostBack = "true" OnSelectedIndexChanged = "OnSelectedIndexChanged" runat="server">
               <asp:ListItem>-Choose-</asp:ListItem>
               <asp:ListItem>Closest USDA Match</asp:ListItem>
               <asp:ListItem>Manual Input</asp:ListItem>
        </asp:DropDownList>--%>
  
  
		<%--<td><asp:TextBox ID="txtNumber" runat="server"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="txtNumber" ID="chkItemNumber" runat="server" ValidationGroup="UpdateItem" ErrorMessage="(Required)"></asp:RequiredFieldValidator></td> </tr>--%>
		<%--<select id="ddlMatchedCeresID" runat="server" name="Matched Ceres ID's">--%>
		<%--</select>--%>
		<%--<asp:GridView
			ID="gridMatchedCeresIDS" 
			runat="server" 
			CssClass="footable"
			Style="max-width: 500px"
			OnSelectedIndexChanged="gridMatchedCeresIDS_SelectedIndexChanged"
			OnRowDataBound="ceresMatchedOnRowDataBound"
			AutoGenerateColumns="False"
			RowStyle-Wrap="false">
			<Columns>
				<asp:BoundField DataField="CeresID" HeaderText="CeresID" />
				<asp:BoundField DataField="Ceres_Name" HeaderText="Ceres_Name" />
				<asp:BoundField DataField="USDA Number" HeaderText="NDBno" />
				<asp:BoundField DataField="Name" HeaderText="Name" />
				<asp:BoundField DataField="ND score" HeaderText="ND Score" />
				<asp:CommandField ShowSelectButton="true" SelectText="Update" />
			</Columns>
		</asp:GridView>
		 <asp:DropDownList  id="ddlChooseMethod" OnSelectedIndexChanged="ddlChooseMethod_SelectedIndexChanged" runat="server">
             <asp:ListItem>-Input Method-</asp:ListItem>
             <asp:ListItem>USDA</asp:ListItem>
             <asp:ListItem>Manual: Old Label</asp:ListItem>
             <asp:ListItem>Manual: New Label</asp:ListItem>
         </asp:DropDownList>
		 <asp:Label ID="lblUSDASearch" runat="server" Text="Search USDA"></asp:Label>
         <asp:TextBox ID="txtSearchUSDA" runat="server"></asp:TextBox>
         <asp:Button ID="btnSearchUSDA" runat="server" Text="Search" />

		<asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
         <asp:Label ID="lblOldProtein" runat="server" Text="Protein:"></asp:Label>
         <asp:TextBox ID="txtOldProtein" runat="server"></asp:TextBox>
         <asp:Label ID="lblOldFiber" runat="server" Text="Fiber:"></asp:Label>
         <asp:TextBox ID="txtOldFiber" runat="server"></asp:TextBox>
         <asp:Label ID="lblOldVitaminA" runat="server" Text="Vitamin A:"></asp:Label>
         <asp:TextBox ID="txtOldVitaminA" runat="server"></asp:TextBox>
         <asp:Label ID="lblOldVitaminC" runat="server" Text="Vitamin C:"></asp:Label>
         <asp:TextBox ID="txtOldVitaminC" runat="server"></asp:TextBox>
         <asp:Label ID="lblOldCalcium" runat="server" Text="Calcium:"></asp:Label>
         <asp:TextBox ID="txtOldCalcium" runat="server"></asp:TextBox>
         <asp:Label ID="lblOldIron" runat="server" Text="Iron:"></asp:Label>
         <asp:TextBox ID="txtOldIron" runat="server"></asp:TextBox>
         <asp:Label ID="lblOldSaturatedFat" runat="server" Text="Saturated Fat:"></asp:Label>
         <asp:TextBox ID="txtOldSaturatedFat" runat="server"></asp:TextBox>
         <asp:Label ID="lblOldTotalSugar" runat="server" Text="Total Sugar:"></asp:Label>
         <asp:TextBox ID="txtOldTotalSugar" runat="server"></asp:TextBox>
         <asp:Label ID="lblOldSodium" runat="server" Text="Sodium:"></asp:Label>
         <asp:TextBox ID="txtOldSodium" runat="server"></asp:TextBox>
         <asp:Label ID="lblOldKCal" runat="server" Text="KCal:"></asp:Label><asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
         <asp:TextBox ID="txtOldKCal" runat="server"></asp:TextBox>
         <asp:Button ID="btnCalculateOldNRF6" runat="server" Text="Calculate" />
         <asp:Label ID="lblOldNRF6" runat="server" Text="ND_Score"></asp:Label>
         <asp:Button ID="btnSaveOldItem" runat="server" Text="Save" />
         <br>

         <asp:Label ID="lblNewProtein" runat="server" Text="Protein:"></asp:Label>
         <asp:TextBox ID="txtNewProtein" runat="server"></asp:TextBox>
         <asp:Label ID="lblNewFiber" runat="server" Text="Fiber:"></asp:Label>
         <asp:TextBox ID="txtNewFiber" runat="server"></asp:TextBox>
         <asp:Label ID="lblNewVitaminD" runat="server" Text="Vitamin D:"></asp:Label>
         <asp:TextBox ID="txtNewVitaminD" runat="server"></asp:TextBox>
         <asp:Label ID="lblNewPotassium" runat="server" Text="Potassium:"></asp:Label>
         <asp:TextBox ID="txtNewPotassium" runat="server"></asp:TextBox>
         <asp:Label ID="lblNewCalcium" runat="server" Text="Calcium:"></asp:Label>
         <asp:TextBox ID="txtNewCalcium" runat="server"></asp:TextBox>
         <asp:Label ID="lblNewIron" runat="server" Text="Iron:"></asp:Label>
         <asp:TextBox ID="txtNewIron" runat="server"></asp:TextBox>
         <asp:Label ID="lblNewSaturatedFat" runat="server" Text="Saturated Fat:"></asp:Label>
         <asp:TextBox ID="txtNewSaturatedFat" runat="server"></asp:TextBox>
         <asp:Label ID="lblNewAddedSugar" runat="server" Text="Added Sugar:"></asp:Label>
         <asp:TextBox ID="txtNewAddedSugar" runat="server"></asp:TextBox>
         <asp:Label ID="lblNewSodium" runat="server" Text="Sodium:"></asp:Label>
         <asp:TextBox ID="txtNewSodium" runat="server"></asp:TextBox>
         <asp:Label ID="lblNewKCal" runat="server" Text="KCal:"></asp:Label>
         <asp:TextBox ID="txtNewKCal" runat="server"></asp:TextBox>
         <asp:Button ID="btnCalculateOldNDScore" runat="server" Text="Calculate" />
         <asp:Label ID="lblNewNRF6" runat="server" Text="ND_Score"></asp:Label>
         <asp:Button ID="btnSaveNewItem" runat="server" Text="Save" />
         
         <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
         <asp:Button ID="btnSearch" runat="server" Text="Search USDA" />
	</div>

                     
      
  <div id="divmanual" runat="server" visible="false">
     <select id="DropDownList2" runat="server" name="form_select" onchange="showDiv(this)" >
        <option value="0">Manual: Old Label</option>
        <option value="1">Manual: New Label</option>
         <option value="2">USDA</option>
     </select>

  <div id="divold" runat="server" style="display:none">
  <%--<table>
  <tr>
    <td>kCal: </td>
    <td><asp:TextBox ID="txtOldKCal" runat="server"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="txtOldKCal" ID="RequiredFieldValidator1" ValidationGroup="CalculateOld" runat="server" ErrorMessage="(Required)"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td>Saturated Fat:</td>
    <td><asp:TextBox ID="txtOldSatFat" runat="server"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="txtOldSatFat" ID="RequiredFieldValidator2" ValidationGroup="CalculateOld" runat="server" ErrorMessage="(Required)"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td>Sodium:</td>
    <td><asp:TextBox ID="txtOldSodium" runat="server"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="txtOldSodium" ID="RequiredFieldValidator3" runat="server" ValidationGroup="CalculateOld" ErrorMessage="(Required)"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td>Fiber:</td>
    <td><asp:TextBox ID="txtOldFiber" runat="server"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="txtOldFiber" ID="RequiredFieldValidator4" runat="server" ValidationGroup="CalculateOld" ErrorMessage="(Required)"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td>Total Sugar:</td>
    <td><asp:TextBox ID="txtOldTotalSugar" runat="server"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="txtOldTotalSugar" ID="RequiredFieldValidator5" runat="server" ValidationGroup="CalculateOld" ErrorMessage="(Required)"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td>Protein:</td>
    <td><asp:TextBox ID="txtOldProtein" runat="server"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="txtOldProtein" ID="RequiredFieldValidator6" ValidationGroup="CalculateOld" runat="server" ErrorMessage="(Required)"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td>Vitamin A|%:</td>
    <td><asp:TextBox ID="txtOldVA" runat="server"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="txtOldVA" ID="RequiredFieldValidator7" ValidationGroup="CalculateOld" runat="server" ErrorMessage="(Required)"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td>Vitamin C|%:</td>
    <td> <asp:TextBox ID="txtOldVC" runat="server"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="txtOldVC" ID="RequiredFieldValidator8" runat="server" ErrorMessage="(Required)" ValidationGroup="CalculateOld"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td>Calcium |%</td>
    <td><asp:TextBox ID="txtOldCalcium" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtOldCalcium" ErrorMessage="(Required)" ValidationGroup="CalculateOld"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td>Iron |%:</td>
    <td><asp:TextBox ID="txtOldIron" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtOldIron" runat="server" ErrorMessage="(Required)" ValidationGroup="CalculateOld"></asp:RequiredFieldValidator></td>
  </tr>
</table>
  <asp:Button ID="btnCalculateOld" runat="server" OnClick="btnCalculateOld_Click" Text="Calculate Index" CssClass="btncss" ValidationGroup="CalculateOld" />
  <asp:Button ID="btnOldSaveItem" runat="server" OnClick="btnOldSaveItem_Click" Text="Save Item" CssClass="btncss"/>
  <asp:Label ID="lblOldResult" runat="server" Text=" "></asp:Label>--%>
</div>

<div id="divnew" runat="server" style="display:none">
<%--<table>
  <tr>
    <td>kCal: </td>
    <td><asp:TextBox ID="txtNewKCal" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="(Required)" ValidationGroup ="CalcNew" ControlToValidate="txtNewKCal"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td>Saturated Fat:</td>
    <td><asp:TextBox ID="txtNewSatFat" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="(Required)" ControlToValidate="txtNewSatFat" ValidationGroup ="CalcNew"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td>Sodium:</td>
    <td><asp:TextBox ID="txtNewSodium" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="(Required)" ControlToValidate="txtNewSodium" ValidationGroup ="CalcNew"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td>Fiber:</td>
    <td><asp:TextBox ID="txtNewFiber" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="txtNewFiber" runat="server" ErrorMessage="(Required)" ValidationGroup ="CalcNew"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td>Added Sugar:</td>
    <td><asp:TextBox ID="txtNewAddedSugar" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator15" ControlToVallidate="txtNewAddedSugar" runat="server" ErrorMessage="(Required)" ValidationGroup ="CalcNew" ControlToValidate="txtNewAddedSugar"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td>Protein:</td>
    <td><asp:TextBox ID="txtNewProtein" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator16" ControlToValidate="txtNewProtein" runat="server" ErrorMessage="(Required)" ValidationGroup ="CalcNew"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td>Vitamin D:</td>
    <td><asp:TextBox ID="txtNewVD" runat="server"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="txtNewVD" ID="RequiredFieldValidator17" runat="server" ErrorMessage="(Required)" ValidationGroup ="CalcNew"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td>Potassium:</td>
    <td><asp:TextBox ID="txtNewPotassium" runat="server"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="txtNewPotassium" ID="RequiredFieldValidator18" runat="server" ErrorMessage="(Required)" ValidationGroup ="CalcNew"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td>Calcium:</td>
    <td><asp:TextBox ID="txtNewCalcium" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator19" ControlToValidate="txtNewCalcium" runat="server" ErrorMessage="(Required)" ValidationGroup ="CalcNew"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td>Iron:</td>
    <td><asp:TextBox ID="txtNewIron" runat="server"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="txtNewIron" ID="RequiredFieldValidator20" runat="server" ErrorMessage="(Required)" ValidationGroup ="CalcNew"></asp:RequiredFieldValidator></td>
  </tr>
</table>
    <asp:Button ID="btnCalculateNew" runat="server" ValidationGroup="CalcNew" OnClick="btnCalculateNew_Click" Text="Calculate Index" CssClass="btncss" />
  <asp:Button ID="btnNewSaveItem" runat="server" OnClick="btnNewSaveItem_Click" Text="Save Item" CssClass="btncss"/>
    <asp:Label ID="lblNewResult" runat="server" Text=" "></asp:Label>--%>
</div>

	  <div id="divgridview" style="display: none">
		  <h4>Search a Similar Item:</h4>
		  <div>
			  <asp:TextBox ID="txtSearchDescription" runat="server"></asp:TextBox>
		  </div>
		  <div>
			  <asp:Button ID="btnUpdateItem" runat="server" Text="Update Item" CssClass="btncss" OnClick="btnUpdateItem_Click" ValidationGroup="UpdateItem" />
		  </div>
		  <%--<asp:GridView ID="gridUSDAChoices" runat="server" OnRowDataBound="gridUSDAChoices_RowDataBound" AutoGenerateColumns="false" onselectedindexchanged="gridSearchResults_SelectedIndexChanged" HorizontalAlign="Center">
<Columns>
<asp:BoundField DataField ="NDBno" HeaderText ="NDBno"/>
<asp:BoundField DataField ="Name" HeaderText ="Name"/>
<asp:BoundField DataField ="Food Group" HeaderText ="Food Group"/>
<asp:BoundField DataField ="ND score" HeaderText ="ND Score" />
<asp:commandfield showselectbutton="True" selectText ="Select"/>
</Columns>
</asp:GridView>--%>
		  <%--<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">--%>

		  <%--</asp:Content>--%>
	  </div>
  </div>


	<div>
		<asp:Label ID="lblFBCategories" Visible="false" runat="server" Text="Choose a Food Bank Category"></asp:Label>
		<asp:DropDownList ID="ddlFBCategories" runat="server" Visible="False">
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
		<asp:Button ID="btnSelectFBCategory" runat="server" OnClick="btnSelectFBCategory_Click" Text="Select" Visible="False" />
	</div>


	<section runat="server" id="section" visible="true">
		<h3><asp:Literal ID="search_summary" runat="server" /></h3>

		<!-- Search items will show here -->
		<asp:GridView
			ID="gridMatchedCeresIDS" 
			runat="server" 
			CssClass="table table-bordered table-hover"
			OnRowDataBound="ceresMatchedOnRowDataBound"
			AutoGenerateColumns="False"
			ClientIDMode="Static"
			RowStyle-Wrap="false">
			<Columns>
				<asp:BoundField DataField="CeresID" HeaderText="CeresID" />
				<asp:BoundField DataField="Ceres_Name" HeaderText="Ceres_Name" />
				<asp:BoundField DataField="USDA Number" HeaderText="NDBno" />
				<asp:BoundField DataField="Name" HeaderText="Name" />
				<asp:BoundField DataField="ND score" HeaderText="ND Score" />
			</Columns>
		</asp:GridView>
		<asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
		<div id="search_results" runat="server" class="row"></div>

		<!-- Modal for expanded view -->
		<div class="modal fade" id="expanded_view" tabindex="-1" role="dialog" aria-labelledby="expanded view">
			<div class="modal-dialog modal-sm" role="document">
				<div class="modal-content">
					<asp:ScriptManager runat="server" EnablePartialRendering="true"></asp:ScriptManager>
					<asp:UpdatePanel runat="server">
						<ContentTemplate>
							<div class="modal-header">
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
											<td>
												<asp:Label ID="txtcalories" runat="server" /></td>
											<td></td>
										</tr>
										<tr class='fat'>
											<th>Saturated Fat</th>
											<td>
												<asp:Label ID="txtsatfat" runat="server" /></td>
											<td>g</td>
										</tr>
										<tr>
											<th>Sodium</th>
											<td>
												<asp:Label ID="txtsodium" runat="server" /></td>
											<td>g</td>
										</tr>
										<tr>
											<th>Dietary Fiber</th>
											<td>
												<asp:Label ID="txtfiber" runat="server" /></td>
											<td>g</td>
										</tr>
										<tr>
											<th>Total Sugars</th>
											<td>
												<asp:Label ID="txtsugar" runat="server" /></td>
											<td>g</td>
										</tr>
										<tr>
											<th>Protein</th>
											<td>
												<asp:Label ID="txtprotein" runat="server" /></td>
											<td>g</td>
										</tr>
										<tr class='fatter'>
											<th>Vitamin A</th>
											<td>
												<asp:Label ID="txtva" runat="server" /></td>
											<td>IU</td>
										</tr>
										<tr>
											<th>Vitamin C</th>
											<td>
												<asp:Label ID="txtvc" runat="server" /></td>
											<td>IU</td>
										</tr>
										<tr>
											<th>Calcium</th>
											<td>
												<asp:Label ID="txtcalcium" runat="server" /></td>
											<td>mg</td>
										</tr>
										<tr>
											<th>Iron</th>
											<td>
												<asp:Label ID="txtiron" runat="server" /></td>
											<td>mg</td>
										</tr>
									</tbody>
								</table>

								<hr />
								<div>
									<div class="form-group">
										<label for="txtCeresNumber">
											<asp:Label Text="Ceres Number" runat="server" /></label>
										<asp:TextBox ID="txtCeresNumber" CssClass="form-control" runat="server" placeholder="12345..."></asp:TextBox>
									</div>
									<div class="form-group">
										<label for="txtCeresDescription">
											<asp:Label Text="Ceres Description" runat="server" /></label>
										<asp:TextBox ID="txtCeresDescription" CssClass="form-control" runat="server" placeholder="Item description..."></asp:TextBox><br>
										<%--<button type="button" class="btn btn-sm btn-default" id="btnSaveItem" runat="server" onserverclick="btnSaveItem_Click"><span class="glyphicon glyphicon-floppy-saved"></span>Save</button></span>--%>
									</div>
								</div>
							</div>
							<div class="modal-footer">
								<asp:Button Text="Close" runat="server" CssClass="btn btn-default" data-dismiss="modal" type="button" />
								<%--<asp:Button Text="Compare Item" runat="server" CssClass="btn btn-success" OnClick="CompareItem" />--%>
							</div>
							<!-- hack to expand modal after postback -->
							<asp:HiddenField runat="server" ID="hidden_ceresid" ClientIDMode="Static"></asp:HiddenField>
							<asp:HiddenField runat="server" ID="hidden_ceres_name" ClientIDMode="Static"></asp:HiddenField>
							<asp:HiddenField runat="server" ID="hidden_ndbno" ClientIDMode="Static"></asp:HiddenField>
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
<%--	
	 <script src="Fb_categories.js"></script>

	 <link href="/css/additem.css" rel="stylesheet" type="text/css" runat="server" />
	 <link href="Fb_category.css" rel="stylesheet" type="text/css" runat="server" />

	 <script>
        function showDiv(elem) {
            if (elem.value == 0) {
                document.getElementById('document.getElementById("divold")').style.display = "block";
                document.getElementById('divnew').style.display = "none";
                document.getElementById('divgridview').style.display = "none";
            } else if (elem.value == 1) {
                document.getElementById('divnew').style.display = "block";
                document.getElementById('divold').style.display = "none";
                document.getElementById('divnew').style.display = "none";
            } else if (elem.value == 2) {
                document.getElementById('divnew').style.display = "none";
                document.getElementById('divold').style.display = "none";
                document.getElementById('divgridview').style.display = "block";

            } else {
                document.getElementById('divold').style.display = "block";
                document.getElementById('divnew').style.display = "none";
                document.getElementById('divgridview').style.display = "block";
            }
        }
	 </script>--%>
	
	<script type="text/javascript" src="/Scripts/Vendor/moment.min.js"></script>
	<script type="text/javascript" src="/Scripts/Vendor/footable.min.js"></script>
    <script type="text/javascript" src="/Scripts/Vendor/jquery.matchHeight-min.js"></script>
    <script type="text/javascript" src="/Scripts/Custom/update_item.js"></script>
 </asp:Content>


