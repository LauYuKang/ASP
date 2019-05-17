using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eadLab5.DAL
{
    public class customer
    {
        public customer()
        {
        }
        public string customerId { get; set; }
        public string customerName { get; set; }
        public string customerAddress { get; set; }
        public string customerHomePhone { get; set; }
        public string customerMobile { get; set; }

    }
}