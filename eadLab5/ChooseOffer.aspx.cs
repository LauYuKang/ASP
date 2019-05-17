using eadLab5.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace eadLab5
{
    public partial class ChooseOffer : System.Web.UI.Page
    {
        protected string tripName = null;
        protected string tripStart = null;
        protected string tripEnd = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            int tripId = Convert.ToInt32(Request.QueryString["tripId"]);
            Trip tripClass = new Trip();
            TripDAO tripObj = new TripDAO();
            if (Session["AdminNo"] == null)
            {
                Response.Redirect("loginStudent.aspx");
            }else
            {
                Choice choice = tripObj.checkOffer(Session["AdminNo"].ToString(),tripId);
                if(choice == null || choice.choice == "Accepted" || choice.choice =="Rejected")
                {
                    System.Diagnostics.Debug.WriteLine("its here");
                    Response.Redirect("Oops.aspx");
                }else if(choice.teacherChoice != "Approve")
                {
                    System.Diagnostics.Debug.WriteLine("its here2");
                    Response.Redirect("Oops.aspx");
                }
                tripName = choice.tripName;
                tripStart = choice.tripStart.ToString("dd/MM/yyyy");
                tripEnd = choice.tripEnd.ToString("dd/MM/yyyy");
            }

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Trip tripClass = new Trip();
            TripDAO tripObj = new TripDAO();
            tripObj.chooseOffer("Accepted",Session["AdminNo"].ToString());
            Response.Redirect("Tripdetails.aspx");
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            Trip tripClass = new Trip();
            TripDAO tripObj = new TripDAO();
            tripObj.chooseOffer("Rejected", Session["AdminNo"].ToString());
            Response.Redirect("Tripdetails.aspx");
        }
    }
}