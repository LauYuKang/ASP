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

                StudentDAO studentDao = new StudentDAO();
                List<DAL.Student> allStu = studentDao.getAllstudent();
                string isBanned = "F";
                if (stuObj == null)
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
                            if (compareAuditIP == useripaddr && currentAudit.ActionType == "STUDENT LOGIN FAIL" && todayDate.Substring(0,10) == currentAudit.ActionDate.Substring(0,10))
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
                    String AdminNo = tbLogin.Text;
                    String ipaddr = newAudit.GetIPAddress();
                    newAuditDAO.InsertAudit("STUDENT LOGIN FAIL", currentDateTime,"NIL", AdminNo, ipaddr, "NIL", -1, isBanned);

                    if (isBanned == "T")
                    {
                        Response.Redirect("Oops.aspx");
                    }


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

                    Audit newAudit = new Audit();
                    AuditDAO newAuditDAO = new AuditDAO();
                    String currentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    String AdminNo = stuObj.AdminNo;
                    String ipaddr = newAudit.GetIPAddress();
                    newAuditDAO.InsertAudit("STUDENT LOGIN SUCCESS", currentDateTime, "NIL", AdminNo, ipaddr, "NIL", -1, isBanned);


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



        protected void btnSignUp_click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }
    }
}