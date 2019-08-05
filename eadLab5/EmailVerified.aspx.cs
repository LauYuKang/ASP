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

        protected void Page_Load(object sender, EventArgs e)
        {
            string adminNo = Session["AdminNo"].ToString();
            string email = Session["Email"].ToString();

            if (!IsPostBack)
            {
                Session["code"] = null;
            }

        }


        protected void btn_sendCodeClick(object sender, EventArgs e)
        {
            string adminNo = Session["AdminNo"].ToString();
            string email = Session["Email"].ToString();
            StudentDAO logDao = new StudentDAO();
            ////int logObj = logDao.updateVerifiedTime(adminNo);
            //if (logObj == 1)
            //{
            btn_sendCode.Text = "Resend";
            Random r = new Random();
            rInt = r.Next(10000, 99999);
            SendPasswordResetEmail(email, adminNo, rInt);
            lblError.Visible = true;
            lblError.Text = "Code Sent";
            Session["code"] = rInt;
            //}
            //else
            //{
            //    lblError.Visible = true;
            //    lblError.Text = "Code send failed";
            //}
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
                string adminNo = Session["AdminNo"].ToString();
                string emailverified = "T";
                //if (newcompare > 5)
                //{
                //    lblError.Text = "Code Expired";
                //}
                //else
                //{
                StudentDAO obj = new StudentDAO();
                string emailcode = Session["code"].ToString();
                string code = tbCode.Text.ToString();
                if (emailcode == code)
                {
                    int check = obj.updateVerified(adminNo, emailverified);
                    if (check == 1) {
                        ScriptManager.RegisterStartupScript(this, this.GetType(),"alert","alert('Email Verified sucessfully');window.location ='loginStudent.aspx';",true);
                        //Response.Redirect("loginStudent.aspx");
                    }
                    else
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "Verification Failed";
                    }

                }
                else
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Wrong code" ;
                }
                //}
            }
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