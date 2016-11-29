using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bank.Models;
namespace Bank.Controllers
{
    public class HomeController : Controller
    {
        AccountContext accountConext = new AccountContext();
        public AccountContext context
        {
            get
            {
                return accountConext;
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            //List<ApplicationUser> users = new List<ApplicationUser>();
            Account acc = null;

            ////список всех пользователей(бд авторизации)
            //using (ApplicationDbContext db = new ApplicationDbContext())
            //{
            //    users = db.Users.ToList();
            //}

            //foreach (ApplicationUser item in users)
            //{
            //    if (item.UserName == HttpContext.User.Identity.Name)
            //    {
            
            foreach (Account item in accountConext.Accounts.ToList())
            {
                //если авторизированный пользователь уже зарегестрирован как клиент банка
                if (item.login == HttpContext.User.Identity.Name)
                {
                    //показывает всю инфу о данном пользователе/клиенте банка
                   return View(item);
                }

            }
            ViewBag.Login = HttpContext.User.Identity.Name;
            //отправляем пустого пользователя, чтобы там его создать.
            return View(acc);

            //    }

            //}

            //List<Account> accounts = new List<Account>();
            //using (AccountContext db = new AccountContext())
            //{
            //    accounts = db.Accounts.ToList();
            //}

            //return View(accounts);
            //    return View();
        }
        [HttpPost]
        public ActionResult Index(Account act)
        {
            act.Id = Guid.NewGuid();
            accountConext.Accounts.Add(act);
            accountConext.SaveChanges();
            ViewBag.InfoText = act.ToString() + "Пользователь был добавлен!";
            return View("BackToIndex");
        }

        public ActionResult About()
        {
            ViewBag.Message = "My Bank application alfa version";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}