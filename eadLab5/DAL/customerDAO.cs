using System;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;

namespace eadLab5.DAL
{
    public class customerDAO
    {
        public customer getCustomerById(string custId)
        {
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //Create Adapter
            //WRITE SQL Statement to retrieve all columns from Customer by customer Id using query parameter
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select * from saleslt.Customer where");
            sqlCommand.AppendLine("customerId = @paraCustId");
            //***TO Simulate system error  *****
            // change custId in where clause to custId1 or 
            // change connection string in web config to a wrong file name  

            customer obj = new customer();   // create a customer instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("paraCustId", custId);
            // fill dataset
            da.Fill(ds, "custTable");
            int rec_cnt = ds.Tables["custTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["custTable"].Rows[0];  // Sql command returns only one record
                obj.customerId = row["customerId"].ToString();
                obj.customerName = row["namestyle"].ToString();
                obj.customerAddress = row["Title"].ToString();
                obj.customerMobile = row["phone"].ToString();
                obj.customerHomePhone = row["firstname"].ToString();
            }
            else
            {
                obj = null;
            }

            return obj;
        }

    }
}