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
using Wholesome;
using System.Web.Services;
using System.Configuration;

namespace Wholesome
{
    public partial class Update_Item : System.Web.UI.Page
    {
        public static DataTable dataSearchResults = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {   
                if(IndexResults.number != "")
                {
                    txtNumber.Text = IndexResults.number;
                }

                if (FoodItem.getCeresID() != "" || FoodItem.getDescription() != "")
                {
                    txtNumber.Text = FoodItem.getCeresID();
                    txtDescription.Text = FoodItem.getDescription();
                    FoodItem.clearCeresData();
                }
            }

            else
            {
                if (!String.IsNullOrEmpty(txtNewAddedSugar.Text) && !String.IsNullOrEmpty(txtNewFiber.Text))
                {
                    divnew.Style.Add("display", "block");
                    divold.Style.Add("display", "none");
                    ddlMethod.SelectedIndex = 2;
                }

                else if (!String.IsNullOrEmpty(txtOldCalcium.Text) && !String.IsNullOrEmpty(txtOldIron.Text))
                {
                    divold.Style.Add("display", "block");
                    divnew.Style.Add("display", "none");
                    ddlMethod.SelectedIndex = 1;
                }
            }

        }

        protected void btnSearch(object sender, EventArgs e)
        {


            if (txtSearch.Text != "")
            {
                String foodSearch = "";
                foodSearch = txtSearch.Text;
                FoodItem.findNdbno(foodSearch);
                Server.Transfer("~/IndexResults.aspx");
            }

            else
            {
                Response.Write("<script>alert('Please enter a value');</script>");
            }


        }

