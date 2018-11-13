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
    [Route("api/converter")]
    public class NumberConverterController : ApiController
    {
        [HttpGet, HttpPut, HttpDelete]
        public IHttpActionResult CurrencyToWords()
        {            
            return Content(HttpStatusCode.NotImplemented, "Not Implemented");
        }

        [HttpPost]
        public IHttpActionResult CurrencyToWords(CurrencyToWordModel body)
        {
            if(string.IsNullOrWhiteSpace(body.name))
            {
                return Content(HttpStatusCode.BadRequest, "Please input a name");
            }

            var response = body;
            response.currencyConverted = NumberConverterService.CurrencyToWords(body.currencyInput);
            return Ok(response);
        }        
    }
}
