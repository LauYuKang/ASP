using eadLab5.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eadLab5
{
    public partial class PEMMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Staffid"] == null)
            {
                Response.Redirect("loginStaff.aspx");
            }
            else {StudentDAO stuObj = new StudentDAO();
            TripDAO Trip1 = new TripDAO();
            StudentRepeater.DataSource = stuObj.getAllstudent();
            StudentRepeater.DataBind();
            TripRepeater.DataSource = Trip1.getAllTrip();
            TripRepeater.DataBind(); }
            

        }
    }
}