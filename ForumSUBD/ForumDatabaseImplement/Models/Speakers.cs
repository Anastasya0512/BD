using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ForumDatabaseImplement.Models
{
    public partial class Speakers
    {
        public Speakers()
        {
            Reports = new HashSet<Reports>();
        }

        public int Speakerid { get; set; }
        public string Namespeaker { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Reports> Reports { get; set; }
    }
}
