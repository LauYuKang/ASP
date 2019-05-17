using eadLab5.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eadLab5
{
    public partial class FeedBacks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FeedbackFormDAO tdDAO = new FeedbackFormDAO();
                List<FeedbackForm> tdList = new List<FeedbackForm>();
                string Studentid = Session["AdminNo"].ToString();
                tdList = tdDAO.GetAllFeedBackAvailable(Studentid);
                GridViewStudentFeedBack.DataSource = tdList;
                GridViewStudentFeedBack.DataBind();
            }
        }

        protected void GridViewStudentFeedBack_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridViewStudentFeedBack.SelectedRow;
            // In this grid, the first cell (index 0) contains
            // the TD Account.
            Session["FeedBackActive"] = (row.Cells[0].Text).ToString();
            Response.Redirect("FeedBackFormStudent.aspx");
        }
    }
}