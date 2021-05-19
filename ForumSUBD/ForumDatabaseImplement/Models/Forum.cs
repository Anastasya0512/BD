using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ForumDatabaseImplement.Models
{
    public partial class Forum
    {
        public Forum()
        {
            ForumReports = new HashSet<ForumReports>();
        }

        public int Forumid { get; set; }
        public string Themeforum { get; set; }
        public DateTime Startdate { get; set; }
        public int Forumtypeid { get; set; }
        public int Userid { get; set; }

        public virtual Forumtype Forumtype { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<ForumReports> ForumReports { get; set; }
    }
}
