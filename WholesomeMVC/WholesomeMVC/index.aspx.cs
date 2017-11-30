
using System;
using System.Data.SqlClient;
using Wholesome;

public partial class index : System.Web.UI.Page
{

    public static string foodSearch;
    protected void Page_Load(object sender, EventArgs e)
    {
        //cleaning up code--not sure if this will need to be used 
        //if (!IsPostBack)
        //{
        //    if (Application["visits"] == null)
        //    {
        //        Application["visits"] = 1;
        //    }
        //    else
        //    {
        //        int visits = (int)Application["visits"];
        //        visits++;
        //        Application["visits"] = visits;

        //    }
        //}
    }

    protected void btnSearch(object sender, EventArgs e)
    {
     
            if (txtSearch.Text != "" && ddlCategory.SelectedIndex == 0)
            {
                foodSearch = txtSearch.Text;
                FoodItem.findNdbno(foodSearch);
                Server.Transfer("~/IndexResults.aspx");     
            }

            else if (ddlCategory.SelectedIndex == 1)
            {
                foodSearch = txtSearch.Text + "&fg=0100";
                FoodItem.findNdbno(foodSearch);
                Server.Transfer("~/IndexResults.aspx");
            }
            else if (ddlCategory.SelectedIndex == 2)
            {
                foodSearch = txtSearch.Text + "&fg=0200";
                FoodItem.findNdbno(foodSearch);
                Server.Transfer("~/IndexResults.aspx");

            }
            else if (ddlCategory.SelectedIndex == 3)
            {
                foodSearch = txtSearch.Text + "&fg=0300";
                FoodItem.findNdbno(foodSearch);
                Server.Transfer("~/IndexResults.aspx"); 

            }
            else if (ddlCategory.SelectedIndex == 4)
            {
                foodSearch = txtSearch.Text + "&fg=0400";
                FoodItem.findNdbno(foodSearch);
                Server.Transfer("~/IndexResults.aspx");
            }

            else if (ddlCategory.SelectedIndex == 5)
            {
                foodSearch = txtSearch.Text + "&fg=0500";
                FoodItem.findNdbno(foodSearch);
                Server.Transfer("~/IndexResults.aspx");
            }
            else if (ddlCategory.SelectedIndex == 6)
            {
                foodSearch = txtSearch.Text + "&fg=0600";
                FoodItem.findNdbno(foodSearch);
                Server.Transfer("~/IndexResults.aspx");
            }

            else if (ddlCategory.SelectedIndex == 7)
            {
                foodSearch = txtSearch.Text + "&fg=0700";
                FoodItem.findNdbno(foodSearch);
                Server.Transfer("~/IndexResults.aspx");
            }

            else if (ddlCategory.SelectedIndex == 8)
            {
                foodSearch = txtSearch.Text + "&fg=0800";
                FoodItem.findNdbno(foodSearch);
                Server.Transfer("~/IndexResults.aspx");
            }

            else if (ddlCategory.SelectedIndex == 9)
            {
                foodSearch = txtSearch.Text + "&fg=0900";
                FoodItem.findNdbno(foodSearch);
                Server.Transfer("~/IndexResults.aspx");
            }

            else if (ddlCategory.SelectedIndex == 10)
            {
                foodSearch = txtSearch.Text + "&fg=1000";
                FoodItem.findNdbno(foodSearch);
                Server.Transfer("~/IndexResults.aspx");
            }

            else if (ddlCategory.SelectedIndex == 11)
            {
                foodSearch = txtSearch.Text + "&fg=1100";
                FoodItem.findNdbno(foodSearch);
                Server.Transfer("~/IndexResults.aspx");
            }

            else if (ddlCategory.SelectedIndex == 12)
            {
                foodSearch = txtSearch.Text + "&fg=1200";
                FoodItem.findNdbno(foodSearch);
                Server.Transfer("~/IndexResults.aspx");
            }

            else if (ddlCategory.SelectedIndex == 13)
            {
                foodSearch = txtSearch.Text + "&fg=1300";
                FoodItem.findNdbno(foodSearch);
                Server.Transfer("~/IndexResults.aspx");
            }

            else if (ddlCategory.SelectedIndex == 14)
            {
                foodSearch = txtSearch.Text + "&fg=1400";
                FoodItem.findNdbno(foodSearch);
                Server.Transfer("~/IndexResults.aspx");
            }

            else if (ddlCategory.SelectedIndex == 15)
            {
                foodSearch = txtSearch.Text + "&fg=1500";
                FoodItem.findNdbno(foodSearch);
                Server.Transfer("~/IndexResults.aspx");
            }

            else if (ddlCategory.SelectedIndex == 16)
            {
                foodSearch = txtSearch.Text + "&fg=1600";
                FoodItem.findNdbno(foodSearch);
                Server.Transfer("~/IndexResults.aspx");
            }

            else if (ddlCategory.SelectedIndex == 17)
            {
                foodSearch = txtSearch.Text + "&fg=1700";
                FoodItem.findNdbno(foodSearch);
                Server.Transfer("~/IndexResults.aspx");
            }

            else if (ddlCategory.SelectedIndex == 18)
            {
                foodSearch = txtSearch.Text + "&fg=1800";
                FoodItem.findNdbno(foodSearch);
                Server.Transfer("~/IndexResults.aspx");
            }

            else if (ddlCategory.SelectedIndex == 19)
            {
                foodSearch = txtSearch.Text + "&fg=1900";
                FoodItem.findNdbno(foodSearch);
                Server.Transfer("~/IndexResults.aspx");
            }

            else if (ddlCategory.SelectedIndex == 20)
            {
                foodSearch = txtSearch.Text + "&fg=2000";
                FoodItem.findNdbno(foodSearch);
                Server.Transfer("~/IndexResults.aspx");
            }

            else if (ddlCategory.SelectedIndex == 21)
            {
                foodSearch = txtSearch.Text + "&fg=2100";
                FoodItem.findNdbno(foodSearch);
                Server.Transfer("~/IndexResults.aspx");

            }

            else if (ddlCategory.SelectedIndex == 22)
            {
                foodSearch = txtSearch.Text + "&fg=2200";
                FoodItem.findNdbno(foodSearch);
                Server.Transfer("~/IndexResults.aspx");

            }

            else if (ddlCategory.SelectedIndex == 23)
            {
                foodSearch = txtSearch.Text + "&fg=2500";
                FoodItem.findNdbno(foodSearch);
            Server.Transfer("~/IndexResults.aspx");
            }

            else if (ddlCategory.SelectedIndex == 24)
            {
                foodSearch = txtSearch.Text + "&fg=3500";
                FoodItem.findNdbno(foodSearch);
            Server.Transfer("~/IndexResults.aspx");
            }

            else if (ddlCategory.SelectedIndex == 25)
            {
                foodSearch = txtSearch.Text + "&fg=3600";
                FoodItem.findNdbno(foodSearch);
                Server.Transfer("~/IndexResults.aspx");

            }
        }
    }


