using System;
using System.Net;
using System.Web.Http.Results;
using akqa_tech_challange.WebAPI.Controllers;
using akqa_tech_challange.WebAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace akqa_tech_challange.Controllers.Tests
{
    [TestClass]
    public class NumberConverterControllerTest
    {
        [TestMethod]
        public void CurrencyToWord_Success()
        {
            var controller = new NumberConverterController();
            var body = new CurrencyToWordModel()
            {
                name = "John Smith",
                currency = 123.45M
            };

            var result = controller.CurrencyToWords(body) as OkNegotiatedContentResult<CurrencyToWordModel>;            

            Assert.IsNotNull(result);            
            Assert.AreEqual("John Smith", result.Content.name);
            Assert.AreEqual(123.45M, result.Content.currency);
            Assert.AreEqual("ONE HUNDRED AND TWENTY - THREE DOLLARS AND FORTY - FIVE CENTS", result.Content.currencyConverted.ToUpper());
        }

        [TestMethod]
        public void CurrencyToWord_Empty()
        {
            var controller = new NumberConverterController();            

            var result = controller.CurrencyToWords(new CurrencyToWordModel()) as NegotiatedContentResult<string>;

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.AreEqual("Please input a name", result.Content);
        }

        [TestMethod]
        public void CurrencyToWord_NoName()
        {
            var controller = new NumberConverterController();
            var body = new CurrencyToWordModel()
            {                
                currency = 123.45M
            };

            var result = controller.CurrencyToWords(body) as NegotiatedContentResult<string>;

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.AreEqual("Please input a name", result.Content);
        }

        [TestMethod]
        public void CurrencyToWord_NoCurrency()
        {
            var controller = new NumberConverterController();
            var body = new CurrencyToWordModel()
            {
                name = "John Smith"
            };

            var result = controller.CurrencyToWords(body) as OkNegotiatedContentResult<CurrencyToWordModel>;

            Assert.IsNotNull(result);
            Assert.AreEqual("John Smith", result.Content.name);
            Assert.AreEqual(0M, result.Content.currency);
            Assert.AreEqual("ZERO DOLLARS AND ZERO CENTS", result.Content.currencyConverted.ToUpper());
        }
    }
}
