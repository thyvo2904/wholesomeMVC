<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="account_management.aspx.cs" Inherits="Wholesome.account_management" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <title>Wholesome | Account Management</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
  <link href="/css/layout.css" rel="stylesheet" type="text/css" runat="server"/>
  <style>
      
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
            <li><a style="color:#0D8843; font-size:14px;" href="saved_items.aspx">SAVED ITEMS</a></li>
        </ul>
        
        
        
        <!--new section-->    
          
        <div class="input-group">
            <div class="input-group-btn search-panel">
       <asp:DropDownList ID="ddlCategory" runat="server" CssClass="btn btn-default dropdown-toggle" AppendDataBoundItems="true" OnSelectedIndexChanged="Page_Load" DataSourceID="Category" DataTextField="FdGrp_Desc" DataValueField="FdGrp_Desc">
         <asp:ListItem Selected="True">--Select Category--</asp:ListItem>
 
                
      </asp:DropDownList>
                </div>
                      <asp:SqlDataSource ID="Category" runat="server" ConnectionString="<%$ ConnectionStrings:constr2 %>" SelectCommand="SELECT [FdGrp_Desc] FROM [FD_GROUP]"></asp:SqlDataSource>

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
      <button class="btn btn-default dropdown-toggle" type="button" id="userdropdown" data-toggle="dropdown" style="background-color: #0D8843; color: #fff;">Welcome  <span class="glyphicon glyphicon-user" style="color:#fff;"></span>
    <span class="caret"></span></button>
    <ul class="dropdown-menu" role="menu" aria-labelledby="userdropdown">
      <li role="presentation"><a role="menuitem" tabindex="-1" href="login.aspx">Log-In<span class="glyphicon glyphicon-log-in"></span></a></li>
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
   <h3>
    <span style="color: #fff;" class="glyphicon "></span> </h3>       
       </div> 
    </div> <!--end row-->
    </div> <!--end second container-->
 </div>  <!--end container-->

  
<br><br>
       
<br>

<div class="col-md-2"> 

<div class="container-fluid menu">       
<div class="vertical-menu">
  <a href="Settings.aspx">General Settings</a>
  <a href="system_settings.aspx">System Settings</a>
  <a href="account_management.aspx" class="active">Account Management</a>
</div>    
   </div>    
     </div>
   <div class="col-md-10 align-center">   

   <div class="container-fluid">            
  <table class="table table-hover">
    <thead>
      <tr>
     <h2>Account Management</h2>
    </thead>
    <tbody>
      <tr>
        <td><b>Create Accounts</b></td>
        <td><span style="color: #000000;" class="glyphicon glyphicon-plus-sign"></span></td> 
        <td><button type="button" class="btn btn" data-toggle="modal" data-target="#myModal2">Edit</button>
    
    <!-- Modal -->
  <div class="modal fade" id="myModal2" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Create New Account</h4>
        </div>
        <div class="modal-body">

   <form class="container" id="needs-validation" novalidate>
  <div class="row">
    <div class="col-md-6 mb-3">
      <label for="validationCustom01">First name</label>
      <input type="text" class="form-control" id="validationCustom1" placeholder="First name" value="" required>
    </div>
    <div class="col-md-6 mb-3">
      <label for="validationCustom02">Last name</label>
      <input type="text" class="form-control" id="validationCustom2" placeholder="Last name" value="" required>
    </div>
  </div>
  <div class="row">
    <div class="col-md-6 mb-3">
      <label for="validationCustom03">City</label>
      <input type="text" class="form-control" id="validationCustom3" placeholder="City" required>
      <div class="invalid-feedback">
        Please provide a valid city.
      </div>
    </div>
    <div class="col-md-3 mb-3">
      <label for="validationCustom04">State</label>
      <input type="text" class="form-control" id="validationCustom4" placeholder="State" required>
      <div class="invalid-feedback">
        Please provide a valid state.
      </div>
    </div>
    <div class="col-md-3 mb-3">
      <label for="validationCustom05">Zip</label>
      <input type="text" class="form-control" id="validationCustom5" placeholder="Zip" required>
      <div class="invalid-feedback">
        Please provide a valid zip.
      </div>
    </div>
  </div>
       <br>
<div class="row">
     <div class="col-md-6 mb-3">
      <label for="validationCustom06">Username</label>
      <input type="text" class="form-control" id="validationCustom6" placeholder="Username" value="" required>
    </div>
    <div class="col-md-6 mb-3">
      <label for="validationCustom07">Password</label>
      <input type="text" class="form-control" id="validationCustom7" placeholder="Password" value="" required>
    </div>      
       </div>  
       <br>
  <button class="btn btn-primary" type="submit">Submit form</button>
</form>

<script>
    // Example starter JavaScript for disabling form submissions if there are invalid fields
    (function () {
        'use strict';

        window.addEventListener('load', function () {
            var form = document.getElementById('needs-validation');
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            }, false);
        }, false);
    })();
</script>         
            
            
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>
      </tr>
        
     <tr>
        <td><b>Delete Accounts</b></td>
        <td><span style="color: #000000;" class="glyphicon glyphicon-trash"></span></td> <!--add parameters-->
        <td><button type="button" class="btn btn" data-toggle="modal" data-target="#myModal">Edit</button>
    
    <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Delete Existing Accounts</h4>
        </div>
        <div class="modal-body">
    
            
<form class="form-inline">
  <label class="mr-sm-2" for="inlineFormCustomSelect">Delete Account</label>
  <select class="custom-select mb-2 mr-sm-2 mb-sm-0" id="inlineFormCustomSelect">
    <option selected>Choose...</option>
    <option value="1">XXX</option>
    <option value="2">XXX</option>
    <option value="3">XXX</option>
  </select>

  <label class="custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0">
    <input type="checkbox" class="custom-control-input">
    <span class="custom-control-indicator"></span>
    <span class="custom-control-description">Remember my preference</span>
  </label>

  <button type="submit" class="btn btn-primary">Submit</button>
</form>   
            
            
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>
      </tr>    
 
    </tbody>
  </table>
</div>
  
        </div>
        
        
        

    
<br>    
      

  
<br>    
    

  
    
   <br> 
   
  
<br><br><br>  <br><br><br>
    
    
    
<br><br>    

<br><br>    <br><br><br><br>
        
   
    
    
<!--start footer-->
     
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

      
    
    
    </form>
    
</body>
</html>
