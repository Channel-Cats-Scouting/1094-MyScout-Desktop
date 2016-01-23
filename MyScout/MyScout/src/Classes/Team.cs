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

        /// <summary>
        /// How well the team does with crossing each defense.
        /// Each defense coresponds with an ID which is used to identify it.<para />
        /// 
        /// 0 = Portcullis,
        /// 1 = Cheval de Frise,
        /// 2 = Moat,
        /// 3 = Ramparts,
        /// 4 = Drawbridge,
        /// 5 = Sally Port,
        /// 6 = Rock Wall,
        /// 7 = Rough Terrain,
        /// 8 = Low Bar <para/>
        /// 
        /// As an example, if a team does a really good job of breaching the Moat,
        /// skillwithdefenses[2] would equal "Rating.Good." Whereas if the same team
        /// did a poor job of breaching the Rough Terrain, skillwithdefenses[7] would
        /// equal "Rating.Poor."
        /// </summary>
        public Rating[] skillwithdefenses = new Rating[9];
    }

    /// <summary>
    /// An enumerator used to rate something.
    /// </summary>
    public enum Rating
    {
        Good,
        Mediocre,
        Poor
    }
}
