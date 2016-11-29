using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Bank.Models
{
    public class AccountContext: DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Report> Reports { get; set; }
        public AccountContext(): base("MyConnection")
        {

        }

    }
}