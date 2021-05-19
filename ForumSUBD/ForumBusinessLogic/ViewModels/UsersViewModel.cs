using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ForumBusinessLogic.ViewModels
{
    public class UsersViewModel
    {
        public int? Userid { get; set; }
        [DisplayName("ФИО")]
        public string Username { get; set; }
        [DisplayName("Почта")]
        public string Email { get; set; }
        [DisplayName("Пароль")]
        public string Password { get; set; }
        public Dictionary<int, string> Forum { get; set; }
    }
}
