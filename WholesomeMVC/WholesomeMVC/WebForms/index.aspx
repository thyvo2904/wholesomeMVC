<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/_layout.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WholesomeMVC.WebForms.index" %>

<asp:Content ContentPlaceHolderID="style" runat="server">
    <link href="/Content/Custom/index.css" rel="stylesheet" type="text/css" runat="server" />
</asp:Content>

<asp:Content ContentPlaceHolderID="body" runat="server">
    <section id="banner">
        <div class="background-color">
            <div class="text-center">
                <h1 class="hidden-xs"><asp:Label ID="banner_message" runat="server" /></h1>

                <div class="container-fluid" id="search-panel">
                    <div class="col-sm-4">
                        <asp:DropDownList
                            ID="ddlCategory"
                            runat="server"
                            CssClass="btn btn-default btn-lg dropdown-toggle"
                            AppendDataBoundItems="True"
                            OnSelectedIndexChanged="Page_Load"
                            DataSourceID="Category"
                            DataTextField="FdGrp_Desc"
							style="width: 100%;"
                            DataValueField="FdGrp_Desc">
                            <asp:ListItem Selected="True">Select a category</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource
                            ID="Category"
                            runat="server"
                            ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                            SelectCommand="SELECT [FdGrp_Desc] FROM [FD_GROUP]"></asp:SqlDataSource>
                    </div>

                    <div class="col-sm-8">
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
                <asp:Image ID="image_nutrient_calculator" runat="server" />
                <asp:HyperLink ID="link_nutrient_calculator" runat="server" CssClass="btn btn-success btn-lg btn-block" />
            </div>
        </div>

        <div class="col-md-4 text-center">
            <div class="panel panel-default text-center banner-button">
                <asp:Image ID="image_recent" runat="server" />
                <asp:HyperLink ID="link_recent" runat="server" CssClass="btn btn-success btn-lg btn-block" />
            </div>
        </div>

        <div class="col-md-4 text-center">
            <div class="panel panel-default text-center banner-button">
                <asp:Image ID="image_saved_items" runat="server" />
                <asp:HyperLink ID="link_saved_items" runat="server" CssClass="btn btn-success btn-lg btn-block" />
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ContentPlaceHolderID="script" runat="server">
</asp:Content>