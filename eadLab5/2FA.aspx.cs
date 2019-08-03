using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twilio.Rest.Api.V2010.Account;
using System.Net;
using System.Data.SqlClient;

namespace eadLab5
{
    public partial class _2FA : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButtonEnable2FA_Click(object sender, EventArgs e)
        {
            Response.Redirect("Enable2FA.aspx");
        }

        protected void ButtonDisable2FA_Click(object sender, EventArgs e)
        {
            Response.Redirect("Disable2FA.aspx");
        }
    }
}