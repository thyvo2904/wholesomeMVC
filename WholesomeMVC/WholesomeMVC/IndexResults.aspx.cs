using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Configuration;


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
            lblIndexResult.Text = Convert.ToString(FoodItem.newFood.NRF6);
            lblName.Text = FoodItem.newFood.name;
            lblNdbno.Text = FoodItem.newFood.ndbNo;
            txtprotein.Value = FoodItem.newFood.protein.ToString();
            txtfiber.Value = FoodItem.newFood.fiber.ToString();
            txtva.Value = FoodItem.newFood.vitaminA.ToString();
            txtvc.Value = FoodItem.newFood.vitaminC.ToString();
            txtcalcium.Value = FoodItem.newFood.calcium.ToString();
            txtiron.Value = FoodItem.newFood.iron.ToString();
            txtcalories.Value = FoodItem.newFood.kCal.ToString();
            txtsatfat.Value = FoodItem.newFood.satFat.ToString();
            txtsugar.Value = FoodItem.newFood.totalSugar.ToString();
            txtsodium.Value = FoodItem.newFood.sodium.ToString();
            ingredients.Value = FoodItem.newFood.ingredients;

            if (FoodItem.newFood.kCal.Equals(0))
            {
                lblIndexResult.Text = "Uncategorized";
                lblIndexResult.Attributes["style"] = "color:black; font-weight:bold;";
            }

            else if (FoodItem.newFood.NRF6 < Convert.ToDouble(GradientValues.getValue1()))
            {
                scorecolor.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor1() + "; font-weight:bold;";
            }

            else if ((FoodItem.newFood.NRF6 >= Convert.ToDouble(GradientValues.getValue1())) && (FoodItem.newFood.NRF6 <= Convert.ToDouble(GradientValues.getValue2())))
            {
                scorecolor.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor2() + "; font-weight:bold;";
            }

            else if ((FoodItem.newFood.NRF6 > Convert.ToDouble(GradientValues.getValue2())) && (FoodItem.newFood.NRF6 <= Convert.ToDouble(GradientValues.getValue3())))
            {
                scorecolor.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor3() + "; font-weight:bold;";
            }

            else if ((FoodItem.newFood.NRF6 > Convert.ToDouble(GradientValues.getValue3())) && (FoodItem.newFood.NRF6 <= Convert.ToDouble(GradientValues.getValue4())))
            {
                scorecolor.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor4() + "; font-weight:bold;";
            }

            else if ((FoodItem.newFood.NRF6 > Convert.ToDouble(GradientValues.getValue4())) && (FoodItem.newFood.NRF6 <= Convert.ToDouble(GradientValues.getValue5())))
            {
                scorecolor.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor5() + "; font-weight:bold;";
            }

            else if ((FoodItem.newFood.NRF6 > Convert.ToDouble(GradientValues.getValue5())) && (FoodItem.newFood.NRF6 <= Convert.ToDouble(GradientValues.getValue6())))
            {
                scorecolor.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor6() + "; font-weight:bold;";
            }

            else if ((FoodItem.newFood.NRF6 > Convert.ToDouble(GradientValues.getValue6())) && (FoodItem.newFood.NRF6 <= Convert.ToDouble(GradientValues.getValue7())))
            {
                scorecolor.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor7() + "; font-weight:bold;";
            }

            else if ((FoodItem.newFood.NRF6 > Convert.ToDouble(GradientValues.getValue7())) && (FoodItem.newFood.NRF6 <= Convert.ToDouble(GradientValues.getValue8())))
            {
                scorecolor.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor8() + "; font-weight:bold;";
            }

            else if (FoodItem.newFood.NRF6 > Convert.ToDouble(GradientValues.getValue8()))
            {
                scorecolor.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor9() + "; font-weight:bold;";
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
                        lblMatched.Text = "MATCHED";
                        btnUpdateItem.Visible = true;
                    }
                    else
                    {

                        lblMatched.Text = "UNMATCHED";
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
    

     
        
      
      
    




 
