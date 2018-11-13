using System.Net;
using System.Web.Http;
using akqa_tech_challange.Models.NumberConverter.WebAPI;
using akqa_tech_challange.Services.NumberConverter;

namespace akqa_tech_challange.Web.Controllers.WebAPI
{
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
            response.currencyConverted = NumberConverterService.CurrencyToWords(body.currency);
            return Ok(response);
        }        
    }
}
