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
using System.Configuration;

namespace WholesomeMVC.WebForms
{
    public class GradientColors
    {
        // Goes from lowest score to highest
        private static String color1 = "red";
        private static String color2 = "yellow";
        private static String color3 = "green";




        public static void setRed(String newColor1)
        {


            String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;



            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                {
                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandType = System.Data.CommandType.Text;


                    command1.CommandText = @"UPDATE [wholesomeDB].[dbo].[GradientValue] ([HexColor]) VALUES

               (@HexColor) WHERE GradientValue = '1'";

                    command1.Parameters.Add("@HexColor", SqlDbType.NChar, 10).Value = newColor1;
                    //command1.Parameters.Add("@GradientValue", SqlDbType.Date).Value = ;
                    //command1.Parameters.Add("@LastUpdatedBy", SqlDbType.NVarChar, 50).Value = "Charles Moore";
                    //command1.Parameters.Add("@lastupdated", SqlDbType.Date).Value = DateTime.Now;


                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();
                }
            }

            color1 = newColor1;
        }

        public static void setYellow(String newColor2)
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;



            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                {
                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandType = System.Data.CommandType.Text;


                    command1.CommandText = @"UPDATE [wholesomeDB].[dbo].[GradientValue] ([HexColor]) VALUES

               (@HexColor) WHERE GradientValue = '2'";

                    command1.Parameters.Add("@HexColor", SqlDbType.NChar, 10).Value = newColor2;
                    //command1.Parameters.Add("@GradientValue", SqlDbType.Date).Value = ;
                    //command1.Parameters.Add("@LastUpdatedBy", SqlDbType.NVarChar, 50).Value = "Charles Moore";
                    //command1.Parameters.Add("@lastupdated", SqlDbType.Date).Value = DateTime.Now;


                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();
                }
            }

            color2 = newColor2;
        }

        public static void setGreen(String newColor3)
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;



            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                {
                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandType = System.Data.CommandType.Text;


                    command1.CommandText = @"UPDATE [wholesomeDB].[dbo].[GradientValue] ([HexColor]) VALUES

               (@HexColor) WHERE GradientValue = '3'";

                    command1.Parameters.Add("@HexColor", SqlDbType.NChar, 10).Value = newColor3;
                    //command1.Parameters.Add("@GradientValue", SqlDbType.Date).Value = ;
                    //command1.Parameters.Add("@LastUpdatedBy", SqlDbType.NVarChar, 50).Value = "Charles Moore";
                    //command1.Parameters.Add("@lastupdated", SqlDbType.Date).Value = DateTime.Now;


                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();
                }
            }

            color3 = newColor3;
        }


        public static String getColor1()
        {
            String color = "";
            int count = 0;
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            };

            sc.Open();

            SqlDataReader newReader = null;
            SqlCommand myCommand = new SqlCommand("SELECT HexColor FROM GradientValue WHERE GradientEntry = 1",
                                                     sc);
            newReader = myCommand.ExecuteReader();

            while (newReader.Read())
            {
                count++;
                if (count == 1)
                color = newReader["HexColor"].ToString();
            }

            sc.Close();

            return color;

        }

        public static String getColor2()
        {
            String color = "";
            int count = 0;
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            };

            sc.Open();

            SqlDataReader newReader = null;
            SqlCommand myCommand = new SqlCommand("SELECT HexColor FROM GradientValue",
                                                     sc);
            newReader = myCommand.ExecuteReader();

            while (newReader.Read())
            {
                count++;
                if (count == 1)
                {
                    color = newReader["HexColor"].ToString();
                }

            }

            sc.Close();

            return color;
        }

        public static String getColor3()
        {
            String color = "";
            int count = 0;
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            };

            sc.Open();

            SqlDataReader newReader = null;
            SqlCommand myCommand = new SqlCommand("SELECT HexColor FROM GradientValue",
                                                     sc);
            newReader = myCommand.ExecuteReader();

            while (newReader.Read())
            {
                count++;
                if (count == 2)
                {
                    color = newReader["HexColor"].ToString();
                }

            }

            sc.Close();

            return color;
        }

    }
}