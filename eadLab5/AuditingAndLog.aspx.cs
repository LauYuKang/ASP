using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eadLab5.DAL;
using System.Windows;

namespace eadLab5
{
    public partial class AuditingAndLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null)
            {
                Response.Redirect("loginStaff.aspx");
            }
            if (Session["role"].ToString() != "admin")
            {
                Response.Redirect("loginStaff.aspx");
            } /*
            if (Session["role"] == null)
            {
                Response.Redirect("loginStaff.aspx");
            }
            if (Session["role"].ToString() != "admin")
            {
                Response.Redirect("loginStaff.aspx");
            }
            if (Session["Staffid"] == null)
            {
                Response.Redirect("loginStaff.aspx");
            }
            if (Convert.ToInt32(Session["Staffid"]) != 0)
            {
                Response.Redirect("loginStaff.aspx");
            }*/
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            AuditDAO deleteDAO = new AuditDAO();
            deleteDAO.delete(index);
            Response.Redirect("AuditingAndLog.aspx");
        }



        bool ReturnValue()
        {
            return false;
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //((Button)e.Row.Cells[9].Controls[]).OnClientClick = "return confirm('Are you sure you want to delete?');";
            }
        }

        protected void tb_date_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void btn_retrieve_Click(object sender, EventArgs e)
        {
            //EADP.FilterExpression = "CONVERT(VARCHAR, ActionDate) LIKE'" + tb_date.Text + "%'";
            //EADP.SelectCommand = "SELECT * FROM [AuditLog] WHERE CONVERT(VARCHAR(30), ActionDate) LIKE '" + tb_date.Text + "%'";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}