<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/WebForms/_layout.Master" CodeBehind="Update_Item.aspx.cs" Inherits="WholesomeMVC.WebForms.Update_Item" %>



<%--<html>
<head>
<meta charset="UTF-8">
<meta name="viewport" 

    content="initial-scale=1.0, maximum-scale=1.0, user-scalable=no, width=device-width">
<title>Wholesome | Update Item</title>

<link href="css/bootstrap.css" rel="stylesheet" type="text/css" media="screen">
<link href="css/custom.css" rel="stylesheet" type="text/css" media="screen">
 <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>--%>

   
      
         
        
         
<%--<div  class="col-md-2"> 

<div class="container-fluid menu">       
<div class="vertical-menu">
  <a href="Add_Item.aspx">Add Item</a>
  <a href="Update_Item.aspx" class="active" >Update Item</a>
  <a href="Sync_Database.aspx">Sync Database</a>
  <a href="Inventory_admin.aspx">Main Menu</a>
  

</div>    
   </div>
    

     </div>--%>

         
    <asp:Content ContentPlaceHolderID="body" runat="server">
<br> 
  <div class="wrapper">
     <div id="divitem" ClientIDMode="static" runat="server">
        <%--<asp:Label ID="Label10" runat="server" Text="Method of Nutrition Entry:"></asp:Label>
               <asp:DropDownList ID="ddlMethod" AutoPostBack = "true" OnSelectedIndexChanged = "OnSelectedIndexChanged" runat="server">
               <asp:ListItem>-Choose-</asp:ListItem>
               <asp:ListItem>Closest USDA Match</asp:ListItem>
               <asp:ListItem>Manual Input</asp:ListItem>
        </asp:DropDownList>--%>
  
  
    <td>Matched Items </td>
    <%--<td><asp:TextBox ID="txtNumber" runat="server"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="txtNumber" ID="chkItemNumber" runat="server" ValidationGroup="UpdateItem" ErrorMessage="(Required)"></asp:RequiredFieldValidator></td>
  </tr>--%>
  <%--<select id="ddlMatchedCeresID" runat="server" name="Matched Ceres ID's">--%>
         <asp:GridView ID="gridMatchedCeresIDS" runat="server" ClientIDMode="static" CssClass="footable" Style="max-width: 500px" OnSelectedIndexChanged="gridMatchedCeresIDS_SelectedIndexChanged" OnRowDataBound="ceresMatchedOnRowDataBound" AutoGenerateColumns="False" RowStyle-Wrap="false">
             <Columns>
             <asp:BoundField DataField ="CeresID" HeaderText ="CeresID"/>
             <asp:BoundField DataField ="Ceres_Name" HeaderText ="Ceres_Name"/>
             <asp:BoundField DataField ="USDA Number" HeaderText ="NDBno"/>
             <asp:BoundField DataField ="Name" HeaderText ="Name"/>
             <asp:BoundField DataField ="ND score" HeaderText ="ND Score" />
          <asp:commandfield showselectbutton="true" selectText ="Update"/>
         </Columns>
                     </asp:GridView>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
  <%--</select>--%>
      
  <tr>
    <td></td>
    
  </tr>
 

        </div>
                     
      
  <div id="divmanual" runat="server" ClientIDMode="static" visible="true">
     <select id="DropDownList2" runat="server" name="form_select" onchange="showDiv(this)" >
        <option value="0">Manual: Old Label</option>
        <option value="1">Manual: New Label</option>
         <option value="2">USDA</option>
     </select>

  <div id="divold" runat="server" ClientIDMode="static" style="display:none">
  <table>
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
  <asp:Label ID="lblOldResult" runat="server" Text=" "></asp:Label>
</div>

<div id="divnew" runat="server" ClientIDMode="static" style="display:none">
<table>
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
    <asp:Label ID="lblNewResult" runat="server" Text=" "></asp:Label>
