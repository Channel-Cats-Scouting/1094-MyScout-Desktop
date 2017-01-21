using System;
using System.Collections.Generic;
using System.Linq;

namespace MyScout
{
    static class Tokenizer
    {
        /// <summary>
        /// Converts a list of objects into a single comma-separated string.
        /// Everything has toString() called on it, but
        /// Lists become ls(type){item|item}
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string CreateTokenizedString(List<object> input)
        {
            string output = "";

            foreach (object obj in input)
            {
                if (isIntList(obj))
                {
                    string str = "";
                    List<int> objlist = (List<int>)obj;
                    str += "ls(int){";
                    foreach (int e in objlist)
                    {
                        str += e.ToString();
                        str += "|";
                    }
                    str += "}";
                    output += (output.Length > 0 ? ":" : "") + str.ToString();
                }
                else if (isBoolList(obj))
                {
                    string str = "";
                    List<bool> objlist = (List<bool>)obj;
                    str += "ls(bool){";
                    foreach (bool e in objlist)
                    {
                        str += e.ToString();
                        str += "|";
                    }
                    str += "}";
                    output += (output.Length > 0 ? ":" : "") + str.ToString();
                }
                else
                {
                    string str = obj.ToString();
                    if (str.Contains(':'))
                    {
                        str = str.Replace(":", "\\s");
                    }
                    if (str.Contains('{'))
                    {
                        str = str.Replace("{", "\\l");
                    }
                    if (str.Contains('}'))
                    {
                        str = str.Replace("}", "\\r");
                    }
                    output += (output.Length > 0 ? ":" : "") + str.ToString();
                }
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
                else if (s.StartsWith("ls")) //if there's a list
                {
                    string clean = s.Replace("ls","");
                    if (clean.StartsWith("(int)"))
                    {
                        List<int> outlist = new List<int>();

                        clean = clean.Replace("(int){", "").Replace("}", "");
                        foreach(string str in clean.Split('|'))
                        {
                            if (clean != "") //If there's actually something to parse
                                outlist.Add(int.Parse(str));
                        }
                        output.Add(outlist);
                    }
                    else if (clean.StartsWith("(bool)"))
                    {
                        List<bool> outlist = new List<bool>();

                        clean = clean.Replace("(bool){", "").Replace("}", "");
                        foreach (string str in clean.Split('|'))
                        {
                            if(clean != "") //If there's actually something to parse
                                outlist.Add(bool.Parse(str));
                        }
                        output.Add(outlist);
                    }
                }
                else
                    output.Add(s.ToString()
                        .Replace("\\s",":")
                        .Replace("\\l","{")
                        .Replace("\\r","}")
                        );
            }

            return output;
        }

        //Tries to parse obj to bool list, returns if successful
        private static bool isBoolList(object obj)
        {
            bool output = true;
            try
            {
                List<bool> test = (List<bool>)obj;
            }
            catch
            {
                output = false;
            }
            return output;
        }

        //Tries to parse obj to int list, returns if successful
        private static bool isIntList(object obj)
        {
            bool output = true;
            try
            {
                List<int> test = (List<int>)obj;
            }
            catch
            {
                output = false;
            }
            return output;
        }

        public static Type getTypeFromString(string typestring)
        {
            Type output = typeof(int);
            switch(typestring)
            {
                case "int":
                    output = typeof(int);
                    break;
                case "float":
                    output = typeof(float);
                    break;
                case "bool":
                    output = typeof(bool);
                    break;
                case "string":
                    output = typeof(string);
                    break;
            }
            return output;
        }

        public static string getStringFromType(Type T)
        {
            Type output = typeof(int);
            if(T.Equals(typeof(int)))
            {
                return "int";
            }
            else if(T.Equals(typeof(float)))
            {
                return "float";
            }
            else if(T.Equals(typeof(bool)))
            {
                return "bool";
            }
            else if(T.Equals(typeof(string)))
            {
                return "string";
            }
            return "";
        }
    }
}
