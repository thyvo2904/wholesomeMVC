using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WholesomeMVC.WebForms;

public partial class inventory_admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection
            //{
            //    ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            //};

            //sc.Open();
            //SqlCommand myCommand = new SqlCommand("Pull_Ceres_Weight",sc);
            //myCommand.CommandType = CommandType.StoredProcedure;
            //myCommand.ExecuteNonQuery();
            //sc.Close();

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
    protected void btnlogout_click(object sender, EventArgs e)
    {
        Session["name"] = null;
    }
}