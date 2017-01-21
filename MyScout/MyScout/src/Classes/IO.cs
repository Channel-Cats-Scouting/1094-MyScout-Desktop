using ExcelLibrary.SpreadSheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace MyScout
{
    public static class IO
    {
        #region Input-related functions

        /// <summary>
        /// Loads all events from the program's event folder.
        /// </summary>
        public static void LoadAllEvents()
        {
            string[] files = Directory.GetFiles(Program.StartupPath + "\\Events");
            for (int i = 0; i < files.Length; i++)
            {
                LoadEvent(i);
            }
            Program.MainFrm.Invoke(new Action(() => { Program.MainFrm.RefreshEventList(); }));
        }

        /// <summary>
        /// Loads the given event from an XML file.
        /// </summary>
        /// <param name="eventid">The ID of the XML file to load.</param>
        public static void LoadEvent(int eventid)
        {
            //TODO: undo try commenting
            try
            {
                if (File.Exists(Program.StartupPath + "\\Events\\Event" + eventid.ToString() + ".xml"))
                {
                    using (XmlReader reader = XmlReader.Create(Program.StartupPath + "\\Events\\Event" + eventid.ToString() + ".xml"))
                    {
                        reader.ReadStartElement("Event");
                        string fileversionstring = reader.ReadElementString("Version");
                        string filedataset = reader.ReadElementString("DataSet");

                        if(filedataset != Program.DataSetName)
                        {
                            return;
                        }

                        if (fileversionstring == Program.VersionString || 
                            filedataset == Program.DataSetName || 
                            (filedataset != Program.DataSetName && MessageBox.Show($"Event #{eventid.ToString()} seems to have been made with an older version of the application. Would you like to try and read it anyway? (May not work correctly)", "MyScout 2016", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) || 
                            ((Convert.ToSingle(fileversionstring) < Convert.ToSingle(Program.VersionString) && MessageBox.Show($"Event #{eventid.ToString()} seems to have been made with an older version of the application. Would you like to try and read it anyway? (May not work correctly)", "MyScout 2016", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)))
                        {
                            Program.Events.Add(new Event(reader.ReadElementString("Name"), reader.ReadElementString("BeginDate"), reader.ReadElementString("EndDate"), filedataset));
                            Program.Events[Program.Events.Count - 1].rounds.Clear();

                            reader.ReadStartElement("Teams");
                            int count = Convert.ToInt32(reader.ReadElementString("Count"));

                            //Load Team Info
                            for (int i = 0; i < count; i++)
                            {
                                reader.ReadStartElement("Team");
                                List<object> tokens = Tokenizer.ReadTokenizedString(reader.ReadElementString("TeamInfoTokens"));

                                //The first two tokens are team id and name
                                Team team = new Team(Convert.ToInt32(tokens[0]), tokens[1].ToString()); 
                                for(int j = 2; j < tokens.Count; j++)
                                {
                                    team.GetTeamSpecificDataset()[j - 2].SetValue(tokens[j]);
                                }

                                Program.Events[Program.Events.Count - 1].teams.Add(team);
                                reader.ReadEndElement();
                            }

                            reader.ReadEndElement();

                            reader.ReadStartElement("Rounds");
                            Program.Events[Program.Events.Count - 1].lastviewedround = Convert.ToInt32(reader.ReadElementString("Current"));
                            //List<object> AllianceScores = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("AllianceScoreTokens"));
                            //Round.score = new int[2] { Convert.ToInt32(AllianceScores[0]), Convert.ToInt32(AllianceScores[1]) };

                            count = Convert.ToInt32(reader.ReadElementString("Count"));
                            for (int i = 0; i < count; i++)
                            {
                                reader.ReadStartElement("Round");
                                Round round = new Round();

                                reader.ReadStartElement("Teams"); //Load the teams for each round
                                List<object> tokens = Tokenizer.ReadTokenizedString(reader.ReadElementString("TeamTokens"));
                                for (int i2 = 0; i2 < 6; i2++)
                                {
                                    round.teams[i2] = Convert.ToInt32(tokens[i2]);
                                }
                                reader.ReadEndElement();

                                reader.ReadStartElement("DataSets");
                                for(int j = 0; j < 6; j++)
                                {
                                    List<object> datatokens = Tokenizer.ReadTokenizedString(reader.ReadElementString("DataPoints" + j.ToString()));
                                    for(int k = 0; k < Program.DataSet.Count; k++)
                                    {
                                        round.dataset[j][k].SetValue(datatokens[k]);
                                    }
                                }

                                //reader.ReadStartElement("Defenses");
                                //for (int i2 = 0; i2 < 6; i2++)
                                //{
                                //    List<object> AOReachedTokens = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("AOReachedTokens"));
                                //    List<object> AOCrossedTokens = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("AOCrossedTokens"));
                                //    List<object> TOCrossedTokens = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("TOCrossedTokens"));

                                //    for (int i3 = 0; i3 < 9; i3++)
                                //    {
                                //        round.defenses[i2, i3].AOreached      = (bool)AOReachedTokens[i3];
                                //        round.defenses[i2, i3].AOcrossed      = (bool)AOCrossedTokens[i3];
                                //        round.defenses[i2, i3].TOtimescrossed = (int)TOCrossedTokens[i3];
                                //    }
                                //}
                                //reader.ReadEndElement();

                                //round.scaledtower = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("TOScaledTokens")).Cast<bool>().ToArray();
                                //round.challengedtower = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("TOChallengedTokens")).Cast<bool>().ToArray();
                                //round.AOhighgoalcount = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("AOHighGoalTokens")).Cast<int>().ToArray();
                                //round.AOlowgoalcount = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("AOLowGoalTokens")).Cast<int>().ToArray();
                                //round.TOhighgoalcount = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("TOHighGoalTokens")).Cast<int>().ToArray();
                                //round.TOlowgoalcount = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("TOLowGoalTokens")).Cast<int>().ToArray();

                                //round.comments = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("CommentTokens")).Cast<string>().ToArray();
                                //round.humancomments = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("HumanCommentTokens")).Cast<string>().ToArray();
                                //round.died = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("DiedTokens")).Cast<bool>().ToArray();
                                //round.dieddefense = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("DiedDefenseTokens")).Cast<int>().ToArray();
                                //round.diedcomments = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("DiedCommentTokens")).Cast<string>().ToArray();

                                Program.Events[Program.Events.Count - 1].rounds.Add(round); //Add the round we just made to the round list.
                                reader.ReadEndElement();
                            }

                            reader.ReadEndElement();
                        }
                        else { return; }
                        reader.ReadEndElement();
                    }
                }
        }
            catch (Exception ex)
            {
                MessageBox.Show($"Event #{eventid.ToString()} could not be loaded. \n\n{ex.Message}", "MyScout 2016", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (File.Exists(Application.StartupPath + "\\Datasets\\Data_default.xml"))
                {
                    using (XmlReader reader = XmlReader.Create(Application.StartupPath + "\\Datasets\\Data_default.xml"))
                    {
                        reader.ReadStartElement("gamedata");
                        string fileversionstring = reader.ReadElementString("version");
                        string name = reader.ReadElementString("name");
                        string desc = reader.ReadElementString("desc");

                        if (fileversionstring == Program.VersionString || (Convert.ToSingle(fileversionstring) < Convert.ToSingle(Program.VersionString) && MessageBox.Show($"The Dataset file {Application.StartupPath + "\\Datasets\\data_default.xml"} seems to have been made with an older version of the application. Would you like to try and read it anyway? (May not work correctly)", "MyScout 2016", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                        {
                            reader.ReadStartElement("dataset");

                            int teamAmnt = Convert.ToInt16(reader.ReadElementString("teamamnt"));
                            reader.ReadStartElement("teamdata");
                            for (int i = 0; i < teamAmnt; i++)
                            {
                                List<object> tokens = Tokenizer.ReadTokenizedString(reader.ReadElementString("datapoint"));
                                teamDataSet.Add(new DataPoint((string)tokens[0], Tokenizer.getTypeFromString((string)tokens[1])));
                            }
                            reader.ReadEndElement();

                            int roundAmnt = Convert.ToInt16(reader.ReadElementString("roundamnt"));
                            reader.ReadStartElement("rounddata");
                            for (int i = 0; i < roundAmnt; i++)
                            {
                                List<object> tokens = Tokenizer.ReadTokenizedString(reader.ReadElementString("datapoint"));
                                roundDataSet.Add(new DataPoint((string)tokens[0], Tokenizer.getTypeFromString((string)tokens[1])));
                            }
                            reader.ReadEndElement();

                            int compAmnt = Convert.ToInt16(reader.ReadElementString("compamnt"));
                            reader.ReadStartElement("compdata");
                            for (int i = 0; i < roundAmnt; i++)
                            {
                                List<object> tokens = Tokenizer.ReadTokenizedString(reader.ReadElementString("datapoint"));
                                compDataSet.Add(new DataPoint((string)tokens[0], Tokenizer.getTypeFromString((string)tokens[1])));
                            }
                            reader.ReadEndElement();

                            int execAmnt = Convert.ToInt16(reader.ReadElementString("execamnt"));
                            reader.ReadStartElement("exec");
                            for (int i = 0; i < execAmnt; i++)
                            {
                                reader.ReadElementString("func");
                                execDataSet.Add(new DataPoint("exec" + i, typeof(string)));
                            }
                            reader.ReadEndElement();
                            reader.ReadEndElement();
                        }
                        else { return; }
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
                MessageBox.Show($"File{Application.StartupPath + "\\Datasets\\Data_default.xml"} could not be loaded.\nMake sure to supply a default file with the name 'Data_default.xml' in {Application.StartupPath + "\\Datasets"}\n\n{ex.Message}", "MyScout 2016", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return;
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

                        if (fileversionstring == Program.VersionString || (Convert.ToSingle(fileversionstring) < Convert.ToSingle(Program.VersionString) && MessageBox.Show($"The Dataset file {filepath} seems to have been made with an older version of the application. Would you like to try and read it anyway? (May not work correctly)", "MyScout 2016", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                        {
                            reader.ReadStartElement("dataset");

                            int teamAmnt = Convert.ToInt16(reader.ReadElementString("teamamnt"));
                            reader.ReadStartElement("teamdata");
                            for (int i = 0; i < teamAmnt; i++)
                            {
                                List<object> tokens = Tokenizer.ReadTokenizedString(reader.ReadElementString("datapoint"));
                                teamDataSet.Add(new DataPoint((string)tokens[0], Tokenizer.getTypeFromString((string)tokens[1])));
                            }
                            reader.ReadEndElement();

                            int roundAmnt = Convert.ToInt16(reader.ReadElementString("roundamnt"));
                            reader.ReadStartElement("rounddata");
                            for (int i = 0; i < roundAmnt; i++)
                            {
                                List<object> tokens = Tokenizer.ReadTokenizedString(reader.ReadElementString("datapoint"));
                                roundDataSet.Add(new DataPoint((string)tokens[0], Tokenizer.getTypeFromString((string)tokens[1])));
                            }
                            reader.ReadEndElement();

                            int compAmnt = Convert.ToInt16(reader.ReadElementString("compamnt"));
                            reader.ReadStartElement("compdata");
                            for (int i = 0; i < compAmnt; i++)
                            {
                                List<object> tokens = Tokenizer.ReadTokenizedString(reader.ReadElementString("datapoint"));
                                compDataSet.Add(new DataPoint((string)tokens[0], Tokenizer.getTypeFromString((string)tokens[1])));
                            }
                            reader.ReadEndElement();

                            int execAmnt = Convert.ToInt16(reader.ReadElementString("execamnt"));
                            reader.ReadStartElement("exec");
                            for(int i = 0; i < execAmnt; i++)
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
                MessageBox.Show($"File {filepath} could not be loaded. \n\n{ex.Message}", "MyScout 2016", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
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
            if (Directory.Exists(Program.StartupPath + "\\Events") && Directory.GetFiles(Program.StartupPath + "\\Events").Length > 0)
            {
                if (Directory.Exists(Program.StartupPath + "\\Events Backup"))
                {
                    Directory.Delete(Program.StartupPath + "\\Events Backup",true);
                }
                Directory.Move(Program.StartupPath + "\\Events", Program.StartupPath + "\\Events Backup");
            }
            Directory.CreateDirectory(Program.StartupPath + "\\Events");

            for (int i = 0; i < Program.Events.Count; i++)
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
                if (File.Exists(Program.StartupPath + "\\Events\\Event" + eventid.ToString() + ".xml"))
                {
                    File.Delete(Program.StartupPath + "\\Events\\Event" + eventid.ToString() + ".xml");
                }

                SaveDataToTeams();

                using (XmlTextWriter writer = new XmlTextWriter(Program.StartupPath + "\\Events\\Event" + eventid.ToString() + ".xml", Encoding.ASCII))
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
                        for(int i = 0; i < team.GetTeamSpecificDataset().Count; i++)
                        {
                            List<DataPoint> datatokens = team.GetTeamSpecificDataset();
                            var token = Convert.ChangeType(datatokens[i].GetValue(), datatokens[i].GetDataType());
                            tokens.Add(token); //Write team specific data to tokens
                        }

                        //Write team specific data to xml
                        writer.WriteElementString("TeamInfoTokens", Tokenizer.CreateTokenizedString(tokens));
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();

                    writer.WriteStartElement("Rounds");
                    writer.WriteElementString("Current", (Program.Events[eventid].lastviewedround == -1)? (Program.Events[eventid].rounds.Count-1).ToString(): Program.Events[eventid].lastviewedround.ToString());
                    //writer.WriteElementString("AllianceScoreTokens", TokenizeStringHandler.CreateTokenizedString(new List<object> { Round.score[0], Round.score[1] }));

                    writer.WriteElementString("Count", Program.Events[eventid].rounds.Count.ToString());
                    
                    foreach (Round round in Program.Events[eventid].rounds)
                    {
                        writer.WriteStartElement("Round");
                        writer.WriteStartElement("Teams");

                        List<object> teams = new List<object>(); //Save teams for each round

                        for (int i = 0; i < 6; i++)
                        {
                            teams.Add(round.teams[i]); //Write teams to xml
                        }

                        writer.WriteElementString("TeamTokens", Tokenizer.CreateTokenizedString(teams));
                        writer.WriteEndElement();

                        writer.WriteStartElement("DataSets");
                        for(int i = 0; i < 6; i++) //For each list of datapoints
                        {
                            List<object> tokens = new List<object>();
                            for (int j = 0; j < Program.DataSet[1].Count(); j++) //For each datapoint
                            {
                                tokens.Add(round.dataset[i][j].GetValue()); //Add the datapoint to the tokens list
                            }
                            writer.WriteElementString("DataPoints" + i.ToString(), Tokenizer.CreateTokenizedString(tokens));
                        }
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                    }
                    
                    writer.WriteEndElement();

                }
            //}
            //catch (exception ex)
            //{
            //    messagebox.show($"event #{eventid.tostring()} could not be saved. \n\n{ex.message}", "myscout 2016", messageboxbuttons.ok, messageboxicon.error);
            //}
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
                for (int i = 0; i < datasetIn[0].Count; i++)
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
                for (int i = 0; i < datasetIn[1].Count; i++)
                {
                    List<object> tokens = new List<object>();
                    tokens.Add(datasetIn[1][i].GetName());
                    tokens.Add(Tokenizer.getStringFromType(datasetIn[1][i].GetDataType()));
                    writer.WriteElementString("datapoint", Tokenizer.CreateTokenizedString(tokens));
                }
                writer.WriteEndElement();

                writer.WriteElementString("compamnt", datasetIn[2].Count.ToString());
                writer.WriteStartElement("compamnt");
                for (int i = 0; i < datasetIn[2].Count; i++)
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
            //for each team in the event
            for(int i = 0; i < Program.Events[Program.CurrentEventIndex].teams.Count; i++)
            {
                for(int j = 0; j < Program.DataSet[2].Count; j++)
                {
                    TotalsUtil.execFunction(i, j);
                }
            }
        }

        /// <summary>
        /// Generate a spreadsheet of teams in "{Program.startuppath}\Spreadsheets\Scouting Report {ev.name}.xls"
        /// </summary>
        /// <param name="ev">The event to load data from</param>
        /// <param name="sorting">How to sort the generated report; 1:TotalScore, 2:AutoScore, 3:CrossingPower</param>
        public static void CreateEventSpreadsheet(Event ev, int sorting)
        {
            SaveDataToTeams();

            List<Team> teamList = ev.teams;
            
            //Clean the report
            for (int i = 0; i < teamList.Count; i++)
            {
                if (teamList[i] == null)
                {
                    teamList[i] = new Team(0000, "null");
                }
            }

            //Sort the team list based on the sorting int
            List<Team> sortedTeamList = teamList;
                //team => (sorting == 0 ? team.avgScore : sorting == 1 ? team.teleHighGoals : team.crossingPowerScore)
                //).ToList();

            string filepath = $"{Program.StartupPath}\\Spreadsheets\\Scouting Report {ev.name}.xls";

            if (!Directory.Exists($"{Program.StartupPath}\\Spreadsheets"))
            {
                Directory.CreateDirectory($"{Program.StartupPath}\\Spreadsheets");
            }

            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet("Scouting Report");

            //PLEASE DON'T CHANGE THE BELOW VALUES I SPENT QUITE A WHILE TWEAKING THEM
            //  SO THEY ALL FIT ON ONE PAGE HORIZONTALLY WITH DEFAULT PADDING
            // ~Ethan

            worksheet.Cells[0, 0] = new Cell("ID");
            worksheet.Cells.ColumnWidth[0] = 1250;

            worksheet.Cells[0, 1] = new Cell("Name");
            worksheet.Cells.ColumnWidth[1] = 3700;

            worksheet.Cells[0, 2] = new Cell("Scaled");
            worksheet.Cells.ColumnWidth[2] = 1600;

            worksheet.Cells[0, 3] = new Cell("Challenged");
            worksheet.Cells.ColumnWidth[3] = 2600;

            worksheet.Cells[0, 4] = new Cell("High Goals");
            worksheet.Cells.ColumnWidth[4] = 2500;
            worksheet.Cells[0, 5] = new Cell("Low Goals");
            worksheet.Cells.ColumnWidth[5] = 2400;

            worksheet.Cells[0, 6] = new Cell("Tele:"); //TELE STUFFS
            worksheet.Cells.ColumnWidth[6] = 1250;

            worksheet.Cells[0, 7] = new Cell("PC");
            worksheet.Cells[0, 8] = new Cell("CF");
            worksheet.Cells[0, 9] = new Cell("M");
            worksheet.Cells[0, 10] = new Cell("RP");
            worksheet.Cells[0, 11] = new Cell("DB");
            worksheet.Cells[0, 12] = new Cell("SP");
            worksheet.Cells.ColumnWidth[7, 12] = 900;

            worksheet.Cells[0, 13] = new Cell("RW");
            worksheet.Cells.ColumnWidth[13] = 1000;

            worksheet.Cells[0, 14] = new Cell("RT");
            worksheet.Cells[0, 15] = new Cell("LB");
            worksheet.Cells.ColumnWidth[14, 15] = 900;

            worksheet.Cells[0, 16] = new Cell("Auto:"); //AUTO STUFFS
            worksheet.Cells.ColumnWidth[16] = 1250;

            worksheet.Cells[0, 17] = new Cell("Crossed");
            worksheet.Cells.ColumnWidth[17] = 2100;

            worksheet.Cells[0, 18] = new Cell("High Goals");
            worksheet.Cells.ColumnWidth[18] = 2500;
            worksheet.Cells[0, 19] = new Cell("Low Goals");
            worksheet.Cells.ColumnWidth[19] = 2400;


            for (int i = 1; i < sortedTeamList.Count() + 1; i++)
            {
                Team team = sortedTeamList[i - 1];
                if (team != null)
                {
                    worksheet.Cells[i, 0] = new Cell(team.id.ToString());
                    worksheet.Cells[i, 1] = new Cell(team.name);
                    //worksheet.Cells[i, 2] = new Cell(Convert.ToInt16(team.towersScaled));
                    //worksheet.Cells[i, 3] = new Cell(Convert.ToInt16(team.towersChallenged));
                    //worksheet.Cells[i, 4] = new Cell(Convert.ToInt16(team.teleHighGoals));
                    //worksheet.Cells[i, 5] = new Cell(Convert.ToInt16(team.teleLowGoals));
                }
                else worksheet.Cells[i, 0] = new Cell("N/A");

                if(team != null)
                    for (int j = 0; j < 9; j++)
                    {
                        //Fill each defense cell with the number of times it has crossed the defense
                        //worksheet.Cells[i, (j + 7)] = new Cell(team.defensesCrossed[j]);
                    }
                int autoCrossedTotal = 0;
                if(team != null)
                    for(int j = 0; j< 9; j++)
                    {
                        //autoCrossedTotal += (int)team.autoDefensesCrossed[j];
                    }
                worksheet.Cells[i, 17] = new Cell(autoCrossedTotal);

                //worksheet.Cells[i, 18] = new Cell(Convert.ToInt16(team.autoHighGoals));
                //worksheet.Cells[i, 19] = new Cell(Convert.ToInt16(team.autoLowGoals));

            }

            workbook.Worksheets.Add(worksheet);
            workbook.Save(filepath);
        }
        
        /// <summary>
        /// Generates a report based on an individual round
        /// </summary>
        /// <param name="ev"></param>
        /// <param name="sorting"></param>
        public static void CreateRoundSpreadsheet(Event ev, int roundID, int sorting)
        {
            SaveDataToTeams();

            int[] rawTeamList = ev.rounds[roundID].teams;
            Team[] teamList = new Team[6];

            for(int i = 0; i < 6; i++)
            {
                teamList[i] = (Program.Events[Program.CurrentEventIndex].rounds[roundID].teams[i] == -1) ? null :
                    Program.Events[Program.CurrentEventIndex].teams[Program.Events[Program.CurrentEventIndex].rounds[roundID].teams[i]];
            }

            //Clean the report
            for(int i = 0; i < teamList.Length; i++)
            {
                if(teamList[i] == null)
                {
                    teamList[i] = new Team(0000, "null");
                }
            }

            string filepath = $"{Program.StartupPath}\\Spreadsheets\\Scouting Report {ev.name} - Round {roundID+1}.xls";

            if (!Directory.Exists($"{Program.StartupPath}\\Spreadsheets"))
            {
                Directory.CreateDirectory($"{Program.StartupPath}\\Spreadsheets");
            }

            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet("Scouting Report");

            //PLEASE DON'T CHANGE THE BELOW VALUES I SPENT QUITE A WHILE TWEAKING THEM (again)
            //  SO THEY ALL FIT ON ONE PAGE HORIZONTALLY WITH DEFAULT PADDING
            // ~Ethan

            worksheet.Cells[0, 0] = new Cell("ID");
            worksheet.Cells.ColumnWidth[0] = 1250;

            worksheet.Cells[0, 1] = new Cell("Name");
            worksheet.Cells.ColumnWidth[1] = 3700;

            worksheet.Cells[0, 2] = new Cell("High");
            worksheet.Cells.ColumnWidth[2] = 1100;

            worksheet.Cells[0, 3] = new Cell("Low");
            worksheet.Cells.ColumnWidth[3] = 1000;
            worksheet.Cells[0, 4] = new Cell("Emb?");
            worksheet.Cells[0, 5] = new Cell("Floor?");
            worksheet.Cells.ColumnWidth[4] = 1450;
            worksheet.Cells.ColumnWidth[5] = 1600;

            worksheet.Cells[0, 6] = new Cell("Prefers");
            worksheet.Cells.ColumnWidth[6] = 1700;

            worksheet.Cells[0, 7] = new Cell("PrSct:"); //Prescout
            worksheet.Cells.ColumnWidth[7] = 1600;

            worksheet.Cells[0, 8] = new Cell("PC");
            worksheet.Cells[0, 9] = new Cell("CF");
            worksheet.Cells[0, 10] = new Cell("M");
            worksheet.Cells[0, 11] = new Cell("RP");
            worksheet.Cells[0, 12] = new Cell("DB");
            worksheet.Cells[0, 13] = new Cell("SP");
            worksheet.Cells.ColumnWidth[8, 13] = 900;

            worksheet.Cells[0, 14] = new Cell("RW");
            worksheet.Cells.ColumnWidth[14] = 1000;

            worksheet.Cells[0, 15] = new Cell("RT");
            worksheet.Cells[0, 16] = new Cell("LB");
            worksheet.Cells.ColumnWidth[15, 16] = 900;

            worksheet.Cells[0, 17] = new Cell("Smart:"); //Smart
            worksheet.Cells.ColumnWidth[17] = 1600;

            worksheet.Cells[0, 18] = new Cell("PC");
            worksheet.Cells[0, 19] = new Cell("CF");
            worksheet.Cells[0, 20] = new Cell("M");
            worksheet.Cells[0, 21] = new Cell("RP");
            worksheet.Cells[0, 22] = new Cell("DB");
            worksheet.Cells[0, 23] = new Cell("SP");
            worksheet.Cells.ColumnWidth[18, 23] = 900;

            worksheet.Cells[0, 24] = new Cell("RW");
            worksheet.Cells.ColumnWidth[24] = 1000;

            worksheet.Cells[0, 25] = new Cell("RT");
            worksheet.Cells[0, 26] = new Cell("LB");
            worksheet.Cells.ColumnWidth[25, 26] = 900;

            for (int i = 1; i < teamList.Count() + 1; i++)
            {
                Team team = teamList[i - 1];
                if (team != null)
                {
                    worksheet.Cells[i, 0] = new Cell(team.id.ToString());
                    worksheet.Cells[i, 1] = new Cell(team.name);
                    //worksheet.Cells[i, 2] = new Cell(team.canScoreHighGoals ? " " + ((char)0x221A).ToString() : "");
                    //worksheet.Cells[i, 3] = new Cell(team.canScoreLowGoals ? " " + ((char)0x221A).ToString() : "");
                    //worksheet.Cells[i, 4] = new Cell(team.loadsFromHumanPlayerStations ? " " + ((char)0x221A).ToString() : "");
                    //worksheet.Cells[i, 5] = new Cell(team.loadsFromFloor ? " " + ((char)0x221A).ToString() : "");
                    //worksheet.Cells[i, 6] = new Cell(team.prefers == 0 ? "None" : team.prefers == 1 ? "Floor" : "HPS");
                }
                else worksheet.Cells[i, 0] = new Cell("N/A");

                if(team != null)
                    for (int j = 0; j < 9; j++)
                    {
                        //if (team.defensesCrossable[j]) worksheet.Cells[i, (j + 8)] = new Cell(" " + ((char)0x221A).ToString());
                        //if (team.smartDefensesCrossable[j]) worksheet.Cells[i, (j + 18)] = new Cell(" " + ((char)0x221A).ToString());
                    }
            }

            workbook.Worksheets.Add(worksheet);
            workbook.Save(filepath);
        }

        /// <summary>
        /// A unified method for printing a spreadsheet, compact edition™
        /// </summary>
        /// <param name="ev"></param>
        /// <param name="sorting"></param>
        public static void GenerateSpreadsheet(Event ev, int sorting)
        {
            GenerateSpreadsheet(ev, -1, sorting);
        }

        /// <summary>
        /// A unified method for printing a spreadsheet. If roundID is '-1' it prints an event report, otherwise it prints a round report.
        /// </summary>
        /// <param name="ev"></param>
        /// <param name="roundID"></param>
        /// <param name="sorting"></param>
        public static void GenerateSpreadsheet(Event ev, int roundID, int sorting)
        {
            try
            {
                if (roundID != -1)
                {
                    CreateRoundSpreadsheet(ev, roundID, sorting);
                }
                else
                {
                    CreateEventSpreadsheet(ev, sorting);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The spreadsheet could not be generated. \n\n{ex.Message}", "MyScout 2016", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
