using System;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;
namespace eadLab5.DAL
{
    public class StudentProfileDAO
    {
        public StudentProfile getStudentById(String AdminNo)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            StringBuilder StudentCommand = new StringBuilder();
            StudentCommand.AppendLine("Select * from Student where ");
            StudentCommand.AppendLine("AdminNo = @paraAdminNo");
            StudentProfile obj = new StudentProfile();

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
                obj.HpNumber = Convert.ToInt32(row["HpNumber"].ToString());
                obj.Email = row["Email"].ToString();
                obj.PEMClass = row["PEMClass"].ToString();
                obj.ProfilePicture = row["ProfilePicture"].ToString();
            }
            else
            {
                obj = null;
            }

            return obj;
        }
        public int updateTD(String AdminNo, String StudentName, String MedicalCondition, String MedicalHistory, String Summary, int HpNumber, String Email, String Img)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();
            // Step1 : Create SQL insert command to add record to TDMaster using     

            //         parameterised query in values clause
            //
            sqlStr.AppendLine("UPDATE Student");
            sqlStr.AppendLine("SET StudentName = @paraStudentName, MedicalCondition = @paraMedicalCondition, MedicalHistory =@paraMedicalHistory, Summary=@paraSummary, HpNumber=@paraHpNumber, Email=@paraEmail, ProfilePicture = @paraImg ");
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
            sqlCmd.Parameters.AddWithValue("@paraHpNumber", HpNumber);
            sqlCmd.Parameters.AddWithValue("@paraEmail", Email);
            sqlCmd.Parameters.AddWithValue("@paraImg", Img);
            // Step 4 Open connection the execute NonQuery of sql command   


            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;

        }

        public int ChangePw(String AdminNo, String password)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();
            // Step1 : Create SQL insert command to add record to TDMaster using     

            //         parameterised query in values clause
            //
            sqlStr.AppendLine("UPDATE Student");
            sqlStr.AppendLine("SET Password = @parapassword");
            sqlStr.AppendLine("where AdminNo = @paraAdminNo");


            // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            // Step 3 : Add each parameterised query variable with value
            //          complete to add all parameterised queries
            sqlCmd.Parameters.AddWithValue("@paraAdminNo", AdminNo);
            sqlCmd.Parameters.AddWithValue("@parapassword", password);
            // Step 4 Open connection the execute NonQuery of sql command   


            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;

        }

    }
}