        // This just does the USDA item search / pops up the manual input options
        protected void btnUpdateItem_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr2"].ConnectionString))
            {
                System.Data.SqlClient.SqlCommand go = new System.Data.SqlClient.SqlCommand();
                Boolean findCeresID = false;
                con.Open();
                go.Connection = con;
                go.CommandText = "SELECT No_ FROM Wholesome_Item WHERE No_ = @No_";
                go.Parameters.Add("@No_", SqlDbType.NVarChar, 20).Value = txtNumber.Text;

                SqlDataReader readIn = go.ExecuteReader();
                while (readIn.Read())
                {
                    findCeresID = true;
                }

                con.Close();

                if (findCeresID == true)
                {
                    String foodSearch = txtSearchDescription.Text;
                    FoodItem.findNdbnoUpdateItem(foodSearch);

                    gridUSDAChoices.DataSource = Update_Item.dataSearchResults;
                    gridUSDAChoices.DataBind();
                }

                else
                {
                    Response.Write("<script>alert('Please enter a valid Ceres ID!');</script>");
                }
            }
        }

        protected void btnCalculateOld_Click(object sender, EventArgs e)
        {
            try
            {
                lblOldResult.Text = String.Empty;
                double nR6;
                double liMT;
                double NRF6;
         
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
            try {
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
            } catch (Exception ei)
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

                    String description = txtDescription.Text;

                    if(description.Length > 48)
                    {
                        description = description.Substring(0, 48);
                    }

                    // UPDATE Wholesome_Item SET No_ = , ndb_no = , Description = , Long_Desc = ,
                    // protein = , fiber = , vitaminA = , vitaminC = , vitaminD = , Potassium = ,
                    // calcium = , iron = , saturatedFat = , TotalSugar = , AddedSugar = , Sodium = ,
                    // KCal = , nrf6 = , lastUpdatedBy = , LastUpdated = WHERE No_ = 
                    command1.CommandText = @"UPDATE Wholesome_Item SET No_ = @No_, ndb_no = @ndb_no," 
                    + " Description = @Description, Long_Desc = @Long_Desc,"
                    + " protein = @protein, fiber = @fiber, vitaminA = @vitaminA, vitaminC = @vitaminC, " +
                    "vitaminD = @vitaminD, Potassium = @Potassium,"
                    + " calcium = @calcium, iron = @iron, saturatedFat = @saturatedFat, TotalSugar = @TotalSugar, " +
                    "AddedSugar = @AddedSugar, Sodium = @Sodium,"
                    + " KCal = @KCal, nrf6 = @nrf6, lastUpdatedBy = @LastUpdatedBy, LastUpdated = @LastUpdated WHERE No_ = @No_";


                    command1.Parameters.Add("@No_", SqlDbType.NVarChar, 20).Value = txtNumber.Text;
                    command1.Parameters.Add("@ndb_no", SqlDbType.VarChar, 8).Value = "";
                    command1.Parameters.Add("@Description", SqlDbType.NVarChar, 50).Value = description;
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

                    int count = 0;
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr2"].ConnectionString))
                    {
                        System.Data.SqlClient.SqlCommand go = new System.Data.SqlClient.SqlCommand();

                        con.Open();
                        go.Connection = con;
                        go.CommandText = "SELECT No_ FROM Item WHERE No_ = @No_";
                        go.Parameters.Add("@No_", SqlDbType.NVarChar, 20).Value = txtNumber.Text;

                        SqlDataReader readIn = go.ExecuteReader();
                        while (readIn.Read())
                        {
                            ++count;
                        }

                        con.Close();


                    }

                    if (count == 1)
                    {
                        connection.Open();

                        try
                        {
                            command1 = new SqlCommand();
                            command1.Connection = connection;
                            command1.CommandType = System.Data.CommandType.Text;

                            command1.CommandText = @"UPDATE item SET [CHOP Points] = @CHOPPoints
                    WHERE No_ = @No_";

                            command1.Parameters.Add("@CHOPPoints", SqlDbType.Decimal, 18).Value = lblOldResult.Text;
                            command1.Parameters.Add("@No_", SqlDbType.NVarChar, 20).Value = txtNumber.Text;
                            command1.ExecuteNonQuery();
                            connection.Close();
                        }

                        catch (Exception k)
                        {

                        }
                    }

                    else
                    {
                        Response.Write("<script>alert('Nutritional value recorded! Please remember to submit Ceres information!');</script>");
                    }
                }
            }
        }

        protected void btnNewSaveItem_Click(object sender, EventArgs e)
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings["constr2"].ConnectionString;
            String description = txtDescription.Text;

            if(description.Length > 48)
            {
                description.Substring(0, 48);
            }


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


                    command1.Parameters.Add("@No_", SqlDbType.NVarChar, 20).Value = txtNumber.Text;
                    command1.Parameters.Add("@ndb_no", SqlDbType.VarChar, 8).Value = "";
                    command1.Parameters.Add("@Description", SqlDbType.NVarChar, 50).Value = description;
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

                    int count = 0;
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr2"].ConnectionString))
                    {
                        System.Data.SqlClient.SqlCommand go = new System.Data.SqlClient.SqlCommand();

                        con.Open();
                        go.Connection = con;
                        go.CommandText = "SELECT No_ FROM Item WHERE No_ = @No_";
                        go.Parameters.Add("@No_", SqlDbType.NVarChar, 20).Value = txtNumber.Text;

                        SqlDataReader readIn = go.ExecuteReader();
                        while (readIn.Read())
                        {
                            ++count;
                        }

                        con.Close();


                    }

                    if (count == 1)
                    {
                        connection.Open();
                        try
                        {
                            command1 = new SqlCommand();
                            command1.Connection = connection;
                            command1.CommandType = System.Data.CommandType.Text;

                            command1.CommandText = @"UPDATE item SET [CHOP Points] = @CHOPPoints
                    WHERE No_ = @No_";

                            command1.Parameters.Add("@CHOPPoints", SqlDbType.Decimal, 18).Value = lblNewResult.Text;
                            command1.Parameters.Add("@No_", SqlDbType.NVarChar, 20).Value = txtNumber.Text;
                            command1.ExecuteNonQuery();
                            connection.Close();
                        }

                        catch (Exception r)
                        {

                        }
                    }

                    else
                    {
                        Response.Write("<script>alert('Nutritional value recorded! Please remember to submit Ceres information!');</script>");
                    }
                }
            }
        }

        protected void gridSearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Response.Write("<script>alert('USDA item connected to CERES ID!');</script>");
            String no_ = txtNumber.Text;
            String ndbno = gridUSDAChoices.SelectedRow.Cells[0].Text;
            String ceresDescription = txtDescription.Text;
            string description = gridUSDAChoices.SelectedRow.Cells[1].Text;
            double protein = Double.Parse(gridUSDAChoices.SelectedRow.Cells[2].Text);
            double fiber = Double.Parse(gridUSDAChoices.SelectedRow.Cells[3].Text);
            double vitaminA = Double.Parse(gridUSDAChoices.SelectedRow.Cells[4].Text);
            double vitaminC = Double.Parse(gridUSDAChoices.SelectedRow.Cells[5].Text);
            double iron = Double.Parse(gridUSDAChoices.SelectedRow.Cells[6].Text);
            double calcium = Double.Parse(gridUSDAChoices.SelectedRow.Cells[7].Text);
            double saturatedFat = Double.Parse(gridUSDAChoices.SelectedRow.Cells[8].Text);
            double totalSugar = Double.Parse(gridUSDAChoices.SelectedRow.Cells[9].Text);
            double sodium = Double.Parse(gridUSDAChoices.SelectedRow.Cells[10].Text);
            double kCal = Double.Parse(gridUSDAChoices.SelectedRow.Cells[11].Text);
            double ndscore = Double.Parse(gridUSDAChoices.SelectedRow.Cells[12].Text);

            String ConnectionString = ConfigurationManager.ConnectionStrings["constr2"].ConnectionString;

            if (ceresDescription.Length > 48)
            {
                ceresDescription = ceresDescription.Substring(0, 48);
            }

            if(description.Length > 48)
            {
                description = description.Substring(0, 48);
            }


            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                {
                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandType = System.Data.CommandType.Text;


                    command1.CommandText = @"UPDATE Wholesome_Item SET ndb_no = @ndb_no,"
                     + " Description = @Description, Long_Desc = @Long_Desc,"
                     + " protein = @protein, fiber = @fiber, vitaminA = @vitaminA, vitaminC = @vitaminC, " +
                     "vitaminD = @vitaminD, Potassium = @Potassium,"
                     + " calcium = @calcium, iron = @iron, saturatedFat = @saturatedFat, TotalSugar = @TotalSugar, " +
                     "AddedSugar = @AddedSugar, Sodium = @Sodium,"
                     + " KCal = @KCal, nrf6 = @nrf6, lastUpdatedBy = @LastUpdatedBy, LastUpdated = @LastUpdated WHERE No_ = @No_";


                    command1.Parameters.Add("@No_", SqlDbType.NVarChar, 20).Value = no_;
                    command1.Parameters.Add("@ndb_no", SqlDbType.VarChar, 8).Value = ndbno;
                    command1.Parameters.Add("@Description", SqlDbType.NVarChar, 50).Value = ceresDescription;
                    command1.Parameters.Add("@Long_Desc", SqlDbType.NVarChar, 500).Value = description;
                    command1.Parameters.Add("@protein", SqlDbType.Decimal, 18).Value = protein;
                    command1.Parameters.Add("@fiber", SqlDbType.Decimal, 18).Value = fiber;
                    command1.Parameters.Add("@vitaminA", SqlDbType.Decimal, 18).Value = vitaminA;
                    command1.Parameters.Add("@vitaminC", SqlDbType.Decimal, 18).Value = vitaminC;
                    command1.Parameters.Add("@vitaminD", SqlDbType.Decimal, 18).Value = 0;
                    command1.Parameters.Add("@Potassium", SqlDbType.Decimal, 18).Value = 0;
                    command1.Parameters.Add("@Calcium", SqlDbType.Decimal, 18).Value = calcium;
                    command1.Parameters.Add("@Iron", SqlDbType.Decimal, 18).Value = iron;
                    command1.Parameters.Add("@saturatedFat", SqlDbType.Decimal, 18).Value = saturatedFat;
                    command1.Parameters.Add("@TotalSugar", SqlDbType.Decimal, 18).Value = totalSugar;
                    command1.Parameters.Add("@AddedSugar", SqlDbType.Decimal, 18).Value = 0;
                    command1.Parameters.Add("@Sodium", SqlDbType.Decimal, 18).Value = sodium;
                    command1.Parameters.Add("@KCal", SqlDbType.Decimal, 18).Value = kCal;
                    command1.Parameters.Add("@nrf6", SqlDbType.Decimal, 18).Value = ndscore;
                    command1.Parameters.Add("@LastUpdatedBy", SqlDbType.NVarChar, 50).Value = "Charles Moore";
                    command1.Parameters.Add("@Lastupdated", SqlDbType.Date).Value = DateTime.Now;


                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();


                    int count = 0;
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr2"].ConnectionString))
                    {
                        System.Data.SqlClient.SqlCommand go = new System.Data.SqlClient.SqlCommand();

                        con.Open();
                        go.Connection = con;
                        go.CommandText = "SELECT No_ FROM Item WHERE No_ = @No_";
                        go.Parameters.Add("@No_", SqlDbType.NVarChar, 20).Value = txtNumber.Text;


                        SqlDataReader readIn = go.ExecuteReader();
                        while (readIn.Read())
                        {
                            ++count;
                        }

                        con.Close();


                    }

                    if (count == 1)
                    {
                        connection.Open();

                        try
                        {
                            command1 = new SqlCommand();
                            command1.Connection = connection;
                            command1.CommandType = System.Data.CommandType.Text;

                            command1.CommandText = @"UPDATE item SET [No_ 2] = @No_2,  [Description 2] = @Description2, [CHOP Points] = @CHOPPoints
                    WHERE No_ = '" + txtNumber.Text + "'";

                            command1.Parameters.Add("@No_2", SqlDbType.NVarChar, 20).Value = ndbno;
                            command1.Parameters.Add("@Description2", SqlDbType.NVarChar, 50).Value = description;
                            command1.Parameters.Add("@CHOPPoints", SqlDbType.Decimal, 18).Value = ndscore;
                            command1.ExecuteNonQuery();
                            connection.Close();
                        }

                        catch (Exception l)
                        {
                            Response.Write("<script>alert('Nutritional value recorded! Please remember to submit Ceres information!');</script>");
                        }

                    }

                    else
                    {
                        Response.Write("<script>alert('Nutritional value recorded! Please remember to submit Ceres information!');</script>");
                    }
                }
            }


        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMethod.SelectedIndex == 0)
            {

            }

            else if (ddlMethod.SelectedIndex == 1)
            {
                gridUSDAChoices.Visible = true;
                divmanual.Visible = false;
            }

            else if (ddlMethod.SelectedIndex == 2)
            {
                divmanual.Visible = true;
                gridUSDAChoices.Visible = false;
                divold.Style.Add("display", "block");

            }

        }


    }
}