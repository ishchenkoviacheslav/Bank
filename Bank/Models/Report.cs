using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank.Models
{
    public class Report
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TypeOfOperation OperationType { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public Report()
        {

        }
        public Report(DateTime date, TypeOfOperation type, string sender, string receiver)
        {
            Date = date;
            OperationType = type;
            SenderId = sender;
            ReceiverId = receiver;
        }

    }
}