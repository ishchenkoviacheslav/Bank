using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bank.Models;
namespace Bank.Controllers
{
    public class AccountFunctionalController : Controller
    {
        AccountContext accountContext = new AccountContext();
        public AccountContext acctCountext
        {
            get
            {
                return accountContext;
            }
        }

        // GET: AccountFunctional
        public ActionResult Index()
        {

            return View();
        }
        //[HttpPost]
        //public ActionResult Index(string msg)
        //{

        //    return View();
        //}
        [HttpGet]
        public ActionResult GetCash()
        {
            List<Account> Acclist = accountContext.Accounts.ToList();
            foreach (Account item in Acclist)
            {
                if(item.login == HttpContext.User.Identity.Name)
                {
                    ViewBag.ClientSum = item.Money;
                }
            }
            ViewBag.id = HttpContext.User.Identity.Name;
            return View("GetCash");
        }
        [HttpPost]
        public ActionResult GetCash(string Sum)
        {
            List<Account> Acclist = accountContext.Accounts.ToList();
            foreach (Account item in Acclist)
            {
                //найти нужного клиента
                if (item.login == HttpContext.User.Identity.Name)
                {
                    try
                    {
                        float ClienSum = float.Parse(Sum);
                        //достаточна ли сумма денег на счету для снятия
                    if (item.Money >= ClienSum)
                        {
                            item.Money = item.Money - ClienSum;
                            accountContext.SaveChanges();
                            ViewBag.OperMsg = "операция прошла успешно";
                            //Response.Redirect("/Home/Index");
                            return View("Index");
                        }
                        else
                        {
                            //return "недостаточно средств на счету";
                            ViewBag.OperMsg = "недостаточно средств на счету";
                            return View("Index");

                        }
                    }
                    catch (Exception)
                    {
                        //return "введены некоректные данные суммы";
                        ViewBag.OperMsg = "введены некоректные данные суммы";
                        return View("Index");
                    }
                }               
            }
            //return "системная ошибка, ненайдет клиент";
            ViewBag.OperMsg = "системная ошибка, ненайдет клиент";
            return View("Index");
        }
        ActionResult Transaction()
        {
            return View();
        }
    }
}