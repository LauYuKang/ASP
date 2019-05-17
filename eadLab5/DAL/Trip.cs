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
        public string staffName { get; set; }
        public string staffHonorifics { get; set; }
        public DateTime tripOpen { get; set; }
        public int RegisterId { get; set; }
        public int TripId { get; set; }
        public string AdminNo { get; set; }
        public string Reasons { get; set; }
        public int StaffId { get; set; }
        public string GenderType { get; set; }
        public string tripImg2 { get; set; }
        public string tripImg3 { get; set; }
    }
}