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
using System.Drawing;
using System.Configuration;

namespace WholesomeMVC.WebForms
{
    public partial class Sync_Database : System.Web.UI.Page
    {
        public static DataTable matchedCeresIDS = new DataTable();
        public static DataTable unMatchedCeresIDS = new DataTable();
        public static DataTable unMatchedTestDBIDS = new DataTable();
        public static DataTable archivedData = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {   // searchbar dropdownlist 
            if (!IsPostBack)
            {


            }

            if (!IsPostBack)
            {
                System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection
                {
                    ConnectionString = ConfigurationManager.ConnectionStrings["constr2"].ConnectionString
                };

                sc.Open();


                SqlCommand myCommand = new SqlCommand("Pull_New_Ceres_Items",
                                                         sc)
                {
                    CommandType = CommandType.StoredProcedure
                };

                myCommand.ExecuteNonQuery();

                myCommand = new SqlCommand("Update_Ceres_Items",
                                                         sc);
                myCommand.ExecuteNonQuery();

                //myCommand = new SqlCommand("Update_Wholesome_Items",
                //                                         sc);
                //myCommand.ExecuteNonQuery();

                sc.Close();


                if (!matchedCeresIDS.Columns.Contains("NDBno") && !matchedCeresIDS.Columns.Contains("Name")
                && !matchedCeresIDS.Columns.Contains("ND Score"))
                {
                    matchedCeresIDS.Columns.Add("CeresID", typeof(string)); // Row 0
                    matchedCeresIDS.Columns.Add("Ceres_Name", typeof(string)); // Row 1
                    matchedCeresIDS.Columns.Add("USDA Number", typeof(string)); // Row 2
                    matchedCeresIDS.Columns.Add("Name", typeof(string)); // Row 3
                    matchedCeresIDS.Columns.Add("ND Score", typeof(double));// Row 14
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
                SqlCommand newCommand = new SqlCommand("SELECT Wholesome_Item.No_, Wholesome_Item.description, Wholesome_item.ndb_no, Wholesome_item.[description 2] AS description2, nrf6" +
                    " FROM Wholesome_Item WHERE nrf6 IS NOT NULL",
                                                         conn);

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

                conn.Close();


            }
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

        protected void gridMatchedCeresIDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sendCeresID = gridMatchedCeresIDS.SelectedRow.Cells[0].Text;
            String sendDescription = gridMatchedCeresIDS.SelectedRow.Cells[1].Text;
            FoodItem.setCeresData(sendCeresID, sendDescription);
            Response.Redirect("Update_Item.aspx");


        }

        protected void gridUnMatchedWholesomeIDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            //String sendCeresID = gridUnmatchedTestDBIDS.SelectedRow.Cells[0].Text;
            //String sendDescription = gridUnmatchedTestDBIDS.SelectedRow.Cells[1].Text;
            //FoodItem.setCeresData(sendCeresID, sendDescription);
            //Response.Redirect("Update_Item.aspx");


        }

        protected void gridunMatchedCeresIDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            //String sendCeresID = gridUnmatchedCeresIDS.SelectedRow.Cells[0].Text;
            //String sendDescription = gridUnmatchedCeresIDS.SelectedRow.Cells[1].Text;
            //FoodItem.setCeresData(sendCeresID, sendDescription);
            //Response.Redirect("add_item.aspx");

        }

        protected void btnSyncDatabase_Click(object sender, EventArgs e)
        {
            //    System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection
            //    {
            //        ConnectionString = ConfigurationManager.ConnectionStrings["constr2"].ConnectionString
            //};

            //    sc.Open();


            //    SqlCommand myCommand = new SqlCommand("UPDATE Item SET [CHOP Points] = nrf6, [No_ 2] = ndb_no, [Description 2] = Long_Desc FROM Item" +
            //        " INNER JOIN Wholesome_Item ON Item.No_ = Wholesome_Item.No_ WHERE Len(Long_Desc) < 49",
            //                                             sc);

            //    myCommand.ExecuteNonQuery();


            //    sc.Close();


        }

        protected void btnRetrieveArchivedValues_Click(object sender, EventArgs e)
        {

            if (!archivedData.Columns.Contains("NDBno") && !archivedData.Columns.Contains("Name")
                && !archivedData.Columns.Contains("ND Score"))
            {
                archivedData.Columns.Add("CeresID", typeof(string)); // Row 0
                archivedData.Columns.Add("Ceres_Name", typeof(string)); // Row 1
                archivedData.Columns.Add("NDBno", typeof(string)); // Row 2
                archivedData.Columns.Add("Name", typeof(string)); // Row 3
                archivedData.Columns.Add("ND Score", typeof(double));// Row 4
                archivedData.Columns.Add("lastupdatedby", typeof(string));
            }

            else
            {
                archivedData.Clear();
            }


            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["constr2"].ConnectionString
            };

