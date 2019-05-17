using eadLab5.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eadLab5
{
    public partial class loginStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
            Session["AdminNo"] = null;
            Session["role"] = null;
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
                    Session["AdminNo"] = stuObj.AdminNo;
                    Session["role"] = stuObj.Year;
                    Response.Redirect("TripDetails.aspx");
                    string roleformasterpage = Session["role"].ToString();
                }
            }
        }
     }
}