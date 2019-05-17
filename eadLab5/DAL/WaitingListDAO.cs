using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace eadLab5.DAL
{
    public class WaitingListDAO
    {
        //string DBConnect = ConfigurationManager.ConnectionStrings['ConnStr'].ConnectionString;

        public WaitingList getWaitingList()
        {
            return null;
            //DataSet ds = new DataSet();
            //DataTable wtData = new DataTable();

            //StringBuilder sqlStr = new StringBuilder();
            //sqlStr.AppendLine("Select * from WaitingList wl");
            //sqlStr.AppendLine("INNER JOIN Student s on s.adminno = wl.adminno");

            //SqlConnection myConn = new SqlConnection(DBConnect);
            //SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            //da.Fill(ds, "TableWL");

            //int rec_cnt = ds.Tables["TableWL"].Rows.Count;
            //WaitingList myWL = new WaitingList();
            //if(rec_cnt > 0)
            //{
            //    DataRow row = ds.Tables["TableWL"].Rows[0];
            //    myWL.name = row["StudentName"].ToString();
            //    myWL.precedence = Convert.ToInt32(row["precendence"]);
            //    myWL.remarks = row["Remarks"].ToString();
            //    return myWL;
            //}
            //return null;
        }
    }
}