using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eadLab5.DAL
{
    public class WaitingList
    {
        public WaitingList()
        {
        }
        public string name { get; set; }
        public int precedence { get; set; }
        public string remarks { get; set; }
    }
}