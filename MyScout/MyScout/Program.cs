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
        /// The current version of the application in string form.
        /// </summary>
        public static string versionstring = "2.0";
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
        /// <summary>
        /// The path the program was started from.
        /// </summary>
        public static string startuppath;
        /// <summary>
        /// A publicly-accessable instance of the main form.
        /// </summary>
        public static MainFrm mainfrm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            startuppath = Application.StartupPath;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainfrm = new MainFrm();
            Application.Run(mainfrm);
        }
    }
}
