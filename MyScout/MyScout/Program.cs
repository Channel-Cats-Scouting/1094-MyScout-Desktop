using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyScout
{
    static class Program
    {
        #region Variable Declarations/Definitions

        #region Generic
        /// <summary>
        /// The current version of the application in string form.
        /// </summary>
        public static string versionstring = "3.5";
        /// <summary>
        /// The path the program was started from.
        /// </summary>
        public static string startuppath;
        /// <summary>
        /// A publicly-accessable instance of the main form.
        /// </summary>
        public static MainFrm mainfrm;
        /// <summary>
        /// Whether or not the program has saved all its data.
        /// </summary>
        public static bool saved
        {
            get { return Saved; }

            set
            {
                Saved = value;
                mainfrm.UpdateTitle();
            }
        }
        private static bool Saved = true;
        #endregion

        #region Scouting-related
        /// <summary>
        /// The data model to be referenced for saving/loading.
        /// 0 is pre/team scouting, 1 is round scouting, and 2 is score-compiling
        /// </summary>
        public static List<List<DataPoint>> dataset;
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
        /// "-1" means no value has been set.
        /// </summary>
        public static int selectedteamroundindex = -1;
        /// <summary>
        /// The current team that's been selected.
        /// "-1" means no value has been set.
        /// </summary>
        public static int selectedteam = -1;
        #endregion

        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Set the path the application was started from. Used for saving data within the application's directory.
            startuppath = Application.StartupPath;

            //Configure various GUI elements of the application.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region DataSet Initialization
            //Pre/Team-related Scouting
            dataset = new List<List<DataPoint>>();
            dataset.Add(new List<DataPoint>());
            dataset.Add(new List<DataPoint>());
            dataset.Add(new List<DataPoint>());
            dataset[0].Add(new DataPoint("Name", typeof(string)));              //The team's name.
            dataset[0].Add(new DataPoint("ID", typeof(int)));                   //The team's ID (I.E. 1094)
            dataset[0].Add(new DataPoint("Score", typeof(int)));                //The team's score.
            dataset[0].Add(new DataPoint("CanCross", typeof(List<bool>)));      //A list of values defining whether or not the team claims they can cross a defense for each of the 9 defenses.
            dataset[0].Add(new DataPoint("CanHighGoal", typeof(bool)));         //Whether or not the team claims they can shoot boulders into the high goal.
            dataset[0].Add(new DataPoint("CanLowGoal", typeof(bool)));          //Whether or not the team claims they can shoot boulders into the low goal.
            dataset[0].Add(new DataPoint("FromFloor", typeof(bool)));           //Whether or not the team claims they can collect boulders from the floor.
            dataset[0].Add(new DataPoint("FromHuman", typeof(bool)));           //Whether or not the team claims they can collect boulders from the human player station.
            dataset[0].Add(new DataPoint("Prefers", typeof(int)));              //Whether the team prefers the human player station (2), floor (1), or none (0).

            //Round Scouting
            dataset[1].Add(new DataPoint("TDefenses", typeof(List<int>)));      //Defense-related data collected during the Tele-Op period.
            dataset[1].Add(new DataPoint("ADefenses", typeof(List<int>)));      //Defense-related data collected during the Autonomous period.
            dataset[1].Add(new DataPoint("ScaledTower", typeof(bool)));         //Whether or not the robot scaled the tower.
            dataset[1].Add(new DataPoint("OnBatters", typeof(bool)));           //Whether or not the robot challenged the tower.
            dataset[1].Add(new DataPoint("AHighGoal", typeof(bool)));           //Whether or not the robot got a score in the high goal in Autonomous.
            dataset[1].Add(new DataPoint("ALowGoal", typeof(bool)));            //Whether or not the robot got a score in the low goal in Autonomous.
            dataset[1].Add(new DataPoint("THighGoals", typeof(int)));           //How many times the robot got a score in the high goal in Tele-Op.
            dataset[1].Add(new DataPoint("TLowGoals", typeof(int)));            //How many times the robot got a score in the low goal in Tele-Op.
            dataset[1].Add(new DataPoint("Comments", typeof(string)));          //Comments related to the match that don't fit in other categories.
            dataset[1].Add(new DataPoint("HComments", typeof(string)));         //Comments related to the performance of the human player.
            dataset[1].Add(new DataPoint("Died", typeof(bool)));                //Whether or not the robot died.
            dataset[1].Add(new DataPoint("DiedDefense", typeof(int)));          //The index of the defense the robot died on.
            dataset[1].Add(new DataPoint("DComments", typeof(string)));         //Comments related to how the robot died.

            //Score compiling
            dataset[2].Add(new DataPoint("TDefTotals", typeof(List<int>)));     //Defense-related totals, with counts for amounts of defense crossings during Tele-Op
            dataset[2].Add(new DataPoint("ADefTotals", typeof(List<int>)));     //Defense-related totals, with counts for amounts of defense crossings during Automode
            dataset[2].Add(new DataPoint("ScaledTotal", typeof(int)));          //The amount of times the robot scaled the tower
            dataset[2].Add(new DataPoint("OnBattTotal", typeof(int)));          //The amount of times the robot challenged the tower
            dataset[2].Add(new DataPoint("AHighTotal", typeof(int)));           //The amount of times the robot got a score in the high goal in Autonomous
            dataset[2].Add(new DataPoint("ALowTotal", typeof(int)));            //The amount of times the robot got a score in the low goal in Autonomous
            dataset[2].Add(new DataPoint("THighTotal", typeof(int)));           //The amount of times the robot got a score in the high goal in Tele-Op
            dataset[2].Add(new DataPoint("TLowGoals", typeof(int)));            //The amount of times the robot got a score in the low goal in Tele-Op
            dataset[2].Add(new DataPoint("DiedTotal", typeof(int)));            //The amount of times the robot died
            #endregion

            //Begin the GUI side of the application
            mainfrm = new MainFrm();
            Application.Run(mainfrm);
        }
    }
}