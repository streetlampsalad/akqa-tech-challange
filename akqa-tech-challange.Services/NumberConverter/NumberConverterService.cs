using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace akqa_tech_challange.Services.NumberConverter
{
    public class NumberConverterService
    {
        // Logic based off https://stackoverflow.com/questions/2729752/converting-numbers-in-to-words-c-sharp
        public static string CurrencyToWords(decimal currency)
        {
            if(currency == 0)
            {
                return "zero dollars and zero cents";
            }                
            
            if(currency < 0)
            {
                // If input is a negative, return what the positive version of the input would be plus "negative " at the start
                return "negative " + CurrencyToWords(Math.Abs(currency));
            }                
            
            if(currency > int.MaxValue)
            {
                throw new Exception("Input is greater then int32, please input a number less then 2,147,483,647");
            }

            if(decimal.Round(currency, 2) != currency)
            {
                throw new Exception("Input must be a valid currency and can only be 2 decimal places");
            }

            string words = "";

            // Get whole numbers before decimal place
            int intPortion = (int)currency;
            // Subtract the whole number from decimal then multiply by 100 to make the decimal numbers whole numbers
            decimal fraction = (currency - intPortion) * 100;
            // Convert decimal to int
            int decPortion = (int)fraction;

            var intPortionWords = NumberToWords(intPortion).TrimEnd(' ');            
            
            if(intPortionWords == "one")
            {
                words += intPortionWords + " dollar";
            }
            else
            {
                words += intPortionWords + " dollars";
            }

            if(decPortion > 0)
            {
                words += " and ";
                var decPortionWords = NumberToWords(decPortion).TrimEnd(' ');
                if(decPortionWords == "one")
                {
                    words += decPortionWords + " cent";
                }
                else
                {
                    words += decPortionWords + " cents";
                }
            }            

            return words;
        }

        // Logic based off https://stackoverflow.com/questions/2729752/converting-numbers-in-to-words-c-sharp
        // Left this public as I am testing this function directly because it should be able to be called by other functions or APIs in the future
        public static string NumberToWords(int number)
        {
            if(number == 0)
            {
                return "zero";
            }

            if(number < 0)
            {
                // If input is a negative, return what the positive version of the input would be plus "negative " at the start
                return "negative " + NumberToWords(Math.Abs(number));
            }

            string words = "";

            // Check if the input is divisible by a million
            if((number / 1000000) > 0)
            {
                // Add the number plus " million " then devide the int by 1000000
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            // Check if the input is divisible by a thousand
            if((number / 1000) > 0)
            {
                // Add the number plus " thousand " then devide the int by 1000
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            // Check if the input is divisible by a hundred
            if((number / 100) > 0)
            {
                // Add the number plus " hundred " then devide the int by 100
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if(number > 0)
            {                
                if(words != "")
                {
                    // If words isn't empty string then continue with the string with "and" 
                    words += "and ";
                }                    

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if(number < 20)
                    // Each number is mapped to its equivalent index in the array
                    words += unitsMap[number];
                else
                {
                    // If the number is greater then 20 then add the appropriate prefix to the string before adding the number
                    words += tensMap[number / 10];
                    if((number % 10) > 0)
                    {                        
                        words += " - " + unitsMap[number % 10];
                    }                        
                }
            }

            words = words.TrimEnd(' ');

            return words;
        }        
    }
}