using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_application.Models.Domain
{
    public class Employee
    {

        private int employeeID;
        private string name;
        private string firstName;
        private string secondName;
        private string email;
        private string password;
        private string ocupation;
        private int supervisor;

        //Auditorias 
        private string status;
        private DateTime dateCreation;
        private DateTime modificationDate;
        private int userCreation;
        private int userModification;

        public Employee()
        {
        }

        public Employee(int employeeID, string name, string firstName, string secondName, string email, string password, string ocupation, int supervisor, string status, DateTime dateCreation, DateTime modificationDate, int userCreation, int userModification)
        {
            this.employeeID = employeeID;
            this.name = name;
            this.firstName = firstName;
            this.secondName = secondName;
            this.email = email;
            this.password = password;
            this.ocupation = ocupation;
            this.supervisor = supervisor;
            this.status = status;
            this.dateCreation = dateCreation;
            this.modificationDate = modificationDate;
            this.userCreation = userCreation;
            this.userModification = userModification;
        }

        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public string Name { get => name; set => name = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string SecondName { get => secondName; set => secondName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Ocupation { get => ocupation; set => ocupation = value; }
        public int Supervisor { get => supervisor; set => supervisor = value; }
        public string Status { get => status; set => status = value; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }
        public DateTime ModificationDate { get => modificationDate; set => modificationDate = value; }
        public int UserCreation { get => userCreation; set => userCreation = value; }
        public int UserModification { get => userModification; set => userModification = value; }
    }
}
