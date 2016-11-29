using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank.Models
{
    public class Report
    {
        public Guid ReportId { get; set; }
        public DateTime Date { get; set; }
        public TypeOfOperation OperationType { get; set; }
        public Guid SenderId { get; set; }
        public Guid Receiver { get; set; }
    }
}