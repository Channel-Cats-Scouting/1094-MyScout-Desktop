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
        public static string versionstring = "3.5";
        /// <summary>
        /// Whether or not the program has saved all its data.
        /// </summary>
        private static bool Saved = true;
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
        /// The data model to be referenced for saving/loading.
        /// 0 is pre/team scouting, 1 is round scouting
        /// </summary>
        public static List<List<DataPoint>> dataset;
        /// <summary>
        /// A publicly-accessable instance of the main form.
        /// </summary>
        public static MainFrm mainfrm;

        public static bool saved
        {
            get
            {
                return Saved;
            }

            set
            {
                Saved = value;
                mainfrm.UpdateTitle();
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            startuppath = Application.StartupPath;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region DataSet init
            //Auto Scouting
            dataset = new List<List<DataPoint>>();
            dataset[0].Add(new DataPoint("Name", DataPoint.STRING));
            dataset[0].Add(new DataPoint("ID", DataPoint.INT));
            dataset[0].Add(new DataPoint("Score", DataPoint.INT));
            dataset[0].Add(new DataPoint("CanCross", DataPoint.BOOL_LIST));
            dataset[0].Add(new DataPoint("CanHighGoal", DataPoint.BOOL));
            dataset[0].Add(new DataPoint("CanLowGoal", DataPoint.BOOL));
            dataset[0].Add(new DataPoint("FromFloor", DataPoint.BOOL));
            dataset[0].Add(new DataPoint("FromHuman", DataPoint.BOOL));
            dataset[0].Add(new DataPoint("Prefers", DataPoint.INT));

            //Round Scouting
            dataset[1].Add(new DataPoint("TDefenses", DataPoint.INT_LIST));
            dataset[1].Add(new DataPoint("ADefenses", DataPoint.INT_LIST));
            dataset[1].Add(new DataPoint("ScaledTower", DataPoint.BOOL));
            dataset[1].Add(new DataPoint("OnBatters", DataPoint.BOOL));
            dataset[1].Add(new DataPoint("AHighGoal", DataPoint.BOOL));
            dataset[1].Add(new DataPoint("ALowGoal", DataPoint.BOOL));
            dataset[1].Add(new DataPoint("THighGoals", DataPoint.INT));
            dataset[1].Add(new DataPoint("TLowGoals", DataPoint.INT));
            dataset[1].Add(new DataPoint("Comments", DataPoint.STRING));
            dataset[1].Add(new DataPoint("HComments", DataPoint.STRING));
            dataset[1].Add(new DataPoint("Died", DataPoint.BOOL));
            dataset[1].Add(new DataPoint("DiedDefense", DataPoint.INT));
            dataset[1].Add(new DataPoint("DComments", DataPoint.STRING));
            #endregion

            mainfrm = new MainFrm();
            Application.Run(mainfrm);
        }
    }
}
