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
                lblTwo.Value = GradientValues.getValue1();
                lblThree.Value = GradientValues.getValue2();
                lblFour.Value = GradientValues.getValue3();
                lblFive.Value = GradientValues.getValue4();
                lblSix.Value = GradientValues.getValue5();
                lblSeven.Value = GradientValues.getValue6();
                lblEight.Value = GradientValues.getValue7();
                lblNine.Value = GradientValues.getValue8();

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
            GradientValues.setValue2(Convert.ToDouble(lblThree.Value));
            GradientValues.setValue3(Convert.ToDouble(lblFour.Value));
            GradientValues.setValue4(Convert.ToDouble(lblFive.Value));
            GradientValues.setValue5(Convert.ToDouble(lblSix.Value));
            GradientValues.setValue6(Convert.ToDouble(lblSeven.Value));
            GradientValues.setValue7(Convert.ToDouble(lblEight.Value));
            GradientValues.setValue8(Convert.ToDouble(lblNine.Value));

        }

    }
}