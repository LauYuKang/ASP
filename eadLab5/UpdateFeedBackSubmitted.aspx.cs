using eadLab5.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eadLab5
{
    public partial class UpdateFeedBackSubmitted : System.Web.UI.Page
    {
        string str = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FeedbackForm cusObj = new FeedbackForm();
                FeedbackFormDAO cusDao = new FeedbackFormDAO();
                str = Convert.ToString(Session["FeedBackIdStudentUpdate"].ToString());
                cusObj = cusDao.GetSpecificFeedBack(str);
                if (cusObj != null)
                {
                    EnjoymentDropDownUpdate.Text = cusObj.Enjoyment.ToString();
                    AffordabilityDropDownUpdate.Text = cusObj.Affordability.ToString();
                    FreedomDropBoxUpdate.Text = cusObj.Freedom.ToString();
                    CountryLabel.Text = cusObj.Country;
                    DownsidesTbUpdate.Text = cusObj.ReviewCons;
                    HighlightTbUpdate.Text = cusObj.ReviewPros;
                    ImprovementTbUpdate.Text = cusObj.ReviewImprovement;
                }
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            FeedbackForm cusObj = new FeedbackForm();
            FeedbackFormDAO cusDao = new FeedbackFormDAO();
            str = Convert.ToString(Session["FeedBackIdStudentUpdate"].ToString());
            cusObj = cusDao.GetSpecificFeedBack(str);

            String Affordability = AffordabilityDropDownUpdate.SelectedValue.ToString();
            String Enjoyment = EnjoymentDropDownUpdate.SelectedValue.ToString();
            String Freedom = FreedomDropBoxUpdate.SelectedValue.ToString();
            String ReviewPros = HighlightTbUpdate.Text.ToString();
            String ReviewCons = DownsidesTbUpdate.Text.ToString();
            String ReviewImprovement = ImprovementTbUpdate.Text.ToString();

            FeedbackForm selTD = new FeedbackForm();
            FeedbackFormDAO updTD = new FeedbackFormDAO();
            int updCnt;

            updCnt = updTD.updateOwnFB(Affordability, Enjoyment, Freedom, ReviewPros, ReviewCons, ReviewImprovement, Session["FeedBackIdStudentUpdate"].ToString());

            if (updCnt == 1)
            {
                LblResult.Text = "Feedback Submitted! Thank you! You will be redirected in 5 seconds to the homepage!";
                Response.AddHeader("REFRESH", "5;URL=http://localhost:3355");
            }

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewFeedBackSubmitted.aspx");
        }
    }
}