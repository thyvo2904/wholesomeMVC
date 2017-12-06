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
		//private const string AntiXsrfTokenKey = "__AntiXsrfToken";
		//private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
		//private string _antiXsrfTokenValue;

		//protected void Page_Init(object sender, EventArgs e)
		//{
		//	//First, check for the existence of the Anti-XSS cookie
		//	var requestCookie = Request.Cookies[AntiXsrfTokenKey];
		//	Guid requestCookieGuidValue;

		//	//If the CSRF cookie is found, parse the token from the cookie.
		//	//Then, set the global page variable and view state user
		//	//key. The global variable will be used to validate that it matches 
		//	//in the view state form field in the Page.PreLoad method.
		//	if (requestCookie != null
		//		&& Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
		//	{
		//		//Set the global token variable so the cookie value can be
		//		//validated against the value in the view state form field in
		//		//the Page.PreLoad method.
		//		_antiXsrfTokenValue = requestCookie.Value;

		//		//Set the view state user key, which will be validated by the
		//		//framework during each request
		//		Page.ViewStateUserKey = _antiXsrfTokenValue;
		//	}
		//	//If the CSRF cookie is not found, then this is a new session.
		//	else
		//	{
		//		//Generate a new Anti-XSRF token
		//		_antiXsrfTokenValue = Guid.NewGuid().ToString("N");

		//		//Set the view state user key, which will be validated by the
		//		//framework during each request
		//		Page.ViewStateUserKey = _antiXsrfTokenValue;

		//		//Create the non-persistent CSRF cookie
		//		var responseCookie = new HttpCookie(AntiXsrfTokenKey) {
		//			//Set the HttpOnly property to prevent the cookie from
		//			//being accessed by client side script
		//			HttpOnly = true,

		//			//Add the Anti-XSRF token to the cookie value
		//			Value = _antiXsrfTokenValue
		//		};

		//		//If we are using SSL, the cookie should be set to secure to
		//		//prevent it from being sent over HTTP connections
		//		if (FormsAuthentication.RequireSSL &&
		//			Request.IsSecureConnection)
		//		{
		//			responseCookie.Secure = true;
		//		}

		//		//Add the CSRF cookie to the response
		//		Response.Cookies.Set(responseCookie);
		//	}

		//	Page.PreLoad += master_Page_PreLoad;
		//}

		//protected void master_Page_PreLoad(object sender, EventArgs e)
		//{
		//	//During the initial page load, add the Anti-XSRF token and user
		//	//name to the ViewState
		//	if (!IsPostBack)
		//	{
		//		//Set Anti-XSRF token
		//		ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;

		//		//If a user name is assigned, set the user name
		//		ViewState[AntiXsrfUserNameKey] =
		//			   Context.User.Identity.Name ?? String.Empty;
		//	}
		//	//During all subsequent post backs to the page, the token value from
		//	//the cookie should be validated against the token in the view state
		//	//form field. Additionally user name should be compared to the
		//	//authenticated users name
		//	else
		//	{
		//		//Validate the Anti-XSRF token
		//		if ((string) ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
		//			|| (string) ViewState[AntiXsrfUserNameKey] !=
		//				 (Context.User.Identity.Name ?? String.Empty))
		//		{
		//			throw new InvalidOperationException("Validation of " +
		//								"Anti-XSRF token failed.");
		//		}
		//	}
		//}

		protected void Page_Load(object sender, EventArgs e)
        {
            label_year.Text = DateTime.Now.Year.ToString();

            if (Request.IsAuthenticated) {
				// User is authenticated
				//log_in_out.NavigateUrl = "~/Manage/Index";
				//log_in_out.NavigateUrl = "javascript:document.getElementById('logoutForm').submit()";
				log_in.Visible = false;
				label_user.Text = HttpContext.Current.User.Identity.GetUserName();
                generatedToken.Value = _antiXsrfTokenValue;

                String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                try
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        SqlCommand command1 = new SqlCommand();
                        command1.Connection = connection;
                        command1.CommandType = System.Data.CommandType.Text;

                        command1.CommandText = @"
						INSERT INTO [wholesomeDB].[dbo].[Session] (
							[ID],
							[LastUpdated],
                            [LastUpdatedBy]
						) VALUES (
							@ID,
							@LastUpdated,
							@LastUpdatedBy)
					";

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
				label_user.Text = "Account";
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

		/***
		 * Generate HTML code to create a form and submit to ~/Account/Logoff to logout.
		 * Utilizing ~/Account/Logoff will prevent CSRF attacks.
		 */
		protected void LogOut(object sender, EventArgs e)
		{
			StringBuilder sbRenderOnMe = new StringBuilder();

			// the form and the data
			sbRenderOnMe.AppendFormat(@"
			<html>
				<body>
					<form action='/Account/LogOff' class='hidden' id='logoutForm' method='post'>
						<input id='tokenToSubmit' name='__RequestVerificationToken' type ='hidden' value='{0}' />
					</form>",
			AntiForgery.GetHtml());

			// the auto submit
			sbRenderOnMe.AppendFormat("<script>javascript:document.getElementById('logoutForm').submit();</script>");
			sbRenderOnMe.AppendFormat("</body></html>");

			Response.Write(sbRenderOnMe.ToString());
			Response.End();
		}
	}
}