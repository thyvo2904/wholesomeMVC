<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="IndexResults.aspx.cs" Inherits="WholesomeMVC.IndexResults" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <title>WHOLESOME | HOME</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <link href="/css/indexresults.css" rel="stylesheet" type="text/css" runat="server"/>
 
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
  .image {
  width: 250px;
  float: left;
  margin: 20px;
}


.performance-facts {
  border: 1px solid black;
  margin: 30px;
  float: right;
  width: 40%;
  padding: 0.5rem;
  height:auto;
  
  table {
    border-collapse: collapse;
  }
}
.performance-facts__title {
  font-weight: bold;
  font-size: 25px;
  margin: 0 0 0.25rem 0;

}
.performance-facts__header {
  border-bottom: 10px solid black;
  padding: 0 0 0.25rem 0;
  margin: 0 0 0.5rem 0;

  p {
    margin: 0;
  }
}
      .performance-facts__header_yellow {
  border-bottom: 10px solid black;
  padding: 0 0 0.25rem 0;
  margin: 0 0 0.5rem 0;
  background-color:yellow;
  p {
    margin: 0;
  }
}
      .performance-facts__header_red {
  border-bottom: 10px solid black;
  padding: 0 0 0.25rem 0;
  margin: 0 0 0.5rem 0;
  background-color:red;
  p {
    margin: 0;
  }
}
.performance-facts__table {
  width: 100%;

  thead tr {
    th, td {
      border: 0;
    }
  }
  th, td {
    font-weight: normal;
    text-align: left;
    padding: 0.25rem 0;
    border-top: 1px solid black; 
    white-space: nowrap;
    font-size:3rem;
  }

  td {
    &:last-child {
      text-align: right;
      font-size:3rem;
    }
  }
  .blank-cell {
    width: 4rem;
    border-top: 0;
  }
  .thick-row {
    th, td {
      border-top-width: 5px;
    }
  }
}
.small-info {
  font-size: 2rem;
}

.performance-facts__table--small {
  @extend .performance-facts__table;
  border-bottom: 1px solid #999;
  margin: 0 0 0.5rem 0;
  thead {
    tr {
      border-bottom: 1px solid black; 
    }
  }
  td {
    &:last-child {
      text-align: left;
      font-size:3rem;
    }
  }
  th, td {
    border: 0;
    padding: 0;
  }
}

.performance-facts__table--grid {
  @extend .performance-facts__table;
  margin: 0 0 0.5rem 0;
  td {
    &:last-child {
      text-align: left;
      &::before {
        content: "•";
        font-weight: bold;
        margin: 0 0.25rem 0 0;
      }
    }
  }
}

.text-center {
  text-align: center;
}
.thick-end {
  border-bottom: 10px solid black;
}
.thin-end {
  border-bottom: 1px solid black;
}

.txtceres{
    /*border: 0px solid;*/
    height: 20px;
    color: black;
    width: 120px;
    font-size:20px;
}

.txtnutrition{
    background-color: transparent;
    border: 0px solid;
    height: 20px;
    color: black;
    width: 60px;
   /* font-size:20px;*/
}
        .sookyeown{
          height:32px;
          width:200px;
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
        }
         
         
        .myGridStyle tr:nth-child(even)
        {
            background-color: lightblue;
        }
         
        .myGridStyle tr:nth-child(odd)
        {
            background-color:gray;
        }
         
        .myGridStyle td
        {
            border:1px solid black;
            padding: 8px;
        }
         
        .myGridStyle tr:last-child td
        {
        }
 
 
      .gridSearchResults{
          margin-left: 30px;
          margin-right:60px;
          margin-top:20px;
          max-height: 600px;
          overflow:scroll;
          float: left;
      }
      #wrapper{
          display: inline-block;
          height: 1000px;
      }
       @media only screen and (max-width:900px) /*800px for tablets and phones.*/
{ 
    #section1,#section2
    {
        display: block; 
        float: none; 
        width: 75%;
    }
    #colorguide{
        display:none;
    }
    #ingredients{
        display:none;
    }
    .txtnutrition{
        font-size: 12px;
    }
    .txtceres{
        font-size: 12px;
    }
    lblingredients{
        display: none;
    }
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
            <li><a style="color:#0D8843; font-size:14px;" href="manual_input.aspx">NUTRIENT CALCULATOR</a></li>
            <li><a style="color:#0D8843; font-size:14px;" href="recent.aspx">RECENT</a></li>
            <li><a style="color:#0D8843; font-size:14px;" href="saved_items.aspx">SAVED ITEMS</a></li>
        </ul>
        
        
        
