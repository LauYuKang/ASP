using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eadLab5.DAL
{
    public class Choice
    {
        public Choice()
        {

        }
        public string tripName { get; set; }
        public string choice { get; set; }
        public DateTime tripStart { get; set; }
        public DateTime tripEnd { get; set; }
        public string teacherChoice { get; set; }
    }
}