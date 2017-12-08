using Microsoft.AspNet.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WholesomeMVC.WebForms
{
    public partial class indexresult : System.Web.UI.Page
    {
        // Counter to keep up with save id's
        public static String savedNdb_no = "";
        public static String savedItemName = "";
        public static double savedNrf6 = 0;
        public static String savedFoodGroup = "";
        public static ArrayList lowSodium;
        

        public static string number;
        public static string ing;
        public static int counter = 0;
        public static DataTable dataSearchResults = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                txtCeresNumber.Text = (string)Session["sharedCeresID"];
                txtCeresDescription.Text = (string)Session["sharedCeresDescription"];
            }

            if (HttpContext.Current.User.IsInRole("Admin"))
            {
                btnCompare.Visible = true;
                sook.Visible = true;
                txtCeresStatus.Visible = true;
                btnSaveItem.Visible = true;
            }
            else
            {
                btnCompare.Visible = false;
                sook.Visible = false;
                txtCeresStatus.Visible = false;
                btnSaveItem.Visible = false;
            }
            if (IsPostBack)
            {
                // do nothing
            }
            else
            {
                // set page variables
                String strTitle = "Search Results";

                Literal page_title = (Literal)Master.FindControl("page_title");
                page_title.Text = strTitle;
                Label body_title = (Label)Master.FindControl("body_title");
                body_title.Text = strTitle;

                BindDataFromDB();
            }
        }

        /***
		 * Use Pull_New_Ceres_Items and Update_Ceres_Items stored procedure to fetch data.
		 * Loop through the data set.
		 * For each row in the data set, call GenerateHtmlForEachItem() to generate HTML code.
		 * Render generated HTML to search_results section.
		 */
        protected void BindDataFromDB()
        {
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            };

            sc.Open();

            SqlCommand myCommand = new SqlCommand("Pull_New_Ceres_Items", sc)
            {
                CommandType = CommandType.StoredProcedure
            };
            myCommand.ExecuteNonQuery();

            myCommand = new SqlCommand("Update_Ceres_Items", sc);
            myCommand.ExecuteNonQuery();

            //myCommand = new SqlCommand("Update_Wholesome_Items", sc);
            //myCommand.ExecuteNonQuery();

            sc.Close();

            search_summary.Text = String.Format("Found {0} items", dataSearchResults.Rows.Count);
            //filter_applied.Text = String.Format("Filter applied: {0}", "none");

            String strHTML = "";
            foreach (DataRow row in dataSearchResults.Rows)
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

            if (score < 4.66)
            {
                colorScaleStyle = GradientColors.getColor1();
            }
            else if ((score >= 4.66) && (score <= 28))
            {
                colorScaleStyle = GradientColors.getColor2();
            }
            else if (score > 28)
            {
                colorScaleStyle = GradientColors.getColor3();
            }
            else
            {
                // do nothing
            }

            colorScaleStyle += " !important";

            returnValue = String.Format(@"
				<li>
					<div class='col-sm-6 col-md-4 col-lg-3'>
						<div class='panel panel-default' style='border-bottom: 5px solid {0};'>
							<div class='panel-body'>
								<h4 id='{3}_name' class='panel-title equal-height'>{1}</h4>
								<h4><strong>ND_Score: <span style='color: {0};'>{2}<span></strong></h4>
								<button id='{3}' class='btn btn-default btn-block expend-button' data-toggle='modal' data-target='#expanded_view'>Expand</button>
							</div>
						</div>
					</div>
				</li>
			",
            colorScaleStyle,
            item["name"].ToString(),
            item["ND score"].ToString(),
            item["NDBno"].ToString());

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
            string ndbno = lblNdbno.Value;
            FoodItem.findNdbno(ndbno);

           
            String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //check if item already exists in database, if it does hide the save button and show the update button
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("Select * FROM wholesome_item WHERE ndb_no = @ndbno", connection);
                command.Parameters.Add("@ndbno", SqlDbType.NVarChar, 8).Value = ndbno;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    btnUpdate.Visible = true;
                    btnSaveItem.Visible = false;
                    txtCeresStatus.Text = "Matched";
                }
                else
                {
                    btnSaveItem.Visible = true;
                    txtCeresStatus.Text = "Unmatched";
                    btnUpdate.Visible = false;
                }
                connection.Close();
            }

            //saved into recent_index 
            //check if they login
            if (!checkndbno(ndbno))
            {

                if (HttpContext.Current.User.IsInRole("Admin"))
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO RECENT_INDEX(NDB_NO,LOGINID,LastUpdated,LastUpdatedBy) VALUES (@NDB_NO, @ID,@LastUpdated, @LastUpdatedby);", connection);
                        command.Parameters.Add("@NDB_NO", SqlDbType.NVarChar, 8).Value = ndbno;
                        command.Parameters.Add("@ID", SqlDbType.Int).Value = getloginid();
                        command.Parameters.Add("@LastUpdatedBy", SqlDbType.NVarChar, 20).Value = HttpContext.Current.User.Identity.GetUserName();
                        command.Parameters.Add("@LastUpdated", SqlDbType.DateTime, 128).Value = DateTime.Now;
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                else
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO RECENT_INDEX(NDB_NO,LOGINID,LastUpdated,LastUpdatedBy) VALUES (@NDB_NO, @ID,@LastUpdated, @LastUpdatedby);", connection);
                        command.Parameters.Add("@NDB_NO", SqlDbType.NVarChar, 8).Value = ndbno;
                        command.Parameters.Add("@ID", SqlDbType.Int).Value = DBNull.Value;
                        command.Parameters.Add("@LastUpdatedBy", SqlDbType.NVarChar, 20).Value = "Guest";
                        command.Parameters.Add("@LastUpdated", SqlDbType.DateTime, 128).Value = DateTime.Now;
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            else
            {
               //do nothing
            }

            double score = FoodItem.newFood.NRF6;
            String colorScaleStyle = "background-color: ";

            if(score < 4.66)
            {
                colorScaleStyle += GradientColors.getColor1() + "; color: white;";
            }
            else if ((score >= 4.66) && (score <= 28))
            {
                colorScaleStyle += GradientColors.getColor2() + "; color: black;";
            }
            else if (score > 28)
            {
                colorScaleStyle += GradientColors.getColor3() + "; color: white;";
            }
            else
            {
                // do nothing
            }

            nd_score_panel.Attributes["style"] = colorScaleStyle;

            lblFoodName.Text = FoodItem.newFood.name;
            lblFoodName.Attributes["style"] = "font-weight: bold;";
            lblIndexResult.Text = Convert.ToString(Math.Round(score, 2));
            lblNdbno.Value = FoodItem.newFood.ndbNo;
            lblName.Value = FoodItem.newFood.name;

            txtcalories.Text = FoodItem.newFood.kCal.ToString();
            txtsatfat.Text = Math.Round(FoodItem.newFood.satFat, 2).ToString();
            txtsodium.Text = Math.Round(FoodItem.newFood.sodium, 2).ToString();
            txtfiber.Text = Math.Round(FoodItem.newFood.fiber, 2).ToString();
            txtsugar.Text = Math.Round(FoodItem.newFood.totalSugar, 2).ToString();
            txtprotein.Text = Math.Round(FoodItem.newFood.protein, 2).ToString();
            txtva.Text = Math.Round(FoodItem.newFood.vitaminA, 2).ToString();
            txtvc.Text = Math.Round(FoodItem.newFood.vitaminC, 2).ToString();
            txtcalcium.Text = Math.Round(FoodItem.newFood.calcium, 2).ToString();
            txtiron.Text = Math.Round(FoodItem.newFood.iron, 2).ToString();

			// re-render bootstrap-select component
			ddlFBCategories.CssClass = "selectpicker";
			ddlFBCategories.Attributes["title"] = "Select a category";
			ddlFBCategories.Attributes["data-width"] = "100%";
			ddlFBCategories.Attributes["data-live-search"] = "true";
			ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "rerender", "$('.selectpicker').selectpicker('render');", true);
		}

		/***
		 * Using the static saved data in this class, update Wholesome_Item table.
		 * 
		 * TODO: 
		 * Check if the ceres item is null.
		 * If ceres item doesn't exist prompt the user to open ceres and enter it there first.
		 */
		public static String checkNDB_No(string ndbno)
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            String getNdb_No = "";
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand command = new SqlCommand("Select TOP 1 ndb_No  from recent_index where ndb_no=@ndb_no;", con);
                command.Parameters.Add("@ndb_no", SqlDbType.NVarChar, 8).Value = ndbno;
                con.Open();
                
                getNdb_No = command.ExecuteScalar().ToString();
                con.Close();
            }
            return getNdb_No;
            
        }

        public static bool checkndbno(String ndbno)
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("Select ndb_No From dbo.recent_index WHERE ndb_no = @ndb_no", connection);
                command.Parameters.Add("@ndb_no", SqlDbType.NVarChar, 8).Value = ndbno;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["ndb_no"].ToString().Equals(ndbno))
                    {
                        return true;
                    }

                }
                connection.Close();
            }
            return false;
            }
        public static String getloginid()
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

        protected void CompareItem(object sender, EventArgs e)
        {

            bool flag = false;
            String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            String ndbno = lblNdbno.Value;
            

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = new SqlCommand("Select ndb_no From dbo.Comparison_Item WHERE ndb_no = @ndb_no", connection);
                    command.Parameters.Add("@ndb_no", SqlDbType.NVarChar, 8).Value = ndbno;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader[0].ToString() == ndbno)
                        {
                            flag = true;
                            break;
                        }

                    }
                    connection.Close();
                    if (flag)
                    {
                        // food already been compared
                        string script = "alert(\"Item has already been added to comparison tool\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                    }
                    else
                    {
                        connection.Open();
                    SqlCommand command1 = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = System.Data.CommandType.Text,

                        CommandText = @"
					INSERT INTO [wholesomeDB].[dbo].[Comparison_Item] (
						[ndb_no],
						[nrf6],
						[FoodName],
						[loginID],
						[protein],
						[fiber],
						[VitaminA],
						[VitaminC],
						[Calcium],
						[Iron],
						[SaturatedFat],
						[TotalSugar],
						[Sodium],
						[KCal],
                        [LastupdatedBy],
                        [LastUpdated]
					) VALUES (
						@ndbno,
						@nrf6,
						@name,
						@loginid,
						@protein,
						@fiber,
						@va,
						@vc,
						@calcium,
						@iron,
						@satfat,
						@sugar,
						@sodium,
						@calories,
                        @lastupdatedby,
                        @lastupdated
					)
				"
                    };
                    if (lblIndexResult.Text == "NaN")
                    {
                        command1.Parameters.AddWithValue("@nrf6", DBNull.Value);
                    }
                    else
                    {
                        command1.Parameters.Add("@nrf6", SqlDbType.Decimal).Value = lblIndexResult.Text;
                    }

                    command1.Parameters.Add("@ndbno", SqlDbType.NVarChar, 8).Value = lblNdbno.Value;
                        //command1.Parameters.Add("@nrf6", SqlDbType.Decimal).Value = lblIndexResult.Text;
                        command1.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = lblName.Value;
                        command1.Parameters.Add("@loginid", SqlDbType.Int).Value = getloginid();
                        command1.Parameters.Add("@protein", SqlDbType.Decimal).Value = txtprotein.Text;
                        command1.Parameters.Add("@fiber", SqlDbType.Decimal).Value = txtfiber.Text;
                        command1.Parameters.Add("@va", SqlDbType.Decimal).Value = txtva.Text;
                        command1.Parameters.Add("@vc", SqlDbType.Decimal).Value = txtvc.Text;
                        command1.Parameters.Add("@calcium", SqlDbType.Decimal).Value = txtcalcium.Text;
                        command1.Parameters.Add("@iron", SqlDbType.Decimal).Value = txtiron.Text;
                        command1.Parameters.Add("@satfat", SqlDbType.Decimal, 20).Value = txtsatfat.Text;
                        command1.Parameters.Add("@sugar", SqlDbType.Decimal).Value = txtsugar.Text;
                        command1.Parameters.Add("@sodium", SqlDbType.Decimal).Value = txtsodium.Text;
                        command1.Parameters.Add("@calories", SqlDbType.Decimal).Value = txtcalories.Text;
                        command1.Parameters.Add("@lastupdatedby", SqlDbType.VarChar, 20).Value = "Yihui Zhou";
                        command1.Parameters.Add("@lastupdated", SqlDbType.Date).Value = DateTime.Now;

                        command1.ExecuteNonQuery();
                        connection.Close();

                    }
                }
            
        
            




            // Check if the ceres item is null. If ceres item doesn't exist prompt the user to open ceres and enter it there first
            //	if (txtCeresNumber.Text == "" || txtCeresDescription.Text == "") {
            //		using (SqlConnection connection = new SqlConnection(ConnectionString)) {
            //			SqlCommand command1 = new SqlCommand();
            //			command1.Connection = connection;
            //			command1.CommandType = System.Data.CommandType.Text;

            //			//if (FoodItem.newFood.name.Length > 48)
            //			//{
            //			//    FoodItem.newFood.name = FoodItem.newFood.name.Substring(0, 48);
            //			//}
            //			if (savedFoodGroup == "") { savedFoodGroup = "BRND"; }

            //			command1.CommandText = @"
            //				INSERT INTO [wholesomeDB].[dbo].[Wholesome_Item] (
            //					[NDB_No],
            //					[nrf6],
            //					[FdGrp_CD],
            //					[LastUpdatedBy],
            //					[LastUpdated],
            //					[Description 2]
            //				) VALUES (
            //					@ndbno,
            //					@nrf6,
            //					@FdGrp_CD,
            //					@lastupdatedby,
            //					@lastupdated,
            //					@Description2
            //				)
            //			";
            //			command1.Parameters.Add("@ndbno", SqlDbType.NVarChar, 8).Value = savedNdb_no;
            //			command1.Parameters.Add("@Description2", SqlDbType.NVarChar, 50).Value = lblName.Value;
            //			command1.Parameters.Add("@nrf6", SqlDbType.Decimal).Value = savedNrf6;
            //			command1.Parameters.Add("@FdGrp_CD", SqlDbType.NVarChar, 4).Value = savedFoodGroup;
            //			command1.Parameters.Add("@lastupdatedby", SqlDbType.NVarChar, 20).Value = "Nathan Hamrick";
            //			command1.Parameters.Add("@lastupdated", SqlDbType.Date).Value = DateTime.Now;

            //			connection.Open();
            //			command1.ExecuteNonQuery();
            //			connection.Close();
            //		}
            //	} else {
            //		using (SqlConnection connection = new SqlConnection(ConnectionString))
            //		{
            //			SqlCommand command1 = new SqlCommand();
            //			command1.Connection = connection;
            //			command1.CommandType = System.Data.CommandType.Text;

            //			//if (FoodItem.newFood.name.Length > 48)
            //			//{
            //			//    FoodItem.newFood.name = FoodItem.newFood.name.Substring(0, 48);
            //			//}


            //			command1.CommandText = @"UPDATE [wholesomeDB].[dbo].[Wholesome_Item] SET ndb_no = @ndbno, nrf6 = @nrf6, FdGrp_CD = @FdGrp_CD,"
            //			+ " LastUpdatedBy = @LastUpdatedBy, LastUpdated = @LastUpdated, [description 2] = @description2 WHERE No_ = @No_";

            //			command1.Parameters.Add("@No_", SqlDbType.NVarChar, 20).Value = txtCeresNumber.Text;
            //			command1.Parameters.Add("@ndbno", SqlDbType.NVarChar, 8).Value = FoodItem.newFood.ndbNo;
            //			command1.Parameters.Add("@description2", SqlDbType.VarChar, 50).Value = FoodItem.newFood.name;
            //			command1.Parameters.Add("@FdGrp_CD", SqlDbType.VarChar, 4).Value = FoodItem.newFood.foodGroup;
            //			command1.Parameters.Add("@nrf6", SqlDbType.Decimal).Value = FoodItem.newFood.NRF6;
            //			command1.Parameters.Add("@lastupdatedby", SqlDbType.NVarChar, 20).Value = "Nathan Hamrick";
            //			command1.Parameters.Add("@lastupdated", SqlDbType.Date).Value = DateTime.Now;

            //			connection.Open();
            //			command1.ExecuteNonQuery();
            //			connection.Close();
            //		}
            //	}

            //	savedNdb_no = "";

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
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
                    //String name = lblName.Text;
                    {
                        SqlCommand command1 = new SqlCommand
                        {
                            Connection = connection,
                            CommandType = System.Data.CommandType.Text,



                            CommandText = @"INSERT INTO [wholesomeDB].[dbo].[Wholesome_Item] ([No_], [ndb_no], [Description], [nrf6], [LoginID], [LastUpdatedBy], [LastUpdated], [description 2]) VALUES
                                      (@ceresitemnumber, @ndbno, @ceresdescription, @nrf6, @loginID, @lastupdatedby, @lastupdated, @name)"
                        };
                        // dealing with uncatogirzed food which has NaN nd_score
                        if (lblIndexResult.Text == "NaN")
                        {
                            command1.Parameters.AddWithValue("@nrf6", DBNull.Value);
                        }
                        else
                        {
                            command1.Parameters.Add("@nrf6", SqlDbType.Decimal).Value = FoodItem.newFood.NRF6;
                        }
                        command1.Parameters.Add("@ceresitemnumber", SqlDbType.NVarChar, 20).Value = txtCeresNumber.Text;
                        command1.Parameters.Add("@ndbno", SqlDbType.NVarChar, 8).Value = FoodItem.newFood.ndbNo;
                        command1.Parameters.Add("@ceresdescription", SqlDbType.NVarChar, 50).Value = txtCeresDescription.Text;
                        ////command1.Parameters.Add("@nrf6", SqlDbType.Decimal).Value = FoodItem.newFood.NRF6;
                        command1.Parameters.Add("@name", SqlDbType.NVarChar, 500).Value = FoodItem.newFood.name;            
                        command1.Parameters.Add("@loginID", SqlDbType.Int).Value = getloginid();
                        command1.Parameters.Add("@lastupdatedby", SqlDbType.NVarChar, 20).Value = "Nathan Hamrick";
                        command1.Parameters.Add("@lastupdated", SqlDbType.Date).Value = DateTime.Now;

                        connection.Open();
                        command1.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
        }

    }
}

