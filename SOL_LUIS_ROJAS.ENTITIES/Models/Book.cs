﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL_LUIS_ROJAS.ENTITIES.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string ISBN { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public string Country { get; set; }

        public DateTime IssueDate { get; set; }

        public string Publisher { get; set; }

        public List<BookLoan> BookLoans { get; set; }
    }
}
