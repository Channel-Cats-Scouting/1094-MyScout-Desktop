using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScout
{
    /// <summary>
    /// This defines the "Alliance" type variable.
    /// </summary>
    public class Alliance
    {
        /// <summary>
        /// The IDs associated with the teams that are a part of the alliance.
        /// </summary>
        public int[] teams = new int[3] { -1, -1, -1 };
        /// <summary>
        /// The alliance's current score.
        /// </summary>
        public int score = 0;

        public Alliance() { }
    }
}
