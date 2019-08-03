using eadLab5.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;


namespace eadLab5
{
    public partial class loginStudent : System.Web.UI.Page
    {
        static string finalHash;
        static string salt;

        string MYDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
            Session["AdminNo"] = null;
            Session["role"] = null;
        }





        protected string getDBSalt(string userid)
        {
            string s = null;
            SqlConnection connection = new SqlConnection(MYDBConnectionString);
            string sql = "select Salt FROM [Student] WHERE AdminNo=@USERID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@USERID", userid);
            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["Salt"] != null)
                        {
                            if (reader["Salt"] != DBNull.Value)
                            {
                                s = reader["Salt"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { connection.Close(); }
            return s;
        }


        protected string get2FA(string userid)
        {
            string s = null;
            SqlConnection connection = new SqlConnection(MYDBConnectionString);
            string sql = "select FA FROM [Student] WHERE AdminNo=@USERID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@USERID", userid);
            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["FA"] != null)
                        {
                            if (reader["FA"] != DBNull.Value)
                            {
                                s = reader["FA"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { connection.Close(); }
            return s;
        }
        protected string getDBHash(string userid)
        {
            string h = null;
            SqlConnection connection = new SqlConnection(MYDBConnectionString);
            string sql = "select Password FROM [Student] WHERE AdminNo=@USERID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@USERID", userid);
            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        if (reader["Password"] != null)
                        {
                            if (reader["Password"] != DBNull.Value)
                            {
                                h = reader["Password"].ToString();
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { connection.Close(); }
            return h;
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
            tbLogin.Text.ToUpper();
            validateLogin.Visible = false;
            validatePassword.Visible = false;
            if (string.IsNullOrEmpty(tbLogin.Text) || string.IsNullOrEmpty(tbPassword.Text))
            {
                if (string.IsNullOrEmpty(tbLogin.Text))
                { validateLogin.Visible = true; }
                if (string.IsNullOrEmpty(tbPassword.Text))
                { validatePassword.Visible = true; }
            }
            else
            {
                StudentLogin stuObj = new StudentLogin();
                StudentLoginDAO stuDao = new StudentLoginDAO();
                stuObj = stuDao.getStudentById(tbLogin.Text, tbPassword.Text);
                if (stuObj == null)
                {
                    lblErrorMessage.Visible = true;
                }
                else
                {
                    string userid = tbLogin.Text.ToString().Trim();
                    string af = get2FA(userid);

                    if (af == "1") {
                        Session["AdminNo"] = stuObj.AdminNo;
                        Session["role"] = stuObj.Year;
                        Response.Redirect("OTP.aspx");
                        string roleformasterpage = Session["role"].ToString();
                    }
                    else
                    {
                        Session["AdminNo"] = stuObj.AdminNo;
                        Session["role"] = stuObj.Year;
                        Response.Redirect("TripDetails.aspx");
                        string roleformasterpage = Session["role"].ToString();
                    }
                    
                }
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }

        protected void ButtonForgotPass_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmailConfirmation.aspx");
        }
    }
}