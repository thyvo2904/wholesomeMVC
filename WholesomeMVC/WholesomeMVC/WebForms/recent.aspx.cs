using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WholesomeMVC.WebForms
{
	public partial class recent : System.Web.UI.Page
	{
		public static int marker = 0;
		public static String[] ndbnoArray = new String[8];
		public static FoodItem[] newFoodArray = new FoodItem[6];

		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack) {
				// do nothing
			} else {
				// set page variables
				String strTitle = "Recent Searches";

				Literal page_title = (Literal)Master.FindControl("page_title");
				page_title.Text = strTitle;
				Label body_title = (Label)Master.FindControl("body_title");
				body_title.Text = strTitle;

				String strScaleLegend = "Color Scale Legend";

				label_color_scale_legend.Text = strScaleLegend;
				image_color_scale_legend.ImageUrl = "/Content/Images/image_color_scale_legend.png";

				String strRecentItems = "Recently Search Items";
				label_recent_items.Text = strRecentItems;

				// get ndb_no from local db
				Boolean HasNdbno = IfHasRowsSetNdbnoFromDb();

				// render recent items dynamically
				RenderRecentItems();
			}
		}

		/***
		 * Generate html code for an recent item.
		 * 
		 * RETURN:
		 * A string contains the html code.
		 * 
		 * TODO:
		 * - accept new item as input
		 */
		protected String GenerateRecentItem()
		{
			String returnValue = @"
				<div class='col-sm-6 col-md-4 col-lg-3'>
					<div class='panel panel-default'>
						<div class='panel-heading'>
							<h4 class='panel-title'>
								AHOLD, HARICOTS VERTS LIGHTLY SEASONED FRENCH GREEN BEANS WITH FINISHING BUTTER, UPC: 688267136344
								<br />
								<br />
								<strong>ND_Score: 37.58</strong>
							</h4>
						</div>

						<div class='panel-body'>
							<h4>Nutrient Facts</h4>

							<table class='table table-condensed table-hover'>
								<tr>
									<th>Calories</th>
									<td>71</td>
									<td></td>
								</tr>
								<tr>
									<th>Saturated Fat</th>
									<td>2.21</td>
									<td>g</td>
								</tr>
								<tr>
									<th>Sodium</th>
									<td>27</td>
									<td>g</td>
								</tr>
								<tr>
									<th>Dietary Fiber</th>
									<td>2.7</td>
									<td>g</td>
								</tr>
								<tr>
									<th>Total Sugars</th>
									<td>2.65</td>
									<td>g</td>
								</tr>
								<tr>
									<th>Protein</th>
									<td>1.77</td>
									<td>g</td>
								</tr>
								<tr>
									<th>Vitamin A</th>
									<td>200</td>
									<td>IU</td>
								</tr>
								<tr>
									<th>Vitamin C</th>
									<td>8</td>
									<td>IU</td>
								</tr>
								<tr>
									<th>Calcium</th>
									<td>53</td>
									<td>mg</td>
								</tr>
								<tr>
									<th>Iron</th>
									<td>0.72</td>
									<td>mg</td>
								</tr>
							</table>

							<button class='btn btn-success btn-block'>Save Item</button>
						</div>
					</div>
				</div>
			";

			return returnValue;
		}

		/***
		 * Take in an arrays of recent items.
		 * For each item, generate a string of HTML.
		 * Concatnate all strings to a string with all of recent items HTML.
		 * Render the string to a <section> with id=section_recent_items
		 */
		protected void RenderRecentItems()
		{
			String strInnerHTML = "";

			if (ndbnoArray == null) {
				// do nothing
			} else {
				for (int i = 0; i < ndbnoArray.Length; i++) {
					strInnerHTML += "\n" + GenerateRecentItem();
				}

				for (int i = 0; i < ndbnoArray.Length; i++) {
					strInnerHTML += "\n" + ndbnoArray[i];
				}
			}
			section_recent_items.InnerHtml = strInnerHTML;
		}

		/***
		 * Connect to local db using default connection.
		 * Fetch ndb_no from RECENT_INDEX table.
		 * If there are rows in db, return true and set those data to ndbnoArray.
		 * If there is no row in db, return false.
		 */
		protected Boolean IfHasRowsSetNdbnoFromDb()
		{
			Boolean returnValue = true;
			marker = 0;
			Array.Clear(ndbnoArray, 0, ndbnoArray.Length);
			Array.Clear(newFoodArray, 0, newFoodArray.Length);

			System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection {
				ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
			};

			sc.Open();

			String strCommand = @"
				SELECT NDB_NO
				FROM RECENT_INDEX
				ORDER BY SearchDate DESC
			";
			SqlCommand myCommand = new SqlCommand(strCommand, sc);

			SqlDataReader newReader = null;
			newReader = myCommand.ExecuteReader();
			if (newReader.HasRows) {
				int counter = 0;
				while (newReader.Read()) { 
					if (counter < ndbnoArray.Length) {
						ndbnoArray[counter] = newReader["ndb_no"].ToString();
						counter++;
					}
				}
			} else {
				returnValue = false;

				// hard-coded to test, remove when there're real data
				ndbnoArray[0] = "45078606";
				ndbnoArray[1] = "45186303";
				ndbnoArray[2] = "45169417";
				ndbnoArray[3] = "45169419";
				ndbnoArray[4] = "45253484";
				ndbnoArray[5] = "45169416";
				ndbnoArray[6] = "45094214";
				ndbnoArray[7] = "45156252";
				returnValue = true;
			}

			sc.Close();
			return returnValue;
		}
	}
}