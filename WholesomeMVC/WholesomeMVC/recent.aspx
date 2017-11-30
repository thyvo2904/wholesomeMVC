<%@ Page Language="C#" AutoEventWireup="True" Inherits="recent" Codebehind="recent.aspx.cs" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <title>WHOLESOME | RECENT</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
  <link href="/css/recent.css" rel="stylesheet" type="text/css" runat="server"/>
  <style>

      .image {
            width: 250px;
            float: left;
            margin: 20px;

      }

.performance-facts {
  border: 1px solid black;
  margin: 30px;
  float: left;
  width: 40%;
  padding: 0.5rem;
  height:auto;
  
  table {
    border-collapse: collapse;
  }
}
.performance-facts__title {
  font-weight: bold;
  font-size: 16px;
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
.txtnutrition{
    background-color: transparent;
    border: 0px solid;
    height: 20px;
    color: black;
    width: 45px;
    font-size:14px;
}

.btnsave{
    background-color: #0D8843;
    color:#fff;
    float:right;
    outline-color: #0D8843;
}


#section4{
    width:25%;
    display:block;
}

.wrapper
{
  display: table;
  width: 100%;
}

.containerdiv{
    display: table-cell;
    width: 25%;
}
@media only screen and (max-width:800px) /*800px for tablets and phones.*/
{
    #section1, #section2,#section3,#section4,#section5,#section6
    {
        display: block; 
        float: none; 
        width: 60%;
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
   <h3 >
    <span style="color: #fff;" class="glyphicon"></span> 
 </h3>       
       </div> 
    </div> <!--end row-->
    </div> <!--end second container-->
 </div>  <!--end container-->

<br><br> 
    
<div class="container">
  <div class="row">
    <h1 style="font-family: Avenir Next;">Recent Searches <span style="color: #0D8843;" class="glyphicon glyphicon-search"></span></h1>
   
      <br>
      <img src="https://farm5.staticflickr.com/4570/37777844945_eeb4e724be_o.png" style="float: right; width:750px; height:90px">
      
 
<div class="wrapper">
   <%--   1st label--%>
  <div id="section1" runat="server" visible="false" class="performance-facts containerdiv">
      <div id="divcolor1" runat="server">
  <header class="performance-facts__header">
    <h5 class="performance-facts__title">
        <asp:label runat="server" ID="lblName"></asp:label>
        <br />
        ND_Score&nbsp;
     <asp:label runat="server" ID="lblIndexResult"></asp:label>

      </h5>
    <p>
  </header>
          </div>
  <table class="performance-facts__table">
    <thead>
        <tr>
        <th colspan="3" class="small-info">
          <b>Nutrition Facts</b>
        </th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <th colspan="2" class="auto-style4">
          <b>Calories</b>
           </th>
           <td>
          <input class="txtnutrition" type="text" id="txtcalories" runat="server" >
           </td>
      </tr>
      <tr class="thick-row">
        <td colspan="3" class="small-info">
          <%--<b>Nutrition Facts</b>--%>
        </td>
      </tr>
      <tr>
        <th colspan="2">
        </th>
        <td>
        </td>
      </tr>
      <tr>
        <td class="blank-cell">
        </td>
        <th>
          <b>Saturated Fat|g</b>
        </th>
        <td>
          <input class="txtnutrition" type="text" id="txtsatfat" runat="server" >
        </td>
      </tr>
      <tr>
        <td class="blank-cell">
        </td>
        <th>
        </th>
        <td>
        </td>
      </tr>
      <tr>
        <th colspan="2">
        </th>
        <td>
        </td>
      </tr>
      <tr>
        <th colspan="2">
          <b>Sodium|mg</b>
        </th>
        <td>
          <input class="txtnutrition" type="text" id="txtsodium" runat="server" >
        </td>
      </tr>
      <tr>
        <th colspan="2">
        </th>
        <td>
        </td>
      </tr>
      <tr>
        <td class="blank-cell">
        </td>
        <th>
         <b> Dietary Fiber|g</b>
        </th>
        <td>
          <input class="txtnutrition" type="text" id="txtfiber" runat="server">
        </td>
      </tr>
      <tr>
        <td class="blank-cell">
        </td>
        <th>
         <b> Total Sugars|g</b>
        </th>
        <td>
            <input class="txtnutrition" type="text" id="txtsugar" runat="server">
        </td>
      </tr>
      <tr class="thick-end">
        <th colspan="2">
          <b>Protein|g</b>
        </th>
        <td>
            <input class="txtnutrition" type="text" id="txtprotein" runat="server">
        </td>
      </tr>
    </tbody>
  </table>
  
  <table class="performance-facts__table--grid">
    <tbody>
      <tr>
        <td colspan="2">
         <b> Vitamin A|IU </b><span style="margin-left: 2em;"></span>
          <input class="txtnutrition" type="text" id="txtva" runat="server">
        </td>
        <td>
          <b>Vitamin C|IU </b><span style="margin-left: 2em;"></span>
          <input class="txtnutrition" type="text" id="txtvc" runat="server">
        </td>
      </tr>
      <tr>
        <td colspan="2">
         <b> Calcium|mg </b> <span style="margin-left: 2em;"></span>
          <input class="txtnutrition" type="text" id="txtcalcium" runat="server">
        </td>
        <td>
         <b> Iron|mg</b> <span style="margin-left: 4em;"></span>
          <input class="txtnutrition" type="text" id="txtiron" runat="server">
          <br><br><asp:Button ID="btnSaveItem1" runat="server" Text="Save Item" class="btnsave" OnClick="btnSaveItem1_Click" />
        </td>
      </tr>
    </tbody>
  </table>
  </div>

  <%--  2nd label--%>
  <div id="section2" runat="server" visible="false" class="performance-facts containerdiv">
  <div id="divcolor2" runat="server">
      <header class="performance-facts__header">
    <h5 class="performance-facts__title">
        <asp:label runat="server" ID="lblName2"></asp:label>
        <br />
        ND_Score&nbsp;
     <asp:label runat="server" ID="lblIndexResult2"></asp:label>
      </h5>
    <p>
  </header>
      </div>
  <table class="performance-facts__table">
    <thead>
        <tr>
        <th colspan="3" class="small-info">
          Nutrition Facts
        </th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <th colspan="2" class="auto-style4">
          <b>Calories</b>
            </th>
          <td>
          <input class="txtnutrition" type="text" id="txtcalories2" runat="server" >
          </td>
      </tr>
      <tr class="thick-row">
        <td colspan="3" class="small-info">
        </td>
      </tr>
      <tr>
        <th colspan="2">
        </th>
        <td>
        </td>
      </tr>
      <tr>
        <td class="blank-cell">
        </td>
        <th>
         <b> Saturated Fat|g</b>
        </th>
        <td>
          <input class="txtnutrition" type="text" id="txtsatfat2" runat="server" >
        </td>
      </tr>
      <tr>
        <td class="blank-cell">
        </td>
        <th>
        </th>
        <td>
        </td>
      </tr>
      <tr>
        <th colspan="2">
        </th>
        <td>
        </td>
      </tr>
      <tr>
        <th colspan="2">
          <b>Sodium|mg</b>
        </th>
        <td>
          <input class="txtnutrition" type="text" id="txtsodium2" runat="server" >
        </td>
      </tr>
      <tr>
        <th colspan="2">
        </th>
        <td>
        </td>
      </tr>
      <tr>
        <td class="blank-cell">
        </td>
        <th>
          <b>Dietary Fiber|g</b>
        </th>
        <td>
          <input class="txtnutrition" type="text" id="txtfiber2" runat="server">
        </td>
      </tr>
      <tr>
        <td class="blank-cell">
        </td>
        <th>
        <b>  Total Sugars|g</b>
        </th>
        <td>
            <input class="txtnutrition" type="text" id="txtsugar2" runat="server">
        </td>
      </tr>
      <tr class="thick-end">
        <th colspan="2">
          <b>Protein|g</b>
        </th>
        <td>
            <input class="txtnutrition" type="text" id="txtprotein2" runat="server">
        </td>
      </tr>
    </tbody>
  </table>
  
  <table class="performance-facts__table--grid">
    <tbody>
      <tr>
        <td colspan="2">
          <b>Vitamin A|IU</b> <span style="margin-left: 2em;"></span>
          <input class="txtnutrition" type="text" id="txtva2" runat="server">
        </td>
        <td>
          <b>Vitamin C|IU</b> <span style="margin-left: 2em;"></span>
          <input class="txtnutrition" type="text" id="txtvc2" runat="server">
        </td>
      </tr>
      <tr>
        <td colspan="2">
          <b>Calcium|mg</b> <span style="margin-left: 2em;"></span>
          <input class="txtnutrition" type="text" id="txtcalcium2" runat="server">
        </td>
        <td>
          <b>Iron|mg</b> <span style="margin-left: 4em;"></span>
          <input class="txtnutrition" type="text" id="txtiron2" runat="server">
          <br><br><asp:Button ID="Button2" runat="server" Text="Save Item" class="btnsave" OnClick="btnSaveItem2_Click" />
        </td>
      </tr>
    </tbody>
  </table>
    </div>
  <%--  3rd label--%>
  <div id="section3" runat="server" visible="false" class="performance-facts containerdiv">
      <div id="divcolor3" runat="server">
  <header class="performance-facts__header">
    <h5 class="performance-facts__title">
        <asp:label runat="server" ID="lblName3"></asp:label>
        <br />
        ND_Score&nbsp;
     <asp:label runat="server" ID="lblIndexResult3"></asp:label>

      </h5>
    <p>
  </header>
          </div>
  <table class="performance-facts__table">
    <thead>
        <tr>
        <th colspan="3" class="small-info">
          <b>Nutrition Facts</b>
        </th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <th colspan="2" class="auto-style4">
          <b>Calories</b>
            </th>
          <td>
          <input class="txtnutrition" type="text" id="txtcalories3" runat="server" >
          </td>
      </tr>
      <tr class="thick-row">
        <td colspan="3" class="small-info">
        </td>
      </tr>
      <tr>
        <th colspan="2">
        </th>
        <td>
        </td>
      </tr>
      <tr>
        <td class="blank-cell">
        </td>
        <th>
         <b> Saturated Fat|g</b>
        </th>
        <td>
          <input class="txtnutrition" type="text" id="txtsatfat3" runat="server" >
        </td>
      </tr>
      <tr>
        <td class="blank-cell">
        </td>
        <th>
        </th>
        <td>
        </td>
      </tr>
      <tr>
        <th colspan="2">
        </th>
        <td>
        </td>
      </tr>
      <tr>
        <th colspan="2">
          <b>Sodium|mg</b>
        </th>
        <td>
          <input class="txtnutrition" type="text" id="txtsodium3" runat="server" >
        </td>
      </tr>
      <tr>
        <th colspan="2">
        </th>
        <td>
        </td>
      </tr>
      <tr>
        <td class="blank-cell">
        </td>
        <th>
         <b> Dietary Fiber|g</b>
        </th>
        <td>
          <input class="txtnutrition" type="text" id="txtfiber3" runat="server">
        </td>
      </tr>
      <tr>
        <td class="blank-cell">
        </td>
        <th>
         <b> Total Sugars|g</b>
        </th>
        <td>
            <input class="txtnutrition" type="text" id="txtsugar3" runat="server">
        </td>
      </tr>
      <tr class="thick-end">
        <th colspan="2">
          <b>Protein|g</b>
        </th>
        <td>
            <input class="txtnutrition" type="text" id="txtprotein3" runat="server">
        </td>
      </tr>
    </tbody>
  </table>
  
  <table class="performance-facts__table--grid">
    <tbody>
      <tr>
        <td colspan="2">
         <b> Vitamin A|IU</b> <span style="margin-left: 2em;"></span>
          <input class="txtnutrition" type="text" id="txtva3" runat="server">
        </td>
        <td>
         <b> Vitamin C|IU</b> <span style="margin-left: 2em;"></span>
          <input class="txtnutrition" type="text" id="txtvc3" runat="server">
        </td>
      </tr>
      <tr>
        <td colspan="2">
         <b> Calcium|mg</b> <span style="margin-left: 2em;"></span>
          <input class="txtnutrition" type="text" id="txtcalcium3" runat="server">
        </td>
        <td>
          <b>Iron|mg</b> <span style="margin-left: 4em;"></span>
          <input class="txtnutrition" type="text" id="txtiron3" runat="server">
        <br><br><asp:Button ID="Button1" runat="server" Text="Save Item" class="btnsave" OnClick="btnSaveItem3_Click" />
        </td>
      </tr>
    </tbody>
  </table>
    </div>
      </div>
<%--    4th label--%>

  <div id="section4" runat="server" visible="false" class="performance-facts containerdiv">
      <div id="divcolor4" runat="server">
  <header class="performance-facts__header">
    <h5 class="performance-facts__title">
        <asp:label runat="server" ID="lblName4"></asp:label>
        <br />
        ND_Score&nbsp;
     <asp:label runat="server" ID="lblIndexResult4"></asp:label>

      </h5>
    <p>
  </header>
          </div>
  <table class="performance-facts__table">
    <thead>
        <tr>
        <th colspan="3" class="small-info">
          <b>Nutrition Facts</b>
        </th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <th colspan="2" class="auto-style4">
          <b>Calories</b>
          </th>
          <td>
          <input class="txtnutrition" type="text" id="txtcalories4" runat="server" >
          </td>
      </tr>
      <tr class="thick-row">
        <td colspan="3" class="small-info">
        </td>
      </tr>
      <tr>
        <th colspan="2">
      </tr>
      <tr>
        <td class="blank-cell">
        </td>
        <th>
          <b>Saturated Fat|g</b>
        </th>
        <td>
          <input class="txtnutrition" type="text" id="txtsatfat4" runat="server" >
        </td>
      </tr>
      <tr>
        <td class="blank-cell">
        </td>
        <th>
        </th>
        <td>
        </td>
      </tr>
      <tr>
        <th colspan="2">
        </th>
        <td>
        </td>
      </tr>
      <tr>
        <th colspan="2">
          <b>Sodium|mg</b>
        </th>
        <td>
          <input class="txtnutrition" type="text" id="txtsodium4" runat="server" >
        </td>
      </tr>
      <tr>
        <th colspan="2">
        </th>
        <td>
        </td>
      </tr>
      <tr>
        <td class="blank-cell">
        </td>
        <th>
         <b> Dietary Fiber|g</b>
        </th>
        <td>
          <input class="txtnutrition" type="text" id="txtfiber4" runat="server">
        </td>
      </tr>
      <tr>
        <td class="blank-cell">
        </td>
        <th>
        <b>  Total Sugars|g</b>
        </th>
        <td>
            <input class="txtnutrition" type="text" id="txtsugar4" runat="server">
        </td>
      </tr>
      <tr class="thick-end">
        <th colspan="2">
          <b>Protein|g</b>
        </th>
        <td>
            <input class="txtnutrition" type="text" id="txtprotein4" runat="server">
        </td>
      </tr>
    </tbody>
  </table>
  
  <table class="performance-facts__table--grid">
    <tbody>
      <tr>
        <td colspan="2">
         <b> Vitamin A|IU </b><span style="margin-left: 2em;"></span>
          <input class="txtnutrition" type="text" id="txtva4" runat="server">
        </td>
        <td>
         <b> Vitamin C|IU </b><span style="margin-left: 2em;"></span>
          <input class="txtnutrition" type="text" id="txtvc4" runat="server">
        </td>
      </tr>
      <tr>
        <td colspan="2">
         <b> Calcium|mg </b> <span style="margin-left: 2em;"></span>
          <input class="txtnutrition" type="text" id="txtcalcium4" runat="server">
        </td>
        <td>
         <b> Iron|mg</b> <span style="margin-left: 4em;"></span>
          <input class="txtnutrition" type="text" id="txtiron4" runat="server">
          <br><br><asp:Button ID="btnSaveItem4" runat="server" Text="Save Item" class="btnsave" OnClick="btnSaveItem4_Click" />
        </td>
      </tr>
    </tbody>
  </table>
    </div>

      <div id="section5" runat="server" visible="false" class="performance-facts containerdiv">
  <div id="divcolor5" runat="server">
          <header class="performance-facts__header">
    <h5 class="performance-facts__title">
        <asp:label runat="server" ID="lblName5"></asp:label>
        <br />
        ND_Score&nbsp;
     <asp:label runat="server" ID="lblIndexResult5"></asp:label>

      </h5>
    <p>
  </header>
      </div>
  <table class="performance-facts__table">
    <thead>
        <tr>
        <th colspan="3" class="small-info">
          <b>Nutrition Facts</b>
        </th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <th colspan="2" class="auto-style4">
          <b>Calories</b>
          </th>
          <td>
          <input class="txtnutrition" type="text" id="txtcalories5" runat="server" >
          </td>
      </tr>
      <tr class="thick-row">
        <td colspan="3" class="small-info">
        </td>
      </tr>
      <tr>
        <th colspan="2">
      </tr>
      <tr>
        <td class="blank-cell">
        </td>
        <th>
          <b>Saturated Fat|g</b>
        </th>
        <td>
          <input class="txtnutrition" type="text" id="txtsatfat5" runat="server" >
        </td>
      </tr>
      <tr>
        <td class="blank-cell">
        </td>
        <th>
        </th>
        <td>
        </td>
      </tr>
      <tr>
        <th colspan="2">
        </th>
        <td>
        </td>
      </tr>
      <tr>
        <th colspan="2">
          <b>Sodium|mg</b>
        </th>
        <td>
          <input class="txtnutrition" type="text" id="txtsodium5" runat="server" >
        </td>
      </tr>
      <tr>
        <th colspan="2">
        </th>
        <td>
        </td>
      </tr>
      <tr>
        <td class="blank-cell">
        </td>
        <th>
         <b> Dietary Fiber|g</b>
        </th>
        <td>
          <input class="txtnutrition" type="text" id="txtfiber5" runat="server">
        </td>
      </tr>
      <tr>
        <td class="blank-cell">
        </td>
        <th>
        <b>Total Sugars|g</b>
        </th>
        <td>
            <input class="txtnutrition" type="text" id="txtsugar5" runat="server">
        </td>
      </tr>
      <tr class="thick-end">
        <th colspan="2">
          <b>Protein|g</b>
        </th>
        <td>
            <input class="txtnutrition" type="text" id="txtprotein5" runat="server">
        </td>
      </tr>
    </tbody>
  </table>
  
  <table class="performance-facts__table--grid">
    <tbody>
      <tr>
        <td colspan="2">
         <b> Vitamin A|IU </b><span style="margin-left: 2em;"></span>
          <input class="txtnutrition" type="text" id="txtva5" runat="server">
        </td>
        <td>
         <b> Vitamin C|IU </b><span style="margin-left: 2em;"></span>
          <input class="txtnutrition" type="text" id="txtvc5" runat="server">
        </td>
      </tr>
      <tr>
        <td colspan="2">
         <b> Calcium|mg </b> <span style="margin-left: 2em;"></span>
          <input class="txtnutrition" type="text" id="txtcalcium5" runat="server">
        </td>
        <td>
         <b> Iron|mg</b> <span style="margin-left: 4em;"></span>
          <input class="txtnutrition" type="text" id="txtiron5" runat="server">
          <br><br><asp:Button ID="btnSaveItem5" runat="server" Text="Save Item" class="btnsave" OnClick="btnSaveItem4_Click" />
        </td>
      </tr>
    </tbody>
  </table>
    </div>
  
<div id="section6" runat="server" visible="false" class="performance-facts containerdiv">
  <div id="divcolor6" runat="server">
   <header class="performance-facts__header">
      <h5 class="performance-facts__title">
        <asp:label runat="server" ID="lblName6"></asp:label>
        <br />
        ND_Score&nbsp;
     <asp:label runat="server" ID="lblIndexResult6"></asp:label>

      </h5>
    <p>
  </header>
   </div>
  <table class="performance-facts__table">
    <thead>
        <tr>
        <th colspan="3" class="small-info">
          <b>Nutrition Facts</b>
        </th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <th colspan="2" class="auto-style4">
          <b>Calories</b>
          </th>
          <td>
          <input class="txtnutrition" type="text" id="txtcalories6" runat="server" >
          </td>
      </tr>
      <tr class="thick-row">
        <td colspan="3" class="small-info">
        </td>
      </tr>
      <tr>
        <th colspan="2">
      </tr>
      <tr>
        <td class="blank-cell">
        </td>
        <th>
          <b>Saturated Fat|g</b>
        </th>
        <td>
          <input class="txtnutrition" type="text" id="txtsatfat6" runat="server" >
        </td>
      </tr>
      <tr>
        <td class="blank-cell">
        </td>
        <th>
        </th>
        <td>
        </td>
      </tr>
      <tr>
        <th colspan="2">
        </th>
        <td>
        </td>
      </tr>
      <tr>
        <th colspan="2">
          <b>Sodium|mg</b>
        </th>
        <td>
          <input class="txtnutrition" type="text" id="txtsodium6" runat="server" >
        </td>
      </tr>
      <tr>
        <th colspan="2">
        </th>
        <td>
        </td>
      </tr>
      <tr>
        <td class="blank-cell">
        </td>
        <th>
         <b> Dietary Fiber|g</b>
        </th>
        <td>
          <input class="txtnutrition" type="text" id="txtfiber6" runat="server">
        </td>
      </tr>
      <tr>
        <td class="blank-cell">
        </td>
        <th>
        <b>  Total Sugars|g</b>
        </th>
        <td>
            <input class="txtnutrition" type="text" id="txtsugar6" runat="server">
        </td>
      </tr>
      <tr class="thick-end">
        <th colspan="2">
          <b>Protein|g</b>
        </th>
        <td>
            <input class="txtnutrition" type="text" id="txtprotein6" runat="server">
        </td>
      </tr>
    </tbody>
  </table>
  
  <table class="performance-facts__table--grid">
    <tbody>
      <tr>
        <td colspan="2">
         <b> Vitamin A|IU </b><span style="margin-left: 2em;"></span>
          <input class="txtnutrition" type="text" id="txtva6" runat="server">
        </td>
        <td>
         <b> Vitamin C|IU </b><span style="margin-left: 2em;"></span>
          <input class="txtnutrition" type="text" id="txtvc6" runat="server">
        </td>
      </tr>
      <tr>
        <td colspan="2">
         <b> Calcium|mg </b> <span style="margin-left: 2em;"></span>
          <input class="txtnutrition" type="text" id="txtcalcium6" runat="server">
        </td>
        <td>
         <b> Iron|mg</b> <span style="margin-left: 4em;"></span>
          <input class="txtnutrition" type="text" id="txtiron6" runat="server">
          <br><br><asp:Button ID="btnSaveItem6" runat="server" Text="Save Item" class="btnsave" OnClick="btnSaveItem4_Click" />
        </td>
      </tr>
    </tbody>
  </table>
    </div>
    
<br>
    

     </div>
    
    </div>

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