using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WholesomeMVC.WebForms
{
	public partial class IndexResults : System.Web.UI.Page
	{
		// Counter to keep up with save id's

		public static string number;
		public static string ing;
		public static int counter = 0;
		public static DataTable dataSearchResults = new DataTable();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack)
			{
				// do nothing
			} else
			{
				// set page variables
				String strTitle = "Search Results";

				Literal page_title = (Literal) Master.FindControl("page_title");
				page_title.Text = strTitle;
				Label body_title = (Label) Master.FindControl("body_title");
				body_title.Text = strTitle;

				System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection {
					ConnectionString = ConfigurationManager.ConnectionStrings["constr2"].ConnectionString
				};

				sc.Open();

				SqlCommand myCommand = new SqlCommand("Pull_New_Ceres_Items", sc);
				myCommand.CommandType = CommandType.StoredProcedure;
				myCommand.ExecuteNonQuery();

				myCommand = new SqlCommand("Update_Ceres_Items", sc);
				myCommand.ExecuteNonQuery();

				//myCommand = new SqlCommand("Update_Wholesome_Items", sc);
				//myCommand.ExecuteNonQuery();

				sc.Close();

				gridSearchResults.DataSource = dataSearchResults;
				gridSearchResults.DataBind();
			}
		}
	}
}