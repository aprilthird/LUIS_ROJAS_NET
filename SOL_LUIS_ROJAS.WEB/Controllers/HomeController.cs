using SOL_LUIS_ROJAS.CORE.Helpers;
using SOL_LUIS_ROJAS.WEB.Seeder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SOL_LUIS_ROJAS.WEB.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController() : base()
        {
        }

        public async Task<ActionResult> Index()
        {
            if(Constants.Seed.ENABLED)
            {
                await DbSeeder.SeedAsync(_context);
            }

            return View();
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}