using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Configuration;
//using System.Windows.Forms;

namespace WholesomeMVC
{

    public partial class IndexResults : System.Web.UI.Page
    {
        // Counter to keep up with save id's

        public static string number;
        public static string ing;
        public static int counter = 0;
        public static DataTable dataSearchResults = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection
                {
                    ConnectionString = ConfigurationManager.ConnectionStrings["constr2"].ConnectionString
                };

                sc.Open();


                SqlCommand myCommand = new SqlCommand("Pull_New_Ceres_Items",
                                                         sc);
                myCommand.CommandType = CommandType.StoredProcedure;

                myCommand.ExecuteNonQuery();

                myCommand = new SqlCommand("Update_Ceres_Items",
                                                         sc);
                myCommand.ExecuteNonQuery();

                //myCommand = new SqlCommand("Update_Wholesome_Items",
                //                                         sc);
                //myCommand.ExecuteNonQuery();

                sc.Close();

                gridSearchResults.DataSource = dataSearchResults;
                gridSearchResults.DataBind();
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

        public void gridSearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ndbno = gridSearchResults.SelectedRow.Cells[0].Text;

            FoodItem.findNdbno(ndbno);

            lblFoodName.Text = FoodItem.newFood.name;
            lblIndexResult.Text = Convert.ToString(Math.Round(FoodItem.newFood.NRF6, 2));
            lblName.Text = FoodItem.newFood.name;
            lblNdbno.Text = FoodItem.newFood.ndbNo;
            //txtfat.Value = FoodItem.newFood.totalFat.ToString() + "g";
            //txtTransfat.Value = FoodItem.newFood.transFat.ToString() + "g";
            //txtCholesterol.Value = Math.Round(FoodItem.newFood.cholesterol, 2).ToString() + "mg";

            txtprotein.Value = Math.Round(FoodItem.newFood.protein, 2).ToString() + "g";
            txtfiber.Value = Math.Round(FoodItem.newFood.fiber, 2).ToString() + "g";
            txtva.Value = Math.Round((FoodItem.newFood.vitaminA / 5000) * 100).ToString() + "%";
            txtvc.Value = Math.Round((FoodItem.newFood.vitaminC / 60) * 100).ToString() + "%";
            txtcalcium.Value = Math.Round((FoodItem.newFood.calcium / 1000) * 100).ToString() + "%";
            txtiron.Value = Math.Round((FoodItem.newFood.iron / 18) * 100).ToString() + "%";
            txtcalories.Value = FoodItem.newFood.kCal.ToString();
            txtsatfat.Value = Math.Round(FoodItem.newFood.satFat, 2).ToString() + "g";
            txtsugar.Value = Math.Round(FoodItem.newFood.totalSugar, 2).ToString();
            txtsodium.Value = Math.Round(FoodItem.newFood.sodium, 2).ToString() + "mg";
            //txtCarbohydrate.Value = Math.Round(FoodItem.newFood.carbohydrates, 2).ToString() + "g";

            //txtfatpercent.Value = Math.Round((FoodItem.newFood.totalFat / 65) * 100).ToString() + "%";
            //txt.Value = Math.Round(FoodItem.newFood.transFat).ToString();
            //txtCholesterolpercecnt.Value = Math.Round((FoodItem.newFood.cholesterol / 300) * 100).ToString() + "%";
            //txtfiberpercent.Value = Math.Round((FoodItem.newFood.fiber / 25) * 100).ToString() + "%";
            //txtsatfatpercent.Value = Math.Round((FoodItem.newFood.satFat / 20) * 100).ToString() + "%";
            //txtsodiumpercent.Value = Math.Round((FoodItem.newFood.fiber / 2400) * 100).ToString() + "%";
            //txtcarbonpercent.Value = Math.Round((FoodItem.newFood.carbohydrates / 300) * 100).ToString() + "%";

            if (FoodItem.newFood.kCal.Equals(0))
            {
                lblIndexResult.Text = "Uncategorized";
                lblIndexResult.Attributes["style"] = "color:black; font-weight:bold;";
            }

