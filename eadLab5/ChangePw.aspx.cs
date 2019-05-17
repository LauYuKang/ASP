using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eadLab5.DAL;

namespace eadLab5
{
    public partial class ChangePw : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                if (Session["AdminNo"] != null)
                {
                    LblAdminNo.Text = Session["AdminNo"].ToString();
                    StudentProfile selTD = new StudentProfile();
                    StudentProfileDAO updTD = new StudentProfileDAO();
                    selTD = updTD.getStudentById(LblAdminNo.Text);
                }
            }
        }

        protected void BtnUpdate(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbNewPassword.Text) || string.IsNullOrEmpty(TbNewPassword.Text))
            {
                LblResult.Text = "Pls fill in all the blank";
            }
            else
            {
                LblAdminNo.Text = Session["AdminNo"].ToString();
                Student selTD = new Student();
                StudentProfileDAO updTD = new StudentProfileDAO();
                if (TbNewPassword.Text == TbCfmNewPassword.Text)
                {
                    int updCnt;
                    updCnt = updTD.ChangePw(LblAdminNo.Text, TbNewPassword.Text);
                    if (updCnt == 1)
                    {
                        LblResult.Text = "Password has been changed!";
                        LblResult.ForeColor = System.Drawing.Color.Black;
                        Response.Redirect("GeneralSetting.aspx");
                    }
                }
                else
                {
                    LblResult.Text = "Password Different. Please double check";
                }
            }


        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("GeneralSetting.aspx");
        }
    }
}