using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eadLab5.DAL
{
    public class FAQ
    {
        public FAQ()
        {
        }

        public int FaqId { get; set; }
        public int StaffId { get; set; }
        public String Question { get; set; }
        public String Ans { get; set; }
    }
}