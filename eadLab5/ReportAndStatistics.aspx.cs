using eadLab5.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eadLab5
{
    public partial class ReportAndStatistics : System.Web.UI.Page
    {
        string tmpChartName2 = "test2.jpg";
        string tmpChartName4 = "test4.jpg";

        string tmpChartName1 = "test1.jpg";
        string tmpChartName3 = "test3.jpg";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if ((Session["role"].ToString() == "Teacher") || (Session["role"].ToString() == "Incharge"))
                {
                    if (!IsPostBack)
                    {
                        buildBarChart("All", "All", DateTime.Parse("1-1-1753"), DateTime.Parse("1-1-9999"));
                        buildPieChart("All");
                        buildHorizontalChart("All");
                        buildLineChart("All", "All");

                        Chart1.Series[0]["PieLabelStyle"] = "Outside";
                        Chart1.Legends.Add("Legend1");
                        Chart1.Legends[0].Enabled = true;
                        Chart1.Series[0].LegendText = "#PERCENT{P1}";

                    

                        TripDAO tripDao = new TripDAO();
                        List<String> countryList = tripDao.getCountry();
                        CountryDropDown.DataSource = countryList;
                        CountryDropDown.DataBind();
                        CountryDropDown.Items.Insert(0, new ListItem("All", "All"));

                        DropDownListCountryPieChart.DataSource = countryList;
                        DropDownListCountryPieChart.DataBind();
                        DropDownListCountryPieChart.Items.Insert(0, new ListItem("All", "All"));
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

       public string flipDate(string originalD)
        {
            string noinput = "";
            if (originalD == "") {
                return noinput;
            }
            else
            {
                string year = originalD.Substring(0, 4);
                string month = originalD.Substring(5, 2);
                string day = originalD.Substring(8, 2);
                string newdate = day + "-" + month + "-" + year;
                return newdate;
            }

       }

        private void buildBarChart(string country, string type, DateTime dateStart, DateTime dateEnd)
        {
            String myConnect = ConfigurationManager.ConnectionStrings["EADPConnectionString2"].ToString();
            SqlConnection myConn = new SqlConnection(myConnect);

            DataSet ds = new DataSet();

            String strSQL = "SELECT location, avg(cost) as cost FROM [dbo].[Trip] ";

            if (!country.Equals("All"))
            {
                strSQL += "where location = @paraCountry ";
                strSQL += "and status != 'Cancelled' ";
            }

            if (!type.Equals("All") && (!country.Equals("All")))
            {
                strSQL += "and triptype = @paratype ";
                strSQL += "and status != 'Cancelled' ";

            }
            else if (!type.Equals("All") && (country.Equals("All")))
            {

                strSQL += "where triptype = @paratype ";
                strSQL += "and status != 'Cancelled' ";
            }

            if ((!dateStart.Equals("") || (!dateEnd.Equals(""))) && (country.Equals("All")) && (type.Equals("All")))
            {
                strSQL += "where TRIPSTART BETWEEN @paradateStart and @paradateEnd ";
                strSQL += "and status != 'Cancelled' ";

            }
            else if ((!dateStart.Equals("") || (!dateEnd.Equals(""))) && (!country.Equals("All")) && (type.Equals("All")))
            {
                strSQL += "and TRIPSTART BETWEEN @paradateStart and @paradateEnd ";
                strSQL += "and status != 'Cancelled' ";

            }
            else if ((!dateStart.Equals("") || (!dateEnd.Equals(""))) && (country.Equals("All")) && (!type.Equals("All")))
            {
                strSQL += "and TRIPSTART BETWEEN @paradateStart and @paradateEnd ";
                strSQL += "and status != 'Cancelled' ";
            }
            else if ((!dateStart.Equals("") || (!dateEnd.Equals(""))) && (!country.Equals("All")) && (!type.Equals("All")))
            {
                strSQL += "and TRIPSTART BETWEEN @paradateStart and @paradateEnd ";
                strSQL += "and status != 'Cancelled' ";
            }


            strSQL += "group by location";

            SqlDataAdapter da = new SqlDataAdapter(strSQL.ToString(), myConn);

            if (!country.Equals("All"))
            {
                da.SelectCommand.Parameters.AddWithValue("@paraCountry", country);
            }

            if (!type.Equals("All"))
            {
                da.SelectCommand.Parameters.AddWithValue("@paratype", type);
            }

            if (!dateStart.Equals(""))
            {
                da.SelectCommand.Parameters.AddWithValue("@paradateStart", dateStart);
            }

            if (!dateEnd.Equals(""))
            {
                da.SelectCommand.Parameters.AddWithValue("@paradateEnd", dateEnd);
            }

            da.Fill(ds, "tripTable");

            Chart2.DataSource = ds;
            Chart2.DataBind();

            string imgPathing2 = HttpContext.Current.Request.PhysicalApplicationPath + tmpChartName2;
            Chart2.SaveImage(imgPathing2);
        }

        private void buildPieChart(string country)
        {
            String myConnect = ConfigurationManager.ConnectionStrings["EADPConnectionString2"].ToString();
            SqlConnection myConn = new SqlConnection(myConnect);

            DataSet ds = new DataSet();
            
            String strSQL = "SELECT COUNT([Diploma]) NoOfStudents, [Diploma] FROM interview i ";
            strSQL += "INNER JOIN[Register] R on i.tripid = r.tripid ";
            strSQL += "INNER JOIN[Student] S on r.adminNo = s.adminNo ";
            strSQL += "INNER JOIN[trip] T on i.tripid = t.tripid ";

            if (!country.Equals("All"))
            {
                strSQL += "where location = @paraCountry and [studentchoice] = 'accepted' ";
            }else
            {
                strSQL += "where [studentchoice] = 'accepted' ";

            }

            strSQL += "Group By [Diploma]";

            SqlDataAdapter da = new SqlDataAdapter(strSQL.ToString(), myConn);

            if (!country.Equals("All"))
            {
                da.SelectCommand.Parameters.AddWithValue("@paraCountry", country);
            }

            da.Fill(ds, "tripTable");

            Chart1.DataSource = ds;
            Chart1.DataBind();
            string imgPathing2 = HttpContext.Current.Request.PhysicalApplicationPath + tmpChartName1;
            Chart1.SaveImage(imgPathing2);
        }

        private void buildLineChart(string Diploma, string StudentYear)
        {
            String myConnect = ConfigurationManager.ConnectionStrings["EADPConnectionString2"].ToString();
            SqlConnection myConn = new SqlConnection(myConnect);

            DataSet ds = new DataSet();

            SqlDataAdapter da;

            DateTime now = DateTime.Now;


            String strSQL = "SELECT COUNT(i.adminno) NoOfStudents, DATENAME(month, TripEnd) AS [Month] FROM [interview] i ";
            strSQL += "INNER JOIN trip t on i.tripid = t.tripid ";
            strSQL += "INNER JOIN register r on i.AdminNo = r.AdminNo ";
            strSQL += "INNER JOIN Student s on r.adminNo = s.adminno ";

            if (!Diploma.Equals("All"))
            {
                strSQL += "WHERE Diploma = @paraDiploma and studentchoice = 'accepted' and (GETDATE() > TripEnd) ";
                da = new SqlDataAdapter(strSQL.ToString(), myConn);

                if (!StudentYear.Equals("All"))
                {
                    if (now.Month > 4)
                    {
                        int studentyr = int.Parse(StudentYear);
                        studentyr--;
                        strSQL += "AND ((year(getdate()) - 2000) - convert(int, SUBSTRING(i.AdminNo, 1, 2))) = @paraStudentYear Group By [TripEnd] ";
                        //check
                        da = new SqlDataAdapter(strSQL.ToString(), myConn);
                        da.SelectCommand.Parameters.AddWithValue("@paraStudentYear", studentyr);
                    }
                    else
                    {
                        strSQL += "AND ((year(getdate()) - 2000) - convert(int, SUBSTRING(i.AdminNo, 1, 2))) = @paraStudentYear Group By [TripEnd] ";
                        //check
                        da = new SqlDataAdapter(strSQL.ToString(), myConn);
                        da.SelectCommand.Parameters.AddWithValue("@paraStudentYear", StudentYear);
                    }
                }
                else
                {
                    strSQL += "where studentchoice = 'accepted' and (GETDATE() > TripEnd) ";
                    strSQL += "Group By DATENAME(month, TripEnd) ";
                    da = new SqlDataAdapter(strSQL.ToString(), myConn);

                }
                da.SelectCommand.Parameters.AddWithValue("@paraDiploma", Diploma);
            }

            else if (!StudentYear.Equals("All"))
            {
                if (now.Month > 4)
                {
                    int studentyr = int.Parse(StudentYear);
                    studentyr--;
                    strSQL += "WHERE ((year(getdate()) - 2000) - convert(int, SUBSTRING(i.AdminNo, 1, 2))) = @paraStudentYear Group By [TripEnd] ";
                    //check
                    da = new SqlDataAdapter(strSQL.ToString(), myConn);
                    da.SelectCommand.Parameters.AddWithValue("@paraStudentYear", studentyr);
                }
                else
                {
                    strSQL += "WHERE ((year(getdate()) - 2000) - convert(int, SUBSTRING(i.AdminNo, 1, 2))) = @paraStudentYear Group By [TripEnd] ";
                    //check
                    da = new SqlDataAdapter(strSQL.ToString(), myConn);
                    da.SelectCommand.Parameters.AddWithValue("@paraStudentYear", StudentYear);
                }
            }

            else
            {
                strSQL += "Group By DATENAME(month, TripEnd) ";
                da = new SqlDataAdapter(strSQL.ToString(), myConn);
            }
            da.Fill(ds, "tripTable");

            Chart3.DataSource = ds;
            Chart3.DataBind();
            string imgPathing2 = HttpContext.Current.Request.PhysicalApplicationPath + tmpChartName3;
            Chart3.SaveImage(imgPathing2);
        }

        private void buildHorizontalChart(string StudentYear)
        {
            String myConnect = ConfigurationManager.ConnectionStrings["EADPConnectionString2"].ToString();
            SqlConnection myConn = new SqlConnection(myConnect);

            DataSet ds = new DataSet();

            String strSQL = "SELECT  Count(i.AdminNo) NoOfStudents, Location FROM [interview] i ";
            strSQL += "INNER JOIN trip t on i.tripid = t.tripid ";
            strSQL += "INNER JOIN register r on i.AdminNo = r.AdminNo ";
            strSQL += "INNER JOIN Student s on r.adminNo = s.adminno ";

            SqlDataAdapter da;

            DateTime now = DateTime.Now;

            if (!StudentYear.Equals("All"))
            {
                if (now.Month > 4)
                {
                    int studentyr= int.Parse(StudentYear);
                    studentyr--;
                    strSQL += "WHERE ((year(getdate()) - 2000) - convert(int, SUBSTRING(i.AdminNo, 1, 2))) = @paraStudentYear Group By [Location] ";
                    //check
                    da = new SqlDataAdapter(strSQL.ToString(), myConn);
                    da.SelectCommand.Parameters.AddWithValue("@paraStudentYear", studentyr);
                }
                else
                {
                    strSQL += "WHERE ((year(getdate()) - 2000) - convert(int, SUBSTRING(i.AdminNo, 1, 2))) = @paraStudentYear Group By [Location] ";
                    //check
                    da = new SqlDataAdapter(strSQL.ToString(), myConn);
                    da.SelectCommand.Parameters.AddWithValue("@paraStudentYear", StudentYear);
                }
            }
            else
            {
                strSQL += "Group By [Location] ";
                da = new SqlDataAdapter(strSQL.ToString(), myConn);
            }


            da.Fill(ds, "tripTable");

            Chart4.DataSource = ds;
            Chart4.DataBind();

            string imgPath4 = HttpContext.Current.Request.PhysicalApplicationPath + tmpChartName4;
            Chart4.SaveImage(imgPath4);
        }

        protected void DropDownListCountryPieChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            buildHorizontalChart(DropDownYear.Text);

            string countryBarChart = CountryDropDown.SelectedValue.ToString();
            string type = TypeDropDown.SelectedValue.ToString();

            string dateStart = flipDate(DateStartRange.Text);
            string dateEnd = flipDate(DateEndRange.Text);
            try
            {
                buildBarChart(countryBarChart, type, DateTime.Parse(dateStart), DateTime.Parse(dateEnd));
            }
            catch(Exception)
            {
                buildBarChart(countryBarChart, type, DateTime.Parse("1-1-1753"), DateTime.Parse("1-1-9999"));
            }
            

            string countryPieChart = DropDownListCountryPieChart.SelectedValue.ToString();
            buildPieChart(countryPieChart);

            string DiplomaLine = DropDownDiplomaLine.SelectedValue.ToString();
            string StudentYearDD = DropDownYearLine.SelectedValue.ToString();
            buildLineChart(DiplomaLine, StudentYearDD);

            Chart1.Series[0]["PieLabelStyle"] = "Outside";
            Chart1.Legends.Add("Legend1");
            Chart1.Legends[0].Enabled = true;
            Chart1.Series[0].LegendText = "#PERCENT{P1}";
        }

        protected void CountryDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            buildHorizontalChart(DropDownYear.Text);

            string countryBarChart = CountryDropDown.SelectedValue.ToString();
            string type = TypeDropDown.SelectedValue.ToString();

            string dateStart = flipDate(DateStartRange.Text);
            string dateEnd = flipDate(DateEndRange.Text);
            try
            {
                buildBarChart(countryBarChart, type, DateTime.Parse(dateStart), DateTime.Parse(dateEnd));
            }
            catch (Exception)
            {
                buildBarChart(countryBarChart, type, DateTime.Parse("1-1-1753"), DateTime.Parse("1-1-9999"));
            }


            string countryPieChart = DropDownListCountryPieChart.SelectedValue.ToString();
            buildPieChart(countryPieChart);

            string DiplomaLine = DropDownDiplomaLine.SelectedValue.ToString();
            string StudentYearDD = DropDownYearLine.SelectedValue.ToString();
            buildLineChart(DiplomaLine, StudentYearDD);
            Chart1.Series[0]["PieLabelStyle"] = "Outside";
            Chart1.Legends.Add("Legend1");
            Chart1.Legends[0].Enabled = true;
            Chart1.Series[0].LegendText = "#PERCENT{P1}";
        }

        protected void TypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            buildHorizontalChart(DropDownYear.Text);

            string countryBarChart = CountryDropDown.SelectedValue.ToString();
            string type = TypeDropDown.SelectedValue.ToString();

            string dateStart = flipDate(DateStartRange.Text);
            string dateEnd = flipDate(DateEndRange.Text);
            try
            {
                buildBarChart(countryBarChart, type, DateTime.Parse(dateStart), DateTime.Parse(dateEnd));
            }
            catch (Exception)
            {
                buildBarChart(countryBarChart, type, DateTime.Parse("1-1-1753"), DateTime.Parse("1-1-9999"));
            }


            string countryPieChart = DropDownListCountryPieChart.SelectedValue.ToString();
            buildPieChart(countryPieChart);

            string DiplomaLine = DropDownDiplomaLine.SelectedValue.ToString();
            string StudentYearDD = DropDownYearLine.SelectedValue.ToString();
            buildLineChart(DiplomaLine, StudentYearDD);
            Chart1.Series[0]["PieLabelStyle"] = "Outside";
            Chart1.Legends.Add("Legend1");
            Chart1.Legends[0].Enabled = true;
            Chart1.Series[0].LegendText = "#PERCENT{P1}";
        }

       

        protected void DateEndRange_TextChanged(object sender, EventArgs e)
        {
            buildHorizontalChart(DropDownYear.Text);

            string countryBarChart = CountryDropDown.SelectedValue.ToString();
            string type = TypeDropDown.SelectedValue.ToString();

            string dateStart = flipDate(DateStartRange.Text);
            string dateEnd = flipDate(DateEndRange.Text);
            try
            {
                buildBarChart(countryBarChart, type, DateTime.Parse(dateStart), DateTime.Parse(dateEnd));
            }
            catch (Exception)
            {
                buildBarChart(countryBarChart, type, DateTime.Parse("1-1-1753"), DateTime.Parse("1-1-9999"));
            }


            string countryPieChart = DropDownListCountryPieChart.SelectedValue.ToString();
            buildPieChart(countryPieChart);

            string DiplomaLine = DropDownDiplomaLine.SelectedValue.ToString();
            string StudentYearDD = DropDownYearLine.SelectedValue.ToString();
            buildLineChart(DiplomaLine, StudentYearDD);
            Chart1.Series[0]["PieLabelStyle"] = "Outside";
            Chart1.Legends.Add("Legend1");
            Chart1.Legends[0].Enabled = true;
            Chart1.Series[0].LegendText = "#PERCENT{P1}";
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            buildHorizontalChart(DropDownYear.Text);

            string countryBarChart = CountryDropDown.SelectedValue.ToString();
            string type = TypeDropDown.SelectedValue.ToString();

            string dateStart = flipDate(DateStartRange.Text);
            string dateEnd = flipDate(DateEndRange.Text);
            try
            {
                buildBarChart(countryBarChart, type, DateTime.Parse(dateStart), DateTime.Parse(dateEnd));
            }
            catch (Exception)
            {
                buildBarChart(countryBarChart, type, DateTime.Parse("1-1-1753"), DateTime.Parse("1-1-9999"));
            }


            string countryPieChart = DropDownListCountryPieChart.SelectedValue.ToString();
            buildPieChart(countryPieChart);

            string DiplomaLine = DropDownDiplomaLine.SelectedValue.ToString();
            string StudentYearDD = DropDownYearLine.SelectedValue.ToString();
            buildLineChart(DiplomaLine, StudentYearDD);
            Chart1.Series[0]["PieLabelStyle"] = "Outside";
            Chart1.Legends.Add("Legend1");
            Chart1.Legends[0].Enabled = true;
            Chart1.Series[0].LegendText = "#PERCENT{P1}";
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buildHorizontalChart(DropDownYear.Text);

            string countryBarChart = CountryDropDown.SelectedValue.ToString();
            string type = TypeDropDown.SelectedValue.ToString();

            string dateStart = flipDate(DateStartRange.Text);
            string dateEnd = flipDate(DateEndRange.Text);
            try
            {
                buildBarChart(countryBarChart, type, DateTime.Parse(dateStart), DateTime.Parse(dateEnd));
            }
            catch (Exception)
            {
                buildBarChart(countryBarChart, type, DateTime.Parse("1-1-1753"), DateTime.Parse("1-1-9999"));
            }


            string countryPieChart = DropDownListCountryPieChart.SelectedValue.ToString();
            buildPieChart(countryPieChart);

            string DiplomaLine = DropDownDiplomaLine.SelectedValue.ToString();
            string StudentYearDD = DropDownYearLine.SelectedValue.ToString();
            buildLineChart(DiplomaLine, StudentYearDD);
            Chart1.Series[0]["PieLabelStyle"] = "Outside";
            Chart1.Legends.Add("Legend1");
            Chart1.Legends[0].Enabled = true;
            Chart1.Series[0].LegendText = "#PERCENT{P1}";
        }

        protected void DropDownYearLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            buildHorizontalChart(DropDownYear.Text);

            string countryBarChart = CountryDropDown.SelectedValue.ToString();
            string type = TypeDropDown.SelectedValue.ToString();

            string dateStart = flipDate(DateStartRange.Text);
            string dateEnd = flipDate(DateEndRange.Text);
            try
            {
                buildBarChart(countryBarChart, type, DateTime.Parse(dateStart), DateTime.Parse(dateEnd));
            }
            catch (Exception)
            {
                buildBarChart(countryBarChart, type, DateTime.Parse("1-1-1753"), DateTime.Parse("1-1-9999"));
            }


            string countryPieChart = DropDownListCountryPieChart.SelectedValue.ToString();
            buildPieChart(countryPieChart);

            string DiplomaLine = DropDownDiplomaLine.SelectedValue.ToString();
            string StudentYearDD = DropDownYearLine.SelectedValue.ToString();
            buildLineChart(DiplomaLine, StudentYearDD);
            Chart1.Series[0]["PieLabelStyle"] = "Outside";
            Chart1.Legends.Add("Legend1");
            Chart1.Legends[0].Enabled = true;
            Chart1.Series[0].LegendText = "#PERCENT{P1}";
        }

        protected void Chart1_DataBound(object sender, EventArgs e)
        {
            // If there is no data in the series, show a text annotation
            if (Chart1.Series[0].Points.Count == 0)
            {
                System.Web.UI.DataVisualization.Charting.TextAnnotation annotation =
                    new System.Web.UI.DataVisualization.Charting.TextAnnotation();
                annotation.Text = "No data for this period";
                annotation.X = 5;
                annotation.Y = 5;
                annotation.Font = new System.Drawing.Font("Arial", 12);
                annotation.ForeColor = System.Drawing.Color.Red;
                Chart1.Annotations.Add(annotation);
            }
        }

        protected void Chart2_DataBound(object sender, EventArgs e)
        {
            // If there is no data in the series, show a text annotation
            if (Chart2.Series[0].Points.Count == 0)
            {
                System.Web.UI.DataVisualization.Charting.TextAnnotation annotation =
                    new System.Web.UI.DataVisualization.Charting.TextAnnotation();
                annotation.Text = "No data for this period";
                annotation.X = 5;
                annotation.Y = 5;
                annotation.Font = new System.Drawing.Font("Arial", 12);
                annotation.ForeColor = System.Drawing.Color.Red;
                Chart2.Annotations.Add(annotation);
            }
        }

        protected void Chart3_DataBound(object sender, EventArgs e)
        {
            // If there is no data in the series, show a text annotation

            if (Chart3.Series[0].Points.Count == 0)
            {
                System.Web.UI.DataVisualization.Charting.TextAnnotation annotation =
                    new System.Web.UI.DataVisualization.Charting.TextAnnotation();
                annotation.Text = "No data for this period";
                annotation.X = 5;
                annotation.Y = 5;
                annotation.Font = new System.Drawing.Font("Arial", 12);
                annotation.ForeColor = System.Drawing.Color.Red;
                Chart3.Annotations.Add(annotation);
            }
        }

        protected void Chart4_DataBound(object sender, EventArgs e)
        {
            if (Chart4.Series[0].Points.Count == 0)
            {
                System.Web.UI.DataVisualization.Charting.TextAnnotation annotation =
                    new System.Web.UI.DataVisualization.Charting.TextAnnotation();
                annotation.Text = "No data for this period";
                annotation.X = 5;
                annotation.Y = 5;
                annotation.Font = new System.Drawing.Font("Arial", 12);
                annotation.ForeColor = System.Drawing.Color.Red;
                Chart4.Annotations.Add(annotation);
            }
        }

        protected void DateStartRange_TextChanged(object sender, EventArgs e)
        {
            buildHorizontalChart(DropDownYear.Text);

            string countryBarChart = CountryDropDown.SelectedValue.ToString();
            string type = TypeDropDown.SelectedValue.ToString();

            string dateStart = flipDate(DateStartRange.Text);
            string dateEnd = flipDate(DateEndRange.Text);
            try
            {
                buildBarChart(countryBarChart, type, DateTime.Parse(dateStart), DateTime.Parse(dateEnd));
            }
            catch (Exception)
            {
                buildBarChart(countryBarChart, type, DateTime.Parse("1-1-1753"), DateTime.Parse("1-1-9999"));
            }


            string countryPieChart = DropDownListCountryPieChart.SelectedValue.ToString();
            buildPieChart(countryPieChart);

            string DiplomaLine = DropDownDiplomaLine.SelectedValue.ToString();
            string StudentYearDD = DropDownYearLine.SelectedValue.ToString();
            buildLineChart(DiplomaLine, StudentYearDD);
            Chart1.Series[0]["PieLabelStyle"] = "Outside";
            Chart1.Legends.Add("Legend1");
            Chart1.Legends[0].Enabled = true;
            Chart1.Series[0].LegendText = "#PERCENT{P1}";
        }

        protected void btnChart2Excel_Click(object sender, EventArgs e)

        {
            string imgPath2 = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/" + tmpChartName2);

            Response.Clear();

            Response.ContentType = "application/vnd.ms-excel";

            Response.AddHeader("Content-Disposition", "attachment; filename=Chart.xls;");

            StringWriter stringWrite = new StringWriter();

            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            string headerTable = @"<Table><tr><td><img src='" + imgPath2 + @"' \></td></tr></Table>";

            Response.Write(headerTable);

            Response.Write(stringWrite.ToString());

            Response.End();



        }

        protected void btnChart4Excel_Click(object sender, EventArgs e)

        {
          

            string imgPath2 = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/" + tmpChartName4);

            Response.Clear();

            Response.ContentType = "application/vnd.ms-excel";

            Response.AddHeader("Content-Disposition", "attachment; filename=Chart.xls;");

            StringWriter stringWrite = new StringWriter();

            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            string headerTable = @"<Table><tr><td><img src='" + imgPath2 + @"' \></td></tr></Table>";

            Response.Write(headerTable);

            Response.Write(stringWrite.ToString());

            Response.End();



        }

        protected void btnChart3Excel_Click(object sender, EventArgs e)

        {
            string imgPath2 = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/" + tmpChartName3);

            Response.Clear();

            Response.ContentType = "application/vnd.ms-excel";

            Response.AddHeader("Content-Disposition", "attachment; filename=Chart.xls;");

            StringWriter stringWrite = new StringWriter();

            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            string headerTable = @"<Table><tr><td><img src='" + imgPath2 + @"' \></td></tr></Table>";

            Response.Write(headerTable);

            Response.Write(stringWrite.ToString());

            Response.End();



        }

        protected void btnChart1Excel_Click(object sender, EventArgs e)

        {
            string imgPath2 = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/" + tmpChartName1);

            Response.Clear();

            Response.ContentType = "application/vnd.ms-excel";

            Response.AddHeader("Content-Disposition", "attachment; filename=Chart.xls;");

            StringWriter stringWrite = new StringWriter();

            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            string headerTable = @"<Table><tr><td><img src='" + imgPath2 + @"' \></td></tr></Table>";

            Response.Write(headerTable);

            Response.Write(stringWrite.ToString());

            Response.End();



        }

    }
}


 

       


       