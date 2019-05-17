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
    public class AchievementDAO
    {
        public int count = 0;

        public List<Achievement> getAchievement(string AdminNo)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            List<Achievement> tdList = new List<Achievement>();

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            StringBuilder AchievementCommand = new StringBuilder();
            AchievementCommand.AppendLine("Select * from Achievement where");
            AchievementCommand.AppendLine("AdminNo = @paraAdminNo");
            Achievement obj = new Achievement();

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(AchievementCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("paraAdminNo", AdminNo);
            da.Fill(ds, "AchievementTable");

            int rec_cnt = ds.Tables["AchievementTable"].Rows.Count;
            count = rec_cnt;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["AchievementTable"].Rows)
                {
                    Achievement myTd = new Achievement();

                    myTd.AchievementName = row["AchievementName"].ToString(); ;
                    myTd.AyearTaken = Convert.ToInt32(row["AyearTaken"]);
                    myTd.AdminNo = row["AdminNo"].ToString();
                    myTd.Status = row["Status"].ToString();
                    tdList.Add(myTd);
                }
            }
            else
            {
                tdList = null;
            }

            return tdList;
        }
    }
}