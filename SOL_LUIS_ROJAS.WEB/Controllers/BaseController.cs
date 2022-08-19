using SOL_LUIS_ROJAS.DATA.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOL_LUIS_ROJAS.WEB.Controllers
{
    public class BaseController : Controller
    {
        protected AppDbContext _context;

        public BaseController()
        {
            _context = new AppDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}