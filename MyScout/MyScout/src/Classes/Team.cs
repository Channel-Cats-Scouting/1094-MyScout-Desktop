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
        public string name = "NO NAME LOADED"; //Helpfulness improved at the cost of comedy :P
        /// <summary>
        /// The id of the team (E.G. "1094").
        /// </summary>
        public int id = 0000; //Helpfulness Improved
        /// <summary>
        /// The team's total score.
        /// </summary>
        public int totalScore = 0;
        /// <summary>
        /// The team's total count of defenses crossed.
        /// </summary>
        public int teleDefensesCrossedCount = 0;
        public int teleHighGoals = 0;
        public int teleLowGoals = 0;
        public int towerScaledCount = 0;

        /// <summary>
        /// A list of defenses this team can cross.
        /// Each index references a different defense:
        /// [0]: Portcullis
        /// [1]: Cheval de Frise
        /// [2]: Moat
        /// [3]: Ramparts
        /// [4]: Drawbridge
        /// [5]: Sally Port
        /// [6]: Rock Wall
        /// [7]: Rough Terrain
        /// [8]: Low Bar
        /// </summary>
        public bool[] defensesCrossable = new bool[9];

        /// <summary>
        /// A score based on how well the team can cross defenses
        /// </summary>
        public int crossingPowerScore = 0;

        /// <summary>
        /// A list of defenses this team has interacted with in auto mode.
        /// Each index references a different defense:
        /// [0]: Portcullis
        /// [1]: Cheval de Frise
        /// [2]: Moat
        /// [3]: Ramparts
        /// [4]: Drawbridge
        /// [5]: Sally Port
        /// [6]: Rock Wall
        /// [7]: Rough Terrain
        /// [8]: Low Bar
        /// </summary>
        public int autoDefensesCrossed = 0;
        public int autoHighGoals = 0;
        public int autoLowGoals = 0;

        /// <summary>
        /// Total amount of times the robot stopped working at any moment on the field
        /// </summary>
        public int deathCount = 0;

        public Team(int id, string name) { this.id = id; this.name = name; }
    }
}
