using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eadLab5.DAL
{
    public class StaffLogin
    {
        public StaffLogin()
        {
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Staffid { get; set; }
        public string Surname { get; set; }
        public string School { get; set; }
        public string Role { get; set; }
        public string PEMClass { get; set; }
        public string Name { get; set; }
    }
}