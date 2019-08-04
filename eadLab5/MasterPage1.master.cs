using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eadLab5
{
    public partial class MasterPage1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if ((!(Session["role"]).Equals(null)) && (!(Session["role"]).Equals(""))){ 
            //string roleformasterpage = Session["role"].ToString();
         //}
        }

        protected void LogOutUser(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();

            Response.Redirect("SignUp.aspx", false);

            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
                
            }
            
            if (Request.Cookies["sessionidcookie"] != null)
            {
                Response.Cookies["sessionidcookie"].Value = string.Empty;
                Response.Cookies["sessionidcookie"].Expires = DateTime.Now.AddMonths(-20);

            }

            if (Request.Cookies["staffsessionidcookie"] != null)
            {
                Response.Cookies["staffsessionidcookie"].Value = string.Empty;
                Response.Cookies["staffsessionidcookie"].Expires = DateTime.Now.AddMonths(-20);

            }

            if (Request.Cookies["AuthToken"] != null)
            {
                Response.Cookies["AuthToken"].Value = string.Empty;
                Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);
            }
        }

        protected void LogOutStaff(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();

            Response.Redirect("SignUp.aspx", false);

            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);

            }

            if (Request.Cookies["sessionidcookie"] != null)
            {
                Response.Cookies["sessionidcookie"].Value = string.Empty;
                Response.Cookies["sessionidcookie"].Expires = DateTime.Now.AddMonths(-20);

            }

            if (Request.Cookies["staffsessionidcookie"] != null)
            {
                Response.Cookies["staffsessionidcookie"].Value = string.Empty;
                Response.Cookies["staffsessionidcookie"].Expires = DateTime.Now.AddMonths(-20);

            }

            if (Request.Cookies["AuthToken"] != null)
            {
                Response.Cookies["AuthToken"].Value = string.Empty;
                Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);
            }
        }

        
    }
}
