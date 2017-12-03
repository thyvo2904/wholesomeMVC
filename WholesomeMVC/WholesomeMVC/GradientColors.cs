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
        private static String color1 = "#ED1C24";
        private static String color2 = "#F15B22";
        private static String color3 = "#F6851F";

        private static String color4 = "#F9B517";
        private static String color5 = "#F6E700";
        private static String color6 = "#CECF2A";

        private static String color7 = "#11A44A";
        private static String color8 = "#0B6F39";
        private static String color9 = "#1F4821";


        public static void setGreenHighValue(String newColor1)
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

        public static void setGreenMidValue(String newColor2)
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

        public static void setGreenLowValue(String newColor3)
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

        public static void setYellowHighValue(String newColor4)
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;



            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                {
                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandType = System.Data.CommandType.Text;


                    command1.CommandText = @"UPDATE [wholesomeDB].[dbo].[GradientValue] ([HexColor]) VALUES

               (@HexColor) WHERE GradientValue = '4'";

                    command1.Parameters.Add("@HexColor", SqlDbType.NChar, 10).Value = newColor4;
                    //command1.Parameters.Add("@GradientValue", SqlDbType.Date).Value = ;
                    //command1.Parameters.Add("@LastUpdatedBy", SqlDbType.NVarChar, 50).Value = "Charles Moore";
                    //command1.Parameters.Add("@lastupdated", SqlDbType.Date).Value = DateTime.Now;


                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();
                }
            }

            color4 = newColor4;
        }

        public static void setYellowMidValue(String newColor5)
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;



            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                {
                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandType = System.Data.CommandType.Text;


                    command1.CommandText = @"UPDATE [wholesomeDB].[dbo].[GradientValue] ([HexColor]) VALUES

               (@HexColor) WHERE GradientValue = '5'";

                    command1.Parameters.Add("@HexColor", SqlDbType.NChar, 10).Value = newColor5;
                    //command1.Parameters.Add("@GradientValue", SqlDbType.Date).Value = ;
                    //command1.Parameters.Add("@LastUpdatedBy", SqlDbType.NVarChar, 50).Value = "Charles Moore";
                    //command1.Parameters.Add("@lastupdated", SqlDbType.Date).Value = DateTime.Now;


                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();
                }
            }

            color5 = newColor5;
        }

        public static void setYellowLowValue(String newColor6)
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;



            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                {
                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandType = System.Data.CommandType.Text;


                    command1.CommandText = @"UPDATE [wholesomeDB].[dbo].[GradientValue] ([HexColor]) VALUES

               (@HexColor) WHERE GradientValue = '6'";

                    command1.Parameters.Add("@HexColor", SqlDbType.NChar, 10).Value = newColor6;
                    //command1.Parameters.Add("@GradientValue", SqlDbType.Date).Value = ;
                    //command1.Parameters.Add("@LastUpdatedBy", SqlDbType.NVarChar, 50).Value = "Charles Moore";
                    //command1.Parameters.Add("@lastupdated", SqlDbType.Date).Value = DateTime.Now;


                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();
                }
            }

            color6 = newColor6;
        }

        public static void setRedHighValue(String newColor7)
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;



            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                {
                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandType = System.Data.CommandType.Text;


                    command1.CommandText = @"UPDATE [wholesomeDB].[dbo].[GradientValue] ([HexColor]) VALUES

               (@HexColor) WHERE GradientValue = '7'";

                    command1.Parameters.Add("@HexColor", SqlDbType.NChar, 10).Value = newColor7;
                    //command1.Parameters.Add("@GradientValue", SqlDbType.Date).Value = ;
                    //command1.Parameters.Add("@LastUpdatedBy", SqlDbType.NVarChar, 50).Value = "Charles Moore";
                    //command1.Parameters.Add("@lastupdated", SqlDbType.Date).Value = DateTime.Now;


                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();
                }
            }

            color7 = newColor7;
        }

        public static void setRedMidValue(String newColor8)
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;



            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                {
                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandType = System.Data.CommandType.Text;


                    command1.CommandText = @"UPDATE [wholesomeDB].[dbo].[GradientValue] ([HexColor]) VALUES

               (@HexColor) WHERE GradientValue = '8'";

                    command1.Parameters.Add("@HexColor", SqlDbType.NChar, 10).Value = newColor8;
                    //command1.Parameters.Add("@GradientValue", SqlDbType.Date).Value = ;
                    //command1.Parameters.Add("@LastUpdatedBy", SqlDbType.NVarChar, 50).Value = "Charles Moore";
                    //command1.Parameters.Add("@lastupdated", SqlDbType.Date).Value = DateTime.Now;


                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();
                }
            }

            color8 = newColor8;
        }

        public static void setRedLowValue(String newColor9)
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;



            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                {
                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandType = System.Data.CommandType.Text;


                    command1.CommandText = @"UPDATE [wholesomeDB].[dbo].[GradientValue] ([HexColor]) VALUES

               (@HexColor) WHERE GradientValue = '9'";

                    command1.Parameters.Add("@HexColor", SqlDbType.NChar, 10).Value = newColor9;
                    //command1.Parameters.Add("@GradientValue", SqlDbType.Date).Value = ;
                    //command1.Parameters.Add("@LastUpdatedBy", SqlDbType.NVarChar, 50).Value = "Charles Moore";
                    //command1.Parameters.Add("@lastupdated", SqlDbType.Date).Value = DateTime.Now;


                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();
                }
            }

            color9 = newColor9;
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
                
                    color = newReader["HexColor"].ToString();
                

                }

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

            return color;
        }

        public static String getColor4()
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
                if (count == 3)
                {
                    color = newReader["HexColor"].ToString();
                }

            }

            return color;
        }

        public static String getColor5()
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
                if (count == 4)
                {
                    color = newReader["HexColor"].ToString();
                }

            }

            return color;
        }

        public static String getColor6()
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
                if (count == 5)
                {
                    color = newReader["HexColor"].ToString();
                }

            }

            return color;
        }

        public static String getColor7()
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
                if (count == 6)
                {
                    color = newReader["HexColor"].ToString();
                }

            }

            return color;
        }

        public static String getColor8()
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
                if (count == 7)
                {
                    color = newReader["HexColor"].ToString();
                }

            }

            return color;
        }

        public static String getColor9()
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
                if (count == 8)
                {
                    color = newReader["HexColor"].ToString();
                }

            }

            return color;
        }
    }

    
}