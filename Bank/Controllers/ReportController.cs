using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bank.Models;
namespace Bank.Controllers
{
    public class ReportController : Controller
    {
        AccountContext accountContext = new AccountContext();
        public AccountContext acctCountext
        {
            get
            {
                return accountContext;
            }
        }
        // GET: Report
        public ActionResult Index()
        {
            //найти все движения средств в которых участововал (отправитель/получатель) данный клиент
           List<Report> listReports = accountContext.Reports.Where(a => (a.ReceiverId.Contains(HttpContext.User.Identity.Name) || a.SenderId.Contains(HttpContext.User.Identity.Name))).ToList();
            return View(listReports);
        }
        //[HttpPost]
        //public ActionResult Index()
        //{

        //    return View();
        //}
    }
}