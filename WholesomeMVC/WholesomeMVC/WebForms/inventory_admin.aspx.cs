using Microsoft.AspNet.Identity;
using System;
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
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack) {
                ddlCereItem.DataBind();
                ddlFBGroup.DataBind();
            } else {
				
				String strTitle = "Inventory Admin";

				Literal page_title = (Literal) Master.FindControl("page_title");
				page_title.Text = strTitle;
				Label body_title = (Label) Master.FindControl("body_title");
				body_title.Text = strTitle;

				String strChart1Header = "Purchased Item Overview";
				chart_1_header.Text = strChart1Header;
				String strChart2Header = "Inventory Overview";
				chart_2_header.Text = strChart2Header;
				String strWhatIfHeader = "What-If Scenario";
				whatif_header.Text = strWhatIfHeader;
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
    }
}