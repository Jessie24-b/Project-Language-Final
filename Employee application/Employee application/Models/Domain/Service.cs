using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_application.Models.Domain
{
    public class Service
    {
        private int serviceID;
        private string serviceName;

        //Auditorias 
        private string status;
        private DateTime dateCreation;
        private DateTime modificationDate;
        private int userCreation;
        private int userModification;

        public Service()
        {
        }

        public Service(int serviceID, string serviceName, string status, DateTime dateCreation, DateTime modificationDate, int userCreation, int userModification)
        {
            this.serviceID = serviceID;
            this.serviceName = serviceName;
            this.status = status;
            this.dateCreation = dateCreation;
            this.modificationDate = modificationDate;
            this.userCreation = userCreation;
            this.userModification = userModification;
        }

        public int ServiceID { get => serviceID; set => serviceID = value; }
        public string ServiceName { get => serviceName; set => serviceName = value; }
        public string Status { get => status; set => status = value; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }
        public DateTime ModificationDate { get => modificationDate; set => modificationDate = value; }
        public int UserCreation { get => userCreation; set => userCreation = value; }
        public int UserModification { get => userModification; set => userModification = value; }
    }
}
