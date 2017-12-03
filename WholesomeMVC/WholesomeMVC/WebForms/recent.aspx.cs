using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WholesomeMVC.WebForms
{
	public partial class recent : System.Web.UI.Page
	{
		public static int marker = 0;
		public static String[] ndbnoArray = new String[8];
		public static FoodItem[] newFoodArray = new FoodItem[8];

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

				// get data from USDA API
				if (HasNdbno) { GetDataFromUsdaApi(); }

				// render recent items dynamically
				RenderRecentItems(HasNdbno);
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
			String returnValue = string.Format(@"
				<div class='col-sm-6 col-md-4 col-lg-3'>
					<div class='panel panel-default'>
						<div class='panel-heading'>
							<h4 class='panel-title'>
								{0}
								<br />
								<br />
								<strong>ND_Score: {1}</strong>
							</h4>
						</div>

						<div class='panel-body'>
							<h4>Nutrient Facts</h4>

							<table class='table table-condensed table-hover'>
								<tr>
									<th>Calories</th>
									<td>{2}</td>
									<td></td>
								</tr>
								<tr>
									<th>Saturated Fat</th>
									<td>{3}</td>
									<td>g</td>
								</tr>
								<tr>
									<th>Sodium</th>
									<td>{4}</td>
									<td>g</td>
								</tr>
								<tr>
									<th>Dietary Fiber</th>
									<td>{5}</td>
									<td>g</td>
								</tr>
								<tr>
									<th>Total Sugars</th>
									<td>{6}</td>
									<td>g</td>
								</tr>
								<tr>
									<th>Protein</th>
									<td>{7}</td>
									<td>g</td>
								</tr>
								<tr>
									<th>Vitamin A</th>
									<td>{8}</td>
									<td>IU</td>
								</tr>
								<tr>
									<th>Vitamin C</th>
									<td>{9}</td>
									<td>IU</td>
								</tr>
								<tr>
									<th>Calcium</th>
									<td>{10}</td>
									<td>mg</td>
								</tr>
								<tr>
									<th>Iron</th>
									<td>{11}</td>
									<td>mg</td>
								</tr>
							</table>

							<button class='btn btn-success btn-block'>Save Item</button>
						</div>
					</div>
				</div>
			",
			newFoodArray[0].name.ToString(),
			newFoodArray[0].NRF6.ToString(),
			newFoodArray[0].kCal.ToString(),
			newFoodArray[0].satFat.ToString(),
			newFoodArray[0].sodium.ToString(),
			newFoodArray[0].fiber.ToString(),
			newFoodArray[0].totalSugar.ToString(),
			newFoodArray[0].protein.ToString(),
			newFoodArray[0].vitaminA.ToString(),
			newFoodArray[0].vitaminC.ToString(),
			newFoodArray[0].calcium.ToString(),
			newFoodArray[0].iron.ToString());

			return returnValue;
		}

		/***
		 * Take in an arrays of recent items.
		 * For each item, generate a string of HTML.
		 * Concatnate all strings to a string with all of recent items HTML.
		 * Render the string to a <section> with id=section_recent_items
		 *
		 * ARGS:
		 * Boolean variable that indicate if ndbnoArray has a valid value.
		 */
		protected void RenderRecentItems(Boolean HasNdbno)
		{
			String strInnerHTML = "";

			if (HasNdbno) {
				for (int i = 0; i < ndbnoArray.Length; i++) {
					strInnerHTML += "\n" + GenerateRecentItem();
				}
			} else {
				// show error
			}
			section_recent_items.InnerHtml = strInnerHTML;
		}

		/***
		 * Connect to local db using default connection.
		 * Fetch ndb_no from RECENT_INDEX table.
		 *
		 * RETURN:
		 * If there are rows in db, return true and set those data to ndbnoArray.
		 * If there is no row in db, return false.
		 */
		protected Boolean IfHasRowsSetNdbnoFromDb()
		{
			Boolean returnValue = true;
			marker = 0;
			Array.Clear(ndbnoArray, 0, ndbnoArray.Length);
			Array.Clear(newFoodArray, 0, newFoodArray.Length);

			System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection
			{
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
			if (newReader.HasRows)
			{
				int counter = 0;
				while (newReader.Read())
				{
					if (counter < ndbnoArray.Length)
					{
						ndbnoArray[counter] = newReader["ndb_no"].ToString();
						counter++;
					}
				}
			}
			else
			{
				returnValue = false;

				// hard-coded to test, remove when there're real data
				ndbnoArray[0] = "45136115";
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

		/***
		 * Use ndbnoArray to fetch data from USDA API.
		 * Set values of newFoodArray with those data.
		 */
		protected void GetDataFromUsdaApi()
		{
			String urlRequest = "";

			for (int i = 0; i < ndbnoArray.Length; i++) {
				if (ndbnoArray[i] != null) {
					if (i == 0) {
						urlRequest += ndbnoArray[i].ToString();
					} else {
						urlRequest += "&ndbno=";
						urlRequest += ndbnoArray[i].ToString();
					}
				}
			}

			String urlPartOne = "https://api.nal.usda.gov/ndb/V2/reports?ndbno=";
			String urlPartTwo = "&type=b&format=json&api_key=m37cNkiJMin6FLxPuq6wDMqtFekEJYB6HJpbLrYb";

			String url = urlPartOne + urlRequest + urlPartTwo;

			var json = new WebClient().DownloadString(url);
			var result = JsonConvert.DeserializeObject<RootObject>(json);

			for (int i = 0; i < result.foods.Count; i++) {
				FoodItem newFoodItem = new FoodItem();

				foreach (Nutrient item in result.foods[i].food.nutrients) {
					newFoodItem.name = result.foods[i].food.desc.name;

					// Good nutrients
					if (Int32.Parse(item.nutrient_id) == 203) { newFoodItem.protein = Double.Parse(item.value); }
					if (Int32.Parse(item.nutrient_id) == 291) { newFoodItem.fiber = Double.Parse(item.value); }
					if (Int32.Parse(item.nutrient_id) == 318) { newFoodItem.vitaminA = Double.Parse(item.value); }
					if (Int32.Parse(item.nutrient_id) == 401) { newFoodItem.vitaminC = Double.Parse(item.value); }
					if (Int32.Parse(item.nutrient_id) == 301) { newFoodItem.calcium = Double.Parse(item.value); }
					if (Int32.Parse(item.nutrient_id) == 303) { newFoodItem.iron = Double.Parse(item.value); }
					if (Int32.Parse(item.nutrient_id) == 208) { newFoodItem.kCal = Double.Parse(item.value); }

					// Bad nutrients
					if (Int32.Parse(item.nutrient_id) == 606) { newFoodItem.satFat = Double.Parse(item.value); }
					if (Int32.Parse(item.nutrient_id) == 269) { newFoodItem.totalSugar = Double.Parse(item.value); }
					if (Int32.Parse(item.nutrient_id) == 307) { newFoodItem.sodium = Double.Parse(item.value); }
				}

                newFoodItem.calculateNRF6();
                newFoodArray[i] = newFoodItem;
			}
		}
	}
}