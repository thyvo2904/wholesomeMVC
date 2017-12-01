using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WholesomeMVC
{
    public partial class index : System.Web.UI.Page
    {
        public static string foodSearch;

        protected void Page_Load(object sender, EventArgs e)
        {
            // set page variable
            String strTitle = "Home";
            page_title.Text = strTitle;

            banner_message.Text = @"
                Wholesome can quickly find out the different nutritional values of your food options.
                It's time to decide what works best for you yourself!
            ";

            image_nutrient_calculator.ImageUrl = "/Content/Images/icons8-calculator-100.png";
            link_nutrient_calculator.NavigateUrl = "manual_input.aspx";
            link_nutrient_calculator.Text = "Nutrient Calculator";

            image_recent.ImageUrl = "/Content/Images/icons8-time-machine-100.png";
            link_recent.NavigateUrl = "recent.aspx";
            link_recent.Text = "Recent";

            image_saved_items.ImageUrl = "/Content/Images/icons8-check-file-100.png";
            link_saved_items.NavigateUrl = "saved_items.aspx";
            link_saved_items.Text = "Saved Items";
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
}