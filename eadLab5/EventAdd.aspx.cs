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
    public partial class EventAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbAdminNo.Text = Session["AdminNo"].ToString();
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbEventName.Text) || string.IsNullOrEmpty(TbEyearTaken.Text) || string.IsNullOrEmpty(TbSEMTaken.Text))
            {
                LblResult.Text = "pls fill in all the blank";
            }
            else
            {
                //String Status = "active";
                String AdminNo = lbAdminNo.Text.ToString();
                String EventName = TbEventName.Text.ToString();
                String EyearTaken = TbEyearTaken.Text.ToString();
                String EsemTaken = TbSEMTaken.Text.ToString();
                EventDAO fmTd = new EventDAO();
                int insCnt = fmTd.InsertTD(EventName, EyearTaken, EsemTaken, AdminNo);
                if (insCnt == 1)
                {
                    LblResult.Text = "Event Added!";
                    Response.Redirect("EventPage.aspx");
                }
                else
                {
                    LblResult.Text = "Unable to insert Event, please inform system administrator!";

                }
                BtnConfirm.Enabled = false;
            }
        }

    }
}