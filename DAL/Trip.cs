using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eadLab5.DAL
{
    public class Trip
    {
        public Trip()
        {

        }
        public int tripId { get; set; }
        public string tripTitle { get; set; }
        public string tripLocation { get; set; }
        public string tripActivities { get; set; }
        public int tripDays { get; set; }
        public double tripCost { get; set; }
        public string tripImg { get; set; }
        public string tripType { get; set; }
        public DateTime tripStart { get; set; }
        public DateTime tripEnd { get; set; }
        public string tripStatus { get; set; }
        public int staffId { get; set; }
    }
}