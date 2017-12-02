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
			if (IsPostBack) {
				// do nothing
			} else {
				// set page variables
				String strTitle = "Nutrient Calculator";
				String strDescription = @"
                Manually input the value of each nutrient to calculate
                a score to compare to the nutrition grade";

				page_title.Text = strTitle;

				body_title.Text = strTitle;
				body_description.Text = strDescription;

				view_mode.Value = "old";

				String strScoreDefault = "0.0";

				txtindex0.Text = strScoreDefault;
				txtindex1.Text = strScoreDefault;

				String strScore = "ND_Score";
				String strScoreHelp = "Calculated based on 100kcal";

				label_score0.Text = strScore;
				label_score_help0.Text = strScoreHelp;

				label_score1.Text = strScore;
				label_score_help1.Text = strScoreHelp;

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

				label_txtKcal1.Text = strKcal;
				label_txtsatfat1.Text = strSatFat;
				label_txtsodium1.Text = strSodium;
				label_txtfiber1.Text = strFiber;
				label_txtsugar1.Text = strSugar;
				label_txtprotein1.Text = strProtein;

				String strVitaminA = "Vitamin A";
				String strVitaminC = "Vitamin C";
				String strVitaminD = "Vitamin D";
				String strCalcium = "Calcium";
				String strIron = "Iron";
				String strPotassium = "Potassium";

				label_txtva0.Text = strVitaminA;
				label_txtvc0.Text = strVitaminC;
				label_txtcalcium0.Text = strCalcium;
				label_txtiron0.Text = strIron;

				label_txtvd1.Text = strVitaminD;
				label_txtcalcium1.Text = strCalcium;
				label_txtiron1.Text = strIron;
				label_txtpotassium.Text = strPotassium;

				String strCalculate = "Calculate";
				String strReset = "Reset";

				button_calculate0.Text = strCalculate;
				button_reset0.Text = strReset;

				button_calculate1.Text = strCalculate;
				button_reset1.Text = strReset;
			}
		}

		protected void Reset0(object sender, EventArgs e)
		{
			txtindex0.Text = "0.0";

			txtKcal0.Text = null;
			txtcalcium0.Text = null;
			txtva0.Text = null;
			txtvc0.Text = null;
			txtprotein0.Text = null;
			txtfiber0.Text = null;
			txtsatfat0.Text = null;
			txtsugar0.Text = null;
			txtsodium0.Text = null;
			txtiron0.Text = null;

			view_mode.Value = "old";
		}

		protected void Calculate0(object sender, EventArgs e)
		{
			try
			{
				txtindex0.Text = String.Empty;
				double nR6;
				double liMT;
				double NRF6;

				//DV for Vitamin A: 5000UI
				//DV for Vitamin C: 60mg
				//DV for Iron: 18mg
				//DV for Calcium: 1000mg
				//DV for potassium: 4700mg
				//Conversion: 1IU = 0.025mcg
				double kCal = (Double.Parse(txtKcal0.Text));

				double calcium = (((Double.Parse(txtcalcium0.Text.Trim())) / 100) * 1000);
				double vitA = (((Double.Parse(txtva0.Text.Trim()) / 100)) * 5000);
				double vitC = (((Double.Parse(txtvc0.Text.Trim())) / 100) * 60);
				double protein = (Double.Parse(txtprotein0.Text));
				double fiber = (Double.Parse(txtfiber0.Text));
				double satFat = (Double.Parse(txtsatfat0.Text));
				double sugar = (Double.Parse(txtsugar0.Text));
				double sodium = (Double.Parse(txtsodium0.Text));
				double iron = (((Double.Parse(txtiron0.Text.Trim())) / 100) * 18);

				nR6 = (
					(
						(
							(protein / 50) + (fiber / 25) + (vitA / 5000) + (vitC / 60) + (calcium / 1000) + (iron / 18)
						) * 100
					) / (kCal / 100)
				);

				liMT = (
					(
						(
							(satFat / 20) + (sugar / 125) + (sodium / 2400)
						) * 100
					) / (kCal / 100)
				);

				NRF6 = Math.Round(nR6 - liMT, 2);
				txtindex0.Text = Convert.ToString(NRF6);

				if (txtKcal0.Text.Equals(0))
				{
					txtindex0.Text = "Uncategorized";
					txtindex0.Attributes["style"] = "font-weight:bold;text-align: center; font-size: 110%";
				}
				else if (NRF6 < 4.66)
				{
					txtindex0.Attributes["style"] = "color:red; font-weight:bold;text-align: center; font-size: 110%";
				}
				else if ((NRF6 >= 4.66) && (NRF6 <= 28))
				{
					txtindex0.Attributes["style"] = "background-color:yellow; font-weight:bold;text-align: center; font-size: 110%";
				}
				else if (NRF6 > 28)
				{
					txtindex0.Attributes["style"] = "color:green; font-weight:bold;text-align: center; font-size: 110%";

				}
			}
			catch (Exception ex)
			{
				Response.Write("<script>alert('Please enter a valid value');</script>");
				Console.WriteLine(ex.ToString());
			}

			view_mode.Value = "old";
		}

		protected void Reset1(object sender, EventArgs e)
		{
			txtindex1.Text = "0.0";

			txtKcal1.Text = null;
			txtcalcium1.Text = null;
			txtvd1.Text = null;
			txtprotein1.Text = null;
			txtfiber1.Text = null;
			txtsatfat1.Text = null;
			txtsugar1.Text = null;
			txtsodium1.Text = null;
			txtiron1.Text = null;
			txtpotassium.Text = null;

			view_mode.Value = "new";
		}

		protected void Calculate1(object sender, EventArgs e)
		{
			try
			{
				txtindex1.Text = String.Empty;
				double nR6;
				double liMT;
				double NRF6;

				//DV for Vitamin A: 5000UI
				//DV for Vitamin C: 60mg
				//DV for Iron: 18mg
				//DV for Calcium: 1000mg
				//DV for potassium: 4700mg
				//Conversion: 1IU = 0.025mcg
				double iron = Double.Parse(txtiron1.Text);
				double calcium = Double.Parse(txtcalcium1.Text);
				double kCal = Double.Parse(txtKcal1.Text);
				double protein = Double.Parse(txtprotein1.Text);
				double fiber = Double.Parse(txtfiber1.Text);
				double satFat = Double.Parse(txtsatfat1.Text);
				double sodium = Double.Parse(txtsodium1.Text);
				double vitD = Double.Parse(txtvd1.Text) / 0.025;
				double potassium = Double.Parse(txtpotassium.Text);
				double addedsugar = Double.Parse(txtsugar1.Text);

				//new
				nR6 = (
					(
						(
							(100 / kCal) * protein / 50
						) + (
							(100 / kCal) * fiber / 25
						) + (
							(100 / kCal) * vitD / 600
						) + (
							(100 / kCal) * potassium / 4700
						) + (
							(100 / kCal) * calcium / 1000
						) + (
							(100 / kCal) * iron / 18
						)
					) * 100
				);

				liMT = (
					(
						(100 / kCal) * satFat / 20
					) + (
						(100 / kCal) * addedsugar / 50
					) + (
						(100 / kCal) * sodium / 2400
					) * 100
				);

				NRF6 = Math.Round(nR6 - liMT, 2);
				txtindex1.Text = Convert.ToString(NRF6);

				if (txtKcal1.Text.Equals(0))
				{
					txtindex1.Text = "Uncategorized";
					txtindex1.Attributes["style"] = "font-weight:bold;text-align: center; font-size: 110%";
				}
				else if (NRF6 < 4.66)
				{
					txtindex1.Attributes["style"] = "color:red; font-weight:bold;text-align: center; font-size: 110%";
				}
				else if ((NRF6 >= 4.66) && (NRF6 <= 28))
				{
					txtindex1.Attributes["style"] = "color:yellow; font-weight:bold;background: black;text-align: center; font-size: 110%";
				}
				else if (NRF6 > 28)
				{
					txtindex1.Attributes["style"] = "color:green; font-weight:bold;text-align: center; font-size: 110%";
				}
				else
				{
					txtindex1.Text = "Uncategorized";
					txtindex1.Attributes["style"] = "font-weight:bold;text-align: center; font-size: 110%";
				}
			}
			catch (Exception ei)
			{
				Response.Write("<script>alert('Please enter a valid value');</script>");
				Console.WriteLine(ei.ToString());
			}

			view_mode.Value = "new";
		}
	}
}