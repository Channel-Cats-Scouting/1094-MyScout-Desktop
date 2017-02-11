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
        public int[] Teams = new int[6] { -1, -1, -1, -1, -1, -1 };
        /// <summary>
        /// An array of lists of datapoints, with one list for each team.
        /// </summary>
        public List<List<DataPoint>> DataSet;
        #endregion

        public Round()
        {
            //Make 6 lists of datapoints within the existing dataset variable - one for each team in the round.
            DataSet = new List<List<DataPoint>>();

            for (int i = 0; i < 6; ++i) //For each team in the round
            {
                List<DataPoint> points = new List<DataPoint>();
                for (int j = 0; j < Program.DataSet[1].Count; j++)
                {
                    points.Add(new DataPoint(Program.DataSet[1][j]));
                }
                DataSet.Add(points); //Assign it a copy of the dataset
            }
        }
    }
}