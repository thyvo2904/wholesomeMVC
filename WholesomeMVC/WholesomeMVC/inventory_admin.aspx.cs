using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using WholesomeMVC;

public partial class inventory_admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["name"] == null)
            Server.TransferRequest("~/login.aspx");
        else
            lblName.Text = Session["name"].ToString();
        if (!IsPostBack)
        {


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