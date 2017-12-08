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
using System.Configuration;

using System.Linq;
using System.Drawing;
using Microsoft.AspNet.Identity;

namespace WholesomeMVC.WebForms
{
    public partial class update_item : System.Web.UI.Page
    {

        private static double oldNRF6 = 0;

        public static DataTable matchedCeresIDS = new DataTable();
        public static DataTable dataSearchResults = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
				String strTitle = "Update Item";

				Literal page_title = (Literal) Master.FindControl("page_title");
				page_title.Text = strTitle;
				Label body_title = (Label) Master.FindControl("body_title");
				body_title.Text = strTitle;

				BindDataFromDB();
			}
            else
            {
                gridMatchedCeresIDS.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                gridMatchedCeresIDS.HeaderRow.Cells[2].Attributes["data-hide"] = "all";
                gridMatchedCeresIDS.HeaderRow.Cells[3].Attributes["data-hide"] = "all";
                gridMatchedCeresIDS.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
                gridMatchedCeresIDS.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        // This just does the USDA item search / pops up the manual input options
        protected void btnUpdateItem_Click(object sender, EventArgs e)
        {
        }

        protected void btnCalculateOld_Click(object sender, EventArgs e)
        {
        }



        protected void btnCalculateNew_Click(object sender, EventArgs e)
        {
        }

        protected void btnOldSaveItem_Click(object sender, EventArgs e)
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings["constr2"].ConnectionString;
            String gradientEntry = "";

            if (FoodItem.newFood.NRF6 <= 4.65)
            {
                gradientEntry = "1";
            }
            else if ((FoodItem.newFood.NRF6 >= 4.66) && (FoodItem.newFood.NRF6 <= 27.99))
            {
                gradientEntry = "2";
            }
            else if (FoodItem.newFood.NRF6 >= 28)
            {
                gradientEntry = "3";
            }


            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                SqlCommand command1 = new SqlCommand
                {
                    Connection = connection,
                    CommandType = System.Data.CommandType.Text,


                    CommandText = @"UPDATE Wholesome_Item SET"
                        + " nrf6 = @nrf6, Loginid = @loginid, GradientEntry = @GradientEntry,"
                        + " lastUpdatedBy = @LastUpdatedBy, LastUpdated = @LastUpdated, [description 2] = @description2, FBC_Code = @FBC_Code " +
                        "WHERE ndb_no = @ndbno"
                };
               
                command1.Parameters.Add("@nrf6", SqlDbType.Decimal, 18).Value = FoodItem.newFood.NRF6;
                command1.Parameters.Add("@loginid", SqlDbType.Int).Value = getloginid();
                command1.Parameters.Add("@GradientEntry", SqlDbType.Int).Value = gradientEntry;
                command1.Parameters.Add("@description2", SqlDbType.NVarChar, 50).Value = FoodItem.newFood.name;
                command1.Parameters.Add("@LastUpdatedBy", SqlDbType.NVarChar, 50).Value = HttpContext.Current.User.Identity.GetUserName();
                command1.Parameters.Add("@lastupdated", SqlDbType.DateTime).Value = DateTime.Now;
                command1.Parameters.Add("@ndbno", SqlDbType.NVarChar, 8).Value = FoodItem.newFood.ndbNo;
                command1.Parameters.Add("@FBC_Code", SqlDbType.NVarChar, 10).Value = ddlFBCategories.SelectedValue;
                connection.Open();
                command1.ExecuteNonQuery();
                connection.Close();
                gridMatchedCeresIDS.DataBind();
            
    


                  
                }
            }
        

        protected void btnNewSaveItem_Click(object sender, EventArgs e)
        {
        }

        protected void ceresMatchedOnRowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void gridUSDAChoices_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //check the item being bound is actually a DataRow, if it is,
            //wire up the required html events and attach the relevant JavaScripts
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] =
                    "javascript:ready();";
            }
        }

        protected void gridSearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            String ndbno = "";
            string description = ""; 
            string foodGroup = "";
           
            double ndscore = 0;
            String foodGroupNumber = "";

            String ConnectionString = ConfigurationManager.ConnectionStrings["constr2"].ConnectionString;
            if (description.Length > 48)
            {
                description = description.Substring(0, 48);
            }

            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            };
            SqlCommand command = new SqlCommand
            {
                Connection = sc,
                CommandType = System.Data.CommandType.Text
            };
            sc.Open();


            // ADD SESSION INFO
            command.CommandText = @"SELECT FdGrp_CD FROM FD_GROUP WHERE FdGrp_Desc = @FdGrp_Desc";
            command.Parameters.Add("@FdGrp_Desc", SqlDbType.NVarChar, 60).Value = foodGroup;

            SqlDataReader readIn = command.ExecuteReader();
            while (readIn.Read())
            {
                foodGroupNumber = readIn["FdGrp_CD"].ToString();
            }

            sc.Close();
            if (foodGroupNumber != "")
            {
                sc.Open();
                SqlCommand command1 = new SqlCommand
                {
                    Connection = sc,
                    CommandType = System.Data.CommandType.Text,

                    // ADD SESSION INFO
                    CommandText = @"UPDATE Wholesome_Item SET ndb_no = @ndb_no,"
                 + " FdGrp_CD = @FdGrp_CD, nrf6 = @nrf6, "
                 + "lastUpdatedBy = @LastUpdatedBy, LastUpdated = @LastUpdated, [Description 2] = @Description2 WHERE No_ = @No_"
                };


                //command1.Parameters.Add("@No_", SqlDbType.NVarChar, 20).Value = no_;
                command1.Parameters.Add("@ndb_no", SqlDbType.NVarChar, 8).Value = ndbno;
                command1.Parameters.Add("@Description2", SqlDbType.NVarChar, 50).Value = description;
                command1.Parameters.Add("@nrf6", SqlDbType.Decimal, 18).Value = ndscore;
                command1.Parameters.Add("FdGrp_CD", SqlDbType.NVarChar, 4).Value = foodGroupNumber;


                command1.Parameters.Add("@LastUpdatedBy", SqlDbType.NVarChar, 50).Value = "Charles Moore";
                command1.Parameters.Add("@Lastupdated", SqlDbType.Date).Value = DateTime.Now;



                command1.ExecuteNonQuery();
                sc.Close();
            }


            lblFBCategories.Visible = true;
            ddlFBCategories.Visible = true;
            btnSelectFBCategory.Visible = true;
        }

        protected void gridMatchedCeresIDS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void ddlChooseMethod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSelectFBCategory_Click(object sender, EventArgs e)
        {
            //String no_ = txtNumber.Text;
            String ndbno = ""; // gridUSDAChoices.SelectedRow.Cells[0].Text;
            //String ceresDescription = txtDescription.Text;
            string description = ""; // gridUSDAChoices.SelectedRow.Cells[1].Text;
           // string foodGroup = ""; // gridUSDAChoices.SelectedRow.Cells[2].Text;
            double ndscore = 0; // Double.Parse(gridUSDAChoices.SelectedRow.Cells[3].Text);
            String gradientEntry = "";

            if (ndscore <= 4.65)
            {
                gradientEntry = "1";
            }

            else if ((ndscore >= 4.66) && (ndscore <= 27.99))
            {
                gradientEntry = "2";
            }
            else if (ndscore >= 28)
            {
                gradientEntry = "3";
            }

            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            };

            sc.Open();
            SqlCommand command1 = new SqlCommand
            {
                Connection = sc,
                CommandType = System.Data.CommandType.Text,

                // ADD SESSION INFO
                CommandText = @"UPDATE Wholesome_Item SET ndb_no = @ndb_no,"
             + " FBC_Code = @FBC_Code, GradientEntry = @GradientEntry, nrf6 = @nrf6, "
             + "lastUpdatedBy = @LastUpdatedBy, LastUpdated = @LastUpdated, [Description 2] = @Description2 WHERE No_ = @No_"
            };

            //command1.Parameters.Add("@No_", SqlDbType.NVarChar, 20).Value = no_;
            command1.Parameters.Add("@GradientEntry", SqlDbType.NVarChar, 20).Value = gradientEntry;
            command1.Parameters.Add("@ndb_no", SqlDbType.NVarChar, 8).Value = ndbno;
            command1.Parameters.Add("@Description2", SqlDbType.NVarChar, 50).Value = description;
            command1.Parameters.Add("@nrf6", SqlDbType.Decimal, 18).Value = ndscore;
            command1.Parameters.Add("FBC_Code", SqlDbType.NVarChar, 10).Value = ddlFBCategories.SelectedValue;

            command1.Parameters.Add("@LastUpdatedBy", SqlDbType.NVarChar, 50).Value = "Charles Moore";
            command1.Parameters.Add("@Lastupdated", SqlDbType.Date).Value = DateTime.Now;

            command1.ExecuteNonQuery();
            sc.Close();
        }

        /***
		 * Get data from DB.
		 * Bind data to a gridview and format gridview table with footable in front-end.
		 */
        protected void BindDataFromDB()
        {
            if (!matchedCeresIDS.Columns.Contains("NDBno") &&
                !matchedCeresIDS.Columns.Contains("Name") &&
                !matchedCeresIDS.Columns.Contains("ND Score"))
            {
                matchedCeresIDS.Columns.Add("CeresID", typeof(string)); // Row 0
                matchedCeresIDS.Columns.Add("Ceres_Name", typeof(string)); // Row 1
                matchedCeresIDS.Columns.Add("USDA Number", typeof(string)); // Row 2
                matchedCeresIDS.Columns.Add("Name", typeof(string)); // Row 3
                matchedCeresIDS.Columns.Add("ND Score", typeof(double));// Row 4
            }
            else
            {
                matchedCeresIDS.Clear();
            }

            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["constr2"].ConnectionString
            };

            conn.Open();

            SqlDataReader newReader = null;
            SqlCommand newCommand = new SqlCommand(@"
				SELECT
					Wholesome_Item.No_,
					Wholesome_Item.description,
					Wholesome_item.ndb_no,
					Wholesome_item.[description 2] AS description2,
					nrf6
				FROM Wholesome_Item WHERE nrf6 IS NOT NULL", conn);
            newReader = newCommand.ExecuteReader();
            if (newReader.HasRows)
            {
                while (newReader.Read())
                {
                    DataRow row = matchedCeresIDS.NewRow();
                    row[0] = newReader["No_"].ToString();
                    row[1] = newReader["description"].ToString();
                    row[2] = newReader["ndb_no"].ToString();
                    row[3] = newReader["description2"].ToString();
                    row[4] = Double.Parse(newReader["nrf6"].ToString());

                    matchedCeresIDS.Rows.Add(row);
                }
            }

            gridMatchedCeresIDS.DataSource = matchedCeresIDS;
            gridMatchedCeresIDS.DataBind();

            gridMatchedCeresIDS.HeaderRow.Cells[2].Attributes["data-breakpoints"] = "all";
            gridMatchedCeresIDS.HeaderRow.Cells[3].Attributes["data-breakpoints"] = "all";
            gridMatchedCeresIDS.HeaderRow.Cells[4].Attributes["data-breakpoints"] = "xs";
            gridMatchedCeresIDS.HeaderRow.Cells[4].Attributes["data-type"] = "number";
            gridMatchedCeresIDS.HeaderRow.Cells[4].Attributes["class"] = "text-right";

            gridMatchedCeresIDS.HeaderRow.TableSection = TableRowSection.TableHeader;

            conn.Close();

            search_summary.Text = String.Format("Found {0} matched items", matchedCeresIDS.Rows.Count);
            view_mode.Text = String.Format("View mode");
        }
        /***
		 * Get the ndbno from a hidden field in front-end.
		 * Get data using FoodItem.findNdbno method and ndbno.
		 * Style the NR Score accordingly.
		 * Update data to modal section in front-end.
		 */
        protected void ExpandItem(object sender, EventArgs e)
        {
            // get data from front end
            string ceresid = hidden_ceresid.Value;           
            string ceres_name = hidden_ceres_name.Value;           
            string ndbno = hidden_ndbno.Value;
            string nrf6 = hidden_nrf6.Value;
			string view_mode = hidden_view_mode.Value;

            // To manage records with matched USDA items 
            if (ndbno != "")
            {
                FoodItem.findNdbno(ndbno);


                double score = FoodItem.newFood.NRF6;
                String colorScaleStyle = "background-color: ";
                if (score <= 4.65)
                {
                    colorScaleStyle += GradientColors.getColor1() + "; color: white;";
                }
                else if ((score >= 4.66) && (score <= 27.99))
                {
                    colorScaleStyle += GradientColors.getColor2() + "; color: black;";
                }
                else if (score >= 28)
                {
                    colorScaleStyle += GradientColors.getColor3() + "; color: white;";
                }
                else
                {
                    // do nothing
                }

                switch (view_mode)
                {
                    case "old":
                        nd_old_score_panel.Attributes["style"] = colorScaleStyle;

                        lblOldFoodName.Text = FoodItem.newFood.name;
                        lblOldIndexResult.Text = Convert.ToString(Math.Round(score, 2));

                        txtOldKCal.Text = FoodItem.newFood.kCal.ToString();
                        txtOldSaturatedFat.Text = Math.Round(FoodItem.newFood.satFat, 2).ToString();
                        txtOldSodium.Text = Math.Round(FoodItem.newFood.sodium, 2).ToString();
                        txtOldFiber.Text = Math.Round(FoodItem.newFood.fiber, 2).ToString();
                        txtOldTotalSugar.Text = Math.Round(FoodItem.newFood.totalSugar, 2).ToString();
                        txtOldProtein.Text = Math.Round(FoodItem.newFood.protein, 2).ToString();
                        txtOldVitaminA.Text = Math.Round((FoodItem.newFood.vitaminA / 5000) * 100).ToString();
                        txtOldVitaminC.Text = Math.Round((FoodItem.newFood.vitaminC / 60) * 100).ToString();
                        txtOldCalcium.Text = Math.Round((FoodItem.newFood.calcium / 1000) * 100).ToString();
                        txtOldIron.Text = Math.Round((FoodItem.newFood.iron / 18) * 100).ToString();
                        lblNewCeresNumber.Text = ceresid;

                        break;
                    case "new":
                        nd_new_score_panel.Attributes["style"] = colorScaleStyle;

                        lblNewFoodName.Text = FoodItem.newFood.name;
                        lblNewIndexResult.Text = Convert.ToString(Math.Round(score, 2));

                        txtNewKCal.Text = FoodItem.newFood.kCal.ToString();
                        txtNewSaturatedFat.Text = Math.Round(FoodItem.newFood.satFat, 2).ToString();
                        txtNewSodium.Text = Math.Round(FoodItem.newFood.sodium, 2).ToString();
                        txtNewFiber.Text = Math.Round(FoodItem.newFood.fiber, 2).ToString();
                        txtNewAddedSugar.Text = Math.Round(FoodItem.newFood.totalSugar, 2).ToString();
                        txtNewProtein.Text = Math.Round(FoodItem.newFood.protein, 2).ToString();
                        txtNewVitaminD.Text = Math.Round((FoodItem.newFood.vitaminA / 5000) * 100).ToString();
                        txtNewCalcium.Text = Math.Round((FoodItem.newFood.calcium / 1000) * 100).ToString();
                        txtNewIron.Text = Math.Round((FoodItem.newFood.iron / 18) * 100).ToString();
                        txtNewPotassium.Text = Math.Round((FoodItem.newFood.vitaminC / 60) * 100).ToString();
                        break;
                    default:
                        break;
                }

                // re-render bootstrap-select component
                ddlFBCategories.CssClass = "selectpicker";
                ddlFBCategories.Attributes["title"] = "Select a category";
                ddlFBCategories.Attributes["data-width"] = "100%";
                ddlFBCategories.Attributes["data-live-search"] = "true";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "rerender", "$('.selectpicker').selectpicker('render');", true);

            }

            // To manage manually inputted items
            else
            {
                double score = Double.Parse(hidden_nrf6.Value);
                String colorScaleStyle = "";
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
                colorScaleStyle = "background-color: " + colorScaleStyle;

                switch (view_mode)
                {
                    case "old":
                        nd_old_score_panel.Attributes["style"] = colorScaleStyle;
                        
                        lblOldIndexResult.Text = Convert.ToString(Math.Round(score, 2));
                        lblNewCeresNumber.Text = ceresid;

                        break;
                    case "new":
                        nd_new_score_panel.Attributes["style"] = colorScaleStyle;
                        
                        lblNewIndexResult.Text = Convert.ToString(Math.Round(score, 2));
                        break;
                    default:
                        break;
                }

                // re-render bootstrap-select component
                ddlFBCategories.CssClass = "selectpicker";
                ddlFBCategories.Attributes["title"] = "Select a category";
                ddlFBCategories.Attributes["data-width"] = "100%";
                ddlFBCategories.Attributes["data-live-search"] = "true";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "rerender", "$('.selectpicker').selectpicker('render');", true);


            }
        }

        protected void btnCalculateOldNRF6_Click(object sender, EventArgs e)
        {
            //try
            //{
            //   lblOldResult.Text = String.Empty;
            double nR6 = 0;
            double liMT = 0;
            //double NRF6 = 0;
            double kCal = Double.Parse(txtOldKCal.Text);
            double protein = Double.Parse(txtOldProtein.Text);
            double vitaminA = Double.Parse(txtOldVitaminA.Text);
            double vitaminC = Double.Parse(txtOldVitaminC.Text);
            double fiber = Double.Parse(txtOldFiber.Text);
            double calcium = Double.Parse(txtOldCalcium.Text);
            double iron = Double.Parse(txtOldIron.Text);
            double saturatedFat = Double.Parse(txtOldSaturatedFat.Text);
            double totalSugar = Double.Parse(txtOldTotalSugar.Text);
            double sodium = Double.Parse(txtOldSodium.Text);


            protein = protein / 50;
            fiber = fiber / 25;
            vitaminA = vitaminA / 5000;
            vitaminC = vitaminC / 60;
            calcium = calcium / 1000;
            iron = iron / 18;

            //if any of the good value ratios are > 1, set them equal to 1 to follow algorithm rule 
            if (protein > 1)
            {
                protein = 1;
            }

            if (fiber > 1)
            {
                fiber = 1;
            }

            if (vitaminA > 1)
            {
                vitaminA = 1;
            }

            if (vitaminC > 1)
            {
                vitaminC = 1;
            }

            if (calcium > 1)
            {
                calcium = 1;
            }

            if (iron > 1)
            {
                iron = 1;
            }



            nR6 = (protein) + (fiber) + (vitaminA) + (vitaminC) + (calcium) + (iron);
            liMT = (saturatedFat / 20) + (totalSugar / 125) + (sodium / 2400);

            FoodItem.newFood.NRF6 = (nR6 - liMT);





        }



                        

        protected String getloginid()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            String getid;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string result = "SELECT max(LoginID) FROM dbo.Session WHERE Id = '" + HttpContext.Current.User.Identity.GetUserId() + "' ";
                SqlCommand showresult = new SqlCommand(result, con);
                con.Open();
                getid = showresult.ExecuteScalar().ToString();
                con.Close();
            }
            return getid;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            String foodSearch = txtSearch.Text;
            string ceresid = hidden_ceresid.Value;
            string ceresDescription = hidden_ceres_name.Value;
            Session["sharedCeresID"] = ceresid;
            Session["sharedCeresDescription"] = ceresDescription;

            WebForms.FoodItem.findNdbno(foodSearch);
            Server.Transfer("/WebForms/indexresult.aspx");
            
        }

        protected void btnCalculateNewNRF6_Click(object sender, EventArgs e)
        {
            //try
            //{
            //   lblOldResult.Text = String.Empty;
            double nR6 = 0;
            double liMT = 0;
            //double NRF6 = 0;
            double kCal = Double.Parse(txtNewKCal.Text);
            double protein = Double.Parse(txtNewProtein.Text);
            double vitaminA = Double.Parse(txtNewVitaminD.Text);
            double vitaminC = Double.Parse(txtNewPotassium.Text);
            double fiber = Double.Parse(txtOldFiber.Text);
            double calcium = Double.Parse(txtOldCalcium.Text);
            double iron = Double.Parse(txtOldIron.Text);
            double saturatedFat = Double.Parse(txtOldSaturatedFat.Text);
            double totalSugar = Double.Parse(txtOldTotalSugar.Text);
            double sodium = Double.Parse(txtOldSodium.Text);


            protein = protein / 50;
            fiber = fiber / 25;
            vitaminA = vitaminA / 5000;
            vitaminC = vitaminC / 60;
            calcium = calcium / 1000;
            iron = iron / 18;

            //if any of the good value ratios are > 1, set them equal to 1 to follow algorithm rule 
            if (protein > 1)
            {
                protein = 1;
            }

            if (fiber > 1)
            {
                fiber = 1;
            }

            if (vitaminA > 1)
            {
                vitaminA = 1;
            }

            if (vitaminC > 1)
            {
                vitaminC = 1;
            }

            if (calcium > 1)
            {
                calcium = 1;
            }

            if (iron > 1)
            {
                iron = 1;
            }



            nR6 = (protein) + (fiber) + (vitaminA) + (vitaminC) + (calcium) + (iron);
            liMT = (saturatedFat / 20) + (totalSugar / 125) + (sodium / 2400);

            FoodItem.newFood.NRF6 = (nR6 - liMT);
        }
    }
}