using eadLab5.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eadLab5
{
    public partial class ChooseInterview : System.Web.UI.Page
    {
        protected List<Interview> intSessions;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Adminno"] == null)
            {
                Response.Redirect("./loginStudent.aspx");
            }
            else
            {
                string adminNo = Session["AdminNo"].ToString();
                InterviewDAO interviewDao = new InterviewDAO();
                intSessions = interviewDao.fetchSession(adminNo);
            }
        }
    }
}