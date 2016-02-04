using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScout
{
    /// <summary>
    /// TODO: Documentation
    /// </summary>
    public class Defense
    {
        /// <summary>
        /// How well the team does at crossing this defense.
        /// For example, if a team is skilled at crossing a defense, the defense's "skill" variable would be set to "Rating.Good."
        /// </summary>
        public Rating skill;
        /// <summary>
        /// Whether or not the team reached this defense.
        /// </summary>
        public bool reached = false;
        /// <summary>
        /// How many times the team crossed this defense.
        /// </summary>
        public int timescrossed = 0;
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
