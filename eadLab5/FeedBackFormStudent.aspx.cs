using eadLab5.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eadLab5
{
    public partial class FeedBackFormStudent : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FeedbackForm cusObj = new FeedbackForm();
                FeedbackFormDAO cusDao = new FeedbackFormDAO();
                string str = Convert.ToString(Session["FeedBackActive"].ToString());
                string AdminNumber = Convert.ToString(Session["AdminNo"].ToString());
                cusObj = cusDao.GetFeedbackSelected(str, AdminNumber);
                if (cusObj != null)
                {
                    CountryLabel.Text = cusObj.location;
                }
            }
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {

            FeedbackForm cusObj = new FeedbackForm();
            FeedbackFormDAO cusDao = new FeedbackFormDAO();
            string str = Session["FeedBackActive"].ToString();
            string AdminNumber = Session["AdminNo"].ToString();
            cusObj = cusDao.GetFeedbackSelected(str, AdminNumber);


            String Affordability = AffordabilityDropDown.SelectedValue.ToString();
            String Enjoyment = EnjoymentDropDown.SelectedValue.ToString();
            String Freedom = FreedomDropBox.SelectedValue.ToString();
            String ReviewPros = HighlightTb.Text.ToString();
            String ReviewCons = DownsidesTb.Text.ToString();
            String ReviewImprovement = ImprovementTb.Text.ToString();
            int TripId = int.Parse(Session["FeedBackActive"].ToString());
            String StudName = cusObj.StudentName;
            String AdminNo = Session["AdminNo"].ToString();
            String Country = cusObj.location;
            DateTime DateCreated = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));

            try
            {

                FeedbackFormDAO FBF = new FeedbackFormDAO();
                int insCnt = FBF.InsertTD(Affordability, Enjoyment, Freedom, ReviewPros, ReviewCons, ReviewCons, StudName, Country, AdminNo, TripId, DateCreated);
                if (insCnt == 1)
                {
                    LblResult.Text = "Feedback Submitted! Thank you! You will be redirected in 5 seconds to the homepage!";
                    int UpdCnt = FBF.updateFeedBackDone(AdminNo, TripId);
                    Response.AddHeader("REFRESH", "5;URL=http://localhost:3355");
                }
                else
                {
                    LblResult.Text = "Unable to submit feedback, please inform system administrator!";

                }
                BtnConfirm.Enabled = false;

            }
            catch (FormatException)
            {

            }

        }
    }
}