            sc.Open();

            SqlDataReader newReader = null;
            SqlCommand myCommand = new SqlCommand("SELECT No_, description, ndb_no, [description 2] AS description2, nrf6, lastupdatedby," +
                " nrf6 FROM Wholesome_Item_Archive",
                                                     sc);

            newReader = myCommand.ExecuteReader();
            if (newReader.HasRows)
            {
                while (newReader.Read())
                {

                    DataRow row = archivedData.NewRow();
                    row[0] = newReader["No_"].ToString();
                    row[1] = newReader["description"].ToString();
                    row[2] = newReader["ndb_no"].ToString();
                    row[3] = newReader["description2"].ToString();
                    row[4] = Double.Parse(newReader["nrf6"].ToString());
                    row[5] = newReader["lastupdatedby"].ToString();


                    archivedData.Rows.Add(row);
                }
            }
            gridArchivedData.DataSource = archivedData;
            gridArchivedData.DataBind();

            sc.Close();
        }

        protected void ceresMatchedOnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell cell = e.Row.Cells[4];
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

        protected void unMatchedOnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell cell = e.Row.Cells[17];
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

        protected void gridArchivedData_SelectedIndexChanged(object sender, EventArgs e)
        {
            String no_ = gridArchivedData.SelectedRow.Cells[0].Text;
            string description = gridArchivedData.SelectedRow.Cells[1].Text;
            String ndbno = gridArchivedData.SelectedRow.Cells[2].Text;
            string long_Desc = gridArchivedData.SelectedRow.Cells[3].Text;
            double protein = Double.Parse(gridArchivedData.SelectedRow.Cells[4].Text);
            double fiber = Double.Parse(gridArchivedData.SelectedRow.Cells[5].Text);
            double vitaminA = Double.Parse(gridArchivedData.SelectedRow.Cells[6].Text);
            double vitaminC = Double.Parse(gridArchivedData.SelectedRow.Cells[7].Text);
            double vitaminD = Double.Parse(gridArchivedData.SelectedRow.Cells[8].Text);
            double potassium = Double.Parse(gridArchivedData.SelectedRow.Cells[9].Text);
            double iron = Double.Parse(gridArchivedData.SelectedRow.Cells[10].Text);
            double calcium = Double.Parse(gridArchivedData.SelectedRow.Cells[11].Text);
            double saturatedFat = Double.Parse(gridArchivedData.SelectedRow.Cells[12].Text);
            double totalSugar = Double.Parse(gridArchivedData.SelectedRow.Cells[13].Text);
            double addedSugar = Double.Parse(gridArchivedData.SelectedRow.Cells[14].Text);
            double sodium = Double.Parse(gridArchivedData.SelectedRow.Cells[15].Text);
            double kCal = Double.Parse(gridArchivedData.SelectedRow.Cells[16].Text);
            double ndscore = Double.Parse(gridArchivedData.SelectedRow.Cells[17].Text);

            String ConnectionString = ConfigurationManager.ConnectionStrings["constr2"].ConnectionString;



            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                {
                    SqlCommand command1 = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = System.Data.CommandType.Text,


                        CommandText = @"UPDATE Wholesome_Item SET ndb_no = @ndb_no,"
                     + " Description = @Description, Long_Desc = @Long_Desc,"
                     + " protein = @protein, fiber = @fiber, vitaminA = @vitaminA, vitaminC = @vitaminC, " +
                     "vitaminD = @vitaminD, Potassium = @Potassium,"
                     + " calcium = @calcium, iron = @iron, saturatedFat = @saturatedFat, TotalSugar = @TotalSugar, " +
                     "AddedSugar = @AddedSugar, Sodium = @Sodium,"
                     + " KCal = @KCal, nrf6 = @nrf6, lastUpdatedBy = @LastUpdatedBy, LastUpdated = @LastUpdated WHERE No_ = @No_"
                    };


                    command1.Parameters.Add("@No_", SqlDbType.NVarChar, 20).Value = no_;
                    command1.Parameters.Add("@ndb_no", SqlDbType.VarChar, 8).Value = ndbno;
                    command1.Parameters.Add("@Description", SqlDbType.NVarChar, 50).Value = description;
                    command1.Parameters.Add("@Long_Desc", SqlDbType.NVarChar, 500).Value = long_Desc;
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
                    command1.Parameters.Add("@lastupdated", SqlDbType.Date).Value = DateTime.Now;


                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();
                }
            }

            Response.Write("<script>alert('Record restored!');</script>");
        }
    }
}