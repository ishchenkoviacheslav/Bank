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
        
        [HttpGet]
        public ActionResult GetCash()
        {
            List<Account> Acclist = accountContext.Accounts.ToList();
            foreach (Account item in Acclist)
            {
                if (item.login == HttpContext.User.Identity.Name)
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
                            accountContext.Reports.Add(new Report(DateTime.Now, TypeOfOperation.Taking, item.login, "None"));
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
        public ActionResult Transaction()
        {
            List<Account> Acclist = accountContext.Accounts.ToList();
            foreach (Account item in Acclist)
            {
                if (item.login == HttpContext.User.Identity.Name)
                {
                    ViewBag.ClientMoney = item.Money;
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Transaction(string login, string Sum)
        {
            List<Account> Acclist = accountContext.Accounts.ToList();

            //найти клиента-цель, для отправки ему денег
            Account target = null;
            foreach (Account item in Acclist)
            {
                if(item.login == login)
                {
                    target = item;
                }
            }
            if (target == null)
            {
                ViewBag.OperMsg = "клиент не найден";
                return View("Index");
            }
            float TransSum;
            //проверить что у нас есть достаточно денег и перевести их клиенту
            foreach (Account item in Acclist)
            {
                //найти нужного клиента
                if (item.login == HttpContext.User.Identity.Name)
                {
                    try
                    {
                        TransSum = float.Parse(Sum);
                    }
                    catch (Exception)
                    {
                        ViewBag.OperMsg = "введены некоректные данные суммы";
                        return View("Index");
                    }

                    if(item.Money< TransSum)
                    {
                        ViewBag.OperMsg = "недостаточно средств на счету";
                        return View("Index");
                    }
                    else
                    {
                        item.Money = item.Money - TransSum;
                        target.Money = target.Money + TransSum;
                        accountContext.Reports.Add(new Report(DateTime.Now, TypeOfOperation.Transfer, item.login, target.login));
                        accountContext.SaveChanges();
                        ViewBag.OperMsg = "операция прошла успешно";
                        return View("Index");
                    }
                }
            }
            ViewBag.OperMsg = "Список клиентов пуст";
            return View("Index");
        }

        public ActionResult Deposit()
        {
            List<Account> Acclist = accountContext.Accounts.ToList();
            foreach (Account item in Acclist)
            {
                //узнать сумму денег клиента для отображения на странице
                if (item.login == HttpContext.User.Identity.Name)
                {
                    ViewBag.ClientMoney = item.Money;
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Deposit(string Sum, int month)
        {
            List<Account> Acclist = accountContext.Accounts.ToList();
            float DepSum;
            try
            {
                DepSum = float.Parse(Sum);
            }
            catch (Exception)
            {
                ViewBag.OperMsg = "введены некоректные данные суммы";
                return View("Index");
            }

            foreach (Account item in Acclist)
            {
                if (item.login == HttpContext.User.Identity.Name)
                {
                    if (item.Money < DepSum)
                    {
                        ViewBag.OperMsg = "недостаточно средств на счету";
                        return View("Index");
                    }
                    else
                    {
                        //проверка на добавление депозита повторно
                        if(accountContext.Deposits.Where(a=>a.DepositId==item.Id).ToList()!=null)
                        {
                            ViewBag.OperMsg = "у вас есть действующий депозит";
                            return View("Index");
                        }
                        item.Money = item.Money - DepSum;
                        accountContext.Deposits.Add(new Models.Deposit(item.Id, DepSum, month));
                        accountContext.SaveChanges();
                        ViewBag.OperMsg = "вклад на депозит был осуществлен";
                        return View("Index");
                    }
                }
            }
            ViewBag.OperMsg = "список клиентов оказался пуст...";
            return View("Index");
        }
        public ActionResult DepositReport()
        {
            Account acc = accountContext.Accounts.Where(a => a.login.Contains(HttpContext.User.Identity.Name)).FirstOrDefault();
            Deposit depos = accountContext.Deposits.Where(a => a.DepositId == acc.Id).FirstOrDefault();

            return View(depos);
        }
    }
}