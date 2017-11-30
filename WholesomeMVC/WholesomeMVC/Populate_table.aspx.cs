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
using Wholesome;
using System.Web.Services;

namespace Wholesome
{
    public partial class Populate_table : System.Web.UI.Page
    {
        public static ArrayList ndbnoList = new ArrayList();
        public static ArrayList descriptionList = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
                sc.ConnectionString = @"Server =localhost\SQLEXPRESS;Database=Master Ceres 4 Test Database;Trusted_Connection=Yes;";


                sc.Open();

                SqlDataReader newReader = null;
                SqlCommand myCommand = new SqlCommand("select ndb_no from BridgeInventoryItems",
                                                         sc);
                newReader = myCommand.ExecuteReader();
                while (newReader.Read())
                {
                    if (newReader["ndb_no"] != DBNull.Value)
                    {
                        ndbnoList.Add(newReader["ndb_no"].ToString());
                    }
                    

                }

                sc.Close();
                String url1 = "";
                String url2 = "";
                String ndbno = "";

                url1 = "https://api.nal.usda.gov/ndb/reports/?ndbno=";
                
                url2 = "&type=b&format=json&api_key=m37cNkiJMin6FLxPuq6wDMqtFekEJYB6HJpbLrYb";
                for(int i = 0; i < ndbnoList.Count; i++)
                {
                    String url = url1 + ndbno + url2;

                    var json = new WebClient().DownloadString(url);

                    var result = JsonConvert.DeserializeObject<RootObject>(json);
                    descriptionList.Add(result.foods[i].food.desc.name);
                }


                sc.Open();

                for (int i = 0; i < descriptionList.Count; i++)
                {
                    myCommand = new SqlCommand("INSERT INTO BridgeInventoryItems (Long_Desc) " +
                        "VALUES (@Long_Desc) WHERE ndb_no = " + ndbnoList[i], sc);
                    myCommand.Parameters.Add("@Long_Desc", SqlDbType.NVarChar, 200).Value = descriptionList[i];

                    myCommand.ExecuteNonQuery();
                }
                sc.Close();
            }
        }
    }
}