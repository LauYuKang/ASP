using eadLab5.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace eadLab5
{
    public partial class SignUp : System.Web.UI.Page
    {
        static string finalHash;
        static string salt;
        byte[] Key;
        byte[] IV;
        int rInt ;
        string adminNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            validateAdminNo.Visible = false;
            validateYear.Visible = false;
            validatePw.Visible = false;
            validateCfmPw.Visible = false;
            validateEmail.Visible = false;
            validatePhoneNo.Visible = false;
            lblverification.Visible = false;
            Session["AdminNo"] = null;
            Session["Email"] = null;
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(tbAdminNo.Text) || string.IsNullOrEmpty(tbYear.Text) || string.IsNullOrEmpty(tbPw.Text) || string.IsNullOrEmpty(tbCfmpw.Text) || string.IsNullOrEmpty(tbEmailAdd.Text) || string.IsNullOrEmpty(tbPhone.Text))
            {
                if (string.IsNullOrEmpty(tbAdminNo.Text)) {
                    validateAdminNo.Text = "Admin Number is required!";
                    validateAdminNo.Visible = true; }
                if (string.IsNullOrEmpty(tbYear.Text))
                {
                    validateYear.Text = "Academic Year is required!";
                    validateYear.Visible = true;
                }
                if (string.IsNullOrEmpty(tbPw.Text)) {
                    validatePw.Text = "Password is required!";
                    validatePw.Visible = true; }
                if (string.IsNullOrEmpty(tbCfmpw.Text)) {
                    validateCfmPw.Text = "Confirm Password is required";
                    validateCfmPw.Visible = true; }
                if (tbPw.Text != tbCfmpw.Text)
                {
                    validateCfmPw.Text = "Password not the same";
                    validateCfmPw.Visible = true;
                }
                if (string.IsNullOrEmpty(tbEmailAdd.Text)) {
                    validateEmail.Text = "Email Address is required!";
                    validateEmail.Visible = true; }
                if (string.IsNullOrEmpty(tbPhone.Text)) {
                    validatePhoneNo.Text = "Phone Number is required!";
                    validatePhoneNo.Visible = true; }
            }
            else
            {
                if (string.IsNullOrEmpty(tbAdminNo.Text) == false && string.IsNullOrEmpty(tbYear.Text) == false && string.IsNullOrEmpty(tbPw.Text) == false && string.IsNullOrEmpty(tbCfmpw.Text) == false && string.IsNullOrEmpty(tbEmailAdd.Text) == false && string.IsNullOrEmpty(tbPhone.Text) == false)
                {

                    Regex admin = new Regex(@"[0-9][0-9][0-9][0-9][0-9][0-9][A-Z]");
                    if (admin.Match(tbAdminNo.Text).Success){ }
                    else
                    {
                        validateAdminNo.Text = "Invalid Admin Number!";
                        validateAdminNo.Visible = true;
                    }
                    if (tbYear.Text.Length != 1)
                    {
                        validateYear.Text = "Invalid Academic Year!";
                        validateYear.Visible = true;
                    }
                    Regex year = new Regex(@"[1-3]");
                    if (year.Match(tbYear.Text).Success) { }
                    else
                    {
                        validateYear.Text = "Invalid Academic Year!";
                        validateYear.Visible = true;
                    }

                    Regex password = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
                    if (password.Match(tbPw.Text).Success) { }
                    else
                    {
                        validatePw.Text = "Invalid password";
                        validatePw.Visible = true;
                    }
                    Regex email = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                    if (email.Match(tbEmailAdd.Text).Success) { }
                    else
                    {
                        validateEmail.Text = "Invalid Email Address";
                        validateEmail.Visible = true;
                    }
                    if (tbPhone.Text.Length < 8)
                    {
                        validatePhoneNo.Text = "Invalid Phone Number";
                        validatePhoneNo.Visible = true;
                    }
                    Regex phoneNo = new Regex(@"[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]");
                    if (phoneNo.Match(tbPhone.Text).Success) { }
                    else
                    {
                        validatePhoneNo.Text = "Invalid Phone Number";
                        validatePhoneNo.Visible = true;
                    }

                }
                if (validateAdminNo.Visible || validateYear.Visible || validatePw.Visible || validateCfmPw.Visible || validateEmail.Visible || validatePhoneNo.Visible) { }
                else
                {
                    StudentLogin stuObj = new StudentLogin();
                    StudentLoginDAO stuDao = new StudentLoginDAO();
                    stuObj = stuDao.getStudentById(tbAdminNo.Text.ToString());
                    if (stuObj != null)
                    {
                        LblResult.ForeColor = System.Drawing.Color.Red;
                        LblResult.Visible = true;
                        LblResult.Text = "User Exist";
                    }
                    else
                    {
                        string pwd = tbPw.Text.ToString().Trim();
                        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                        byte[] saltByte = new byte[8];
                        rng.GetBytes(saltByte);
                        salt = Convert.ToBase64String(saltByte);
                        SHA512Managed hashing = new SHA512Managed();

                        string pwdWithSalt = pwd + salt;
                        byte[] plainHash = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwd));
                        byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));
                        finalHash = Convert.ToBase64String(hashWithSalt);
                        RijndaelManaged cipher = new RijndaelManaged();
                        cipher.GenerateKey();

                        int Year = Int32.Parse(tbYear.Text);
                        string EmailVerified = "F";
                        adminNo = tbAdminNo.Text;
                        cipher.GenerateKey();
                        Key = cipher.Key;
                        IV = cipher.IV;
                        string phoneno = Convert.ToBase64String(encryptData(tbPhone.Text));

                        StudentDAO logDao = new StudentDAO();
                        int logObj = logDao.InsertTD(tbAdminNo.Text, finalHash, Year, tbEmailAdd.Text, phoneno, salt, EmailVerified);

                        if (logObj == 1)
                        {
                            //Random r = new Random();
                            //rInt = r.Next(10000, 99999);
                            //SendPasswordResetEmail(tbEmailAdd.Text, tbAdminNo.Text, rInt);
                            //lblverification.Visible = true;
                            //btnSignUp.Visible = false;
                            //btnDone.Visible = true;
                            //tbVerification.Visible = true;
                            Session["AdminNo"] = tbAdminNo.Text;
                            Session["Email"] = tbEmailAdd.Text;
                            LblResult.Text = "Please Verify Your Email!!! ";
                            LblResult.ForeColor = System.Drawing.Color.Green;
                            Response.Redirect("EmailVerified.aspx");
                        }
                        else
                        {
                            LblResult.Text = "Please fill in all the blank!";
                            LblResult.ForeColor = System.Drawing.Color.Red;

                        }
                    }

                }

            }

        }

        private void SendPasswordResetEmail(string ToEmail, string UserName, int r)
        {
            // MailMessage class is present is System.Net.Mail namespace
            MailMessage mailMessage = new MailMessage("ikaroswork1@gmail.com", ToEmail);


            // StringBuilder class is present in System.Text namespace
            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("Dear " + UserName + ",<br/><br/>");
            sbEmailBody.Append("Your code is "+ rInt);
            sbEmailBody.Append("<br/><br/>");
            sbEmailBody.Append("<b>SARASA</b>");

            mailMessage.IsBodyHtml = true;

            mailMessage.Body = sbEmailBody.ToString();
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);


            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "ikaroswork1@gmail.com",
                Password = "1234321xX"
            };

            smtpClient.EnableSsl = true;
            try
            {
                smtpClient.Send(mailMessage);
                Page.RegisterStartupScript("UserMsg", "<script>alert('successful')</script>");
            }

            catch
            {
                Page.RegisterStartupScript("UserMsg", "<script>alert('fail')</script>");
            }
        }

        //protected void btnDone_Click(object sender, EventArgs e)
        //{
        //    lblverification.Visible = true;
        //    int rdno = Int32.Parse(tbVerification.Text);
        //    if (rdno == rInt)
        //    {
        //        lblverification.Visible = true;
        //        String EmailVerified = "T";
        //        StudentDAO logDao = new StudentDAO();
        //        int logObj = logDao.updateVerified(adminNo, EmailVerified);
        //        if (logObj == 1)
        //        {
        //            Response.Redirect("loginStudent.aspx");
        //        }
        //    }
        //    else
        //    {
        //        validateValification.Text = "Wrong Code";
        //        validateValification.Visible = true;
        //    }
        //}

        protected byte[] encryptData(string data)
        {
            byte[] cipherText = null;
            try
            {
                RijndaelManaged cipher = new RijndaelManaged();
                cipher.IV = IV;
                cipher.Key = Key;
                ICryptoTransform encryptTransform = cipher.CreateEncryptor();
                //ICryptoTransform decryptTransform = cipher.CreateDecryptor();
                byte[] plainText = Encoding.UTF8.GetBytes(data);
                cipherText = encryptTransform.TransformFinalBlock(plainText, 0,
               plainText.Length);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { }
            return cipherText;
        }
    }
}