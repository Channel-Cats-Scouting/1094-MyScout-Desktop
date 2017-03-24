using ExcelLibrary.SpreadSheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace MyScout
{
    public static class IO
    {
        #region Constants and Paths
        public static readonly string REPORTS_FOLDER_ROOT = Program.StartupPath + "\\Spreadsheets\\";
        public static readonly string EVENTS_FOLDER_ROOT = Program.StartupPath + "\\Events\\";
        public static readonly string DATASETS_FOLDER_ROOT = Program.StartupPath + "\\Datasets\\";
        public static readonly string REPORT_PROFILES_FOLDER_ROOT = REPORTS_FOLDER_ROOT + "\\Profiles\\";

        public static readonly string REPORT_PREFIX = "Report for ";

        private static string reportsFolder() { return REPORTS_FOLDER_ROOT + Program.DataSetName; }
        private static string eventsFolder() { return EVENTS_FOLDER_ROOT + Program.DataSetName; }
        private static string reportProfilesFolder() { return REPORT_PROFILES_FOLDER_ROOT; }
        #endregion

        #region Input-related functions

        /// <summary>
        /// Loads all events from the program's event folder.
        /// </summary>
        public static void LoadAllEvents()
        {
            if (!Directory.Exists(eventsFolder()))
            {
                Directory.CreateDirectory(eventsFolder());
            }
            string[] files = Directory.GetFiles(eventsFolder());

            for (int i = 0; i < files.Length; ++i)
            {
                LoadEvent(files[i]);
            }
            Program.MainFrm.Invoke(new Action(() => { Program.MainFrm.RefreshEventList(); }));
        }

        public static void LoadCSV(string path)
        {
            try {
                string[] splitText = File.ReadAllText(path).Split(',');

                List<int> allTeamNums = new List<int>();
                List<int[]> allNewRounds = new List<int[]>();

                for (int i = 0; i < splitText.Length; ++i)
                {
                    string s = splitText[i];            //Splits the CSV using commas
                    if (s.StartsWith("Quals"))
                    {
                        //Contains the 3 red, then 3 blue teams
                        int[] teamnums = new int[6];

                        //For each red team, save the team number
                        for (int j = 0; j < 3; ++j)
                        {
                            teamnums[j] = Convert.ToInt16(splitText[i + j + 1]);
                            if (!allTeamNums.Contains(teamnums[j]))
                            {
                                allTeamNums.Add(teamnums[j]);
                            }
                        }

                        //For each blue team, save the team number
                        for (int j = 3; j < 6; ++j)
                        {
                            teamnums[j] = Convert.ToInt16(splitText[i + j + 2]);
                            if (!allTeamNums.Contains(teamnums[j]))
                            {
                                allTeamNums.Add(teamnums[j]);
                            }
                        }

                        allNewRounds.Add(teamnums);
                    }
                }
                
                Program.CurrentEvent.rounds.Clear();

                //Add each new team to the Event.teams list
                foreach (int teamnum in allTeamNums)
                {
                    if (Program.GetTeamGlobalIndexFromTeamID(teamnum) == -1)
                    {
                        Program.CurrentEvent.teams.Add(new Team(teamnum, ""));
                    }
                }

                //Add each new round to the Event.rounds list
                foreach (int[] roster in allNewRounds)
                {
                    //Add a new round, with the team global indices correctly set.
                    //Using roster on its own would set the indices incorrectly,
                    //  as roster contains team ID numbers.
                    //
                    //  ~Ethan Schrunk, who DEFINITELY did not do the above, definitely. :P
                    Program.AddRound(new Round(new int[]
                        {
                            Program.GetTeamGlobalIndexFromTeamID(roster[0]),
                            Program.GetTeamGlobalIndexFromTeamID(roster[1]),
                            Program.GetTeamGlobalIndexFromTeamID(roster[2]),
                            Program.GetTeamGlobalIndexFromTeamID(roster[3]),
                            Program.GetTeamGlobalIndexFromTeamID(roster[4]),
                            Program.GetTeamGlobalIndexFromTeamID(roster[5])
                        }));
                }

                Program.MainFrm.RefreshAfterRoundEdit();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Something went wrong while loading the CSV:\n\n" + ex);
            }
        }

        /// <summary>
        /// Loads the given event from an XML file.
        /// </summary>
        /// <param name="eventid">The ID of the XML file to load.</param>
        public static void LoadEvent(string fileName)
        {
            try
            {
                if (File.Exists(fileName) && fileName.EndsWith(".xml"))
                {
                    using (var fileStream = File.OpenRead(fileName))
                    {
                        XDocument xml = XDocument.Load(fileStream);
                        string fileVersionString = xml.Root.Element("Version").Value;
                        string fileDataSet = xml.Root.Element("DataSet").Value;

                        if (fileDataSet != Program.DataSetName)
                            return;

                        Program.Events.Add(new Event(xml.Root.Element("Name").Value,
                            xml.Root.Element("BeginDate").Value,
                            xml.Root.Element("EndDate").Value, 
                            fileDataSet,
                            fileName.Replace(eventsFolder() + "\\", "")));

                        Program.Events[Program.Events.Count - 1].rounds.Clear();

                        var teamsElement = xml.Root.Element("Teams");
                        int count = Convert.ToInt32(teamsElement.Element("Count").Value);

                        //Load Team Info
                        foreach (var teamElement in teamsElement.Elements("Team"))
                        {
                            List<object> tokens =
                                Tokenizer.ReadTokenizedString(teamElement.Element("TeamInfoTokens").Value);

                            //The first two tokens are team id and name
                            Team team = new Team(Convert.ToInt32(tokens[0]), tokens[1].ToString());

                            //j = 2 because tokens[0] and tokens[1] are hardcoded values
                            for (int j = 2; j < tokens.Count; ++j)
                            {
                                team.GetTeamSpecificDataset()[j - 2].SetValue(tokens[j]);
                            }

                            Program.Events[Program.Events.Count - 1].teams.Add(team);
                        }

                        var roundsElement = xml.Root.Element("Rounds");
                        Program.Events[Program.Events.Count - 1].lastviewedround =
                            Convert.ToInt32(roundsElement.Element("Current").Value);

                        count = Convert.ToInt32(roundsElement.Element("Count").Value);
                        foreach (var roundElement in roundsElement.Elements("Round"))
                        {
                            Round round = new Round();
                            var teamElement = roundElement.Element("Teams"); //Load the teams for each round
                            var tokens =
                                Tokenizer.ReadTokenizedString(teamElement.Element("TeamTokens").Value);

                            for (int i2 = 0; i2 < 6; ++i2)
                            {
                                round.Teams[i2] = Convert.ToInt32(tokens[i2]);
                            }

                            var dataSetElement = roundElement.Element("DataSets");
                            for (int j = 0; j < 6; ++j)
                            {
                                var dataTokens =
                                    Tokenizer.ReadTokenizedString(dataSetElement.Element("DataPoints" + j).Value);

                                for (int k = 0; k < Program.DataSet[1].Count; ++k)
                                {
                                    round.DataSet[j][k].SetValue(dataTokens[k]);
                                }
                            }

                            Program.Events[Program.Events.Count - 1].rounds.Add(round); //Add the round we just made to the round list.
                        }

                        fileStream.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Event #{fileName.Replace(eventsFolder(), "")} could not be loaded. \n\n{ex.Message}",
                    "MyScout 2017", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads the default dataset
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static void LoadDefaultDataset()
        {
            //TODO: undo try commenting
            try
            {
                List<DataPoint> teamDataSet = new List<DataPoint>();
                List<DataPoint> roundDataSet = new List<DataPoint>();
                List<DataPoint> compDataSet = new List<DataPoint>();
                List<DataPoint> execDataSet = new List<DataPoint>();
                string filePath = Path.Combine(Application.StartupPath, "Datasets", "Data_default.xml");
                
                if (File.Exists(filePath))
                {
                    using (XmlReader reader = XmlReader.Create(filePath))
                    {
                        reader.ReadStartElement("gamedata");
                        string fileversionstring = reader.ReadElementString("version");
                        string name = reader.ReadElementString("name");
                        string desc = reader.ReadElementString("desc");

                        if (fileversionstring == Program.VersionString || (Convert.ToSingle(fileversionstring) < Convert.ToSingle(Program.VersionString) && MessageBox.Show($"The Dataset file {Application.StartupPath + "\\Datasets\\data_default.xml"} seems to have been made with an older version of the application. Would you like to try and read it anyway? (May not work correctly)", "MyScout 2017", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                        {
                            reader.ReadStartElement("dataset");

                            int teamAmnt = Convert.ToInt16(reader.ReadElementString("teamamnt"));
                            reader.ReadStartElement("teamdata");
                            for (int i = 0; i < teamAmnt; ++i)
                            {
                                List<object> tokens = Tokenizer.ReadTokenizedString(reader.ReadElementString("datapoint"));
                                teamDataSet.Add(new DataPoint((string)tokens[0], Tokenizer.getTypeFromString((string)tokens[1])));
                            }
                            reader.ReadEndElement();

                            int roundAmnt = Convert.ToInt16(reader.ReadElementString("roundamnt"));
                            reader.ReadStartElement("rounddata");
                            for (int i = 0; i < roundAmnt; ++i)
                            {
                                List<object> tokens = Tokenizer.ReadTokenizedString(reader.ReadElementString("datapoint"));
                                roundDataSet.Add(new DataPoint((string)tokens[0], Tokenizer.getTypeFromString((string)tokens[1])));
                            }
                            reader.ReadEndElement();

                            int compAmnt = Convert.ToInt16(reader.ReadElementString("compamnt"));
                            reader.ReadStartElement("compdata");
                            for (int i = 0; i < roundAmnt; ++i)
                            {
                                List<object> tokens = Tokenizer.ReadTokenizedString(reader.ReadElementString("datapoint"));
                                compDataSet.Add(new DataPoint((string)tokens[0], Tokenizer.getTypeFromString((string)tokens[1])));
                            }
                            reader.ReadEndElement();

                            int execAmnt = Convert.ToInt16(reader.ReadElementString("execamnt"));
                            reader.ReadStartElement("exec");
                            for (int i = 0; i < execAmnt; ++i)
                            {
                                reader.ReadElementString("func");
                                execDataSet.Add(new DataPoint("exec" + i, typeof(string)));
                            }
                            reader.ReadEndElement();
                            reader.ReadEndElement();
                        }
                        else return;
                        reader.ReadEndElement();
                    }
                }

                List<List<DataPoint>> newDataset = new List<List<DataPoint>>();
                newDataset.Add(teamDataSet);
                newDataset.Add(roundDataSet);
                newDataset.Add(compDataSet);

                Program.DataSet = newDataset;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"File{Application.StartupPath + "\\Datasets\\Data_default.xml"} could not be loaded.\nMake sure to supply a default file with the name 'Data_default.xml' in {Application.StartupPath + "\\Datasets"}\n\n{ex.Message}", "MyScout 2017", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loats a Dataset xml file into the Program memory
        /// </summary>
        /// <param name="eventid"></param>
        public static List<List<DataPoint>> LoadDatasetFromPath(string filepath)
        {
            //TODO: undo try commenting
            try
            {
                List<DataPoint> teamDataSet = new List<DataPoint>();
                List<DataPoint> roundDataSet = new List<DataPoint>();
                List<DataPoint> compDataSet = new List<DataPoint>();

                if (File.Exists(filepath))
                {
                    using (XmlReader reader = XmlReader.Create(filepath))
                    {
                        reader.ReadStartElement("gamedata");
                        string fileversionstring = reader.ReadElementString("version");
                        string name = reader.ReadElementString("name");
                        string desc = reader.ReadElementString("desc");

                        if (fileversionstring == Program.VersionString || (Convert.ToSingle(fileversionstring) < Convert.ToSingle(Program.VersionString) && MessageBox.Show($"The Dataset file {filepath} seems to have been made with an older version of the application. Would you like to try and read it anyway? (May not work correctly)", "MyScout 2017", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                        {
                            reader.ReadStartElement("dataset");

                            int teamAmnt = Convert.ToInt16(reader.ReadElementString("teamamnt"));
                            reader.ReadStartElement("teamdata");
                            for (int i = 0; i < teamAmnt; ++i)
                            {
                                //Read all the tokens in this datapoint
                                List<object> tokens = Tokenizer.ReadTokenizedString(reader.ReadElementString("datapoint"));
                                //Create a new datapoint from the tokens
                                teamDataSet.Add(new DataPoint((string)tokens[0], Tokenizer.getTypeFromString((string)tokens[1]), tokens.Count == 3 ? new LinkedDouble(tokens[2].ToString()) : new LinkedDouble(0)));
                            }
                            reader.ReadEndElement();

                            int roundAmnt = Convert.ToInt16(reader.ReadElementString("roundamnt"));
                            reader.ReadStartElement("rounddata");
                            for (int i = 0; i < roundAmnt; ++i)
                            {
                                //Read all the tokens in this datapoint
                                List<object> tokens = Tokenizer.ReadTokenizedString(reader.ReadElementString("datapoint"));
                                //Create a new datapoint from the tokens
                                roundDataSet.Add(new DataPoint((string)tokens[0], Tokenizer.getTypeFromString((string)tokens[1]), tokens.Count == 3 ? new LinkedDouble(tokens[2].ToString()) : new LinkedDouble(0)));
                            }
                            reader.ReadEndElement();

                            int compAmnt = Convert.ToInt16(reader.ReadElementString("compamnt"));
                            reader.ReadStartElement("compdata");
                            for (int i = 0; i < compAmnt; ++i)
                            {
                                //Read all the tokens in this datapoint
                                List<object> tokens = Tokenizer.ReadTokenizedString(reader.ReadElementString("datapoint"));
                                //Create a new datapoint from the tokens
                                compDataSet.Add(new DataPoint((string)tokens[0], Tokenizer.getTypeFromString((string)tokens[1]), tokens.Count == 3 ? new LinkedDouble(tokens[2].ToString()) : new LinkedDouble(0)));
                            }
                            reader.ReadEndElement();

                            int execAmnt = Convert.ToInt16(reader.ReadElementString("execamnt"));
                            reader.ReadStartElement("exec");
                            for (int i = 0; i < execAmnt; ++i)
                            {
                                compDataSet[i].SetScript(reader.ReadElementString("func"));
                            }
                            reader.ReadEndElement();
                            reader.ReadEndElement();
                        }
                        else { return null; }
                        reader.ReadEndElement();
                    }
                }

                List<List<DataPoint>> newDataset = new List<List<DataPoint>>();
                newDataset.Add(teamDataSet);
                newDataset.Add(roundDataSet);
                newDataset.Add(compDataSet);

                return newDataset;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"File {filepath} could not be loaded. \n\n{ex.Message}", "MyScout 2017", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }
        
        /// <summary>
        /// Loads a round profile .xml for the report generator, returning the string names of the datasets used
        /// </summary>
        /// <returns></returns>
        public static List<string> LoadReportProfile(int eventIndex)
        {
            List<string> toReturn = new List<string>();

            if (File.Exists(reportProfilesFolder() + "\\Profile" + eventIndex.ToString() + ".xml"))
            {
                using (XmlReader reader = XmlReader.Create(reportProfilesFolder() + "\\Profile" + eventIndex.ToString() + ".xml"))
                {
                    reader.ReadStartElement();
                    int count = Convert.ToInt16(reader.ReadElementString());
                    for (int i = 0; i < count; i++)
                    {
                        toReturn.Add(reader.ReadElementString());
                    }
                }
            }

            return toReturn;
        }

        /// <summary>
        /// Returns a string[] containing the name [0] and description [1] of the data file. Converts \n to line break
        /// </summary>
        /// <param name="fileid"></param>
        /// <returns></returns>
        public static string[] GetNameAndDescFromDataset(string filepath)
        {
            string[] output = new string[2];
            if (File.Exists(filepath))
            {
                using (XmlReader reader = XmlReader.Create(filepath))
                {
                    reader.ReadStartElement("gamedata");
                    string fileversionstring = reader.ReadElementString("version");
                    string name = reader.ReadElementString("name");
                    string desc = reader.ReadElementString("desc");

                    output[0] = name;
                    output[1] = desc;
                }
            }

            return output;
        }
        #endregion

        #region scOutput-related functions (pun brought to you by the amazing Ethan™)
        /// <summary>
        /// Saves all events in memory to the program's event folder.
        /// </summary>
        public static void SaveAllEvents()
        {
            string eventPath = eventsFolder();
            string eventBackupPath = Path.Combine(Program.StartupPath, "Events Backup", Program.DataSetName);

            Directory.CreateDirectory(eventPath);
            Directory.CreateDirectory(eventBackupPath);

            if (Directory.Exists(eventPath) && Directory.GetFiles(eventPath).Length > 0)
            {
                if (Directory.Exists(eventBackupPath))
                {
                    Directory.Delete(eventBackupPath, true);
                }
                Directory.Move(eventPath, eventBackupPath);
            }

            Directory.CreateDirectory(eventPath);
            eventPath = Path.Combine(Program.StartupPath, "Events");
            eventBackupPath = Path.Combine(Program.StartupPath, "Events Backup");

            if (Directory.Exists(eventPath) && Directory.GetFiles(eventPath).Length > 0)
            {
                if (Directory.Exists(eventBackupPath))
                {
                    Directory.Delete(eventBackupPath, true);
                }
                Directory.Move(eventPath, eventBackupPath);
            }
            Directory.CreateDirectory(eventPath);

            for (int i = 0; i < Program.Events.Count; ++i)
            {
                SaveEvent(i);
            }
        }

        /// <summary>
        /// Save the given event as an XML file.
        /// </summary>
        /// <param name="eventid">The event to save as an XML file.</param>
        public static void SaveEvent(int eventid)
        {
            //try
            //{
            string eventfilename = Program.Events[eventid].filename;
            if (File.Exists(eventsFolder() + "\\" + eventfilename))
            {
                File.Delete(eventsFolder() + "\\" + eventfilename);
            }

            var dir = Path.Combine(eventsFolder());
            Directory.CreateDirectory(dir);

            using (XmlTextWriter writer = new XmlTextWriter(eventsFolder() + "\\" + eventfilename, Encoding.ASCII))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;

                writer.WriteStartDocument();
                writer.WriteStartElement("Event");
                writer.WriteElementString("Version", Program.VersionString);
                writer.WriteElementString("DataSet", Program.DataSetName);
                writer.WriteElementString("Name", Program.Events[eventid].name);
                writer.WriteElementString("BeginDate", Program.Events[eventid].begindate);
                writer.WriteElementString("EndDate", Program.Events[eventid].enddate);

                writer.WriteStartElement("Teams");
                writer.WriteElementString("Count", Program.Events[eventid].teams.Count.ToString());

                //Convert team information to a tokenized int string
                foreach (Team team in Program.Events[eventid].teams)
                {
                    writer.WriteStartElement("Team");
                    List<object> tokens = new List<object>();

                    tokens.Add(team.id);
                    tokens.Add(team.name);
                    for (int i = 0; i < team.GetTeamSpecificDataset().Count; ++i)
                    {
                        List<DataPoint> datatokens = team.GetTeamSpecificDataset();
                        var token = datatokens[i].GetValue();
                        tokens.Add(token); //Write team specific data to tokens
                    }

                    //Write team specific data to xml
                    writer.WriteElementString("TeamInfoTokens", Tokenizer.CreateTokenizedString(tokens));
                    writer.WriteEndElement();
                }


                writer.WriteEndElement();

                writer.WriteStartElement("Rounds");
                writer.WriteElementString("Current", (Program.Events[eventid].lastviewedround == -1) ? (Program.Events[eventid].rounds.Count - 1).ToString() : Program.Events[eventid].lastviewedround.ToString());
                //writer.WriteElementString("AllianceScoreTokens", TokenizeStringHandler.CreateTokenizedString(new List<object> { Round.score[0], Round.score[1] }));

                writer.WriteElementString("Count", Program.Events[eventid].rounds.Count.ToString());

                foreach (Round round in Program.Events[eventid].rounds)
                {
                    writer.WriteStartElement("Round");
                    writer.WriteStartElement("Teams");

                    List<object> teams = new List<object>(); //Save teams for each round

                    for (int i = 0; i < 6; ++i)
                    {
                        teams.Add(round.Teams[i]); //Write teams to xml
                    }

                    writer.WriteElementString("TeamTokens", Tokenizer.CreateTokenizedString(teams));
                    writer.WriteEndElement();

                    writer.WriteStartElement("DataSets");
                    for (int i = 0; i < 6; ++i) //For each list of datapoints
                    {
                        List<object> tokens = new List<object>();
                        for (int j = 0; j < Program.DataSet[1].Count(); j++) //For each datapoint
                        {
                            tokens.Add(round.DataSet[i][j].GetValue()); //Add the datapoint to the tokens list
                        }
                        writer.WriteElementString("DataPoints" + i.ToString(), Tokenizer.CreateTokenizedString(tokens));
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }
        }

        public static void SaveDatasetTemplate(string fileid, string name, string description, List<List<DataPoint>> datasetIn)
        {
            if (File.Exists(Program.StartupPath + "\\Datasets\\Data_" + fileid + ".xml"))
            {
                File.Delete(Program.StartupPath + "\\Datasets\\Data_" + fileid + ".xml");
            }
            using (XmlTextWriter writer = new XmlTextWriter(Program.StartupPath + "\\Datasets\\Data_" + fileid + ".xml", Encoding.ASCII))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;

                writer.WriteStartDocument();
                writer.WriteStartElement("gamedata");
                writer.WriteElementString("version", Program.VersionString);
                writer.WriteElementString("name", name);
                writer.WriteElementString("desc", description);

                writer.WriteStartElement("dataset");

                writer.WriteElementString("teamamnt", datasetIn[0].Count.ToString());
                writer.WriteStartElement("teamdata");
                for (int i = 0; i < datasetIn[0].Count; ++i)
                {
                    List<object> tokens = new List<object>();
                    tokens.Add(datasetIn[0][i].GetName());
                    tokens.Add(datasetIn[0][i].GetDataType());
                    tokens.Add(Tokenizer.getStringFromType(datasetIn[0][i].GetDataType()));
                    writer.WriteElementString("datapoint", Tokenizer.CreateTokenizedString(tokens));
                }
                writer.WriteEndElement();

                writer.WriteElementString("roundamnt", datasetIn[1].Count.ToString());
                writer.WriteStartElement("roundamnt");
                for (int i = 0; i < datasetIn[1].Count; ++i)
                {
                    List<object> tokens = new List<object>();
                    tokens.Add(datasetIn[1][i].GetName());
                    tokens.Add(Tokenizer.getStringFromType(datasetIn[1][i].GetDataType()));
                    writer.WriteElementString("datapoint", Tokenizer.CreateTokenizedString(tokens));
                }
                writer.WriteEndElement();

                writer.WriteElementString("compamnt", datasetIn[2].Count.ToString());
                writer.WriteStartElement("compamnt");
                for (int i = 0; i < datasetIn[2].Count; ++i)
                {
                    List<object> tokens = new List<object>();
                    tokens.Add(datasetIn[2][i].GetName());
                    tokens.Add(Tokenizer.getStringFromType(datasetIn[2][i].GetDataType()));
                    writer.WriteElementString("datapoint", Tokenizer.CreateTokenizedString(tokens));
                }
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }

        /// <summary>
        /// Save pertinent data to Teams and calculate scores as necessary
        /// </summary>
        public static void SaveDataToTeams()
        {
            if(Program.CurrentEventIndex != -1)
            {
                //for each team in the event
                for (int i = 0; i < Program.Events[Program.CurrentEventIndex].teams.Count; i++)
                {
                    TotalsUtil.updateTeamTotalScore(i);

                    for (int j = 0; j < Program.DataSet[2].Count; j++)
                    {
                        TotalsUtil.execFunction(i, j);
                    }
                }
            }
        }

        /// <summary>
        /// Generate an xml file with the strings from the outListBox saved, maintaining the order and value of strings.
        /// </summary>
        /// <param name="outListBox"></param>
        public static void SaveReportProfile(ListBox outListBox, string reporttype, string name)
        {
            //try
            //{
            string reportPath = reportProfilesFolder() + "\\profile_" + name + ".xml";

            if (File.Exists(reportPath))
            {
                File.Delete(reportPath);
            }

            Directory.CreateDirectory(reportProfilesFolder());

            using (XmlTextWriter writer = new XmlTextWriter(reportPath, Encoding.ASCII))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;

                writer.WriteStartDocument();
                writer.WriteStartElement("datapoints");
                writer.WriteElementString("count", outListBox.Items.Count.ToString());
                for (int i = 0; i < outListBox.Items.Count; i++)
                {
                    writer.WriteElementString("datapoint", (string)outListBox.Items[i]);
                }
                writer.WriteEndElement();
            }
        }

        /// <summary>
        /// Writes an event to an HTML table (and some irrelevant css animations) for nicer viewing and printing
        /// </summary>
        /// <param name="ev"></param>
        /// <param name="outListBox"></param>
        public static void CreateEventHTML(Event ev, ListBox outListBox)
        {
            SaveDataToTeams();

            List<Team> teamList = ev.teams;

            //Near-useless nullcheck™
            for (int i = 0; i < teamList.Count; ++i)
            {
                if (teamList[i] == null)
                {
                    teamList[i] = new Team(0000, "null");
                }
            }

            List<Team> sortedTeamList = SortTeamsByAvgScore(teamList);

            string filepath = reportsFolder() + $"\\{REPORT_PREFIX + ev.name}.html";

            if (!Directory.Exists(reportsFolder()))
            {
                Directory.CreateDirectory(reportsFolder());
            }

            using (XmlTextWriter writer = new XmlTextWriter(filepath, Encoding.ASCII))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                writer.WriteDocType("html", null, null, null);
                writer.WriteStartElement("html");

                //Head
                writer.WriteStartElement("head");
                writer.WriteElementString("title", ev.name + "Report");
                writer.WriteStartElement("style");
                writer.WriteString("#reporttable {border-collapse: collapse; table-layout: fixed;}");
                writer.WriteString("#reporttable td {border: 1px solid black; padding: 2px;}");
                writer.WriteString(".thead {background-color: gray; color: white;}");
                writer.WriteString(".evenrow {background-color: lightgray;}");
                writer.WriteEndElement();
                writer.WriteEndElement();

                //Body
                writer.WriteStartElement("body");
                writer.WriteStartElement("table");
                writer.WriteAttributeString("id", "reporttable");
                for (int row = -1; row < sortedTeamList.Count; ++row)
                {
                    writer.WriteStartElement("tr");
                    //Add neat striping
                    if (row % 2 != 0 && row != -1)
                    {
                        writer.WriteAttributeString("class", "evenrow");
                    }
                    
                    if (row >= 0)  //This is actual content vvvvv
                    {
                        writer.WriteElementString("td", sortedTeamList[row].id.ToString());
                        writer.WriteElementString("td", sortedTeamList[row].name.ToString());
                        writer.WriteElementString("td", sortedTeamList[row].avgScore.ToString());
                        writer.WriteElementString("td", TotalsUtil.getRoundsFromTeam(sortedTeamList[row]).Count.ToString());

                        foreach (string s in outListBox.Items)
                        {
                            if (GetDatapointByName(sortedTeamList[row].GetCompiledScoreDataset(), s) != null)
                            {
                                writer.WriteElementString("td", GetDatapointByName(sortedTeamList[row].GetCompiledScoreDataset(), s).GetValue().ToString());
                            }
                            else
                            {
                                writer.WriteElementString("td", GetDatapointByName(sortedTeamList[row].GetTeamSpecificDataset(), s).GetValue().ToString());
                            }
                        }
                    }
                    else      //This is header stuff vvvvvvv I'm an idiot
                    {
                        writer.WriteAttributeString("class", "thead");
                        writer.WriteElementString("td", "ID");
                        writer.WriteElementString("td", "Name");
                        writer.WriteElementString("td", "Avg");
                        writer.WriteElementString("td", "inRounds");
                        foreach(string s in outListBox.Items)
                        {
                            if (GetDatapointByName(Program.DataSet[2], s) != null)
                            {
                                DataPoint dp = GetDatapointByName(Program.DataSet[2], s);
                                writer.WriteElementString("td", dp.GetAbbreviation().Length >= 8 ? dp.GetAbbreviationBasic() : dp.GetAbbreviation());
                            }
                            else
                            {
                                DataPoint dp = GetDatapointByName(Program.DataSet[0], s);
                                writer.WriteElementString("td", dp.GetAbbreviation().Length >= 8 ? dp.GetAbbreviationBasic() : dp.GetAbbreviation());
                            }
                        }
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteEndElement();
            }
        }

        /// <summary>
        /// Generate a spreadsheet of teams in "{Program.StartupPath}\Spreadsheets\Scouting Report {ev.name}.xls"
        /// </summary>
        /// <param name="ev">The event to load data from</param>
        /// <param name="sorting">How to sort the generated report; 1:TotalScore, 2:AutoScore, 3:CrossingPower</param>
        public static void CreateEventSpreadsheet(Event ev, ListBox outListBox)
        {
            SaveDataToTeams();

            List<Team> teamList = ev.teams;

            //Near-useless nullcheck™
            for (int i = 0; i < teamList.Count; ++i)
            {
                if (teamList[i] == null)
                {
                    teamList[i] = new Team(0000, "null");
                }
            }

            List<Team> sortedTeamList = SortTeamsByAvgScore(teamList);

            string filepath = reportsFolder() + $"\\{REPORT_PREFIX + ev.name}.xls";

            if (!Directory.Exists(reportsFolder()))
            {
                Directory.CreateDirectory(reportsFolder());
            }

            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet("Scouting Report");

            for(int row = -1; row < sortedTeamList.Count; row++)
            {
                List<string> teamPoints = new List<string>();

                //Initialize data
                if(row >= 0)
                {
                    teamPoints.Add(sortedTeamList[row].id.ToString());
                    teamPoints.Add(sortedTeamList[row].name.ToString());
                    teamPoints.Add(sortedTeamList[row].avgScore.ToString());
                    teamPoints.Add(TotalsUtil.getRoundsFromTeam(sortedTeamList[row]).Count.ToString());

                    foreach (string s in outListBox.Items)
                    {
                        if (GetDatapointByName(sortedTeamList[row].GetCompiledScoreDataset(), s) != null)
                        {
                            teamPoints.Add(GetDatapointByName(sortedTeamList[row].GetCompiledScoreDataset(), s).GetValue().ToString());
                        }
                        else
                        {
                            teamPoints.Add(GetDatapointByName(sortedTeamList[row].GetTeamSpecificDataset(), s).GetValue().ToString());
                        }
                    }
                }
                else
                {
                    teamPoints.Add("ID");
                    teamPoints.Add("Name");
                    teamPoints.Add("Avg");
                    teamPoints.Add("inRounds");
                    foreach(string s in outListBox.Items)
                    {
                        if(GetDatapointByName(Program.DataSet[2], s) != null)
                        {
                            teamPoints.Add(GetDatapointByName(Program.DataSet[2], s).GetAbbreviation());
                        }
                        else
                        {
                            teamPoints.Add(GetDatapointByName(Program.DataSet[0], s).GetAbbreviation());
                        }
                    }
                }

                for (ushort col = 0; col < teamPoints.Count; col++)
                {
                    worksheet.Cells[row+1, col] = new Cell(teamPoints[col]);

                    //Calculate cell width
                    ushort CHAR_WIDTH = 400;
                    if(row == -1)
                    {
                        worksheet.Cells.ColumnWidth[col] = (ushort)(teamPoints[col].Length * CHAR_WIDTH);
                    }
                    if (worksheet.Cells.ColumnWidth[col] < teamPoints[col].Length * CHAR_WIDTH)
                    {
                        worksheet.Cells.ColumnWidth[col] = (ushort)(teamPoints[col].Length * CHAR_WIDTH);
                    }
                }
            }
            
            workbook.Worksheets.Add(worksheet);
            bool cannotSave = true;
            while (cannotSave)
            {
                try
                {
                    workbook.Save(filepath);
                    cannotSave = false;
                }
                catch
                {
                    MessageBox.Show("Something is currently using the file, it can't be edited until you close it!");
                }

            }
        }
        #endregion

        #region Misc Utils

        /// <summary>
        /// Finds a datapoint in a certain datapoint by its name. Returns null if none found.
        /// </summary>
        /// <param name="team"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static DataPoint GetDatapointByName(List<DataPoint> dataset, string name)
        {
            foreach (DataPoint d in dataset)
            {
                if(d.GetName() == name)
                {
                    return d;
                }
            }
            return null;
        }

        /// <summary>
        /// Returns a list of teams sorted by average score
        /// </summary>
        /// <param name="teamList"></param>
        /// <returns></returns>
        public static List<Team> SortTeamsByAvgScore(List<Team> teamList)
        {
            List<Team> sortedTeamList = new List<Team>();
            for (int i = 0; i < teamList.Count; ++i) //For each team in TeamList
            {
                if (sortedTeamList.Count > 0) //If there are teams in sortedTeamList
                {
                    int insertIndex = 0;
                    bool notAdded = true;
                    while (notAdded) //For each team in sortedTeamList
                    {
                        if (insertIndex < sortedTeamList.Count) //If the insert index isn't out of bounds
                        {
                            if (teamList[i].avgScore > sortedTeamList[insertIndex].avgScore &&
                                (insertIndex == 0 || teamList[i].avgScore < sortedTeamList[insertIndex - 1].avgScore))
                            //If it's in the correct space (x > [avgscore] > y)
                            {
                                sortedTeamList.Insert(insertIndex, teamList[i]); //Add it to the list
                                notAdded = false;
                            }
                            else insertIndex++; //Otherwise move the index down the list
                        }
                        else //If the insert index is at the end of the list, meaning it's less than every other one
                        {
                            sortedTeamList.Insert(insertIndex, teamList[i]); //Add it to the list at the end
                            notAdded = false;
                        }
                    }
                }
                else sortedTeamList.Add(teamList[i]);
            }
            return sortedTeamList;
        }
        #endregion
    }

}