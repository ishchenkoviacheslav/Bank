using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;
using Bank.Controllers;
using System.Data.Entity;
using Bank.Models;
namespace Bank.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        
        [TestMethod]
        public void Index()
        {
            //удаётся ли считать клиентов банка из БД
            HomeController controller = new HomeController();

           List<Account> AccList = controller.context.Accounts.ToList();

            Assert.IsNotNull(AccList);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("My Bank application alfa version", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
