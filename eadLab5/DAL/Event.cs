using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eadLab5.DAL
{
    public class Event
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string EyearTaken { get; set; }
        public string EsemTaken { get; set; }

        public string AdminNo { get; set; }

        public String Status { get; set; }

    }
}