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
    public class AchievementDAO
    {
        public int count = 0;
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        public List<Achievement> getAchievement(string AdminNo)
        {

            List<Achievement> tdList = new List<Achievement>();

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            StringBuilder AchievementCommand = new StringBuilder();
            AchievementCommand.AppendLine("Select * from Achievement where");
            AchievementCommand.AppendLine("AdminNo = @paraAdminNo AND Status = 'active' ");
            Achievement obj = new Achievement();

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(AchievementCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("paraAdminNo", AdminNo);
            da.Fill(ds, "AchievementTable");

            int rec_cnt = ds.Tables["AchievementTable"].Rows.Count;
            count = rec_cnt;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["AchievementTable"].Rows)
                {
                    Achievement myTd = new Achievement();

                    myTd.AchievementId = Convert.ToInt32(row["AchievementId"]);
                    myTd.AchievementName = row["AchievementName"].ToString(); ;
                    myTd.AyearTaken = Convert.ToInt32(row["AyearTaken"]);
                    myTd.AdminNo = row["AdminNo"].ToString();
                    myTd.Status = row["Status"].ToString();
                    tdList.Add(myTd);
                }
            }
            else
            {
                tdList = null;
            }

            return tdList;
        }

        public int InsertTD(String AchievementName, int AyearTaken, String AdminNo, String Status)
        {

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();
            // Step1 : Create SQL insert command to add record to TDMaster using     

            //         parameterised query in values clause
            //
            sqlStr.AppendLine("INSERT INTO Achievement (AchievementName, AyearTaken, AdminNo, Status) ");
            sqlStr.AppendLine("VALUES (@paraAchievementName,@paraAyearTaken, @paraAdminNo, @paraStatus)");


            // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            // Step 3 : Add each parameterised query variable with value
            //          complete to add all parameterised queries
            sqlCmd.Parameters.AddWithValue("@paraAchievementName", AchievementName);
            sqlCmd.Parameters.AddWithValue("@paraAyearTaken", AyearTaken);
            sqlCmd.Parameters.AddWithValue("@paraAdminNo", AdminNo);
            sqlCmd.Parameters.AddWithValue("@paraStatus", Status);

            // Step 4 Open connection the execute NonQuery of sql command   

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;

        }

        public int delete(int AchievementId, String AdminNo, String Status)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();
            // Step1 : Create SQL insert command to add record to TDMaster using     

            //         parameterised query in values clause
            //
            sqlStr.AppendLine("UPDATE Achievement");
            sqlStr.AppendLine("SET Status = @paraStatus");
            sqlStr.AppendLine("where AchievementId = @paraAchievementId");


            // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            // Step 3 : Add each parameterised query variable with value
            //          complete to add all parameterised queries
            sqlCmd.Parameters.AddWithValue("@paraAdminNo", AdminNo);
            sqlCmd.Parameters.AddWithValue("@paraStatus", Status);
            sqlCmd.Parameters.AddWithValue("@paraAchievementId", AchievementId);
            // Step 4 Open connection the execute NonQuery of sql command   


            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;

        }

        public Achievement getAchievementById(int AchievementId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;


            SqlDataAdapter da;
            DataSet ds = new DataSet();

            StringBuilder AchievementCommand = new StringBuilder();
            AchievementCommand.AppendLine("Select * from Achievement where ");
            AchievementCommand.AppendLine("AchievementId = @paraAchievementId");

            Achievement obj = new Achievement();

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(AchievementCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("paraAchievementId", AchievementId);
            da.Fill(ds, "AchievementTable");

            int rec_cnt = ds.Tables["AchievementTable"].Rows.Count;
            count = rec_cnt;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["AchievementTable"].Rows[0];
                obj.AchievementId = Convert.ToInt32(row["AchievementId"]);
                obj.AchievementName = row["AchievementName"].ToString(); ;
                obj.AyearTaken = Convert.ToInt32(row["AyearTaken"]);
                obj.AdminNo = row["AdminNo"].ToString();
                obj.Status = row["Status"].ToString();
            }
            else
            {
                obj = null;
            }

            return obj;
        }

        public int Edit(int AchievementId, String AchievementName, int AyearTaken)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();
            // Step1 : Create SQL insert command to add record to TDMaster using     

            //         parameterised query in values clause
            //
            sqlStr.AppendLine("UPDATE Achievement");
            sqlStr.AppendLine("SET AchievementName = @paraAchievementName, AyearTaken = @paraAyearTaken ");
            sqlStr.AppendLine("where AchievementId = @paraAchievementId");


            // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            // Step 3 : Add each parameterised query variable with value
            //          complete to add all parameterised queries
            sqlCmd.Parameters.AddWithValue("@paraAchievementName", AchievementName);
            sqlCmd.Parameters.AddWithValue("@paraAyearTaken", AyearTaken);
            sqlCmd.Parameters.AddWithValue("@paraAchievementId", AchievementId);
            // Step 4 Open connection the execute NonQuery of sql command   


            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;

        }

    }
}