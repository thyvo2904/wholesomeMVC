using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace WholesomeMVC
{
    public partial class Activation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                string activationCode = !string.IsNullOrEmpty(Request.QueryString["ActivationCode"]) ? Request.QueryString["ActivationCode"] : Guid.Empty.ToString();
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Account_Activation WHERE ActivationCode = @ActivationCode"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@ActivationCode", activationCode);
                            cmd.Connection = con;
                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();
                            con.Close();
                            if (rowsAffected == 1)
                            {
                                ltMessage.Text = "Activation successful.";
                            }
                            else
                            {
                                ltMessage.Text = "Invalid Activation code.";
                            }
                        }
                    }
                }
            }
        }

    }
}