using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL_LUIS_ROJAS.ENTITIES.Models
{
    public class BookLoan
    {
        public int Id { get; set; }

        public DateTime LoanDate { get; set; }

        public string LoanPurpose { get; set; }

        public DateTime ReturnDate { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
