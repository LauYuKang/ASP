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
    public partial class EventPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LblAdminNo.Text = Session["AdminNo"].ToString();
            String adminNo = LblAdminNo.Text.ToString();
            EventDAO tdDAO = new EventDAO();
            List<Event> tdList = new List<Event>();
            tdList = tdDAO.getCurrentEvent(LblAdminNo.Text);
            GridView_Event.DataSource = tdList;
            GridView_Event.DataBind();
            LblAdminNo.Visible = false;
        }

        protected void BtnAdd(object sender, EventArgs e)
        {
            Response.Redirect("EventAdd.aspx");
        }

        protected void gv_Students_RowCommand(object sender, GridViewCommandEventArgs e)

        {
            Event selTD = new Event();
            EventDAO tdDAO = new EventDAO();
            int updCnt;
            String Status = "delete";
            int EventID = Convert.ToInt32(e.CommandArgument.ToString());
            if (e.CommandName == "Delete")
            {
                updCnt = tdDAO.delete(EventID, Status);
                if (updCnt == 1)
                {
                    Response.Redirect("EventPage.aspx");
                }
            }

            else if (e.CommandName == "Edit")

            {
                Session["SSEventID"] = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect("EditEvent.aspx");
            }

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("GeneralSetting.aspx");
        }
    }
}