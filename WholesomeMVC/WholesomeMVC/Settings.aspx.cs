using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WholesomeMVC;

public partial class Settings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblName.Text = login.newAccount.firstname ;
        lblUsername.Text = login.newAccount.firstname+ "  " + login.newAccount.lastname;
        lblPassword.Text = login.newAccount.passwordhash;
        lblEmail.Text =login.newAccount.email;

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
}