using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using WholesomeMVC;
using System.Web.Services;
using System.Drawing;


namespace WholesomeMVC
{

    public class FoodItem
    {
        public string name { get; set; }
        public String ndbNo { get; set; }
        public double protein { get; set; }
        public double fiber { get; set; }
        public double vitaminA { get; set; }
        public double vitaminC { get; set; }
        public double calcium { get; set; }
        public double iron { get; set; }
        public double kCal { get; set; }
        public double satFat { get; set; }
        public double totalSugar { get; set; }
        public double sodium { get; set; }
        public double nR6 { get; set; }
        public double liMT { get; set; }
        public double NRF6 { get; set; }
        public String ingredients { get; set; }

        public static List<string> names = new List<string>();

        public static FoodItem newFood = new FoodItem();

        // Used for transfering ceres ID's on sync database to the add item page
        private static String ceresID = "";
        private static String description = "";

        public void calculateNRF6()
        {
            this.nR6 = (protein / 50) + (fiber / 25) + (vitaminA / 5000)
                               + (vitaminC / 60) + (calcium / 1000) + (iron / 18);

            this.liMT = (satFat / 20) + (totalSugar / 125) + (sodium / 2400);
            double good = ((nR6 * 100) / kCal) * 100;
            double bad = ((liMT * 100) / kCal) * 100;

            NRF6 = Math.Round(good - bad, 2);


        }

        public static void findNdbno(String foodSearch)
        {

            names.Clear();


            String urlPartOne = "https://api.nal.usda.gov/ndb/search/?format=json&q=";
            String urlPartTwo = "&sort=n&max=25&offset=0&api_key=m37cNkiJMin6FLxPuq6wDMqtFekEJYB6HJpbLrYb";


            String url = urlPartOne + foodSearch + urlPartTwo;

            var json = new WebClient().DownloadString(url);



            var result = JsonConvert.DeserializeObject<Search>(json);


            //for (int i = 0; i < IndexResults.dataSearchResults.Rows.Count; i++)
            //{
            if (!IndexResults.dataSearchResults.Columns.Contains("NDBno") && !IndexResults.dataSearchResults.Columns.Contains("Name")
                && !IndexResults.dataSearchResults.Columns.Contains("ND Score"))
            {
                IndexResults.dataSearchResults.Columns.Add("NDBno", typeof(string));
                IndexResults.dataSearchResults.Columns.Add("Name", typeof(string));
                IndexResults.dataSearchResults.Columns.Add("ND Score", typeof(double));

            }

            else
            {
                IndexResults.dataSearchResults.Clear();
            }

            if (result.list.item != null)
            {
                for (int i = 0; i < result.list.item.Count; i++)
                {

                    newFood.ndbNo = result.list.item[i].ndbno;
                    newFood.name = result.list.item[i].name;
                    DataRow row = IndexResults.dataSearchResults.NewRow();
                    row[0] = newFood.ndbNo;
                    row[1] = newFood.name;

                    String food = (newFood.ndbNo);

                    String urlPartOne2 = "https://api.nal.usda.gov/ndb/V2/reports?ndbno=";
                    String urlPartTwo2 = "&type=b&format=json&api_key=m37cNkiJMin6FLxPuq6wDMqtFekEJYB6HJpbLrYb";

                    String url2 = urlPartOne2 + food + urlPartTwo2;

                    var json2 = new WebClient().DownloadString(url2);

                    var result2 = JsonConvert.DeserializeObject<RootObject>(json2);


                    // SOME OF THE NUTRIENT ID'S ARE CHANGED W/ VERSION TWO, I FIXED THEM
                    foreach (Nutrient item in result2.foods[0].food.nutrients)
                    {
                        if (Int32.Parse(item.nutrient_id) == 203)
                        {
                            newFood.protein = Double.Parse(item.value);
                        }
                        if (Int32.Parse(item.nutrient_id) == 208)
                        {
                            newFood.kCal = Double.Parse(item.value);
                        }
                        if (Int32.Parse(item.nutrient_id) == 291)
                        {
                            newFood.fiber = Double.Parse(item.value);
                        }
                        if (Int32.Parse(item.nutrient_id) == 318)
                        {
                            newFood.vitaminA = Double.Parse(item.value);
                        }
                        if (Int32.Parse(item.nutrient_id) == 401)
                        {
                            newFood.vitaminC = Double.Parse(item.value);
                        }
                        if (Int32.Parse(item.nutrient_id) == 301)
                        {
                            newFood.calcium = Double.Parse(item.value);
                        }
                        if (Int32.Parse(item.nutrient_id) == 303)
                        {
                            newFood.iron = Double.Parse(item.value);
                        }
                        if (Int32.Parse(item.nutrient_id) == 606)
                        {
                            newFood.satFat = Double.Parse(item.value);
                        }
                        if (Int32.Parse(item.nutrient_id) == 269)
                        {
                            newFood.totalSugar = Double.Parse(item.value);
                        }
                        if (Int32.Parse(item.nutrient_id) == 307)
                        {
                            newFood.sodium = Double.Parse(item.value);
                        }
                        if (result2.foods[0].food.ing != null)
                        {
                            newFood.ingredients = result2.foods[0].food.ing.desc;
                        }

                        newFood.nR6 = (newFood.protein / 50) + (newFood.fiber / 25) + (newFood.vitaminA / 5000) + (newFood.vitaminC / 60) + (newFood.calcium / 1000) + (newFood.iron / 18);
                        newFood.liMT = (newFood.satFat / 20) + (newFood.totalSugar / 125) + (newFood.sodium / 2400);


                        double good = ((newFood.nR6 * 100) / newFood.kCal) * 100;
                        double bad = ((newFood.liMT * 100) / newFood.kCal) * 100;

                        newFood.NRF6 = good - bad;
                        newFood.NRF6 = Math.Round(newFood.NRF6, 5);

                        row[2] = newFood.NRF6;

                    }
                    IndexResults.dataSearchResults.Rows.Add(row);
                }
            }
            else
            {
            
            }
        }
        
            
                                         
  protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        TableCell cell = e.Row.Cells[2];
        int quantity = int.Parse(cell.Text);
        if (quantity < 4.66)
        {
            cell.BackColor = Color.Red;
        }
        if (quantity >= 4.66 && quantity <= 27.99)
        {
            cell.BackColor = Color.Yellow;
        }
        if (quantity >= 28)
        {
            cell.BackColor = Color.Green;
        }
    }
}

        public static void findNdbnoAddItem(String foodSearch)
        {

            names.Clear();


            String urlPartOne = "https://api.nal.usda.gov/ndb/search/?format=json&q=";
            String urlPartTwo = "&sort=n&max=10&offset=0&api_key=m37cNkiJMin6FLxPuq6wDMqtFekEJYB6HJpbLrYb";


            String url = urlPartOne + foodSearch + urlPartTwo;

            var json = new WebClient().DownloadString(url);



            var result = JsonConvert.DeserializeObject<Search>(json);



            if (!Add_Item.dataSearchResults.Columns.Contains("NDBno") && !Add_Item.dataSearchResults.Columns.Contains("Name")
                && !Add_Item.dataSearchResults.Columns.Contains("ND Score"))
            {
                Add_Item.dataSearchResults.Columns.Add("NDBno", typeof(int)); // Row 0
                Add_Item.dataSearchResults.Columns.Add("Name", typeof(string)); // Row 1
                Add_Item.dataSearchResults.Columns.Add("Protein", typeof(double));// Row 2
                Add_Item.dataSearchResults.Columns.Add("Fiber", typeof(double));// Row 3
                Add_Item.dataSearchResults.Columns.Add("VitaminA", typeof(double));// Row 4
                Add_Item.dataSearchResults.Columns.Add("VitaminC", typeof(double));// Row 5
                Add_Item.dataSearchResults.Columns.Add("Iron", typeof(double));// Row 6
                Add_Item.dataSearchResults.Columns.Add("Calcium", typeof(double));// Row 7
                Add_Item.dataSearchResults.Columns.Add("Sat_Fat", typeof(double));// Row 8
                Add_Item.dataSearchResults.Columns.Add("Total_Sugar", typeof(double));// Row 9
                Add_Item.dataSearchResults.Columns.Add("Sodium", typeof(double));// Row 10
                Add_Item.dataSearchResults.Columns.Add("KCal", typeof(double));// Row 11
                Add_Item.dataSearchResults.Columns.Add("ND Score", typeof(double));// Row 12

            }

            else
            {
                Add_Item.dataSearchResults.Clear();
            }

            try
            {
                for (int i = 0; i < result.list.item.Count; i++)
                {

                    newFood.ndbNo = result.list.item[i].ndbno;
                    newFood.name = result.list.item[i].name;
                    DataRow row = Add_Item.dataSearchResults.NewRow();

                    row[0] = newFood.ndbNo;
                    row[1] = newFood.name;

                    String food = Convert.ToString(newFood.ndbNo);

                    String urlPartOne2 = "https://api.nal.usda.gov/ndb/V2/reports?ndbno=";
                    String urlPartTwo2 = "&type=b&format=json&api_key=m37cNkiJMin6FLxPuq6wDMqtFekEJYB6HJpbLrYb";
                    String url2 = urlPartOne2 + food + urlPartTwo2;

                    var json2 = new WebClient().DownloadString(url2);

                    var result2 = JsonConvert.DeserializeObject<RootObject>(json2);

                    foreach (Nutrient item in result2.foods[0].food.nutrients)
                    {
                        if (Int32.Parse(item.nutrient_id) == 203)
                        {
                            newFood.protein = Double.Parse(item.value);
                        }

                        else if (Int32.Parse(item.nutrient_id) == 291)
                        {
                            newFood.fiber = Double.Parse(item.value);
                        }

                        else if (item.nutrient_id == "318")
                        {
                            newFood.vitaminA = Double.Parse(item.value);
                        }

                        else if (Int32.Parse(item.nutrient_id) == 401)
                        {
                            newFood.vitaminC = Double.Parse(item.value);
                        }

                        else if (Int32.Parse(item.nutrient_id) == 301)
                        {
                            newFood.calcium = Double.Parse(item.value);
                        }

                        else if (Int32.Parse(item.nutrient_id) == 303)
                        {
                            newFood.iron = Double.Parse(item.value);
                        }

                        else if (Int32.Parse(item.nutrient_id) == 208)
                        {
                            newFood.kCal = Double.Parse(item.value);
                        }

                        else if (Int32.Parse(item.nutrient_id) == 606)
                        {
                            newFood.satFat = Double.Parse(item.value);
                        }

                        else if (Int32.Parse(item.nutrient_id) == 269)
                        {
                            newFood.totalSugar = Double.Parse(item.value);
                        }

                        else if (Int32.Parse(item.nutrient_id) == 307)
                        {
                            newFood.sodium = Double.Parse(item.value);

                        }
                    }

                    newFood.nR6 = (newFood.protein / 50) + (newFood.fiber / 25) + (newFood.vitaminA / 5000) + (newFood.vitaminC / 60) + (newFood.calcium / 1000) + (newFood.iron / 18);
                    newFood.liMT = (newFood.satFat / 20) + (newFood.totalSugar / 125) + (newFood.sodium / 2400);


                    double good = ((newFood.nR6 * 100) / newFood.kCal) * 100;
                    double bad = ((newFood.liMT * 100) / newFood.kCal) * 100;

                    newFood.NRF6 = good - bad;
                    newFood.NRF6 = Math.Round(newFood.NRF6, 5);

                    row[2] = newFood.protein;
                    row[3] = newFood.fiber;
                    row[4] = newFood.vitaminA;
                    row[5] = newFood.vitaminC;
                    row[6] = newFood.iron;
                    row[7] = newFood.calcium;
                    row[8] = newFood.satFat;
                    row[9] = newFood.totalSugar;
                    row[10] = newFood.sodium;
                    row[11] = newFood.kCal;
                    row[12] = newFood.NRF6;
                    Add_Item.dataSearchResults.Rows.Add(row);
                }
            }
            catch (Exception e)
            {

            }
        }

        public static void findNdbnoUpdateItem(String foodSearch)
        {

            names.Clear();


            String urlPartOne = "https://api.nal.usda.gov/ndb/search/?format=json&q=";
            String urlPartTwo = "&sort=n&max=10&offset=0&api_key=m37cNkiJMin6FLxPuq6wDMqtFekEJYB6HJpbLrYb";


            String url = urlPartOne + foodSearch + urlPartTwo;

            var json = new WebClient().DownloadString(url);



            var result = JsonConvert.DeserializeObject<Search>(json);



            if (!Update_Item.dataSearchResults.Columns.Contains("NDBno") && !Update_Item.dataSearchResults.Columns.Contains("Name")
                && !Update_Item.dataSearchResults.Columns.Contains("ND Score"))
            {
                Update_Item.dataSearchResults.Columns.Add("NDBno", typeof(int)); // Row 0
                Update_Item.dataSearchResults.Columns.Add("Name", typeof(string)); // Row 1
                Update_Item.dataSearchResults.Columns.Add("Protein", typeof(double));// Row 2
                Update_Item.dataSearchResults.Columns.Add("Fiber", typeof(double));// Row 3
                Update_Item.dataSearchResults.Columns.Add("VitaminA", typeof(double));// Row 4
                Update_Item.dataSearchResults.Columns.Add("VitaminC", typeof(double));// Row 5
                Update_Item.dataSearchResults.Columns.Add("Iron", typeof(double));// Row 6
                Update_Item.dataSearchResults.Columns.Add("Calcium", typeof(double));// Row 7
                Update_Item.dataSearchResults.Columns.Add("Sat_Fat", typeof(double));// Row 8
                Update_Item.dataSearchResults.Columns.Add("Total_Sugar", typeof(double));// Row 9
                Update_Item.dataSearchResults.Columns.Add("Sodium", typeof(double));// Row 10
                Update_Item.dataSearchResults.Columns.Add("KCal", typeof(double));// Row 11
                Update_Item.dataSearchResults.Columns.Add("ND Score", typeof(double));// Row 12

            }

            else
            {
                Update_Item.dataSearchResults.Clear();
            }

            try
            {
                for (int i = 0; i < result.list.item.Count; i++)
                {

                    newFood.ndbNo = result.list.item[i].ndbno;
                    newFood.name = result.list.item[i].name;
                    DataRow row = Update_Item.dataSearchResults.NewRow();

                    row[0] = newFood.ndbNo;
                    row[1] = newFood.name;

                    String food = Convert.ToString(newFood.ndbNo);

                    String urlPartOne2 = "https://api.nal.usda.gov/ndb/V2/reports?ndbno=";
                    String urlPartTwo2 = "&type=b&format=json&api_key=m37cNkiJMin6FLxPuq6wDMqtFekEJYB6HJpbLrYb";


                    String url2 = urlPartOne2 + food + urlPartTwo2;

                    var json2 = new WebClient().DownloadString(url2);

                    var result2 = JsonConvert.DeserializeObject<RootObject>(json2);

                    foreach (Nutrient item in result2.foods[0].food.nutrients)
                    {
                        if (Int32.Parse(item.nutrient_id) == 203)
                        {
                            newFood.protein = Double.Parse(item.value);
                        }

                        else if (Int32.Parse(item.nutrient_id) == 291)
                        {
                            newFood.fiber = Double.Parse(item.value);
                        }

                        else if (item.nutrient_id == "318")
                        {
                            newFood.vitaminA = Double.Parse(item.value);
                        }

                        else if (Int32.Parse(item.nutrient_id) == 401)
                        {
                            newFood.vitaminC = Double.Parse(item.value);
                        }

                        else if (Int32.Parse(item.nutrient_id) == 301)
                        {
                            newFood.calcium = Double.Parse(item.value);
                        }

                        else if (Int32.Parse(item.nutrient_id) == 303)
                        {
                            newFood.iron = Double.Parse(item.value);
                        }

                        else if (Int32.Parse(item.nutrient_id) == 208)
                        {
                            newFood.kCal = Double.Parse(item.value);
                        }

                        else if (Int32.Parse(item.nutrient_id) == 606)
                        {
                            newFood.satFat = Double.Parse(item.value);
                        }

                        else if (Int32.Parse(item.nutrient_id) == 269)
                        {
                            newFood.totalSugar = Double.Parse(item.value);
                        }

                        else if (Int32.Parse(item.nutrient_id) == 307)
                        {
                            newFood.sodium = Double.Parse(item.value);
                        }
                    }

                    newFood.nR6 = (newFood.protein / 50) + (newFood.fiber / 25) + (newFood.vitaminA / 5000) + (newFood.vitaminC / 60) + (newFood.calcium / 1000) + (newFood.iron / 18);
                    newFood.liMT = (newFood.satFat / 20) + (newFood.totalSugar / 125) + (newFood.sodium / 2400);


                    double good = ((newFood.nR6 * 100) / newFood.kCal) * 100;
                    double bad = ((newFood.liMT * 100) / newFood.kCal) * 100;

                    newFood.NRF6 = good - bad;
                    newFood.NRF6 = Math.Round(newFood.NRF6, 5);

                    row[2] = newFood.protein;
                    row[3] = newFood.fiber;
                    row[4] = newFood.vitaminA;
                    row[5] = newFood.vitaminC;
                    row[6] = newFood.iron;
                    row[7] = newFood.calcium;
                    row[8] = newFood.satFat;
                    row[9] = newFood.totalSugar;
                    row[10] = newFood.sodium;
                    row[11] = newFood.kCal;
                    row[12] = newFood.NRF6;
                    Update_Item.dataSearchResults.Rows.Add(row);
                }
            }
            catch (Exception e)
            {

            }
        }

        public static void setCeresData(String addCeresID, String addDescription)
        {
            ceresID = addCeresID;
            description = addDescription;
        }

        public static String getCeresID()
        {
            return ceresID;
        }

        public static String getDescription()
        {
            return description;
        }

        public static void clearCeresData()
        {
            ceresID = "";
            description = "";
        }
    }
}











