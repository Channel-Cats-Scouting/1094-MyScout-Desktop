using System;
using System.Collections.Generic;

namespace MyScout
{
    /// <summary>
    /// An object representation of a bit of data to be stored/loaded from Event#.xml
    /// (NYI)
    /// </summary>
    public class DataPoint
    {
        #region vars
        /// <summary>
        /// The index of the team this belongs to
        /// </summary>
        private int teamindex = -1;
        /// <summary>
        /// The public, shown name of the datapoint.
        /// </summary>e
        private string publicName = "";
        /// <summary>
        /// The actual data this datapoint contains.
        /// </summary>
        private object value = null;
        /// <summary>
        /// The script for compiling a score datapoint.
        /// </summary>
        private string script = "";
        /// <summary>
        /// The amount of points this datapoint is worth
        /// </summary>
        private LinkedDouble pointValue = new LinkedDouble(0);
        /// <summary>
        /// The type of data this datapoint contains.
        /// </summary>
        public Type datatype = null;
        #endregion

        #region Default Types
        /// <summary>
        /// A dictonary of common variable types, as well as the default values to assign to them. <para/>
        /// To get, for example, the default boolean value, you'd use "defaultvalues[typeof(bool)]"
        /// </summary>
        private readonly Dictionary<Type, object> defaultvalues = new Dictionary<Type, object>
        {
            { typeof(bool), false },
            { typeof(int), 0 },
            { typeof(string), ""},
            { typeof(List<bool>), new List<bool>() },
            { typeof(List<int>), new List<int>() },
            { typeof(List<string>), new List<string>() },
            { typeof(List<List<bool>>), new List<List<bool>>() },
            { typeof(List<List<int>>), new List<List<int>>() },
            { typeof(List<List<string>>), new List<List<string>>() }
        };
        #endregion

        /// <summary>
        /// A piece of data used by the software that should be written/read upon opening/closing of the application.
        /// </summary>
        /// <param name="name">The name of the data being stored. Used to help keep things "neat."</param>
        /// <param name="value">*Optional* The actual data being stored.</param>
        public DataPoint(string name, object value = null)
        {
            publicName = name;
            if (value != null) { this.value = value; }
        }

        /// <summary>
        /// A piece of data used by the software that should be written/read upon opening/closing of the application.
        /// </summary>
        /// <param name="name">The name of the data being stored. Used to help keep things "neat."</param>
        /// <param name="type">The type of data being stored.</param>
        public DataPoint(string name, Type type)
        {
            publicName = name;
            value = defaultvalues[type];
            datatype = type;
        }

        public DataPoint(string name, Type type, LinkedDouble pointValue)
        {
            publicName = name;
            value = defaultvalues[type];
            datatype = type;
            this.pointValue = pointValue;
        }

        public DataPoint(DataPoint dp)
        {
            this.publicName = dp.publicName;
            this.value = dp.value;
            this.datatype = dp.datatype;
            this.pointValue = dp.pointValue;
        }

        /// <summary>
        /// Retrieves the type of the given piece of data.
        /// </summary>
        /// <returns>The type of the given piece of data.</returns>
        public Type GetDataType()
        {
            return datatype;
        }

        /// <summary>
        /// Retrieves the name of the given piece of data.
        /// </summary>
        /// <returns>The name of the given piece of data.</returns>
        public string GetName()
        {
            return publicName;
        }

        /// <summary>
        /// Takes the first and every capital char in the datapoint's name and makes them into an abbreviation
        /// </summary>
        /// <returns></returns>
        public string GetAbbreviationBasic()
        {
            string abbr = "";
            char[] chars = publicName.ToCharArray();
            for (int i = 0; i < publicName.Length; i++)
            {
                if (i == 0 || char.IsUpper(chars[i]))
                {
                    abbr += char.ToUpper(chars[i]);
                }
            }

            return abbr;
        }

