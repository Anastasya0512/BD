using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ForumBusinessLogic.ViewModels
{
    public class SpeakersViewModel
    {
        public int? Speakerid { get; set; }
        [DisplayName("ФИО")]
        public string Namespeaker { get; set; }
        [DisplayName("Никнейм")]
        public string Nickname { get; set; }
        [DisplayName("Почта")]
        public string Email { get; set; }
    }
}
