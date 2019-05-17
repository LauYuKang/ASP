using eadLab5.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eadLab5
{
    public partial class loginStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
            Session["Staffid"] = null;
            Session["role"] = null;
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
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
                StaffLogin logObj = new StaffLogin();
                StaffLoginDAO logDao = new StaffLoginDAO();
                logObj = logDao.getStaffById(tbLogin.Text, tbPassword.Text);

                if (logObj == null)
                {
                    lblErrorMessage.Visible = true;
                }
                else
                {
                    Session["Staffid"] = logObj.Staffid;
                    Session["role"] = logObj.Role;
                    Response.Redirect("TripDetails.aspx");
                    
                }
            }
        }
    }
}
