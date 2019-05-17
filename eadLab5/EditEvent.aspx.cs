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
    public partial class EditEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["SSEventID"] != null)
                {
                    int EventID = Convert.ToInt32(Session["SSEventID"]);
                    LblEventID.Text = EventID.ToString();
                    Event selTD = new Event();
                    EventDAO updTD = new EventDAO();
                    selTD = updTD.getEventById(EventID);
                }
            }
        }

        protected void BtnUpdate(object sender, EventArgs e)
        {
            int EventID = Convert.ToInt32(Session["SSEventID"]);
            Event selTD = new Event();
            EventDAO updTD = new EventDAO();
            int updCnt;
            updCnt = updTD.Edit(EventID, TbEventName.Text, TbEyearTaken.Text, TbEsemTaken.Text);
            if (string.IsNullOrEmpty(TbEventName.Text) || string.IsNullOrEmpty(TbEyearTaken.Text) || string.IsNullOrEmpty(TbEsemTaken.Text) )
            {
                LblResult.Text = "pls fill in all the blank";
            }
            else
            {
                if (updCnt == 1)
                {
                    Response.Redirect("EventPage.aspx");
                }
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventPage.aspx");
        }
    }
}