using eadLab5.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eadLab5
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StudentProfile StudentObj = new StudentProfile();
            StudentProfileDAO StudentDao = new StudentProfileDAO();
            String adminNo = Session["AdminNo"].ToString();
            StudentObj = StudentDao.getStudentById(adminNo);

            if (StudentObj != null)
            {

                //PanelErrorResult.Visible = false;
                //Panelstudent.Visible = true;
                Lbl_studentname.Text = StudentObj.StudentName;
                Lbl_Gender.Text = StudentObj.Gender;
                Lbl_Diploma.Text = StudentObj.Diploma;
                Lbl_MedicalCondition.Text = StudentObj.MedicalCondition;
                Lbl_MedicalHistory.Text = StudentObj.MedicalHistory;
                Lbl_Summary.Text = StudentObj.Summary;
                Lbl_HpNumber.Text = StudentObj.HpNumber.ToString();
                Lbl_Email.Text = StudentObj.Email;
                Image1.ImageUrl = StudentObj.ProfilePicture;
                //Lbl_err.Text = String.Empty;
            }
        }

        protected void BtnSettingDetails(object sender, EventArgs e)
        {
            Session["SSStudentName"] = Lbl_studentname.Text;
            Response.Redirect("GeneralSetting.aspx");
        }
    }
}