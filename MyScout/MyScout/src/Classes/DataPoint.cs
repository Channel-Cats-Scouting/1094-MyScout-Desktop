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
        /// The internal name id of the datapoint.
        /// </summary>
        private string internalName;
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
        private double pointValue = 0;
        /// <summary>
        /// The type of data this datapoint contains.
        /// </summary>
        public Type datatype = null;
        private readonly Type Type;
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

        public DataPoint(string name, Type type, double pointValue)
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
            for(int i = 0; i < publicName.Length; i++)
            {
                if(i == 0 || char.IsUpper(chars[i]))
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
            for(int i = 0; i < publicName.Length; i++)
            {
                if (i == 0 || char.IsUpper(chars[i]) || 
                    chars[i] != 'a' || 
                    chars[i] != 'e' || 
                    chars[i] != 'i' || 
                    chars[i] != 'o' || 
                    chars[i] != 'u')
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
        public double GetPointValue()
        {
            return pointValue;
        }

        /// <summary>
        /// Sets the point value of the datapoint
        /// </summary>
        /// <param name="pointvalue"></param>
        public void SetPointValue(float pointvalue)
        {
            pointValue = pointvalue;
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
}