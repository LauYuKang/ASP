﻿using eadLab5.DAL;
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
            Session["Staffid"] = null;
            Session["role"] = null;
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string EncodedResponseStaff = Request.Form["g-Recaptcha-Response"];
            bool IsCaptchaValid = (ReCaptchaClass2.Validate(EncodedResponseStaff) == "true" ? true : false);

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
                StaffLogin logObj = new StaffLogin();
                StaffLoginDAO logDao = new StaffLoginDAO();
                logObj = logDao.getStaffById(tbLogin.Text, tbPassword.Text);

                Staff staffDao = new Staff();
                List<Staff> allStaff = staffDao.getAllstaff();
                String isBanned = "F";
                if (logObj == null)
                {
                    Audit newAudit = new Audit();
                    AuditDAO newAuditDAO = new AuditDAO();
                    List<Audit> auditList = newAuditDAO.getAllAudit();

                    int loginCount = 0;
                    Boolean isValidID = false;

                    // is the input a valid ID?
                    foreach (Staff currentStaff in allStaff)
                    {
                        if (tbLogin.Text == currentStaff.Email)
                        {
                            isValidID = true;
                        }
                    }

                    if (isValidID == true && auditList != null)
                    {
                        // this is the user ip address
                        String useripaddr = newAudit.GetIPAddress();
                        String todayDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        // loop all the audits
                        foreach (Audit currentAudit in auditList)
                        {
                            String compareAuditIP = currentAudit.IPAddress;
                            if (compareAuditIP == useripaddr && currentAudit.ActionType == "STAFF LOGIN FAIL" && todayDate.Substring(0, 10) == currentAudit.ActionDate.Substring(0, 10))
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
                    String staffID = tbLogin.Text;
                    String ipaddr = newAudit.GetIPAddress();
                    newAuditDAO.InsertAudit("STAFF LOGIN FAIL", currentDateTime, staffID, "NIL", ipaddr, "NIL", -1,isBanned);

                    if (isBanned == "T")
                    {
                        Response.Redirect("Oops.aspx");
                    }

                    lblErrorMessage.Visible = true;
                }
                else
                {
                    Session["Staffid"] = logObj.Staffid;
                    Session["role"] = logObj.Role;

                    Audit newAudit = new Audit();
                    AuditDAO newAuditDAO = new AuditDAO();
                    String currentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    String staffID = logObj.Staffid;
                    String ipaddr = newAudit.GetIPAddress();
                    newAuditDAO.InsertAudit("STAFF LOGIN SUCCESS", currentDateTime, staffID, "NIL", ipaddr, "NIL", -1,isBanned);

                    //creates a new guid every login & saves into session
                    string guid = Guid.NewGuid().ToString();
                    Session["AuthToken"] = guid;

                    //creates cookie with the guid value
                    Response.Cookies.Add(new HttpCookie("AuthToken", guid));

                    Response.Redirect("TripDetails.aspx");
                    
                }
            }
        }
    }
}
