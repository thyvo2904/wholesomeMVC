<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="system_settings.aspx.cs" Inherits="Wholesome.system_settings" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <title>Wholesome | System Settings</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
  <link href="/css/settings.css" rel="stylesheet" type="text/css" runat="server"/>
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
    <span style="color: #fff;" class="glyphicon"></span> 
 </h3>       
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
  <a href="system_settings.aspx" class="active">System Settings</a>
  <a href="account_management.aspx">Account Management</a>
</div>    
   </div>    
     </div>
   <div class="col-md-10 align-center">   

   <div class="container-fluid">            
  <table class="table table-hover">
    <thead>
      <tr>
     <h2>System Settings</h2>
    </thead>
    <tbody>
      <tr>
        <td><b>Algorithm Options</b></td>
        <td>Old Label</td> 
        <td><button type="button" class="btn btn" data-toggle="modal" data-target="#myModal">Edit</button>
    
    <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Edit Algorithm Options</h4>
        </div>
        <div class="modal-body">
          <p>Please select which food label you'd like to use.</p>
            
    <div class="radio">
  <label><input type="radio" name="optradio">Old Food Label</label>
</div>
<div class="radio">
  <label><input type="radio" name="optradio">New Food Label</label>
</div>
     <br>
            
    <button type="button" class="btn btn-outline-secondary" type="submit" data-dismiss="modal">Save Changes</button>
            
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>
      </tr>
      <tr>
        <td><b>Index Tiers</b></td>
        <td></td> <!--add index tiers-->
        <td><button type="button" class="btn btn" data-toggle="modal" data-target="#myModal2">Edit</button>
    
    <!-- Modal -->
  <div class="modal fade" id="myModal2" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Edit Index Tiers</h4>
        </div>
        <div class="modal-body">
        
  <img src="images/green.png" alt="color gradient" height="60" width="500" class="center-block">
            <br>
            
   
<label  runat="server" class="checkbox-inline"><input type="text" id="lblNine" runat="server" value=">42.67"></label>
  
<label  runat="server" class="checkbox-inline"><input type="text" id="lblEight" runat="server" value=">35.33"></label>
  
<label  runat="server" class="checkbox-inline"><input type="text" id="lblSeven" runat="server" value=">28"></label> 
    
<br>        
        <br>
            
      <img src="images/yellow.png" alt="color gradient" height="60" width="500" class="center-block">      
<br>
         
       
<label  runat="server" class="checkbox-inline"><input type="text" id="lblSix" runat="server" value=">20.22"></label>
     
<label  runat="server" class="checkbox-inline"><input type="text" id="lblFive" runat="server" value=">12.44"></label>

<label  runat="server" class="checkbox-inline"><input type="text" id="lblFour" runat="server" value=">4.66"></label>
  <br>
         
        <br>
            
         <img src="images/red.png" alt="color gradient" height="60" width="500" class="center-block">     
       
    <br>        

  
<label  runat="server" class="checkbox-inline"><input type="text" id="lblThree" runat="server" value=">2.33"></label>
  
<label  runat="server" class="checkbox-inline"><input type="text" id="lblTwo" runat="server" value="0"></label>
  
<label  runat="server" class="checkbox-inline"><input type="text" value="Negative" runat="server" id="lblOne"></label>    

                 
    <br><br>
            
 <button runat="server" onserverclick="btnSaveValues" class="btn btn-outline-secondary" type="submit" data-dismiss="modal">Save Changes</button>            
            
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>
      </tr>
      <tr>
        <td><b>Color Gradient</b></td>
        <td></td>
        <td><button type="button" class="btn btn" data-toggle="modal" data-target="#myModal3">Edit</button>
    <td></td> 
    <!-- Modal -->
  <div class="modal fade" id="myModal3" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Edit Color Gradient</h4>
        </div>
          
          
        <div class="modal-body">
         
    
    <div class="form-group row">
  <label for="example-color-input" class="col-2 col-form-label">Edit Shade of Green</label>
  <div class="col-10">
    <input class="form-control" type="color" value="#004700" id="color-input-green">
  </div>
</div>
             
    <br>
            
<div class="form-group row">
  <label for="example-color-input" class="col-2 col-form-label">Edit Shade of Yellow</label>
  <div class="col-10">
    <input class="form-control" type="color" value="#F7E800" id="color-input-yellow">
  </div>
</div>            
      
        <br>
            
<div class="form-group row">
  <label for="example-color-input" class="col-2 col-form-label">Edit Shade of Red</label>
  <div class="col-10">
    <input class="form-control" type="color" value="#ED1C24" id="color-input-red">
  </div>
</div>
            
<br>            
        </div>
        
        <br>
  <div class="container">      
 <button type="button" class="btn btn-outline-secondary" type="submit" data-dismiss="modal">Save Changes</button>
    </div>  
          <br>
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
        
      
        </form>
    
    
<!--start footer-->
     
<footer style="padding-top: 10px; position:relative; bottom:0; border-top:1px solid #fff; background-color: #0D8843;">
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
