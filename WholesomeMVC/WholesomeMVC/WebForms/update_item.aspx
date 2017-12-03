<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Update_Item.aspx.cs" Inherits="WholesomeMVC.WebForms.Update_Item" %>

<!DOCTYPE html>

<html>
<head>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>Wholesome | Update Item</title>

<link href="css/bootstrap.css" rel="stylesheet" type="text/css" media="screen">
<link href="css/custom.css" rel="stylesheet" type="text/css" media="screen">
 <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <link href="/css/additem.css" rel="stylesheet" type="text/css" runat="server"/>
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
      
        
       
        </style>

<script>
    $(document).ready(function (e) {
        $('.search-panel .dropdown-menu').find('a').click(function (e) {
            e.preventDefault();
            var param = $(this).attr("href").replace("#", "");
            var concept = $(this).text();
            $('.search-panel span#search_concept').text(concept);
            $('.input-group #search_param').val(param);
        });
    });
</script> 
<script type="text/javascript">
    $(document).ready(function () {
        $("[id*=txtSearch]").autocomplete({ source: '<%=ResolveUrl("~/AutoComplete.ashx" ) %>' });
    }); 
</script>    

    <script>
        function showDiv(elem) {
            if (elem.value == 0) {
                document.getElementById('divold').style.display = "block";
                document.getElementById('divnew').style.display = "none";
            } else if (elem.value == 1) {
                document.getElementById('divnew').style.display = "block";
                document.getElementById('divold').style.display = "none";
            } else {
                document.getElementById('divold').style.display = "block";
                document.getElementById('divnew').style.display = "none";
            }
        }
        </script>
</head>

<body>
    
     <form runat="server">   
    
<!--start nav bar-->      
     
<nav class="navbar navbar-default" role="navigation">
    <div class="navbar-header">
        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
        </button>
        <a class="navbar-brand" href="index.aspx">
            <img src="https://farm5.staticflickr.com/4468/38145590072_8dd45d4da2_o.png" height="75" width="120" alt="Wholesome Logo" class="img-responsive"></a>
    </div>
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
        <ul class="nav navbar-nav">
            <li><a style="color:#0D8843; font-size:14px;" href="manual_input.aspx">NUTRIENT CALCULATOR</a></li>
            <li><a style="color:#0D8843; font-size:14px;" href="recent.aspx">RECENT</a></li>
            <li><a style="color:#0D8843; font-size:14px;" href="saved_items.aspx">SAVED ITEMS</a></li>
        </ul>
        
        
        
        <!--new section-->    
          
        <div class="input-group">
            <div class="input-group-btn search-panel">
       <asp:DropDownList ID="ddlCategory" runat="server" CssClass="btn btn-default dropdown-toggle" AppendDataBoundItems="true" OnSelectedIndexChanged="Page_Load" DataSourceID="Category" DataTextField="FdGrp_Desc" DataValueField="FdGrp_Desc">
         <asp:ListItem Selected="True">--Select Category--</asp:ListItem>
 
                
      </asp:DropDownList>
                </div>
                      <asp:SqlDataSource ID="Category" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [FdGrp_Desc] FROM [FD_GROUP]"></asp:SqlDataSource>
            <asp:TextBox ID="txtSearch" runat="server" CssClass="sook form-control"></asp:TextBox>
           <span class="input-group-btn">
         <button type="submit" class="btn btn-default" runat="server" onserverclick="btnSearch" ><span class="glyphicon glyphicon-search"></span></button></span>
      
        
            </div>
    </div>

       <!--ADDED HTML FOR THE LOGIN DROPDOWN--> 
    
 <div class="container-fluid">
     <div class="col-sm-12">
     <div class="row">
    <div class="dropdown pull-right">  
      <button class="btn btn-default dropdown-toggle" type="button" id="userdropdown" data-toggle="dropdown" style="background-color: #0D8843; color: #fff;">Welcome,<asp:Label ID="lblName" runat="server" Text="name"></asp:Label>   <span class="glyphicon glyphicon-user" style="color:#fff;"></span>
    <span class="caret"></span></button>
    <ul class="dropdown-menu" role="menu" aria-labelledby="userdropdown">
      <li role="presentation"><a role="menuitem" tabindex="-1" href="account_management.aspx">Account Management</a></li>
      <li role="presentation"><a role="menuitem" tabindex="-1" href="Settings.aspx">Settings</a></li>
      <li role="presentation" class="divider"></li>
      <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Log Out</a></li>
    </ul>      
         </div>   
         
        
</div>
         </div>
</div>     
         
<!--END ADDED HTML FOR THE LOGIN DROPDOWN-->  
</nav>
  
 <!--end nav bar--> 
    
  
   


    <div class="container-fluid banner">    
  <div class="col-sm-8"> <!--start first container--> 
          

  
      
    </div> <!--end 1st container-->
            
        
  <div class="col-sm-4"> <!--start 2nd container-->
    <div class="row">  <!--start row-->
    <div class="text-center"> 
   <h3 >
    <span style="color: #fff;" class="glyphicon"></span>
 </h3>       
       </div> 
    </div> <!--end row-->
    </div> <!--end second container-->
 </div>  <!--end container-->
  <br>  
         
        
         
