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
    public partial class WaitingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand("select * from WaitingList wl inner join Student s on s.AdminNo = wl.AdminNo", myConn);
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            DataTable WT = new DataTable();
            da.Fill(WT);
            GvWaitingList.DataSource = WT;
            GvWaitingList.DataBind();
        }
    }
}