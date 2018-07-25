using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace myMoneAppAPI.Models
{
    public class BillingCycle
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int month { get; set; }
        [Required]
        public int year { get; set; }
        public IEnumerable<Credito> credits { get; set; }
        public IEnumerable<Debito> debts { get; set; }
    }

    public class Credito
    {
        public string name { get; set; }
        public decimal value { get; set; }
    }
    public class Debito
    {
        public string name { get; set; }
        public decimal value { get; set; }
        public string status { get; set; }
    }
    public class Summary
    {
        public decimal debt { get; set; }
        public decimal credit { get; set; }
    }
        
}