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
        public int avgScore = 0;
        /// <summary>
        /// The team's total count of defenses crossed.
        /// </summary>
        public float teleDefensesCrossed = 0;
        public float teleHighGoals = 0;
        public float teleLowGoals = 0;
        public float towerScaledAvg = 0;

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
        /// Average defenses crossed per round
        /// </summary>
        public float autoDefensesCrossed = 0;
        public float autoDefensesReached = 0;
        public float autoHighGoals = 0;
        public float autoLowGoals = 0;

        /// <summary>
        /// Total amount of times the robot stopped working at any moment on the field
        /// </summary>
        public int deathCount = 0;

        /// <summary>
        /// A list of defenses with the amount of times it failed on each.
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
        public int[] deathDefenses = new int[9];

        public Team(int id, string name) { this.id = id; this.name = name; }

        public void updateTeamScores()
        {
            calcCrossingPower();
            calcAvgScore();
        }

        /// <summary>
        /// Calculate and save the total score based on the point values
        /// for each scoring opportunity. Point values are from the official rules
        /// </summary>
        public int calcAvgScore()
        {
            avgScore = 0;
            avgScore = Convert.ToInt16(
                autoDefensesReached * 2 +
                autoDefensesReached * 10 +
                autoHighGoals * 10 +
                autoLowGoals * 5 +
                teleDefensesCrossed * 5 +
                teleHighGoals * 5 +
                teleLowGoals * 2 +
                towerScaledAvg * 15
                );


            return avgScore;
        }

        /// <summary>
        /// Calculate and save the crossing power based on the difficulty
        /// of circumventing defenses.
        /// </summary>
        public int calcCrossingPower()
        {
            crossingPowerScore = 0;
            for(int i = 0; i < 8; i++)
            {
                if(defensesCrossable[i])
                {
                    if(i == 0)//portcullis
                        crossingPowerScore += 5;

                    else if(i == 1)//cheval de frise
                        crossingPowerScore += 5;

                    else if(i == 2)//moat
                        crossingPowerScore += 3;

                    else if(i == 4)//drawbridge
                        crossingPowerScore += 4;

                    else if(i == 8)//low bar
                        crossingPowerScore += 1;

                    else crossingPowerScore += 2;
                }
            }
            return crossingPowerScore;
        }
    }
}
