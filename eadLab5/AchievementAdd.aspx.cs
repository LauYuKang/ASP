using eadLab5.DAL;
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
    public partial class AchievementAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbAdminNo.Text = Session["AdminNo"].ToString();
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbAchievementName.Text) || string.IsNullOrEmpty(TbAyearTaken.Text))
            {
                LblResult.Text = "pls fill in all the blank";
            }
            else
            {
                String Status = "active";
                String AdminNo = lbAdminNo.Text.ToString();
                String AchievementName = TbAchievementName.Text.ToString();
                int AyearTaken = Convert.ToInt32(TbAyearTaken.Text.ToString());
                AchievementDAO fmTd = new AchievementDAO();
                int insCnt = fmTd.InsertTD(AchievementName, AyearTaken, AdminNo, Status);
                if (insCnt == 1)
                {
                    LblResult.Text = "Achievement Created!";
                    Response.Redirect("AchievementPage.aspx");
                }
                else
                {
                    LblResult.Text = "Unable to insert Achievement, please inform system administrator!";

                }
                BtnConfirm.Enabled = false;
            }
            // complete the code
            /*
            try
            {
                int tdRenewMode = Convert.ToInt16(DdlRenew.SelectedValue);
                timeDepositDAO fmTd = new timeDepositDAO();
                int insCnt = fmTd.InsertTD(tdAccount, tdCustId, tdPrincipal, tdTerm, tdIntRte, tdMaturityDte, tdMaturedAmt, tdInterest, tdRenewMode);
                if (insCnt == 1)
                {
                    LblResult.Text = "Time Deposit Created!";
                }
                else
                {
                    LblResult.Text = "Unable to insert time deposit, please inform system administrator!";

                }
                BtnConfirm.Enabled = false;

            }
            catch (FormatException)
            {
                LblResult.Text = "Select a renewal option!";
            }
            */
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AchievementPage.aspx");
        }
    }
}