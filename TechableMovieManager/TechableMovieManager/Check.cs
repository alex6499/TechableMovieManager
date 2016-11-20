using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TechableMovieManager
{
    abstract class Check
    {
        

            
        public static bool isPhone(string input)
        {
            Regex phoneRegex = new Regex(@"^\d{3}-\d{3}-\d{4}$");
            return phoneRegex.IsMatch(input);
        }

        public static bool isUPC(string input)
        {
            Regex phoneRegex = new Regex(@"^\d{5,20}$");
            return phoneRegex.IsMatch(input);
        }

        public static bool isAllAlphaNumeric(params string[] inputs)
        {
            bool isAlphaNum = true;

            foreach (string input in inputs)
            {
                if (!isAlphaNumeric(input))
                {
                    isAlphaNum = false;
                    break;
                }
            }

            return (isAlphaNum);
        }

        public static bool isAlphaNumeric(string input)
        {
            Regex alphaNumeric = new Regex("^[a-zA-Z0-9]*$");
            bool isAlphaNum = alphaNumeric.IsMatch(input);
            return (isAlphaNum);
        }

        public static bool isAllInt32(params string[] inputs)
        {
            bool isNum = true;

            foreach (string input in inputs)
            {
                if (!isInt32(input))
                {
                    isNum = false;
                    break;
                }
            }

            return (isNum);
        }

        public static bool isInt32(string input)
        {
            int parsed;
            return (Int32.TryParse(input, out parsed));
        }

    }
}
