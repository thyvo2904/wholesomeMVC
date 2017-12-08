using System;
using System.Web;
using System.Web.Security;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;

namespace WholesomeMVC.WebForms
{
	public partial class _layout : System.Web.UI.MasterPage
    {
		protected void Page_Load(object sender, EventArgs e)
        {
            label_year.Text = DateTime.Now.Year.ToString();
             
            if (Request.IsAuthenticated) {
				// User is authenticated
				log_in_out.NavigateUrl = "~/Manage/Index";
				log_in_out.Text = "Logout";
				label_user.Text = HttpContext.Current.User.Identity.GetUserName();

				// set authentication and authorization
				authentication.Value = "authenticated";
				authorization.Value = "";
				foreach (String role in Roles.GetRolesForUser()) {
					authorization.Value += role + "#";
				}

				register.Visible = false;

                String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                try
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        SqlCommand command1 = new SqlCommand
                        {
                            Connection = connection,
                            CommandType = System.Data.CommandType.Text,

                            CommandText = @"
							INSERT INTO [wholesomeDB].[dbo].[Session] (
								[ID],
								[LastUpdated],
								[LastUpdatedBy]
							) VALUES (
								@ID,
								@LastUpdated,
								@LastUpdatedBy)"
                        };

                        command1.Parameters.Add("@ID", SqlDbType.NVarChar, 128).Value = HttpContext.Current.User.Identity.GetUserId();
                        command1.Parameters.Add("@LastUpdated", SqlDbType.DateTime).Value = DateTime.Now;
                        command1.Parameters.Add("@LastUpdatedBy", SqlDbType.NVarChar,20).Value = HttpContext.Current.User.Identity.GetUserName();
                        
                        connection.Open();
                        command1.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                catch (Exception q)
                {
                    Console.WriteLine(q.ToString());
                }
            } else {
				// User is NOT authenticated
				log_in_out.NavigateUrl = "~/Account/Login";
				log_in_out.Text = "Login";
				label_user.Text = "Account";

				// clear authentication and authorization
				authentication.Value = "";
				authorization.Value = "";
			}
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