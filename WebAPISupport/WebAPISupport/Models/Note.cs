using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebAPISupport.Models
{
    public partial class Note
    {
        public string NoteDescription { get; set; }
        public DateTime? NoteTime { get; set; }
        public int EmployeeId { get; set; }
        public int IssueId { get; set; }
        public string Status { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int? UserCreation { get; set; }
        public int? ModificationUser { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Issue Issue { get; set; }
    }
}
