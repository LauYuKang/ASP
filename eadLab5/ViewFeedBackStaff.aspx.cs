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
    public partial class ViewFeedBackStaff : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if ((Session["role"].ToString() == "Teacher") || (Session["role"].ToString() == "Incharge"))
                {
                    if (!IsPostBack)
                    {
                        FeedbackFormDAO tdDAO = new FeedbackFormDAO();
                        List<FeedbackForm> tdList = new List<FeedbackForm>();
                        tdList = tdDAO.GetAllFeedBack();
                        GridView_GetFB.DataSource = tdList;
                        GridView_GetFB.DataBind();

                        TripDAO tripDao = new TripDAO();
                        List<String> countryList = tripDao.getCountry();
                        CountryFilterDropDown.DataSource = countryList;
                        CountryFilterDropDown.DataBind();
                        CountryFilterDropDown.Items.Insert(0, new ListItem("All", "All"));
                    }
                }
                else
                {
                    Response.Redirect("./Oops.aspx");
                }
            }
            catch (Exception)
            {
                Response.Redirect("./Oops.aspx");
            }

        }

        protected void GridView_GetFB_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView_GetFB.SelectedRow;
            // In this grid, the first cell (index 0) contains
            // the TD Account.

            Session["FeedBackId"] = row.Cells[0].Text;
            Response.Redirect("StaffViewSpecificFeedBack.aspx");
        }

        protected void CountryFilterDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            FeedbackFormDAO tdDAO = new FeedbackFormDAO();
            List<FeedbackForm> tdList = new List<FeedbackForm>();
            DateTime startD = DateTime.Parse("1-1-1753");
            DateTime endD = DateTime.Parse("1-1-9999");

            try
            {
                 startD = DateTime.Parse(txtDateCheckStart.Text);
                 endD = DateTime.Parse(txtDateCheckEnd.Text);
            }
            catch (Exception)
            {
                 startD = DateTime.Parse("1-1-1753");
                 endD = DateTime.Parse("1-1-9999");
            }
            
            try
            {
                tdList = tdDAO.GetFilteredFeedBacks(CountryFilterDropDown.SelectedValue.ToString(), AffordabilityFilterDropDown.SelectedValue.ToString(), FreedomFilterDropDown.SelectedValue.ToString(), startD, endD);
            }
            catch (Exception)
            {
                tdList = tdDAO.GetFilteredFeedBacks(CountryFilterDropDown.SelectedValue.ToString(), AffordabilityFilterDropDown.SelectedValue.ToString(), FreedomFilterDropDown.SelectedValue.ToString(), DateTime.Parse("1-1-1753"), DateTime.Parse("1-1-9999"));
            }
           
            GridView_GetFB.DataSource = tdList;
            GridView_GetFB.DataBind();
        }

        protected void AffordabilityFilterDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            FeedbackFormDAO tdDAO = new FeedbackFormDAO();
            List<FeedbackForm> tdList = new List<FeedbackForm>();
            DateTime startD = DateTime.Parse("1-1-1753");
            DateTime endD = DateTime.Parse("1-1-9999");

            try
            {
                startD = DateTime.Parse(txtDateCheckStart.Text);
                endD = DateTime.Parse(txtDateCheckEnd.Text);
            }
            catch (Exception)
            {
                startD = DateTime.Parse("1-1-1753");
                endD = DateTime.Parse("1-1-9999");
            }

            try
            {
                tdList = tdDAO.GetFilteredFeedBacks(CountryFilterDropDown.SelectedValue.ToString(), AffordabilityFilterDropDown.SelectedValue.ToString(), FreedomFilterDropDown.SelectedValue.ToString(), startD, endD);
            }
            catch (Exception)
            {
                tdList = tdDAO.GetFilteredFeedBacks(CountryFilterDropDown.SelectedValue.ToString(), AffordabilityFilterDropDown.SelectedValue.ToString(), FreedomFilterDropDown.SelectedValue.ToString(), DateTime.Parse("1-1-1753"), DateTime.Parse("1-1-9999"));
            }

            GridView_GetFB.DataSource = tdList;
            GridView_GetFB.DataBind();
        }

        protected void FreedomFilterDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            FeedbackFormDAO tdDAO = new FeedbackFormDAO();
            List<FeedbackForm> tdList = new List<FeedbackForm>();
            DateTime startD = DateTime.Parse("1-1-1753");
            DateTime endD = DateTime.Parse("1-1-9999");

            try
            {
                startD = DateTime.Parse(txtDateCheckStart.Text);
                endD = DateTime.Parse(txtDateCheckEnd.Text);
            }
            catch (Exception)
            {
                startD = DateTime.Parse("1-1-1753");
                endD = DateTime.Parse("1-1-9999");
            }

            try
            {
                tdList = tdDAO.GetFilteredFeedBacks(CountryFilterDropDown.SelectedValue.ToString(), AffordabilityFilterDropDown.SelectedValue.ToString(), FreedomFilterDropDown.SelectedValue.ToString(), startD, endD);
            }
            catch (Exception)
            {
                tdList = tdDAO.GetFilteredFeedBacks(CountryFilterDropDown.SelectedValue.ToString(), AffordabilityFilterDropDown.SelectedValue.ToString(), FreedomFilterDropDown.SelectedValue.ToString(), DateTime.Parse("1-1-1753"), DateTime.Parse("1-1-9999"));
            }

            GridView_GetFB.DataSource = tdList;
            GridView_GetFB.DataBind();
        }
        

        protected void txtDateCheckEnd_TextChanged(object sender, EventArgs e)
        {
            FeedbackFormDAO tdDAO = new FeedbackFormDAO();
            List<FeedbackForm> tdList = new List<FeedbackForm>();
            DateTime startD = DateTime.Parse("1-1-1753");
            DateTime endD = DateTime.Parse("1-1-9999");

            try
            {
                 startD = DateTime.Parse(txtDateCheckStart.Text);
                 endD = DateTime.Parse(txtDateCheckEnd.Text);
            }
            catch (Exception)
            {
                 startD = DateTime.Parse("1-1-1753");
                 endD = DateTime.Parse("1-1-9999");
            }
            
            try
            {
                tdList = tdDAO.GetFilteredFeedBacks(CountryFilterDropDown.SelectedValue.ToString(), AffordabilityFilterDropDown.SelectedValue.ToString(), FreedomFilterDropDown.SelectedValue.ToString(), startD, endD);
            }
            catch (Exception)
            {
                tdList = tdDAO.GetFilteredFeedBacks(CountryFilterDropDown.SelectedValue.ToString(), AffordabilityFilterDropDown.SelectedValue.ToString(), FreedomFilterDropDown.SelectedValue.ToString(), DateTime.Parse("1-1-1753"), DateTime.Parse("1-1-9999"));
            }
           
            GridView_GetFB.DataSource = tdList;
            GridView_GetFB.DataBind();
        }
    }
}