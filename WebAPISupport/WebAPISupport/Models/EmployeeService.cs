﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebAPISupport.Models
{
    public partial class EmployeeService
    {
        public int EmployeeId { get; set; }
        public int ServiceId { get; set; }
        public string Status { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int? UserCreation { get; set; }
        public int? ModificationUser { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Service Service { get; set; }
    }
}
