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
        public static readonly int BOOL = 0;
        public static readonly int INT = 1;
        public static readonly int STRING = 2;
        public static readonly int BOOL_LIST = 3;
        public static readonly int INT_LIST = 4;
        public static readonly int STR_LIST = 5;
        public static readonly int BOOL_2D = 6;
        public static readonly int INT_2D = 7;
        public static readonly int STR_2D = 8;
        #endregion

        public DataPoint(string name, int datatype)
        {
            type = datatype;
            publicName = name;

            switch(type)
            {
                case 0:
                    value = false;
                    break;
                case 1:
                    value = 0;
                    break;
                case 2:
                    value = "";
                    break;
                case 3:
                    value = new List<bool>();
                    break;
                case 4:
                    value = new List<int>();
                    break;
                case 5:
                    value = new List<string>();
                    break;
                case 6:
                    value = new List<List<bool>>();
                    break;
                case 7:
                    value = new List<List<int>>();
                    break;
                case 8:
                    value = new List<List<string>>();
                    break;
            }

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
