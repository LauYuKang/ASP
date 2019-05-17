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
    public class FeedbackFormDAO
    {
        // Place the DBConnect to class variable to be shared by all the methodsin this class
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        public int InsertTD(string Affordability, string Enjoyment, string Freedom, string ReviewPros, string ReviewCons, string ReviewImprovement, string StudentName, string Country, string AdminNo, int TripId, string DateCreated)
        {

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();
            // Step1 : Create SQL insert command to add record to TDMaster using     

            //         parameterised query in values clause
            //
            sqlStr.AppendLine("INSERT INTO FeedBack(Affordability,Enjoyment,Freedom,ReviewPros,ReviewCons,ReviewImprovement, StudentName, Country, AdminNo, TripId, DateCreated) ");
            sqlStr.AppendLine("VALUES (@paraAffordability,@paraEnjoyment,@paraFreedom,@paraReviewPros,@paraReviewCons,@paraReviewImprovement,@paraStudentName,@paraCountry,@paraAdminNo,@paraTripId, @paraDateCreated)");

            // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            // Step 3 : Add each parameterised query variable with value
            //          complete to add all parameterised queries
            sqlCmd.Parameters.AddWithValue("@paraAffordability", Affordability);
            sqlCmd.Parameters.AddWithValue("@paraEnjoyment", Enjoyment);
            sqlCmd.Parameters.AddWithValue("@paraFreedom", Freedom);
            sqlCmd.Parameters.AddWithValue("@paraReviewPros", ReviewPros);
            sqlCmd.Parameters.AddWithValue("@paraReviewCons", ReviewCons);
            sqlCmd.Parameters.AddWithValue("@paraReviewImprovement", ReviewImprovement);

            sqlCmd.Parameters.AddWithValue("@paraStudentName", StudentName);
            sqlCmd.Parameters.AddWithValue("@paraCountry", Country);
            sqlCmd.Parameters.AddWithValue("@paraAdminNo", AdminNo);
            sqlCmd.Parameters.AddWithValue("@paraTripId", TripId);
            sqlCmd.Parameters.AddWithValue("@paraDateCreated", DateCreated);


            // Step 4 Open connection the execute NonQuery of sql command   

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;

        }

        public FeedbackForm GetSpecificFeedBack(string FeedBackId)
        {
            // Step 2 : declare a list to hold collection of customer's timeDeposit
            //           DataSet instance and dataTable instance 

            FeedbackForm td = new FeedbackForm();
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();
            //
            // Step 3 :Create SQLcommand to select all columns from TDMaster by parameterised customer id
            //          where TD is not matured yet

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * From FeedBack");
            sqlStr.AppendLine("where FeedBackId = @paraFeedBackId");


            // Step 4 :Instantiate SqlConnection instance and SqlDataAdapter instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            // Step 5 :add value to parameter 

            da.SelectCommand.Parameters.AddWithValue("paraFeedBackId", FeedBackId);

            // Step 6: fill dataset
            da.Fill(ds, "TableTD");

            // Step 7: Iterate the rows from TableTD above to create a collection of TD
            //         for this particular customer 



            int rec_cnt = ds.Tables["TableTD"].Rows.Count;
            FeedbackForm myTD = new FeedbackForm();
            if (rec_cnt > 0)
            {

                // Step 8 Set attribute of timeDeposit instance for the record in TableTD
                // DataRow is set to Rows[0] because only one row is returned
                //
                DataRow row = ds.Tables["TableTD"].Rows[0];
                myTD.Affordability = row["Affordability"].ToString();
                myTD.Enjoyment = row["Enjoyment"].ToString();
                myTD.Freedom = row["Freedom"].ToString();
                myTD.ReviewPros = row["ReviewPros"].ToString();
                myTD.ReviewCons = row["ReviewCons"].ToString();
                myTD.ReviewImprovement = row["ReviewImprovement"].ToString();
                myTD.AdminNo = row["AdminNo"].ToString();
                myTD.TripId = Convert.ToInt32(row["TripId"]);
                myTD.Country = row["Country"].ToString();
                myTD.StudentName = row["StudentName"].ToString();

            }

            else
            {
                myTD = null;
            }
            return myTD;
        }

        public List<FeedbackForm> GetAllFeedBack()
        {
            // Step 2 : declare a list to hold collection of customer's timeDeposit
            //           DataSet instance and dataTable instance 

            List<FeedbackForm> tdList = new List<FeedbackForm>();
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();
            //
            // Step 3 :Create SQLcommand to select all columns from TDMaster by parameterised customer id
            //          where TD is not matured yet

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * From FeedBack");
           

            // Step 4 :Instantiate SqlConnection instance and SqlDataAdapter instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            // Step 5 :add value to parameter 
            // Step 6: fill dataset
            da.Fill(ds, "TableTD");

            // Step 7: Iterate the rows from TableTD above to create a collection of TD
            //         for this particular customer 

            int rec_cnt = ds.Tables["TableTD"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["TableTD"].Rows)
                {
                    FeedbackForm myTD = new FeedbackForm();

                    // Step 8 Set attribute of timeDeposit instance for each row of record in TableTD

                    myTD.Affordability = row["Affordability"].ToString();
                    myTD.Enjoyment = row["Enjoyment"].ToString();
                    myTD.Freedom = row["Freedom"].ToString();
                    myTD.ReviewPros = row["ReviewPros"].ToString();
                    myTD.ReviewCons = row["ReviewCons"].ToString();
                    myTD.ReviewImprovement = row["ReviewImprovement"].ToString();
                    myTD.AdminNo = row["AdminNo"].ToString();
                    myTD.TripId = Convert.ToInt32(row["TripId"]);
                    myTD.Country = row["Country"].ToString();
                    myTD.StudentName = row["StudentName"].ToString();
                    myTD.FeedBackId = Convert.ToInt16(row["FeedBackId"]);

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
        

        public List<FeedbackForm> GetFilteredFeedBacks(string Country, string Affordability, string Freedom, string DateStart, string DateEnd)
        {
            // Step 2 : declare a list to hold collection of customer's timeDeposit
            //           DataSet instance and dataTable instance 

            List<FeedbackForm> tdList = new List<FeedbackForm>();
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();
            //
            // Step 3 :Create SQLcommand to select all columns from TDMaster by parameterised customer id
            //          where TD is not matured yet

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * From FeedBack");
            sqlStr.AppendLine("WHERE Country = @paraCountry and Affordability = @paraAffordability and Freedom = @paraFreedom and DateCreated BETWEEN @paraDateStart and @paraDateEnd");

            // Step 4 :Instantiate SqlConnection instance and SqlDataAdapter instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            // Step 5 :add value to parameter 
            da.SelectCommand.Parameters.AddWithValue("paraCountry", Country);
            da.SelectCommand.Parameters.AddWithValue("paraAffordability", Affordability);
            da.SelectCommand.Parameters.AddWithValue("paraFreedom", Freedom);
            da.SelectCommand.Parameters.AddWithValue("paraDateStart", DateStart);
            da.SelectCommand.Parameters.AddWithValue("paraDateEnd", DateEnd);

            // Step 6: fill dataset
            da.Fill(ds, "TableTD");

            // Step 7: Iterate the rows from TableTD above to create a collection of TD
            //         for this particular customer 

            int rec_cnt = ds.Tables["TableTD"].Rows.Count;
            FeedbackForm myTD = new FeedbackForm();
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["TableTD"].Rows)
                {
                    // Step 8 Set attribute of timeDeposit instance for the record in TableTD
                    // DataRow is set to Rows[0] because only one row is returned

                    myTD.Affordability = row["Affordability"].ToString();
                    myTD.Enjoyment = row["Enjoyment"].ToString();
                    myTD.Freedom = row["Freedom"].ToString();
                    myTD.ReviewPros = row["ReviewPros"].ToString();
                    myTD.ReviewCons = row["ReviewCons"].ToString();
                    myTD.ReviewImprovement = row["ReviewImprovement"].ToString();
                    myTD.AdminNo = row["AdminNo"].ToString();
                    myTD.TripId = Convert.ToInt32(row["TripId"]);
                    myTD.Country = row["Country"].ToString();
                    myTD.StudentName = row["StudentName"].ToString();
                    tdList.Add(myTD);
                }

            }

            else
            {
                myTD = null;
            }
            return tdList;
        }


        public List<FeedbackForm> GetOwnFeedBack(string AdminNo)
        {
            // Step 2 : declare a list to hold collection of customer's timeDeposit
            //           DataSet instance and dataTable instance 

            List<FeedbackForm> tdList = new List<FeedbackForm>();
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();
            //
            // Step 3 :Create SQLcommand to select all columns from TDMaster by parameterised customer id
            //          where TD is not matured yet

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * From FeedBack");
            sqlStr.AppendLine("where AdminNo = @paraAdminNo");
           


            // Step 4 :Instantiate SqlConnection instance and SqlDataAdapter instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            // Step 5 :add value to parameter 

            da.SelectCommand.Parameters.AddWithValue("paraAdminNo", AdminNo);

            // Step 6: fill dataset
            da.Fill(ds, "TableTD");

            // Step 7: Iterate the rows from TableTD above to create a collection of TD
            //         for this particular customer 

            int rec_cnt = ds.Tables["TableTD"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["TableTD"].Rows)
                {
                    FeedbackForm myTD = new FeedbackForm();

                    // Step 8 Set attribute of timeDeposit instance for each row of record in TableTD
                    
                    myTD.Affordability = row["Affordability"].ToString();
                    myTD.Enjoyment = row["Enjoyment"].ToString();
                    myTD.Freedom = row["Freedom"].ToString();
                    myTD.ReviewPros = row["ReviewPros"].ToString();
                    myTD.ReviewCons = row["ReviewCons"].ToString();
                    myTD.ReviewImprovement = row["ReviewImprovement"].ToString();
                    myTD.AdminNo = row["AdminNo"].ToString();
                    myTD.TripId = Convert.ToInt32(row["TripId"]);
                    myTD.Country = row["Country"].ToString();
                    myTD.StudentName = row["StudentName"].ToString();
                    myTD.FeedBackId = Convert.ToInt16(row["FeedBackId"]);

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

        public int updateOwnFB(string Affordability, string Enjoyment, string Freedom, string ReviewPros, string ReviewCons, string ReviewImprovement, string StudentName, string Country, string AdminNo, string TripId, string FeedBackId)
        {

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();
            // Step1 : Create SQL insert command to add record to TDMaster using     

            //         parameterised query in values clause
            //
            sqlStr.AppendLine("UPDATE FeedBack");
            sqlStr.AppendLine("SET Affordability=@paraAffordability, Enjoyment=@paraEnjoyment, Freedom=@paraFreedom, ReviewPros=@paraReviewCons, ReviewImprovement=@paraReviewImprovement, StudentName=@paraStudentName, Country=@paraCountry, AdminNo=@paraAdminNo, TripId=@paraTripId ");
            sqlStr.AppendLine("WHERE FeedBackId = @paraFeedBackId");


            // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            // Step 3 : Add each parameterised query variable with value
            //          complete to add all parameterised queries
            sqlCmd.Parameters.AddWithValue("@paraAffordability", Affordability);
            sqlCmd.Parameters.AddWithValue("@paraEnjoyment", Enjoyment);
            sqlCmd.Parameters.AddWithValue("@paraFreedom", Freedom);
            sqlCmd.Parameters.AddWithValue("@paraReviewPros", ReviewPros);
            sqlCmd.Parameters.AddWithValue("@paraReviewCons", ReviewCons);
            sqlCmd.Parameters.AddWithValue("@paraReviewImprovement", ReviewImprovement);

            sqlCmd.Parameters.AddWithValue("@paraStudentName", StudentName);
            sqlCmd.Parameters.AddWithValue("@paraCountry", Country);
            sqlCmd.Parameters.AddWithValue("@paraAdminNo", AdminNo);
            sqlCmd.Parameters.AddWithValue("@paraTripId", TripId);
            sqlCmd.Parameters.AddWithValue("@paraFeedBackId", FeedBackId);

            // Step 4 Open connection the execute NonQuery of sql command   

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;

        }


    }
}

