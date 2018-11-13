using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace akqa_tech_challange.Services.Tests
{
    [TestClass]
    public class NumberConverterServiceTest
    {
        #region CurrencyToWords

        [TestMethod]
        public void CurrencyToWords_Zero()
        {
            var testInput = 0M;
            var result = NumberConverterService.CurrencyToWords(testInput);
            Assert.IsNotNull(result);
            Assert.AreNotEqual("", result);
            Assert.AreEqual("ZERO DOLLARS AND ZERO CENTS", result.ToUpper());
        }

        [TestMethod]
        public void CurrencyToWords_One()
        {
            var testInput = 1.01M;
            var result = NumberConverterService.CurrencyToWords(testInput);
            Assert.IsNotNull(result);
            Assert.AreNotEqual("", result);
            Assert.AreEqual("ONE DOLLAR AND ONE CENT", result.ToUpper());
        }

        [TestMethod]
        public void CurrencyToWords_Teen()
        {
            var testInput = 12.17M;
            var result = NumberConverterService.CurrencyToWords(testInput);
            Assert.IsNotNull(result);
            Assert.AreNotEqual("", result);
            Assert.AreEqual("TWELVE DOLLARS AND SEVENTEEN CENTS", result.ToUpper());
        }

        [TestMethod]
        public void CurrencyToWords_Hundred()
        {
            var testInput = 123.45M;
            var result = NumberConverterService.CurrencyToWords(testInput);
            Assert.IsNotNull(result);
            Assert.AreNotEqual("", result);
            Assert.AreEqual("ONE HUNDRED AND TWENTY - THREE DOLLARS AND FORTY - FIVE CENTS", result.ToUpper());
        }

        [TestMethod]
        public void CurrencyToWords_Thousand()
        {
            var testInput = 123000.45M;
            var result = NumberConverterService.CurrencyToWords(testInput);
            Assert.IsNotNull(result);
            Assert.AreNotEqual("", result);
            Assert.AreEqual("ONE HUNDRED AND TWENTY - THREE THOUSAND DOLLARS AND FORTY - FIVE CENTS", result.ToUpper());
        }

        [TestMethod]
        public void CurrencyToWords_Million()
        {
            var testInput = 123000000.45M;
            var result = NumberConverterService.CurrencyToWords(testInput);
            Assert.IsNotNull(result);
            Assert.AreNotEqual("", result);
            Assert.AreEqual("ONE HUNDRED AND TWENTY - THREE MILLION DOLLARS AND FORTY - FIVE CENTS", result.ToUpper());
        }

        [TestMethod]
        public void CurrencyToWords_MillionThousandHundred()
        {
            var testInput = 123456789.10M;
            var result = NumberConverterService.CurrencyToWords(testInput);
            Assert.IsNotNull(result);
            Assert.AreNotEqual("", result);
            Assert.AreEqual("ONE HUNDRED AND TWENTY - THREE MILLION FOUR HUNDRED AND FIFTY - SIX THOUSAND SEVEN HUNDRED AND EIGHTY - NINE DOLLARS AND TEN CENTS", result.ToUpper());
        }

        [TestMethod]
        public void CurrencyToWords_Negative()
        {
            var testInput = -14.10M;
            var result = NumberConverterService.CurrencyToWords(testInput);
            Assert.IsNotNull(result);
            Assert.AreNotEqual("", result);
            Assert.AreEqual("NEGATIVE FOURTEEN DOLLARS AND TEN CENTS", result.ToUpper());
        }

        [TestMethod]
        public void CurrencyToWords_Max()
        {
            var testInput = 2147483647M;
            var result = NumberConverterService.CurrencyToWords(testInput);
            Assert.IsNotNull(result);
            Assert.AreNotEqual("", result);
            Assert.AreEqual("TWO THOUSAND ONE HUNDRED AND FORTY - SEVEN MILLION FOUR HUNDRED AND EIGHTY - THREE THOUSAND SIX HUNDRED AND FORTY - SEVEN DOLLARS", result.ToUpper());
        }

        [TestMethod]
        public void CurrencyToWords_GreaterThenInt32Exception()
        {
            var testInput = 123000000000.45M;
            try
            {
                var result = NumberConverterService.CurrencyToWords(testInput);
                Assert.Fail("An exception should have been thrown");
            }
            catch(Exception ex)
            {
                Assert.AreEqual("Input is greater then int32, please input a number less then 2,147,483,647", ex.Message);
            }
        }

        [TestMethod]
        public void CurrencyToWords_MoreThen2DecimalPlacesException()
        {
            var testInput = 1.11111M;
            try
            {
                var result = NumberConverterService.CurrencyToWords(testInput);
                Assert.Fail("An exception should have been thrown");
            }
            catch(Exception ex)
            {
                Assert.AreEqual("Input must be a valid currency and can only be 2 decimal places", ex.Message);
            }
        }

        #endregion

        #region NumberToWords

        [TestMethod]
        public void NumberToWords_Zero()
        {
            var testInput = 0;
            var result = NumberConverterService.NumberToWords(testInput);
            Assert.IsNotNull(result);
            Assert.AreNotEqual("", result);
            Assert.AreEqual("ZERO", result.ToUpper());
        }

        [TestMethod]
        public void NumberToWords_One()
        {
            var testInput = 1;
            var result = NumberConverterService.NumberToWords(testInput);
            Assert.IsNotNull(result);
            Assert.AreNotEqual("", result);
            Assert.AreEqual("ONE", result.ToUpper());
        }

        [TestMethod]
        public void NumberToWords_Teen()
        {
            var testInput = 12;
            var result = NumberConverterService.NumberToWords(testInput);
            Assert.IsNotNull(result);
            Assert.AreNotEqual("", result);
            Assert.AreEqual("TWELVE", result.ToUpper());
        }

        [TestMethod]
        public void NumberToWords_Hundred()
        {
            var testInput = 123;
            var result = NumberConverterService.NumberToWords(testInput);
            Assert.IsNotNull(result);
            Assert.AreNotEqual("", result);
            Assert.AreEqual("ONE HUNDRED AND TWENTY - THREE", result.ToUpper());
        }

        [TestMethod]
        public void NumberToWords_Thousand()
        {
            var testInput = 123000;
            var result = NumberConverterService.NumberToWords(testInput);
            Assert.IsNotNull(result);
            Assert.AreNotEqual("", result);
            Assert.AreEqual("ONE HUNDRED AND TWENTY - THREE THOUSAND", result.ToUpper());
        }

        [TestMethod]
        public void NumberToWords_Million()
        {
            var testInput = 123000000;
            var result = NumberConverterService.NumberToWords(testInput);
            Assert.IsNotNull(result);
            Assert.AreNotEqual("", result);
            Assert.AreEqual("ONE HUNDRED AND TWENTY - THREE MILLION", result.ToUpper());
        }

        [TestMethod]
        public void NumberToWords_MillionThousandHundred()
        {
            var testInput = 123456789;
            var result = NumberConverterService.NumberToWords(testInput);
            Assert.IsNotNull(result);
            Assert.AreNotEqual("", result);
            Assert.AreEqual("ONE HUNDRED AND TWENTY - THREE MILLION FOUR HUNDRED AND FIFTY - SIX THOUSAND SEVEN HUNDRED AND EIGHTY - NINE", result.ToUpper());
        }

        [TestMethod]
        public void NumberToWords_Max()
        {
            var testInput = 2147483647;
            var result = NumberConverterService.NumberToWords(testInput);
            Assert.IsNotNull(result);
            Assert.AreNotEqual("", result);
            Assert.AreEqual("TWO THOUSAND ONE HUNDRED AND FORTY - SEVEN MILLION FOUR HUNDRED AND EIGHTY - THREE THOUSAND SIX HUNDRED AND FORTY - SEVEN", result.ToUpper());
        }

        [TestMethod]
        public void NumberToWords_Negative()
        {
            var testInput = -14;
            var result = NumberConverterService.NumberToWords(testInput);
            Assert.IsNotNull(result);
            Assert.AreNotEqual("", result);
            Assert.AreEqual("NEGATIVE FOURTEEN", result.ToUpper());
        }        

        #endregion
    }
}
