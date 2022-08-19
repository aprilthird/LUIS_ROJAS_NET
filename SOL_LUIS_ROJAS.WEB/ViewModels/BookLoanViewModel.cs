using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOL_LUIS_ROJAS.WEB.ViewModels
{
    public class BookLoanViewModel
    {
        public int? Id { get; set; }

        public int BookId { get; set; }

        public BookViewModel Book { get; set; }

        public int UserId { get; set; }

        public UserViewModel User { get; set; }

        public string LoanPurpose { get; set; }

        public DateTime LoanDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public SelectList Books { get; set; }

        public SelectList Users { get; set; }

        public SelectList LoanPurposes { get; set; }
    }
}