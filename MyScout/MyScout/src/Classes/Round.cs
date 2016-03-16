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
        /// <summary>
        /// The alliances' current scores.
        /// </summary>
        public static int[] score = new int[2] { 0, 0 };
        /// <summary>
        /// TODO: Documentation
        /// </summary>
        public Defense[,] defenses = new Defense[6,9];
        /// <summary>
        /// TODO: Documentation
        /// </summary>
        public Defense[,] autodefenses = new Defense[6, 9];
        /// <summary>
        /// TODO: Documentation
        /// </summary>
        public bool[] scaledtower = new bool[6] { false, false, false, false, false, false };
        /// <summary>
        /// TODO: Documentation
        /// </summary>
        public bool[] challengedtower = new bool[6] { false, false, false, false, false, false };
        /// <summary>
        /// TODO: Documentation
        /// </summary>
        public int[] AOhighgoalcount = new int[6] { 0, 0, 0, 0, 0, 0 };
        /// <summary>
        /// TODO: Documentation
        /// </summary>
        public int[] AOlowgoalcount = new int[6] { 0, 0, 0, 0, 0, 0 };
        /// <summary>
        /// TODO: Documentation
        /// </summary>
        public int[] TOhighgoalcount = new int[6] { 0, 0, 0, 0, 0, 0 };
        /// <summary>
        /// TODO: Documentation
        /// </summary>
        public int[] TOlowgoalcount = new int[6] { 0, 0, 0, 0, 0, 0 };
        /// <summary>
        /// TODO: Documentation
        /// </summary>
        public string[] comments = new string[6] { " ", " ", " ", " ", " ", " " };
        /// <summary>
        /// TODO: Documentation
        /// </summary>
        public string[] humancomments = new string[6] { " ", " ", " ", " ", " ", " " };
        /// <summary>
        /// TODO: Documentation
        /// </summary>
        public bool[] died = new bool[6] { false, false, false, false, false, false };
        /// <summary>
        /// TODO: Documentation
        /// </summary>
        public int[] dieddefense = new int[6] { 0, 0, 0, 0, 0, 0 };
        /// <summary>
        /// TODO: Documentation
        /// </summary>
        public string[] diedcomments = new string[6] { " ", " ", " ", " ", " ", " " };

        public Round()
        {
            //TODO: Documentation
            for (int i = 0; i < 6; i++)
            {
                for (int i2 = 0; i2 < 9; i2++)
                {
                    defenses[i, i2] = new Defense();
                }
            }
        }
    }
}
