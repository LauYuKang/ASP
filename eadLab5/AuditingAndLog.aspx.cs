using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eadLab5
{
    public partial class AuditingAndLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void tb_date_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void btn_retrieve_Click(object sender, EventArgs e)
        {
            //EADP.FilterExpression = "CONVERT(VARCHAR, ActionDate) LIKE'" + tb_date.Text + "%'";
            //EADP.SelectCommand = "SELECT * FROM [AuditLog] WHERE CONVERT(VARCHAR(30), ActionDate) LIKE '" + tb_date.Text + "%'";
        }
    }
}