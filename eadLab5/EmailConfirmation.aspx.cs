using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Threading.Tasks;

namespace eadLab5
{
    public partial class EmailConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        protected void TextBoxAdminNumber_TextChanged(object sender, EventArgs e)
        {

        }

        

        

        protected void BtnResetPassword_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["EADPConnectionString2"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                
                    SqlCommand cmd = new SqlCommand("spResetPassword6", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramUsername = new SqlParameter("@UserName", txtUserName.Text);
                    cmd.Parameters.Add(paramUsername);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                try
                {
                    while (rdr.Read())
                    {
                        if (Convert.ToBoolean(rdr["ReturnCode"]))
                        {
                            SendPasswordResetEmail(rdr["Email"].ToString(), txtUserName.Text, rdr["UniqueId"].ToString());
                            lblMessage.Text = "An email with instructions to reset your password is sent to your registered email";
                        }
                        else
                        {
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Text = "Username not found!";
                        }
                    }
                }
                catch (Exception)
                {
                    Page.RegisterStartupScript("UserMsg", "<script>alert('nop')</script>");
                }
            }
        }

        

        

        


        

        private void SendPasswordResetEmail(string ToEmail, string UserName, string UniqueId)
        {
            // MailMessage class is present is System.Net.Mail namespace
            MailMessage mailMessage = new MailMessage("ikaroswork1@gmail.com", ToEmail);


            // StringBuilder class is present in System.Text namespace
            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("Dear " + UserName + ",<br/><br/>");
            sbEmailBody.Append("Please click on the following link to reset your password");
            sbEmailBody.Append("<br/>"); sbEmailBody.Append("http://localhost:3355/ResetPass.aspx?uid=" + UniqueId);
            sbEmailBody.Append("<br/><br/>");
            sbEmailBody.Append("<b>SARASA</b>");

            mailMessage.IsBodyHtml = true;

            mailMessage.Body = sbEmailBody.ToString();
            mailMessage.Subject = "Reset Your Password";
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