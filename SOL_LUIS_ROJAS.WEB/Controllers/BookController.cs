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
    public class BookController : BaseController
    {
        public BookController() : base()
        {
        }

        // GET: Book
        public async Task<ActionResult> Index()
        {
            var query = _context.Books
                .AsNoTracking()
                .AsQueryable();

            var model = await query
                .Select(x => new BookViewModel
                {
                    Id = x.Id,
                    ISBN = x.ISBN,
                    Name = x.Name,
                    Author = x.Author,
                    Country = x.Country,
                    Category = x.Category,
                    IssueDate = x.IssueDate,
                    Publisher = x.Publisher,
                }).ToListAsync();

            return View(model);
        }
    }
}