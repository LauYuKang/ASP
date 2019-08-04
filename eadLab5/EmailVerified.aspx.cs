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
using System.Net.Mail;

namespace eadLab5
{
    public partial class EmailVerified : System.Web.UI.Page
    {
        int rInt;
        string email;
        string adminNo;

        protected void Page_Load(object sender, EventArgs e)
        {
            adminNo = Session["AdminNo"].ToString();
            email = Session["Email"].ToString();
        }

        protected void btn_submitClick(object sender, EventArgs e)
        {
            StudentDAO logDao = new StudentDAO();
            //DateTime lastTime = logDao.getVerifiedTime(adminNo);
            //DateTime CurrentTime = DateTime.Now;
            //TimeSpan Compare = CurrentTime - lastTime;
            //int newcompare = Convert.ToInt32(Compare);
            if (string.IsNullOrEmpty(tbCode.Text))
            {
                
                validationCode.Visible = true;
            }
            else
            {
                //if (newcompare > 5)
                //{
                //    lblError.Text = "Code Expired";
                //}
                //else
                //{
                string emailcode = rInt.ToString();
                string code = tbCode.Text;
                if (emailcode == code)
                {
                    Response.Redirect("loginStudent.aspx");
                }
                else
                {
                    lblError.Text = "Wrong code";
                }
                //}
            }
        }

        protected void btn_sendCodeClick(object sender, EventArgs e)
        {
            StudentDAO logDao = new StudentDAO();
            ////int logObj = logDao.updateVerifiedTime(adminNo);
            //if (logObj == 1)
            //{
                btn_sendCode.Text = "Resend";
                Random r = new Random();
                rInt = r.Next(10000, 99999);
                SendPasswordResetEmail(email, adminNo, rInt);
                lblError.Visible = true;
                lblError.Text = "Code Sent, Code only valid for one minutes";
            //}
            //else
            //{
            //    lblError.Visible = true;
            //    lblError.Text = "Code send failed";
            //}
        }



        private void SendPasswordResetEmail(string ToEmail, string UserName, int r)
        {
            // MailMessage class is present is System.Net.Mail namespace
            MailMessage mailMessage = new MailMessage("ikaroswork1@gmail.com", ToEmail);


            // StringBuilder class is present in System.Text namespace
            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("Dear " + UserName + ",<br/><br/>");
            sbEmailBody.Append("Your code is " + rInt);
            sbEmailBody.Append("<br/><br/>");
            sbEmailBody.Append("<b>SARASA</b>");

            mailMessage.IsBodyHtml = true;

            mailMessage.Body = sbEmailBody.ToString();
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);


            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "ikaroswork1@gmail.com",
                Password = "1234321xX"
            };

            smtpClient.EnableSsl = true;
            try
            {
                smtpClient.Send(mailMessage);
                Page.RegisterStartupScript("UserMsg", "<script>alert('successful')</script>");
            }

            catch
            {
                Page.RegisterStartupScript("UserMsg", "<script>alert('fail')</script>");
            }
        }

    }
}