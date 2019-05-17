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
    public class StudentLoginDAO
    {
        public StudentLogin getStudentById(string AdminNo, string password)
        {

            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //Create Adapter
            //WRITE SQL Statement to retrieve all columns from Customer by customer Id using query parameter
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select * from Student where");
            sqlCommand.AppendLine("AdminNo = @paraAdminNo AND ");
            sqlCommand.AppendLine("Password = @paraPassword");
            //***TO Simulate system error  *****
            // change custId in where clause to custId1 or 
            // change connection string in web config to a wrong file name  

            StudentLogin obj = new StudentLogin();   // create a customer instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraAdminNo", AdminNo);
            da.SelectCommand.Parameters.AddWithValue("@paraPassword", password);

            // fill dataset
            da.Fill(ds, "custTable");
            int rec_cnt = ds.Tables["custTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["custTable"].Rows[0];  // Sql command returns only one record
                obj.AdminNo = row["AdminNo"].ToString();
                obj.Password = row["Password"].ToString();
                
            }
            else
            {
                obj = null;
            }

            return obj;
        }
        public StudentLogin getStudentByPEM(string PEMClass)
        {

            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //Create Adapter
            //WRITE SQL Statement to retrieve all columns from Customer by customer Id using query parameter
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select * from Student where");
            sqlCommand.AppendLine("PEMClass = @paraPEMClass");
            //***TO Simulate system error  *****
            // change custId in where clause to custId1 or 
            // change connection string in web config to a wrong file name  

            StudentLogin obj = new StudentLogin();   // create a customer instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraPEMClass", PEMClass);

            // fill dataset
            da.Fill(ds, "custTable");
            int rec_cnt = ds.Tables["custTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["custTable"].Rows[0];  // Sql command returns only one record
                obj.AdminNo = row["AdminNo"].ToString();
                obj.Password = row["Password"].ToString();
            }
            else
            {
                obj = null;
            }

            return obj;
        }
    }
}