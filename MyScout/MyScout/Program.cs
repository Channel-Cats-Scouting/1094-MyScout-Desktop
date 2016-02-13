using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyScout
{
    static class Program
    {
        /// <summary>
        /// The list of events to be used by the application.
        /// </summary>
        public static List<Event> events = new List<Event>();
        /// <summary>
        /// The current event that's been selected from the list.
        /// </summary>
        public static int currentevent = 0;
        /// <summary>
        /// The current round of the game.
        /// </summary>
        public static int currentround = 0;
        /// <summary>
        /// The index of the round's "teams" variable that contains the index of the currently selected team.
        /// </summary>
        public static int selectedteamroundindex = -1;
        /// <summary>
        /// The current team that's been selected.
        /// </summary>
        public static int selectedteam = -1;
        //TODO: Un-comment this ^ and make a get-set event for it.

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFrm());
        }
    }
}
