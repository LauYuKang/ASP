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

        string sessionid;
        string strSessionId;
        static string finalHash;
        static string salt;

        string MYDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Audit loadAudit = new Audit();
            AuditDAO newAuditDAO = new AuditDAO();
            List<Audit> auditList = newAuditDAO.getAllAudit();
            String useripaddr = loadAudit.GetIPAddress();
            String todayDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (auditList != null)
            {
                foreach (Audit currentAudit in auditList)
                {
                    String compareAuditIP = currentAudit.IPAddress;
                    if (compareAuditIP == useripaddr && currentAudit.IsBanned == "T" && todayDate.Substring(0, 10) == currentAudit.ActionDate.Substring(0, 10))
                    {
                        Response.Redirect("Oops.aspx");
                    }
                }
            }

            //store session id in cookie
            sessionid = HttpContext.Current.Session.SessionID;
            Response.Cookies.Add(new HttpCookie("sessionidcookie", sessionid));
            //rmbrMeCookie.Value = sessionid.ToString();


            if (!IsPostBack)
            {
                //if value of cookie is available
                if (Request.Cookies["val1"] != null && Request.Cookies["val2"] != null)
                {

                    tbLogin.Text = Request.Cookies["val1"].Value;
                    tbPassword.Attributes["value"] = Request.Cookies["val2"].Value;
                }

            }

            //keep the checkbox checked if "remember me" was checked
            if (!IsPostBack)
            {
                if (Session["checkbox"] != null)
                {
                    chkbox_rmbrMe.Checked = (bool)Session["checkbox"];
                }


            }

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
            string EncodedResponse = Request.Form["g-Recaptcha-Response"];
            bool IsCaptchaValid = (ReCaptchaClass.Validate(EncodedResponse) == "true" ? true : false);
            
            string adminNo = tbLogin.Text.ToUpper();
            validateLogin.Visible = false;
            validatePassword.Visible = false;
            
            //HttpCookie rmbrMeCookie = new HttpCookie("rmbrMeCookie");

            if (string.IsNullOrEmpty(tbLogin.Text) || string.IsNullOrEmpty(tbPassword.Text) || (!IsCaptchaValid))
            {
                if (string.IsNullOrEmpty(tbLogin.Text))
                { validateLogin.Visible = true; }
                if (string.IsNullOrEmpty(tbPassword.Text))
                {
                    validatePassword.Visible = true;
                    
                }
                if (!IsCaptchaValid)
                {
                    { validateCaptcha.Visible = true; }
                }
                
            }
            else
            {
                StudentLogin stuObj = new StudentLogin();
                StudentLoginDAO stuDao = new StudentLoginDAO();
                SHA512Managed hashing = new SHA512Managed();
                string dbHash = getDBHash(tbLogin.Text);
                string dbSalt = getDBSalt(tbLogin.Text);
                if (dbSalt != null && dbSalt.Length > 0 && dbHash != null && dbHash.Length > 0)
                {
                    string pwdWithSalt = tbPassword.Text + dbSalt;
                    byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));
                    string userHash = Convert.ToBase64String(hashWithSalt);
                    StudentDAO studentDao = new StudentDAO();
                    List<DAL.Student> allStu = studentDao.getAllstudent();
                    string isBanned = "F";
                    if (userHash.Equals(dbHash))
                    {
                        if (chkbox_rmbrMe.Checked)
                        {

                            //creates a session state for checkbox
                            Session["checkbox"] = chkbox_rmbrMe.Checked;
                            Response.Cookies["val1"].Value = tbLogin.Text;
                            Response.Cookies["val2"].Value = tbPassword.Text;


                        }
                        else
                        {
                            Session["checkbox"] = null;
                            Response.Cookies["val1"].Expires = DateTime.Now.AddMonths(-1);
                            Response.Cookies["val2"].Expires = DateTime.Now.AddMonths(-1);

                        }



                        Audit newAudit = new Audit();
                        AuditDAO newAuditDAO = new AuditDAO();
                        String currentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        String ipaddr = newAudit.GetIPAddress();
                        newAuditDAO.InsertAudit("STUDENT LOGIN SUCCESS", currentDateTime, "NIL", adminNo, ipaddr, "NIL", -1, isBanned);



                        string userid = tbLogin.Text.ToString().Trim();
                        string af = get2FA(userid);
                        if (af == "1")
                        {
                            Session["AdminNo"] = adminNo;
                            Session["role"] = "1";
                            //creates a new guid every login & saves into session
                            string guid = Guid.NewGuid().ToString();
                            Session["AuthToken"] = guid;

                            //creates cookie with the guid value
                            Response.Cookies.Add(new HttpCookie("AuthToken", guid));
                            Response.Redirect("OTP.aspx");
                            string roleformasterpage = Session["role"].ToString();

                        }
                        else
                        {
                            Session["AdminNo"] = adminNo;
                            Session["role"] = "1";
                            //creates a new guid every login & saves into session
                            string guid = Guid.NewGuid().ToString();
                            Session["AuthToken"] = guid;

                            //creates cookie with the guid value
                            Response.Cookies.Add(new HttpCookie("AuthToken", guid));
                            Response.Redirect("TripDetails.aspx");
                            string roleformasterpage = Session["role"].ToString();
                        }
                    }
                    else
                    {
                        Audit newAudit = new Audit();
                        AuditDAO newAuditDAO = new AuditDAO();
                        List<Audit> auditList = newAuditDAO.getAllAudit();

                        int loginCount = 0;
                        Boolean isValidID = false;

                        // is the input a valid ID?
                        foreach (DAL.Student currentStudent in allStu)
                        {
                            if (tbLogin.Text == currentStudent.AdminNo)
                            {
                                isValidID = true;
                            }
                        }

                        if (isValidID == true && auditList != null)
                        {
                            // this is the user ip address and current date
                            String useripaddr = newAudit.GetIPAddress();
                            String todayDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            // loop all the audits
                            foreach (Audit currentAudit in auditList)
                            {
                                String compareAuditIP = currentAudit.IPAddress;
                                if (compareAuditIP == useripaddr && currentAudit.ActionType == "STUDENT LOGIN FAIL" && todayDate.Substring(0, 10) == currentAudit.ActionDate.Substring(0, 10))
                                {
                                    loginCount++;
                                }
                            }
                            if (loginCount >= 8)
                            {
                                isBanned = "T";
                            }
                        }

                        String currentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        String ipaddr = newAudit.GetIPAddress();
                        newAuditDAO.InsertAudit("STUDENT LOGIN FAIL", currentDateTime, "NIL", adminNo, ipaddr, "NIL", -1, isBanned);

                        if (isBanned == "T")
                        {
                            Response.Redirect("Oops.aspx");
                        }


                        lblErrorMessage.Visible = true;
                        //Response.Cookies["val1"].Value = string.Empty;
                        //Response.Cookies["val2"].Value = string.Empty;
                    }
                }
                }
        }



        protected void btnSignUp_click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }

        protected void ButtonForgotPass_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmailConfirmation.aspx");
        }
    }
}