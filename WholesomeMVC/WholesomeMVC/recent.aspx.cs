using WholesomeMVC;
using System;
using System.Net;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class recent : System.Web.UI.Page
{

    public static String[] ndbnoArray = new String[8];
    public static int marker = 0;
    public static FoodItem[] newFoodArray = new FoodItem[6];

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {   

        }

        Boolean hasRows = true;
        marker = 0;
        Array.Clear(ndbnoArray, 0, ndbnoArray.Length);
        Array.Clear(newFoodArray, 0, newFoodArray.Length);

        int counter = 0;

        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
    };

        sc.Open();

        SqlDataReader newReader = null;
        SqlCommand myCommand = new SqlCommand("SELECT ndb_no FROM RECENT_INDEX ORDER BY SearchDate DESC",
                                                 sc);
        newReader = myCommand.ExecuteReader();
        if (newReader.HasRows)
        {
            while (newReader.Read())
            {



                if (counter < 6)
                {
                    ndbnoArray[counter] = newReader["ndb_no"].ToString();
                    counter++;
                }


            }
        }

        else
        {
            hasRows = false;
        }
        sc.Close();

        //ArrayList ndbnoURLArray = new ArrayList();
        String urlRequest = "";
        if (hasRows)
        {
            for (int i = 0; i < ndbnoArray.Length; i++)
            {
                if (ndbnoArray[i] != null)
                {
                    if (i == 0)
                    {
                        urlRequest += ndbnoArray[i].ToString();
                    }

                    else
                    {
                        urlRequest += "&ndbno=";
                        urlRequest += ndbnoArray[i].ToString();
                    }
                }
            }

            String urlPartOne = "https://api.nal.usda.gov/ndb/V2/reports?ndbno=";
            String urlPartTwo = "&type=b&format=json&api_key=m37cNkiJMin6FLxPuq6wDMqtFekEJYB6HJpbLrYb";

            String url = urlPartOne + urlRequest + urlPartTwo;

            var json = new WebClient().DownloadString(url);

            var result = JsonConvert.DeserializeObject<RootObject>(json);
            String name = "";
            double protein = 0;
            double fiber = 0;
            //double vitaminD = 0;
            double vitaminA = 0;
            double vitaminC = 0;
            //double potassium = 0;
            double calcium = 0;
            double iron = 0;
            double kCal = 0;
            double satFat = 0;
            double totalSugar = 0;
            //double addedSugar = 0;
            double sodium = 0;

            double nR6 = 0;
            double liMT = 0;
            double NRF6 = 0;
            
            for (int i = 0; i < result.foods.Count; i++)
            {
                FoodItem newFoodItem = new FoodItem();
                foreach (Nutrient item in result.foods[i].food.nutrients)
                {
                    newFoodItem.name = result.foods[i].food.desc.name;

                    // Good nutrients
                    if (Int32.Parse(item.nutrient_id) == 203)
                    {
                        newFoodItem.protein = Double.Parse(item.value);
                    }

                    if (Int32.Parse(item.nutrient_id) == 291)
                    {
                        newFoodItem.fiber = Double.Parse(item.value);
                    }

                    if (Int32.Parse(item.nutrient_id) == 318)
                    {
                        newFoodItem.vitaminA = Double.Parse(item.value);
                    }

                    if (Int32.Parse(item.nutrient_id) == 401)
                    {
                        newFoodItem.vitaminC = Double.Parse(item.value);
                    }

                    if (Int32.Parse(item.nutrient_id) == 301)
                    {
                        newFoodItem.calcium = Double.Parse(item.value);
                    }

                    if (Int32.Parse(item.nutrient_id) == 303)
                    {
                        newFoodItem.iron = Double.Parse(item.value);
                    }

                    if (Int32.Parse(item.nutrient_id) == 208)
                    {
                        newFoodItem.kCal = Double.Parse(item.value);
                    }



                    // Bad nutrients
                    if (Int32.Parse(item.nutrient_id) == 606)
                    {
                        newFoodItem.satFat = Double.Parse(item.value);
                    }

                    if (Int32.Parse(item.nutrient_id) == 269)
                    {
                        newFoodItem.totalSugar = Double.Parse(item.value);
                    }

                    if (Int32.Parse(item.nutrient_id) == 307)
                    {
                        newFoodItem.sodium = Double.Parse(item.value);
                    }

                }



                //nR6 = ((((kCal / 100) * protein / 50) + ((kCal / 100) * fiber / 25) + ((kCal / 100) * vitaminA / 5000)
                //               + ((kCal / 100) * vitaminC / 60) + ((kCal / 100) * calcium / 1000) + ((kCal / 100) * iron / 18)) * 100);
                //newFoodItem.nR6 = nR6;

                //liMT = ((((kCal / 100) * satFat / 20) + ((kCal / 100) * totalSugar / 125) + ((kCal / 100) * sodium / 2400)) * 100);
                //newFoodItem.liMT = liMT;

                //NRF6 = Math.Round(nR6 - liMT,2);
                //newFoodItem.NRF6 = NRF6;

                newFoodItem.calculateNRF6();
                
                //String darkRed = "#ED1C24";
                //String medRed = "#F15B22";
                //String lightRed = "#F6851F";
                //String darkYellow = "#F9B517";
                //String medYellow = "#F6E700";
                //String lightYellow = "#CECF2A";
                //String darkGreen = "#11A44A";
                //String medGreen = "#0B6F39";
                //String lightGreen = "#1F4821";


                newFoodArray[i] = newFoodItem;
                
                for (int j = 0; j < newFoodArray.Length; j++)
                {
                    if (j == 0 && newFoodArray[j] != null)
                    {
                        lblIndexResult.Text = newFoodArray[j].NRF6.ToString();
                        lblName.Text = newFoodArray[j].name.ToString();
                        section1.Visible = true;

                        txtprotein.Value = newFoodArray[j].protein.ToString();
                        txtfiber.Value = newFoodArray[j].fiber.ToString();
                        txtva.Value = newFoodArray[j].vitaminA.ToString();
                        txtvc.Value = newFoodArray[j].vitaminC.ToString();
                        txtcalcium.Value = newFoodArray[j].calcium.ToString();
                        txtiron.Value = newFoodArray[j].iron.ToString();
                        txtcalories.Value = newFoodArray[j].kCal.ToString();
                        txtsatfat.Value = newFoodArray[j].satFat.ToString();
                        txtsugar.Value = newFoodArray[j].totalSugar.ToString();
                        txtsodium.Value = newFoodArray[j].sodium.ToString();

                        if (newFoodArray[j].NRF6 < 0)
                        {
                            divcolor1.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor1() + "; font-weight:bold;";
                            //lblIndexResult.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor1() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 >= 0) && (newFoodArray[j].NRF6 <= 2.33))
                        {
                            divcolor1.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor2() + "; font-weight:bold;"; ;
                            //lblIndexResult.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor2() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > 2.33) && (newFoodArray[j].NRF6 <= 4.66))
                        {
                            divcolor1.Attributes["style"]= "color:black; background-color:" + GradientColors.getColor3() + "; font-weight:bold;";
                            //lblIndexResult.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor3() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > 4.66) && (newFoodArray[j].NRF6 <= 12.44))
                        {
                            divcolor1.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor4() + "; font-weight:bold;";
                            //lblIndexResult.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor4() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > 12.44) && (newFoodArray[j].NRF6 <= 20.22))
                        {
                            divcolor1.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor5() + "; font-weight:bold;";
                            //lblIndexResult.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor5() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > 20.22) && (newFoodArray[j].NRF6 <= 28))
                        {
                            divcolor1.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor6() + "; font-weight:bold;";
                            //lblIndexResult.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor6() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > 28) && (newFoodArray[j].NRF6 <= 35.33))
                        {
                            divcolor1.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor7() + "; font-weight:bold;";
                            //lblIndexResult.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor7() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > 35.33) && (newFoodArray[j].NRF6 <= 42.67))
                        {
                            divcolor1.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor8() + "; font-weight:bold;";
                            //lblIndexResult.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor8() + "; font-weight:bold;";
                        }

                        else if (newFoodArray[j].NRF6 > 42.67)
                        {
                            divcolor1.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor9() + "; font-weight:bold;";
                            //lblIndexResult.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor9() + "; font-weight:bold;";
                        }
                    }

                    else if (j == 1 && newFoodArray[j] != null)
                    {
                        lblIndexResult2.Text = newFoodArray[j].NRF6.ToString();
                        lblName2.Text = newFoodArray[j].name.ToString();
                        section2.Visible = true;

                        txtprotein2.Value = newFoodArray[j].protein.ToString();
                        txtfiber2.Value = newFoodArray[j].fiber.ToString();
                        txtva2.Value = newFoodArray[j].vitaminA.ToString();
                        txtvc2.Value = newFoodArray[j].vitaminC.ToString();
                        txtcalcium2.Value = newFoodArray[j].calcium.ToString();
                        txtiron2.Value = newFoodArray[j].iron.ToString();
                        txtcalories2.Value = newFoodArray[j].kCal.ToString();
                        txtsatfat2.Value = newFoodArray[j].satFat.ToString();
                        txtsugar2.Value = newFoodArray[j].totalSugar.ToString();
                        txtsodium2.Value = newFoodArray[j].sodium.ToString();

                        if (newFoodArray[j].NRF6 < 0)
                        {
                            divcolor2.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor1() + "; font-weight:bold;";
                            //lblIndexResult2.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor1() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 >= 0) && (newFoodArray[j].NRF6 <= 2.33))
                        {
                            divcolor2.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor2() + "; font-weight:bold;";
                            //lblIndexResult2.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor2() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > 2.33) && (newFoodArray[j].NRF6 <= 4.66))
                        {
                            divcolor2.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor3() + "; font-weight:bold;";
                            //lblIndexResult2.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor3() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > 4.66) && (newFoodArray[j].NRF6 <= 12.44))
                        {
                            divcolor2.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor4() + "; font-weight:bold;";
                            //lblIndexResult2.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor4() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > 12.44) && (newFoodArray[j].NRF6 <= 20.22))
                        {
                            divcolor2.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor5() + "; font-weight:bold;";
                            //lblIndexResult2.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor5() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > 20.22) && (newFoodArray[j].NRF6 <= 28))
                        {
                            divcolor2.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor6() + "; font-weight:bold;";
                            //lblIndexResult2.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor6() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > 28) && (newFoodArray[j].NRF6 <= 35.33))
                        {
                            divcolor2.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor7() + "; font-weight:bold;";
                            //lblIndexResult2.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor7() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > 35.33) && (newFoodArray[j].NRF6 <= 42.67))
                        {
                            divcolor2.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor8() + "; font-weight:bold;";
                            //lblIndexResult2.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor8() + "; font-weight:bold;";
                        }

                        else if (newFoodArray[j].NRF6 > 42.67)
                        {
                            divcolor2.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor9() + "; font-weight:bold;";
                            //lblIndexResult2.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor9() + "; font-weight:bold;";
                        }
                    }

                    else if (j == 2 && newFoodArray[j] != null)
                    {
                        lblIndexResult3.Text = newFoodArray[j].NRF6.ToString();
                        lblName3.Text = newFoodArray[j].name.ToString();
                        section3.Visible = true;

                        txtprotein3.Value = newFoodArray[j].protein.ToString();
                        txtfiber3.Value = newFoodArray[j].fiber.ToString();
                        txtva3.Value = newFoodArray[j].vitaminA.ToString();
                        txtvc3.Value = newFoodArray[j].vitaminC.ToString();
                        txtcalcium3.Value = newFoodArray[j].calcium.ToString();
                        txtiron3.Value = newFoodArray[j].iron.ToString();
                        txtcalories3.Value = newFoodArray[j].kCal.ToString();
                        txtsatfat3.Value = newFoodArray[j].satFat.ToString();
                        txtsugar3.Value = newFoodArray[j].totalSugar.ToString();
                        txtsodium3.Value = newFoodArray[j].sodium.ToString();

                        if (newFoodArray[j].NRF6 < Convert.ToDouble(GradientValues.getValue1()))
                        {
                            divcolor3.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor1() + "; font-weight:bold;";
                            //lblIndexResult3.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor1() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 >= Convert.ToDouble(GradientValues.getValue1())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue2())))
                        {
                            divcolor3.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor2() + "; font-weight:bold;";
                            //lblIndexResult3.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor2() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue2())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue3())))
                        {
                            divcolor3.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor3() + "; font-weight:bold;";
                            //lblIndexResult3.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor3() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue3())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue4())))
                        {
                            divcolor3.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor4() + "; font-weight:bold;";
                            //lblIndexResult3.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor4() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue4())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue5())))
                        {
                            divcolor3.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor5() + "; font-weight:bold;";
                            //lblIndexResult3.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor5() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue5())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue6())))
                        {
                            divcolor3.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor6() + "; font-weight:bold;";
                            //lblIndexResult3.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor6() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue6())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue7())))
                        {
                            divcolor3.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor7() + "; font-weight:bold;";
                            //lblIndexResult3.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor7() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue7())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue8())))
                        {
                            divcolor3.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor8() + "; font-weight:bold;";
                            //lblIndexResult3.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor8() + "; font-weight:bold;";
                        }

                        else if (newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue8()))
                        {
                            divcolor3.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor9() + "; font-weight:bold;";
                            //lblIndexResult3.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor9() + "; font-weight:bold;";
                        }
                    }
                    else if (j == 3 && newFoodArray[j] != null)
                    {
                        lblIndexResult4.Text = newFoodArray[j].NRF6.ToString();
                        lblName4.Text = newFoodArray[j].name.ToString();
                        section4.Visible = true;

                        txtprotein4.Value = newFoodArray[j].protein.ToString();
                        txtfiber4.Value = newFoodArray[j].fiber.ToString();
                        txtva4.Value = newFoodArray[j].vitaminA.ToString();
                        txtvc4.Value = newFoodArray[j].vitaminC.ToString();
                        txtcalcium4.Value = newFoodArray[j].calcium.ToString();
                        txtiron4.Value = newFoodArray[j].iron.ToString();
                        txtcalories4.Value = newFoodArray[j].kCal.ToString();
                        txtsatfat4.Value = newFoodArray[j].satFat.ToString();
                        txtsugar4.Value = newFoodArray[j].totalSugar.ToString();
                        txtsodium4.Value = newFoodArray[j].sodium.ToString();

                        if (newFoodArray[j].NRF6 < Convert.ToDouble(GradientValues.getValue1()))
                        {
                            divcolor4.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor1() + "; font-weight:bold;";
                            //lblIndexResult4.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor1() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 >= Convert.ToDouble(GradientValues.getValue1())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue2())))
                        {
                            divcolor4.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor2() + "; font-weight:bold;";
                            lblIndexResult4.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor2() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue2())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue3())))
                        {
                            divcolor4.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor3() + "; font-weight:bold;";
                            //lblIndexResult4.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor3() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue3())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue4())))
                        {
                            divcolor4.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor4() + "; font-weight:bold;";
                            //lblIndexResult4.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor4() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue4())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue5())))
                        {
                            divcolor4.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor5() + "; font-weight:bold;";
                            //lblIndexResult4.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor5() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue5())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue6())))
                        {
                            divcolor4.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor6() + "; font-weight:bold;";
                            //lblIndexResult4.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor6() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue6())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue7())))
                        {
                            divcolor4.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor7() + "; font-weight:bold;";
                            //lblIndexResult4.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor7() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue7())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue8())))
                        {
                            divcolor4.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor8() + "; font-weight:bold;";
                            //lblIndexResult4.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor8() + "; font-weight:bold;";
                        }

                        else if (newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue8()))
                        {
                            divcolor4.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor9() + "; font-weight:bold;";
                            //lblIndexResult4.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor9() + "; font-weight:bold;";
                        }
                    }

                    else if (j == 4 && newFoodArray[j] != null)
                    {
                        lblIndexResult5.Text = newFoodArray[j].NRF6.ToString();
                        lblName5.Text = newFoodArray[j].name.ToString();
                        section5.Visible = true;

                        txtprotein5.Value = newFoodArray[j].protein.ToString();
                        txtfiber5.Value = newFoodArray[j].fiber.ToString();
                        txtva5.Value = newFoodArray[j].vitaminA.ToString();
                        txtvc5.Value = newFoodArray[j].vitaminC.ToString();
                        txtcalcium5.Value = newFoodArray[j].calcium.ToString();
                        txtiron5.Value = newFoodArray[j].iron.ToString();
                        txtcalories5.Value = newFoodArray[j].kCal.ToString();
                        txtsatfat5.Value = newFoodArray[j].satFat.ToString();
                        txtsugar5.Value = newFoodArray[j].totalSugar.ToString();
                        txtsodium5.Value = newFoodArray[j].sodium.ToString();

                        if (newFoodArray[j].NRF6 < Convert.ToDouble(GradientValues.getValue1()))
                        {
                            divcolor5.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor1() + "; font-weight:bold;";
                            //lblIndexResult5.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor1() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 >= Convert.ToDouble(GradientValues.getValue1())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue2())))
                        {
                            divcolor5.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor2() + "; font-weight:bold;";
                            //lblIndexResult5.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor2() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue2())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue3())))
                        {
                            divcolor5.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor3() + "; font-weight:bold;";
                            //lblIndexResult5.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor3() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue3())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue4())))
                        {
                            divcolor5.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor4() + "; font-weight:bold;";
                            //lblIndexResult5.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor4() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue4())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue5())))
                        {
                            divcolor5.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor5() + "; font-weight:bold;";
                            //lblIndexResult5.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor5() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue5())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue6())))
                        {
                            divcolor5.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor6() + "; font-weight:bold;";
                            //lblIndexResult5.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor6() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue6())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue7())))
                        {
                            divcolor5.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor7() + "; font-weight:bold;";
                            //lblIndexResult5.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor7() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue7())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue8())))
                        {
                            divcolor5.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor8() + "; font-weight:bold;";
                            //lblIndexResult5.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor8() + "; font-weight:bold;";
                        }

                        else if (newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue8()))
                        {
                            divcolor5.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor9() + "; font-weight:bold;";
                            //lblIndexResult5.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor9() + "; font-weight:bold;";
                        }
                    }

                    else if (j == 5 && newFoodArray[j] != null)
                    {
                        lblIndexResult6.Text = newFoodArray[j].NRF6.ToString();
                        lblName6.Text = newFoodArray[j].name.ToString();
                        section6.Visible = true;

                        txtprotein6.Value = newFoodArray[j].protein.ToString();
                        txtfiber6.Value = newFoodArray[j].fiber.ToString();
                        txtva6.Value = newFoodArray[j].vitaminA.ToString();
                        txtvc6.Value = newFoodArray[j].vitaminC.ToString();
                        txtcalcium6.Value = newFoodArray[j].calcium.ToString();
                        txtiron6.Value = newFoodArray[j].iron.ToString();
                        txtcalories6.Value = newFoodArray[j].kCal.ToString();
                        txtsatfat6.Value = newFoodArray[j].satFat.ToString();
                        txtsugar6.Value = newFoodArray[j].totalSugar.ToString();
                        txtsodium6.Value = newFoodArray[j].sodium.ToString();

                        if (newFoodArray[j].NRF6 < Convert.ToDouble(GradientValues.getValue1()))
                        {
                            divcolor6.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor1() + "; font-weight:bold;";
                            //lblIndexResult6.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor1() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 >= Convert.ToDouble(GradientValues.getValue1())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue2())))
                        {
                            divcolor6.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor2() + "; font-weight:bold;";
                            //lblIndexResult6.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor2() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue2())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue3())))
                        {
                            divcolor6.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor3() + "; font-weight:bold;";
                            //lblIndexResult6.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor3() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue3())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue4())))
                        {
                            divcolor6.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor4() + "; font-weight:bold;";
                            //lblIndexResult6.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor4() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue4())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue5())))
                        {
                            divcolor6.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor5() + "; font-weight:bold;";
                            //lblIndexResult6.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor5() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue5())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue6())))
                        {
                            divcolor6.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor6() + "; font-weight:bold;";
                            //lblIndexResult6.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor6() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue6())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue7())))
                        {
                            divcolor6.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor7() + "; font-weight:bold;";
                            //lblIndexResult6.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor7() + "; font-weight:bold;";
                        }

                        else if ((newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue7())) && (newFoodArray[j].NRF6 <= Convert.ToDouble(GradientValues.getValue8())))
                        {
                            divcolor6.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor8() + "; font-weight:bold;";
                            //lblIndexResult6.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor8() + "; font-weight:bold;";
                        }

                        else if (newFoodArray[j].NRF6 > Convert.ToDouble(GradientValues.getValue8()))
                        {
                            divcolor6.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor9() + "; font-weight:bold;";
                            //lblIndexResult6.Attributes["style"] = "color:black; background-color:" + GradientColors.getColor9() + "; font-weight:bold;";
                        }
                    }

                }




            }
        }
    }


    protected void btnSaveItem_Click(object sender, EventArgs e)
    {
        

        String urlPartOne = "https://api.nal.usda.gov/ndb/search/?format=json&q=";
        String urlPartTwo = "&sort=n&max=25&offset=0&api_key=m37cNkiJMin6FLxPuq6wDMqtFekEJYB6HJpbLrYb";
        
        String food = "";

        
        food = food.Substring(0, 1);
        

        

        double protein = 0;
        double fiber = 0;
        //double vitaminD = 0;
        double vitaminA = 0;
        double vitaminC = 0;
        //double potassium = 0;
        double calcium = 0;
        double iron = 0;
        double kCal = 0;
        double satFat = 0;
        double totalSugar = 0;
        //double addedSugar = 0;
        double sodium = 0;

        double nR6 = 0;
        double liMT = 0;
        double NRF6 = 0;

        String reportUrlPartOne = "https://api.nal.usda.gov/ndb/V2/reports?ndbno=";
        String reportUrlPartTwo = "&type=b&format=json&api_key=m37cNkiJMin6FLxPuq6wDMqtFekEJYB6HJpbLrYb";
        String reportFood = ndbnoArray[Int32.Parse(food) - 1];

        String reportUrl = reportUrlPartOne + reportFood + reportUrlPartTwo;
        var jsonReport = new WebClient().DownloadString(reportUrl);

        var resultReport = JsonConvert.DeserializeObject<RootObject>(jsonReport);

        // Protein id = 203, fiber id = 291, vitamin a IU id = 318,
        //vitanim c id = 401, calcium id = 301, iron id = 303, kcal = 208 (it's referred to as energy?)
        // sat fat id = 606, total sugar id = 269, sodium id = 307
        foreach (Nutrient item in resultReport.foods[0].food.nutrients)
        {
            // Good nutrients
            if (Int32.Parse(item.nutrient_id) == 203)
            {
                protein = Double.Parse(item.value);
            }

            if (Int32.Parse(item.nutrient_id) == 291)
            {
                fiber = Double.Parse(item.value);
            }

            if (Int32.Parse(item.nutrient_id) == 318)
            {
                vitaminA = Double.Parse(item.value);
            }

            if (Int32.Parse(item.nutrient_id) == 401)
            {
                vitaminC = Double.Parse(item.value);
            }

            if (Int32.Parse(item.nutrient_id) == 301)
            {
                calcium = Double.Parse(item.value);
            }

            if (Int32.Parse(item.nutrient_id) == 303)
            {
                iron = Double.Parse(item.value);
            }

            if (Int32.Parse(item.nutrient_id) == 208)
            {
                kCal = Double.Parse(item.value);
            }



            // Bad nutrients
            if (Int32.Parse(item.nutrient_id) == 606)
            {
                satFat = Double.Parse(item.value);
            }

            if (Int32.Parse(item.nutrient_id) == 269)
            {
                totalSugar = Double.Parse(item.value);
            }

            if (Int32.Parse(item.nutrient_id) == 307)
            {
                sodium = Double.Parse(item.value);
            }
          

        }

        

        nR6 = ((((kCal / 100) * protein / 50) + ((kCal / 100) * fiber / 25) + ((kCal / 100) * vitaminA / 5000)
                               + ((kCal / 100) * vitaminC / 60) + ((kCal / 100) * calcium / 1000) + ((kCal / 100) * iron / 18)) * 100);

        liMT = ((((kCal / 100) * satFat / 20) + ((kCal / 100) * totalSugar / 125) + ((kCal / 100) * sodium / 2400)) * 100);

        

        NRF6 = nR6 - liMT;

        FoodItem newFood = new FoodItem();
        String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            {
                SqlCommand command1 = new SqlCommand();
                command1.Connection = connection;
                command1.CommandType = System.Data.CommandType.Text;


                command1.CommandText = @"INSERT INTO [testDB].[dbo].[SavedItems] ([ndb_no], [name], [NRF6], [LastUpdated], [LastUpdatedBy]) VALUES

               (@ndb_no, @name, @NRF6, @lastupdated, @lastupdatedby)";

                command1.Parameters.Add("@ndb_no", SqlDbType.NVarChar).Value = newFood.ndbNo;
                command1.Parameters.Add("@name", SqlDbType.NVarChar, 500).Value = newFood.name;
                command1.Parameters.Add("@NRF6", SqlDbType.Decimal).Value = newFood.NRF6;
                command1.Parameters.Add("@lastupdated", SqlDbType.Date).Value = DateTime.Now;
                command1.Parameters.Add("@lastupdatedby", SqlDbType.VarChar, 20).Value = "Charles Moore";


                connection.Open();
                command1.ExecuteNonQuery();
                connection.Close();


            }
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

    protected void btnSaveItem1_Click(object sender, EventArgs e)
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                {
                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandType = System.Data.CommandType.Text;


                    command1.CommandText = @"INSERT INTO [testDB].[dbo].[SavedItems] ([ndb_no], [name], [ND_Score], [saved by], [date saved]) VALUES

               (@ndb_no, @name, @NRF6, @savedby, @savedate)";

                    command1.Parameters.Add("@ndb_no", SqlDbType.NVarChar, 8).Value = newFoodArray[0].ndbNo;
                    command1.Parameters.Add("@name", SqlDbType.NVarChar, 500).Value = newFoodArray[0].name;
                    command1.Parameters.Add("@NRF6", SqlDbType.Decimal).Value = newFoodArray[0].NRF6;
                    command1.Parameters.Add("@savedby", SqlDbType.VarChar, 50).Value = "Nathan Hamrick";
                    command1.Parameters.Add("@savedate", SqlDbType.Date).Value = DateTime.Now;


                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        catch(Exception z)
        {
            Response.Write("<script>alert('Item already saved!');</script>");
        }
    }

    protected void btnSaveItem2_Click(object sender, EventArgs e)
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                {
                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandType = System.Data.CommandType.Text;


                    command1.CommandText = @"INSERT INTO [testDB].[dbo].[SavedItems] ([ndb_no], [name], [ND_Score], [saved by], [date saved]) VALUES

               (@ndb_no, @name, @NRF6, @savedby, @savedate)";

                    command1.Parameters.Add("@ndb_no", SqlDbType.NVarChar, 8).Value = newFoodArray[1].ndbNo;
                    command1.Parameters.Add("@name", SqlDbType.NVarChar, 500).Value = newFoodArray[1].name;
                    command1.Parameters.Add("@NRF6", SqlDbType.Decimal).Value = newFoodArray[1].NRF6;
                    command1.Parameters.Add("@savedby", SqlDbType.VarChar, 50).Value = "Nathan Hamrick";
                    command1.Parameters.Add("@savedate", SqlDbType.Date).Value = DateTime.Now;


                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        catch(Exception y)
        {
            Response.Write("<script>alert('Item already saved!');</script>");
        }
    }

    protected void btnSaveItem3_Click(object sender, EventArgs e)
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                {
                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandType = System.Data.CommandType.Text;


                    command1.CommandText = @"INSERT INTO [testDB].[dbo].[SavedItems] ([ndb_no], [name], [ND_Score], [saved by], [date saved]) VALUES

               (@ndb_no, @name, @NRF6, @savedby, @savedate)";

                    command1.Parameters.Add("@ndb_no", SqlDbType.NVarChar, 8).Value = newFoodArray[2].ndbNo;
                    command1.Parameters.Add("@name", SqlDbType.NVarChar, 500).Value = newFoodArray[2].name;
                    command1.Parameters.Add("@NRF6", SqlDbType.Decimal).Value = newFoodArray[2].NRF6;
                    command1.Parameters.Add("@savedby", SqlDbType.VarChar, 50).Value = "Nathan Hamrick";
                    command1.Parameters.Add("@savedate", SqlDbType.Date).Value = DateTime.Now;


                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        catch(Exception x)
        {
            Response.Write("<script>alert('Item already saved!');</script>");
        }
    }

    protected void btnSaveItem4_Click(object sender, EventArgs e)
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                {
                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandType = System.Data.CommandType.Text;


                    command1.CommandText = @"INSERT INTO [testDB].[dbo].[SavedItems] ([ndb_no], [name], [ND_Score], [saved by], [date saved]) VALUES

               (@ndb_no, @name, @NRF6, @savedby, @savedate)";

                    command1.Parameters.Add("@ndb_no", SqlDbType.NVarChar, 8).Value = newFoodArray[3].ndbNo;
                    command1.Parameters.Add("@name", SqlDbType.NVarChar, 500).Value = newFoodArray[3].name;
                    command1.Parameters.Add("@NRF6", SqlDbType.Decimal).Value = newFoodArray[3].NRF6;
                    command1.Parameters.Add("@savedby", SqlDbType.VarChar, 50).Value = "Nathan Hamrick";
                    command1.Parameters.Add("@savedate", SqlDbType.Date).Value = DateTime.Now;


                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        
        catch(Exception w)
        {
            Response.Write("<script>alert('Item already saved!');</script>");
        }
    }


    protected void btnSaveItem5_Click(object sender, EventArgs e)
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                {
                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandType = System.Data.CommandType.Text;


                    command1.CommandText = @"INSERT INTO [testDB].[dbo].[SavedItems] ([ndb_no], [name], [ND_Score], [saved by], [date saved]) VALUES

               (@ndb_no, @name, @NRF6, @savedby, @savedate)";

                    command1.Parameters.Add("@ndb_no", SqlDbType.NVarChar, 8).Value = newFoodArray[4].ndbNo;
                    command1.Parameters.Add("@name", SqlDbType.NVarChar, 500).Value = newFoodArray[4].name;
                    command1.Parameters.Add("@NRF6", SqlDbType.Decimal).Value = newFoodArray[4].NRF6;
                    command1.Parameters.Add("@savedby", SqlDbType.VarChar, 50).Value = "Nathan Hamrick";
                    command1.Parameters.Add("@savedate", SqlDbType.Date).Value = DateTime.Now;


                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        catch(Exception x)
        {
            Response.Write("<script>alert('Item already saved!');</script>");
        }
    }

    protected void btnSaveItem6_Click(object sender, EventArgs e)
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                {
                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandType = System.Data.CommandType.Text;


                    command1.CommandText = @"INSERT INTO [testDB].[dbo].[SavedItems] ([ndb_no], [name], [ND_Score], [saved by], [date saved]) VALUES

               (@ndb_no, @name, @NRF6, @savedby, @savedate)";

                    command1.Parameters.Add("@ndb_no", SqlDbType.NVarChar, 8).Value = newFoodArray[5].ndbNo;
                    command1.Parameters.Add("@name", SqlDbType.NVarChar, 500).Value = newFoodArray[5].name;
                    command1.Parameters.Add("@NRF6", SqlDbType.Decimal).Value = newFoodArray[5].NRF6;
                    command1.Parameters.Add("@savedby", SqlDbType.VarChar, 50).Value = "Nathan Hamrick";
                    command1.Parameters.Add("@savedate", SqlDbType.Date).Value = DateTime.Now;


                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        catch(Exception q)
        {
            Response.Write("<script>alert('Item already saved!');</script>");
        }
    }
}