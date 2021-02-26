using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebAPISupport.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeService = new HashSet<EmployeeService>();
            InverseEmployeeSupervisorNavigation = new HashSet<Employee>();
            Issue = new HashSet<Issue>();
            Note = new HashSet<Note>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePassword { get; set; }
        public string EmployeeOccupation { get; set; }
        public int EmployeeSupervisor { get; set; }
        public string Status { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int? UserCreation { get; set; }
        public int? ModificationUser { get; set; }

        public virtual Employee EmployeeSupervisorNavigation { get; set; }
        public virtual ICollection<EmployeeService> EmployeeService { get; set; }
        public virtual ICollection<Employee> InverseEmployeeSupervisorNavigation { get; set; }
        public virtual ICollection<Issue> Issue { get; set; }
        public virtual ICollection<Note> Note { get; set; }
    }
}
