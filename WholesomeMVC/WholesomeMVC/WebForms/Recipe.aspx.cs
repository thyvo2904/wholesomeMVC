using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WholesomeMVC.WebForms
{
	public partial class Recipe : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                // do nothing
            }
            else
            {
                // set page variable
                String strTitle = "Recipe Search";

                Literal page_title = (Literal)Master.FindControl("page_title");
                page_title.Text = strTitle;

                banner_message.Text = @"
					Search for a recipe!
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
        }

        protected void btnSearch(object sender, EventArgs e)
        {
            String foodSearch = "";

            if (txtSearch.Text != "")
            {
               
            }
            else
            {
                // show error
            }

            FoodItem.findNdbno(foodSearch);
            Server.Transfer("/WebForms/indexresult.aspx");
        }
    }
}