</div>
      <div id="divgridview" ClientIDMode="static" runat="server" style="display:none">
          <td>Search a Similar Item:</td>
    <td><asp:TextBox ID="txtSearchDescription" runat="server"></asp:TextBox></td>
          <td><asp:Button ID="btnUpdateItem" runat="server" Text="Update Item" CssClass="btncss" OnClick="btnUpdateItem_Click" ValidationGroup="UpdateItem"/></td>
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

         </div>

         
         <br>
         <asp:Label ID="lblFBCategories" visible="false" runat="server" Text="Choose a Food Bank Category"></asp:Label>
         <br>
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

         <br>
         
         
         <br><br><br><br><br>
    

    

    <section runat="server" id="section" visible="true">
		<h3><asp:Literal ID="search_summary" runat="server" /></h3>
		<h4><asp:Literal ID="filter_applied" runat="server" /></h4>
		<div id="search_results" runat="server" class="row">
			<div class='col-sm-6 col-md-4 col-lg-3'>
				<div class='panel panel-default'>
					<div class='panel-body'>
						<h4 class='panel-title equal-height'>{1}
						</h4>
						<h4><strong>ND_Score: {2}</strong></h4>
						<button class='btn btn-success btn-block'>Expand</button>
					</div>
				</div>
			</div>
			<%--OnSelectedIndexChanged="gridSearchResults_SelectedIndexChanged"
			OnRowDataBound="OnRowDataBound"--%>
			<%--<asp:GridView
				ID="gridSearchResults"
				runat="server"
				AutoGenerateColumns="false"
				Width="660px"
				Visible="true"
				CssClass="myGridStyle"
				PagerStyle-CssClass="pgr"
				EmptyDataText="Please use the search bar to locate food items">
				<Columns>
					<asp:BoundField DataField="NDBno" HeaderText="NDBno" />
					<asp:BoundField DataField="Name" HeaderText="Item" />
					<asp:BoundField DataField="ND score" HeaderText="ND Score" />
					<asp:CommandField ShowSelectButton="True" SelectText="Expand" />
				</Columns>
				<EmptyDataRowStyle Font-Size="30px" />
				<PagerStyle CssClass="pgr"></PagerStyle>
			</asp:GridView>--%>
		</div>
	</section>

             </asp:Content>
    
     <asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
         <script type="text/javascript" src="/Scripts/Custom/Update_Item.js"></script>
         <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
         <script src="scripts/jquery.responsivetable.min.js"></script> 
    <script src="Fb_categories.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css"
    rel="stylesheet" type="text/css" />
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
<%--<script type="text/javascript">
    $(function () {
        $('[id*=gridMatchedCeresIDS]').footable();
    });
</script>--%>
    
  <link href="/css/additem.css" rel="stylesheet" type="text/css" runat="server"/>
    <link href="Fb_category.css" rel="stylesheet" type="text/css" runat="server"/>
    
  <style>

    ul.ui-autocomplete {
    list-style: none;
    list-style-type:none;
    padding: 0px;
    margin:0px;
    color: black;
    height: 200px; 
    overflow-y: scroll;
    overflow-x: hidden;

      }
              .wrapper{
            display: inline-block;
            /*width: 360px;*/
            height: 360px;
        }

        #divitem{
            float:left;
            margin-right:50px;
            margin-left: 80px;
        }

        #divmanual{
            float: right;
            margin-left: 50px;
        }

        #divgridview{
            text-align:center;
            margin-left: auto; margin-right: auto;
        }

        .btncss{
         background-color: #0D8843;
         color:#fff;
         outline-color: #0D8843;
         float: right;  
     }
        select#ddlMatchedCeresID {
   color: #fff;
   background-image: url(http://i62.tinypic.com/15xvbd5.png), -webkit-linear-gradient(#779126, #779126 40%, #779126);
   background-color: #779126;
   -webkit-border-radius: 20px;
   -moz-border-radius: 20px;
   border-radius: 20px;
   padding-left: 15px;
}
      
        
       
        </style>

<%--<script>
    $(document).ready(function (e) {
        $('.search-panel .dropdown-menu').find('a').click(function (e) {
            e.preventDefault();
            var param = $(this).attr("href").replace("#", "");
            var concept = $(this).text();
            $('.search-panel span#search_concept').text(concept);
            $('.input-group #search_param').val(param);
        });
    });
</script> --%>
<%--<script type="text/javascript">
    $(document).ready(function () {
        $("[id*=txtSearch]").autocomplete({ source: '<%=ResolveUrl("~/AutoComplete.ashx" ) %>' });
    }); 
</script>   --%> 

    <%--<script>
        function showDiv(elem) {
            if (elem.value == 0) {
                document.getElementById('divold').style.display = "block";
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
        </script>
    <script>
        $(document).ready(function () {

            // Custom settings
            $('.matchedCeresIDS').responsiveTable({
                staticColumns: 2,
                scrollRight: true,
                scrollHintEnabled: true,
                scrollHintDuration: 2000
            });
        });
    </script>--%>
    </asp:Content>

     
