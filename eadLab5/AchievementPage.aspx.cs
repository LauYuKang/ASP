using System;
using eadLab5.DAL;
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
    public partial class AchievementPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //LblAdminNo.Text = Session["SSAdminNo"].ToString();
            //String adminNo = LblAdminNo.Text.ToString();
            //string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            //SqlConnection myConn = new SqlConnection(DBConnect);
            //SqlCommand cmd1 = new SqlCommand("select * from Achievement where AdminNo = adminNo", myConn);
            //SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            //DataTable dt = new DataTable();
            //sda1.Fill(dt);
            //GridView_Achievement.DataSource = dt;
            //GridView_Achievement.DataBind();

            LblAdminNo.Text = Session["AdminNo"].ToString();
            String adminNo = LblAdminNo.Text.ToString();
            AchievementDAO tdDAO = new AchievementDAO();
            List<Achievement> tdList = new List<Achievement>();
            tdList = tdDAO.getAchievement(LblAdminNo.Text);
            GridView_Achievement.DataSource = tdList;
            GridView_Achievement.DataBind();
            LblAdminNo.Visible = false;
        }

        protected void gv_Students_RowCommand(object sender, GridViewCommandEventArgs e)

        {
            Achievement selTD = new Achievement();
            AchievementDAO updTD = new AchievementDAO();
            int updCnt;
            String Status = "delete";
            int AchievementId = Convert.ToInt32(e.CommandArgument.ToString());
            if (e.CommandName == "Delete")
            {
                updCnt = updTD.delete(AchievementId, LblAdminNo.Text, Status);
                if (updCnt == 1)
                {
                    Response.Redirect("AchievementPage.aspx");
                }
            }

            else if (e.CommandName == "Edit")

            {
                Session["SSAchievementId"] = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect("EditAchievement.aspx");
            }

        }


        protected void BtnAdd(object sender, EventArgs e)
        {
            Response.Redirect("AchievementAdd.aspx");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("GeneralSetting.aspx");
        }
    }
}