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
        public static String CreateTokenizedString(List<object> input)
        {
            String output = "";

            foreach (object o in input)
            {
                output += (output.Length > 0 ? ":" : "") + o.ToString();
                Console.WriteLine("Current object: " + o.ToString());
                Console.WriteLine("Current output: " + output);
            }

            return output;
        }

        /// <summary>
        /// Converts a tokenized string back into a List of objects
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static List<object> ReadTokenizedString(String input)
        {
            List<object> output = new List<object>();
            String[] tokenArray = input.Split(':');
            int parsedNum;
            Boolean parsedBool;

            foreach (String s in tokenArray)
            {
                var isNum = int.TryParse(s, out parsedNum);
                var isBool = Boolean.TryParse(s, out parsedBool);

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
