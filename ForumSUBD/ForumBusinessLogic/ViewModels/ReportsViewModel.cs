using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ForumBusinessLogic.ViewModels
{
    public class ReportsViewModel
    {
        public int? Reportid { get; set; }
        [DisplayName("Тема доклада")]
        public string Themereport { get; set; }
        [DisplayName("ID докладчика")]
        public int Speakerid { get; set; }

    }
}
