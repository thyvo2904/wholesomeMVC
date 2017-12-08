using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using WholesomeMVC;
using System.Web.Services;
using System.Linq;

namespace WholesomeMVC.WebForms
{
	public partial class Farmers_Market : System.Web.UI.Page
	{
		private static DataTable dataFarmersMarketSearchResults = new DataTable();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack)
			{
				// do nothing
			} else
			{
				// set page variables
				String strTitle = "Farmers Market Finder";
				Literal page_title = (Literal) Master.FindControl("page_title");
				page_title.Text = strTitle;
				Label body_title = (Label) Master.FindControl("body_title");
				body_title.Text = strTitle;

				String strMessage = "Enter your zip code to search for a nearby farmers market!";
				lblFarmersMarket.Text = strMessage;

				google_map_section.Attributes["style"] = "display: none;";
			}
		}

		protected void btnSearchFarmersMarket_Click(object sender, EventArgs e)
		{
			String urlPartOne = "https://search.ams.usda.gov/farmersmarkets/v1/data.svc/zipSearch?zip=";
			String zip = txtFarmersMarket.Text;
			String url = urlPartOne + zip;

			var json = new WebClient().DownloadString(url);
			var result = JsonConvert.DeserializeObject<RootThing>(json);

			if (!dataFarmersMarketSearchResults.Columns.Contains("id") &&
				!dataFarmersMarketSearchResults.Columns.Contains("Market_Name"))
			{
				dataFarmersMarketSearchResults.Columns.Add("id", typeof(string));
				dataFarmersMarketSearchResults.Columns.Add("Distance", typeof(string));
				dataFarmersMarketSearchResults.Columns.Add("Market_Name", typeof(string));
			} else
			{
				dataFarmersMarketSearchResults.Clear();
			}

			foreach (FarmersMarketResult item in result.results)
			{
				DataRow row = dataFarmersMarketSearchResults.NewRow();
				row[0] = item.id.ToString();
				row[1] = item.marketname.ToString().Split(' ').First();
				row[2] = item.marketname.ToString().Substring(item.marketname.ToString().IndexOf(' ') + 1);
				dataFarmersMarketSearchResults.Rows.Add(row);
			}
			gridFarmersMarket.DataSource = dataFarmersMarketSearchResults;
			gridFarmersMarket.DataBind();

			gridFarmersMarket.HeaderRow.TableSection = TableRowSection.TableHeader;

			gridFarmersMarket.HeaderRow.Cells[1].Attributes["data-type"] = "nummber";

            search_summary.Text = String.Format("Found {0} markets near zip code {1}", gridFarmersMarket.Rows.Count, zip);
		}

		protected void gridFarmersMarket_SelectedIndexChanged(object sender, EventArgs e)
		{
			String urlPartOne = "https://search.ams.usda.gov/farmersmarkets/v1/data.svc/mktDetail?id=";
			String marketid = gridFarmersMarket.SelectedRow.Cells[0].Text;
			String marketname = gridFarmersMarket.SelectedRow.Cells[2].Text;
			String url = urlPartOne + marketid;

			var json = new WebClient().DownloadString(url);
			var result = JsonConvert.DeserializeObject<RootMarket>(json);

			String googleResult = "https://www.google.com/maps/embed/v1/place?key=AIzaSyB_YudDX76ja7-rhvRpqxGCC1--qmZLMsY&q=";
			int cutter = result.marketdetails.GoogleLink.IndexOf('=');
			String googleResultPart2 = result.marketdetails.GoogleLink.Substring(cutter + 1);

            // Using market addy for the time being as the google link returns a world map
			String googleResultFull = googleResult + result.marketdetails.Address;

			lblFarmersMarketName.Text = marketname;
			lblFarmersMarketLocation.Text = result.marketdetails.Address;
			farmersMarketIFrame.Src = System.Net.WebUtility.HtmlEncode(googleResultFull);
			//skrrt

			google_map_section.Attributes["style"] = "display: block;";
		}
	}
}