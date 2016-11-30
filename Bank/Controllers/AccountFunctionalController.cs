using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bank.Controllers
{
    public class AccountFunctionalController : Controller
    {
        // GET: AccountFunctional
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult GetCash()
        {
            ViewBag.id = HttpContext.User.Identity.Name;
            return View();
        }
    }
}