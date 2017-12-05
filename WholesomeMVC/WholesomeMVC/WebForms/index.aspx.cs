﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WholesomeMVC.WebForms
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (IsPostBack) {
				// do nothing
			} else {
				// set page variable
				String strTitle = "Home";

				Literal page_title = (Literal)Master.FindControl("page_title");
				page_title.Text = strTitle;

				banner_message.Text = @"
					Using Wholesome, you can quickly find out the different nutritional values of your 
                    food options and decide for yourself what works for you and your needs.

                ";

				image_nutrient_calculator.ImageUrl = "/Content/Images/icons8-calculator-100.png";
				link_nutrient_calculator.NavigateUrl = "manual_input.aspx";
				link_nutrient_calculator.Text = "Nutrient Calculator";

				image_recent.ImageUrl = "/Content/Images/icons8-time-machine-100.png";
				link_recent.NavigateUrl = "recent.aspx";
				link_recent.Text = "Recent";

				image_saved_items.ImageUrl = "/Content/Images/icons8-save-100.png";
				link_saved_items.NavigateUrl = "Comparison.aspx";
				link_saved_items.Text = "Comparison";
			}       
        }

        protected void btnSearch(object sender, EventArgs e)
        {
			String foodSearch = "";

			if (txtSearch.Text != "") {
				switch (ddlCategory.SelectedIndex)
				{
					case 0: foodSearch = txtSearch.Text; break;
					case 1: foodSearch = txtSearch.Text + "&fg=0100"; break;
					case 2: foodSearch = txtSearch.Text + "&fg=0200"; break;
					case 3: foodSearch = txtSearch.Text + "&fg=0300"; break;
					case 4: foodSearch = txtSearch.Text + "&fg=0400"; break;
					case 5: foodSearch = txtSearch.Text + "&fg=0500"; break;
					case 6: foodSearch = txtSearch.Text + "&fg=0600"; break;
					case 7: foodSearch = txtSearch.Text + "&fg=0700"; break;
					case 8: foodSearch = txtSearch.Text + "&fg=0800"; break;
					case 9: foodSearch = txtSearch.Text + "&fg=0900"; break;
					case 10: foodSearch = txtSearch.Text + "&fg=1000"; break;
					case 11: foodSearch = txtSearch.Text + "&fg=1100"; break;
					case 12: foodSearch = txtSearch.Text + "&fg=1200"; break;
					case 13: foodSearch = txtSearch.Text + "&fg=1300"; break;
					case 14: foodSearch = txtSearch.Text + "&fg=1400"; break;
					case 15: foodSearch = txtSearch.Text + "&fg=1500"; break;
					case 16: foodSearch = txtSearch.Text + "&fg=1600"; break;
					case 17: foodSearch = txtSearch.Text + "&fg=1700"; break;
					case 18: foodSearch = txtSearch.Text + "&fg=1800"; break;
					case 19: foodSearch = txtSearch.Text + "&fg=1900"; break;
					case 20: foodSearch = txtSearch.Text + "&fg=2000"; break;
					case 21: foodSearch = txtSearch.Text + "&fg=2100"; break;
					case 22: foodSearch = txtSearch.Text + "&fg=2200"; break;
					case 23: foodSearch = txtSearch.Text + "&fg=2500"; break;
					case 24: foodSearch = txtSearch.Text + "&fg=3500"; break;
					case 25: foodSearch = txtSearch.Text + "&fg=3600"; break;
					default: break;
				}
			} else {
				// show error
			}
            
			FoodItem.findNdbno(foodSearch);
			Server.Transfer("/WebForms/indexresult.aspx");
		}
    }
}