using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_application.Models.Domain
{
    public class Note
    {
        private string noteDescription;
        private DateTime noteTime;
        private int employeeId;
        private int issueId;

        //Auditorias 
        private string status;
        private DateTime dateCreation;
        private DateTime modificationDate;
        private int userCreation;
        private int modificationUser;

        public Note()
        {
        }

        public Note(string noteDescription, DateTime noteTime, int employeeId, int issueId, string status, DateTime dateCreation, DateTime modificationDate, int userCreation, int modificationUser)
        {
            this.NoteDescription = noteDescription;
            this.NoteTime = noteTime;
            this.EmployeeId = employeeId;
            this.IssueId = issueId;
            this.Status = status;
            this.DateCreation = dateCreation;
            this.ModificationDate = modificationDate;
            this.UserCreation = userCreation;
            this.ModificationUser = modificationUser;
        }

        public string NoteDescription { get => noteDescription; set => noteDescription = value; }
        public DateTime NoteTime { get => noteTime; set => noteTime = value; }
        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public int IssueId { get => issueId; set => issueId = value; }
        public string Status { get => status; set => status = value; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }
        public DateTime ModificationDate { get => modificationDate; set => modificationDate = value; }
        public int UserCreation { get => userCreation; set => userCreation = value; }
        public int ModificationUser { get => modificationUser; set => modificationUser = value; }
    }
}
