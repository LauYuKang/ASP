using eadLab5.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eadLab5
{
    public partial class TermDeposit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnGetCustomer_Click(object sender, EventArgs e)
        {
            
            customer cusObj = new customer();
            customerDAO cusDao = new customerDAO();
            cusObj = cusDao.getCustomerById(tbCustId.Text);
            if (cusObj != null)
            {
                PanelErrorResult.Visible = false;
                PanelCust.Visible = true;
                Lbl_custname.Text = cusObj.customerName;
                Lbl_Address.Text = cusObj.customerAddress;
                Lbl_HomePhone.Text = cusObj.customerHomePhone;
                Lbl_Mobile.Text = cusObj.customerMobile;
                Lbl_err.Text = String.Empty;
                HyplinkAdd.Visible = true;
                Session["SScustId"] = tbCustId.Text.ToString();
                Session["SScustName"] = cusObj.customerName;

                //timeDepositDAO tdDAO = new timeDepositDAO();
                //List<timeDeposit> tdList = new List<timeDeposit>();
                //tdList = tdDAO.getTDbyCustomerId(tbCustId.Text);
                //GridView_TD.DataSource = tdList;
                //GridView_TD.DataBind();
            }
            else
            {
                Lbl_err.Text = "Customer record not found!";
                PanelErrorResult.Visible = true;
                PanelCust.Visible = false;
                Lbl_custname.Text = String.Empty;
                Lbl_Address.Text = String.Empty;
                Lbl_HomePhone.Text = String.Empty;
                Lbl_Mobile.Text = String.Empty;
                HyplinkAdd.Visible = false;
                
            }
        }

        protected void GridView_TD_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView_TD.SelectedRow;
            // In this grid, the first cell (index 0) contains
            // the TD Account.
            Session["SSTDAcNo"] = row.Cells[0].Text;
            Response.Redirect("TermDepositUpdate.aspx");
        }
    }
}