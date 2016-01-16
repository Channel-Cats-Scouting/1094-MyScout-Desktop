using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016Scoring
{
    public class Event
    {
        public string name = "THE LAST EVENT";
        public string date = $"{DateTime.Now.Month.ToString()}/{DateTime.Now.Day.ToString()}/{DateTime.Now.Year.ToString()}";

        public List<Team> Teams = new List<Team>();

        /// <summary>
        /// An event is the basis that holds all scouting-related data.
        /// 
        /// The idea is that you have one event for each competition, each
        /// holding all the scouting-related information specific to that event.
        /// </summary>
        /// <param name="name">The name of the event</param>
        /// <param name="date">The date the event takes place</param>
        public Event(string name, string date) { this.name = name; this.date = date; }
    }
}
