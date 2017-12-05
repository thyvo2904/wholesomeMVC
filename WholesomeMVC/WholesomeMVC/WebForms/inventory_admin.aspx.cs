using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WholesomeMVC.WebForms;

namespace WholesomeMVC.WebForms
{
	public partial class inventory_admin : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack) {
				// do nothing
			} else {
				//System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection
				//{
				//    ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
				//};

				//sc.Open();
				//SqlCommand myCommand = new SqlCommand("Pull_Ceres_Weight",sc);
				//myCommand.CommandType = CommandType.StoredProcedure;
				//myCommand.ExecuteNonQuery();
				//sc.Close();

				// set up page
				String strTitle = "Inventory Admin";

				Literal page_title = (Literal) Master.FindControl("page_title");
				page_title.Text = strTitle;
				Label body_title = (Label) Master.FindControl("body_title");
				body_title.Text = strTitle;

				String strChart1Header = "Purchased Item Overview";
				chart_1_header.Text = strChart1Header;
				String strChart2Header = "Inventory Overview";
				chart_2_header.Text = strChart2Header;
			}

		}
	}
}