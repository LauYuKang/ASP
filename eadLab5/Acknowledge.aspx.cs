using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eadLab5
{
    public partial class Acknowledge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cusName = String.Empty;
            string cusEmail = String.Empty;
            if (string.IsNullOrEmpty(Request.QueryString["cname"]) && string.IsNullOrEmpty(Request.QueryString["cname"]))
            {
                lbAck.Text = "Sorry please provide your contact";
            }
            else
            {
                cusName = Request.QueryString["cname"];
                cusEmail = Request.QueryString["cemail"];

                StringBuilder ackMsg = new StringBuilder();

                ackMsg.AppendLine("Thank you for your enquiry");
                ackMsg.AppendLine(cusName);
                ackMsg.AppendLine(", we will contact you sooner to your email");
                ackMsg.AppendLine(cusEmail);
                ackMsg.AppendLine(".");
                lbAck.Text = ackMsg.ToString();
            }

        }
    }
}