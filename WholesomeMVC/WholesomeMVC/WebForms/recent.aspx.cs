﻿using Microsoft.AspNet.Identity;
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

			String colorScaleStyle = "background-color: ";
			double score = newFoodArray[intItemIndex].NRF6;

            if (score <= 4.65) {
                colorScaleStyle += GradientColors.getColor1() + "; color: white;";
            } else if ((score >= 4.66) && (score <= 27.99)) {
                colorScaleStyle += GradientColors.getColor2() + "; color: black;";
            } else if (score >= 28) {
                colorScaleStyle += GradientColors.getColor3() + "; color: white;";
            } else {
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

						<div class='panel-body' style='{0}'>
							<h4><strong>ND_Score: {2}</strong></h4>
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
            //using (SqlConnection connection = new SqlConnection(ConnectionString))
            //{
            //    SqlCommand command = new SqlCommand("INSERT INTO RECENT_INDEX(NDB_NO,ID,LastUpdated,LastUpdatedBy) VALUES (@NBD_NO, @ID,@LastUpdated, @LastUpdatedby);", connection);
            //    command.Parameters.Add("@NDB_NO", SqlDbType.NVarChar, 8).Value = ndbno;
            //    command.Parameters.Add("@ID", SqlDbType.NVarChar, 128).Value = getloginid();
            //    command.Parameters.Add("@LastUpdatedBy", SqlDbType.NVarChar, 20).Value = HttpContext.Current.User.Identity.GetUserName();
            //    command.Parameters.Add("@LastUpdated", SqlDbType.DateTime, 128).Value = DateTime.Now;
            //    connection.Open();
            //    command.ExecuteNonQuery();
            //    connection.Close();
            //}
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
				SELECT        Recent_Index.ndb_no
                FROM            Recent_Index INNER JOIN
                         Session ON Recent_Index.LoginId = Session.LoginID
						 Where Session.ID = @ID
                ORDER BY Recent_Index.LastUpdated DESC
			";
			SqlCommand myCommand = new SqlCommand(strCommand, sc);
            if (HttpContext.Current.User.IsInRole("Admin")|| HttpContext.Current.User.IsInRole("Purchasing_Staff")|| HttpContext.Current.User.IsInRole("Warehouse_Staff"))
                myCommand.Parameters.Add("@ID", SqlDbType.NVarChar,128).Value = HttpContext.Current.User.Identity.GetUserId();
            else
                myCommand.Parameters.Add("@ID", SqlDbType.NVarChar, 128).Value = DBNull.Value;

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

       
    }
}