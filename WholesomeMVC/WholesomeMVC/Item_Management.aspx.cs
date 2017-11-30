using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wholesome
{
    public partial class Item_Management : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void btnAddItem_Click(object sender, EventArgs e)
        {

        }
    }
}