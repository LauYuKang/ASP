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

    }
}


