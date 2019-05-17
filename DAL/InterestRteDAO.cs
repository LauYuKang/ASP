using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;

namespace eadLab5.DAL
{
    public class InterestRteDAO
    {
        public List<interestRte> getCurrentTdRte()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Step 1 : declare a List to hold collection of interestRte object
            List<interestRte> rteList = new List<interestRte>();

            // Step 2 :Retrieve connection string from web.config

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Step 3 :Create SQLcommand to select tdTerm and tdRate 
            //        from TDRate table where the rate is current
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("SELECT tdTerm, tdRate From TDRate ");
            sqlCommand.AppendLine("where GETDATE() between tdEffDte and tdExpiryDte");
           
            // Step 4 :Instantiate SqlConnection instance  
            SqlConnection myConn = new SqlConnection(DBConnect);
  
            // Step 5 :Retrieve record using DataAdapter
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
 
            // fill dataset to a table
            da.Fill(ds, "tdRateTable");
           
            // Step 6 : if there is no record in dataset, set the rteList to null
            int rec_cnt = ds.Tables["tdRateTable"].Rows.Count;
            if (rec_cnt==0)
            {
                rteList = null;
            }
            else
            { 
               // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
               //          create interestRte instance and add the instance to a List collection       

                foreach (DataRow row in ds.Tables["tdRateTable"].Rows)
                {
                    interestRte objRte = new interestRte();
                     objRte.tdTerm = Convert.ToInt32(row["tdTerm"]);
                    objRte.intRte = Convert.ToSingle(row["tdRate"]);
                    rteList.Add(objRte);
                }
             }
            return rteList;
        }
    }
}