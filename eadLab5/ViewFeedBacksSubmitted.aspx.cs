using eadLab5.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace eadLab5
{
    public partial class ViewFeedBacksSubmitted : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
            FeedbackFormDAO tdDAO = new FeedbackFormDAO();
            List<FeedbackForm> tdList = new List<FeedbackForm>();
            tdList = tdDAO.GetOwnFeedBack(Session["AdminNo"].ToString());
            GridView_GetOwnFB.DataSource = tdList;
            GridView_GetOwnFB.DataBind();
        }

        protected void GridView_GetOwnFB_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView_GetOwnFB.SelectedRow;
            // In this grid, the first cell (index 0) contains
            // the TD Account.
            Session["FeedBackIdStudentUpdate"] = row.Cells[0].Text;
            Response.Redirect("UpdateFeedBackSubmitted.aspx");
        }
    }
}