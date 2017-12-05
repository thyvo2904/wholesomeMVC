using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace WholesomeMVC.WebForms
{
    public partial class _layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            label_year.Text = DateTime.Now.Year.ToString();

            if (Request.IsAuthenticated) {
				login.Text = "Account";
				login.NavigateUrl = "~/Manage/Index";
			}

			label_user.Text = HttpContext.Current.User.Identity.GetUserName();
		}

		protected void btnSearch(object sender, EventArgs e)
		{
			String foodSearch = "";

			if (txtSearch.Text != "")
			{
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
			} else
			{
				// show error
			}

			WebForms.FoodItem.findNdbno(foodSearch);
			Server.Transfer("/WebForms/indexresult.aspx");
		}
	}
}