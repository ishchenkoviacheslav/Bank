using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank.Models
{
    public class Deposit
    {
        public Guid DepositId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public float Sum { get; set; }
        public float SumOfInterest { get; set; }

    }
}