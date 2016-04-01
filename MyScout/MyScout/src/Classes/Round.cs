using System.Collections.Generic;

namespace MyScout
{
    /// <summary>
    /// This defines the "Round" type variable.
    /// </summary>
    public class Round
    {
        #region Variable Declaration/Definition
        /// <summary>
        /// The IDs associated with the teams that are a part of this round.
        /// First three values are part of the red alliance, last three values
        /// are part of the blue alliance. <para/>
        /// 
        /// "-1" means no team has been assigned to that slot.
        /// </summary>
        public int[] teams = new int[6] { -1, -1, -1, -1, -1, -1 };
        /// <summary>
        /// TODO: Documentation
        /// </summary>
        public List<DataPoint>[] dataset;
        #endregion

        public Round()
        {
            //Make 6 lists of datapoints within the existing dataset variable - one for each team in the round.
            dataset = new List<DataPoint>[6];

            for (int i = 0; i < 6; i++)
            {
                dataset[i] = Program.dataset[1];
            }
        }
    }
}