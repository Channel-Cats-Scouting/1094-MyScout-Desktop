using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScout
{
    static class TokenizeStringHandler
    {
        /// <summary>
        /// Converts a list of objects into a single comma-separated string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string CreateTokenizedString(List<object> input)
        {
            string output = "";

            foreach (object o in input)
            {
                output += (output.Length > 0 ? ":" : "") + o.ToString();
            }

            return output;
        }

        /// <summary>
        /// Converts a tokenized string back into a List of objects
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static List<object> ReadTokenizedString(string input)
        {
            List<object> output = new List<object>();
            string[] tokenArray = input.Split(':');
            int parsedNum;
            bool parsedBool;

            foreach (string s in tokenArray)
            {
                var isNum = int.TryParse(s, out parsedNum);
                var isBool = bool.TryParse(s, out parsedBool);

                if (isNum)
                    output.Add(parsedNum);
                else if (isBool)
                    output.Add(parsedBool);
                else output.Add(s.ToString());
            }

            return output;
        }
    }
}
