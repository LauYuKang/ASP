using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eadLab5.DAL;

namespace eadLab5
{
    public partial class EditAchievement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["SSAchievementId"] != null)
                {
                    int AchievementId = Convert.ToInt32(Session["SSAchievementId"]);
                    LblAchievementId.Text = AchievementId.ToString();
                    Achievement selTD = new Achievement();
                    AchievementDAO updTD = new AchievementDAO();
                    selTD = updTD.getAchievementById(AchievementId);
                }
            }
        }

        protected void BtnUpdate(object sender, EventArgs e)
        {
            int AchievementId = Convert.ToInt32(Session["SSAchievementId"]);
            Achievement selTD = new Achievement();
            AchievementDAO updTD = new AchievementDAO();
            int AyearTaken = Convert.ToInt32(TbAyearTaken.Text.ToString());
            int updCnt;
            updCnt = updTD.Edit(AchievementId, TbAchievementName.Text, AyearTaken);
            if (string.IsNullOrEmpty(TbAchievementName.Text) || string.IsNullOrEmpty(TbAyearTaken.Text))
            {
                LblResult.Text = "pls fill in all the blank";
            }
            else
            {
                if (updCnt == 1)
                {
                    Response.Redirect("AchievementPage.aspx");
                }
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AchievementPage.aspx");
        }
    }
}