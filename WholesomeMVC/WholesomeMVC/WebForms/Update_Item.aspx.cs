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

namespace WholesomeMVC.WebForms
{
    public partial class Update_Item : System.Web.UI.Page
    {
        public static DataTable matchedCeresIDS = new DataTable();
        public static DataTable dataSearchResults = new DataTable();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack) {
				//if (indexresult.number != "") {
				//	//txtNumber.Text = indexresult.number;
				//}

				//if (FoodItem.getCeresID() != "" || FoodItem.getDescription() != "") {
				//	//txtNumber.Text = FoodItem.getCeresID();
				//	//txtDescription.Text = FoodItem.getDescription();
				//	FoodItem.clearCeresData();
				//}

				//	//string ConnectString = ConfigurationManager.ConnectionStrings["constr2"].ConnectionString;
				//	//string QueryString = "select No_ + ' ' + description AS itemdescription from wholesome_item WHERE nrf6 IS NOT NULL";

				//	//SqlConnection myConnection = new SqlConnection(ConnectString);
				//	//SqlDataAdapter myCommand = new SqlDataAdapter(QueryString, myConnection);
				//	//DataSet ds = new DataSet();
				//	//myCommand.Fill(ds, "wholesome_item");

				//	//ddlMatchedCeresID.DataSource = ds;
				//	//ddlMatchedCeresID.DataTextField = "itemdescription";
				//	//ddlMatchedCeresID.DataValueField = "itemdescription";
				//	//ddlMatchedCeresID.DataBind();

				//	System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection {
				//		ConnectionString = ConfigurationManager.ConnectionStrings["constr2"].ConnectionString
				//	};

				//	sc.Open();

				//	SqlCommand myCommand = new SqlCommand("Pull_New_Ceres_Items", sc);
				//	myCommand.CommandType = CommandType.StoredProcedure;

				//	myCommand.ExecuteNonQuery();

				//	myCommand = new SqlCommand("Update_Ceres_Items", sc);
				//	myCommand.ExecuteNonQuery();

				//	//myCommand = new SqlCommand("Update_Wholesome_Items", sc);
				//	//myCommand.ExecuteNonQuery();

				//	sc.Close();
				
				// set page variables
				String strTitle = "Update Item";

				Literal page_title = (Literal) Master.FindControl("page_title");
				page_title.Text = strTitle;
				Label body_title = (Label) Master.FindControl("body_title");
				body_title.Text = strTitle;

				BindDataFromDB();
			} else {
				if (!String.IsNullOrEmpty(txtNewAddedSugar.Text) && !String.IsNullOrEmpty(txtNewFiber.Text)) {
					divnew.Style.Add("display", "block");
					divold.Style.Add("display", "none");
					DropDownList2.SelectedIndex = 2;
				} else if (!String.IsNullOrEmpty(txtOldCalcium.Text) && !String.IsNullOrEmpty(txtOldIron.Text)) {
					divold.Style.Add("display", "block");
					divnew.Style.Add("display", "none");
					DropDownList2.SelectedIndex = 1;
				}

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
            //using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr2"].ConnectionString))
            //{
            //    System.Data.SqlClient.SqlCommand go = new System.Data.SqlClient.SqlCommand();
            //    Boolean findCeresID = false;
            //    con.Open();
            //    go.Connection = con;
            //    go.CommandText = "SELECT No_ FROM Wholesome_Item WHERE No_ = @No_";
            //    //go.Parameters.Add("@No_", SqlDbType.NVarChar, 20).Value = txtNumber.Text;

            //    SqlDataReader readIn = go.ExecuteReader();
            //    while (readIn.Read())
            //    {
            //        findCeresID = true;
            //    }

            //    con.Close();

                //if (findCeresID == true)
                //{
                    String foodSearch = txtSearchDescription.Text;
                    FoodItem.findNdbnoUpdateItem(foodSearch);
            BindDataFromDB();
            //gridUSDAChoices.DataSource = Update_Item.dataSearchResults;
            //gridUSDAChoices.DataBind();
            //    }

            //    else
            //    {
            //        Response.Write("<script>alert('Please enter a valid Ceres ID!');</script>");
            //    }
            //}
        }