<div class="input-group">
            <div class="input-group-btn search-panel">
       <asp:DropDownList ID="ddlCategory" runat="server" CssClass="btn btn-default dropdown-toggle" AppendDataBoundItems="true" OnSelectedIndexChanged="Page_Load" DataSourceID="Category" DataTextField="FdGrp_Desc" DataValueField="FdGrp_Desc">
         <asp:ListItem Selected="True">--Select Category--</asp:ListItem>
 
                
      </asp:DropDownList>
                </div>
          <asp:SqlDataSource ID="Category" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [FdGrp_Desc] FROM [FD_GROUP]"></asp:SqlDataSource>
            
      <asp:TextBox ID="txtSearch" runat="server" CssClass="sook form-control"></asp:TextBox>
    <span class="input-group-btn">
            
       <button class="btn btn-default" runat="server" onserverclick="btnSearch" ><span class="glyphicon glyphicon-search"></span></button>     </span>          
            
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
     <div id="wrapper">
     <div class ="gridSearchResults" id="section1">
  <asp:GridView ID="gridSearchResults" runat="server" AutoGenerateColumns="false" Width="660px" Visible ="true" CssClass="myGridStyle" PagerStyle-CssClass="pgr" OnSelectedIndexChanged="gridSearchResults_SelectedIndexChanged" OnRowDataBound = "OnRowDataBound" EmptyDataText="Please use the search bar to locate food items" >     
         <Columns>
             <asp:BoundField DataField ="NDBno" HeaderText ="NDBno"/>
             <asp:BoundField DataField ="Name" HeaderText ="Item"/>
             <asp:BoundField DataField ="ND score" HeaderText ="ND Score" />
             <asp:commandfield showselectbutton="True" selectText ="Expand"/>
         </Columns>

         <EmptyDataRowStyle Font-Size="30px" />

