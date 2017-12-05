<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sync_Database.aspx.cs" Inherits="WholesomeMVC.WebForms.Sync_Database" %>

<!DOCTYPE html>

<html>
<head>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>Wholesome | Sync Database</title>

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
        
        .gvceres{
            margin: 0 auto;
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
            <li><a style="color:#0D8843; font-size:14px;" href="Comparison.aspx">COMPARISON</a></li>
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
      <li role="presentation"><a role="menuitem" tabindex="-1" href="advanced_search.aspx">Advance Search</a></li>
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
  <a href="Update_Item.aspx" >Update Item</a>
  <a href="Sync_Database.aspx" class="active">Sync Database</a>
  <a href="Inventory_admin.aspx">Main Menu</a>
  

</div>    
   </div>
    

     </div>
    
<br> 
        
        <div>
         <div class="container">
         <asp:Label ID="lblMatchedCeresIDS" runat="server" Text="Matched Ceres ID's"></asp:Label>
         <asp:GridView ID="gridMatchedCeresIDS" runat="server" OnRowDataBound="ceresMatchedOnRowDataBound" AutoGenerateColumns="false" onselectedindexchanged="gridMatchedCeresIDS_SelectedIndexChanged">
             <Columns>
             <asp:BoundField DataField ="CeresID" HeaderText ="CeresID"/>
             <asp:BoundField DataField ="Ceres_Name" HeaderText ="Ceres_Name"/>
             <asp:BoundField DataField ="NDBno" HeaderText ="NDBno"/>
             <asp:BoundField DataField ="Name" HeaderText ="Name"/>
             <%--<asp:BoundField DataField ="Protein" HeaderText ="Protein"/>
             <asp:BoundField DataField ="Fiber" HeaderText ="Fiber"/>
             <asp:BoundField DataField ="VitaminA" HeaderText ="VitaminA"/>
             <asp:BoundField DataField ="VitaminC" HeaderText ="VitaminC"/>
             <asp:BoundField DataField ="VitaminD" HeaderText ="VitaminD"/>
             <asp:BoundField DataField ="Potassium" HeaderText ="Potassium"/>
             <asp:BoundField DataField ="Iron" HeaderText ="Iron"/>
             <asp:BoundField DataField ="Calcium" HeaderText ="Calcium"/>
             <asp:BoundField DataField ="Sat_Fat" HeaderText ="Sat_Fat"/>
             <asp:BoundField DataField ="Total_Sugar" HeaderText ="Total_Sugar"/> 
             <asp:BoundField DataField ="Added_Sugar" HeaderText ="Added_Sugar"/>
             <asp:BoundField DataField ="Sodium" HeaderText ="Sodium"/>
             <asp:BoundField DataField ="KCal" HeaderText ="KCal"/>--%>
             <asp:BoundField DataField ="ND score" HeaderText ="ND Score" />
          <asp:commandfield showselectbutton="true" selectText ="Update"/>
         </Columns>
                     </asp:GridView>
         <asp:Button ID="btnSyncDatabase" runat="server" Text="Sync Database" OnClick="btnSyncDatabase_Click" CssClass="btn"/>
         <asp:Button ID="btnRetrieveArchivedValues" runat="server" CssClass="btn" OnClick="btnRetrieveArchivedValues_Click" Text="Retrieve Archived Values" />
             </div>
         <br><br>
         <div class="container">
         <asp:GridView ID="gridArchivedData" runat="server" AutoGenerateColumns="false" onselectedindexchanged="gridArchivedData_SelectedIndexChanged">
             <Columns>
             <asp:BoundField DataField ="CeresID" HeaderText ="CeresID"/>
             <asp:BoundField DataField ="Ceres_Name" HeaderText ="Ceres_Name"/>
             <asp:BoundField DataField ="NDBno" HeaderText ="NDBno"/>
             <asp:BoundField DataField ="Name" HeaderText ="Name"/>
             <%--<asp:BoundField DataField ="Protein" HeaderText ="Protein"/>
             <asp:BoundField DataField ="Fiber" HeaderText ="Fiber"/>
             <asp:BoundField DataField ="VitaminA" HeaderText ="VitaminA"/>
             <asp:BoundField DataField ="VitaminC" HeaderText ="VitaminC"/>
             <asp:BoundField DataField ="VitaminD" HeaderText ="VitaminD"/>
             <asp:BoundField DataField ="Potassium" HeaderText ="Potassium"/>
             <asp:BoundField DataField ="Iron" HeaderText ="Iron"/>
             <asp:BoundField DataField ="Calcium" HeaderText ="Calcium"/>
             <asp:BoundField DataField ="Sat_Fat" HeaderText ="Sat_Fat"/>
             <asp:BoundField DataField ="Total_Sugar" HeaderText ="Total_Sugar"/> 
             <asp:BoundField DataField ="Added_Sugar" HeaderText ="Added_Sugar"/>
             <asp:BoundField DataField ="Sodium" HeaderText ="Sodium"/>
             <asp:BoundField DataField ="KCal" HeaderText ="KCal"/>--%>
             <asp:BoundField DataField ="ND score" HeaderText ="ND Score" />
          <asp:commandfield showselectbutton="true" selectText ="Retrieve"/>
         </Columns>
                     </asp:GridView>
             <%--</div>
         <br><br>
         <div class="container">
         <asp:Label ID="lblUmatchedCeresIDS" runat="server" Text="Unmatched Ceres ID's"></asp:Label>
         <asp:GridView ID="gridUnmatchedCeresIDS" runat="server" onselectedindexchanged="gridunMatchedCeresIDS_SelectedIndexChanged" AutoGenerateColumns="false">
              <Columns>
             <asp:BoundField DataField ="CeresID" HeaderText ="CeresID"/>
             <asp:BoundField DataField ="Ceres_Name" HeaderText ="Ceres_Name"/>
          <asp:commandfield showselectbutton="true" selectText ="Select a Match"/>
         </Columns>
        </asp:GridView>
             </div>--%>
         <br><br>
         <%--<div class="container">
         <asp:Label ID="Label1" runat="server" Text="Unmatched Wholesome ID's"></asp:Label>
         <asp:GridView ID="gridUnmatchedTestDBIDS" runat="server" OnRowDataBound="unMatchedOnRowDataBound" AutoGenerateColumns="false" onselectedindexchanged="gridUnMatchedWholesomeIDS_SelectedIndexChanged">
             <Columns>
              <asp:BoundField DataField ="CeresID" HeaderText ="CeresID"/>
             <asp:BoundField DataField ="Ceres_Name" HeaderText ="Ceres_Name"/>
             <asp:BoundField DataField ="NDBno" HeaderText ="NDBno"/>
             <asp:BoundField DataField ="Name" HeaderText ="Name"/>
             <asp:BoundField DataField ="Protein" HeaderText ="Protein"/>
             <asp:BoundField DataField ="Fiber" HeaderText ="Fiber"/>
             <asp:BoundField DataField ="VitaminA" HeaderText ="VitaminA"/>
             <asp:BoundField DataField ="VitaminC" HeaderText ="VitaminC"/>
             <asp:BoundField DataField ="VitaminD" HeaderText ="VitaminD"/>
             <asp:BoundField DataField ="Potassium" HeaderText ="Potassium"/>
             <asp:BoundField DataField ="Iron" HeaderText ="Iron"/>
             <asp:BoundField DataField ="Calcium" HeaderText ="Calcium"/>
             <asp:BoundField DataField ="Sat_Fat" HeaderText ="Sat_Fat"/>
             <asp:BoundField DataField ="Total_Sugar" HeaderText ="Total_Sugar"/> 
             <asp:BoundField DataField ="Added_Sugar" HeaderText ="Added_Sugar"/>
             <asp:BoundField DataField ="Sodium" HeaderText ="Sodium"/>
             <asp:BoundField DataField ="KCal" HeaderText ="KCal"/>
             <asp:BoundField DataField ="ND score" HeaderText ="ND Score" />
             <asp:commandfield showselectbutton="true" selectText ="Update"/>
                 </Columns>
         </asp:GridView>
        </div>--%>
      </div>
         <br>
         
         



         
         

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
            <li><a style="color:#fff; font-size:14px;" href="Comparison.aspx">COMPARISON</a></li>
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

