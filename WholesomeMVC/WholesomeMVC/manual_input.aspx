<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="manual_input.aspx.cs" Inherits="WholesomeMVC.manual_input" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <title>Wholesome | Nutrition Calculator</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
  <link href="/css/manualinput.css" rel="stylesheet" type="text/css" runat="server"/>
  <style>
      
     
      .manual{
          
        font-family: 'Nunito', sans-serif;
        padding-top: 20px;
        padding-bottom: 20px;
        margin:auto;
        border-style: solid;
        padding-right: 5px;
        padding-left: 5px;
        transition: box-shadow .3s;
      }
      
      .manual:hover {
        box-shadow: 0 0 11px rgba(33,33,33,.2); 
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

 /*switch old/new food label*/
.performance-facts {
  border: 1px solid black;
  margin: 30px;
  position:absolute;
  left: 30%;
  width: 35%;
  padding: 0.5rem;
  height:auto;
  
  table {
    border-collapse: collapse;
  }
}
.performance-facts__title {
  font-weight: bold;
  font-size: 18px;
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
    width: 70%;
}

select {
    outline: 0;
    overflow: hidden;
    height: 30px;
    background: #0D8843;
    color: #fff;
    border: #2c343c;
    padding: 5px 3px 5px 10px;
    -moz-border-radius: 6px;
    -webkit-border-radius: 6px;
    border-radius: 6px;
}

select option 
{
    border: 1px solid #000; 
    background: #fff;
    font-family: 'Nunito', sans-serif;
    color:#0D8843;
    text-align: center;

}

 .sookyeown {
     width:50%;
     margin-top:10px;
 }

 .sook{
     width:30%;
 }

 .searchSpan{
     margin-top:50px;
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
<!--old/new food label switch-->
<script>
    function showDiv(elem) {
        if (elem.value == 0) {
            document.getElementById('div0').style.display = "block";
            document.getElementById('div1').style.display = "none";
        } else if (elem.value == 1) {
            document.getElementById('div1').style.display = "block";
            document.getElementById('div0').style.display = "none";
        } else {
            document.getElementById('div0').style.display = "block";
            document.getElementById('div1').style.display = "none";
        }
    }

    function load() {
        document.getElementById('div0').style.display = "block";
    }
</script>
</head>
<body onload="load()">         
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
<div class="col-md-12">
 <div class="row">
    <h2 class="text-center" style="color:#0D8843;">Nutrition Calculator</h2>
     <br>
     
     <h4>Using the nutrition calculator, you can manually input the value of each nutrient to calculate a score to compare to the nutrition grade.</h4>
    
    </div>    <br>
     </div>     
     </div> 
     
 <div class="container">  
     <select id="test" name="form_select" onchange="showDiv(this)" style="position:absolute;left:62%;">
		<option value="0">Old</option>
		<option value ="1">New</option>
     </select>
	 
	 <div id="div0" class="performance-facts" style="display:none">
         <div id="scorecolor" runat="server">
         <header class="performance-facts__header">
             <h5 class="performance-facts__title">
    ND_Score&nbsp;
     <input type="text" id="txtindex" runat="server" readonly="readonly" style="border:none;width:100px"/></h5>
          &nbsp;<span style="font-style:italic;font-size:8px;color:grey;">calculated based on 100kcal</span>
      
    <p>
    <p></p>
  </header>
  </div>
  <table class="performance-facts__table">
    <thead>
        <tr>
        <th colspan="3" class="small-info">
        </th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <th colspan="2" class="auto-style4">
          <b>Calories</b>
            </th>
          <td>
        <asp:TextBox ID="txtKcal0" runat="server" CssClass="txtnutrition"></asp:TextBox>
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
          <b>Saturated Fat|g</b>
        </th>
        <td>
             <asp:TextBox ID="txtsatfat0" runat="server" CssClass="txtnutrition"></asp:TextBox>
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
             <asp:TextBox ID="txtsodium0" runat="server" CssClass="txtnutrition"></asp:TextBox>
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
             <asp:TextBox ID="txtfiber0" runat="server" CssClass="txtnutrition"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="blank-cell">
        </td>
        <th>
         <b> TotalSugars|g</b>
        </th>
        <td>
            <asp:TextBox ID="txtsugar0" runat="server" CssClass="txtnutrition"></asp:TextBox>
        </td>
      </tr>
      <tr class="thick-end">
        <th colspan="2">
          <b>Protein|g</b>
        </th>
        <td>
            <asp:TextBox ID="txtprotein0" runat="server" CssClass="txtnutrition"></asp:TextBox>
        </td>
      </tr>
    </tbody>
  </table>
  
  <table class="performance-facts__table--grid">
    <tbody>
      <tr>
        <td colspan="2">
          <b>Vitamin A|%</b>
            <asp:TextBox ID="txtva0" runat="server" CssClass="txtnutrition"></asp:TextBox>
        </td>
        <td>
         <b>Vitamin C|%</b><span style="margin-left:2em;"></span>
            <asp:TextBox ID="txtvc0" runat="server" CssClass="txtnutrition"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td colspan="2">
         <b> Calcium|%</b><span style="margin-left:2em;"></span>
            <asp:TextBox ID="txtcalcium0" runat="server" CssClass="txtnutrition"></asp:TextBox>
        </td>
        <td>
          <b>Iron&nbsp;|% </b><span style="margin-right: 5em;"></span>
        <asp:TextBox ID="txtiron0" runat="server" CssClass="txtnutrition"></asp:TextBox>
        </td>
      </tr>
    </tbody>
  </table>
  <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Calculate" />
	 </div>
	 
<div id="div1" class="performance-facts" style="display:none">
	<header class="performance-facts__header">
    <h5 class="performance-facts__title">
        ND_Score&nbsp;
        <input type="text" id="txtindex2" runat="server" readonly="readonly" style="background-color: transparent; border: 0px solid;" ></h5>
        &nbsp;<span style="font-style:italic;font-size:8px;color:grey;">calculated based on 100kcal</span>
    <p>
    <p></p>
  </header>
  <table class="performance-facts__table">
    <thead>
        <tr>
        <th colspan="3" class="small-info">
          
        </th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <th colspan="2" class="auto-style4">
          <b>Calories</b>
       </th>
          <td>
        <asp:TextBox ID="txtkcal1" runat="server" CssClass="txtnutrition"></asp:TextBox>
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
             <asp:TextBox ID="txtsatfat1" runat="server" CssClass="txtnutrition"></asp:TextBox>
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
             <asp:TextBox ID="txtsodium1" runat="server" CssClass="txtnutrition"></asp:TextBox>

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
          Dietary Fiber|g
        </th>
        <td>
             <asp:TextBox ID="txtfiber1" runat="server" CssClass="txtnutrition"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="blank-cell">
        </td>
        <th>
          Added Sugars|g
        </th>
        <td>
            <asp:TextBox ID="addsugar1" runat="server" CssClass="txtnutrition"></asp:TextBox>
        </td>
      </tr>
      <tr class="thick-end">
        <th colspan="2">
          <b>Protein|g</b>
        </th>
        <td>
            <asp:TextBox ID="txtprotein1" runat="server" CssClass="txtnutrition"></asp:TextBox>
        </td>
      </tr>
    </tbody>
  </table>
  
  <table class="performance-facts__table--grid">
    <tbody>
      <tr>
        <td colspan="2">
         <b> Vitamin D|mcg</b>
            <asp:TextBox ID="txtvd1" runat="server" CssClass="txtnutrition"></asp:TextBox>
        </td>
        <td>
         <b> Calcium |mg</b>
            <asp:TextBox ID="txtcalcium1" runat="server" CssClass="txtnutrition"></asp:TextBox>

        </td>
      </tr>
      <tr>
        <td colspan="2">
         <b> Iron&nbsp;|mg </b><span style="margin-right: 5em;"></span>
            <asp:TextBox ID="txtiron1" runat="server" CssClass="txtnutrition"></asp:TextBox>
        </td>
        <td>
         <b> Potassium  |mg</b>
        <asp:TextBox ID="txtpotassium" runat="server" CssClass="txtnutrition"></asp:TextBox>
        </td>
      </tr>
     </tbody>
  </table>
         <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="Calculate"/>
	 </div>
            
   
    </div> 
     
     <br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
     
        
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
</body>
</html>