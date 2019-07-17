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

        public int InsertAudit(string ActionType, DateTime ActionDate, string StaffID, string AdminNo, string IPAddress, string TableName, int RecNumber)
        {
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();
            // Step1 : Create SQL insert command to add record to TDMaster using     
            //         parameterised query in values clause
           
            sqlStr.AppendLine("INSERT INTO AuditLog (ActionType, ActionDate, StaffID, AdminNo, IPAddress, TableName, RecNumber) ");
            sqlStr.AppendLine("VALUES (@paraActionType, @paraActionDate, @paraStaffID, @paraAdminNo, @paraIPAddress, @paraTableName, @paraRecNumber)");


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