<%@ Page Language="C#" AutoEventWireup="True" Inherits="Wholesome.inventory_staff" Codebehind="inventory_staff.aspx.cs" %>

<!doctype html>
<html>
<head>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>Wholesome | Inventory-Staff</title>

<link href="css/bootstrap.css" rel="stylesheet" type="text/css" media="screen">
<link href="css/custom.css" rel="stylesheet" type="text/css" media="screen">
<meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style>
    
     @import url('https://fonts.googleapis.com/css?family=Nunito');
      
      
     body{
         
         font-family: 'Nunito', sans-serif;
     }     
     
     .btn{
         
         background-color: #0D8843;
          color:#fff;
         outline-color: #0D8843;
        
     } 
     
     
     .navbar{
         
         background-color: #fff;
         padding-top: 15px;
     }     
     
     
     .navbar-header{
         
         margin-bottom: 35px;
         margin-left: 10px;
        
     }
     
        .navbar-default{
        padding-top: 25px; 
        margin-bottom: 0; 
         
     }   
     
 
     
     .input-group{
        padding-top: 9px;  
         
     } 
         
        /*end nav bar css*/

     
      
      .dropdown-item{
          
          color:#0D8843;
          text-align: center;
         
      }        
             
        
          .banner{
          
          background-image: url("https://farm5.staticflickr.com/4586/38145589272_f83f3fee78_o.png");
          color:#fff;
          padding-top: 20px;
      }  
      
      
      .btn{
        
          background-color: #0D8843;
          color:#fff;
      }
      
        
        
        .container{
            
            font-family: 'Nunito', sans-serif;
        }    
    
        .thumbnail{
            
            color: #fff;
            border: .5px solid;
            border-color: #000000;
            background-color:#0D8843;
        }    
        
        .modal-content{
            
            font-family: 'Nunito', sans-serif;
            color:#000000;
        }
        
        
        #sidebar{
            
            position:fixed;
            width:200px;
            height:100%;
            background-color:#0D8843;
         
        }    
        
        #sidebar ul li{
        color:#fff;
            list-style:none;
            padding:15px 10px;
            border-bottom: 1px solid rgba(100, 100, 100, 0.3);
            
        }

        @media screen and (max-width: 767px) {
            .sidenav {
                height: auto;
                padding: 15px;
            }
        }
        
          .vertical-menu {
                width: 220px; /* Set a width if you like */
                padding: 30px;
            }

                .vertical-menu a {
                    background-color: #eee; /* Grey background color */
                    color: black; /* Black text color */
                    display: block; /* Make the links appear below each other */
                    padding: 12px; /* Add some padding */
                    text-decoration: none; /* Remove underline from links */
                }

                    .vertical-menu a:hover {
                        background-color: #72C277; /* Dark grey background on mouse-over */
                    }

                    .vertical-menu a.active {
                        background-color: #0D8843; /* Add a green color to the "active/current" link */
                        color: white;
                    }

            .menu {
                font-family: 'Nunito', sans-serif;
            }
        
 
        
       
        .auto-style1 {
            width: 1264px;
            height: 496px;
            position: absolute;
            top: 412px;
            left: 11px;
            z-index: 1;
        }
        .auto-style2 {
            width: 786px;
            height: 420px;
            position: absolute;
            top: 6px;
            left: -16px;
            z-index: 1;
        }
        .auto-style3 {
            position: absolute;
            top: 63px;
            left: 44px;
            z-index: 1;
        }
        .auto-style4 {
            position: absolute;
            top: 111px;
            left: 83px;
            z-index: 1;
        }
        .auto-style5 {
            position: absolute;
            top: 161px;
            left: 83px;
            z-index: 1;
        }
        .auto-style6 {
            position: absolute;
            top: 111px;
            left: 222px;
            z-index: 1;
        }
        .auto-style7 {
            position: absolute;
            top: 163px;
            left: 224px;
            z-index: 1;
        }
        .auto-style8 {
            position: absolute;
            top: 246px;
            left: 37px;
            z-index: 1;
        }
        .auto-style9 {
            position: absolute;
            top: 345px;
            left: 99px;
            z-index: 1;
        }
        .auto-style10 {
            position: absolute;
            top: 345px;
            left: 212px;
            z-index: 1;
            width: 367px;
        }
        .auto-style11 {
            position: absolute;
            top: 239px;
            left: 112px;
            z-index: 1;
        }
        .auto-style12 {
            position: absolute;
            top: 62px;
            left: 539px;
            z-index: 1;
            width: 172px;
        }
        .auto-style13 {
            position: absolute;
            top: 69px;
            left: 444px;
            z-index: 1;
        }
        .auto-style14 {
            position: absolute;
            top: 121px;
            left: 456px;
            z-index: 1;
        }
        .auto-style15 {
            position: absolute;
            top: 190px;
            left: 501px;
            z-index: 1;
        }
        .auto-style16 {
            position: absolute;
            top: 150px;
            left: 495px;
            z-index: 1;
        }
        .auto-style17 {
            position: absolute;
            top: 149px;
            left: 583px;
            z-index: 1;
        }
        .auto-style18 {
            position: absolute;
            top: 193px;
            left: 583px;
            z-index: 1;
        }
        .auto-style19 {
            position: absolute;
            top: 250px;
            left: 355px;
            z-index: 1;
        }
        .auto-style20 {
            position: absolute;
            top: 7px;
            left: 40px;
            z-index: 1;
        }
        .auto-style21 {
            position: absolute;
            top: 248px;
            left: 583px;
            z-index: 1;
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
            <li><a style="color:#0D8843; font-size:14px;" href="nutrition_calculator.aspx">NUTRIENT CALCULATOR</a></li>
            <li><a style="color:#0D8843; font-size:14px;" href="recent.aspx">RECENT</a></li>
            <li><a style="color:#0D8843; font-size:14px;" href="saved_items.aspx">SAVED ITEMS</a></li>
        </ul>
        
        
        
                <!--new section-->    
          
        <div class="input-group">
            <div class="input-group-btn search-panel">
       <asp:DropDownList ID="ddlCategory" runat="server" CssClass="btn btn-default dropdown-toggle" AppendDataBoundItems="true" OnSelectedIndexChanged="Page_Load">
 
                
      </asp:DropDownList>
                </div>
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
  <a href="#" class="active">Current Inventory</a>
  <a href="#">History</a>
  <a href="#">Create Report</a>

</div>    
   </div>    
     </div>
    
<br> 
<!-- begin modal window gallery -->
<div class="container">
  <div class="row">
    <h1>&nbsp;</h1>
      <br>
   
        

        
    </div>
   
  </div>
    
         

         <br><br><br><br>
         <asp:Panel ID="Panel1" runat="server" CssClass="auto-style1">
             <div class="auto-style2">
                 <asp:Label ID="Label1" runat="server" CssClass="auto-style3" Text="Data Source:"></asp:Label>
                 <input id="Text2" class="auto-style11" type="text" />
                 <select id="Select1" class="auto-style12" name="D1">
                     <option></option>
                 </select><asp:Label ID="Label11" runat="server" CssClass="auto-style20" Text="Advanced Search"></asp:Label>
             </div>
             <asp:Label ID="Label2" runat="server" CssClass="auto-style4" Text="Standard Reference:"></asp:Label>
             <asp:Label ID="Label3" runat="server" CssClass="auto-style5" Text="Branded Reference:"></asp:Label>
             <asp:CheckBox ID="CheckBox1" runat="server" CssClass="auto-style6" />
             <asp:CheckBox ID="CheckBox2" runat="server" CssClass="auto-style7" />
             <asp:Label ID="Label4" runat="server" CssClass="auto-style8" Text="NDB No:"></asp:Label>
             <asp:Label ID="Label5" runat="server" CssClass="auto-style9" Text="Search Terms:"></asp:Label>
             <input id="Text1" class="auto-style10" type="text" />
             <asp:Label ID="Label6" runat="server" CssClass="auto-style13" Text="Category:"></asp:Label>
             <asp:Label ID="Label7" runat="server" CssClass="auto-style14" Text="Sort By:"></asp:Label>
             <asp:Label ID="Label8" runat="server" CssClass="auto-style15" Text="Relevance:"></asp:Label>
             <asp:Label ID="Label9" runat="server" CssClass="auto-style16" Text="Food Name:"></asp:Label>
             <asp:CheckBox ID="CheckBox3" runat="server" CssClass="auto-style17" />
             <asp:CheckBox ID="CheckBox4" runat="server" CssClass="auto-style18" />
             <asp:Label ID="Label10" runat="server" CssClass="auto-style19" Text="How many results would you like?"></asp:Label>
             <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style21"></asp:TextBox>
         </asp:Panel>
         <br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>    
         

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
</body>
</html>


