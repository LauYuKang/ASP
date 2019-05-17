using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eadLab5.DAL
{
    public class RegStudent
    {
        public RegStudent()
        {

        }
        public int RegisterId { get; set; }
        public string name { get; set; }
        public string adminNo { get; set; }
        public string reason { get; set; }
        public string staff { get; set; }
    }
}