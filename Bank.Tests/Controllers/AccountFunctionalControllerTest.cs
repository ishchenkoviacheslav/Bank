using System.Text;
using System.Web.Mvc;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;
using Bank.Controllers;
using System.Data.Entity;
using Bank.Models;

namespace Bank.Tests.Controllers
{
    [TestClass]
    public class AccountFunctionalControllerTest
    {
        [TestMethod]
        public async void GetCash()
        {
            AccountFunctionalController contr = new AccountFunctionalController();
            List<Account> list = await contr.acctCountext.Accounts.ToListAsync();
            Assert.IsNotNull(list);
        }
    }
}
