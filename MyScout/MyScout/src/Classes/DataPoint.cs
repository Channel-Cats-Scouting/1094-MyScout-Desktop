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
        /// The amount of points this datapoint is worth
        /// </summary>
        private float pointValue = 0;
        /// <summary>
        /// The type of data this datapoint contains.
        /// </summary>
        public Type type
        {
            get
            {
                return value.GetType();
            }
        }
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
        }

        /// <summary>
        /// Retrieves the type of the given piece of data.
        /// </summary>
        /// <returns>The type of the given piece of data.</returns>
        public Type GetDataType()
        {
            return type;
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
        /// Increments 'value'. Returns false if 'value' is not an int or a float. Takes an argument for how much to incrememt by.
        /// </summary>
        /// <returns></returns>
        public bool IncrementValue(int increment = 0)
        {
            bool success = true;
            if (increment == 0)
            {
                if (value.GetType() == typeof(int) || value.GetType() == typeof(float))
                    value = (int)value + 1;
                else success = false;
            }
            else value = (int)value + increment;
            return success;
        }

        /// <summary>
        /// Resets the value to null
        /// </summary>
        public void ResetValue()
        {
            value = null;
        }

        /// <summary>
        /// Sets the value to an int, used for counting purposes
        /// </summary>
        public void SetValueToInt()
        {
            value = defaultvalues[typeof(int)];
        }

        /// <summary>
        /// Retrieves the point value of the datapoint
        /// </summary>
        /// <returns></returns>
        public float GetPointValue()
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
    }
}