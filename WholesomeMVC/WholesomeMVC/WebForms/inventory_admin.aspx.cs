using Microsoft.AspNet.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WholesomeMVC.WebForms;

namespace WholesomeMVC.WebForms
{
	public partial class inventory_admin : System.Web.UI.Page
	{
        ArrayList scenarioID = new ArrayList();
		protected void Page_Load(object sender, EventArgs e)
		{
          //  this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (IsPostBack) {

            }
            else {
				
				String strTitle = "Current Inventory";

				Literal page_title = (Literal) Master.FindControl("page_title");
				page_title.Text = strTitle;
				Label body_title = (Label) Master.FindControl("body_title");
				body_title.Text = strTitle;

                ddlCereItem.DataBind();
                ddlFBGroup.DataBind();

                String strChart1Header = "Purchased Item Overview";
				chart_1_header.Text = strChart1Header;
				String strWhatIfHeader = "What-If Scenario";
				whatif_header.Text = strWhatIfHeader;
                if (CheckWhatIf() == true)
                {
                    System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection
                    {
                        ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
                    };

                    sc.Open();
                    SqlCommand myCommand = new SqlCommand("Pull_Weight_WhatIf", sc)
                    {
                        CommandType = CommandType.StoredProcedure

                    };
                    System.Data.SqlClient.SqlParameter LastUpdated = new System.Data.SqlClient.SqlParameter();
                    LastUpdated.ParameterName = "@LastUpdated";
                    LastUpdated.Value = DateTime.Now;
                    myCommand.Parameters.Add(LastUpdated); System.Data.SqlClient.SqlParameter LastUpdatedBy = new System.Data.SqlClient.SqlParameter();
                    LastUpdatedBy.ParameterName = "@LastUpdatedBy";
                    LastUpdatedBy.Value = HttpContext.Current.User.Identity.GetUserName();
                    myCommand.Parameters.Add(LastUpdatedBy);
                    myCommand.ExecuteNonQuery();
                    sc.Close();
                }
            }

        }
        
        protected void btnWhatif_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr2"].ConnectionString))
            {
                System.Data.SqlClient.SqlCommand go = new System.Data.SqlClient.SqlCommand();

                con.Open();
                go.Connection = con;
                go.CommandText = "INSERT INTO WHATIF_SCENARIO (ITEM_ID, NETWEIGHT, RECEIVEDDATE,LASTUPDATED, LASTUPDATEDBY)" +
                    "VALUES (@ITEMID, @NETWEIGHT, @RECEIVEDDATE, @LASTUPDATED, @LASTUPDATEDBY);";
                go.Parameters.Add("@ITEMID", SqlDbType.Int).Value = findItemID(ddlCereItem.SelectedValue.ToString());
                go.Parameters.Add("@NETWEIGHT", SqlDbType.Float).Value = txtQuantity.Text;
                go.Parameters.Add("@RECEIVEDDATE", SqlDbType.DateTime).Value = DateTime.Now;
                go.Parameters.Add("@LASTUPDATED", SqlDbType.DateTime).Value = DateTime.Now;
                go.Parameters.Add("@LASTUPDATEDBY", SqlDbType.NVarChar, 20).Value = HttpContext.Current.User.Identity.GetUserName();
                go.ExecuteNonQuery();

                go.Parameters.Clear();

                go.CommandText = "Select max(ScenarioID) from whatif_scenario;";
                go.ExecuteNonQuery();
                SqlDataReader readIn = go.ExecuteReader();
                while (readIn.Read())
                {
                    scenarioID.Add(readIn["ScenarioID"].ToString());
                }
                con.Close();


            }
        }
        public static int findItemID(string itemName)
        {
            int itemID = -1;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr2"].ConnectionString))
            {
                System.Data.SqlClient.SqlCommand go = new System.Data.SqlClient.SqlCommand();

                con.Open();
                go.Connection = con;
                go.CommandText = "SELECT Top 1 ITEM_ID FROM [DBO].[WHOLESOME_ITEM] WHERE DESCRIPTION = @DESCRIPTION;";
                go.Parameters.Add("@DESCRIPTION", SqlDbType.NVarChar, 50).Value = itemName;
                go.ExecuteNonQuery();
                SqlDataReader readIn = go.ExecuteReader();
                while (readIn.Read())
                {
                    itemID = Convert.ToInt32(readIn["Item_ID"].ToString());
                }
                con.Close();
            }
            return itemID;
        }
        protected bool CheckWhatIf()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr2"].ConnectionString))
            {
                System.Data.SqlClient.SqlCommand go = new System.Data.SqlClient.SqlCommand();

                con.Open();
                go.Connection = con;
                go.CommandText = "SELECT count(item_id) as COUNTER FROM [DBO].[Whatif_scenario];";
                go.ExecuteNonQuery();
                SqlDataReader readIn = go.ExecuteReader();
                while (readIn.Read())
                {
                    if(readIn["COUNTER"].Equals(0))
                        return true;
                }
                con.Close();
            }
            return false;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            if (scenarioID.Count != 0)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr2"].ConnectionString))
                    {
                        System.Data.SqlClient.SqlCommand go = new System.Data.SqlClient.SqlCommand();
                        con.Open();
                        go.Connection = con;
                        for (int i = 0; i < scenarioID.Count; i++)
                        {
                            go.CommandText = "Delete from Whatif_scenario where ScrenarioID=@ScenarioID";
                            go.Parameters.Add("@ScenarioID", SqlDbType.Int).Value = scenarioID[i];
                            go.ExecuteNonQuery();
                        }
                        con.Close();
                    }
                    scenarioID.Clear();
                }
                catch
                {

                }
            }
        }
    }
}