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
    public partial class FAQPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FAQDAO FAQDAO = new FAQDAO();
            List<FAQ> tdList = new List<FAQ>();
            tdList = FAQDAO.getFAQ();
            GridView_FAQ.DataSource = tdList;
            GridView_FAQ.DataBind();
        }

        protected void GridView_FAQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView_FAQ.SelectedRow;

            Session["FaqId"] = row.Cells[0].Text;
            Response.Redirect("FAQPage.aspx");
        }
    }
}