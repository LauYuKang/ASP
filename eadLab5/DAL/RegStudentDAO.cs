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
    public class RegStudentDAO
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        public List<RegStudent> getRegisteredStudents(int tripId)
        {
            List<RegStudent> studentList = new List<RegStudent>();
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();
            //
            // Step 3 :Create SQLcommand to select all columns from TDMaster by parameterised customer id
            //          where TD is not matured yet

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * From Register r");
            sqlStr.AppendLine("INNER JOIN STUDENT s on s.AdminNo = r.AdminNo");
            sqlStr.AppendLine("INNER JOIN STAFF st on st.StaffId = r.StaffId");
            sqlStr.AppendLine("where tripId = @pTripId");


            // Step 4 :Instantiate SqlConnection instance and SqlDataAdapter instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            // Step 5 :add value to parameter 

            da.SelectCommand.Parameters.AddWithValue("pTripId", tripId);

            // Step 6: fill dataset
            da.Fill(ds, "TableRS");

            // Step 7: Iterate the rows from TableTD above to create a collection of TD
            //         for this particular customer 

            int rec_cnt = ds.Tables["TableRS"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["TableRS"].Rows)
                {
                    RegStudent registeredStudents = new RegStudent();

                    // Step 8 Set attribute of timeDeposit instance for each row of record in TableTD

                    //myTD.Affordability = row["tdAccount"].ToString();
                    registeredStudents.adminNo = row["AdminNo"].ToString();


                    //  Step 9: Add each timeDeposit instance to array list
                    studentList.Add(registeredStudents);
                }
            }
            else
            {
                studentList = null;
            }
            return studentList;
        }
    }
}