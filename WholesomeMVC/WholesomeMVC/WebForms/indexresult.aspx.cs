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
	public partial class indexresult : System.Web.UI.Page
	{
        // Counter to keep up with save id's
        public static String savedNdb_no = "";
        public static String savedItemName = "";
        public static double savedNrf6 = 0;
        public static String savedFoodGroup = "";

        public static string number;
		public static string ing;
		public static int counter = 0;
		public static DataTable dataSearchResults = new DataTable();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack)
			{
                
            } else
			{
				// set page variables
				String strTitle = "Search Results";

				Literal page_title = (Literal) Master.FindControl("page_title");
				page_title.Text = strTitle;
				Label body_title = (Label) Master.FindControl("body_title");
				body_title.Text = strTitle;

				BindDataFromDB();
            }
		}

		protected void BindDataFromDB()
		{
			System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection {
				ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
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

			search_summary.Text = String.Format("Found {0} items", dataSearchResults.Rows.Count);
			filter_applied.Text = String.Format("Filter applied: {0}", "none");

			String strHTML = "";
			foreach (DataRow row in dataSearchResults.Rows) {
				strHTML += GenerateHtmlForEachItem(row);
			}

			search_results.InnerHtml = strHTML;
		}

		/***
		 * Take a data row (aka item) of the result set as argument.
		 * Generate a string contains a snippet of HTML code and the item's name and score.
		 * Style the foreground color of the score and the background color of the expand button.
		 * Return generated string.
		 */
		protected String GenerateHtmlForEachItem(DataRow item)
		{
			String returnValue = "";
			String colorScaleStyle = "";
			double score = double.Parse(item["ND Score"].ToString());

			if (score < 0) {
				colorScaleStyle = GradientColors.getColor1();
			} else if ((score >= 0) && (score <= 2.33)) {
				colorScaleStyle = GradientColors.getColor2();
			} else if ((score > 2.33) && (score <= 4.66)) {
				colorScaleStyle = GradientColors.getColor3();
			} else if ((score > 4.66) && (score <= 12.44)) {
				colorScaleStyle = GradientColors.getColor4();
			} else if ((score > 12.44) && (score <= 20.22)) {
				colorScaleStyle = GradientColors.getColor5();
			} else if ((score > 20.22) && (score <= 28)) {
				colorScaleStyle = GradientColors.getColor6();
			} else if ((score > 28) && (score <= 35.33)) {
				colorScaleStyle = GradientColors.getColor7();
			} else if ((score > 35.33) && (score <= 42.67)) {
				colorScaleStyle = GradientColors.getColor8();
			} else if (score > 42.67) {
				colorScaleStyle = GradientColors.getColor9();
			} else {
				// do nothing
			}

			colorScaleStyle += " !important";

			returnValue = String.Format(@"
				<div class='col-sm-6 col-md-4 col-lg-3'>
					<div class='panel panel-default' style='border-color: {2};'>
						<div class='panel-body'>
							<h4 class='panel-title equal-height'>{0}</h4>
							<h4><strong>ND_Score: <span style='color: {2};'>{1}<span></strong></h4>
							<button class='btn btn-default btn-block'>Expand</button>
						</div>
					</div>
				</div>
			",
			item["name"].ToString(),
			item["ND score"].ToString(),
			colorScaleStyle);

			return returnValue;
		}
	}
}