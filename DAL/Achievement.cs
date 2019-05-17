using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eadLab5.DAL
{
    public class Achievement
    {
        public Achievement()
        {
        }
        public String AchievementName { get; set; }
        public int AyearTaken { get; set; }
        public String AdminNo { get; set; }
        public String Status { get; set; }
    }
}