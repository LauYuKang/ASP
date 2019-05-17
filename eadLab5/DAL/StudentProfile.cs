using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eadLab5.DAL
{
    public class StudentProfile
    {
        public StudentProfile()
        {
        }
        public String AdminNo { get; set; }
        public String StudentName { get; set; }
        public String Gender { get; set; }
        public String ProfilePicture { get; set; }
        public String MedicalCondition { get; set; }
        public String MedicalHistory { get; set; }
        public String Diploma { get; set; }
        public int tripId { get; set; }
        public String Password { get; set; }
        public int Year { get; set; }
        public String Summary { get; set; }
        public String Achievement { get; set; }
        public String EventsParticipated { get; set; }
        public int HpNumber { get; set; }
        public String Email { get; set; }
        public String Status { get; set; }
        public String PEMClass { get; set; }
    }
}