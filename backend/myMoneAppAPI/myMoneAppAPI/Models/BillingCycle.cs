using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myMoneAppAPI.Models
{
    public class BillingCycle
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public Credito Credito { get; set; }
        public Debito Debito { get; set; }
    }

    public class Credito
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
    public class Debito
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Status { get; set; }
    }
}