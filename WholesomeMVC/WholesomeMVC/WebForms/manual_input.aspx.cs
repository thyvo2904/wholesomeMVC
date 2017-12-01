using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WholesomeMVC
{
    public partial class manual_input1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // set page variables
            String strTitle = "Nutrient Calculator";
            String strDescription = @"
                Manually input the value of each nutrient to calculate
                a score to compare to the nutrition grade";

            page_title.Text = strTitle;

            body_title.Text = strTitle;
            body_description.Text = strDescription;

            label_score.Text = "ND_Score";
            label_score_help.Text = "Calculated based on 100kcal";

			String strKcal = "Calories";
			String strSatFat = "Saturated Fat";
			String strSodium = "Sodium";
			String strFiber = "Dietary Fiber";
			String strSugar = "Total Sugar";
			String strProtein = "Protein";

			label_txtKcal0.Text = strKcal;
			label_txtsatfat0.Text = strSatFat;
			label_txtsodium0.Text = strSodium;
			label_txtfiber0.Text = strFiber;
			label_txtsugar0.Text = strSugar;
			label_txtprotein0.Text = strProtein;

			String strVitaminA = "Vitamin A";
			String strVitaminC = "Vitamin C";
			String strCalcium = "Calcium";
			String strIron = "Iron";

			label_txtva0.Text = strVitaminA;
			label_txtvc0.Text = strVitaminC;
			label_txtcalcium0.Text = strCalcium;
			label_txtiron0.Text = strIron;
        }
    }
}