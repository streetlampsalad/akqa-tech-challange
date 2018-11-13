using akqa_tech_challange.WebAPI.Models;
using akqa_tech_challange.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace akqa_tech_challange.WebAPI.Controllers
{    
    public class NumberConverterController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage CurrencyToWord()
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented);
        }

        [HttpPost]
        public IHttpActionResult CurrencyToWord(CurrencyToWordModel body)
        {
            var response = body;
            response.currencyConverted = NumberConverterService.CurrencyToWords(body.currencyInput);
            return Ok(response);
        }
    }
}
