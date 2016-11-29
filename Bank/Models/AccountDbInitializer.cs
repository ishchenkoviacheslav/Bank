using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Bank.Models
{
    public class AccountDbInitializer: DropCreateDatabaseAlways<AccountContext>
    {
        protected override void Seed(AccountContext context)
        {
           // context.Accounts.Add(new Account() { Id = Guid.NewGuid(), Money = 5000, Name = "Иван", Surname = "Иванов", login = "pupkin@mail.ru" });
            //context.Accounts.Add(new Account() { Id = Guid.NewGuid(), Money = 2000, Name = "Петр", Surname = "Петров" });
            //context.Accounts.Add(new Account() { Id = Guid.NewGuid(), Money = 1500, Name = "Сергей", Surname = "Сергеев" });
            base.Seed(context);
        }
    }
}