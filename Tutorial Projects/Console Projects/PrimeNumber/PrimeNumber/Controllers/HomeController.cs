using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimeNumber.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public string Calculate(string no)
        {
            int _no = Convert.ToInt32(no);
            int _remainder = 1;
            while (_remainder == 0)
            {
                if (_no % 2 == 0) return "prime no";
                _no = _no / 2;
            }
            return "Hi";
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}