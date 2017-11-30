using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WholesomeMVC
{
    public partial class inventory_staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    System.Data.SqlClient.SqlCommand go = new System.Data.SqlClient.SqlCommand();

                    con.Open();
                    go.Connection = con;
                    go.CommandText = "SELECT FdGrp_Desc FROM [FD_Group]";
                    go.ExecuteNonQuery();

                    SqlDataReader readIn = go.ExecuteReader();
                    while (readIn.Read())
                    {
                        ddlCategory.Items.Add(new ListItem(readIn["FdGrp_Desc"].ToString()));
                    }

                    con.Close();

                    ddlCategory.Items.Insert(0, new ListItem("--Select Category--", "0"));
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
                Response.Redirect("~/IndexResults.aspx");
            }

            else
            {
                Response.Write("<script>alert('Please enter a value');</script>");
            }
        }
    }
}