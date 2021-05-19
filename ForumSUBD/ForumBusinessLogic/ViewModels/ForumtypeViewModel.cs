using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ForumBusinessLogic.ViewModels
{
    public class ForumtypeViewModel
    {
        public int? Forumtypeid { get; set; }
        [DisplayName("Тип форума")]
        public string Nametype { get; set; }
    }
}