        protected void btnCalculateOld_Click(object sender, EventArgs e)
        {
            try
            {
                lblOldResult.Text = String.Empty;
                double nR6;
                double liMT;
                double NRF6;
                //this.nR6 = ((((100 / kCal) * protein / 50) + ((100 / kCal) * fiber / 25) + ((100 / kCal) * vitaminA / 5000)
                //       + ((100 / kCal) * vitaminC / 60) + ((100 / kCal) * calcium / 1000) + ((100 / kCal) * iron / 18)) * 100);

                //this.liMT = (((100 / kCal) * satFat / 20) + ((100 / kCal) * totalSugar / 125) + ((100 / kCal) * sodium / 2400) * 100);

                //DV for Vitamin A: 5000UI
                //DV for Vitamin C: 60mg
                //DV for Iron: 18mg
                //DV for Calcium: 1000mg
                //DV for potassium: 4700mg
                //Conversion: 1IU = 0.025mcg
                double kCal = (Double.Parse(txtOldKCal.Text));


                double calcium = (((Double.Parse(txtOldCalcium.Text.Trim())) / 100) * 1000);
                double vitA = (((Double.Parse(txtOldVA.Text.Trim()) / 100)) * 5000);
                double vitC = (((Double.Parse(txtOldVC.Text.Trim())) / 100) * 60);
                double protein = (Double.Parse(txtOldProtein.Text));
                double fiber = (Double.Parse(txtOldFiber.Text));
                double satFat = (Double.Parse(txtOldSatFat.Text));
                double sugar = (Double.Parse(txtOldTotalSugar.Text));
                double sodium = (Double.Parse(txtOldSodium.Text));
                double iron = (((Double.Parse(txtOldIron.Text.Trim())) / 100) * 18);


                nR6 = ((((100 / kCal) * protein / 50) + ((100 / kCal) * fiber / 25) + ((100 / kCal) * vitA / 5000)
                           + ((100 / kCal) * vitC / 60) + ((100 / kCal) * calcium / 1000) + ((100 / kCal) * iron / 18)) * 100);

                liMT = (((100 / kCal) * satFat / 20) + ((100 / kCal) * sugar / 125) + ((100 / kCal) * sodium / 2400) * 100);

                NRF6 = Math.Round(nR6 - liMT, 5);
                lblOldResult.Text = Convert.ToString(NRF6);

                if (txtOldKCal.Text.Equals(0))
                {
                    lblOldResult.Text = "Uncategorized";
                    lblOldResult.Attributes["style"] = "font-weight:bold;text-align: center; font-size: 110%";
                }
                else if (NRF6 < 4.66)
                {
                    lblOldResult.Attributes["style"] = "color:red; font-weight:bold;text-align: center; font-size: 110%";
                }
                else if ((NRF6 >= 4.66) && (NRF6 <= 28))
                {
                    lblOldResult.Attributes["style"] = "color:yellow; font-weight:bold;background: black;text-align: center; font-size: 110%";
                }
                else if (NRF6 > 28)
                {
                    lblOldResult.Attributes["style"] = "color:green; font-weight:bold;text-align: center; font-size: 110%";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Please enter a valid value');</script>");
            }
        }

        protected void btnCalculateNew_Click(object sender, EventArgs e)
        {
            try
            {
                lblNewResult.Text = String.Empty;
                double nR6;
                double liMT;
                double NRF6;

                //DV for Vitamin A: 5000UI
                //DV for Vitamin C: 60mg
                //DV for Iron: 18mg
                //DV for Calcium: 1000mg
                //DV for potassium: 4700mg
                //Conversion: 1IU = 0.025mcg
                double iron = Double.Parse(txtNewIron.Text);
                double calcium = Double.Parse(txtNewCalcium.Text);
                double kCal = Double.Parse(txtNewKCal.Text);
                double protein = Double.Parse(txtNewProtein.Text);
                double fiber = Double.Parse(txtNewFiber.Text);
                double satFat = Double.Parse(txtNewSatFat.Text);
                double sodium = Double.Parse(txtNewSodium.Text);
                double vitD = Double.Parse(txtNewVD.Text) / 0.025;
                double potassium = Double.Parse(txtNewPotassium.Text);
                double addedsugar = Double.Parse(txtNewAddedSugar.Text);

                //new
                nR6 = ((((100 / kCal) * protein / 50) + ((100 / kCal) * fiber / 25) + ((100 / kCal) * vitD / 600)
                          + ((100 / kCal) * potassium / 4700) + ((100 / kCal) * calcium / 1000) + ((100 / kCal) * iron / 18)) * 100);

                liMT = (((100 / kCal) * satFat / 20) + ((100 / kCal) * addedsugar / 50) + ((100 / kCal) * sodium / 2400) * 100);




                NRF6 = Math.Round(nR6 - liMT, 5);
                lblNewResult.Text = Convert.ToString(NRF6);

                if (txtNewKCal.Text.Equals(0))
                {
                    lblNewResult.Text = "Uncategorized";
                    lblNewResult.Attributes["style"] = "font-weight:bold;text-align: center; font-size: 110%";
                }
                else if (NRF6 < 4.66)
                {
                    lblNewResult.Attributes["style"] = "color:red; font-weight:bold;text-align: center; font-size: 110%";
                }
                else if ((NRF6 >= 4.66) && (NRF6 <= 28))
                {
                    lblNewResult.Attributes["style"] = "color:yellow; font-weight:bold;background: black;text-align: center; font-size: 110%";
                }
                else if (NRF6 > 28)
                {
                    lblNewResult.Attributes["style"] = "color:green; font-weight:bold;text-align: center; font-size: 110%";
                }
                else
                {
                    lblNewResult.Text = "Uncategorized";
                    lblNewResult.Attributes["style"] = "font-weight:bold;text-align: center; font-size: 110%";
                }
            }
            catch (Exception ei)
            {
                Response.Write("<script>alert('Please enter a valid value');</script>");
            }
        }

        protected void btnOldSaveItem_Click(object sender, EventArgs e)
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings["constr2"].ConnectionString;



            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                {
                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandType = System.Data.CommandType.Text;

                    //String description = txtDescription.Text;

                    //if (description.Length > 48)
                    //{
                    //    description = description.Substring(0, 48);
                    //}

                    // UPDATE Wholesome_Item SET No_ = , ndb_no = , Description = , Long_Desc = ,
                    // protein = , fiber = , vitaminA = , vitaminC = , vitaminD = , Potassium = ,
                    // calcium = , iron = , saturatedFat = , TotalSugar = , AddedSugar = , Sodium = ,
                    // KCal = , nrf6 = , lastUpdatedBy = , LastUpdated = WHERE No_ = 
                    command1.CommandText = @"UPDATE Wholesome_Item SET ndb_no = @ndb_no,"
                    + " Description = @Description, nrf6 = @nrf6, Loginid = @loginid"
                    + " lastUpdatedBy = @LastUpdatedBy, LastUpdated = @LastUpdated WHERE No_ = @No_";


                    //command1.Parameters.Add("@No_", SqlDbType.NVarChar, 20).Value = txtNumber.Text;
                    command1.Parameters.Add("@ndb_no", SqlDbType.VarChar, 8).Value = "";
                    //command1.Parameters.Add("@Description", SqlDbType.NVarChar, 50).Value = description;
                    command1.Parameters.Add("@Long_Desc", SqlDbType.NVarChar, 500).Value = "";
                    command1.Parameters.Add("@protein", SqlDbType.Decimal, 18).Value = txtOldProtein.Text;
                    command1.Parameters.Add("@fiber", SqlDbType.Decimal, 18).Value = txtOldFiber.Text;
                    command1.Parameters.Add("@vitaminA", SqlDbType.Decimal, 18).Value = txtOldVA.Text;
                    command1.Parameters.Add("@vitaminC", SqlDbType.Decimal, 18).Value = txtOldVC.Text;
                    command1.Parameters.Add("@vitaminD", SqlDbType.Decimal, 18).Value = 0;
                    command1.Parameters.Add("@Potassium", SqlDbType.Decimal, 18).Value = 0;
                    command1.Parameters.Add("@Calcium", SqlDbType.Decimal, 18).Value = txtOldCalcium.Text;
                    command1.Parameters.Add("@Iron", SqlDbType.Decimal, 18).Value = txtOldIron.Text;
                    command1.Parameters.Add("@saturatedFat", SqlDbType.Decimal, 18).Value = txtOldSatFat.Text;
                    command1.Parameters.Add("@TotalSugar", SqlDbType.Decimal, 18).Value = txtOldTotalSugar.Text;
                    command1.Parameters.Add("@AddedSugar", SqlDbType.Decimal, 18).Value = 0;
                    command1.Parameters.Add("@Sodium", SqlDbType.Decimal, 18).Value = txtOldSodium.Text;
                    command1.Parameters.Add("@KCal", SqlDbType.Decimal, 18).Value = txtOldKCal.Text;
                    command1.Parameters.Add("@nrf6", SqlDbType.Decimal, 18).Value = lblOldResult.Text;
                    command1.Parameters.Add("@LastUpdatedBy", SqlDbType.NVarChar, 50).Value = "Charles Moore";
                    command1.Parameters.Add("@lastupdated", SqlDbType.Date).Value = DateTime.Now;


                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();

                    //int count = 0;
                    //using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr2"].ConnectionString))
                    //{
                    //    System.Data.SqlClient.SqlCommand go = new System.Data.SqlClient.SqlCommand();

                    //    con.Open();
                    //    go.Connection = con;
                    //    go.CommandText = "SELECT No_ FROM Item WHERE No_ = @No_";
                    //    go.Parameters.Add("@No_", SqlDbType.NVarChar, 20).Value = txtNumber.Text;

                    //    SqlDataReader readIn = go.ExecuteReader();
                    //    while (readIn.Read())
                    //    {
                    //        ++count;
                    //    }

                    //    con.Close();


                    //}

                    //if (count == 1)
                    //{
                    //    connection.Open();

                    //    try
                    //    {
                    //        command1 = new SqlCommand();
                    //        command1.Connection = connection;
                    //        command1.CommandType = System.Data.CommandType.Text;

                    //        command1.CommandText = @"UPDATE item SET [CHOP Points] = @CHOPPoints
                    //WHERE No_ = @No_";

                    //        command1.Parameters.Add("@CHOPPoints", SqlDbType.Decimal, 18).Value = lblOldResult.Text;
                    //        command1.Parameters.Add("@No_", SqlDbType.NVarChar, 20).Value = txtNumber.Text;
                    //        command1.ExecuteNonQuery();
                    //        connection.Close();
                    //    }

                    //    catch (Exception k)
                    //    {

                    //    }
                    //}

                    //else
                    //{
                    //    Response.Write("<script>alert('Nutritional value recorded! Please remember to submit Ceres information!');</script>");
                    //}
                }
            }
        }

        protected void btnNewSaveItem_Click(object sender, EventArgs e)
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings["constr2"].ConnectionString;
            //String description = txtDescription.Text;

            //if (description.Length > 48)
            //{
            //    description.Substring(0, 48);
            //}


            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                {
                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandType = System.Data.CommandType.Text;


                    command1.CommandText = @"UPDATE Wholesome_Item SET No_ = @No_, ndb_no = @nd_no,"
                    + " Description = @Description, Long_Desc = @Long_Desc,"
                    + " protein = @protein, fiber = @fiber, vitaminA = @vitaminA, vitaminC = @vitaminC, " +
                    "vitaminD = @vitaminD, Potassium = @Potassium,"
                    + " calcium = @calcium, iron = @iron, saturatedFat = @saturatedFat, TotalSugar = @TotalSugar, " +
                    "AddedSugar = @AddedSugar, Sodium = @Sodium,"
                    + " KCal = @KCal, nrf6 = @nrf6, lastUpdatedBy = @LastUpdatedBy, LastUpdated = @LastUpdated WHERE No_ = @No_";


                    //command1.Parameters.Add("@No_", SqlDbType.NVarChar, 20).Value = txtNumber.Text;
                    command1.Parameters.Add("@ndb_no", SqlDbType.VarChar, 8).Value = "";
                    //command1.Parameters.Add("@Description", SqlDbType.NVarChar, 50).Value = description;
                    command1.Parameters.Add("@Long_Desc", SqlDbType.NVarChar, 500).Value = "";
                    command1.Parameters.Add("@protein", SqlDbType.Decimal, 18).Value = txtNewProtein.Text;
                    command1.Parameters.Add("@fiber", SqlDbType.Decimal, 18).Value = txtNewFiber.Text;
                    command1.Parameters.Add("@vitaminA", SqlDbType.Decimal, 18).Value = 0;
                    command1.Parameters.Add("@vitaminC", SqlDbType.Decimal, 18).Value = 0;
                    command1.Parameters.Add("@vitaminD", SqlDbType.Decimal, 18).Value = txtNewVD.Text;
                    command1.Parameters.Add("@Potassium", SqlDbType.Decimal, 18).Value = txtNewPotassium.Text;
                    command1.Parameters.Add("@Calcium", SqlDbType.Decimal, 18).Value = txtNewCalcium.Text;
                    command1.Parameters.Add("@Iron", SqlDbType.Decimal, 18).Value = txtNewIron.Text;
                    command1.Parameters.Add("@saturatedFat", SqlDbType.Decimal, 18).Value = txtNewSatFat.Text;
                    command1.Parameters.Add("@TotalSugar", SqlDbType.Decimal, 18).Value = 0;
                    command1.Parameters.Add("@AddedSugar", SqlDbType.Decimal, 18).Value = txtNewAddedSugar.Text;
                    command1.Parameters.Add("@Sodium", SqlDbType.Decimal, 18).Value = txtNewSodium.Text;
                    command1.Parameters.Add("@KCal", SqlDbType.Decimal, 18).Value = txtNewKCal.Text;
                    command1.Parameters.Add("@nrf6", SqlDbType.Decimal, 18).Value = lblNewResult.Text;
                    command1.Parameters.Add("@LastUpdatedBy", SqlDbType.NVarChar, 50).Value = "Charles Moore";
                    command1.Parameters.Add("@lastupdated", SqlDbType.Date).Value = DateTime.Now;


                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();

                    //int count = 0;
                    //using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr2"].ConnectionString))
                    //{
                    //    System.Data.SqlClient.SqlCommand go = new System.Data.SqlClient.SqlCommand();

                    //    con.Open();
                    //    go.Connection = con;
                    //    go.CommandText = "SELECT No_ FROM Item WHERE No_ = @No_";
                    //    go.Parameters.Add("@No_", SqlDbType.NVarChar, 20).Value = txtNumber.Text;

                    //    SqlDataReader readIn = go.ExecuteReader();
                    //    while (readIn.Read())
                    //    {
                    //        ++count;
                    //    }

                    //    con.Close();


                    //}

                    //if (count == 1)
                    //{
                    //    connection.Open();
                    //    try
                    //    {
                    //        command1 = new SqlCommand();
                    //        command1.Connection = connection;
                    //        command1.CommandType = System.Data.CommandType.Text;

                    //        command1.CommandText = @"UPDATE item SET [CHOP Points] = @CHOPPoints
                    //WHERE No_ = @No_";

                    //        command1.Parameters.Add("@CHOPPoints", SqlDbType.Decimal, 18).Value = lblNewResult.Text;
                    //        command1.Parameters.Add("@No_", SqlDbType.NVarChar, 20).Value = txtNumber.Text;
                    //        command1.ExecuteNonQuery();
                    //        connection.Close();
                    //    }

                    //    catch (Exception r)
                    //    {

                    //    }
                    //}

                    //else
                    //{
                    //    Response.Write("<script>alert('Nutritional value recorded! Please remember to submit Ceres information!');</script>");
                    //}
                }
            }
        }

        protected void ceresMatchedOnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    TableCell cell = e.Row.Cells[4];
            //    foreach (char c in cell.Text)
            //    {
            //        if (char.IsNumber(c))
            //        {
            //            double quantity = double.Parse(cell.Text);


            //            if (quantity < 4.66)
            //            {
            //                cell.BackColor = Color.Red;
            //            }
            //            if (quantity > 4.66 && quantity <= 27.99)
            //            {
            //                cell.BackColor = Color.Yellow;
            //            }
            //            if (quantity >= 28)
            //            {
            //                cell.BackColor = Color.Green;
            //            }
            //        }
            //    }
            //}
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
            // Response.Write("<script>alert('USDA item connected to CERES ID!');</script>");
            //String no_ = txtNumber.Text;
            String ndbno = "";// gridUSDAChoices.SelectedRow.Cells[0].Text;
            //String ceresDescription = txtDescription.Text;
            string description = ""; //gridUSDAChoices.SelectedRow.Cells[1].Text;
            string foodGroup = "";//gridUSDAChoices.SelectedRow.Cells[2].Text;
            //double protein = Double.Parse(gridUSDAChoices.SelectedRow.Cells[2].Text);
            //double fiber = Double.Parse(gridUSDAChoices.SelectedRow.Cells[3].Text);
            //double vitaminA = Double.Parse(gridUSDAChoices.SelectedRow.Cells[4].Text);
            //double vitaminC = Double.Parse(gridUSDAChoices.SelectedRow.Cells[5].Text);
            //double iron = Double.Parse(gridUSDAChoices.SelectedRow.Cells[6].Text);
            //double calcium = Double.Parse(gridUSDAChoices.SelectedRow.Cells[7].Text);
            //double saturatedFat = Double.Parse(gridUSDAChoices.SelectedRow.Cells[8].Text);
            //double totalSugar = Double.Parse(gridUSDAChoices.SelectedRow.Cells[9].Text);
            //double sodium = Double.Parse(gridUSDAChoices.SelectedRow.Cells[10].Text);
            //double kCal = Double.Parse(gridUSDAChoices.SelectedRow.Cells[11].Text);
            double ndscore = 0; // Double.Parse(gridUSDAChoices.SelectedRow.Cells[3].Text);
            String foodGroupNumber = ""; 

            String ConnectionString = ConfigurationManager.ConnectionStrings["constr2"].ConnectionString;

            //if (ceresDescription.Length > 48)
            //{
            //    ceresDescription = ceresDescription.Substring(0, 48);
            //}

            if (description.Length > 48)
            {
                description = description.Substring(0, 48);
            }

            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            };
            SqlCommand command = new SqlCommand();
                    command.Connection = sc;
                    command.CommandType = System.Data.CommandType.Text;
            sc.Open();


                    // ADD SESSION INFO
                    command.CommandText = @"SELECT FdGrp_CD FROM FD_GROUP WHERE FdGrp_Desc = @FdGrp_Desc";
                    command.Parameters.Add("@FdGrp_Desc", SqlDbType.NVarChar, 60).Value = foodGroup;

                    SqlDataReader readIn = command.ExecuteReader();
                    while (readIn.Read())
                    {
                       foodGroupNumber  = readIn["FdGrp_CD"].ToString();
                    }

                    sc.Close();
            if (foodGroupNumber != "")
            {
                sc.Open();
                SqlCommand command1 = new SqlCommand();
                command1.Connection = sc;
                command1.CommandType = System.Data.CommandType.Text;

                // ADD SESSION INFO
                command1.CommandText = @"UPDATE Wholesome_Item SET ndb_no = @ndb_no,"
                 + " FdGrp_CD = @FdGrp_CD, nrf6 = @nrf6, "
                 + "lastUpdatedBy = @LastUpdatedBy, LastUpdated = @LastUpdated, [Description 2] = @Description2 WHERE No_ = @No_";


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

            //int count = 0;
            //using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr2"].ConnectionString))
            //{
            //    System.Data.SqlClient.SqlCommand go = new System.Data.SqlClient.SqlCommand();

            //    con.Open();
            //    go.Connection = con;
            //    go.CommandText = "SELECT No_ FROM Item WHERE No_ = @No_";
            //    go.Parameters.Add("@No_", SqlDbType.NVarChar, 20).Value = txtNumber.Text;


            //    SqlDataReader readIn = go.ExecuteReader();
            //    while (readIn.Read())
            //    {
            //        ++count;
            //    }

            //    con.Close();


            //}

            //if (count == 1)
            //{
            //    connection.Open();

            //    try
            //    {
            //        command1 = new SqlCommand();
            //        command1.Connection = connection;
            //        command1.CommandType = System.Data.CommandType.Text;

            //        command1.CommandText = @"UPDATE item SET [No_ 2] = @No_2,  [Description 2] = @Description2, [CHOP Points] = @CHOPPoints
            //WHERE No_ = '" + txtNumber.Text + "'";

            //        command1.Parameters.Add("@No_2", SqlDbType.NVarChar, 20).Value = ndbno;
            //        command1.Parameters.Add("@Description2", SqlDbType.NVarChar, 50).Value = description;
            //        command1.Parameters.Add("@CHOPPoints", SqlDbType.Decimal, 18).Value = ndscore;
            //        command1.ExecuteNonQuery();
            //        connection.Close();
            //    }

            //    catch (Exception l)
            //    {
            //        Response.Write("<script>alert('Nutritional value recorded! Please remember to submit Ceres information!');</script>");
            //    }

            //}

            //else
            //{
            //    Response.Write("<script>alert('Nutritional value recorded! Please remember to submit Ceres information!');</script>");
            //}

            lblFBCategories.Visible = true;
                ddlFBCategories.Visible = true;
                btnSelectFBCategory.Visible = true;
                

            

        }

        protected void gridMatchedCeresIDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            String idToMatch = gridMatchedCeresIDS.SelectedRow.Cells[0].Text;
            


        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlMethod.SelectedIndex == 0)
            //{

            //}

            //else if (ddlMethod.SelectedIndex == 1)
            //{
            //    gridUSDAChoices.Visible = true;
            //    divmanual.Visible = false;
            //}

            //else if (ddlMethod.SelectedIndex == 2)
            //{
            //    divmanual.Visible = true;
            //    gridUSDAChoices.Visible = false;
            //    divold.Style.Add("display", "block");

            //}

        }

        protected void btnSelectFBCategory_Click(object sender, EventArgs e)
        {
            //String no_ = txtNumber.Text;
            String ndbno = ""; // gridUSDAChoices.SelectedRow.Cells[0].Text;
            //String ceresDescription = txtDescription.Text;
            string description = ""; // gridUSDAChoices.SelectedRow.Cells[1].Text;
            string foodGroup = ""; // gridUSDAChoices.SelectedRow.Cells[2].Text;
            double ndscore = 0; // Double.Parse(gridUSDAChoices.SelectedRow.Cells[3].Text);
            String gradientEntry = "";

            if(ndscore < 0)
            {
                gradientEntry = "1";
            }

            else if(ndscore >= 0 && ndscore < 2.33)
            {
                gradientEntry = "2";
            }

            else if (ndscore >= 2.33 && ndscore < 4.66)
            {
                gradientEntry = "3";
            }

            else if (ndscore >= 4.66 && ndscore < 12.44)
            {
                gradientEntry = "4";
            }

            else if (ndscore >= 12.44 && ndscore < 20.22)
            {
                gradientEntry = "5";
            }

            else if (ndscore >= 20.22 && ndscore < 28)
            {
                gradientEntry = "6";
            }

            else if (ndscore >= 28 && ndscore < 35.33)
            {
                gradientEntry = "7";
            }

            else if (ndscore >= 35.33 && ndscore < 42.67)
            {
                gradientEntry = "8";
            }

            else if (ndscore >= 42.67)
            {
                gradientEntry = "9";
            }

            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            };

            sc.Open();
            SqlCommand command1 = new SqlCommand();
            command1.Connection = sc;
            command1.CommandType = System.Data.CommandType.Text;

            // ADD SESSION INFO
            command1.CommandText = @"UPDATE Wholesome_Item SET ndb_no = @ndb_no,"
             + " FBC_Code = @FBC_Code, GradientEntry = @GradientEntry, nrf6 = @nrf6, "
             + "lastUpdatedBy = @LastUpdatedBy, LastUpdated = @LastUpdated, [Description 2] = @Description2 WHERE No_ = @No_";


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

        protected void BindDataFromDB()
        {
            //section.Visible = true;
            //System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection
            //{
            //    ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            //};

            //sc.Open();

            //SqlCommand myCommand = new SqlCommand("Pull_New_Ceres_Items", sc);
            //myCommand.CommandType = CommandType.StoredProcedure;
            //myCommand.ExecuteNonQuery();

            //myCommand = new SqlCommand("Update_Ceres_Items", sc);
            //myCommand.ExecuteNonQuery();

            //myCommand = new SqlCommand("Update_Wholesome_Items", sc);
            //myCommand.ExecuteNonQuery();

            //sc.Close();

            //gridSearchResults.DataSource = dataSearchResults;
            //gridSearchResults.DataBind();

			if (!matchedCeresIDS.Columns.Contains("NDBno") &&
				!matchedCeresIDS.Columns.Contains("Name") &&
				!matchedCeresIDS.Columns.Contains("ND Score"))
			{
				matchedCeresIDS.Columns.Add("CeresID", typeof(string)); // Row 0
				matchedCeresIDS.Columns.Add("Ceres_Name", typeof(string)); // Row 1
				matchedCeresIDS.Columns.Add("USDA Number", typeof(string)); // Row 2
				matchedCeresIDS.Columns.Add("Name", typeof(string)); // Row 3
				matchedCeresIDS.Columns.Add("ND Score", typeof(double));// Row 4
			} else
			{
				matchedCeresIDS.Clear();
			}

			System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection {
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
			gridMatchedCeresIDS.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
			gridMatchedCeresIDS.HeaderRow.Cells[2].Attributes["data-hide"] = "all";
			gridMatchedCeresIDS.HeaderRow.Cells[3].Attributes["data-hide"] = "all";
			gridMatchedCeresIDS.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
			gridMatchedCeresIDS.HeaderRow.TableSection = TableRowSection.TableHeader;

			conn.Close();

            search_summary.Text = String.Format("Found {0} matched items", matchedCeresIDS.Rows.Count);
            filter_applied.Text = String.Format("Filter applied: {0}", "none");

			String strHTML = "";
            foreach (DataRow row in matchedCeresIDS.Rows)
            {
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

            if (score < 0)
            {
                colorScaleStyle = GradientColors.getColor1();
            }
            else if ((score >= 0) && (score <= 2.33))
            {
                colorScaleStyle = GradientColors.getColor2();
            }
            else if ((score > 2.33) && (score <= 4.66))
            {
                colorScaleStyle = GradientColors.getColor3();
            }
            else if ((score > 4.66) && (score <= 12.44))
            {
                colorScaleStyle = GradientColors.getColor4();
            }
            else if ((score > 12.44) && (score <= 20.22))
            {
                colorScaleStyle = GradientColors.getColor5();
            }
            else if ((score > 20.22) && (score <= 28))
            {
                colorScaleStyle = GradientColors.getColor6();
            }
            else if ((score > 28) && (score <= 35.33))
            {
                colorScaleStyle = GradientColors.getColor7();
            }
            else if ((score > 35.33) && (score <= 42.67))
            {
                colorScaleStyle = GradientColors.getColor8();
            }
            else if (score > 42.67)
            {
                colorScaleStyle = GradientColors.getColor9();
            }
            else
            {
                // do nothing
            }

            colorScaleStyle += " !important";

            returnValue = String.Format(@"
				<div class='col-sm-6 col-md-4 col-lg-3'>
					<div class='panel panel-default' style='border-bottom: 5px solid {0};'>
						<div class='panel-body'>
							<h4 class='panel-title equal-height'>{1}</h4>
							<h4><strong>ND_Score: <span style='color: {0};'>{2}<span></strong></h4>
							<button class='btn btn-default btn-block expend-button' data-toggle='modal' data-target='#expanded_view'>Expand</button>
							<input type='hidden' class='hidden_ceres_name' value='{1}' />
							<input type='hidden' class='hidden_ceresid' value='{3}' />
							<input type='hidden' class='hidden_ndbno' value='{4}' />
						</div>
					</div>
				</div>
			",
            colorScaleStyle,
            item["Ceres_Name"].ToString(),
            item["ND score"].ToString(),
            item["CeresID"].ToString(),
            item["USDA Number"].ToString());

            return returnValue;
        }

		/***
		 * Get the ndbno from a hidden field in front-end.
		 * Get data using FoodItem.findNdbno method and ndbno.
		 * Style the NR Score accordingly.
		 * Update data to modal section in front-end.
		 */
		protected void ExpandItem(object sender, EventArgs e)
		{
			String ceres_name = hidden_ceres_name.Value;
			String ceresid = hidden_ceresid.Value;
			String ndbno = hidden_ndbno.Value;

			FoodItem.findNdbno(ndbno);

			double score = FoodItem.newFood.NRF6;
			String colorScaleStyle = "";

			if (score < 0)
			{
				colorScaleStyle = GradientColors.getColor1();
			} else if ((score >= 0) && (score <= 2.33))
			{
				colorScaleStyle = GradientColors.getColor2();
			} else if ((score > 2.33) && (score <= 4.66))
			{
				colorScaleStyle = GradientColors.getColor3();
			} else if ((score > 4.66) && (score <= 12.44))
			{
				colorScaleStyle = GradientColors.getColor4();
			} else if ((score > 12.44) && (score <= 20.22))
			{
				colorScaleStyle = GradientColors.getColor5();
			} else if ((score > 20.22) && (score <= 28))
			{
				colorScaleStyle = GradientColors.getColor6();
			} else if ((score > 28) && (score <= 35.33))
			{
				colorScaleStyle = GradientColors.getColor7();
			} else if ((score > 35.33) && (score <= 42.67))
			{
				colorScaleStyle = GradientColors.getColor8();
			} else if (score > 42.67)
			{
				colorScaleStyle = GradientColors.getColor9();
			} else
			{
				// do nothing
			}

			lblIndexResult.ForeColor = ColorTranslator.FromHtml(colorScaleStyle);
			modal_header.Attributes["style"] = String.Format("border-bottom: 5px solid {0};", colorScaleStyle);

			lblFoodName.Text = FoodItem.newFood.name;
			lblIndexResult.Text = Convert.ToString(Math.Round(score, 2));
			hidden_ndbno.Value = FoodItem.newFood.ndbNo;

			txtcalories.Text = FoodItem.newFood.kCal.ToString();
			txtsatfat.Text = Math.Round(FoodItem.newFood.satFat, 2).ToString();
			txtsodium.Text = Math.Round(FoodItem.newFood.sodium, 2).ToString();
			txtfiber.Text = Math.Round(FoodItem.newFood.fiber, 2).ToString();
			txtsugar.Text = Math.Round(FoodItem.newFood.totalSugar, 2).ToString();
			txtprotein.Text = Math.Round(FoodItem.newFood.protein, 2).ToString();
			txtva.Text = Math.Round((FoodItem.newFood.vitaminA / 5000) * 100).ToString();
			txtvc.Text = Math.Round((FoodItem.newFood.vitaminC / 60) * 100).ToString();
			txtcalcium.Text = Math.Round((FoodItem.newFood.calcium / 1000) * 100).ToString();
			txtiron.Text = Math.Round((FoodItem.newFood.iron / 18) * 100).ToString();

			txtCeresDescription.Text = ceres_name;
			txtCeresNumber.Text = ceresid;
		}
	}
}