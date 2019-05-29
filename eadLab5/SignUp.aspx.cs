using eadLab5.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                if (string.IsNullOrEmpty(tbAdminNo.Text))
                { validateAdminNo.Visible = true; }
                if (string.IsNullOrEmpty(tbPw.Text))
                { validatePw.Visible = true; }
                if (string.IsNullOrEmpty(tbCfmpw.Text))
                { validateCfmPw.Visible = true; }
                if (string.IsNullOrEmpty(tbEmailAdd.Text))
                { validateEmail.Visible = true; }
                if (string.IsNullOrEmpty(tbPhone.Text))
                { validatePhoneNo.Visible = true; }
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