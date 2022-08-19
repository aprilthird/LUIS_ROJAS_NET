using SOL_LUIS_ROJAS.ENTITIES.Models;
using SOL_LUIS_ROJAS.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SOL_LUIS_ROJAS.WEB.Controllers
{
    public class BookLoanController : BaseController
    {
        public BookLoanController() : base()
        {
        }

        // GET: BookLoan
        public async Task<ActionResult> Index(string user = null, string book = null, string author = null, string publisher = null)
        {
            var query = _context.BookLoans
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrEmpty(user))
                query = query.Where(x => x.User.FirstName.Contains(user) || x.User.LastName.Contains(user));

            if(!string.IsNullOrEmpty(book))
                query = query.Where(x => x.Book.Name.Contains(book));

            if (!string.IsNullOrEmpty(author))
                query = query.Where(x => x.Book.Author.Contains(author));

            if (!string.IsNullOrEmpty(publisher))
                query = query.Where(x => x.Book.Publisher.Contains(publisher));

            var model = await query
                .Select(x => new BookLoanViewModel
                {
                    Id = x.Id,
                    LoanDate = x.LoanDate,
                    ReturnDate = x.ReturnDate,
                    LoanPurpose = x.LoanPurpose,
                    BookId = x.BookId,
                    UserId = x.UserId,
                    Book = new BookViewModel
                    {
                        ISBN = x.Book.ISBN,
                        Name = x.Book.Name,
                    },
                    User = new UserViewModel
                    {
                        DNI = x.User.DNI,
                        FirstName = x.User.FirstName,
                        LastName = x.User.LastName,
                        Role = x.User.Role,
                    }
                }).ToListAsync();

            return View(model);
        }

        public async Task<ActionResult> BookLoanForm(int? id = null)
        {
            var model = new BookLoanViewModel();
            if(id.HasValue)
            {
                var loanInDb = await _context.BookLoans.FindAsync(id.Value);
                model.LoanPurpose = loanInDb.LoanPurpose;
                model.LoanDate = loanInDb.LoanDate;
                model.ReturnDate = loanInDb.ReturnDate;
                model.BookId = loanInDb.BookId;
                model.UserId = loanInDb.UserId;
            }

            model = await FillSelectLists(model);

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> BookLoanForm(BookLoanViewModel viewModel, int? id = null)
        {
            var bookLoan = id.HasValue
                ? await _context.BookLoans.FindAsync(id.Value)
                : new BookLoan();

            bookLoan.LoanPurpose = viewModel.LoanPurpose;
            bookLoan.LoanDate = viewModel.LoanDate;
            bookLoan.ReturnDate = viewModel.ReturnDate;
            bookLoan.BookId = viewModel.BookId;
            bookLoan.UserId = viewModel.UserId;

            if(!id.HasValue)
                _context.BookLoans.Add(bookLoan);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<BookLoanViewModel> FillSelectLists(BookLoanViewModel viewModel)
        {
            var slUsers = await _context.Users
                .AsNoTracking().ToListAsync();
            var slBooks = await _context.Books
                .AsNoTracking().ToListAsync();

            viewModel.Users = new SelectList(slUsers
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = $"{x.LastName}, {x.FirstName} ({x.Role})"
                }).ToList());

            viewModel.Books = new SelectList(slBooks
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = $"{x.Name} ({x.Publisher})"
                }).ToList());

            viewModel.LoanPurposes = new SelectList(
                new List<SelectListItem>()
                { 
                    new SelectListItem { Value = "Lectura dentro de la biblioteca", Text = "Lectura dentro de la biblioteca" },
                    new SelectListItem { Value = "Retiro a casa", Text = "Retiro a casa" },
                });

            return viewModel;
        }
    }
}