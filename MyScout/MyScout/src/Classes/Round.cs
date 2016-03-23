using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScout
{
    /// <summary>
    /// This defines the "Round" type variable.
    /// </summary>
    public class Round
    {
        /// <summary>
        /// The IDs associated with the teams that are a part of this round.
        /// First three values are part of the red alliance, last three values
        /// are part of the blue alliance.
        /// </summary>
        public int[] teams = new int[6] { -1, -1, -1, -1, -1, -1 };

        public List<DataPoint>[] dataset;

        public Round()
        {
            dataset = new List<DataPoint>[6];
            for(int i = 0; i < 6; i++)
            {
                dataset[i] = Program.dataset[1];
            }
        }
    }
}