        public string GetAbbreviation()
        {
            string abbr = "";

            char[] chars = publicName.ToCharArray();
            for (int i = 0; i < publicName.Length; i++)
            {
                if (i == 0 || char.IsUpper(chars[i]) ||
                    (chars[i] != 'a' &&
                    chars[i] != 'e' &&
                    chars[i] != 'i' &&
                    chars[i] != 'o' &&
                    chars[i] != 'u'))
                {
                    abbr += chars[i];
                }
            }

            return abbr;
        }

        /// <summary>
        /// Sets the name of the datapoint
        /// </summary>
        /// <param name="str"></param>
        public void SetName(string str)
        {
            publicName = str;
        }

        /// <summary>
        /// Retrieves the value of the datapoint
        /// </summary>
        /// <returns>value</returns>
        public object GetValue()
        {
            return value;
        }

        /// <summary>
        /// Sets the value of the datapoint
        /// </summary>
        /// <param name="val"></param>
        public void SetValue(object val)
        {
            value = val;
        }

        /// <summary>
        /// Retrieves the point value of the datapoint
        /// </summary>
        /// <returns></returns>
        public double GetPointValue(int teamindex)
        {
            return pointValue.getDouble(teamindex);
        }

        /// <summary>
        /// Sets the point value of the datapoint
        /// </summary>
        /// <param name="pointvalue"></param>
        public void SetPointValue(float pointvalue)
        {
            pointValue.setValue(pointvalue);
        }

        /// <summary>
        /// Gets the script for compiling score. Only used for compiling datapoints.
        /// </summary>
        /// <returns></returns>
        public string GetScript()
        {
            return script;
        }

        /// <summary>
        /// Sets the script for compiling score. Only used for compiling datapoints.
        /// </summary>
        /// <returns></returns>
        public void SetScript(string s)
        {
            script = s;
        }
    }

    public class LinkedDouble //TODO: documentation. Basically it's a double with info on how to get and do math on datapoints to gain a value
    {
        private double doubleValue = 0;
        string[] dataPointNames;
        char[] operators;

        public LinkedDouble(string args)
        {
            char[] chars = args.ToCharArray();
            double number;
            if (args.StartsWith("$"))
            {
                string[] parsedArgs = args.Replace("$", "").Split('+', '-', '*', '/');
                char[] op = new char[parsedArgs.Length - 1];
                int lastOp = 0;
                for (int i = 0; i < chars.Length; i++)
                {
                    if(chars[i] == '+' || chars[i] == '-' || chars[i] == '*' || chars[i] == '/')
                    {
                        op[lastOp++] = chars[i];
                    }
                }

                operators = op;
                dataPointNames = parsedArgs;
            }
            else
            {
                if(!double.TryParse(args, out number))
                {
                    number = 0;
                }

                doubleValue = number;
            }
        }
        
        public LinkedDouble(double d)
        {
            doubleValue = d;
        }

        public void setValue(double d)
        {
            doubleValue = d;
        }
        public double getDouble(int teamindex)
        {
            if(dataPointNames != null)
            {
                double result = 0;
                for(int i = 0; i < dataPointNames.Length; i++)
                {
                    double value = 0;
                    if(double.TryParse(dataPointNames[i], out value))
                    {
                        if (i == 0)
                        {
                            result = value;
                        }
                    }
                    else
                    {
                        DataPoint dp = IO.GetDatapointByName(Program.CurrentEvent.teams[teamindex].GetTeamSpecificDataset(), dataPointNames[i]);

                        double tryparse;
                        if (double.TryParse(dp.GetValue().ToString(), out tryparse))
                        {
                            if (i == 0)
                            {
                                result = dp.GetPointValue(teamindex);
                            }
                            else
                            {
                                switch (operators[i - 1])
                                {
                                    case '+':
                                        result += tryparse;
                                        break;
                                    case '-':
                                        result -= tryparse;
                                        break;
                                    case '*':
                                        result *= tryparse;
                                        break;
                                    case '/':
                                        result /= tryparse;
                                        break;
                                }
                            }
                        }
                    }
                }

                return result;
            }
            else
            {
                return doubleValue;
            }
        }
    }
}