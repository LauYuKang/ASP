using eadLab5.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace eadLab5
{
    public partial class EditTripDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                TripDAO tripDao = new TripDAO();
                List<String> countryList = tripDao.getCountry();
                ddlUpdateLocation.DataSource = countryList;
                ddlUpdateLocation.DataBind();
                ddlUpdateLocation.Items.Insert(0, new ListItem("--Select--", "-1"));
                int tripId = Convert.ToInt32(Request.QueryString["tripId"]);
                Trip tripObj = tripDao.getTripById(tripId);
                if (tripObj == null)
                {
                    Response.Redirect("Oops.aspx");
                }else if (Session["role"].ToString() != "Incharge")
                {
                    Response.Redirect("Oops.aspx");
                }
                else
                {
                    tbUpdateTitle.Text = tripObj.tripTitle.ToString();
                    ddlUpdateLocation.SelectedValue = tripObj.tripLocation.ToString();
                    tripImage.ImageUrl = tripObj.tripImg.ToString();
                    tbUpdateStart.Text = tripObj.tripStart.ToString("yyyy-MM-dd");
                    tbUpdateEnd.Text = tripObj.tripEnd.ToString("yyyy-MM-dd");
                    tbUpdateOpeningday.Text = tripObj.tripOpen.ToString("yyyy-MM-dd");
                    tbUpdateActivities.Text = tripObj.tripActivities;
                    tbUpdateCost.Text = tripObj.tripCost.ToString();
                    DdlUpdateType.SelectedValue = tripObj.tripType.ToString();
                }
            }
        }

        protected void AllowEdit(object sender, EventArgs e)
        {
            tbUpdateActivities.ReadOnly = false;
            tbUpdateCost.ReadOnly = false;
            tbUpdateOpeningday.ReadOnly = false;
            tbUpdateStart.ReadOnly = false;
            tbUpdateEnd.ReadOnly = false;
            tbUpdateTitle.ReadOnly = false;
            UpdateBtn.Enabled = true;
            CancelBtn.Enabled = true;
            DelTrip.Enabled = true;
            ddlUpdateLocation.Enabled = true;
            tripUploadImg.Enabled = true;
            DdlUpdateType.Enabled = true;
        }

        string SaveFile(HttpPostedFile file)
        {
            string savePath = "../Images/";
            //string filename = file.FileName + DateTime.Now.ToString("ddmmyyyyfffffff");
            string filename = Path.GetFileNameWithoutExtension(file.FileName);
            string ext = Path.GetExtension(file.FileName);
            savePath += filename + DateTime.Now.ToString("ddmmyyyyfffffff") + ext;
            string fullPath = Path.Combine(Server.MapPath("~/Images"), savePath);
            file.SaveAs(fullPath);
            return savePath;
        }

        protected void UpdateTrip(object sender, EventArgs e)
        {
            TripDAO updTd = new TripDAO();
            int tripId = Convert.ToInt32(Request.QueryString["tripId"]);
            System.Diagnostics.Debug.WriteLine(tripId + "this is id");
            string tripTitle = tbUpdateTitle.Text;
            string tripLocation = ddlUpdateLocation.SelectedValue;
            string tripImgName = SaveFile(tripUploadImg.PostedFile);
            System.Diagnostics.Debug.WriteLine(tripTitle + "this is title");
            DateTime tripStart = Convert.ToDateTime(tbUpdateStart.Text);
            //LOOK AT THIS SHIT, TRIPSTART WORKS BUT END DOESNT
            System.Diagnostics.Debug.WriteLine(tbUpdateStart.Text);
            DateTime tripEnd = Convert.ToDateTime(tbUpdateEnd.Text);
            System.Diagnostics.Debug.WriteLine(tripEnd);
            DateTime tripOpeningDay = Convert.ToDateTime(tbUpdateOpeningday.Text);
            string tripActivities = tbUpdateActivities.Text;
            double tripCost = Convert.ToInt16(tbUpdateCost.Text);
            System.Diagnostics.Debug.WriteLine(tbUpdateCost.Text + "This is cost");
            string tripType = DdlUpdateType.SelectedValue;
            int results = updTd.updateTrip(tripId, tripTitle, tripLocation, tripImgName, tripStart, tripEnd, tripOpeningDay, tripActivities, tripCost, tripType);
            Response.Redirect("TripDetails.aspx");
        }

        protected void DelTrip_Click(object sender, EventArgs e)
        {
            TripDAO delTD = new DAL.TripDAO();
            int tripId = Convert.ToInt32(Request.QueryString["tripId"]);
            int results = delTD.delTrip(tripId);
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "smtp-mail.outlook.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("eadpsarasa@outlook.com", "msJasmine1");
            Trip tripObj = delTD.getTripById(tripId);
            MailMessage mail = new MailMessage("eadpsarasa@outlook.com", "170313Q@mymail.nyp.edu.sg");
            mail.Subject = "Trip cancelled";
            mail.Body = "This is regarding the trip you sign up for: "+tripObj.tripTitle+"\nReason for cancel: "+tbReason.Text;
            client.Send(mail);

            const string accountSid = "AC90e3e868134c6a071114c494857cea63";
            const string authToken = "25c2aa080ca442ffb5701fe61b6a7af7";
            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "This is regarding the trip "+tripObj.tripTitle+" you had signed up for. The trip has been cancelled due to : "+tbReason.Text,
                from: "(717) 429-0744",
                to: "+65 91783904"
                );

            Response.Redirect("TripDetails.aspx");
        }
    }
}