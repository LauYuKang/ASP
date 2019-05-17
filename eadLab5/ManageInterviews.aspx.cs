using eadLab5.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using OpenTokSDK;

namespace eadLab5
{
    public partial class ManageInterviews : System.Web.UI.Page
    {
        protected List<Interview> interviewList = new List<Interview>();
        protected List<Interview> interviewedStudents = new List<Interview>();
        Interview interview = new Interview();
        InterviewDAO interviewDao = new InterviewDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["role"] == null)
            {
                Response.Redirect("Oops.aspx");
            }else if(Session["role"].ToString() != "Incharge")
            {
                Response.Redirect("Oops.aspx");
            }
            interviewList = interviewDao.retrieveInterview();
            interviewedStudents = interviewDao.fetchGridview();
            GridView1.DataSource = interviewedStudents;
            GridView1.DataBind();
        }

        [WebMethod]
        public static string emailStudent(string emailDate, string emailTime, string intId)
        {
            System.Diagnostics.Debug.WriteLine(emailDate + " this is tripId@@@ ");
            System.Diagnostics.Debug.WriteLine(emailTime + " this is adminNo@@@ ");
            InterviewDAO interviewDao = new InterviewDAO();
            interviewDao.insertDateTime(intId, emailDate, emailTime);
            string adminNo = interviewDao.exchangeIntIdForAdminNo(intId);
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "smtp-mail.outlook.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("eadpsarasa@outlook.com", "msJasmine1");
            //string recipient = adminNo + "@mymail.nyp.edu.sg";
            MailMessage mail = new MailMessage("eadpsarasa@outlook.com", "170313Q@mymail.nyp.edu.sg");
            mail.Subject = "You are scheduled for an interview!";
            mail.Body = "The interview will be on " + emailDate + ", " + emailTime;
            client.Send(mail);

            return emailDate + emailTime;
        }

        [WebMethod]
        public static string createSession(int intId)
        {
            int apiKey = 46243942;
            string apiSecret = "f12c7bc2592d9b613b3e2fadae2cbbf0bc32cb2d";
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            var OpenTok = new OpenTok(apiKey, apiSecret);
            var session = OpenTok.CreateSession();
            string sessionId = session.Id;
            string token = session.GenerateToken();
            InterviewDAO interviewDao = new InterviewDAO();
            interviewDao.createSession(sessionId, token, intId);

            return token + "__________" + sessionId;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int interviewNo = Convert.ToInt32(e.CommandArgument.ToString());
            Interview interview = interviewDao.fetchSingleInterview(interviewNo);
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "smtp-mail.outlook.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("eadpsarasa@outlook.com", "msJasmine1");
            MailMessage mail = new MailMessage("eadpsarasa@outlook.com", "170313Q@mymail.nyp.edu.sg");
            if (e.CommandName == "Approve")
            {
                mail.Subject = "You were approved for the trip";
                mail.Body = "Dear Peh Boon Wah,\nThis is regarding the trip you sign up for: " + interview.tripName + "\nTo confirm your request, login and go to http://eadlab520190123024847.azurewebsites.net/chooseOffer.aspx?tripId="+interview.tripid+"\nYours sincerely,\n"+interview.staffName;
                client.Send(mail);
                int result = interviewDao.updateStatusStudent("Approve", interviewNo);
                Response.Redirect("ManageInterviews.aspx");
            }
            else if(e.CommandName == "Reject")
            {
                mail.Subject = "You were rejected for the trip";
                mail.Body = "Dear Peh Boon Wah,\nThis is regarding the trip you sign up for: " + interview.tripName + "\nUnfortunately, you were rejected for the trip after the interview.\nYours sincerely,\n"+interview.staffName;
                client.Send(mail);
                int result = interviewDao.updateStatusStudent("Reject", interviewNo);
                Response.Redirect("ManageInterviews.aspx");
            }
            else
            {
                return;
            }
        }
    }
}