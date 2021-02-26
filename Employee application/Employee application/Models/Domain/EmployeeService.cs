using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_application.Models.Domain
{
    public class EmployeeService
    {

        private int employeeId;
        private int serviceId;

        //Auditorias 
        private string status;
        private DateTime dateCreation;
        private DateTime modificationDate;
        private int userCreation;
        private int modificationUser;

        public EmployeeService()
        {
        }

        public EmployeeService(int employeeId, int serviceId, string status, DateTime dateCreation, DateTime modificationDate, int userCreation, int modificationUser)
        {
            this.EmployeeId = employeeId;
            this.ServiceId = serviceId;
            this.Status = status;
            this.DateCreation = dateCreation;
            this.ModificationDate = modificationDate;
            this.UserCreation = userCreation;
            this.ModificationUser = modificationUser;
        }

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public int ServiceId { get => serviceId; set => serviceId = value; }
        public string Status { get => status; set => status = value; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }
        public DateTime ModificationDate { get => modificationDate; set => modificationDate = value; }
        public int UserCreation { get => userCreation; set => userCreation = value; }
        public int ModificationUser { get => modificationUser; set => modificationUser = value; }
    }
}
