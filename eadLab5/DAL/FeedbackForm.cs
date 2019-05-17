using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eadLab5.DAL
{
    public class FeedbackForm
    {
        public FeedbackForm()
        {
        }
        public string Affordability { get; set; }
        public string Enjoyment { get; set; }
        public string Freedom { get; set; }
        public string ReviewPros { get; set; }
        public string ReviewCons { get; set; }
        public string ReviewImprovement { get; set; }
        public int TripId { get; set; }
        public string StudentName { get; set; }
        public string AdminNo { get; set; }
        public string Country { get; set; }
        public int FeedBackId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string FBid { get; set; }
        public string TripTitle { get; set; }
        public string TimeRange { get; set; }
        public string location { get; set; }
        public string DateCreated { get; set; }

    }

}