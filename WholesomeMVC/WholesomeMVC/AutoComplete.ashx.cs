using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace WholesomeMVC
{
    /// <summary>
    /// Summary description for AutoComplete
    /// </summary>
    public class AutoComplete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string prefixText = context.Request.QueryString["term"];
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["constr2"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select Long_Desc from FOOD_DES where Long_Desc like + @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    List<string> Items = new List<string>();
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Items.Add(sdr["Long_Desc"].ToString());
                        }
                    }
                    conn.Close();
                    context.Response.Write(new JavaScriptSerializer().Serialize(Items));
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}