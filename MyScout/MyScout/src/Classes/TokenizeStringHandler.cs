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
                output += output.Length > 0 ? "" : ":" + o.ToString();
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
            

            foreach (String s in tokenArray)
            {
                var isNum = int.TryParse(s, out parsedNum);

                if (isNum)
                    output.Add(parsedNum);
                else output.Add(s.Equals("True") ? true : false);
            }

            return output;
        }
    }
}
