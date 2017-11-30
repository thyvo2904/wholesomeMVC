using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
using Wholesome;
using System.Security.Principal;

public partial class login : System.Web.UI.Page
{
    public static string fname = "";
    public static string lname = "";
    public static Account newAccount = new Account();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
        if (!IsPostBack)
        {
            
           
        }
    }
        protected void btnSearch(object sender, EventArgs e)
    {

        if (txtSearch.Text != "")
        {
            String foodSearch = "";
            foodSearch = txtSearch.Text;
            FoodItem.findNdbno(foodSearch);
            Response.Redirect("~/IndexResults.aspx");
        }

        else
        {
            Response.Write("<script>alert('Please enter a value');</script>");
        }


    }

    protected void ValidateUser(object sender, EventArgs e)
    {
        int userId = 0;
        int AccountType = -1;
        string constr = ConfigurationManager.ConnectionStrings["constr2"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("Validate_User"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", txtUsername.Value.Trim());
                cmd.Parameters.AddWithValue("@Password_Hash", Encrypt(txtPassword.Value.Trim()));
                newAccount.passwordhash = txtPassword.Value.Trim();
                cmd.Connection = con;
                con.Open();
                userId = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
            string message = string.Empty;
            switch (userId)
            {
                case -1:
                    message = "Username and/or password is incorrect.";
                    break;
                case -2:
                    message = "Account has not been activated. Please contact the admin.";
                    break;
                default:
                    using (SqlCommand cmd = new SqlCommand("Select Top 1 username, Account_Type, email, password_Hash, FirstName, LastName from Account where @UserID=UserID"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@UserId", userId);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            SqlDataReader reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                AccountType = int.Parse(reader["Account_Type"].ToString());
                                newAccount.passwordhash = Decrypt(reader["Password_Hash"].ToString());
                                newAccount.firstname = reader["FirstName"].ToString();
                                newAccount.lastname = reader["LastName"].ToString();
                                newAccount.email = reader["email"].ToString();
                                newAccount.username = reader["username"].ToString();
                                Session["name"] = newAccount.firstname;
                                //Roles.CreateRole("0");
                                //Roles.AddUserToRole(newAccount.username, "0");

                            }
                            con.Close();
                            
                          //  newAccount.firstname

                        }
                        switch (AccountType)
                        {
                            case 0:
                                Server.Transfer("~/Admin/inventory.aspx");
                                break;
                            case 1:
                                Server.Transfer("~/inventory_staff.aspx");
                                break;
                            case 2:
                                Server.Transfer("~/inventory_purchased.aspx");
                                break;
                            default:
                                Response.Redirect("~/index.aspx");
                                break;
                        }
                    }
                    break;
                

            }
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);

        }
    }
    public static string Encrypt(string toEncrypt)
    {
        byte[] keyArray;
        byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

        System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();

        string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
        hashmd5.Clear();
        TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        tdes.Key = keyArray;
        tdes.Mode = CipherMode.ECB;
        tdes.Padding = PaddingMode.PKCS7;

        ICryptoTransform cTransform = tdes.CreateEncryptor();
        byte[] resultArray =
          cTransform.TransformFinalBlock(toEncryptArray, 0,
          toEncryptArray.Length);
        tdes.Clear();
        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }
    public static string Decrypt(string cipherString)
    {
        byte[] keyArray;

        byte[] toEncryptArray = Convert.FromBase64String(cipherString);

        System.Configuration.AppSettingsReader settingsReader =new AppSettingsReader();
        string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));

        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

        hashmd5.Clear();

        TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        tdes.Key = keyArray;

        tdes.Mode = CipherMode.ECB;
        tdes.Padding = PaddingMode.PKCS7;

        ICryptoTransform cTransform = tdes.CreateDecryptor();
        byte[] resultArray = cTransform.TransformFinalBlock(
                             toEncryptArray, 0, toEncryptArray.Length);
        tdes.Clear();
        return UTF8Encoding.UTF8.GetString(resultArray);
    }
   
}

