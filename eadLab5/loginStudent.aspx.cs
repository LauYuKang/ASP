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
                }
                else
                {
                    Session["AdminNo"] = stuObj.AdminNo;
                    Session["role"] = stuObj.Year;

                    Audit newAudit = new Audit();
                    AuditDAO newAuditDAO = new AuditDAO();
                    String currentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    String AdminNo = stuObj.AdminNo;
                    String ipaddr = newAudit.GetIPAddress();
                    newAuditDAO.InsertAudit("STUDENT LOGIN SUCCESS", currentDateTime, "NIL", AdminNo, ipaddr, "NIL", -1, isBanned);

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