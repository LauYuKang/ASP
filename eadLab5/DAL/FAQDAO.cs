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
    public class FAQDAO
    {
        public int count = 0;
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        public List<FAQ> getFAQ()
        {

            List<FAQ> tdList = new List<FAQ>();

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            StringBuilder FAQCommand = new StringBuilder();
            FAQCommand.AppendLine("Select * from FAQ ");
            FAQ obj = new FAQ();

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(FAQCommand.ToString(), myConn);
            da.Fill(ds, "FAQTable");

            int rec_cnt = ds.Tables["FAQTable"].Rows.Count;
            count = rec_cnt;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["FAQTable"].Rows)
                {
                    FAQ myTd = new FAQ();

                    myTd.FaqId = Convert.ToInt32(row["FaqId"]);
                    myTd.StaffId = Convert.ToInt32(row["StaffId"]);
                    myTd.Question = row["Question"].ToString(); ;
                    myTd.Ans = row["Ans"].ToString();
                    tdList.Add(myTd);
                }
            }
            else
            {
                tdList = null;
            }

            return tdList;
        }

        public int InsertTD(int StaffId, String Question, String Ans)
        {

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();
            // Step1 : Create SQL insert command to add record to TDMaster using     

            //         parameterised query in values clause
            //
            sqlStr.AppendLine("INSERT INTO FAQ (StaffId, Question, Ans) ");
            sqlStr.AppendLine("VALUES (@paraStaffId,@paraQuestion, @paraAns)");


            // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            // Step 3 : Add each parameterised query variable with value
            //          complete to add all parameterised queries
            sqlCmd.Parameters.AddWithValue("@paraStaffId", StaffId);
            sqlCmd.Parameters.AddWithValue("@paraQuestion", Question);
            sqlCmd.Parameters.AddWithValue("@paraAns", Ans);


            // Step 4 Open connection the execute NonQuery of sql command   

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;

        }

    }
}