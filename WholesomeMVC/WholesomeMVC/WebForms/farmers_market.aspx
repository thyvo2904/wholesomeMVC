<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/WebForms/_layout.Master" CodeBehind="Farmers_Market.aspx.cs" Inherits="WholesomeMVC.WebForms.Farmers_Market" %>



<asp:Content ContentPlaceHolderID="body" runat="server">  <!--end container-->
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
 </asp:Content>