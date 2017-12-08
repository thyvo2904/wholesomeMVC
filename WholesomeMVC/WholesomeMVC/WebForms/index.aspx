<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/_layout.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WholesomeMVC.WebForms.index" %>

<asp:Content ContentPlaceHolderID="style" runat="server">
    <link href="/Content/Custom/index.css" rel="stylesheet" type="text/css" runat="server" />
</asp:Content>

<asp:Content ContentPlaceHolderID="body" runat="server">
    <section id="banner">
        <div class="background-color">
            <div>
                <h1 class="hidden-xs text-center"><asp:Label ID="banner_message" runat="server" /></h1>

                <div class="container-fluid" id="search-panel">
                    <div class="col-sm-4">
                        <asp:DropDownList
                            ID="ddlCategory"
                            runat="server"
                            CssClass="selectpicker equal-height"
							data-width="100%"
							data-live-search="true"
							title="Select a category"
                            AppendDataBoundItems="True"
                            OnSelectedIndexChanged="Page_Load"
                            DataSourceID="Category"
                            DataTextField="FdGrp_Desc"
                            DataValueField="FdGrp_Desc">
                        </asp:DropDownList>
                        <asp:SqlDataSource
                            ID="Category"
                            runat="server"
                            ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                            SelectCommand="SELECT [FdGrp_Desc] FROM [FD_GROUP]"></asp:SqlDataSource>
                    </div>

                    <div class="col-sm-8">
                        <div class="input-group">
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control typeahead equal-height" autocomplete="off"></asp:TextBox>
                            <span class="input-group-btn">
                                <button type="submit" class="btn btn-default equal-height" runat="server"  onserverclick="btnSearch" >
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
        <div class="col-sm-6 col-lg-3 text-center">
            <div class="panel panel-default text-center banner-button">
                <asp:Image ID="image_nutrient_calculator" runat="server" />
                <asp:HyperLink ID="link_nutrient_calculator" runat="server" CssClass="btn btn-success btn-lg btn-block" />
            </div>
        </div>

        <div class="col-sm-6 col-lg-3 text-center">
            <div class="panel panel-default text-center banner-button">
                <asp:Image ID="image_recent" runat="server" />
                <asp:HyperLink ID="link_recent" runat="server" CssClass="btn btn-success btn-lg btn-block" />
            </div>
        </div>

        <div class="col-sm-6 col-lg-3 text-center">
            <div class="panel panel-default text-center banner-button">
                <asp:Image ID="image_comparison" runat="server" />
                <asp:HyperLink ID="link_comparison" runat="server" CssClass="btn btn-success btn-lg btn-block" />
            </div>
        </div>

        <div class="col-sm-6 col-lg-3 text-center">
            <div class="panel panel-default text-center banner-button">
                <asp:Image ID="image_farmers_market" runat="server" />
                <asp:HyperLink ID="link_farmers_market" runat="server" CssClass="btn btn-success btn-lg btn-block" />
            </div>
        </div>

        <div class="col-sm-6 col-lg-3 text-center">
            <div class="panel panel-default text-center banner-button">
                <asp:Image ID="image_advanced_search" runat="server" />
                <asp:HyperLink ID="link_advanced_search" runat="server" CssClass="btn btn-success btn-lg btn-block" />
            </div>
        </div>

        <div class="col-sm-6 col-lg-3 text-center">
            <div class="panel panel-default text-center banner-button">
                <asp:Image ID="image_update_item" runat="server" />
                <asp:HyperLink ID="link_update_item" runat="server" CssClass="btn btn-success btn-lg btn-block" />
            </div>
        </div>

        <div class="col-sm-6 col-lg-3 text-center">
            <div class="panel panel-default text-center banner-button">
                <asp:Image ID="image_inventory_projection" runat="server" />
                <asp:HyperLink ID="link_inventory_projection" runat="server" CssClass="btn btn-success btn-lg btn-block" />
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ContentPlaceHolderID="script" runat="server">
</asp:Content>