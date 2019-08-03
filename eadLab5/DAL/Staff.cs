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
    public class Staff
    {
        public Staff()
        {
        }
        public string Staffid { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string School { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string Honorifics { get; set; }

        public List<Staff> getAllstaff()
        {
            List<Staff> staffList = new List<Staff>();
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            StringBuilder StudentCommand = new StringBuilder();
            StudentCommand.AppendLine("Select * from Staff");

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(StudentCommand.ToString(), myConn);
            // fill dataset
            da.Fill(ds, "StaffTable");
            int rec_cnt = ds.Tables["StaffTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["StaffTable"].Rows)
                {
                    Staff obj = new Staff();

                    obj.Staffid = row["Staffid"].ToString();
                    obj.Name = row["Name"].ToString();
                    obj.Surname = row["Surname"].ToString();
                    obj.School = row["School"].ToString();
                    obj.Email = row["Email"].ToString();
                    obj.Role = row["Role"].ToString();
                    obj.Password = row["Password"].ToString();
                    obj.Honorifics = row["Honorifics"].ToString();
                    staffList.Add(obj);

                }

            }
            return staffList;
        }
    }
}