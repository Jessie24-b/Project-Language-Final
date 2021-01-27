using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPISupport.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeServices = new HashSet<EmployeeService>();
            InverseEmployeeSupervisorNavigation = new HashSet<Employee>();
            Issues = new HashSet<Issue>();
            Notes = new HashSet<Note>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeSecondName { get; set; }
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
        public virtual ICollection<EmployeeService> EmployeeServices { get; set; }
        public virtual ICollection<Employee> InverseEmployeeSupervisorNavigation { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
