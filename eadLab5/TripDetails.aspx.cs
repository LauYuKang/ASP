using eadLab5.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eadLab5
{
    public partial class TripDetails : System.Web.UI.Page
    {
        protected string role = null;
        protected int count = 0;
        protected List<Trip> tripObj = null;
        protected string tripType = null;
        public static string adminNo = null;
        protected List<int> listId = null;
        TripDAO tripDao = new TripDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] != null)
            {
                role = Session["role"].ToString();
                if(role == "Incharge" || role == "Teacher")
                {
                    adminNo = null;
                }
                else if (role == "1" || role == "2" || role == "3")
                    adminNo = Session["AdminNo"].ToString();
            }
            if (!IsPostBack)
            {
                tripType = Request.QueryString["tripType"];
                tripObj = tripDao.getTrip(tripType);
                count = tripDao.count;
                listId = tripDao.getSignedUpTrip(adminNo);
                foreach (var i in listId)
                {
                    System.Diagnostics.Debug.Write(i + "_");
                }
                List<String> countryList = tripDao.getCountry();
                ddlAddLocation.DataSource = countryList;
                ddlAddLocation.DataBind();
                ddlAddLocation.Items.Insert(0, new ListItem("--Select--", "-1"));
                if (role == "")
                {
                    System.Diagnostics.Debug.WriteLine("its empty");
                }
                else if (role == null)
                {
                    System.Diagnostics.Debug.WriteLine("its null");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(role);
                }
            }
        }

        [WebMethod]
        public static string assignStudent(string tripId)
        {
            System.Diagnostics.Debug.WriteLine(tripId + " this is tripId@@@ ");
            System.Diagnostics.Debug.WriteLine(adminNo + " this is adminNo@@@ ");
            TripDAO addStudDao = new TripDAO();
            addStudDao.assignStudentToTrip(Convert.ToInt32(tripId), adminNo);
            System.Diagnostics.Debug.WriteLine("its in");

            return tripId;
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
        protected void addTrip(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                TripDAO addTD = new DAL.TripDAO();
                if (tripImageUpload.HasFile)
                {
                    string addLocation = ddlAddLocation.SelectedItem.Text;
                    string addTitle = tbAddTitle.Text;
                    DateTime addStart = Convert.ToDateTime(tbAddStart.Text);
                    DateTime addEnd = Convert.ToDateTime(tbAddEnd.Text);
                    DateTime addOpen = Convert.ToDateTime(tbOpenDay.Text);
                    string addActivities = tbAddActivities.Text;
                    double cost = Convert.ToInt16(tbAddCost.Text);
                    string addType = DdlAddTripType.SelectedItem.Text;
                    HttpFileCollection uploadedFiles = Request.Files;
                    string[] images = new string[3];
                    int staffId = Convert.ToInt32(Session["StaffId"]);
                    for (int i = 0; i < uploadedFiles.Count; i++)
                    {
                        HttpPostedFile userPostedFile = uploadedFiles[i];
                        images[i] = SaveFile(userPostedFile);
                        System.Diagnostics.Debug.WriteLine(images[i]);
                    }
                    if (uploadedFiles.Count == 1)
                    {
                        images[1] = "NULL";
                        images[2] = "NULL";
                    }
                    else if (uploadedFiles.Count == 2)
                    {
                        images[2] = "NULL";
                    }
                    int results = addTD.insertTrip(addLocation, images[0], addTitle, addStart, addEnd, addOpen, addActivities, cost, addType, images[1], images[2], staffId);

                    Response.Redirect("TripDetails.aspx");
                }
                else
                {
                    //add validations? later la
                }
            }
        }
    }
}