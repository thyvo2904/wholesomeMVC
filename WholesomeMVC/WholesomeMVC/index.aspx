<%@ Page Title="" Language="C#" MasterPageFile="~/_layout.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WholesomeMVC.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Home
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="style" runat="server">
    <link href="Content/index.css" rel="stylesheet" type="text/css" runat="server" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <section id="banner">
        <div class="background-color">
            <div class="text-center">
                <h1><asp:Label ID="banner_message" runat="server" /></h1>

                <div class="row" id="search-panel">
                    <div>
                        <asp:DropDownList
                            ID="ddlCategory"
                            runat="server"
                            CssClass="col-lg-4 btn btn-default btn-lg dropdown-toggle"
                            AppendDataBoundItems="True"
                            OnSelectedIndexChanged="Page_Load"
                            DataSourceID="Category"
                            DataTextField="FdGrp_Desc"
                            DataValueField="FdGrp_Desc">
                            <asp:ListItem Selected="True">Select a catagory</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource
                            ID="Category"
                            runat="server"
                            ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                            SelectCommand="SELECT [FdGrp_Desc] FROM [FD_GROUP]"></asp:SqlDataSource>
                    </div>

                    <div class="col-lg-8">
                        <div class="input-group input-group-lg">
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"></asp:TextBox>
                            <span class="input-group-btn">
                                <button type="submit" class="btn btn-default" runat="server" onserverclick="btnSearch" >
                                    <span class="glyphicon glyphicon-search"></span>
                                </button>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <div class="row">
        <div class="col-md-4 text-center">
            <div class="panel panel-default text-center banner-button">
                <img src="Content/Images/icons8-calculator-100.png" alt="Nutrient Calculator" />
                <a class="btn btn-success btn-lg btn-block" href="manual_input.aspx" role="button">Nutrient Calculator</a>
            </div>
        </div>

        <div class="col-md-4 text-center">
            <div class="panel panel-default text-center banner-button">
                <img src="Content/Images/icons8-time-machine-100.png" alt="Nutrient Calculator" />
                <a class="btn btn-success btn-lg btn-block" href="recent.aspx" role="button">Recent</a>
            </div>
        </div>

        <div class="col-md-4 text-center">
            <div class="panel panel-default text-center banner-button">
                <img src="Content/Images/icons8-check-file-100.png" alt="Nutrient Calculator" />
                <a class="btn btn-success btn-lg btn-block" href="saved_items.aspx" role="button">Saved Items</a>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="server">
</asp:Content>