using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPISupport.Models
{
    public class Issue2
    {
        public int? ReportNumber { get; set; }
        public string Description { get; set; }
        public DateTime? Time { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ReportStatus { get; set; }
        public int? Id { get; set; }
        public int? IdS { get; set; }

    }
}
