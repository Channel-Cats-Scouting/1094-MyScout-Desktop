using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// </summary>
        public string publicName = "";
        /// <summary>
        /// The actual data this datapoint contains.
        /// </summary>
        public object value = null;
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
        private readonly Dictionary<Type,object> defaultvalues = new Dictionary<Type,object>
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

        /*
          Are the following methods really necessary?
          I only ask since I kind of have a pet peeve against having methods that could
          easily be replaced with a single line of code.

          For example.. why use "datapoint.GetDataType()" when you could just use "datapoint.type"?
          
          Because of this, for the time being at least, I've commented the folowing methods out.
          But I'd like to make it clear that my intention is not to intrude on/undo the work of others.
          ..So, if you feel they'd be useful or just want them in for whatever reason, feel free to un-comment them!
          I'm just trying to keep things semi-efficient in a way I personally think makes sense. ;)
          
            - Graham
        */


        ///// <summary>
        ///// Retrieves the type of the given piece of data.
        ///// </summary>
        ///// <returns>The type of the given piece of data.</returns>
        //public Type GetDataType()
        //{
        //    return type;
        //}

        ///// <summary>
        ///// Retrieves the name of the given piece of data.
        ///// </summary>
        ///// <returns>The name of the given piece of data.</returns>
        //public string GetName()
        //{
        //    return publicName;
        //}
    }
}
