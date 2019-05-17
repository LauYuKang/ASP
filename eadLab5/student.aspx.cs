using eadLab5.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eadLab5
{
    public partial class Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminNo"] == null)
            {
                Response.Redirect("loginStudent.aspx");
            }
            else
            {
                Lbl_Address.Visible = true;
                TripDAO Trip1 = new TripDAO();
                TripRepeater.DataSource = Trip1.getAllTrip();
                TripRepeater.DataBind();
            }
            
        }
        
    }
}