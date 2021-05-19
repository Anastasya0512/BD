using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ForumDatabaseImplement.Models
{
    public partial class Forumtype
    {
        public Forumtype()
        {
            Forum = new HashSet<Forum>();
        }

        public int Forumtypeid { get; set; }
        public string Nametype { get; set; }

        public virtual ICollection<Forum> Forum { get; set; }
    }
}
