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
    public class AuditDAO
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        public int count = 0;
        public List<Audit> getAllAudit()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            List<Audit> rteList = new List<Audit>();
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("SELECT * from AuditLog");

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.Fill(ds, "AuditTable");

            int rec_cnt = ds.Tables["AuditTable"].Rows.Count;
            count = rec_cnt;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["AuditTable"].Rows)
                {
                    Audit myTd = new Audit();
                    myTd.AuditId = Convert.ToInt32(row["AuditId"]);
                    myTd.ActionType = row["ActionType"].ToString();
                    myTd.ActionDate = row["ActionDate"].ToString();
                    myTd.StaffID = row["StaffID"].ToString();
                    myTd.AdminNo = row["AdminNo"].ToString();
                    myTd.IPAddress = row["IPAddress"].ToString();
                    myTd.TableName = row["TableName"].ToString();
                    myTd.RecNumber = Convert.ToInt32(row["RecNumber"]);
                    myTd.IsBanned = row["IsBanned"].ToString();
                    rteList.Add(myTd);
                }
            }
            else
            {
                rteList = null;
            }

            return rteList;
        }

        public Audit getAuditById(String AuditId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            StringBuilder StudentCommand = new StringBuilder();
            StudentCommand.AppendLine("Select * from AuditLog where ");
            StudentCommand.AppendLine("Auditid = @paraAuditId");
            Audit obj = new Audit();

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(StudentCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("paraAuditId", AuditId);
            // fill dataset
            da.Fill(ds, "AuditTable");
            int rec_cnt = ds.Tables["AuditTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["AuditTable"].Rows[0];  // Sql command returns only one record
                obj.AuditId = Convert.ToInt32(row["AuditId"]);
                obj.ActionType = row["ActionType"].ToString();
                obj.ActionDate = row["ActionDate"].ToString();
                obj.StaffID = row["StaffID"].ToString();
                obj.AdminNo = row["AdminNo"].ToString();
                obj.IPAddress = row["IPAddress"].ToString();
                obj.TableName = row["TableName"].ToString();
                obj.RecNumber = Convert.ToInt32(row["RecNumber"]);
                obj.IsBanned = row["IsBanned"].ToString();

            }
            else
            {
                obj = null;
                System.Diagnostics.Debug.WriteLine(obj + "this is from studentDAO part 2");
            }

            return obj;
        }

        public int InsertAudit(string ActionType, string ActionDate, string StaffID, string AdminNo, string IPAddress, string TableName, int RecNumber, string IsBanned)
        {
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();
            // Step1 : Create SQL insert command to add record to TDMaster using     
            //         parameterised query in values clause
           
            sqlStr.AppendLine("INSERT INTO AuditLog (ActionType, ActionDate, StaffID, AdminNo, IPAddress, TableName, RecNumber, IsBanned) ");
            sqlStr.AppendLine("VALUES (@paraActionType, @paraActionDate, @paraStaffID, @paraAdminNo, @paraIPAddress, @paraTableName, @paraRecNumber, @paraIsBanned)");


            // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            // Step 3 : Add each parameterised query variable with value
            //          complete to add all parameterised queries
            sqlCmd.Parameters.AddWithValue("@paraActionType", ActionType );
            sqlCmd.Parameters.AddWithValue("@paraActionDate", ActionDate );
            sqlCmd.Parameters.AddWithValue("@paraStaffID", StaffID );
            sqlCmd.Parameters.AddWithValue("@paraAdminNo", AdminNo );
            sqlCmd.Parameters.AddWithValue("@paraIPAddress", IPAddress );
            sqlCmd.Parameters.AddWithValue("@paraTableName", TableName );
            sqlCmd.Parameters.AddWithValue("@paraRecNumber", RecNumber );
            sqlCmd.Parameters.AddWithValue("@paraIsBanned", IsBanned);

            // Step 4 Open connection the execute NonQuery of sql command   

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;

        }

        public int delete(int AuditId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();
            // Step1 : Create SQL insert command to add record to TDMaster using     
            //         parameterised query in values clause
            
            sqlStr.AppendLine("DELETE FROM AuditLog");
            sqlStr.AppendLine("WHERE AuditId = @paraAuditId");


            // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            // Step 4 Open connection the execute NonQuery of sql command   

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;

        }
    }
}