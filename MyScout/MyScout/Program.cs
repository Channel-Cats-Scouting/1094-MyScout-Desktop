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
        /// A publicly-accessable instance of the main form.
        /// </summary>
        public static MainFrm MainFrm;
        public static string DataSetName = "";

        /// <summary>
        /// The path the program was started from.
        /// </summary>
        public static readonly string StartupPath = Application.StartupPath;
        /// <summary>
        /// The current version of the application in string form.
        /// </summary>
        public const string VersionString = "3.5";

        /// <summary>
        /// Whether or not the program has saved all its data.
        /// </summary>
        public static bool Saved
        {
            get { return saved; }

            set
            {
                saved = value;
                MainFrm.UpdateTitle();
            }
        }
        private static bool saved = true;
        #endregion

        #region Scouting-related
        /// <summary>
        /// The data model to be referenced for saving/loading.
        /// 0 is pre/team scouting, 1 is round scouting, and 2 is score-compiling variables. 3 is functions for totalling up team data into the score-compiling variables.
        /// </summary>
        public static List<List<DataPoint>> DataSet;
        /// <summary>
        /// The list of events to be used by the application.
        /// </summary>
        public static List<Event> Events = new List<Event>();
        /// <summary>
        /// The current event that's been selected from the list.
        /// "-1" means no value has been set.
        /// </summary>
        public static int CurrentEventIndex = -1;
        /// <summary>
        /// The current round of the game.
        /// "-1" means no value has been set.
        /// </summary>
        public static int CurrentRoundIndex = -1;
        /// <summary>
        /// The index of the round's "teams" variable that contains the index of the currently selected team.
        /// "-1" means no value has been set.
        /// </summary>
        public static int CurrentTeamIndex = -1;
        /// <summary>
        /// The current team that's been selected.
        /// "-1" means no value has been set.
        /// </summary>
        public static int SelectedTeamIndex = -1;
        #endregion

        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Configure various GUI elements of the application.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region DataSet Initialization

            DataSet = new List<List<DataPoint>>();
            DataSet.Add(new List<DataPoint>());
            DataSet.Add(new List<DataPoint>());
            DataSet.Add(new List<DataPoint>());

            //Pre/Team-related Scouting
            DataSet[0].Add(new DataPoint("Score", typeof(int)));                //The team's score.
            DataSet[0].Add(new DataPoint("CanCross", typeof(List<bool>)));      //A list of values defining whether or not the team claims they can cross a defense for each of the 9 defenses.
            DataSet[0].Add(new DataPoint("CanHighGoal", typeof(bool)));         //Whether or not the team claims they can shoot boulders into the high goal.
            DataSet[0].Add(new DataPoint("CanLowGoal", typeof(bool)));          //Whether or not the team claims they can shoot boulders into the low goal.
            DataSet[0].Add(new DataPoint("FromFloor", typeof(bool)));           //Whether or not the team claims they can collect boulders from the floor.
            DataSet[0].Add(new DataPoint("FromHuman", typeof(bool)));           //Whether or not the team claims they can collect boulders from the human player station.
            DataSet[0].Add(new DataPoint("Prefers", typeof(int)));              //Whether the team prefers the human player station (2), floor (1), or none (0).

            //Round Scouting
            DataSet[1].Add(new DataPoint("TDefenses", typeof(List<int>)));      //Defense-related data collected during the Tele-Op period.
            DataSet[1].Add(new DataPoint("ADefenses", typeof(List<int>)));      //Defense-related data collected during the Autonomous period.
            DataSet[1].Add(new DataPoint("ScaledTower", typeof(bool)));         //Whether or not the robot scaled the tower.
            DataSet[1].Add(new DataPoint("OnBatters", typeof(bool)));           //Whether or not the robot challenged the tower.
            DataSet[1].Add(new DataPoint("AHighGoal", typeof(bool)));           //Whether or not the robot got a score in the high goal in Autonomous.
            DataSet[1].Add(new DataPoint("ALowGoal", typeof(bool)));            //Whether or not the robot got a score in the low goal in Autonomous.
            DataSet[1].Add(new DataPoint("THighGoals", typeof(int)));           //How many times the robot got a score in the high goal in Tele-Op.
            DataSet[1].Add(new DataPoint("TLowGoals", typeof(int)));            //How many times the robot got a score in the low goal in Tele-Op.
            DataSet[1].Add(new DataPoint("Comments", typeof(string)));          //Comments related to the match that don't fit in other categories.
            DataSet[1].Add(new DataPoint("HComments", typeof(string)));         //Comments related to the performance of the human player.
            DataSet[1].Add(new DataPoint("Died", typeof(bool)));                //Whether or not the robot died.
            DataSet[1].Add(new DataPoint("DiedDefense", typeof(int)));          //The index of the defense the robot died on.
            DataSet[1].Add(new DataPoint("DComments", typeof(string)));         //Comments related to how the robot died.

            //Score compiling
            DataSet[2].Add(new DataPoint("TDefTotals", typeof(List<int>)));     //Defense-related totals, with counts for amounts of defense crossings during Tele-Op
            DataSet[2].Add(new DataPoint("ADefTotals", typeof(List<int>)));     //Defense-related totals, with counts for amounts of defense crossings during Automode
            DataSet[2].Add(new DataPoint("ScaledTotal", typeof(int)));          //The amount of times the robot scaled the tower
            DataSet[2].Add(new DataPoint("OnBattTotal", typeof(int)));          //The amount of times the robot challenged the tower
            DataSet[2].Add(new DataPoint("AHighTotal", typeof(int)));           //The amount of times the robot got a score in the high goal in Autonomous
            DataSet[2].Add(new DataPoint("ALowTotal", typeof(int)));            //The amount of times the robot got a score in the low goal in Autonomous
            DataSet[2].Add(new DataPoint("THighTotal", typeof(int)));           //The amount of times the robot got a score in the high goal in Tele-Op
            DataSet[2].Add(new DataPoint("TLowGoals", typeof(int)));            //The amount of times the robot got a score in the low goal in Tele-Op
            DataSet[2].Add(new DataPoint("DiedTotal", typeof(int)));            //The amount of times the robot died
            #endregion

            //Begin the GUI side of the application
            MainFrm = new MainFrm();
            Application.Run(MainFrm);
        }
    }
}