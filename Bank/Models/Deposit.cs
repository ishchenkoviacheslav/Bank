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
        public Deposit(float sum, int month)
        {
            DepositId = Guid.NewGuid();
            ExpirationDate = DateTime.Now.AddMonths(month);
            Sum = sum;
            switch (month)
            {
                case 3:
                    SumOfInterest = (sum / 100) * 10;
                    break;
                case 6:
                    SumOfInterest = (sum / 100) * 15;
                    break;
                case 12:
                    SumOfInterest = (sum / 100) * 20;
                    break;
            }

        }

    }
}