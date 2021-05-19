using System;
using System.Collections.Generic;
using System.Text;

namespace ForumBusinessLogic.BindingModels
{
    public class UsersBindingModel
    {
        public int? Userid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
