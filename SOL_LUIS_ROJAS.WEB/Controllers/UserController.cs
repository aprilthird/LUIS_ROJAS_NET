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
    public class UserController : BaseController
    {
        public UserController() : base()
        {
        }

        // GET: User
        public async Task<ActionResult> Index()
        {
            var query = _context.Users
                .AsNoTracking()
                .AsQueryable();

            var model = await query
                .Select(x => new UserViewModel
                {
                    Id = x.Id,
                    DNI = x.DNI,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Role = x.Role,
                    Status = x.Status,
                }).ToListAsync();

            return View(model);
        }
    }
}