<div  class="col-md-2"> 

<div class="container-fluid menu">       
<div class="vertical-menu">
  <a href="Add_Item.aspx">Add Item</a>
  <a href="Update_Item.aspx" class="active" >Update Item</a>
  <a href="Sync_Database.aspx">Sync Database</a>
  <a href="Inventory_admin.aspx">Main Menu</a>
  

</div>    
   </div>
    

     </div>
    
<br> 
  <div class="wrapper">
     <div id="divitem">
        <asp:Label ID="Label10" runat="server" Text="Method of Nutrition Entry:"></asp:Label>
               <asp:DropDownList ID="ddlMethod" AutoPostBack = "true" OnSelectedIndexChanged = "OnSelectedIndexChanged" runat="server">
               <asp:ListItem>-Choose-</asp:ListItem>
               <asp:ListItem>Closest USDA Match</asp:ListItem>
               <asp:ListItem>Manual Input</asp:ListItem>
        </asp:DropDownList>
  <table class="item">
  <tr>
    <td>Item Number: </td>
    <td><asp:TextBox ID="txtNumber" runat="server"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="txtNumber" ID="chkItemNumber" runat="server" ValidationGroup="UpdateItem" ErrorMessage="(Required)"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td>CERES Description:</td>
    <td><asp:TextBox ID="txtDescription" runat="server"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="txtDescription" ValidationGroup="UpdateItem" ID="chkDescription" runat="server" ErrorMessage="(Required)"></asp:RequiredFieldValidator></td>
  </tr>
      <tr>
    <td>Search a Similar Item:</td>
    <td><asp:TextBox ID="txtSearchDescription" runat="server"></asp:TextBox></td>
  </tr>
  <tr>
    <td></td>
    <td><asp:Button ID="btnUpdateItem" runat="server" Text="Update Item" CssClass="btncss" OnClick="btnUpdateItem_Click" ValidationGroup="UpdateItem"/></td>
  </tr>
 
</table>
        </div>
                     
      
  <div id="divmanual" runat="server" visible="false">
     <select id="DropDownList2" name="form_select" onchange="showDiv(this)" >
        <option value="0">Old Label</option>
        <option value="1">New Label</option>
     </select>

  <div id="divold" runat="server" style="display:none">
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

<div id="divnew" runat="server" style="display:none">
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

  </div>

         </div>

         <div id="divgridview">
             <asp:GridView ID="gridUSDAChoices" runat="server" AutoGenerateColumns="false" onselectedindexchanged="gridSearchResults_SelectedIndexChanged" HorizontalAlign="Center">
             <Columns>
             <asp:BoundField DataField ="NDBno" HeaderText ="NDBno"/>
             <asp:BoundField DataField ="Name" HeaderText ="Name"/>
             <asp:BoundField DataField ="Food Group" HeaderText ="Food Group"/>
             <asp:BoundField DataField ="Protein" HeaderText ="Protein"/>
             <asp:BoundField DataField ="Fiber" HeaderText ="Fiber"/>
             <asp:BoundField DataField ="VitaminA" HeaderText ="VitaminA"/>
             <asp:BoundField DataField ="VitaminC" HeaderText ="VitaminC"/>
             <asp:BoundField DataField ="Iron" HeaderText ="Iron"/>
             <asp:BoundField DataField ="Calcium" HeaderText ="Calcium"/>
             <asp:BoundField DataField ="Sat_Fat" HeaderText ="Sat_Fat"/>
             <asp:BoundField DataField ="Total_Sugar" HeaderText ="Total_Sugar"/> 
             <asp:BoundField DataField ="Sodium" HeaderText ="Sodium"/>
             <asp:BoundField DataField ="KCal" HeaderText ="KCal"/>
             <asp:BoundField DataField ="ND score" HeaderText ="ND Score" />
          <asp:commandfield showselectbutton="True" selectText ="Select"/>
         </Columns>
                     </asp:GridView>
             </div>
      
         <br><br><br><br><br><br>
    

    </form>
    <!--start footer-->
     
<footer style="padding-top: 20px; position:relative; bottom:0; border-top:1px solid #fff; background-color: #0D8843;">
  <div class="container">
    <div class="row" style="padding-bottom:10px;">
    
            <div class="col-md-2">
                <div class="hidden-md hidden-lg">
              <h1 style="margin-top:0px; margin-bottom:15px; color: #fff; font-size: 20px; text-transform:uppercase; letter-spacing:2px;">Site Navigation</h1>   
                </div>
        <ul class="nav navbar-nav">
            <li><a style="color:#fff; font-size:14px;" href="manual_input.aspx">NUTRIENT CALCULATOR</a></li>
            <li><a style="color:#fff; font-size:14px;" href="recent.aspx">RECENT</a></li>
            <li><a style="color:#fff; font-size:14px;" href="saved_items.aspx">SAVED ITEMS</a></li>
        </ul>           
        </div> <!--end col 1-->     
        
      </div>
      
      
    <div class="row">   
  <div class="col-md-12 text-right">    
     <p style="color:#fff;">Copyright 2017 Wholesome Inc. All rights reserved.</p>   

      </div>
      </div> 
    </div>  
    
    </footer>
    
<!--end footer-->
</body>
</html>
