using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eadLab5
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
            //if (Session["Staffid"] == null)
            //{
              //  Response.Redirect("loginStaff.aspx");
            //}
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            validateHolder.Visible = false;
            validateNumber.Visible = false;
            validateExpiry.Visible = false;
            validateCVC.Visible = false;

            if (string.IsNullOrEmpty(CreditName.Text))
            {
                validateHolder.Visible = true;
            }

            if (string.IsNullOrEmpty(CreditEntry.Text))
            {
                validateNumber.Text = "Credit Card Number is required!";
                validateNumber.Visible = true;
            }
            else if (CreditEntry.Text.All(char.IsDigit) == false){
                validateNumber.Text = "Please enter numbers only!";
                validateNumber.Visible = true;
            }


            if (CreditExpiry.SelectedDate == null || CreditExpiry.SelectedDate == new DateTime(0001, 1, 1, 0, 0, 0))
            {
                validateExpiry.Text = "Please enter a valid date!";
                validateExpiry.Visible = true;
            }
            
            if (string.IsNullOrEmpty(CreditCVC.Text))
            {
                validateCVC.Text = "CVC is required!";
                validateCVC.Visible = true;
            }
            else if (CreditCVC.Text.All(char.IsDigit) == false)
            {
                validateCVC.Text = "Please enter numbers only!";
                validateCVC.Visible = true;
            }

            lblErrorMessage.Visible = true;
        }

        
    }
}