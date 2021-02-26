using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_application.Models.Domain
{
    public class Employee
    {

        private int employeeId;
        private string employeeName;
        private string employeeEmail;
        private string employeePassword;
        private string employeeOccupation;
        private int employeeSupervisor;

        //Auditorias 
        private string status;
        private DateTime dateCreation;
        private DateTime modificationDate;
        private int userCreation;
        private int modificationUser;

        public Employee()
        {
        }

        public Employee(int employeeId, string employeeName, string employeeEmail, string employeePassword, string employeeOccupation, int employeeSupervisor, string status, DateTime dateCreation, DateTime modificationDate, int userCreation, int modificationUser)
        {
            this.EmployeeId = employeeId;
            this.EmployeeName = employeeName;
            this.EmployeeEmail = employeeEmail;
            this.EmployeePassword = employeePassword;
            this.EmployeeOccupation = employeeOccupation;
            this.EmployeeSupervisor = employeeSupervisor;
            this.Status = status;
            this.DateCreation = dateCreation;
            this.ModificationDate = modificationDate;
            this.UserCreation = userCreation;
            this.ModificationUser = modificationUser;
        }

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string EmployeeName { get => employeeName; set => employeeName = value; }
        public string EmployeeEmail { get => employeeEmail; set => employeeEmail = value; }
        public string EmployeePassword { get => employeePassword; set => employeePassword = value; }
        public string EmployeeOccupation { get => employeeOccupation; set => employeeOccupation = value; }
        public int EmployeeSupervisor { get => employeeSupervisor; set => employeeSupervisor = value; }
        public string Status { get => status; set => status = value; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }
        public DateTime ModificationDate { get => modificationDate; set => modificationDate = value; }
        public int UserCreation { get => userCreation; set => userCreation = value; }
        public int ModificationUser { get => modificationUser; set => modificationUser = value; }
    }
}
