using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eadLab5.DAL
{
    public class StudentLogin
    {
        public StudentLogin() { }
        public string AdminNo { get; set; }
        public string StudentName { get; set; }
        public string Gender { get; set; }
        public string ProfilePicture { get; set; }
        public string MedicalCondition { get; set; }
        public string MedicalHistory { get; set; }
        public string Diploma { get; set; }
        public int TripId { get; set; }
        public string Password { get; set; }
        public string Year { get; set; }
        public string Summary { get; set; }
        public string Achievement { get; set; }
        public string EventsParticipated { get; set; }
        public int HpNumber { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string PEMClass { get; set; }
    }
}