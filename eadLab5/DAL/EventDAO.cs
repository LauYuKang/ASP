using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;

namespace eadLab5.DAL
{
    public class EventDAO
    {
        public int count = 0;
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        public List<Event> getCurrentEvent(string AdminNo)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            List<Event> rteList = new List<Event>();
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("SELECT * from Event where ");
            sqlCommand.AppendLine("AdminNo = @paraAdminNo AND Status = 'active' ");


            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("paraAdminNo", AdminNo);
            da.Fill(ds, "EventTable");

            int rec_cnt = ds.Tables["EventTable"].Rows.Count;
            count = rec_cnt;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["EventTable"].Rows)
                {
                    Event myTd = new Event();
                    myTd.EventID = Convert.ToInt32(row["EventID"].ToString());
                    myTd.EventName = row["EventName"].ToString();
                    myTd.EyearTaken = row["EyearTaken"].ToString();
                    myTd.AdminNo = row["AdminNo"].ToString();
                    myTd.EsemTaken = row["EsemTaken"].ToString();
                    rteList.Add(myTd);
                }
            }
            else
            {
                rteList = null;
            }

            return rteList;
        }

        public int InsertTD(String EventName, String EyearTaken, String EsemTaken, String AdminNo)
        {
            String Status = "active";
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();
            // Step1 : Create SQL insert command to add record to TDMaster using     

            //         parameterised query in values clause
            //
            sqlStr.AppendLine("INSERT INTO Event (EventName, EyearTaken, EsemTaken, AdminNo, Status) ");
            sqlStr.AppendLine("VALUES (@paraEventName,@paraEyearTaken, @paraEsemTaken, @paraAdminNo, @paraStatus)");


            // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            // Step 3 : Add each parameterised query variable with value
            //          complete to add all parameterised queries
            sqlCmd.Parameters.AddWithValue("@paraEventName", EventName);
            sqlCmd.Parameters.AddWithValue("@paraEyearTaken", EyearTaken);
            sqlCmd.Parameters.AddWithValue("@paraEsemTaken", EsemTaken);
            sqlCmd.Parameters.AddWithValue("@paraAdminNo", AdminNo);
            sqlCmd.Parameters.AddWithValue("@paraStatus", Status);

            // Step 4 Open connection the execute NonQuery of sql command   

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;

        }

        public int delete(int EventID, String Status)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();
            // Step1 : Create SQL insert command to add record to TDMaster using     

            //         parameterised query in values clause
            //
            sqlStr.AppendLine("UPDATE Event");
            sqlStr.AppendLine("SET Status = @paraStatus");
            sqlStr.AppendLine("where EventID = @paraEventID");


            // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            // Step 3 : Add each parameterised query variable with value
            //          complete to add all parameterised querie
            sqlCmd.Parameters.AddWithValue("@paraStatus", Status);
            sqlCmd.Parameters.AddWithValue("@paraEventID", EventID);
            // Step 4 Open connection the execute NonQuery of sql command   


            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;

        }

        public Event getEventById(int EventID)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;


            SqlDataAdapter da;
            DataSet ds = new DataSet();

            StringBuilder AchievementCommand = new StringBuilder();
            AchievementCommand.AppendLine("Select * from Event where ");
            AchievementCommand.AppendLine("EventID = @paraEventID");

            Event obj = new Event();

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(AchievementCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("paraEventID", EventID);
            da.Fill(ds, "EventTable");

            int rec_cnt = ds.Tables["EventTable"].Rows.Count;
            count = rec_cnt;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["EventTable"].Rows[0];
                obj.EventID = Convert.ToInt32(row["EventID"]);
                obj.EventName = row["EventName"].ToString(); ;
                obj.EyearTaken = row["EyearTaken"].ToString();
                obj.EsemTaken = row["EsemTaken"].ToString();
                obj.AdminNo = row["AdminNo"].ToString();
            }
            else
            {
                obj = null;
            }

            return obj;
        }

        public int Edit(int EventID, String EventName, String EyearTaken, String EsemTaken)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();
            // Step1 : Create SQL insert command to add record to TDMaster using     

            //         parameterised query in values clause
            //
            sqlStr.AppendLine("UPDATE Event");
            sqlStr.AppendLine("SET EventName = @paraEventName, EyearTaken = @paraEyearTaken, EsemTaken = @paraEsemTaken ");
            sqlStr.AppendLine("where EventID = @paraEventID");


            // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            // Step 3 : Add each parameterised query variable with value
            //          complete to add all parameterised queries
            sqlCmd.Parameters.AddWithValue("@paraEventName", EventName);
            sqlCmd.Parameters.AddWithValue("@paraEyearTaken", EyearTaken);
            sqlCmd.Parameters.AddWithValue("@paraEsemTaken", EsemTaken);
            sqlCmd.Parameters.AddWithValue("@paraEventID", EventID);
            // Step 4 Open connection the execute NonQuery of sql command   


            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;

        }
    }
}