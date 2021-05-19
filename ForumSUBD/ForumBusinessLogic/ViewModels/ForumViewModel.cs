using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ForumBusinessLogic.ViewModels
{
    public class ForumViewModel
    {
        public int? Forumid { get; set; }
        [DisplayName("Тема форума")]
        public string Themeforum { get; set; }
        [DisplayName("Дата начала")]
        public DateTime Startdate { get; set; }
        [DisplayName("ID типа форума")]
        public int Forumtypeid { get; set; }
        [DisplayName("ID пользователя")]
        public int Userid { get; set; }
        [DisplayName("Пользователь")]
        public string User { get; set; }

        [DisplayName("Тип форума")]
        public string Forumtype { get; set; }
    }
}
