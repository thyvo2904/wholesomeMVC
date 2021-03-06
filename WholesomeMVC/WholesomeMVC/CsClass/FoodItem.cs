﻿using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Net;
using Newtonsoft.Json;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace WholesomeMVC.WebForms
{

    public class FoodItem
    {
       
        public string name { get; set; }
        public string ndbNo { get; set; }
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
        public double totalFat { get; set; }
        public double transFat { get; set; }
        public double cholesterol { get; set; }
        public double carbohydrates { get; set; }
        public double nR6 { get; set; }
        public double liMT { get; set; }
        public double NRF6 { get; set; }
        public String ingredients { get; set; }
        public String foodGroup { get; set; }

        public static List<string> names = new List<string>();
        public static List<string> ndbnoList = new List<string>();
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

         
            try
            {
                names.Clear();
                ndbnoList.Clear();
                

                String urlPartOne = "https://api.nal.usda.gov/ndb/search/?format=json&q=";
                String urlPartTwo = "&sort=r&max=50&offset=0&api_key=m37cNkiJMin6FLxPuq6wDMqtFekEJYB6HJpbLrYb";


                String url = urlPartOne + foodSearch + urlPartTwo;

                var json = new WebClient().DownloadString(url);
                var result = JsonConvert.DeserializeObject<Search>(json);

                if (!indexresult.dataSearchResults.Columns.Contains("NDBno") && !indexresult.dataSearchResults.Columns.Contains("Name")
                    && !indexresult.dataSearchResults.Columns.Contains("ND Score"))
                {
                    indexresult.dataSearchResults.Columns.Add("NDBno", typeof(string));
                    indexresult.dataSearchResults.Columns.Add("Name", typeof(string));
                    indexresult.dataSearchResults.Columns.Add("ND Score", typeof(double));
                }

                else
                {
                    indexresult.dataSearchResults.Clear();
                }

                //check usda api first, if result null, use second api

                for (int i = 0; i < result.list.item.Count; i++)
                {

                    newFood = new FoodItem();
                    newFood.ndbNo = Convert.ToString(result.list.item[i].ndbno);
                    newFood.name = Convert.ToString(result.list.item[i].name);
        
           

                String urlPartOne2 = "https://api.nal.usda.gov/ndb/V2/reports?ndbno=";
                String urlPartTwo2 = "&type=b&format=json&api_key=m37cNkiJMin6FLxPuq6wDMqtFekEJYB6HJpbLrYb";

             

                    String url2 = urlPartOne2 + newFood.ndbNo + urlPartTwo2;

                var json2 = new WebClient().DownloadString(url2);

                var result2 = JsonConvert.DeserializeObject<RootObject>(json2);

                    for (int j = 0; j < result2.foods.Count; j++)
                    {
                        
                      
                        // SOME OF THE NUTRIENT ID'S ARE CHANGED W/ VERSION TWO, I FIXED THEM
                        foreach (Nutrient item in result2.foods[j].food.nutrients)
                        {
                            if (Int32.Parse(item.nutrient_id) == 203)
                            {
                                newFood.protein = Double.Parse(item.value);
                                newFood.protein = Math.Round(newFood.protein, 2);
                            }
                            else if (Int32.Parse(item.nutrient_id) == 208)
                            {
                                newFood.kCal = Double.Parse(item.value);
                                newFood.kCal = Math.Round(newFood.kCal);
                            }
                            else if (Int32.Parse(item.nutrient_id) == 291)
                            {
                                newFood.fiber = Double.Parse(item.value);
                                newFood.fiber = Math.Round(newFood.fiber, 2);
                            }
                            else if (Int32.Parse(item.nutrient_id) == 318)
                            {
                                newFood.vitaminA = Double.Parse(item.value);
                                newFood.vitaminA = Math.Round(newFood.vitaminA, 2);
                            }
                            else if (Int32.Parse(item.nutrient_id) == 401)
                            {
                                newFood.vitaminC = Double.Parse(item.value);
                                newFood.vitaminC = Math.Round(newFood.vitaminC, 2);
                            }
                            else if (Int32.Parse(item.nutrient_id) == 301)
                            {
                                newFood.calcium = Double.Parse(item.value);
                                // newFood.calcium = Math.Round(newFood.calcium, 2);
                            }
                            else if (Int32.Parse(item.nutrient_id) == 303)
                            {
                                newFood.iron = Double.Parse(item.value);
                                // newFood.iron = Math.Round(newFood.iron, 2);
                            }
                            else if (Int32.Parse(item.nutrient_id) == 606)
                            {
                                newFood.satFat = Double.Parse(item.value);
                                newFood.satFat = Math.Round(newFood.satFat, 2);
                            }
                            else if (Int32.Parse(item.nutrient_id) == 269)
                            {
                                newFood.totalSugar = Double.Parse(item.value);
                                newFood.totalSugar = Math.Round(newFood.totalSugar, 2);
                            }
                            else if (Int32.Parse(item.nutrient_id) == 307)
                            {
                                newFood.sodium = Double.Parse(item.value);
                                newFood.sodium = Math.Round(newFood.sodium, 2);
                            }
                            else if (Int32.Parse(item.nutrient_id) == 204)
                            {
                                newFood.totalFat = Double.Parse(item.value);
                                newFood.totalFat = Math.Round(newFood.totalFat, 2);
                            }
                            else if (Int32.Parse(item.nutrient_id) == 605)
                            {
                                newFood.transFat = Double.Parse(item.value);
                                newFood.transFat = Math.Round(newFood.transFat, 2);
                            }
                            else if (Int32.Parse(item.nutrient_id) == 601)
                            {
                                newFood.cholesterol = Double.Parse(item.value);
                                newFood.cholesterol = Math.Round(newFood.cholesterol, 2);
                            }
                            else if (Int32.Parse(item.nutrient_id) == 205)
                            {
                                newFood.carbohydrates = Double.Parse(item.value);
                                newFood.carbohydrates = Math.Round(newFood.carbohydrates, 2);
                            }
                            if (result2.foods[0].food.ing != null)
                            {
                                newFood.ingredients = result2.foods[0].food.ing.desc;
                            }


                            double protein = newFood.protein / 50;
                            double fiber = newFood.fiber / 25;
                            double vitaminA = newFood.vitaminA / 5000;
                            double vitaminC = newFood.vitaminC / 60;
                            double calcium = newFood.calcium / 1000;
                            double iron = newFood.iron / 18;

                            //if any of the good value ratios are > 1, set them equal to 1 to follow algorithm rule 
                            if (protein > 1)
                            {
                                protein = 1;
                            }

                            if (fiber > 1)
                            {
                                fiber = 1;
                            }

                            if (vitaminA > 1)
                            {
                                vitaminA = 1;
                            }

                            if (vitaminC > 1)
                            {
                                vitaminC = 1;
                            }

                            if (calcium > 1)
                            {
                                calcium = 1;
                            }

                            if (iron > 1)
                            {
                                iron = 1;
                            }



                            newFood.nR6 = (protein) + (fiber) + (vitaminA) + (vitaminC) + (calcium) + (iron);
                            newFood.liMT = (newFood.satFat / 20) + (newFood.totalSugar / 125) + (newFood.sodium / 2400);


                            double good = ((newFood.nR6 * 100) / newFood.kCal) * 100;
                            double bad = ((newFood.liMT * 100) / newFood.kCal) * 100;

                            newFood.NRF6 = good - bad;
                            newFood.NRF6 = Math.Round(newFood.NRF6, 5);

                            


                        }
                        


                    }
                    DataRow row = indexresult.dataSearchResults.NewRow();
                    row[0] = newFood.ndbNo;
                    row[1] = newFood.name;
                    row[2] = newFood.NRF6;
                    indexresult.dataSearchResults.Rows.Add(row);
                }
                indexresult.savedNdb_no = newFood.ndbNo;
                indexresult.savedItemName = newFood.name;
                indexresult.savedFoodGroup = newFood.foodGroup;
                indexresult.savedNrf6 = newFood.NRF6;
            }catch(Exception ex)
            {
                // response write opps! item cant be found
            }

            //else
            //{
            //    string api2 = System.Web.HttpUtility.UrlPathEncode(foodSearch);
            //   // String urlAPI2pt1 = "https://api.edamam.com/api/food-database/parser?ingr=";
            //   // String urlAPI2pt2 = "&app_id ={cd27db7d} &app_key ={9d149ec2802f86f42a15dcbd16891ff9}&page = 0";



            //    String apiRequest = urlPartOne + api2 + urlPartTwo;

            //    var json2 = new WebClient().DownloadString(apiRequest);
            //    var result2 = JsonConvert.DeserializeObject<Search>(json2);

            //}

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
            ndbnoList.Clear();


            String urlPartOne = "https://api.nal.usda.gov/ndb/search/?format=json&q=";
            String urlPartTwo = "&sort=r&max=10&offset=0&api_key=m37cNkiJMin6FLxPuq6wDMqtFekEJYB6HJpbLrYb";


            String url = urlPartOne + foodSearch + urlPartTwo;

            var json = new WebClient().DownloadString(url);



            var result = JsonConvert.DeserializeObject<Search>(json);


            
            if (!add_item.dataSearchResults.Columns.Contains("NDBno") && !add_item.dataSearchResults.Columns.Contains("Name")
                && !add_item.dataSearchResults.Columns.Contains("ND Score"))
            {
                add_item.dataSearchResults.Columns.Add("NDBno", typeof(string)); // Row 0
                add_item.dataSearchResults.Columns.Add("Name", typeof(string)); // Row 1
                add_item.dataSearchResults.Columns.Add("Protein", typeof(double));// Row 2
                add_item.dataSearchResults.Columns.Add("Fiber", typeof(double));// Row 3
                add_item.dataSearchResults.Columns.Add("VitaminA", typeof(double));// Row 4
                add_item.dataSearchResults.Columns.Add("VitaminC", typeof(double));// Row 5
                add_item.dataSearchResults.Columns.Add("Iron", typeof(double));// Row 6
                add_item.dataSearchResults.Columns.Add("Calcium", typeof(double));// Row 7
                add_item.dataSearchResults.Columns.Add("Sat_Fat", typeof(double));// Row 8
                add_item.dataSearchResults.Columns.Add("Total_Sugar", typeof(double));// Row 9
                add_item.dataSearchResults.Columns.Add("Sodium", typeof(double));// Row 10
                add_item.dataSearchResults.Columns.Add("KCal", typeof(double));// Row 11
                add_item.dataSearchResults.Columns.Add("ND Score", typeof(double));// Row 12


            }

            else
            {
                add_item.dataSearchResults.Clear();
            }

            try
            {


                for (int i = 0; i < result.list.item.Count; i++)
                {

                    newFood.ndbNo = result.list.item[i].ndbno;
                    //newFood.name = result.list.item[i].name;

                    //row[0] = newFood.ndbNo;
                    //row[1] = newFood.name;
                    ndbnoList.Add(newFood.ndbNo);
                }

                String food = "";

                for (int i = 0; i < ndbnoList.Count; i++)
                {
                    if (ndbnoList[i] != null)
                    {
                        if (i == 0)
                        {
                            food += ndbnoList[i].ToString();
                        }

                        else
                        {
                            food += "&ndbno=";
                            food += ndbnoList[i].ToString();
                        }
                    }
                }


                // End this for loop. Make a string array to hold the ndbno's. Do a for loop like recent items to build the food
                // part of the report url. copy the for each loop



                String urlPartOne2 = "https://api.nal.usda.gov/ndb/V2/reports?ndbno=";
                String urlPartTwo2 = "&type=b&format=json&api_key=m37cNkiJMin6FLxPuq6wDMqtFekEJYB6HJpbLrYb";

                //String urlPartOne = "https://api.nal.usda.gov/ndb/V2/reports?ndbno=";
                //String urlPartTwo = "&type=b&format=json&api_key=m37cNkiJMin6FLxPuq6wDMqtFekEJYB6HJpbLrYb";

                String url2 = urlPartOne2 + food + urlPartTwo2;

                var json2 = new WebClient().DownloadString(url2);

                var result2 = JsonConvert.DeserializeObject<RootObject>(json2);

                for (int i = 0; i < result2.foods.Count; i++)
                {
                    DataRow row = add_item.dataSearchResults.NewRow();


                    foreach (Nutrient item in result2.foods[i].food.nutrients)
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
                    newFood.foodGroup = result2.foods[i].food.desc.group;
                    newFood.NRF6 = good - bad;
                    newFood.NRF6 = Math.Round(newFood.NRF6, 5);
                    row[0] = result2.foods[i].food.desc.ndbno;
                    row[1] = result2.foods[i].food.desc.name;
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
                    add_item.dataSearchResults.Rows.Add(row);
                }
            }
            catch (Exception)
            {

            }
        }

        public static void findNdbnoUpdateItem(String foodSearch)
        {

            names.Clear();
            ndbnoList.Clear();


            String urlPartOne = "https://api.nal.usda.gov/ndb/search/?format=json&q=";
            String urlPartTwo = "&sort=r&max=10&offset=0&api_key=m37cNkiJMin6FLxPuq6wDMqtFekEJYB6HJpbLrYb";


            String url = urlPartOne + foodSearch + urlPartTwo;

            var json = new WebClient().DownloadString(url);



            var result = JsonConvert.DeserializeObject<Search>(json);



            if (!update_item.dataSearchResults.Columns.Contains("NDBno"))
            {
                update_item.dataSearchResults.Columns.Add("NDBno", typeof(string)); // Row 0
                update_item.dataSearchResults.Columns.Add("Name", typeof(string)); // Row 1
                update_item.dataSearchResults.Columns.Add("Food Group", typeof(string)); // Row 1
                //Update_Item.dataSearchResults.Columns.Add("Protein", typeof(double));// Row 2
                //Update_Item.dataSearchResults.Columns.Add("Fiber", typeof(double));// Row 3
                //Update_Item.dataSearchResults.Columns.Add("VitaminA", typeof(double));// Row 4
                //Update_Item.dataSearchResults.Columns.Add("VitaminC", typeof(double));// Row 5
                //Update_Item.dataSearchResults.Columns.Add("Iron", typeof(double));// Row 6
                //Update_Item.dataSearchResults.Columns.Add("Calcium", typeof(double));// Row 7
                //Update_Item.dataSearchResults.Columns.Add("Sat_Fat", typeof(double));// Row 8
                //Update_Item.dataSearchResults.Columns.Add("Total_Sugar", typeof(double));// Row 9
                //Update_Item.dataSearchResults.Columns.Add("Sodium", typeof(double));// Row 10
                //Update_Item.dataSearchResults.Columns.Add("KCal", typeof(double));// Row 11
                update_item.dataSearchResults.Columns.Add("ND Score", typeof(double));// Row 12

            }

            else
            {
                update_item.dataSearchResults.Clear();
            }

           


                for (int i = 0; i < result.list.item.Count; i++)
                {

                    newFood.ndbNo = result.list.item[i].ndbno;
                    //newFood.name = result.list.item[i].name;

                    //row[0] = newFood.ndbNo;
                    //row[1] = newFood.name;
                    ndbnoList.Add(newFood.ndbNo);
                }

                String food = "";

                for (int i = 0; i < ndbnoList.Count; i++)
                {
                    if (ndbnoList[i] != null)
                    {
                        if (i == 0)
                        {
                            food += ndbnoList[i].ToString();
                        }

                        else
                        {
                            food += "&ndbno=";
                            food += ndbnoList[i].ToString();
                        }
                    }
                }


                // End this for loop. Make a string array to hold the ndbno's. Do a for loop like recent items to build the food
                // part of the report url. copy the for each loop



                String urlPartOne2 = "https://api.nal.usda.gov/ndb/V2/reports?ndbno=";
                String urlPartTwo2 = "&type=b&format=json&api_key=m37cNkiJMin6FLxPuq6wDMqtFekEJYB6HJpbLrYb";

                //String urlPartOne = "https://api.nal.usda.gov/ndb/V2/reports?ndbno=";
                //String urlPartTwo = "&type=b&format=json&api_key=m37cNkiJMin6FLxPuq6wDMqtFekEJYB6HJpbLrYb";

                String url2 = urlPartOne2 + food + urlPartTwo2;

                var json2 = new WebClient().DownloadString(url2);

                var result2 = JsonConvert.DeserializeObject<RootObject>(json2);

                for (int i = 0; i < result2.foods.Count; i++)
                {
                    DataRow row = update_item.dataSearchResults.NewRow();


                    foreach (Nutrient item in result2.foods[i].food.nutrients)
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

                System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection
                {
                    ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
                };

                Boolean foodGroup = false;
                String foodCatNumber = "";

                sc.Open();
                SqlCommand command = new SqlCommand
                {
                    Connection = sc,
                    CommandType = System.Data.CommandType.Text,



                    // ADD SESSION INFO
                    CommandText = @"SELECT FdGrp_CD FROM FOOD_DES WHERE ndb_no = @ndb_no"
                };
                command.Parameters.Add("@ndb_no", SqlDbType.NVarChar, 60).Value = result2.foods[i].food.desc.ndbno;
                            SqlDataReader readIn = command.ExecuteReader();
                            while (readIn.Read())
                            {
                    foodGroup = true;
                                foodCatNumber = readIn["FdGrp_CD"].ToString();
                            }

                            sc.Close();

                sc.Open();
                command = new SqlCommand
                {
                    Connection = sc,
                    CommandType = System.Data.CommandType.Text,



                    // ADD SESSION INFO
                    CommandText = @"SELECT FdGrp_Desc FROM FD_GROUP WHERE FdGrp_CD = @FdGrp_CD"
                };
                command.Parameters.Add("FdGrp_CD", SqlDbType.NVarChar, 4).Value = foodCatNumber;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    row[2] = reader["FdGrp_Desc"].ToString();
                }

                sc.Close();

                if (foodGroup == false)
                {
                    row[2] = "Branded Reference";
                }

                    newFood.NRF6 = good - bad;
                    newFood.NRF6 = Math.Round(newFood.NRF6, 5);
                    row[0] = result2.foods[i].food.desc.ndbno;
                    row[1] = result2.foods[i].food.desc.name;
                    //row[2] = result2.foods[i].food.desc.group;
                    //row[3] = newFood.protein;
                    //row[4] = newFood.fiber;
                    //row[5] = newFood.vitaminA;
                    //row[6] = newFood.vitaminC;
                    //row[7] = newFood.iron;
                    //row[8] = newFood.calcium;
                    //row[9] = newFood.satFat;
                    //row[10] = newFood.totalSugar;
                    //row[11] = newFood.sodium;
                    //row[12] = newFood.kCal;
                    row[3] = newFood.NRF6;
                    update_item.dataSearchResults.Rows.Add(row);
                }
            
        }


        public static void expandLabel(String foodSearch)
        {

            names.Clear();
            ndbnoList.Clear();


            String urlPartOne = "https://api.nal.usda.gov/ndb/search/?format=json&q=";
            String urlPartTwo = "&sort=r&max=25&offset=0&api_key=m37cNkiJMin6FLxPuq6wDMqtFekEJYB6HJpbLrYb";


            String url = urlPartOne + foodSearch + urlPartTwo;

            var json = new WebClient().DownloadString(url);



            var result = JsonConvert.DeserializeObject<Search>(json);


            //for (int i = 0; i < IndexResults.dataSearchResults.Rows.Count; i++)
            //{
            //if (!indexresult.dataSearchResults.Columns.Contains("NDBno") && !indexresult.dataSearchResults.Columns.Contains("Name")
            //    && !indexresult.dataSearchResults.Columns.Contains("ND Score"))
            //{
            //    indexresult.dataSearchResults.Columns.Add("NDBno", typeof(string));
            //    indexresult.dataSearchResults.Columns.Add("Name", typeof(string));
            //    indexresult.dataSearchResults.Columns.Add("ND Score", typeof(double));

            //}

            //else
            //{
            //    indexresult.dataSearchResults.Clear();
            //}

            //check usda api first, if result null, use second api
            if (result.list.item != null)
            {
                for (int i = 0; i < result.list.item.Count; i++)
                {

                    newFood.ndbNo = result.list.item[i].ndbno;
                    newFood.name = result.list.item[i].name;

                    //row[0] = newFood.ndbNo;
                    //row[1] = newFood.name;
                    ndbnoList.Add(newFood.ndbNo);
                }

                String food = "";

                for (int i = 0; i < ndbnoList.Count; i++)
                {
                    if (ndbnoList[i] != null)
                    {
                        if (i == 0)
                        {
                            food += ndbnoList[i].ToString();
                        }

                        else
                        {
                            food += "&ndbno=";
                            food += ndbnoList[i].ToString();
                        }
                    }
                }


                // End this for loop. Make a string array to hold the ndbno's. Do a for loop like recent items to build the food
                // part of the report url. copy the for each loop



                String urlPartOne2 = "https://api.nal.usda.gov/ndb/V2/reports?ndbno=";
                String urlPartTwo2 = "&type=b&format=json&api_key=m37cNkiJMin6FLxPuq6wDMqtFekEJYB6HJpbLrYb";

                //String urlPartOne = "https://api.nal.usda.gov/ndb/V2/reports?ndbno=";
                //String urlPartTwo = "&type=b&format=json&api_key=m37cNkiJMin6FLxPuq6wDMqtFekEJYB6HJpbLrYb";

                String url2 = urlPartOne2 + food + urlPartTwo2;

                var json2 = new WebClient().DownloadString(url2);

                var result2 = JsonConvert.DeserializeObject<RootObject>(json2);

                for (int i = 0; i < result2.foods.Count; i++)
                {
                    //DataRow row = indexresult.dataSearchResults.NewRow();
                    // SOME OF THE NUTRIENT ID'S ARE CHANGED W/ VERSION TWO, I FIXED THEM
                    foreach (Nutrient item in result2.foods[i].food.nutrients)
                    {
                        if (Int32.Parse(item.nutrient_id) == 203)
                        {
                            newFood.protein = Double.Parse(item.value);
                            newFood.protein = Math.Round(newFood.protein, 2);
                        }
                        else if (Int32.Parse(item.nutrient_id) == 208)
                        {
                            newFood.kCal = Double.Parse(item.value);
                            newFood.kCal = Math.Round(newFood.kCal);
                        }
                        else if (Int32.Parse(item.nutrient_id) == 291)
                        {
                            newFood.fiber = Double.Parse(item.value);
                            newFood.fiber = Math.Round(newFood.fiber, 2);
                        }
                        else if (Int32.Parse(item.nutrient_id) == 318)
                        {
                            newFood.vitaminA = Double.Parse(item.value);
                            newFood.vitaminA = Math.Round(newFood.vitaminA, 2);
                        }
                        else if (Int32.Parse(item.nutrient_id) == 401)
                        {
                            newFood.vitaminC = Double.Parse(item.value);
                            newFood.vitaminC = Math.Round(newFood.vitaminC, 2);
                        }
                        else if (Int32.Parse(item.nutrient_id) == 301)
                        {
                            newFood.calcium = Double.Parse(item.value);
                            newFood.calcium = Math.Round(newFood.calcium, 2);
                        }
                        else if (Int32.Parse(item.nutrient_id) == 303)
                        {
                            newFood.iron = Double.Parse(item.value);
                            newFood.iron = Math.Round(newFood.iron, 2);
                        }
                        else if (Int32.Parse(item.nutrient_id) == 606)
                        {
                            newFood.satFat = Double.Parse(item.value);
                            newFood.satFat = Math.Round(newFood.satFat, 2);
                        }
                        else if (Int32.Parse(item.nutrient_id) == 269)
                        {
                            newFood.totalSugar = Double.Parse(item.value);
                            newFood.totalSugar = Math.Round(newFood.totalSugar, 2);
                        }
                        else if (Int32.Parse(item.nutrient_id) == 307)
                        {
                            newFood.sodium = Double.Parse(item.value);
                            newFood.sodium = Math.Round(newFood.sodium, 2);
                        }
                        else if (Int32.Parse(item.nutrient_id) == 204)
                        {
                            newFood.totalFat = Double.Parse(item.value);
                            newFood.totalFat = Math.Round(newFood.totalFat, 2);
                        }
                        else if (Int32.Parse(item.nutrient_id) == 605)
                        {
                            newFood.transFat = Double.Parse(item.value);
                            newFood.transFat = Math.Round(newFood.transFat, 2);
                        }
                        else if (Int32.Parse(item.nutrient_id) == 601)
                        {
                            newFood.cholesterol = Double.Parse(item.value);
                            newFood.cholesterol = Math.Round(newFood.cholesterol, 2);
                        }
                        else if (Int32.Parse(item.nutrient_id) == 205)
                        {
                            newFood.carbohydrates = Double.Parse(item.value);
                            newFood.carbohydrates = Math.Round(newFood.carbohydrates, 2);
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

                        //row[2] = newFood.NRF6;

                    }
                    //row[0] = result2.foods[i].food.desc.ndbno;
                    //row[1] = result2.foods[i].food.desc.name;
                    //indexresult.dataSearchResults.Rows.Add(row);
                }
                //indexresult.savedNdb_no = newFood.ndbNo;
                //indexresult.savedItemName = newFood.name;
                //indexresult.savedFoodGroup = newFood.foodGroup;
                //indexresult.savedNrf6 = newFood.NRF6;

            }
            else
            {
                string api2 = System.Web.HttpUtility.UrlPathEncode(foodSearch);
                //String urlAPI2pt1 = "https://api.edamam.com/api/food-database/parser?ingr=";
                //String urlAPI2pt2 = "&app_id ={cd27db7d} &app_key ={9d149ec2802f86f42a15dcbd16891ff9}&page = 0";



                String apiRequest = urlPartOne + api2 + urlPartTwo;

                var json2 = new WebClient().DownloadString(apiRequest);
                var result2 = JsonConvert.DeserializeObject<Search>(json2);

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











