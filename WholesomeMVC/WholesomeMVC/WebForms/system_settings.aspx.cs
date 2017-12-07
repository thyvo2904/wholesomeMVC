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
				// set page variables
				String strTitle = "System Settings";
				Literal page_title = (Literal) Master.FindControl("page_title");
				page_title.Text = strTitle;
				Label body_title = (Label) Master.FindControl("body_title");
				body_title.Text = strTitle;

				// get data for gradient values
				lblOne.Value = GradientValues.getValue1();
				lblTwo.Value = GradientValues.getValue2();
				lblThree.Value = GradientValues.getValue3();

				String strAlgorithm = "Select Algorithm Options";
				image_algorithm.ImageUrl = "/Content/Images/icons8-workflow-100.png";
				button_algorithm.Text = strAlgorithm;
				title_algorithm.InnerText = strAlgorithm;

				String strTier = "Adjust Index Tiers";
				image_tier.ImageUrl = "/Content/Images/icons8-adjust-100.png";
				button_tier.Text = strTier;

				String strColor = "Change Gradient Colors";
				image_color.ImageUrl = "/Content/Images/icons8-paint-palette-100.png";
				button_color.Text = strColor;
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