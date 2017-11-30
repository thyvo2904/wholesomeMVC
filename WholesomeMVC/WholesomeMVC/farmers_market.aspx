<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Farmers_Market.aspx.cs" Inherits="Wholesome.Farmers_Market" %>

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
      
      .aye{
          margin-left:5px;
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
        
       
        .auto-style1 {
            width: 100%;
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
    <asp:Label ID="lblFarmersMarket" runat="server" Text="Enter your zip code to search for a nearby farmers market!" Font-Bold="True" Font-Size="Medium"></asp:Label>     
    <br>
    <asp:TextBox ID="txtFarmersMarket" runat="server"></asp:TextBox>    
    <asp:Button ID="btnSearchFarmersMarket" runat="server" Text="Search" OnClick="btnSearchFarmersMarket_Click" />
    <asp:GridView ID="gridFarmersMarket" runat="server"  AutoGenerateColumns="false" onselectedindexchanged="gridFarmersMarket_SelectedIndexChanged">
        <Columns>
        <asp:BoundField DataField ="ID" HeaderText ="ID"/>
             <asp:BoundField DataField ="Market_Name" HeaderText ="Market_Name" />
          <asp:commandfield showselectbutton="True" selectText ="Select"/>
         </Columns>
    </asp:GridView> 

    <asp:Label ID="lblFarmersMarketLocation" runat="server" Text=""></asp:Label>
    <iframe runat="server" width="600"
  height="450"
  frameborder="0" style="border:0" id="farmersMarketIFrame"></iframe>


         <br>
         
   

    
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
    </form>
    
<!--end footer-->
</body>
</html>
