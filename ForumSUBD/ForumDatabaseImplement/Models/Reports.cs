using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ForumDatabaseImplement.Models
{
    public partial class Reports
    {
        public Reports()
        {
            ForumReports = new HashSet<ForumReports>();
        }

        public int Reportid { get; set; }
        public string Themereport { get; set; }
        public int Speakerid { get; set; }

        public virtual Speakers Speaker { get; set; }
        public virtual ICollection<ForumReports> ForumReports { get; set; }
    }
}
