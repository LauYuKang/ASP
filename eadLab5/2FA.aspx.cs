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
        string MYDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        string af = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string userid = Session["adminNo"].ToString();
            string af = get2FA(userid);
            if (af == "1")
            {
                ButtonEnable2FA.Visible = false;
            }
            else if( af =="0")
            {
                ButtonDisable2FA.Visible = false;
            }
            else
            {

            }
        }

        protected string get2FA(string userid)
        {
            string s = null;
            SqlConnection connection = new SqlConnection(MYDBConnectionString);
            string sql = "select FA FROM [Student] WHERE AdminNo=@USERID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@USERID", userid);
            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["FA"] != null)
                        {
                            if (reader["FA"] != DBNull.Value)
                            {
                                s = reader["FA"].ToString();
                                af = s;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { connection.Close(); }
            return s;
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