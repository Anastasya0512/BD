using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ForumDatabaseImplement.Models
{
    public partial class ForumReports
    {
        public int Forumid { get; set; }
        public int Reportid { get; set; }

        public virtual Forum Forum { get; set; }
        public virtual Reports Report { get; set; }
    }
}
