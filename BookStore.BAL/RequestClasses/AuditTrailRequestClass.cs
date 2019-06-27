using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BAL.RequestClasses
{
    public class AuditTrailRequestClass
    {
        public Guid auditlogid { get; set; }
        public string userid { get; set; }
        public DateTime eventdateutc { get; set; }
        public string eventtype { get; set; }
        public string tablename { get; set; }
        public string recordid { get; set; }
        public string columnname { get; set; }
        public string originalvalue { get; set; }
        public string newvalue { get; set; }
    }
}
