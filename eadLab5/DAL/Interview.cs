using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eadLab5.DAL
{
    public class Interview
    {
        public Interview()
        {

        }
        public string studentName { get; set; }
        public string studentPic { get; set; }
        public string tripName { get; set; }
        public string tripLocation { get; set; }
        public DateTime tripStart { get; set; }
        public DateTime tripEnd { get; set; }
        public int interviewId { get; set; }
        public string interviewDate { get; set; }
        public string interviewTime { get; set; }
        public string interviewSession { get; set; }
        public string interviewToken { get; set; }
        public string staffName { get; set; }
        public string staffHonorifics { get; set; }
        public string studentAdminNo { get; set; }
        public string remarks { get; set; }
        public int tripid { get; set; }
    }
}