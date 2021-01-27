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
        private int employeeID;
        private int issueID;

        //Auditorias 
        private string status;
        private DateTime dateCreation;
        private DateTime modificationDate;
        private int userCreation;
        private int userModification;

        public Note()
        {
        }

        public Note(string noteDescription, DateTime noteTime, int employeeID, int issueID, string status, DateTime dateCreation, DateTime modificationDate, int userCreation, int userModification)
        {
            this.noteDescription = noteDescription;
            this.noteTime = noteTime;
            this.employeeID = employeeID;
            this.issueID = issueID;
            this.status = status;
            this.dateCreation = dateCreation;
            this.modificationDate = modificationDate;
            this.userCreation = userCreation;
            this.userModification = userModification;
        }

        public string NoteDescription { get => noteDescription; set => noteDescription = value; }
        public DateTime NoteTime { get => noteTime; set => noteTime = value; }
        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public int IssueID { get => issueID; set => issueID = value; }
        public string Status { get => status; set => status = value; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }
        public DateTime ModificationDate { get => modificationDate; set => modificationDate = value; }
        public int UserCreation { get => userCreation; set => userCreation = value; }
        public int UserModification { get => userModification; set => userModification = value; }
    }
}
