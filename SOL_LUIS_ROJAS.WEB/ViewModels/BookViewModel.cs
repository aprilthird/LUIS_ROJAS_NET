using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOL_LUIS_ROJAS.WEB.ViewModels
{
    public class BookViewModel
    {
        public int? Id { get; set; }

        public string ISBN { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public string Country { get; set; }

        public DateTime IssueDate { get; set; }

        public string Publisher { get; set; }


    }
}