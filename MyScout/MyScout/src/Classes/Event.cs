using System;
using System.Collections.Generic;

namespace MyScout
{
    /// <summary>
    /// This defines the "Event" type variable.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// The name of the event (E.G. "Chaifetz Arena").
        /// </summary>
        public string name = "MISSINGNO";
        /// <summary>
        /// The date the event begins on (E.G. March 10th).
        /// </summary>
        public string begindate = $"{DateTime.Now.Month.ToString()}/{DateTime.Now.Day.ToString()}/{DateTime.Now.Year.ToString()}";
        /// <summary>
        /// The date the event ends on (E.G. March 12th).
        /// </summary>
        public string enddate   = $"{DateTime.Now.Month.ToString()}/{DateTime.Now.Day.ToString()}/{DateTime.Now.Year.ToString()}";

        /// <summary>
        /// The teams attending the event.
        /// </summary>
        public List<Team> teams = new List<Team>();
        /// <summary>
        /// TODO: Documentation.
        /// </summary>
        public List<Round> rounds = new List<Round>() { new Round() };
        /// <summary>
        /// TODO: Documentation.
        /// </summary>
        public int lastviewedround = -1;

        public Event(string name, string begindate, string enddate) { this.name = name; this.begindate = begindate; this.enddate = enddate; }
    }
}
