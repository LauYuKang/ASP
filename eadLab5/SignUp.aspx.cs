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

namespace eadLab5
{
    public partial class SignUp : System.Web.UI.Page
    {
        static string finalHash;
        static string salt;
        protected void Page_Load(object sender, EventArgs e)
        {
            validateAdminNo.Visible = false;
            validatePw.Visible = false;
            validateCfmPw.Visible = false;
            validateEmail.Visible = false;
            validatePhoneNo.Visible = false;

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(tbAdminNo.Text) || string.IsNullOrEmpty(tbPw.Text) || string.IsNullOrEmpty(tbCfmpw.Text) || string.IsNullOrEmpty(tbEmailAdd.Text) || string.IsNullOrEmpty(tbPhone.Text))
            {
                if (string.IsNullOrEmpty(tbAdminNo.Text)) {
                    validateAdminNo.Text = "Admin Number is required!";
                    validateAdminNo.Visible = true; }
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
                if (string.IsNullOrEmpty(tbAdminNo.Text) == false && string.IsNullOrEmpty(tbPw.Text) == false && string.IsNullOrEmpty(tbCfmpw.Text) == false && string.IsNullOrEmpty(tbEmailAdd.Text) == false && string.IsNullOrEmpty(tbPhone.Text) == false)
                {
                    if (tbAdminNo.Text.Length < 7)
                    {
                        validateAdminNo.Text = "Invalid Admin Number!";
                        validateAdminNo.Visible = true;
                    }

                    Regex regex = new Regex(@"[0-9][0-9][0-9][0-9][0-9][0-9][A-Z]");
                    if (regex.Match(tbAdminNo.Text).Success){ }
                    else
                    {
                        validateAdminNo.Text = "Invalid Admin Number!";
                        validateAdminNo.Visible = true;
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
                if (validateAdminNo.Visible || validatePw.Visible || validateCfmPw.Visible || validateEmail.Visible || validatePhoneNo.Visible) { }
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


                    StudentDAO logDao = new StudentDAO();
                    int logObj = logDao.InsertTD(tbAdminNo.Text, finalHash, tbEmailAdd.Text, tbPhone.Text, salt);

                    validatePhoneNo.Visible = true;
                    if (logObj == 1)
                    {
                        LblResult.Text = "Account Created!";
                        LblResult.ForeColor = System.Drawing.Color.Green;
                        Response.Redirect("loginStudent.aspx");
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
}