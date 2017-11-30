 <%@ Page Language="C#" AutoEventWireup="True" CodeBehind="signup.aspx.cs" Inherits="Wholesome.signup" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <title>Wholesome | Sign Up</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
  <link href="/css/signup.css" rel="stylesheet" type="text/css" runat="server"/>
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
    
    
        
    <div class="text-left">
    
    
        
 <form runat="server" type="submit">        
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
            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"></asp:TextBox>
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
   <h3 >
    <span style="color: #fff;" class="glyphicon "></span> 
 </h3>       
       </div> 
    </div> <!--end row-->
    </div> <!--end second container-->
 </div>  <!--end container-->
    
<br><br>
  
<div class="container">

<fieldset class="form-horizontal">

<!-- Form Name -->
<legend><center><h2><b>SIGN-UP</b></h2></center></legend>

<!-- Text input-->

<div class="form-group">
  <label class="col-md-4 control-label">First Name</label>  
  <div class="col-md-4 inputGroupContainer">
  <div class="input-group">
  <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
  <input type="text" id="txtFirstName" placeholder="First Name" class="form-control" runat="server">
    </div>
      <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtFirstName"
                runat="server" Display="Dynamic" />
  </div>
</div>

<!-- Text input-->

<div class="form-group">
  <label class="col-md-4 control-label" >Last Name</label> 
    <div class="col-md-4 inputGroupContainer">
    <div class="input-group">
  <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
  <input type="text" placeholder="Last Name" class="form-control" id="txtLastName"  runat="server">
    </div>
        <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtLastName"
                runat="server" Display="Dynamic" />
  </div>
  </div>
  
<!-- Text input-->

<div class="form-group">
  <label class="col-md-4 control-label">Username</label>  
  <div class="col-md-4 inputGroupContainer">
  <div class="input-group">
  <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
  <input type="text" id="txtUsername" placeholder="Username" class="form-control" runat="server">
    </div>
      <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtUsername"
                runat="server" Display="Dynamic" />
  </div>
</div>

<!-- Text input-->

<div class="form-group">
  <label class="col-md-4 control-label" >Password</label> 
    <div class="col-md-4 inputGroupContainer">
    <div class="input-group">
  <span class="input-group-addon"><i class="glyphicon glyphicon-asterisk"></i></span>
  <input type="password" id="txtPassword" placeholder="Password" class="form-control" runat="server">
    </div>
        <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtPassword"
                runat="server" Display="Dynamic" />
  </div>
</div>

<!-- Text input-->

<div class="form-group">
  <label class="col-md-4 control-label" >Confirm Password</label> 
    <div class="col-md-4 inputGroupContainer">
    <div class="input-group">
  <span class="input-group-addon"><i class="glyphicon glyphicon-asterisk"></i></span>
  <input type="password" id="txtConfirmPassword" placeholder="Confirm Password" class="form-control" runat="server">
    </div>
        <asp:CompareValidator ErrorMessage="Passwords do not match." ForeColor="Red" ControlToCompare="txtPassword"
                ControlToValidate="txtConfirmPassword" runat="server" Display="Dynamic" />
  </div>
</div>

<!-- Text input-->
       <div class="form-group">
  <label class="col-md-4 control-label">E-Mail</label>  
    <div class="col-md-4 inputGroupContainer">
    <div class="input-group">
        <span class="input-group-addon"><i class="glyphicon glyphicon-envelope"></i></span>
  <input type="text" id="txtEmail" placeholder="E-Mail Address" class="form-control" runat="server">
    </div>
        <asp:RequiredFieldValidator ErrorMessage="Required" Display="Dynamic" ForeColor="Red"
                ControlToValidate="txtEmail" runat="server" />
        <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Invalid email address." />
  </div>
</div>


<!-- Text input-->
       
<div class="form-group">
  <label class="col-md-4 control-label">Account Type</label>  
    <div class="col-md-4 inputGroupContainer">
    <div class="input-group">
        <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
  <select id="ddlaccount" name="D1" runat="server" class="form-control">
                 <option value="admin">Admin</option>
                 <option value="FBStaff">Food Bank Staff</option>
                 <option value="PurchaseStaff">Purchasing Staff</option>
                </select>
    </div>
        <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="ddlaccount"
                runat="server" />
  </div>
</div>

<!-- Button -->
<div class="form-group">
  <label class="col-md-4 control-label"></label>
  <div class="col-md-4"><br>
  <button id="btnSignup" onserverclick="RegisterUser" runat="server" type="submit" class="btn btn-secondary btnlogin">Submit Request</button>
  </div>
</div>

</fieldset>
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
    </div>
</body>
</html>
