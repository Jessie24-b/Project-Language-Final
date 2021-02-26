using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_application.Models.Domain
{
    public class Issue
    {

        private int reportId;
        private string reportClassification;
        private int serviceId;
        private string reportStatus;
        private DateTime reportDateTime;
        private string reportResolution;
        private int? employeeId;

        //Auditorias 
        private string status;
        private DateTime dateCreation;
        private DateTime modificationDate;
        private int userCreation;
        private int modificationUser;

        public Issue()
        {
        }

        public Issue(int reportId, string reportClassification, int serviceId, string reportStatus, DateTime reportDateTime, string reportResolution, int employeeId, string status, DateTime dateCreation, DateTime modificationDate, int userCreation, int modificationUser)
        {
            this.ReportId = reportId;
            this.ReportClassification = reportClassification;
            this.ServiceId = serviceId;
            this.ReportStatus = reportStatus;
            this.ReportDateTime = reportDateTime;
            this.ReportResolution = reportResolution;
            this.EmployeeId = employeeId;
            this.Status = status;
            this.DateCreation = dateCreation;
            this.ModificationDate = modificationDate;
            this.UserCreation = userCreation;
            this.ModificationUser = modificationUser;
        }

        public int ReportId { get => reportId; set => reportId = value; }
        public string ReportClassification { get => reportClassification; set => reportClassification = value; }
        public int ServiceId { get => serviceId; set => serviceId = value; }
        public string ReportStatus { get => reportStatus; set => reportStatus = value; }
        public DateTime ReportDateTime { get => reportDateTime; set => reportDateTime = value; }
        public string ReportResolution { get => reportResolution; set => reportResolution = value; }
        public int? EmployeeId { get => employeeId; set => employeeId = value; }
        public string Status { get => status; set => status = value; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }
        public DateTime ModificationDate { get => modificationDate; set => modificationDate = value; }
        public int UserCreation { get => userCreation; set => userCreation = value; }
        public int ModificationUser { get => modificationUser; set => modificationUser = value; }
    }
}
