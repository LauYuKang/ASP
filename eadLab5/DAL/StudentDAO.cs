using System;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;
using System.Collections.Generic;

namespace eadLab5.DAL
{
    public class StudentDAO
    {
        public Student getStudentById(String AdminNo)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            System.Diagnostics.Debug.WriteLine("fuck you junpoh");
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            StringBuilder StudentCommand = new StringBuilder();
            StudentCommand.AppendLine("Select * from Student where ");
            StudentCommand.AppendLine("AdminNo = @paraAdminNo");
            Student obj = new Student();

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(StudentCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("paraAdminNo", AdminNo);
            // fill dataset
            da.Fill(ds, "StudentTable");
            int rec_cnt = ds.Tables["StudentTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["StudentTable"].Rows[0];  // Sql command returns only one record
                obj.AdminNo = row["AdminNo"].ToString();
                obj.StudentName = row["StudentName"].ToString();
                obj.MedicalCondition = row["MedicalCondition"].ToString();
                obj.MedicalHistory = row["MedicalHistory"].ToString();
                obj.Gender = row["Gender"].ToString();
                obj.Diploma = row["Diploma"].ToString();
                obj.Summary = row["Summary"].ToString();
                obj.Achievement = row["Achievement"].ToString();
                obj.Email = row["Email"].ToString();
                obj.PEMClass = row["PEMClass"].ToString();
                obj.Year = Convert.ToInt32(row["Year"]);
                System.Diagnostics.Debug.WriteLine(obj.Year +"this is from studentDAO");
            }
            else
            {
                obj = null;
                System.Diagnostics.Debug.WriteLine(obj + "this is from studentDAO part 2");
            }

            return obj;
        }
        public int updateTD(String AdminNo,String StudentName, String MedicalCondition, String MedicalHistory, String Summary , String Email)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();
            // Step1 : Create SQL insert command to add record to TDMaster using     

            //         parameterised query in values clause
            //
            sqlStr.AppendLine("UPDATE Student");
            sqlStr.AppendLine("SET StudentName = @paraStudentName, MedicalCondition = @paraMedicalCondition, MedicalHistory =@paraMedicalHistory, Summary=@paraSummary, Email=@paraEmail ");
            sqlStr.AppendLine("where AdminNo = @paraAdminNo");


            // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            // Step 3 : Add each parameterised query variable with value
            //          complete to add all parameterised queries
            sqlCmd.Parameters.AddWithValue("@paraAdminNo", AdminNo);
            sqlCmd.Parameters.AddWithValue("@paraStudentName", StudentName);
            sqlCmd.Parameters.AddWithValue("@paraMedicalCondition", MedicalCondition);
            sqlCmd.Parameters.AddWithValue("@paraMedicalHistory", MedicalHistory);
            sqlCmd.Parameters.AddWithValue("@paraSummary", Summary);
            //sqlCmd.Parameters.AddWithValue("@paraHpNumber", HpNumber);
            sqlCmd.Parameters.AddWithValue("@paraEmail", Email);
            // Step 4 Open connection the execute NonQuery of sql command   


            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;

        }

        public List<Student> getAllstudent()
        {
            List<Student> studList = new List<Student>();
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            StringBuilder StudentCommand = new StringBuilder();
            StudentCommand.AppendLine("Select * from Student");

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(StudentCommand.ToString(), myConn);
            // fill dataset
            da.Fill(ds, "StudentTable");
            int rec_cnt = ds.Tables["StudentTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["StudentTable"].Rows)
                {
                    Student obj = new Student();

                    obj.AdminNo = row["AdminNo"].ToString();
                    obj.StudentName = row["StudentName"].ToString();
                    obj.MedicalCondition = row["MedicalCondition"].ToString();
                    obj.MedicalHistory = row["MedicalHistory"].ToString();
                    obj.Gender = row["Gender"].ToString();
                    obj.Diploma = row["Diploma"].ToString();
                    obj.Summary = row["Summary"].ToString();
                    obj.Achievement = row["Achievement"].ToString();
                    obj.Email = row["Email"].ToString();
                    obj.PEMClass = row["PEMClass"].ToString();
                    obj.Year = Convert.ToInt32(row["Year"]);
                    studList.Add(obj);

                }

            }
            return studList;
        }

        public int InsertTD(String AdminNo, String Password, int Year, String Email, String HpNumber, string salt, string EmailVerified)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();
            // Step1 : Create SQL insert command to add record to TDMaster using     

            //         parameterised query in values clause
            //
            sqlStr.AppendLine("INSERT INTO Student (AdminNo, Password, Year, Email, HpNumber, Salt, EmailVerified) ");
            sqlStr.AppendLine("VALUES (@paraAdmin,@paraPassword,@paraYear, @paraEmail, @paraHpNumber, @parasalt, @paraEmailVerified)");


            // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            // Step 3 : Add each parameterised query variable with value
            //          complete to add all parameterised queries
            sqlCmd.Parameters.AddWithValue("@paraAdmin", AdminNo);
            sqlCmd.Parameters.AddWithValue("@paraYear", Year);
            sqlCmd.Parameters.AddWithValue("@paraPassword", Password);
            sqlCmd.Parameters.AddWithValue("@paraEmail", Email);
            sqlCmd.Parameters.AddWithValue("@paraHpNumber", HpNumber);
            sqlCmd.Parameters.AddWithValue("@parasalt", salt);
            sqlCmd.Parameters.AddWithValue("@paraEmailVerified", EmailVerified);

            // Step 4 Open connection the execute NonQuery of sql command   

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;

        }

        public int updateVerified(String AdminNo, String EmailVerified)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();
            // Step1 : Create SQL insert command to add record to TDMaster using     

            //         parameterised query in values clause
            //
            sqlStr.AppendLine("UPDATE Student");
            sqlStr.AppendLine("SET EmailVerified = @paraEmailVerified ");
            sqlStr.AppendLine("where AdminNo = @paraAdminNo");


            // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            // Step 3 : Add each parameterised query variable with value
            //          complete to add all parameterised queries
            sqlCmd.Parameters.AddWithValue("@paraAdminNo", AdminNo);
            sqlCmd.Parameters.AddWithValue("@paraEmailVerified", EmailVerified);



            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;

        }
        public Student getEmailVerified(string adminNo)
        {
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //Create Adapter
            //WRITE SQL Statement to retrieve all columns from Customer by customer Id using query parameter
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select EmailVerified from Student where");
            sqlCommand.AppendLine("AdminNo = @paraadminNo");
            //***TO Simulate system error  *****
            // change custId in where clause to custId1 or 
            // change connection string in web config to a wrong file name  

            Student obj = new Student();   // create a customer instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraadminNo", adminNo);

            // fill dataset
            da.Fill(ds, "custTable");
            int rec_cnt = ds.Tables["custTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["custTable"].Rows[0];  // Sql command returns only one record
                obj.EmailVerified = row["EmailVerified"].ToString();
            }
            else
            {
                obj = null;
            }

            return obj;
        }

        //public int updateVerifiedTime(String AdminNo)
        //{
        //    string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        //    StringBuilder sqlStr = new StringBuilder();
        //    int result = 0;    // Execute NonQuery return an integer value
        //    SqlCommand sqlCmd = new SqlCommand();
        //    // Step1 : Create SQL insert command to add record to TDMaster using     

        //    //         parameterised query in values clause
        //    //
        //    sqlStr.AppendLine("UPDATE Student");
        //    sqlStr.AppendLine("SET EmailVerifiedTime = @paraEmailVerified ");
        //    sqlStr.AppendLine("where AdminNo = @paraAdminNo");


        //    // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

        //    SqlConnection myConn = new SqlConnection(DBConnect);

        //    sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

        //    // Step 3 : Add each parameterised query variable with value
        //    //          complete to add all parameterised queries
        //    sqlCmd.Parameters.AddWithValue("@paraEmailVerifiedTime", DateTime.Now);



        //    myConn.Open();
        //    result = sqlCmd.ExecuteNonQuery();

        //    // Step 5 :Close connection
        //    myConn.Close();

        //    return result;

        //}

        //public DateTime getVerifiedTime(string adminNo)
        //{
        //    string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        //    SqlDataAdapter da;
        //    DataSet ds = new DataSet();

        //    StringBuilder StudentCommand = new StringBuilder();
        //    StudentCommand.AppendLine("Select EmailVerifiedTime from Student");
        //    StudentCommand.AppendLine("where AdminNo = @paraAdminNo");

        //    SqlConnection myConn = new SqlConnection(DBConnect);
        //    da = new SqlDataAdapter(StudentCommand.ToString(), myConn);

        //    // Step 6: fill dataset
        //    da.Fill(ds, "TableTD");

        //    // Step 7: Iterate the rows from TableTD above to create a collection of TD
        //    //         for this particular customer 
        //    Student dl = new Student();
        //    int rec_cnt = ds.Tables["TableTD"].Rows.Count;
        //    if (rec_cnt > 0)
        //    {
        //        DataRow row = ds.Tables["StudentTable"].Rows[0];  // Sql command returns only one record
        //        dl.EmailVerifiedTime = Convert.ToDateTime(row["EmailVerifiedTime"]);
        //    }

        //    return dl;
        //}

    }
}


