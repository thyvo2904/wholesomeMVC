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

namespace WholesomeMVC
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
                if (!matchedCeresIDS.Columns.Contains("NDBno") && !matchedCeresIDS.Columns.Contains("Name")
                && !matchedCeresIDS.Columns.Contains("ND Score"))
                {
                    matchedCeresIDS.Columns.Add("CeresID", typeof(string)); // Row 0
                    matchedCeresIDS.Columns.Add("Ceres_Name", typeof(string)); // Row 1
                    matchedCeresIDS.Columns.Add("NDBno", typeof(string)); // Row 2
                    matchedCeresIDS.Columns.Add("Name", typeof(string)); // Row 3
                    matchedCeresIDS.Columns.Add("Protein", typeof(double));// Row 4
                    matchedCeresIDS.Columns.Add("Fiber", typeof(double));// Row 5
                    matchedCeresIDS.Columns.Add("VitaminA", typeof(double));// Row 6
                    matchedCeresIDS.Columns.Add("VitaminC", typeof(double));// Row 7
                    matchedCeresIDS.Columns.Add("VitaminD", typeof(double));// Row 7
                    matchedCeresIDS.Columns.Add("Potassium", typeof(double));// Row 7
                    matchedCeresIDS.Columns.Add("Iron", typeof(double));// Row 8
                    matchedCeresIDS.Columns.Add("Calcium", typeof(double));// Row 9
                    matchedCeresIDS.Columns.Add("Sat_Fat", typeof(double));// Row 10
                    matchedCeresIDS.Columns.Add("Total_Sugar", typeof(double));// Row 11
                    matchedCeresIDS.Columns.Add("Added_Sugar", typeof(double));// Row 7
                    matchedCeresIDS.Columns.Add("Sodium", typeof(double));// Row 12
                    matchedCeresIDS.Columns.Add("KCal", typeof(double));// Row 13
                    matchedCeresIDS.Columns.Add("ND Score", typeof(double));// Row 14
                }

                else
                {
                    matchedCeresIDS.Clear();
                }

                System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection
                {
                    ConnectionString = ConfigurationManager.ConnectionStrings["constr2"].ConnectionString
            };

                sc.Open();

                SqlDataReader newReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT Item.No_, item.description, Wholesome_Item.ndb_no, Long_Desc," +
                    " protein, fiber, vitaminA, vitaminC, vitaminD, potassium, calcium, iron, " +
                    "saturatedfat, totalsugar, addedsugar, sodium, KCal, nrf6 FROM Wholesome_Item " +
                    " INNER JOIN item ON Wholesome_item.No_ = item.No_",
                                                         sc);
                
                newReader = myCommand.ExecuteReader();
                if (newReader.HasRows)
                {
                    while (newReader.Read())
                    {
                        
                        DataRow row = matchedCeresIDS.NewRow();
                        row[0] = newReader["No_"].ToString();
                        row[1] = newReader["description"].ToString();
                        row[2]= newReader["ndb_no"].ToString();
                        row[3]= newReader["Long_Desc"].ToString();
                        row[4]= Double.Parse(newReader["protein"].ToString());
                        row[5]= Double.Parse(newReader["fiber"].ToString());
                        row[6]= Double.Parse(newReader["vitaminA"].ToString());
                        row[7]= Double.Parse(newReader["vitaminC"].ToString());
                        row[8]= Double.Parse(newReader["vitaminD"].ToString());
                        row[9] = Double.Parse(newReader["potassium"].ToString());
                        row[10] = Double.Parse(newReader["iron"].ToString());
                        row[11] = Double.Parse(newReader["calcium"].ToString());
                        row[12] = Double.Parse(newReader["saturatedFat"].ToString());
                        row[13] = Double.Parse(newReader["totalSugar"].ToString());
                        row[14] = Double.Parse(newReader["addedSugar"].ToString());
                        row[15] = Double.Parse(newReader["sodium"].ToString());
                        row[16] = Double.Parse(newReader["KCal"].ToString());
                        row[17] = Double.Parse(newReader["nrf6"].ToString());

                        matchedCeresIDS.Rows.Add(row);
                    }
                }
                gridMatchedCeresIDS.DataSource = matchedCeresIDS;
                gridMatchedCeresIDS.DataBind();

                sc.Close();

                if (!unMatchedCeresIDS.Columns.Contains("CeresID") && !unMatchedCeresIDS.Columns.Contains("Ceres_Name"))
                {
                    unMatchedCeresIDS.Columns.Add("CeresID", typeof(string)); // Row 0
                    unMatchedCeresIDS.Columns.Add("Ceres_Name", typeof(string)); // Row 1
                    
                }

                else
                {
                    unMatchedCeresIDS.Clear();
                }

                sc.Open();

                newReader = null;
                myCommand = new SqlCommand("SELECT Item.No_, Item.description FROM Item LEFT JOIN Wholesome_Item ON Item.No_ = Wholesome_Item.No_ WHERE Wholesome_Item.No_ IS null",sc);
                newReader = myCommand.ExecuteReader();
                if (newReader.HasRows)
                {
                    while (newReader.Read())
                    {
                        DataRow row = unMatchedCeresIDS.NewRow();
                        row[0] = newReader["No_"].ToString();
                        row[1] = newReader["description"].ToString();


                        
                        unMatchedCeresIDS.Rows.Add(row);
                    }
                }
                gridUnmatchedCeresIDS.DataSource = unMatchedCeresIDS;
                gridUnmatchedCeresIDS.DataBind();
                sc.Close();


                if (!unMatchedTestDBIDS.Columns.Contains("NDBno") && !unMatchedTestDBIDS.Columns.Contains("Name")
                && !unMatchedTestDBIDS.Columns.Contains("ND Score"))
                {
                    unMatchedTestDBIDS.Columns.Add("CeresID", typeof(string)); // Row 0
                    unMatchedTestDBIDS.Columns.Add("Ceres_Name", typeof(string)); // Row 1
                    unMatchedTestDBIDS.Columns.Add("NDBno", typeof(string)); // Row 2
                    unMatchedTestDBIDS.Columns.Add("Name", typeof(string)); // Row 3
                    unMatchedTestDBIDS.Columns.Add("Protein", typeof(double));// Row 4
                    unMatchedTestDBIDS.Columns.Add("Fiber", typeof(double));// Row 5
                    unMatchedTestDBIDS.Columns.Add("VitaminA", typeof(double));// Row 6
                    unMatchedTestDBIDS.Columns.Add("VitaminC", typeof(double));// Row 7
                    unMatchedTestDBIDS.Columns.Add("VitaminD", typeof(double));// Row 7
                    unMatchedTestDBIDS.Columns.Add("Potassium", typeof(double));// Row 7
                    unMatchedTestDBIDS.Columns.Add("Iron", typeof(double));// Row 8
                    unMatchedTestDBIDS.Columns.Add("Calcium", typeof(double));// Row 9
                    unMatchedTestDBIDS.Columns.Add("Sat_Fat", typeof(double));// Row 10
                    unMatchedTestDBIDS.Columns.Add("Total_Sugar", typeof(double));// Row 11
                    unMatchedTestDBIDS.Columns.Add("Added_Sugar", typeof(double));// Row 7
                    unMatchedTestDBIDS.Columns.Add("Sodium", typeof(double));// Row 12
                    unMatchedTestDBIDS.Columns.Add("KCal", typeof(double));// Row 13
                    unMatchedTestDBIDS.Columns.Add("ND Score", typeof(double));// Row 14
                }

                else
                {
                    unMatchedTestDBIDS.Clear();
                }

                sc = new System.Data.SqlClient.SqlConnection
                {
                    ConnectionString = ConfigurationManager.ConnectionStrings["constr2"].ConnectionString
            };

                sc.Open();

                newReader = null;
                myCommand = new SqlCommand("SELECT Wholesome_Item.No_, Wholesome_item.description, Wholesome_Item.ndb_no, Long_Desc," +
                    " protein, fiber, vitaminA, vitaminC, vitaminD, potassium, calcium, iron, " +
                    "saturatedfat, totalsugar, addedsugar, sodium, KCal, nrf6 FROM Wholesome_Item " +
                    " LEFT JOIN item ON Wholesome_item.No_ = item.No_ WHERE item.No_ IS NULL",
                                                         sc);

                newReader = myCommand.ExecuteReader();
                if (newReader.HasRows)
                {
                    while (newReader.Read())
                    {

                        DataRow row = unMatchedTestDBIDS.NewRow();
                        row[0] = newReader["No_"].ToString();
                        row[1] = newReader["description"].ToString();
                        row[2] = newReader["ndb_no"].ToString();
                        row[3] = newReader["Long_Desc"].ToString();
                        row[4] = Double.Parse(newReader["protein"].ToString());
                        row[5] = Double.Parse(newReader["fiber"].ToString());
                        row[6] = Double.Parse(newReader["vitaminA"].ToString());
                        row[7] = Double.Parse(newReader["vitaminC"].ToString());
                        row[8] = Double.Parse(newReader["vitaminD"].ToString());
                        row[9] = Double.Parse(newReader["potassium"].ToString());
                        row[10] = Double.Parse(newReader["iron"].ToString());
                        row[11] = Double.Parse(newReader["calcium"].ToString());
                        row[12] = Double.Parse(newReader["saturatedFat"].ToString());
                        row[13] = Double.Parse(newReader["totalSugar"].ToString());
                        row[14] = Double.Parse(newReader["addedSugar"].ToString());
                        row[15] = Double.Parse(newReader["sodium"].ToString());
                        row[16] = Double.Parse(newReader["KCal"].ToString());
                        row[17] = Double.Parse(newReader["nrf6"].ToString());

                        unMatchedTestDBIDS.Rows.Add(row);
                    }
                }
                gridUnmatchedTestDBIDS.DataSource = unMatchedTestDBIDS;
                gridUnmatchedTestDBIDS.DataBind();

                sc.Close();
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
            String sendCeresID = gridUnmatchedTestDBIDS.SelectedRow.Cells[0].Text;
            String sendDescription = gridUnmatchedTestDBIDS.SelectedRow.Cells[1].Text;
            FoodItem.setCeresData(sendCeresID, sendDescription);
            Response.Redirect("Update_Item.aspx");


        }

        protected void gridunMatchedCeresIDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sendCeresID = gridUnmatchedCeresIDS.SelectedRow.Cells[0].Text;
            String sendDescription = gridUnmatchedCeresIDS.SelectedRow.Cells[1].Text;
            FoodItem.setCeresData(sendCeresID, sendDescription);
            Response.Redirect("Add_Item.aspx");

        }

        protected void btnSyncDatabase_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["constr2"].ConnectionString
        };

            sc.Open();
            
            
            SqlCommand myCommand = new SqlCommand("UPDATE Item SET [CHOP Points] = nrf6, [No_ 2] = ndb_no, [Description 2] = Long_Desc FROM Item" +
                " INNER JOIN Wholesome_Item ON Item.No_ = Wholesome_Item.No_ WHERE Len(Long_Desc) < 49",
                                                     sc);

            myCommand.ExecuteNonQuery();
            

            sc.Close();


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
                archivedData.Columns.Add("Protein", typeof(double));// Row 4
                archivedData.Columns.Add("Fiber", typeof(double));// Row 5
                archivedData.Columns.Add("VitaminA", typeof(double));// Row 6
                archivedData.Columns.Add("VitaminC", typeof(double));// Row 7
                archivedData.Columns.Add("VitaminD", typeof(double));// Row 8
                archivedData.Columns.Add("Potassium", typeof(double));// Row 9
                archivedData.Columns.Add("Iron", typeof(double));// Row 10
                archivedData.Columns.Add("Calcium", typeof(double));// Row 11
                archivedData.Columns.Add("Sat_Fat", typeof(double));// Row 12
                archivedData.Columns.Add("Total_Sugar", typeof(double));// Row 13
                archivedData.Columns.Add("Added_Sugar", typeof(double));// Row 14
                archivedData.Columns.Add("Sodium", typeof(double));// Row 15
                archivedData.Columns.Add("KCal", typeof(double));// Row 16
                archivedData.Columns.Add("ND Score", typeof(double));// Row 17
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
            SqlCommand myCommand = new SqlCommand("SELECT No_, description, ndb_no, Long_Desc," +
                " protein, fiber, vitaminA, vitaminC, vitaminD, potassium, calcium, iron, " +
                "saturatedfat, totalsugar, addedsugar, sodium, KCal, nrf6 FROM Wholesome_Item_Archive",
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
                    row[3] = newReader["Long_Desc"].ToString();
                    row[4] = Double.Parse(newReader["protein"].ToString());
                    row[5] = Double.Parse(newReader["fiber"].ToString());
                    row[6] = Double.Parse(newReader["vitaminA"].ToString());
                    row[7] = Double.Parse(newReader["vitaminC"].ToString());
                    row[8] = Double.Parse(newReader["vitaminD"].ToString());
                    row[9] = Double.Parse(newReader["potassium"].ToString());
                    row[10] = Double.Parse(newReader["iron"].ToString());
                    row[11] = Double.Parse(newReader["calcium"].ToString());
                    row[12] = Double.Parse(newReader["saturatedFat"].ToString());
                    row[13] = Double.Parse(newReader["totalSugar"].ToString());
                    row[14] = Double.Parse(newReader["addedSugar"].ToString());
                    row[15] = Double.Parse(newReader["sodium"].ToString());
                    row[16] = Double.Parse(newReader["KCal"].ToString());
                    row[17] = Double.Parse(newReader["nrf6"].ToString());

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