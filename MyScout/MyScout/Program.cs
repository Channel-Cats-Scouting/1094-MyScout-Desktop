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
        public const string VersionString = "4.1";

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
        /// The current team that's been selected.
        /// "-1" means no value has been set.
        /// </summary>
        public static int CurrentTeamIndex = -1;
        /// <summary>
        /// The index of the round's "teams" variable that contains the index of the currently selected team.
        /// "-1" means no value has been set.
        /// </summary>
        public static int SelectedTeamRoundIndex = -1;

        /// <summary>
        /// Shorthand for getting/setting the current event.
        /// </summary>
        public static Event CurrentEvent
        {
            get
            {
                return (CurrentEventIndex != -1) ? 
                    Events[CurrentEventIndex] : null;
            }

            set
            {
                if (CurrentEventIndex != -1)
                    Events[CurrentEventIndex] = value;
            }
        }

        /// <summary>
        /// Shorthand for getting/setting the current event's current round.
        /// </summary>
        public static Round CurrentRound
        {
            get
            {
                return (CurrentEventIndex != -1 && CurrentRoundIndex != -1) ?
                    CurrentEvent.rounds[CurrentRoundIndex] : null;
            }

            set
            {
                if (CurrentEventIndex != -1 && CurrentRoundIndex != -1)
                    CurrentEvent.rounds[CurrentRoundIndex] = value;
            }
        }

        /// <summary>
        /// Shorthand for getting/setting the current event's current team.
        /// </summary>
        public static Team CurrentTeam
        {
            get
            {
                return (CurrentEventIndex != -1 && CurrentTeamIndex != -1) ?
                    CurrentEvent.teams[CurrentTeamIndex] : null;
            }

            set
            {
                if (CurrentEventIndex != -1 && CurrentTeamIndex != -1)
                    CurrentEvent.teams[CurrentTeamIndex] = value;
            }
        }
        #endregion

        #endregion

        #region Global Utilities

        /// <summary>
        /// Gets the index of a team in the CurrentEvent.teams list. Returns -1 if it's not in the list
        /// </summary>
        /// <param name="team"></param>
        /// <returns>index</returns>
        public static int GetTeamGlobalIndex(Team team)
        {
            for(int i = 0; i < CurrentEvent.teams.Count; ++i)
            {
                if(team.Equals(CurrentEvent.teams[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public static int GetTeamGlobalIndexFromTeamID(int teamnbr)
        {
            for (int i = 0; i < CurrentEvent.teams.Count; ++i)
            {
                if (teamnbr == CurrentEvent.teams[i].id)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Gets the Team object stored in CurrentEvent.teams, Returns null if it's out of bounds
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Team GetTeamFromGlobalIndex(int index)
        {
            Team outteam;
            try { outteam = CurrentEvent.teams[index]; } catch { outteam = null; }
            return outteam;
        }

        public static void AddRound(Round round)
        {
            CurrentEvent.rounds.Add(round);
        }

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

            //Initialize the DataSet™
            DataSet = new List<List<DataPoint>>();
            DataSet.Add(new List<DataPoint>());
            DataSet.Add(new List<DataPoint>());
            DataSet.Add(new List<DataPoint>());

            //Begin the GUI side of the application
            MainFrm = new MainFrm();
            Application.Run(MainFrm);
        }
    }
}