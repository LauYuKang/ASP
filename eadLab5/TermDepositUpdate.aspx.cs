using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eadLab5.DAL;

namespace eadLab5
{
    public partial class TermDepositUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack == false)
            {
                if(Session["AdminNo"] != null)
                {
                    LblCustId.Text = Session["SScustId"].ToString();
                    LblCustname.Text = Session["SSCustName"].ToString();
                    LblAcno.Text = Session["SSTDAcNo"].ToString();
                    timeDeposit selTD = new timeDeposit();
                    timeDepositDAO updTD = new timeDepositDAO();
                    selTD = updTD.getTDbyAccount(LblAcno.Text);
                    LblPrincipal.Text = selTD.tdPrincipal.ToString();
                    LblCustId.Text = selTD.tdMaturedAmt.ToString();
                    LblCustId.Text = selTD.tdMaturityDte.ToString();
                    DdlRenew.SelectedIndex = selTD.tdRenewMode;
                    ViewState["currRenewMode"] = selTD.tdRenewMode;
                }
                else
                {
                    Response.Redirect("TermDeposit.aspx");
                }
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            timeDeposit selTD = new timeDeposit();
            timeDepositDAO updTD = new timeDepositDAO();
            int updCnt;
            int updRenewMode = 0;
            int currMode = Convert.ToInt16(ViewState["currRenewMode"]);

            if (DdlRenew.SelectedIndex == -1)
            {
                LblResult.Text = "Please select a value";
                LblResult.ForeColor = System.Drawing.Color.Red;
            }
            else if (DdlRenew.SelectedValue == currMode.ToString())
            {
                LblResult.Text = "You have not changed the renewal mode";
                LblResult.ForeColor = System.Drawing.Color.Red;
                BtnUpdate.Enabled = false;
            }
            else
            {
                updRenewMode = DdlRenew.SelectedIndex;

                updCnt = updTD.updateTD(LblAcno.Text, updRenewMode);
                if (updCnt == 1)
                {
                    LblResult.Text = "TD Renew Mode has been changed!";
                    LblResult.ForeColor = System.Drawing.Color.Black;
                }
            }

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("TermDeposit.aspx");
        }
    }
}