using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPISupport.Models
{
    public partial class Service
    {
        public Service()
        {
            EmployeeServices = new HashSet<EmployeeService>();
            Issues = new HashSet<Issue>();
        }

        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Status { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int? UserCreation { get; set; }
        public int? ModificationUser { get; set; }

        public virtual ICollection<EmployeeService> EmployeeServices { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
    }
}
