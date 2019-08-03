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

        string sessionid;
        string strSessionId;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
            Session["AdminNo"] = null;
            Session["role"] = null;


            //store session id in cookie
            sessionid = HttpContext.Current.Session.SessionID;
            Response.Cookies.Add(new HttpCookie("sessionidcookie", sessionid));
            //rmbrMeCookie.Value = sessionid.ToString();


            if (!IsPostBack)
            {
                //if value of cookie is available
                if(Request.Cookies["val1"] !=null && Request.Cookies["val2"] != null)
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
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string EncodedResponse = Request.Form["g-Recaptcha-Response"];
            bool IsCaptchaValid = (ReCaptchaClass.Validate(EncodedResponse) == "true" ? true : false);
            
            tbLogin.Text.ToUpper();
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
                stuObj = stuDao.getStudentById(tbLogin.Text, tbPassword.Text);
                 
                if (stuObj == null)
                {
                    lblErrorMessage.Visible = true;
                    //Response.Cookies["val1"].Value = string.Empty;
                    //Response.Cookies["val2"].Value = string.Empty;
                    
                    
                }
                
                else
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

                    Session["AdminNo"] = stuObj.AdminNo.Trim();
                    Session["role"] = stuObj.Year;

                    //creates a new guid every login & saves into session
                    string guid = Guid.NewGuid().ToString();
                    Session["AuthToken"] = guid;

                    //creates cookie with the guid value
                    Response.Cookies.Add(new HttpCookie("AuthToken", guid));


                    Response.Redirect("TripDetails.aspx");
                    string roleformasterpage = Session["role"].ToString();
                }
            }
        }
     }
}