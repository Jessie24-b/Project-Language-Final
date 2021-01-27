using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_application.Models.Domain
{
    public class Issue
    {

        private int reportID;
        private string reportClassification;
        private string reportStatus;
        private DateTime datetime;
        private string reportResolution;
        private int employeeID;
        private int serviceID;

        //Auditorias 
        private string status;
        private DateTime dateCreation;
        private DateTime modificationDate;
        private int userCreation;
        private int userModification;

        public Issue()
        {
        }

        public Issue(int reportID, string reportClassification, string reportStatus, DateTime datetime, string reportResolution, int employeeID, int serviceID, string status, DateTime dateCreation, DateTime modificationDate, int userCreation, int userModification)
        {
            this.reportID = reportID;
            this.reportClassification = reportClassification;
            this.reportStatus = reportStatus;
            this.datetime = datetime;
            this.reportResolution = reportResolution;
            this.employeeID = employeeID;
            this.serviceID = serviceID;
            this.status = status;
            this.dateCreation = dateCreation;
            this.modificationDate = modificationDate;
            this.userCreation = userCreation;
            this.userModification = userModification;
        }

        public int ReportID { get => reportID; set => reportID = value; }
        public string ReportClassification { get => reportClassification; set => reportClassification = value; }
        public string ReportStatus { get => reportStatus; set => reportStatus = value; }
        public DateTime Datetime { get => datetime; set => datetime = value; }
        public string ReportResolution { get => reportResolution; set => reportResolution = value; }
        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public int ServiceID { get => serviceID; set => serviceID = value; }
        public string Status { get => status; set => status = value; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }
        public DateTime ModificationDate { get => modificationDate; set => modificationDate = value; }
        public int UserCreation { get => userCreation; set => userCreation = value; }
        public int UserModification { get => userModification; set => userModification = value; }
    }
}
