using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace WholesomeMVC.WebForms
{
	/// <summary>
	/// Summary description for AutoComplete
	/// </summary>
	public class autocomplete : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			string prefixText = context.Request.QueryString["term"];

			/**
			 * Option 1: get data from local DB
			 */
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
				using (SqlCommand cmd = new SqlCommand())
				{
					//cmd.CommandText = "select Long_Desc from FOOD_DES where Long_Desc like + @SearchText + '%'";
					//cmd.Parameters.AddWithValue("@SearchText", prefixText);
					cmd.CommandText = "select Long_Desc from FOOD_DES";
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
					context.Response.ContentType = "application/json";
					context.Response.Write(new JavaScriptSerializer().Serialize(Items));
				}
			}

			/**
			 * Option 2: get data from USDA API
			 */
			//String urlPartOne = "https://api.nal.usda.gov/ndb/search/?format=json&q=";
			//String urlPartTwo = "&max=10&offset=0&api_key=m37cNkiJMin6FLxPuq6wDMqtFekEJYB6HJpbLrYb";
			//String url = urlPartOne + prefixText + urlPartTwo;

			//using (WebClient wc = new WebClient())
			//{
			//	var json = new WebClient().DownloadString(url);
			//	context.Response.ContentType = "application/json";
			//	context.Response.Write(json);
			//}
		}

		public bool IsReusable
		{
			get {
				return true;
			}
		}
	}
}