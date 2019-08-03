using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace eadLab5.DAL
{
    public class Audit
    {
        public int AuditId { get; set; }
        public string ActionType { get; set; }
        public string ActionDate { get; set; }
        public string StaffID { get; set; }
        public string AdminNo { get; set; }
        public string IPAddress { get; set; }
        public string TableName { get; set; }
        public int RecNumber { get; set; }
        public string IsBanned { get; set; }
        public string GetIPAddress()
        {
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    IPAddress = Convert.ToString(IP);
                }
            }
            return IPAddress;
        }
    }
}