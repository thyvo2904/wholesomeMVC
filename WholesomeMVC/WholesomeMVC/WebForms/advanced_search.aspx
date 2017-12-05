<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="advanced_search.aspx.cs" Inherits="WholesomeMVC.WebForms.advanced_search" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <title>Wholesome | Saved Items</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
  <link href="/css/advancesearch.css" rel="stylesheet" type="text/css" runat="server"/>
<style>
    
   
    
    #NBD{
        
       background-color: #0D8843; 
        color: #fff;
    }     

    #NBD2{
        
         background-color: #0D8843; 
        color: #fff;
        
    }
    
    #NBD3{
        
        background-color: #0D8843; 
        color: #fff;
    }    
   
    .jumbotron{
        
        background-color: #fff;

    }
    
    .searchbar{
        width: 360px;
        height: 35px;
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
            <li><a style="color:#0D8843; font-size:14px;" href="COMPARISON.aspx">COMPARISON</a></li>
        </ul>
                  
      <!--new section-->    
          
        <div class="input-group">
            <div class="input-group-btn search-panel">
       <asp:DropDownList ID="ddlCategory" runat="server" CssClass="btn btn-default dropdown-toggle" AppendDataBoundItems="true" OnSelectedIndexChanged="Page_Load" DataSourceID="Category" DataTextField="FdGrp_Desc" DataValueField="FdGrp_Desc">
         <asp:ListItem Selected="True">--Select Category--</asp:ListItem>

                
      </asp:DropDownList>
                </div>
            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"></asp:TextBox>
           <span class="input-group-btn">
         <button type="submit" class="btn btn-default" runat="server" id="btnSearch" onserverclick="btnSearch_Click" ><span class="glyphicon glyphicon-search"></span></button></span>
      
        
            </div>
    </div>
   
    
    
  <!--ADDED HTML FOR THE LOGIN DROPDOWN--> 
    
 <div class="container-fluid">
     <div class="col-sm-12">
     <div class="row">
    <div class="dropdown pull-right">  
      <button class="btn btn-default dropdown-toggle" type="button" id="userdropdown" data-toggle="dropdown" style="background-color: #0D8843; color: #fff;">Welcome  <span class="glyphicon glyphicon-user" style="color:#fff;"></span>
    <span class="caret"></span></button>
    <ul class="dropdown-menu" role="menu" aria-labelledby="userdropdown">
      <li role="presentation"><a role="menuitem" tabindex="-1" href="account_management.aspx">Account Management</a></li>
      <li role="presentation"><a role="menuitem" tabindex="-1" href="Settings.aspx">Settings</a></li>
      <li role="presentation"><a role="menuitem" tabindex="-1" href="advanced_search.aspx">Advance Search</a></li>
      <li role="presentation" class="divider"></li>
      <li role="presentation"><a role="menuitem" tabindex="-1" href="index.aspx">Log Out</a></li>
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
  
    
<div class="container-fluid">   
<div class="jumbotron">
  <h1 class="display-3">Advanced Search</h1>
  <p class="lead" style="color:#000000;">Fill out the options below for a more advanced search.</p>
  <hr class="my-4">
 
    <div class="row">
    <div class="col-md-4">   
        <div class="input-group">
        
      <div class="input-group-btn search-panel">
          
    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="btn btn-default dropdown-toggle" AppendDataBoundItems="True" OnSelectedIndexChanged="Page_Load" DataSourceID="Category" DataTextField="FdGrp_Desc" DataValueField="FdGrp_Desc">
        <asp:ListItem Selected="True">--Select Category--</asp:ListItem>
 
                
      </asp:DropDownList>
      
          <asp:SqlDataSource ID="Category" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [FdGrp_Desc] FROM [FD_GROUP]"></asp:SqlDataSource>
      
        
      </div>
            
            
      <input type="hidden" name="search_param" value="all" id="search_param">
      <input id="txtAdvSearch" runat="server" type="text" class="searchbar" aria-label="Text input with dropdown button">
    <span class="input-group-btn">
            
       <button class="btn btn-default" runat="server" id="btnAdvSearch" onserverclick="btnAdvSearch_Click" type="button"><span class="glyphicon glyphicon-search"></span></button>     </span>          
            
    </div>            
    </div>    
</div>
    
<br>
    
<div class="row">    
 <div class="col-md-4">   
<h3>Data Source:</h3>
    
    <div class="checkbox" id="radiobutton1">
  <label><input id ="cbxAPI" type="checkbox" runat ="server">API</label>
</div>
<div class="checkbox" id="radiobutton2">
  <label><input id="cbxCeres" type="checkbox" runat="server">Ceres Database</label>
</div>
    </div>
<div class="col-md-4">    
    <h3>Sort By:</h3>
    <div class="checkbox" id="radiobutton1">
  <label><input id="cbxFoodname" type="checkbox" runat="server">Food Name</label>
</div>
<div class="checkbox" id="radiobutton2">
  <label><input id ="cbxRelevance" type="checkbox" runat="server">Relevance</label>
</div>    
    </div> 
    
    
<div class="col-md-4">
 <h3>Report Type:</h3>   
      <div class="checkbox" id="radiobutton1">
  <label><input id ="cbxStandard" type="checkbox" runat="server">Standard Reference</label>
</div> 
<div class="checkbox" id="radiobutton2">
  <label><input id ="cbxBranded" type="checkbox" runat="server">Branded Reference</label>
</div>     
    
    </div>  
    
    </div>

  </div>
    
    
</div>    
    
    
    
    <br><br>  <br><br> <br><br>
     
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

      
    
    
    </form>
</body>
</html>
