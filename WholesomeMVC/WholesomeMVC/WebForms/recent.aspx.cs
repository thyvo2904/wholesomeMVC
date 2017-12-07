using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WholesomeMVC.WebForms
{
	public partial class recent : System.Web.UI.Page
	{
		private const int SIZE_OF_ARRAY = 8;
		public static int marker = 0;
		public static String[] ndbnoArray = new String[SIZE_OF_ARRAY];
		public static FoodItem[] newFoodArray = new FoodItem[SIZE_OF_ARRAY];

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

				//String strScaleLegend = "Color Scale Legend";

				//label_color_scale_legend.Text = strScaleLegend;
				//image_color_scale_legend.ImageUrl = "/Content/Images/image_color_scale_legend.png";

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
		 * ARGS:
		 * Accept item index in newFoodArray as input.
		 * 
		 * RETURN:
		 * A string contains the html code for the item with input index.
		 */
		protected String GenerateRecentItem(int intItemIndex)
		{
			String returnValue = "";
			String colorScaleStyle = "";

			double score = newFoodArray[intItemIndex].NRF6;
            if (score <= 4.65)
            {
                colorScaleStyle = GradientColors.getColor1();
            }

            else if ((score >= 4.66) && (score <= 27.99))
            {
                colorScaleStyle = GradientColors.getColor2();
            }
            else if (score >= 28)
            {
                colorScaleStyle = GradientColors.getColor3();
            }
            else
            {
                // do nothing
            }

            returnValue = String.Format(@"
				<div class='col-sm-6 col-md-4 col-lg-3'>
					<div class='panel panel-default'>
						<div class='panel-heading'>
							<h4 class='panel-title equal-height'>
								{1}
							</h4>
						</div>

						<div class='panel-body' style='background-color: {0};'>
							<h4><strong>ND_Score: <span style='color: {0};'>{2}</span></strong></h4>
						</div>

						<div class='panel-body'>
							<h4><strong>Nutrition Facts</strong></h4>
							<table class='table table-condensed table-hover'>
								<tbody>
									<tr class='fatter'>
										<th>Calories</th>
										<td>{3}</td>
										<td></td>
									</tr>
									<tr class='fat'>
										<th>Saturated Fat</th>
										<td>{4}</td>
										<td>g</td>
									</tr>
									<tr>
										<th>Sodium</th>
										<td>{5}</td>
										<td>g</td>
									</tr>
									<tr>
										<th>Dietary Fiber</th>
										<td>{6}</td>
										<td>g</td>
									</tr>
									<tr>
										<th>Total Sugars</th>
										<td>{7}</td>
										<td>g</td>
									</tr>
									<tr>
										<th>Protein</th>
										<td>{8}</td>
										<td>g</td>
									</tr>
									<tr class='fatter'>
										<th>Vitamin A</th>
										<td>{9}</td>
										<td>IU</td>
									</tr>
									<tr>
										<th>Vitamin C</th>
										<td>{10}</td>
										<td>IU</td>
									</tr>
									<tr>
										<th>Calcium</th>
										<td>{11}</td>
										<td>mg</td>
									</tr>
									<tr>
										<th>Iron</th>
										<td>{12}</td>
										<td>mg</td>
									</tr>
								</tbody>
							</table>

							<button id='{13}' class='btn btn-default btn-block save-button'>Save Item</button>
						</div>
					</div>
				</div>
			",
			colorScaleStyle,
			newFoodArray[intItemIndex].name.ToString(),
			newFoodArray[intItemIndex].NRF6.ToString(),
			newFoodArray[intItemIndex].kCal.ToString(),
			newFoodArray[intItemIndex].satFat.ToString(),
			newFoodArray[intItemIndex].sodium.ToString(),
			newFoodArray[intItemIndex].fiber.ToString(),
			newFoodArray[intItemIndex].totalSugar.ToString(),
			newFoodArray[intItemIndex].protein.ToString(),
			newFoodArray[intItemIndex].vitaminA.ToString(),
			newFoodArray[intItemIndex].vitaminC.ToString(),
			newFoodArray[intItemIndex].calcium.ToString(),
			newFoodArray[intItemIndex].iron.ToString(),
			intItemIndex.ToString());

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
				for (int i = 0; i < newFoodArray.Length; i++) {
					if (newFoodArray[i] == null) {
						// do nothing
					} else { 
						strInnerHTML += "\n" + GenerateRecentItem(i);
					}
				}
			} else {
				// show error
			}

			section_recent_items.InnerHtml = strInnerHTML;

			object x = Master.FindControl("button_1");
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
				ORDER BY LastUpdated DESC
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
			}

			sc.Close();

			//// hard-coded to test, remove when there're real data
			//ndbnoArray[0] = "45136115";
			//ndbnoArray[1] = "45186303";
			//ndbnoArray[2] = "45169417";
			//ndbnoArray[3] = "45169419";
			//ndbnoArray[4] = "45253484";
			//ndbnoArray[5] = "45169416";
			//ndbnoArray[6] = "45094214";
			//ndbnoArray[7] = "45156252";
			//returnValue = true;

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
					newFoodItem.ndbNo = result.foods[i].food.desc.ndbno;

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

		/***
		 * Save item to SavedItems table.
		 */
		protected void SaveItem(object sender, EventArgs e)
		{
			int intItemIndex = int.Parse(hidden_item_index.Value);

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
						INSERT INTO [wholesomeDB].[dbo].[SavedItems] (
							[ndb_no],
							[name],
							[ND_Score],
							[saved by],
							[date saved]
						) VALUES (
							@ndb_no,
							@name,
							@NRF6,
							@savedby,
							@savedate)
					"
                    };

                    command1.Parameters.Add("@ndb_no", SqlDbType.NVarChar, 8).Value = newFoodArray[intItemIndex].ndbNo;
					command1.Parameters.Add("@name", SqlDbType.NVarChar, 500).Value = newFoodArray[intItemIndex].name;
					command1.Parameters.Add("@NRF6", SqlDbType.Decimal).Value = newFoodArray[intItemIndex].NRF6;
					command1.Parameters.Add("@savedby", SqlDbType.VarChar, 50).Value = "Nathan Hamrick";
					command1.Parameters.Add("@savedate", SqlDbType.Date).Value = DateTime.Now;

					connection.Open();
					command1.ExecuteNonQuery();
					connection.Close();
				}

				success_message.Value = String.Format("Successfully saved {0}", newFoodArray[intItemIndex].name);
			} catch (Exception q)
			{
				error_message.Value = String.Format("{0} is already saved!", newFoodArray[intItemIndex].name);
				Console.WriteLine(q.ToString());
			}
		}
	}
}