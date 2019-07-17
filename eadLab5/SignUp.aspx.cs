using eadLab5.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace eadLab5
{
    public partial class SignUp : System.Web.UI.Page
    {
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
                if (string.IsNullOrEmpty(tbAdminNo.Text)){
                    validateAdminNo.Text = "Admin Number is required!";
                    validateAdminNo.Visible = true; }
                if (string.IsNullOrEmpty(tbAdminNo.Text) == false && tbAdminNo.Text.Length == 7)
                {
                    Regex regex = new Regex(@"[0-9][0-9][0-9][0-9][0-9][0-9]A-Z");
                    if (regex.Match(tbAdminNo.Text).Success)
                    {

                    }
                    else
                    {
                        validateAdminNo.Text = "Invalid Admin Number!";
                        validateAdminNo.Visible = true;
                    }
                }
                if (string.IsNullOrEmpty(tbPw.Text)){
                    validatePw.Text = "Password is required!";
                    validatePw.Visible = true; }
                if (string.IsNullOrEmpty(tbCfmpw.Text)){
                    validateCfmPw.Text = "Confirm Password is required";
                    validateCfmPw.Visible = true; }
                if (tbPw.Text != tbCfmpw.Text)
                {
                    validateCfmPw.Text = "Password not the same";
                    validateCfmPw.Visible = true;
                }
                if (string.IsNullOrEmpty(tbEmailAdd.Text)){
                    validateEmail.Text = "Email Address is required!";
                    validateEmail.Visible = true; }
                if(string.IsNullOrEmpty(tbEmailAdd.Text) == false)
                {
                    Regex email = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                    if (email.Match(tbEmailAdd.Text).Success) { }
                    else
                    {
                        validateEmail.Text = "Invalid Email Address";
                        validateEmail.Visible = true;
                    }
                    
                }
                if(string.IsNullOrEmpty(tbPhone.Text)){
                    validatePhoneNo.Text = "Phone Number is required!";
                    validatePhoneNo.Visible = true; }
                if(string.IsNullOrEmpty(tbPhone.Text) == false)
                {
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
            }
            else
            {
                StudentDAO logDao = new StudentDAO();
                int logObj = logDao.InsertTD(tbAdminNo.Text, tbPw.Text, tbPw.Text, tbPhone.Text);

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