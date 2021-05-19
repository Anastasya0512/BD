using System;
using System.Collections.Generic;
using System.Text;

namespace ForumBusinessLogic.BindingModels
{
    public class ForumBindingModel
    {
        public int? Forumid { get; set; }
        public string Themeforum { get; set; }
        public DateTime Startdate { get; set; }
        public int Forumtypeid { get; set; }
        public int Userid { get; set; }
    }
}
