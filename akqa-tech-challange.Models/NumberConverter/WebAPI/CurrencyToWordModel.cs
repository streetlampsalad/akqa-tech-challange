using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace akqa_tech_challange.Models.NumberConverter.WebAPI
{
    public class CurrencyToWordModel
    {        
        public string name { get; set; }
        public decimal currency { get; set; }
        public string currencyConverted { get; set; }
    }
}