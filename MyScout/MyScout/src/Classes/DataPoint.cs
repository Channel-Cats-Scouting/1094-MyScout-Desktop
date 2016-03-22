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
    class DataPoint
    {
        #region vars
        /// <summary>
        /// The internal name id of the datapoint
        /// </summary>
        private string internalName;
        /// <summary>
        /// The public, shown name of the datapoint
        /// </summary>
        private string publicName;
        /// <summary>
        /// The actual data this datapoint contains
        /// </summary>
        public object value;
        /// <summary>
        /// The type of data this datapoint contains
        /// </summary>
        private int type;
        #endregion
        #region data types
        public static readonly int BOOLEAN = 0;
        public static readonly int INT16 = 1;
        public static readonly int STRING = 2;
        public static readonly int BOOL_LIST = 3;
        public static readonly int INT_LIST = 4;
        public static readonly int STR_LIST = 5;
        public static readonly int ARRAY = 6;
        #endregion

        public DataPoint(int datatype, object datavalue)
        {
            type = datatype;
            value = datavalue;
        }

        public int GetDataType()
        {
            return type;
        }

        public string GetName()
        {
            return publicName;
        }
    }
}
