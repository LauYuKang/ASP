using System;
using eadLab5.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Net;
using System.Data.SqlClient;

namespace eadLab5
{
    public partial class OTPStaff : System.Web.UI.Page
    {

        protected string role = null;
        public static string email = null;
        public static string Staffemail = null;
        public static string Name = null;
        public static int Phone = 0;
        public string otp = null;
        public string otps = null;
        public string password = null;
        string MYDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] != null)
            {
                role = Session["role"].ToString();
                if (role == "Incharge" || role == "Teacher")
                {
                    email = Session["Staffid"].ToString();
                    Session["role"] = null;
                }
                else if (role == "1" || role == "2" || role == "3")
                {
                    email = null;
                }
            }
            string Name = GetStudentName(email);
            string Staffemail = GetStaffEmail(email);
            int Phone = GetHpNumber(email);
            string otps = GetOTP(email);
            string password = GetPassword(email);


            if (!IsPostBack)
            {
                if (role == "")
                {
                    System.Diagnostics.Debug.WriteLine("its empty");
                }
                else if (role == null)
                {
                    System.Diagnostics.Debug.WriteLine("its null");
                }
                else
                {
                    string num = "0123456789";
                    int len = num.Length;
                    string otp = string.Empty;
                    int otpdigit = 6;
                    string finaldigit;
                    int getindex;
                    for (int i = 0; i < otpdigit; i++)
                    {
                        do
                        {
                            getindex = new Random().Next(0, len);
                            finaldigit = num.ToCharArray()[getindex].ToString();
                        } while (otp.IndexOf(finaldigit) != -1);
                        otp += finaldigit;
                    }

                    SqlConnection connection = new SqlConnection(MYDBConnectionString);
                    var qry = "UPDATE [Staff] SET OTP = @otp WHERE Staffid=@email";
                    var cmdconnection = new SqlCommand(qry, connection);
                    cmdconnection.Parameters.AddWithValue("@email", email);
                    cmdconnection.Parameters.AddWithValue("@otp", otp);
                    connection.Open();
                    cmdconnection.ExecuteNonQuery();
                    connection.Close();



                    System.Diagnostics.Debug.WriteLine(role);
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //TLS 1.2
                    const string accountSid = "ACa7e3440e40cba702f8d4ab7d9e9bd245";
                    const string authToken = "893fb93024fdd2a5c561418deb6ff911";

                    TwilioClient.Init(accountSid, authToken);

                    var message = MessageResource.Create(

                        body: Name + ", your otp is " + otp,
                        from: new Twilio.Types.PhoneNumber("+19384448461"),
                        to: new Twilio.Types.PhoneNumber("+6591995179")
                    );

                    Console.WriteLine(message.Sid);
                }
            }


        }

        protected void ButtonOTP_Click(object sender, EventArgs e)
        {
            if (TextBoxOTP.Text.ToString() == otp.ToString())
            {

                StaffLogin logObj = new StaffLogin();
                StaffLoginDAO logDao = new StaffLoginDAO();
                logObj = logDao.getStaffById(Staffemail, password);
                if (logObj == null)
                {
                    Labelerror.Text = "gg canot log in";
                }
                else
                {
                    Session["Staffid"] = logObj.Staffid;
                    Session["role"] = logObj.Role;
                    Response.Redirect("TripDetails.aspx");
                    string roleformasterpage = Session["role"].ToString();

                    if (Session["role"] != null)
                    {
                        role = Session["role"].ToString();
                        if (role == "Incharge" || role == "Teacher")
                        {
                            email = Session["Staffid"].ToString();
                        }
                        else if (role == "1" || role == "2" || role == "3")
                        {
                            email = null;
                        }
                    }
                    Response.Redirect("TripDetails.aspx");

                }
            }
            else
            {
                Labelerror.Text = "no work" + otp;
            }
        }


        protected string GetStudentName(string email)
        {
            string h = null;
            SqlConnection connection = new SqlConnection(MYDBConnectionString);
            string sql = "SELECT Name FROM [Staff] WHERE Staffid=@email";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@email", email);
            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        if (reader["Name"] != null)
                        {
                            if (reader["Name"] != DBNull.Value)
                            {
                                h = reader["Name"].ToString();
                                Name = h;
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

        protected string GetStaffEmail(string staffemail)
        {
            string h = null;
            SqlConnection connection = new SqlConnection(MYDBConnectionString);
            string sql = "SELECT Email FROM [Staff] WHERE Staffid=@email";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@email", email);
            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        if (reader["Email"] != null)
                        {
                            if (reader["Email"] != DBNull.Value)
                            {
                                h = reader["Email"].ToString();
                                Staffemail = h;
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


        protected string GetOTP(string email)
        {
            string h = null;
            SqlConnection connection = new SqlConnection(MYDBConnectionString);
            string sql = "SELECT OTP FROM [Staff] WHERE Staffid=@email";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@email", email);
            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        if (reader["OTP"] != null)
                        {
                            if (reader["OTP"] != DBNull.Value)
                            {
                                h = reader["OTP"].ToString();
                                otp = h;
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

        protected int GetHpNumber(string email)
        {
            int h = 0;
            SqlConnection connection = new SqlConnection(MYDBConnectionString);
            string sql = "SELECT HpNumber FROM [Staff] WHERE Staffid=@email";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@email", email);
            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        if (reader["HpNumber"] != null)
                        {
                            if (reader["HpNumber"] != DBNull.Value)
                            {
                                h = int.Parse(reader["HpNumber"].ToString());
                                Phone = h;
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

        protected string GetPassword(string email)
        {
            string h = null;
            SqlConnection connection = new SqlConnection(MYDBConnectionString);
            string sql = "SELECT Password FROM [Staff] WHERE Staffid=@email";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@email", email);
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
                                password = h;
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




    }






}