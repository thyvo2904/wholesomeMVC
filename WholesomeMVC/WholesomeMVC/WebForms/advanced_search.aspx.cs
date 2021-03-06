﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WholesomeMVC.WebForms
{
    public partial class advanced_search : System.Web.UI.Page
    {
 
        string sortBy = "";
        string reportType = "";
        string searchTerms = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
             	String strTitle = "Advanced Search";

				Literal page_title = (Literal)Master.FindControl("page_title");
				page_title.Text = strTitle;
				Label body_title = (Label)Master.FindControl("body_title");
				body_title.Text = strTitle;
            }
        }

        protected void btnAdvSearch_Click(object sender, EventArgs e)
        {
            if (cbxAPI.Checked)
            {
                if (txtAdvSearch.Text != "" && ddlCategory.SelectedIndex == 0)
                {
                    searchTerms = txtAdvSearch.Text;
                }
                else if (ddlCategory.SelectedIndex == 1)
                {
                    searchTerms = txtAdvSearch.Text + "&fg=0100";
                }
                else if (ddlCategory.SelectedIndex == 2)
                {
                    searchTerms = txtAdvSearch.Text + "&fg=0200";
                }
                else if (ddlCategory.SelectedIndex == 3)
                {
                    searchTerms = txtAdvSearch.Text + "&fg=0300";
                }
                else if (ddlCategory.SelectedIndex == 4)
                {
                    searchTerms = txtAdvSearch.Text + "&fg=0400";
                }
                else if (ddlCategory.SelectedIndex == 5)
                {
                    searchTerms = txtAdvSearch.Text + "&fg=0500";
                }
                else if (ddlCategory.SelectedIndex == 6)
                {
                    searchTerms = txtAdvSearch.Text + "&fg=0600";
                }
                else if (ddlCategory.SelectedIndex == 7)
                {
                    searchTerms = txtAdvSearch.Text + "&fg=0700";
                }
                else if (ddlCategory.SelectedIndex == 8)
                {
                    searchTerms = txtAdvSearch.Text + "&fg=0800";
                }
                else if (ddlCategory.SelectedIndex == 9)
                {
                    searchTerms = txtAdvSearch.Text + "&fg=0900";
                }
                else if (ddlCategory.SelectedIndex == 10)
                {
                    searchTerms = txtAdvSearch.Text + "&fg=1000";
                }
                else if (ddlCategory.SelectedIndex == 11)
                {
                    searchTerms = txtAdvSearch.Text + "&fg=1100";
                }
                else if (ddlCategory.SelectedIndex == 12)
                {
                    searchTerms = txtAdvSearch.Text + "&fg=1200";
                }
                else if (ddlCategory.SelectedIndex == 13)
                {
                    searchTerms = txtAdvSearch.Text + "&fg=1300";
                }
                else if (ddlCategory.SelectedIndex == 14)
                {
                    searchTerms = txtAdvSearch.Text + "&fg=1400";
                }
                else if (ddlCategory.SelectedIndex == 15)
                {
                    searchTerms = txtAdvSearch.Text + "&fg=1500";
                }
                else if (ddlCategory.SelectedIndex == 16)
                {
                    searchTerms = txtAdvSearch.Text + "&fg=1600";
                }
                else if (ddlCategory.SelectedIndex == 17)
                {
                    searchTerms = txtAdvSearch.Text + "&fg=1700";
                }
                else if (ddlCategory.SelectedIndex == 18)
                {
                    searchTerms = txtAdvSearch.Text + "&fg=1800";
                }
                else if (ddlCategory.SelectedIndex == 19)
                {
                    searchTerms = txtAdvSearch.Text + "&fg=1900";
                }
                else if (ddlCategory.SelectedIndex == 20)
                {
                    searchTerms = txtAdvSearch.Text + "&fg=2000";
                }
                else if (ddlCategory.SelectedIndex == 21)
                {
                    searchTerms = txtAdvSearch.Text + "&fg=2100";
                }
                else if (ddlCategory.SelectedIndex == 22)
                {
                    searchTerms = txtAdvSearch.Text + "&fg=2200";
                }
                else if (ddlCategory.SelectedIndex == 23)
                {
                    searchTerms = txtAdvSearch.Text + "&fg=2500";
                }
                else if (ddlCategory.SelectedIndex == 24)
                {
                    searchTerms = txtAdvSearch.Text + "&fg=3500";
                }
                else if (ddlCategory.SelectedIndex == 25)
                {
                    searchTerms = txtAdvSearch.Text + "&fg=3600";
                }

                if (cbxBranded.Checked)
                {
                    reportType = "&BL";
                }
                if (cbxStandard.Checked)
                {
                    reportType = "&SR";
                }
                if (cbxFoodname.Checked)
                {
                    sortBy = "&n";
                }
                if (cbxRelevance.Checked)
                {
                    sortBy = "&r";
                }

                FoodItem.names.Clear();
                String urlPartOne = "https://api.nal.usda.gov/ndb/search/?format=json&q=";
                String urlPartTwo = "&max=50&offset=0&api_key=m37cNkiJMin6FLxPuq6wDMqtFekEJYB6HJpbLrYb";
                String url = urlPartOne + searchTerms + reportType + sortBy + urlPartTwo;

                var json = new WebClient().DownloadString(url);
                var result = JsonConvert.DeserializeObject<Search>(json);


                //for (int i = 0; i < IndexResults.dataSearchResults.Rows.Count; i++)
                //{
                if (!indexresult.dataSearchResults.Columns.Contains("NDBno") && !indexresult.dataSearchResults.Columns.Contains("Name")
                    && !indexresult.dataSearchResults.Columns.Contains("ND Score"))
                {
                    indexresult.dataSearchResults.Columns.Add("NDBno", typeof(string));
                    indexresult.dataSearchResults.Columns.Add("Name", typeof(string));
                    indexresult.dataSearchResults.Columns.Add("ND Score", typeof(double));

                }

                else
                {
                    indexresult.dataSearchResults.Clear();
                }
                //}

                //IndexResults.dataSearchResults.Columns.Add("NDBno", typeof(int));
                //IndexResults.dataSearchResults.Columns.Add("Name", typeof(string));
                //IndexResults.dataSearchResults.Columns.Add("ND Score", typeof(double));



                for (int i = 0; i < result.list.item.Count; i++)


                {

                    String ndbno = result.list.item[i].ndbno;
                    string name = result.list.item[i].name;
                    DataRow row = indexresult.dataSearchResults.NewRow();

                    row[0] = ndbno;
                    row[1] = name;



                    String food = Convert.ToString(ndbno);

                    String urlPartOne2 = "https://api.nal.usda.gov/ndb/V2/reports?ndbno=";
                    String urlPartTwo2 = "&type=b&format=json&api_key=m37cNkiJMin6FLxPuq6wDMqtFekEJYB6HJpbLrYb";




                    String url2 = urlPartOne2 + food + urlPartTwo2;

                    var json2 = new WebClient().DownloadString(url2);

                    var result2 = JsonConvert.DeserializeObject<RootObject>(json2);

                    double protein = 0;
                    double fiber = 0;
                    double vitaminA = 0;
                    double vitaminC = 0;
                    double iron = 0;
                    double sodium = 0;
                    double calcium = 0;
                    double kCal = 0;
                    double satFat = 0;
                    double totalSugar = 0;
                    double nR6 = 0;
                    double liMT = 0;
                    double NRF6 = 0;

                    // SOME OF THE NUTRIENT ID'S ARE CHANGED W/ VERSION TWO, I FIXED THEM
                    foreach (Nutrient item in result2.foods[0].food.nutrients)
                    {
                        if (Int32.Parse(item.nutrient_id) == 203)
                        {
                            protein = Double.Parse(item.value);
                        }

                        if (Int32.Parse(item.nutrient_id) == 291)
                        {
                            fiber = Double.Parse(item.value);
                        }

                        if (Int32.Parse(item.nutrient_id) == 318)
                        {
                            vitaminA = Double.Parse(item.value);

                        }
                        if (Int32.Parse(item.nutrient_id) == 401)
                        {
                            vitaminC = Double.Parse(item.value);
                        }

                        if (Int32.Parse(item.nutrient_id) == 301)
                        {
                            calcium = Double.Parse(item.value);
                        }

                        if (Int32.Parse(item.nutrient_id) == 303)
                        {
                            iron = Double.Parse(item.value);
                        }

                        if (Int32.Parse(item.nutrient_id) == 208)
                        {
                            kCal = Double.Parse(item.value);
                        }

                        if (Int32.Parse(item.nutrient_id) == 606)
                        {
                            satFat = Double.Parse(item.value);
                        }

                        if (Int32.Parse(item.nutrient_id) == 269)
                        {
                            totalSugar = Double.Parse(item.value);
                        }

                        if (Int32.Parse(item.nutrient_id) == 307)
                        {
                            sodium = Double.Parse(item.value);




                        }


                    }

                    nR6 = ((((100 / kCal) * protein / 50) + ((100 / kCal) * fiber / 25) + ((100 / kCal) * vitaminA / 5000)
                                       + ((100 / kCal) * vitaminC / 60) + ((100 / kCal) * calcium / 1000) + ((100 / kCal) * iron / 18)) * 100);

                    liMT = (((100 / kCal) * satFat / 20) + ((100 / kCal) * totalSugar / 125) + ((100 / kCal) * sodium / 2400) * 100);

                    NRF6 = nR6 - liMT;

                    NRF6 = Math.Round(NRF6, 5);
                    row[2] = NRF6;
                    indexresult.dataSearchResults.Rows.Add(row);
                }
                Server.Transfer("/WebForms/indexresult.aspx");


            }
            else if (cbxCeres.Checked)
            {
                if (txtAdvSearch.Text != "" && ddlCategory.SelectedIndex!=0)
                {
                    if (!indexresult.dataSearchResults.Columns.Contains("NDBno") && !indexresult.dataSearchResults.Columns.Contains("Name")
                        && !indexresult.dataSearchResults.Columns.Contains("ND Score"))
                    {
                        indexresult.dataSearchResults.Columns.Add("NDBno", typeof(string));
                        indexresult.dataSearchResults.Columns.Add("Name", typeof(string));
                        indexresult.dataSearchResults.Columns.Add("ND Score", typeof(double));


                        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                        {
                            System.Data.SqlClient.SqlCommand go = new System.Data.SqlClient.SqlCommand();

                            con.Open();
                            go.Connection = con;
                            go.CommandText = "SELECT ABBREV.NDB_No as NDB_No ,ABBREV.[Shrt_Desc] as Shrt_Desc, ABBREV.[NDScore] as NDScore FROM FD_GROUP" +
                                " INNER JOIN FOOD_DES ON FD_GROUP.FdGrp_CD = FOOD_DES.FdGrp_Cd " +
                                "INNER JOIN ABBREV ON FOOD_DES.NDB_No = ABBREV.NDB_No where ABBREV.Shrt_Desc like '%"+ txtAdvSearch.Text.ToString()+"%'" +
                                " and [dbo].[FD_GROUP].[FdGrp_Desc] = '" + ddlCategory.SelectedValue.ToString()+"'";
                            go.ExecuteNonQuery();

                            SqlDataReader readIn = go.ExecuteReader();
                            while (readIn.Read())
                            {
                                DataRow row = indexresult.dataSearchResults.NewRow();
                                row[0] = readIn["NDB_No"];
                                row[1] = readIn["Shrt_Desc"].ToString();
                                row[2] = readIn["NDScore"];
                                indexresult.dataSearchResults.Rows.Add(row);

                            }

                            con.Close();
                            
                        }
                    }

                }
                else if (txtAdvSearch.Text != "")
                {
                    if (!indexresult.dataSearchResults.Columns.Contains("NDBno") && !indexresult.dataSearchResults.Columns.Contains("Name")
                        && !indexresult.dataSearchResults.Columns.Contains("ND Score"))
                    {
                        indexresult.dataSearchResults.Columns.Add("NDBno", typeof(string));
                        indexresult.dataSearchResults.Columns.Add("Name", typeof(string));
                        indexresult.dataSearchResults.Columns.Add("ND Score", typeof(double));


                        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                        {
                            System.Data.SqlClient.SqlCommand go = new System.Data.SqlClient.SqlCommand();

                            con.Open();
                            go.Connection = con;
                            go.CommandText = "SELECT NDB_No, Shrt_Desc, Energ_Kcal, [Protein_(g)], " +
                                "[Fiber_TD_(g)], [Sugar_Tot_(g)], [Calcium_(mg)], [Iron_(mg)]," +
                                " [Sodium_(mg)], [Vit_C_(mg)], Vit_A_IU, [FA_Sat_(g)], NDScore FROM ABBREV where Shrt_Desc like '%" + txtAdvSearch.Text.ToString() + "%'";
                            go.ExecuteNonQuery();

                            SqlDataReader readIn = go.ExecuteReader();
                            while (readIn.Read())
                            {
                                DataRow row = indexresult.dataSearchResults.NewRow();
                                row[0] = readIn["NDB_No"];
                                row[1] = readIn["Shrt_Desc"].ToString();
                                row[2] = readIn["NDScore"];
                                indexresult.dataSearchResults.Rows.Add(row);

                            }

                            con.Close();




                        }
                    }

                }


            }
            Server.Transfer("/WebForms/indexresult.aspx");
            ddlCategory.ClearSelection();
			txtAdvSearch.Text = String.Empty;
		}
	}
}



   