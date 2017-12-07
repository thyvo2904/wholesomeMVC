using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WholesomeMVC;

namespace WholesomeMVC.WebForms
{
    public partial class system_settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            

            lblOne.Value = GradientValues.getValue1();
                lblTwo.Value = GradientValues.getValue2();
                lblThree.Value = GradientValues.getValue3();
        

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

        protected void btnSaveValues(object sender, EventArgs e)
        {
            GradientValues.setValue1(Convert.ToDouble(lblOne.Value));
            GradientValues.setValue2(Convert.ToDouble(lblTwo.Value));
            GradientValues.setValue3(Convert.ToDouble(lblThree.Value));
    

        }

    }
}