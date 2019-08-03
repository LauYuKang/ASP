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

using System.Data;


namespace eadLab5
{
    public partial class OTP : System.Web.UI.Page
    {

        protected string role = null;
        public static string adminNo = null;
        public static string Name = null;
        public static int Phone = 0;
        public string otp = null;
        public string otps = null;
        public string password = null;
        string MYDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            // in page load, send otp, send to database, check if textbox is same as database value, if same log in, if not try again
            // Find your Account Sid and Token at twilio.com/console
            // DANGER! This is insecure. See http://twil.io/secure

            if (Session["role"] != null)
            {
                role = Session["role"].ToString();
                if (role == "Incharge" || role == "Teacher")
                {
                    adminNo = null;
                }
                else if (role == "1" || role == "2" || role == "3")
                {
                    adminNo = Session["AdminNo"].ToString();
                    Session["role"] = null;
                }
            }





            string Name = GetStudentName(adminNo);
            int Phone = GetHpNumber(adminNo);
            string otps = GetOTP(adminNo);
            string password = GetPassword(adminNo);

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
                    var qry = "UPDATE [Student] SET OTP = @otp WHERE AdminNo=@adminNo";
                    var cmdconnection = new SqlCommand(qry, connection);
                    cmdconnection.Parameters.AddWithValue("@adminNo", adminNo);
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

                        body: Name + ", your otp is "+ otp  ,
                        from: new Twilio.Types.PhoneNumber("+19384448461"),
                        to: new Twilio.Types.PhoneNumber("+65"+Phone)
                    );

                    Console.WriteLine(message.Sid);
                }
            }
        }

        protected void ButtonOTP_Click(object sender, EventArgs e)
        {
            if (TextBoxOTP.Text.ToString() == otp.ToString())
            {

                StudentLogin stuObj = new StudentLogin();
                StudentLoginDAO stuDao = new StudentLoginDAO();
                stuObj = stuDao.getStudentById(adminNo, password);
                if (stuObj == null)
                {
                    Labelerror.Text = "gg canot log in" ;
                }
                else
                {
                    Session["AdminNo"] = stuObj.AdminNo;
                    Session["role"] = stuObj.Year;
                    Response.Redirect("TripDetails.aspx");
                    string roleformasterpage = Session["role"].ToString();

                    if (Session["role"] != null)
                    {
                        role = Session["role"].ToString();
                        if (role == "Incharge" || role == "Teacher")
                        {
                            adminNo = null;
                        }
                        else if (role == "1" || role == "2" || role == "3")
                        {
                            adminNo = Session["AdminNo"].ToString();
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

        


        protected string GetStudentName(string adminNo)
        {
            string h = null;
            SqlConnection connection = new SqlConnection(MYDBConnectionString);
            string sql = "SELECT StudentName FROM [Student] WHERE AdminNo=@adminNo";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@adminNo", adminNo);
            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        if (reader["StudentName"] != null)
                        {
                            if (reader["StudentName"] != DBNull.Value)
                            {
                                h = reader["StudentName"].ToString();
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

        protected string GetOTP(string adminNo)
        {
            string h = null;
            SqlConnection connection = new SqlConnection(MYDBConnectionString);
            string sql = "SELECT OTP FROM [Student] WHERE AdminNo=@adminNo";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@adminNo", adminNo);
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



        protected int GetHpNumber(string adminNo)
        {
            int h = 0;
            SqlConnection connection = new SqlConnection(MYDBConnectionString);
            string sql = "SELECT HpNumber FROM [Student] WHERE AdminNo=@adminNo";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@adminNo", adminNo);
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

        protected string GetPassword(string adminNo)
        {
            string h = null;
            SqlConnection connection = new SqlConnection(MYDBConnectionString);
            string sql = "SELECT Password FROM [Student] WHERE AdminNo=@adminNo";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@adminNo", adminNo);
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