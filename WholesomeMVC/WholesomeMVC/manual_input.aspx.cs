using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data.SqlClient;

namespace Wholesome
{
    public partial class manual_input : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

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
                Server.Transfer("~/IndexResults.aspx");
            }

            else
            {
                Response.Write("<script>alert('Please enter a value');</script>");
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                txtindex.Value = String.Empty;
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


                nR6 = ((((protein / 50) + (fiber / 25) + (vitA / 5000) + (vitC / 60) + (calcium / 1000)
             + (iron / 18)) * 100) / (kCal / 100));

                liMT = ((((satFat / 20) + (sugar / 125) + (sodium / 2400)) * 100) / (kCal / 100));

                NRF6 = Math.Round(nR6 - liMT, 2);
                txtindex.Value = Convert.ToString(NRF6);

                if (txtKcal0.Text.Equals(0))
                {
                    txtindex.Value = "Uncategorized";
                    txtindex.Attributes["style"] = "font-weight:bold;text-align: center; font-size: 110%";
                }
                else if (NRF6 < 4.66)
                {
                    txtindex.Attributes["style"] = "color:red; font-weight:bold;text-align: center; font-size: 110%";
                }
                else if ((NRF6 >= 4.66) && (NRF6 <= 28))
                {
                    txtindex.Attributes["style"] = "background-color:yellow; font-weight:bold;text-align: center; font-size: 110%";
                }
                else if (NRF6 > 28)
                {
                    txtindex.Attributes["style"] = "color:green; font-weight:bold;text-align: center; font-size: 110%";

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Please enter a valid value');</script>");
            }
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                txtindex2.Value = String.Empty;
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
                double kCal = Double.Parse(txtkcal1.Text);
                double protein = Double.Parse(txtprotein1.Text);
                double fiber = Double.Parse(txtfiber1.Text);
                double satFat = Double.Parse(txtsatfat1.Text);
                double sodium = Double.Parse(txtsodium1.Text);
                double vitD = Double.Parse(txtvd1.Text) / 0.025;
                double potassium = Double.Parse(txtpotassium.Text);
                double addedsugar = Double.Parse(addsugar1.Text);

                //new
                nR6 = ((((100 / kCal) * protein / 50) + ((100 / kCal) * fiber / 25) + ((100 / kCal) * vitD / 600)
                          + ((100 / kCal) * potassium / 4700) + ((100 / kCal) * calcium / 1000) + ((100 / kCal) * iron / 18)) * 100);

                liMT = (((100 / kCal) * satFat / 20) + ((100 / kCal) * addedsugar / 50) + ((100 / kCal) * sodium / 2400) * 100);




                NRF6 = Math.Round(nR6 - liMT, 2);
                txtindex2.Value = Convert.ToString(NRF6);

                if (txtkcal1.Text.Equals(0))
                {
                    txtindex2.Value = "Uncategorized";
                    txtindex2.Attributes["style"] = "font-weight:bold;text-align: center; font-size: 110%";
                }
                else if (NRF6 < 4.66)
                {
                    txtindex2.Attributes["style"] = "color:red; font-weight:bold;text-align: center; font-size: 110%";
                }
                else if ((NRF6 >= 4.66) && (NRF6 <= 28))
                {
                    txtindex2.Attributes["style"] = "color:yellow; font-weight:bold;background: black;text-align: center; font-size: 110%";
                }
                else if (NRF6 > 28)
                {
                    txtindex2.Attributes["style"] = "color:green; font-weight:bold;text-align: center; font-size: 110%";
                }
                else
                {
                    txtindex2.Value = "Uncategorized";
                    txtindex2.Attributes["style"] = "font-weight:bold;text-align: center; font-size: 110%";
                }
            }
            catch (Exception ei)
            {
                Response.Write("<script>alert('Please enter a valid value');</script>");
            }
        }
    }
}
    
