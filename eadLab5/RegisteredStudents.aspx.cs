using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eadLab5
{
    public partial class RegisteredStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int tripId = Convert.ToInt32(Request.QueryString["tripId"]);
            System.Diagnostics.Debug.WriteLine(tripId + " this is trip id from registeredStudent");
        }
    }
}