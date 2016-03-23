using System;

namespace MyScout
{
    /// <summary>
    /// This defines the "Team" type variable.
    /// </summary>
    public class Team
    {
        #region Variables
        #region Constants
        /// <summary>
        /// The name of the team (E.G. "Channel Cats").
        /// </summary>
        public string name = "NO NAME LOADED";
        /// <summary>
        /// The id of the team (E.G. "1094").
        /// </summary>
        public int id = 0000;
        #endregion
        #region Scores
        /// <summary>
        /// The team's total score.
        /// </summary>
        public int avgScore = 0;
        /// <summary>
        /// The team's total count of defenses crossed.
        /// </summary>
        public float teleDefensesCrossed = 0;
        /// <summary>
        /// High goals scored in tele-op
        /// </summary>
        public float teleHighGoals = 0;
        /// <summary>
        /// Low goals scored in tele-op
        /// </summary>
        public float teleLowGoals = 0;
        /// <summary>
        /// Towers scaled
        /// </summary>
        public float towersScaled = 0;
        /// <summary>
        /// Towers challenged
        /// </summary>
        public int towersChallenged = 0;

        /// <summary>
        /// A list of defenses with the amount of times it has crossed each of them
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
        public int[] defensesCrossed = new int[9];

        /// <summary>
        /// A list of defenses the team has crossed at least once.
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
        public bool[] smartDefensesCrossable = new bool[9];

        /// <summary>
        /// A score based on how well the team can cross defenses
        /// </summary>
        public int crossingPowerScore = 0;

        /// <summary>
        /// Average defenses crossed per round
        /// </summary>
        public float[] autoDefensesCrossed = new float[9];
        public float autoDefensesReached = 0;
        public int autoHighGoals = 0;
        public int autoLowGoals = 0;
        #endregion
        #region PreScout
        public bool canScoreHighGoals = false;
        public bool canScoreLowGoals = false;
        public bool loadsFromHumanPlayerStations = false;
        public bool loadsFromFloor = false;
        public int prefers = 0;

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
        #endregion
        #region Death
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

        #endregion
        #endregion

        /// <summary>
        /// TODO: Documentation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Team(int id, string name) { this.id = id; this.name = name; }

        public void UpdateTeamScore()
        {
            CalcCrossingPower();
            CalcAvgScore();
        }

        /// <summary>
        /// Calculate and save the total score based on the point values
        /// for each scoring opportunity. Point values are from the official rules
        /// </summary>
        public int CalcAvgScore()
        {
            avgScore = 0;
            avgScore = Convert.ToInt16(
                autoDefensesReached * 2 +
                autoHighGoals * 10 +
                autoLowGoals * 5 +
                teleHighGoals * 5 +
                teleLowGoals * 2 +
                towersScaled * 15
                );

            foreach (int times in defensesCrossed)
            {
                avgScore += times * 5;
            }
            foreach (int times in autoDefensesCrossed)
            {
                avgScore += times * 10;
            }

            return avgScore;
        }

        /// <summary>
        /// Calculate and save the crossing power based on the difficulty
        /// of circumventing defenses.
        /// </summary>
        public int CalcCrossingPower()
        {
            crossingPowerScore = 0;
            for(int i = 0; i < 8; i++)
            {
                if (defensesCrossable[i])
                {
                    switch (i)
                    {
                        case 0: //portcullis
                            crossingPowerScore += 4;
                            break;

                        case 1: //cheval de frise
                            crossingPowerScore += 4;
                            break;

                        case 2: //moat
                            crossingPowerScore += 3;
                            break;

                        case 4: //drawbridge
                            crossingPowerScore += 3;
                            break;

                        case 8: //low bar
                            crossingPowerScore += 1;
                            break;

                        default:
                            crossingPowerScore += 2;
                            break;
                    }
                }
            }
            return crossingPowerScore;
        }

        /// <summary>
        /// Updates defensesCrossable[] with data from defensesCrossed[]
        /// </summary>
        public void updateDefenseStats()
        {
            for(int i = 0; i < 9; i++)
            {
                defensesCrossable[i] = defensesCrossable[i] ? true : defensesCrossed[i] > 0;
            }
        }
    }
}