<PagerStyle CssClass="pgr"></PagerStyle>

     </asp:GridView>
     </div>



         <div class="performance-facts" id="section2" style="font-family: Times New Roman, Georgia, Serif">
             <span style="font-weight: bold; font-size: 20px">
                 <asp:Label ID="lblFoodName" runat="server" Text=""></asp:Label></span>
             <header class="performance-facts__header">
                 <h3 class="performance-facts__title">ND_Score&nbsp;
     <asp:Label runat="server" ID="lblIndexResult"></asp:Label>
                     <asp:Label runat="server" ID="lblName" Visible="false"></asp:Label>
                     <asp:Label runat="server" ID="lblNdbno" Visible="false"></asp:Label>

                 </h3>
                 <p>
                 <p></p>
             </header>
             <table class="performance-facts__table">
                 <thead>
                     <tr>
                         <th colspan="3" class="small-info"></th>
                     </tr>
                 </thead>
                 <tbody>
                     <tr>
                         <th colspan="2">
                             <span style="font-weight: bold; font-size: 20px">Nutrition Facts</span>
                         </th>
                     </tr>
                     <tr>
                         <td colspan="3" class="small-info"></td>
                     </tr>
                     <tr>
                         <th colspan="2">
                             <span style="font-size: 28px">Calories</span>
                         </th>
                         <td>
                             <input class="txtnutrition txtpercent" type="text" id="txtcalories" style="font-size: 28px; width: 60px;" runat="server" readonly="readonly">
                         </td>
                     </tr>
                     <tr class="thick-row">
                         <td colspan="3" class="small-info">
                             <b style="float: right;">% Daily Value*</b>
                         </td>
                     </tr>
                     <tr>
                         <th colspan="2">
                             <b>Total Fat</b>
                             <input class="txtnutrition" type="text" id="txtfat" runat="server" readonly="readonly">
                         </th>
                         <td>
                             <input class="txtnutrition txtpercent" type="text" id="txtfatpercent" runat="server" readonly="readonly">
                         </td>
                     </tr>
                     <tr>
                         <td class="blank-cell"></td>
                         <th>
                             <b>Saturated Fat</b>
                             <input class="txtnutrition" type="text" id="txtsatfat" runat="server" readonly="readonly">

                         <td>
                             <input class="txtnutrition txtpercent" type="text" id="txtsatfatpercent" runat="server" readonly="readonly">
                         </td>
                     </tr>
                     <tr>
                         <td class="blank-cell"></td>
                         <th>
                             <b>Trans Fat</b>
                             <input class="txtnutrition" type="text" id="txtTransfat" runat="server" readonly="readonly">
                         </th>
                         <td></td>
                     </tr>
                     <tr>
                         <th colspan="2">
                             <b>Cholesterol</b>
                             <input class="txtnutrition" type="text" id="txtCholesterol" runat="server" readonly="readonly">
                         </th>
                         <td>
                             <input class="txtnutrition txtpercent" type="text" id="txtCholesterolpercecnt" runat="server" readonly="readonly">
                         </td>
                     </tr>
                     <tr>
                         <td class="blank-cell"></td>
                         <th>
                             <b>Sodium</b>
                             <input class="txtnutrition" type="text" id="txtsodium" runat="server" readonly="readonly">
                         </th>
                         <td>
                             <input class="txtnutrition  txtpercent" type="text" id="txtsodiumpercent" runat="server" readonly="readonly">
                         </td>
                     </tr>
                     <tr>
                         <th colspan="2">
                             <b>Total Carbohydrate</b>
                             <input class="txtnutrition" type="text" id="txtCarbohydrate" runat="server" readonly="readonly">
                         </th>
                         <td>
                             <input class="txtnutrition txtpercent" type="text" id="txtcarbonpercent" runat="server" readonly="readonly">
                         </td>
                     </tr>
                     <tr>
                         <td class="blank-cell"></td>
                         <th>
                             <b>Dietary Fiber</b>
                             <input class="txtnutrition" type="text" id="txtfiber" runat="server" readonly="readonly">
                         </th>
                         <td>
                             <input class="txtnutrition txtpercent" type="text" id="txtfiberpercent" runat="server" readonly="readonly">
                         </td>
                     </tr>
                     <tr>
                         <td class="blank-cell"></td>
                         <th>
                             <b>Sugars</b>
                             <input class="txtnutrition" type="text" id="txtsugar" runat="server" readonly="readonly">
                         </th>
                         <td></td>
                     </tr>
                     <tr class="thick-end">
                         <td class="blank-cell"></td>
                         <th colspan="2">
                             <b>Protein</b>
                             <input class="txtnutrition" type="text" id="txtprotein" runat="server" readonly="readonly">
                         </th>
                         <td></td>
                     </tr>
                 </tbody>
             </table>

             <table class="performance-facts__table--grid">
                 <tbody>
                     <tr>
                         <td colspan="2">Vitamin A&nbsp;
                             <input class="txtnutrition" type="text" id="txtva" runat="server" readonly="readonly">
                         </td>
                         <td><span style="position: relative; left: 100px">Vitamin C&nbsp;
                             <input class="txtnutrition" type="text" id="txtvc" runat="server" readonly="readonly"></span>
                         </td>
                     </tr>
                     <tr>
                         <td colspan="2">Calcium&nbsp;
                             <input class="txtnutrition" type="text" id="txtcalcium" runat="server" readonly="readonly">
                         </td>
                         <td><span style="position: relative; left: 100px">Iron&nbsp;
                             <input class="txtnutrition" type="text" id="txtiron" runat="server" readonly="readonly"></span>
                         </td>
                     </tr>
                 </tbody>
             </table>
             <p class="small-info">* The % Daily Value (DV) tells you how much a nutrient in a serving of food contributes to a daily diet. 2,000 calories a day is used for general nutrition advice.</p>
             <br />
             <table style="width: 100%;">
                 <tr>
                     <th>
                         <b>Ceres Number:</b>
                     </th>
                     <td>
                         <span style="margin-right: 140px;">
                             <asp:TextBox ID="txtCeresNumber" CssClass="txtceres" runat="server"></asp:TextBox></span>
                     </td>
                 </tr>
                 <tr>
                     <th>
                         <b>Ceres Description:</b>
                     </th>
                     <td>
                         <span style="margin-right: 140px;">
                             <asp:TextBox ID="txtCeresDescription" CssClass="txtceres" runat="server"></asp:TextBox></span>
                     </td>
                 </tr>
                 <tr>
                     <th>
                         <b>Item Quantity:</b>
                     </th>
                     <td>
                         <span style="margin-right: 140px;">
                             <asp:TextBox ID="txtCeresQuantity" CssClass="txtceres" runat="server"></asp:TextBox></span>
                     </td>
                 </tr>
                 <tr>
                     <td colspan="4">
                         <br>
                         <span style="float: right;">
                             <%--<button type="button" class="btn btn-sm btn-default" id="btnSaveItem" runat="server" onserverclick="btnSaveItem_Click"><span class="glyphicon glyphicon-floppy-saved"></span>Save</button></span>--%>
                         <%-- <asp:Button type="submit" ID="btnSaveItem" runat="server" OnClick="btnSaveItem_Click" Text="Save" CssClass="btnindex"/>--%>
                         <span style="float: right;">
                             <%--<button type="button" class="btn btn-sm btn-default" id="btnUpdateItem" runat="server"><span class="glyphicon glyphicon-cloud-upload"></span>Update</button></span>--%>
                     </td>
                 </tr>
             </table>
         </div>
     </div>
     
     
    
 <br />
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
