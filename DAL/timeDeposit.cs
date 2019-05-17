using System;
using System.Linq;
using System.Web;

namespace eadLab5.DAL
{
      public class timeDeposit
    {
        public string tdAccount { get; set; }
        public string tdCustId { get; set; }
        public double tdPrincipal { get; set; }
        public int tdTerm { get; set; }
        public DateTime tdEffDte { get; set; }
        public DateTime tdMaturityDte { get; set; }
        public double tdInterest { get; set; }
        public double tdMaturedAmt { get; set; }
        public float tdIntRte { get; set; }
        public int tdRenewMode { get; set; }

    }
}