            else if (FoodItem.newFood.NRF6 < Convert.ToDouble(GradientValues.getValue1()))
            {
                lblIndexResult.Attributes["style"] = "color:" + GradientColors.getColor1() + "; font-weight:bold;";
            }

            else if ((FoodItem.newFood.NRF6 >= Convert.ToDouble(GradientValues.getValue1())) && (FoodItem.newFood.NRF6 <= Convert.ToDouble(GradientValues.getValue2())))
            {
                lblIndexResult.Attributes["style"] = "color:" + GradientColors.getColor2() + "; font-weight:bold;";
            }

            else if ((FoodItem.newFood.NRF6 > Convert.ToDouble(GradientValues.getValue2())) && (FoodItem.newFood.NRF6 <= Convert.ToDouble(GradientValues.getValue3())))
            {
                lblIndexResult.Attributes["style"] = "color:" + GradientColors.getColor3() + "; font-weight:bold;";
            }

            else if ((FoodItem.newFood.NRF6 > Convert.ToDouble(GradientValues.getValue3())) && (FoodItem.newFood.NRF6 <= Convert.ToDouble(GradientValues.getValue4())))
            {
                lblIndexResult.Attributes["style"] = "color:" + GradientColors.getColor4() + "; font-weight:bold;";
            }

            else if ((FoodItem.newFood.NRF6 > Convert.ToDouble(GradientValues.getValue4())) && (FoodItem.newFood.NRF6 <= Convert.ToDouble(GradientValues.getValue5())))
            {
                lblIndexResult.Attributes["style"] = "color:" + GradientColors.getColor5() + "; font-weight:bold;";
            }

            else if ((FoodItem.newFood.NRF6 > Convert.ToDouble(GradientValues.getValue5())) && (FoodItem.newFood.NRF6 <= Convert.ToDouble(GradientValues.getValue6())))
            {
                lblIndexResult.Attributes["style"] = "color:" + GradientColors.getColor6() + "; font-weight:bold;";
            }

            else if ((FoodItem.newFood.NRF6 > Convert.ToDouble(GradientValues.getValue6())) && (FoodItem.newFood.NRF6 <= Convert.ToDouble(GradientValues.getValue7())))
            {
                lblIndexResult.Attributes["style"] = "color:" + GradientColors.getColor7() + "; font-weight:bold;";
            }

            else if ((FoodItem.newFood.NRF6 > Convert.ToDouble(GradientValues.getValue7())) && (FoodItem.newFood.NRF6 <= Convert.ToDouble(GradientValues.getValue8())))
            {
                lblIndexResult.Attributes["style"] = "color:" + GradientColors.getColor8() + "; font-weight:bold;";
            }

            else if (FoodItem.newFood.NRF6 > Convert.ToDouble(GradientValues.getValue8()))
            {
                lblIndexResult.Attributes["style"] = "color:" + GradientColors.getColor9() + "; font-weight:bold;";
            }


