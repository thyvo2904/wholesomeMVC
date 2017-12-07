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
    public class GradientValues
    {
        // Lowest numbers to highest
        private static double value1 { get; set; }


        private static double value2 { get; set; }


        private static double value3 { get; set; }





        public static void setValue1(double value)
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;



            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                {
                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandType = System.Data.CommandType.Text;


                    command1.CommandText = @"UPDATE [wholesomeDB].[dbo].[GradientValue] SET

               MaxValue = @MaxValue, LastUpdatedBy = @LastUpdatedBy, LastUpdated = @LastUpdated WHERE GradientEntry = '1'";

                    command1.Parameters.Add("@MaxValue", SqlDbType.Decimal, 18).Value = value;
                    //command1.Parameters.Add("@GradientValue", SqlDbType.Date).Value = ;
                    command1.Parameters.Add("@LastUpdatedBy", SqlDbType.VarChar, 20).Value = "Charles Moore";
                    command1.Parameters.Add("@lastupdated", SqlDbType.Date).Value = DateTime.Now;


                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();

                    command1 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandType = System.Data.CommandType.Text;


                    command1.CommandText = @"UPDATE [wholesomeDB].[dbo].[GradientValue] SET

               MinValue = @MinValue, LastUpdatedBy = @LastUpdatedBy, LastUpdated = @LastUpdated WHERE GradientEntry = '2'";

                    command1.Parameters.Add("@MinValue", SqlDbType.Decimal, 18).Value = value;
                    //command1.Parameters.Add("@GradientValue", SqlDbType.Date).Value = ;
                    command1.Parameters.Add("@LastUpdatedBy", SqlDbType.VarChar, 20).Value = "Charles Moore";
                    command1.Parameters.Add("@lastupdated", SqlDbType.Date).Value = DateTime.Now;


                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public static void setValue2(double value)
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;



            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                {
                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandType = System.Data.CommandType.Text;


                    command1.CommandText = @"UPDATE [wholesomeDB].[dbo].[GradientValue] SET

               MaxValue = @MaxValue, LastUpdatedBy = @LastUpdatedBy, LastUpdated = @LastUpdated WHERE GradientEntry = '2'";

                    command1.Parameters.Add("@MaxValue", SqlDbType.Decimal, 18).Value = value;
                    //command1.Parameters.Add("@GradientValue", SqlDbType.Date).Value = ;
                    command1.Parameters.Add("@LastUpdatedBy", SqlDbType.VarChar, 20).Value = "Charles Moore";
                    command1.Parameters.Add("@lastupdated", SqlDbType.Date).Value = DateTime.Now;


                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();

                    command1 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandType = System.Data.CommandType.Text;


                    command1.CommandText = @"UPDATE [wholesomeDB].[dbo].[GradientValue] SET

               MinValue = @MinValue, LastUpdatedBy = @LastUpdatedBy, LastUpdated = @LastUpdated WHERE GradientEntry = '3'";

                    command1.Parameters.Add("@MinValue", SqlDbType.Decimal, 18).Value = value;
                    //command1.Parameters.Add("@GradientValue", SqlDbType.Date).Value = ;
                    command1.Parameters.Add("@LastUpdatedBy", SqlDbType.VarChar, 20).Value = "Charles Moore";
                    command1.Parameters.Add("@lastupdated", SqlDbType.Date).Value = DateTime.Now;


                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public static void setValue3(double value)
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;



            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                {
                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandType = System.Data.CommandType.Text;


                    command1.CommandText = @"UPDATE [wholesomeDB].[dbo].[GradientValue] SET

               MaxValue = @MaxValue, LastUpdatedBy = @LastUpdatedBy, LastUpdated = @LastUpdated WHERE GradientEntry = '3'";

                    command1.Parameters.Add("@MaxValue", SqlDbType.Decimal, 18).Value = value;
                    //command1.Parameters.Add("@GradientValue", SqlDbType.Date).Value = ;
                    command1.Parameters.Add("@LastUpdatedBy", SqlDbType.VarChar, 20).Value = "Charles Moore";
                    command1.Parameters.Add("@lastupdated", SqlDbType.Date).Value = DateTime.Now;


                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();

                    command1 = new SqlCommand();
                    command1.Connection = connection;
                    command1.CommandType = System.Data.CommandType.Text;


                    command1.CommandText = @"UPDATE [wholesomeDB].[dbo].[GradientValue] SET

               MinValue = @MinValue, LastUpdatedBy = @LastUpdatedBy, LastUpdated = @LastUpdated WHERE GradientEntry = '4'";

                    command1.Parameters.Add("@MinValue", SqlDbType.Decimal, 18).Value = value;
                    //command1.Parameters.Add("@GradientValue", SqlDbType.Date).Value = ;
                    command1.Parameters.Add("@LastUpdatedBy", SqlDbType.VarChar, 20).Value = "Charles Moore";
                    command1.Parameters.Add("@lastupdated", SqlDbType.Date).Value = DateTime.Now;


                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }



        public static String getValue1()
        {
            String value = "";
            int count = 0;
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            };

            sc.Open();

            SqlDataReader newReader = null;
            SqlCommand myCommand = new SqlCommand("SELECT MaxValue FROM GradientValue WHERE GradientEntry = 1",
                                                     sc);
            newReader = myCommand.ExecuteReader();
            count++;
            if (count == 1)
                while (newReader.Read())
                {

                    value = newReader["MaxValue"].ToString();


                }
            sc.Close();
            return value;
        }

        public static String getValue2()
        {
            String value = "";
            int count = 0;
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            };

            sc.Open();

            SqlDataReader newReader = null;
            SqlCommand myCommand = new SqlCommand("SELECT MaxValue FROM GradientValue",
                                                     sc);
            newReader = myCommand.ExecuteReader();

            while (newReader.Read())
            {
                count++;
                if (count == 1)
                {
                    value = newReader["MaxValue"].ToString();
                }

            }
            sc.Close();
            return value;
        }

        public static String getValue3()
        {
            String value = "";
            int count = 0;
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            };

            sc.Open();

            SqlDataReader newReader = null;
            SqlCommand myCommand = new SqlCommand("SELECT MaxValue FROM GradientValue",
                                                     sc);
            newReader = myCommand.ExecuteReader();

            while (newReader.Read())
            {
                count++;
                if (count == 2)
                {
                    value = newReader["MaxValue"].ToString();
                }

            }
            sc.Close();
            return value;
        }

    }
    

}