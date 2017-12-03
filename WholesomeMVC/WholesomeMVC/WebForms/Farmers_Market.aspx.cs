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

namespace WholesomeMVC.WebForms
{
    public partial class Farmers_Market : System.Web.UI.Page
    {
        private static DataTable dataFarmersMarketSearchResults = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearchFarmersMarket_Click(object sender, EventArgs e)
        {
            String urlPartOne = "https://search.ams.usda.gov/farmersmarkets/v1/data.svc/zipSearch?zip=";
            String zip = txtFarmersMarket.Text;


            String url = urlPartOne + zip;

            var json = new WebClient().DownloadString(url);



            var result = JsonConvert.DeserializeObject<RootThing>(json);

            if (!dataFarmersMarketSearchResults.Columns.Contains("id") && !dataFarmersMarketSearchResults.Columns.Contains("Market_Name"))
            {
                dataFarmersMarketSearchResults.Columns.Add("id", typeof(string));
                dataFarmersMarketSearchResults.Columns.Add("Market_Name", typeof(string));
                

            }

            else
            {
                dataFarmersMarketSearchResults.Clear();
            }

            foreach (FarmersMarketResult item in result.results)
            {
                DataRow row = dataFarmersMarketSearchResults.NewRow();
                row[0] = item.id.ToString();
                row[1] = item.marketname.ToString();
                dataFarmersMarketSearchResults.Rows.Add(row);
            }
            gridFarmersMarket.DataSource = dataFarmersMarketSearchResults;
            gridFarmersMarket.DataBind();

        }

        protected void gridFarmersMarket_SelectedIndexChanged(object sender, EventArgs e)
        {
            String urlPartOne = "https://search.ams.usda.gov/farmersmarkets/v1/data.svc/mktDetail?id=";
            String market = gridFarmersMarket.SelectedRow.Cells[0].Text;


            String url = urlPartOne + market;

            var json = new WebClient().DownloadString(url);



            var result = JsonConvert.DeserializeObject<RootMarket>(json);
            String googleResult = "http://www.google.com/maps/embed/v1/place?key=AIzaSyB_YudDX76ja7-rhvRpqxGCC1--qmZLMsY&q=";
            int cutter = result.marketdetails.GoogleLink.IndexOf('=');
            String googleResultPart2 = result.marketdetails.GoogleLink.Substring(cutter +1);

            String googleResultFull = googleResult + googleResultPart2;

            lblFarmersMarketLocation.Text = result.marketdetails.Address;
            farmersMarketIFrame.Src = googleResultFull;
            //skrrt

        }

        protected void btnSearch(object sender, EventArgs e)
        {


            if (txtSearch.Text != "")
            {
                String foodSearch = "";
                foodSearch = txtSearch.Text;
                FoodItem.findNdbno(foodSearch);
                Response.Redirect("~/IndexResults.aspx");
            }

            else
            {
                Response.Write("<script>alert('Please enter a value');</script>");
            }


        }

    }
}