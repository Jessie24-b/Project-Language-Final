using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_application.Models.Domain
{
    public class EmployeeService
    {

        private int employeeID;
        private int serviceID;

        //Auditorias 
        private string status;
        private DateTime dateCreation;
        private DateTime modificationDate;
        private int userCreation;
        private int userModification;

        public EmployeeService()
        {
        }

        public EmployeeService(int employeeID, int serviceID, string status, DateTime dateCreation, DateTime modificationDate, int userCreation, int userModification)
        {
            this.employeeID = employeeID;
            this.serviceID = serviceID;
            this.status = status;
            this.dateCreation = dateCreation;
            this.modificationDate = modificationDate;
            this.userCreation = userCreation;
            this.userModification = userModification;
        }

        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public int ServiceID { get => serviceID; set => serviceID = value; }
        public string Status { get => status; set => status = value; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }
        public DateTime ModificationDate { get => modificationDate; set => modificationDate = value; }
        public int UserCreation { get => userCreation; set => userCreation = value; }
        public int UserModification { get => userModification; set => userModification = value; }
    }
}
