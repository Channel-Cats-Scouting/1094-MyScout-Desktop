using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScout
{
    /// <summary>
    /// This defines the "Team" type variable.
    /// </summary>
    public class Team
    {
        /// <summary>
        /// The name of the team (E.G. "Channel Cats").
        /// </summary>
        public string name = "All your base are belong to us"; //Sponsored by Greg™ incorporated
        /// <summary>
        /// The id of the team (E.G. "1094").
        /// </summary>
        public int id = 1094;
        /// <summary>
        /// The team's current score.
        /// </summary>
        public int score = 0;

        public Team(int id, string name) { this.id = id; this.name = name; }
    }
}
