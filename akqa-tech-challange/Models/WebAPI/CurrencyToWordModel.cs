using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace akqa_tech_challange.WebAPI.Models
{
    public class CurrencyToWordModel
    {        
        public string name { get; set; }
        public decimal currencyInput { get; set; }
        public string currencyConverted { get; set; }
    }
}