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
    public partial class TermDepositPlacement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string custId = string.Empty;
            if (Page.IsPostBack == false)
            {
                // step 1: Assign session variables to the respective label for customer NRIC and Name
                // compete the code
                if (Session["SScustId"] != null)
                {
                    LblCustId.Text = Session["SScustId"].ToString();
                    LblCustname.Text = Session["SScustName"].ToString();
                }

                // step 2: Instantiate the interestRte class to a new instance named as fmTdRte 
                //         Instantiate the array list to hold list of TD term and rate
                //         Invole getCurrentTdRte method to obtain the interest rate by term 
                // complete the code
                InterestRteDAO fmTdRte = new InterestRteDAO();
                List<interestRte> TdRteList = new List<interestRte>();



                // Step 3: propogate tdTerm as dropdown list text , propogate intRte as dropdown list value
                DdlTerm.Items.Clear();
                DdlTerm.Items.Insert(0, new ListItem("--Select--", "0"));
                //AppendDataBoundItems property allows you to add items to the ListControl object before data binding occurs.
                DdlTerm.AppendDataBoundItems = true;

                DdlTerm.DataTextField = "tdTerm";
                DdlTerm.DataValueField = "intRte";
                DdlTerm.DataSource = TdRteList;
                DdlTerm.DataBind();
            }
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            // formulate the variables required from web form controls
            // These variables are used to assign the parameters of InsertTD method
            String tdAccount = TbNewAcno.Text.ToString();
            String tdCustId = LblCustId.Text.ToString();
            double tdPrincipal = Convert.ToDouble(TbPrincipal.Text.ToString());
            int tdTerm = Convert.ToInt32(DdlTerm.SelectedItem.Text.ToString());

            DateTime tdMaturityDte = Convert.ToDateTime(LblMaturedDte.Text);
            double tdInterest = Convert.ToDouble(LblInterest.Text.ToString());
            double tdMaturedAmt = Convert.ToDouble(LblMaturedAmt.Text);
            float tdIntRte = Convert.ToSingle(DdlTerm.SelectedValue);

            // complete the code

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

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {

        }

        public double calculateMaturity(double fmPrincipal, int fmTerm, float fmIntRte)
        {
            // A = P x (1 + r/n)nt 
            // r is annual interest rate (1.5% per annual is 0.015
            // n - number of time interest compounded. Monthly compounding, n will be 12
            //     half yearly compounding will be 2, quarter compounding, n will be 4
            //     This practical assume quarter compounding
            // t - number of year
            int n = 4;
            float r = fmIntRte / 100;
            int t = fmTerm;
            int nt = n * t / 12;
            double fmMaturity = fmPrincipal * Math.Pow((1 + (r / n)), nt);
            fmMaturity = Math.Round(fmMaturity, 1);
            return fmMaturity;
        }

        protected void DdlTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            double fmPrincipal;
            DateTime fmTdMatureDte;
            double fmInterest, fmMaturedAmt;
            int fmTerm;
            float fmIntRte;
            int itemidx = DdlTerm.SelectedIndex;
            if (DdlTerm.SelectedIndex > 0)
            {
                try
                {
                    fmPrincipal = Convert.ToDouble(TbPrincipal.Text);
                    fmIntRte = Convert.ToSingle(DdlTerm.SelectedValue);
                    fmTerm = Convert.ToInt32(DdlTerm.SelectedItem.Text);

                    fmMaturedAmt = calculateMaturity(fmPrincipal, fmTerm, fmIntRte);

                    fmInterest = Math.Round((fmMaturedAmt - fmPrincipal), 1);
                    fmTdMatureDte = DateTime.Now.AddMonths(fmTerm);

                    LblIntRte.Text = DdlTerm.SelectedValue;

                    LblMaturedDte.Text = fmTdMatureDte.ToString();
                    LblInterest.Text = fmInterest.ToString();
                    LblMaturedAmt.Text = fmMaturedAmt.ToString();
                }
                catch (FormatException)
                {
                    LblErr.Text = "Please input an numeric dollar amount!";
                }
            }
            else
            {
                LblErr2.Text = "Select a valid term!";
            }
        }
    }
}