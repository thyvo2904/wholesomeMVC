<%@ Page Language="C#" AutoEventWireup="True" Inherits="saved_items" Codebehind="saved_items.aspx.cs" EnableEventValidation="false"%>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <title>WHOLESOME | SAVED ITEMS</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
  <script src="https://unpkg.com/isotope-layout@3/dist/isotope.pkgd.min.js"></script>
  <link href="/css/saveitem.css" rel="stylesheet" type="text/css" runat="server"/>

<style>

    .comparison{   
        background-color: #72C277;
        padding-bottom: 30px;
        padding-top: 25px; 
        width: 80%;
    }
    
    #comparison1, #comparison2, #comparison3{
        
        background-color: #0D8843;
    }
         

.myGridStyle
        {
            border-collapse:collapse;
             
        }
         
        .myGridStyle tr th
        {
            padding: 8px;
            color: white;
            border: 1px solid black;
            height:5px;
        }
         
         
        .myGridStyle tr:nth-child(even)
        {
            background-color: lightblue;
        }
         
        .myGridStyle tr:nth-child(odd)
        {
            background-color: gray;
        }
         
        .myGridStyle td
        {
            border:1px solid black;
            padding: 8px;
        }
         
        .myGridStyle tr:last-child td
        {
        }

.sook{
    margin-top:20px;
    /*margin-left:50px;*/
    max-width:60%;
    /*float:left;*/
    /*overflow:scroll;*/
    text-align:center;
    margin-left: auto; margin-right: auto;
}

 .btnexport{
            background:none!important;
            border:none; 
            padding:0!important;
    
            /*optional*/
            font-family:'Nunito', sans-serif; /*input has OS specific font-family*/
            color:#069;
            text-decoration:underline;
            cursor:pointer;
            position:absolute;
            left:760px;

          }
 .btnexport2{
            background:none!important;
            border:none; 
            padding:0!important;
    
            /*optional*/
            font-family:'Nunito', sans-serif; /*input has OS specific font-family*/
            color:#069;
            text-decoration:underline;
            cursor:pointer;
            float: right;
            position: relative;
            top: 40px;
 }
 
    .tool{
        text-align: center;
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
   

    /*css for comparison table*/
   table {
    font-family: arial, sans-serif;
    border-collapse: collapse;
    width: 100%;
}

td, th {
    border: 1px solid #dddddd;
    text-align: left;
    padding: 8px;
}

tr:nth-child(even) {
    background-color: #dddddd;
}

tr:hover{
    background-color: #0D8843;
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
                <li><a style="color: #0D8843; font-size: 14px;" href="manual_input.aspx">NUTRIENT CALCULATOR</a></li>
                <li><a style="color: #0D8843; font-size: 14px;" href="recent.aspx">RECENT</a></li>
                <li><a style="color: #0D8843; font-size: 14px;" href="saved_items.aspx">SAVED ITEMS</a></li>
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
                    <button type="submit" class="btn btn-default" runat="server" onserverclick="btnSearch"><span class="glyphicon glyphicon-search"></span></button>
                </span>


            </div>
        </div>

        <!--ADDED HTML FOR THE LOGIN DROPDOWN-->

        <div class="container-fluid">
                <div>
                    <div class="dropdown pull-right">
                        <button class="btn btn-default dropdown-toggle" type="button" id="userdropdown" data-toggle="dropdown" style="background-color: #0D8843; color: #fff;">
                            Welcome  <span class="glyphicon glyphicon-user" style="color: #fff;"></span>
                            <span class="caret"></span>
                        </button>
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
        
   
         <br />
      <button runat="server" type="submit" class="btnexport" onserverclick="btnExport_Click">Export To Excel</button> 
        <div class ="sook">
            <div style="overflow-x: auto; width: 99%; height:85%;">
            <asp:GridView ID="GridView1" runat="server" 
               OnPageIndexChanging="GridView1_PageIndexChanging"
                AutoGenerateColumns="False" 
                DataKeyNames="NDB_No"
                DataSourceID="test"
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
                CssClass="table table-bordered table-condensed table-hover"
                PagerStyle-CssClass="pgr"
                OnRowDataBound = "OnRowDataBound">
     <Columns>
          <asp:CommandField ShowSelectButton="True" />
         <asp:BoundField DataField="NDB_No" HeaderText="NDB_No" SortExpression="NDB_No" ReadOnly="True" />
         <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
         <asp:BoundField DataField="ND_Score" HeaderText="ND_Score" SortExpression="ND_Score" />
         <asp:BoundField DataField="Ceres_Item_Number" HeaderText="Ceres_Item_Number" SortExpression="Ceres_Item_Number" />
         <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID" />
         <asp:BoundField DataField="LastUpdatedBy" HeaderText="LastUpdatedBy" SortExpression="LastUpdatedBy" />
         <asp:BoundField DataField="LastUpdated" HeaderText="LastUpdated" SortExpression="LastUpdated" />

     </Columns>
<HeaderStyle CssClass="header"></HeaderStyle>
     
<PagerStyle CssClass="pager"></PagerStyle>

<RowStyle CssClass="rows"></RowStyle>
 </asp:GridView>
                <asp:SqlDataSource ID="test" runat="server" ConnectionString="<%$ ConnectionStrings:test %>" SelectCommand="SELECT [NDB_No], [Name], [ND_Score], [Ceres_Item_Number], [UserID], [LastUpdatedBy], [LastUpdated] FROM [SavedItems]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="savedItems" runat="server"></asp:SqlDataSource>
              <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button3" runat="server" Text="Export" />
              &nbsp;<asp:Button ID="Button1" runat="server" Text="Edit Item" />
              &nbsp;<asp:Button ID="Button2" runat="server" Text="Delete Item" />
          </div>
              </div>

          
        &nbsp;<br />
         <br /><br /><br />

      
     
<asp:SqlDataSource ID="saved" runat="server" ConnectionString="<%mywholesomedb.cqar83yqn60f.us-west-2.rds.amazonaws.com;Initial Catalog=wholesomeDB;Persist Security Info=True;User ID=thyvo2904;Password=Cis484!!;Encrypt=False %>" SelectCommand="SELECT [NDB_No], [Name], [ND_Score], [UserID], [Ceres_Item_Number], [LastUpdatedBy], [LastUpdated] FROM [SavedItems]"></asp:SqlDataSource>
        
<div class="tool">
 <div class="container text-center">
    
 <h3>Nutrition Facts Comparison Tool</h3>   
    
 </div>   
<br>    
    
<div class="container comparison"> <!--start form-->
        
  <div class="input-group">
  <span class="input-group-addon" id="comparison1" style="color:#fff;">Food #1:</span>
  <input type="text" class="form-control" id="txtfood1" runat="server" readonly="readonly"  placeholder="Enter the first food" aria-label="Username" aria-describedby="comparison1">
</div>
<br>
<div class="input-group">
    <span class="input-group-addon" id="comparison2" style="color:#fff;">Food #2:</span>
  <input type="text" class="form-control" id="txtfood2" runat="server" readonly="readonly" placeholder="Enter a food" aria-label="Recipient's username" aria-describedby="comparison2">
</div> 
    <br>
 <div class="input-group">
<span class="input-group-addon" id="comparison3" style="color:#fff;">Food #3:</span>
  <input type="text" class="form-control" id="txtfood3" runat="server" readonly="readonly" placeholder="Enter a food" aria-label="Recipient's username" aria-describedby="comparison3">
</div>    
    <div style="text-align: center; margin-top:10px;">
     <button type="submit" id="btnCompare" runat="server" onserverclick="Compare" class="btn btn-primary btn-lg">Get Comparison</button> 
        <button runat="server" type="submit" class="btnexport2" onserverclick="btntable_Export">Export To Excel</button>
    </div>
</div>  <!--end form--> 
     

<br>    
<div class="container text-center">

    <br><br>
    
    <%--comparison table--%>
  <div class="comparetable">
  <table id="comparetable" runat="server" visible="false"> 
  <tr>
    <th>FoodNumber</th>
    <th>#1</th>
    <th>#2</th>
    <th>#3</th>
  </tr>
  <tr>
    <td>ND_Score</td>
    <td><asp:Label ID="lblNDScore1" runat="server" Text="Label"></asp:Label></td>
    <td><asp:Label ID="lblNDScore2" runat="server" Text="Label"></asp:Label></td>
    <td><asp:Label ID="lblNDScore3" runat="server" Text="Label"></asp:Label></td>
  </tr>
  <tr>
    <td>Calories</td>
    <td><asp:Label ID="lblCal1" runat="server" Text="Label"></asp:Label></td>
    <td><asp:Label ID="lblCal2" runat="server" Text="Label"></asp:Label></td>
    <td><asp:Label ID="lblCal3" runat="server" Text="Label"></asp:Label></td>
  </tr>
  <tr>
    <td>Saturated Fat|g</td>
    <td><asp:Label ID="lblFat1" runat="server" Text="Label"></asp:Label></td>
    <td><asp:Label ID="lblFat2" runat="server" Text="Label"></asp:Label></td>
    <td><asp:Label ID="lblFat3" runat="server" Text="Label"></asp:Label></td>
  </tr>
  <tr>
    <td>Sodium|mg</td>
    <td><asp:Label ID="lblSodium1" runat="server" Text="Label"></asp:Label></td>
    <td><asp:Label ID="lblSodium2" runat="server" Text="Label"></asp:Label></td>
    <td><asp:Label ID="lblSodium3" runat="server" Text="Label"></asp:Label></td>
  </tr>
  <tr>
    <td>Dietary Fiber|g</td>
    <td><asp:Label ID="lblFiber1" runat="server" Text="Label"></asp:Label></td>
    <td><asp:Label ID="lblFiber2" runat="server" Text="Label"></asp:Label></td>
    <td><asp:Label ID="lblFiber3" runat="server" Text="Label"></asp:Label></td>
  </tr>
  <tr>
    <td>Total Sugars|g</td>
    <td><asp:Label ID="lblSugar1" runat="server" Text="Label"></asp:Label></td>
    <td><asp:Label ID="lblSugar2" runat="server" Text="Label"></asp:Label></td>
    <td><asp:Label ID="lblSugar3" runat="server" Text="Label"></asp:Label></td>
  </tr>
  <tr>
    <td>Protein|g</td>
    <td><asp:Label ID="lblProtein1" runat="server" Text="Label"></asp:Label></td>
    <td><asp:Label ID="lblProtein2" runat="server" Text="Label"></asp:Label></td>
    <td><asp:Label ID="lblProtein3" runat="server" Text="Label"></asp:Label></td>
  </tr>
  <tr>
    <td>Vitamin A|IU</td>
    <td><asp:Label ID="lblVitA1" runat="server" Text="Label"></asp:Label></td>
    <td><asp:Label ID="lblVitA2" runat="server" Text="Label"></asp:Label></td>
    <td><asp:Label ID="lblVitA3" runat="server" Text="Label"></asp:Label></td>
  </tr>
  <tr>
    <td>Vitamin C|mg</td>
    <td><asp:Label ID="lblVitC1" runat="server" Text="Label"></asp:Label></td>
    <td><asp:Label ID="lblVitC2" runat="server" Text="Label"></asp:Label></td>
    <td><asp:Label ID="lblVitC3" runat="server" Text="Label"></asp:Label></td>
  </tr>
  <tr>
    <td>Iron|mg</td>
    <td><asp:Label ID="lblIron1" runat="server" Text="Label"></asp:Label></td>
    <td><asp:Label ID="lblIron2" runat="server" Text="Label"></asp:Label></td>
    <td><asp:Label ID="lblIron3" runat="server" Text="Label"></asp:Label></td>
  </tr>
  <tr>
    <td>Calcium|mg</td>
    <td><asp:Label ID="lblCalcium1" runat="server" Text="Label"></asp:Label></td>
    <td><asp:Label ID="lblCalcium2" runat="server" Text="Label"></asp:Label></td>
    <td><asp:Label ID="lblCalcium3" runat="server" Text="Label"></asp:Label></td>
  </tr>
  
</table>
       </div>
    </div>
    
    </div>         
         
        
    
        
              
<!--end col-->  

   
    <br />
     
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
