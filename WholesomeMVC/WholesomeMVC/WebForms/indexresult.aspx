<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/_layout.Master" AutoEventWireup="true" CodeBehind="indexresult.aspx.cs" Inherits="WholesomeMVC.WebForms.indexresult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="style" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
	<section>
<%--			OnSelectedIndexChanged="gridSearchResults_SelectedIndexChanged"
			OnRowDataBound="OnRowDataBound"--%>
		<asp:GridView
			ID="gridSearchResults"
			runat="server"
			AutoGenerateColumns="false"
			Width="660px"
			Visible="true"
			CssClass="myGridStyle"
			PagerStyle-CssClass="pgr"
			EmptyDataText="Please use the search bar to locate food items">
			<Columns>
				<asp:BoundField DataField="NDBno" HeaderText="NDBno" />
				<asp:BoundField DataField="Name" HeaderText="Item" />
				<asp:BoundField DataField="ND score" HeaderText="ND Score" />
				<asp:CommandField ShowSelectButton="True" SelectText="Expand" />
			</Columns> 
			<EmptyDataRowStyle Font-Size="30px" /> 
			<PagerStyle CssClass="pgr"></PagerStyle> 
		</asp:GridView>
	</section>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>