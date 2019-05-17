using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Collections.Generic;

namespace eadLab5.DAL
{
    public class timeDepositDAO
    {
        // Place the DBConnect to class variable to be shared by all the methodsin this class
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        public int InsertTD(String acNum, String customerId, double principal, int term, float tdIntRte, DateTime maturityDte, double maturedAmt, double tdInterest, int tdRenewMode)
        {

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();
            // Step1 : Create SQL insert command to add record to TDMaster using     

            //         parameterised query in values clause
            //
            sqlStr.AppendLine("INSERT INTO TDMaster (tdAccount, custId, principal, tdTerm, ");
            sqlStr.AppendLine("tdEffectFrom,tdMaturity,tdInterest,tdMaturedAmt,tdRate,tdRenewMode)");
            sqlStr.AppendLine("VALUES (@paraTdAccount,@paraCustId, @paraPrincipal, @paraTerm,");
            sqlStr.AppendLine("GETDATE(),@paraTdMaturity,@paraInterest,@paraMatureAmt,@paraTdRate,@paraRenewMode)");


            // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            // Step 3 : Add each parameterised query variable with value
            //          complete to add all parameterised queries
            sqlCmd.Parameters.AddWithValue("@paraTdAccount", acNum);
            sqlCmd.Parameters.AddWithValue("@paraCustId", customerId);
            sqlCmd.Parameters.AddWithValue("@paraPrincipal", principal);
            sqlCmd.Parameters.AddWithValue("@paraTerm", term);
            sqlCmd.Parameters.AddWithValue("@paraTdMaturity", maturityDte);
            sqlCmd.Parameters.AddWithValue("@paraInterest", tdInterest);
            sqlCmd.Parameters.AddWithValue("@paraMatureAmt", maturedAmt);
            sqlCmd.Parameters.AddWithValue("@paraTdRate", tdIntRte);
            sqlCmd.Parameters.AddWithValue("@paraRenewMode", tdRenewMode);

            // Step 4 Open connection the execute NonQuery of sql command   

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();
 
            return result;

        }

        public List<timeDeposit> getTDbyCustomerId(string customerId)
        {
            // Step 2 : declare a list to hold collection of customer's timeDeposit
            //           DataSet instance and dataTable instance 

            List<timeDeposit> tdList = new List<timeDeposit>();
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();
            //
            // Step 3 :Create SQLcommand to select all columns from TDMaster by parameterised customer id
            //          where TD is not matured yet

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * From TDMaster");
            sqlStr.AppendLine("where custId = @paraCustId");
            sqlStr.AppendLine("and tdMaturity >= GETDATE()");


            // Step 4 :Instantiate SqlConnection instance and SqlDataAdapter instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            // Step 5 :add value to parameter 

            da.SelectCommand.Parameters.AddWithValue("paraCustId", customerId);

            // Step 6: fill dataset
            da.Fill(ds, "TableTD");

            // Step 7: Iterate the rows from TableTD above to create a collection of TD
            //         for this particular customer 

            int rec_cnt = ds.Tables["TableTD"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["TableTD"].Rows)
                {
                    timeDeposit myTD = new timeDeposit();

                    // Step 8 Set attribute of timeDeposit instance for each row of record in TableTD

                    myTD.tdAccount = row["tdAccount"].ToString();
                    myTD.tdCustId = row["custId"].ToString();
                    myTD.tdPrincipal = Convert.ToDouble(row["principal"]);
                    myTD.tdTerm = Convert.ToInt32(row["tdTerm"]);
                    myTD.tdEffDte = Convert.ToDateTime(row["tdEffectFrom"]);
                    myTD.tdMaturityDte = Convert.ToDateTime(row["tdMaturity"]);
                    myTD.tdInterest = Convert.ToDouble(row["tdInterest"]);
                    myTD.tdMaturedAmt = Convert.ToDouble(row["tdMaturedAmt"]);
                    myTD.tdIntRte = Convert.ToSingle(row["tdRate"]);
                    myTD.tdRenewMode = Convert.ToInt32(row["tdRenewMode"]);

                    //  Step 9: Add each timeDeposit instance to array list
                    tdList.Add(myTD);
                }
            }
            else
            {
                tdList = null;
            }

            return tdList;
        }

        public timeDeposit getTDbyAccount(string tdAccount)
        {
            // Step 2 : declare a list to hold collection of customer's timeDeposit
            //           DataSet instance and dataTable instance 

            timeDeposit td = new timeDeposit();
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();
            //
            // Step 3 :Create SQLcommand to select all columns from TDMaster by parameterised customer id
            //          where TD is not matured yet

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * From TDMaster");
            sqlStr.AppendLine("where tdAccount = @paratdAccount");


            // Step 4 :Instantiate SqlConnection instance and SqlDataAdapter instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            // Step 5 :add value to parameter 

            da.SelectCommand.Parameters.AddWithValue("paratdAccount", tdAccount);

            // Step 6: fill dataset
            da.Fill(ds, "TableTD");

            // Step 7: Iterate the rows from TableTD above to create a collection of TD
            //         for this particular customer 

            

            int rec_cnt = ds.Tables["TableTD"].Rows.Count;
            timeDeposit myTD = new timeDeposit();
            if (rec_cnt > 0)
            {
               
                // Step 8 Set attribute of timeDeposit instance for the record in TableTD
                // DataRow is set to Rows[0] because only one row is returned
                //
                DataRow row = ds.Tables["TableTD"].Rows[0];
                myTD.tdAccount = row["tdAccount"].ToString();
                myTD.tdCustId = row["custId"].ToString();
                myTD.tdPrincipal = Convert.ToDouble(row["principal"]);
                myTD.tdTerm = Convert.ToInt32(row["tdTerm"]);
                myTD.tdEffDte = Convert.ToDateTime(row["tdEffectFrom"]);
                myTD.tdMaturityDte = Convert.ToDateTime(row["tdMaturity"]);
                myTD.tdInterest = Convert.ToDouble(row["tdInterest"]);
                myTD.tdMaturedAmt = Convert.ToDouble(row["tdMaturedAmt"]);
                myTD.tdIntRte = Convert.ToSingle(row["tdRate"]);
                myTD.tdRenewMode = Convert.ToInt32(row["tdRenewMode"]);

            }
        
     else
     {
     myTD = null;
     }
     return myTD;
    }
    public int updateTD(String acNum, int tdRenewMode)
    {

        StringBuilder sqlStr = new StringBuilder();
        int result = 0;    // Execute NonQuery return an integer value
        SqlCommand sqlCmd = new SqlCommand();
        // Step1 : Create SQL insert command to add record to TDMaster using     

        //         parameterised query in values clause
        //
        sqlStr.AppendLine("UPDATE TDMaster");
        sqlStr.AppendLine("SET tdRenewMode = @paratdRenewMode");
        sqlStr.AppendLine("WHERE tdAccount = @paraAcNum");


        // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

        SqlConnection myConn = new SqlConnection(DBConnect);

        sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            // Step 3 : Add each parameterised query variable with value
            //          complete to add all parameterised queries
            sqlCmd.Parameters.AddWithValue("@paraAcNum", acNum);
        sqlCmd.Parameters.AddWithValue("@paratdRenewMode", tdRenewMode);

        // Step 4 Open connection the execute NonQuery of sql command   

        myConn.Open();
        result = sqlCmd.ExecuteNonQuery();

        // Step 5 :Close connection
        myConn.Close();

        return result;

        }

    }

   

}