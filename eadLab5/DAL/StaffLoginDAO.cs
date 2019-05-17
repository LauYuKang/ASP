using eadLab5.DAL;
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
    public class StaffLoginDAO
    {
        
        public StaffLogin getStaffById(string Email, string password)
        {
            System.Diagnostics.Debug.WriteLine("this is from staffDAO");
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //Create Adapter
            //WRITE SQL Statement to retrieve all columns from Customer by customer Id using query parameter
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select * from Staff where");
            sqlCommand.AppendLine("Email = @paraEmail AND ");
            sqlCommand.AppendLine("Password = @paraPassword");
            //***TO Simulate system error  *****
            // change custId in where clause to custId1 or 
            // change connection string in web config to a wrong file name  

            StaffLogin obj = new StaffLogin();   // create a customer instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmail", Email);
            da.SelectCommand.Parameters.AddWithValue("@paraPassword", password);

            // fill dataset
            da.Fill(ds, "custTable");
            int rec_cnt = ds.Tables["custTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["custTable"].Rows[0];  // Sql command returns only one record
                obj.Staffid = row["Staffid"].ToString();
                obj.Name = row["Name"].ToString();
                obj.Surname = row["Surname"].ToString();
                obj.School = row["School"].ToString();
                obj.Email = row["Email"].ToString();
                obj.Role = row["Role"].ToString();
                obj.Password = row["Password"].ToString();
                //obj.PEMClass = row["PEMClass"].ToString();
            }
            else
            {
                obj = null;
            }
            
            return obj;
        }
    }
}