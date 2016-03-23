using System.Collections.Generic;
using System.Linq;

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

            foreach (object obj in input)
            {
                string str = obj.ToString();
                if (str.Contains(':')) { str = str.Replace(":","\\s"); }
                output += (output.Length > 0 ? ":" : "") + str.ToString();
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
            int parsedNum;
            bool parsedBool;

            foreach (string s in input.Split(':'))
            {
                if (int.TryParse(s, out parsedNum))
                    output.Add(parsedNum);
                else if (bool.TryParse(s, out parsedBool))
                    output.Add(parsedBool);
                else
                    output.Add(s.ToString().Replace("\\s",":"));
            }

            return output;
        }
    }
}