            string ConnectionString = ConfigurationManager.ConnectionStrings["constr2"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                {
                    SqlCommand command1 = new SqlCommand();
                    SqlCommand command2 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandType = System.Data.CommandType.Text;
                    command2.Connection = connection;
                    command2.CommandType = System.Data.CommandType.Text;



                    command1.CommandText = @"INSERT INTO [wholesomeDB].[dbo].[Recent_Index] ([ndb_no], [SearchDate], [LastUpdatedBy], [LastUpdated]) VALUES

                   (@ndb_no, @SearchDate, @LastUpdatedBy, @lastupdated)";

                    command2.CommandText = @"SELECT * FROM [wholesomeDB].[dbo].[Wholesome_Item] WHERE [NDB_No] = @number";
                    command2.Parameters.Add("@number", SqlDbType.VarChar, 8).Value = FoodItem.newFood.ndbNo;
                    command1.Parameters.Add("@ndb_no", SqlDbType.VarChar, 8).Value = ndbno;
                    command1.Parameters.Add("@SearchDate", SqlDbType.Date).Value = DateTime.Now;
                    command1.Parameters.Add("@LastUpdatedBy", SqlDbType.NVarChar, 50).Value = "Charles Moore";
                    command1.Parameters.Add("@lastupdated", SqlDbType.Date).Value = DateTime.Now;


                    connection.Open();
                    // command1.ExecuteNonQuery();
                    SqlDataReader reader = command2.ExecuteReader();
                    if (reader.HasRows)
                    {
                        //lblMatched.Text = "MATCHED";
                        btnUpdateItem.Visible = true;
                    }
                    else
                    {

                        //lblMatched.Text = "UNMATCHED";
                        btnSaveItem.Visible = true;
                    }

                    reader.Close();
                    reader.Dispose();

                }
                connection.Close();


            }
        }



        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell cell = e.Row.Cells[2];
                foreach (char c in cell.Text)
                {
                    if (char.IsNumber(c))
                    {
                        double quantity = double.Parse(cell.Text);


                        if (quantity < 4.66)
                        {
                            cell.BackColor = Color.Red;
                        }
                        if (quantity > 4.66 && quantity <= 27.99)
                        {
                            cell.BackColor = Color.Yellow;
                        }
                        if (quantity >= 28)
                        {
                            cell.BackColor = Color.Green;
                        }
                    }
                }
            }
        }

        protected void btnSaveItem_Click(object sender, EventArgs e)
        {

            String ConnectionString = ConfigurationManager.ConnectionStrings["constr2"].ConnectionString;

            if (txtCeresNumber.Text == "" || txtCeresDescription.Text == "")
            {

                Response.Write("<script>alert('Please enter a value for ceres item number and description');</script>");
            }




            else
            {
                // Check if the ceres item is null. If ceres item doesn't exist prompt the user to open ceres and enter it there first
                // 
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    String name = lblName.Text;
                    {
                        SqlCommand command1 = new SqlCommand();
                        command1.Connection = connection;
                        command1.CommandType = System.Data.CommandType.Text;

                        if (lblName.Text.Length > 48)
                        {
                            name = lblName.Text.Substring(0, 48);
                        }


                        command1.CommandText = @"INSERT INTO [wholesomeDB].[dbo].[Wholesome_Item] ([NDB_No], [Name], [Description], [ND_Score], [Ceres_Item_Number], [UserID], [LastUpdatedBy], [LastUpdated]) VALUES
                                      (@ndbno, @name,  @ceresdescription, @nrf6, @ceresitemnumber, @userID, @lastupdatedby, @lastupdated)";

                        command1.Parameters.Add("@ndbno", SqlDbType.NVarChar, 8).Value = FoodItem.newFood.ndbNo;
                        command1.Parameters.Add("@name", SqlDbType.VarChar, 500).Value = FoodItem.newFood.name;
                        command1.Parameters.Add("@ceresdescription", SqlDbType.VarChar, 50).Value = FoodItem.newFood.name;
                        command1.Parameters.Add("@ceresitemnumber", SqlDbType.NVarChar, 20).Value = txtCeresNumber.Text;
                        command1.Parameters.Add("@nrf6", SqlDbType.Decimal).Value = FoodItem.newFood.NRF6;
                        command1.Parameters.Add("@userID", SqlDbType.Int).Value = "1";
                        command1.Parameters.Add("@lastupdatedby", SqlDbType.NVarChar, 20).Value = "Nathan Hamrick";
                        command1.Parameters.Add("@lastupdated", SqlDbType.Date).Value = DateTime.Now;

                        connection.Open();
                        command1.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
        }

        protected void btnUpdateItem_Click(object sender, EventArgs e)
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings["constr2"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                {
                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandType = System.Data.CommandType.Text;


                    command1.CommandText = @"SELECT [No_] FROM [wholesomeDB].[dbo].[Wholesome_Item] WHERE [NDB_No] = @number";
                    command1.Parameters.Add("@number", SqlDbType.NVarChar, 8).Value = FoodItem.newFood.ndbNo;

                    connection.Open();
                    SqlDataReader readIn = command1.ExecuteReader();
                    if (readIn.HasRows)
                    {
                        while (readIn.Read())
                        {
                            number = Convert.ToString(readIn["No_"]);
                        }
                    }
                    else
                    {
                        number = "";
                    }
                    connection.Close();


                }
                Server.Transfer("~/Update_Item.aspx");
            }
        }
    }
}












