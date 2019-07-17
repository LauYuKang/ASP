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

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }
     }
}
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
            
            //creates a cookie upon page load
            HttpCookie rmbrMeCookie = new HttpCookie("rmbrMeCookie");
            //rmbrMeCookie["val1"] = tbLogin.Text;
            //rmbrMeCookie["val2"] = tbPassword.Text;

            if (!IsPostBack)
            {
                //if value of cookie is available
                if(Request.Cookies["val1"] !=null && Request.Cookies["val2"] != null)
                {
                    //tbLogin.Text = Request.Cookies["rmbrMeCookie"]["val1"];
                    tbLogin.Text = Request.Cookies["val1"].Value;
                    //tbPassword.Text = Request.Cookies["rmbrMeCookie"]["val2"];
                    tbPassword.Attributes["value"] = Request.Cookies["val2"].Value;
                }
            }
            //keep the checkbox checked if "remember me" was checked
            if (!IsPostBack)
            {
                if (Session["chkbox_rmbrMe"] != null)
                {
                    chkbox_rmbrMe.Checked = (bool)Session["chkbox_rmbrMe"];
                }
                
            }
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string EncodedResponse = Request.Form["g-Recaptcha-Response"];
            bool IsCaptchaValid = (ReCaptchaClass.Validate(EncodedResponse) == "true" ? true : false);
            
            tbLogin.Text.ToUpper();
            validateLogin.Visible = false;
            validatePassword.Visible = false;

            
            if (string.IsNullOrEmpty(tbLogin.Text) || string.IsNullOrEmpty(tbPassword.Text) || (!IsCaptchaValid))
            {
                if (string.IsNullOrEmpty(tbLogin.Text))
                { validateLogin.Visible = true; }
                if (string.IsNullOrEmpty(tbPassword.Text))
                { validatePassword.Visible = true; }
                if (!IsCaptchaValid)
                {
                    { validateCaptcha.Visible = true; }
                }
                
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
                    if (chkbox_rmbrMe.Checked)
                    {
                        
                        //creates a session state for checkbox
                        Session["chkbox_rmbrMe"] = chkbox_rmbrMe.Checked;
                        Response.Cookies["val1"].Value = tbLogin.Text;
                        Response.Cookies["val2"].Value = tbPassword.Text;
                    }
                    else
                    {
                        Session["chkbox_rmbrMe"] = null;
                        Response.Cookies["val1"].Expires = DateTime.Now.AddMinutes(-1);
                        Response.Cookies["val2"].Expires = DateTime.Now.AddMinutes(-1);
                    }

                    Session["AdminNo"] = stuObj.AdminNo;
                    Session["role"] = stuObj.Year;
                    Response.Redirect("TripDetails.aspx");
                    string roleformasterpage = Session["role"].ToString();
                }
            }
        }
     }
}