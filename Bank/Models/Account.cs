using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank.Models
{
    public class Account
    {
        //идентификатор аккаунта/пользователя
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public float Money { get; set; }
        public string login { get; set; }
        List<Deposit> ListOfDeposits = new List<Deposit>();
        public override string ToString()
        {
            return Id.ToString() + " " + Name.ToString() + " " + Surname + " " + Money.ToString() + " " + login;
        }
    }
}