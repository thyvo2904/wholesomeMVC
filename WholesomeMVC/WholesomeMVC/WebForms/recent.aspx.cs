using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WholesomeMVC.WebForms
{
	public partial class recent : System.Web.UI.Page
	{
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
							AHOLD, HARICOTS VERTS LIGHTLY SEASONED FRENCH GREEN BEANS WITH FINISHING BUTTER, UPC: 688267136344 ND_Score: 37.58
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
			for (int i = 0; i < 8; i++)
			{
				strInnerHTML += "\r\n" + GenerateRecentItem();
			}
			section_recent_items.InnerHtml = strInnerHTML;
		}
	}
}