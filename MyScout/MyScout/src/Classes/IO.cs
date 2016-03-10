using ExcelLibrary.SpreadSheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            string[] files = Directory.GetFiles(Program.startuppath + "\\Events");
            for (int i = 0; i < files.Length; i++)
            {
                LoadEvent(i);
            }
            Program.mainfrm.Invoke(new Action(() => { Program.mainfrm.RefreshEventList(); }));
        }

        /// <summary>
        /// Loads the given event from an XML file.
        /// </summary>
        /// <param name="eventid">The ID of the XML file to load.</param>
        public static void LoadEvent(int eventid)
        {
            try
            {
                if (File.Exists(Program.startuppath + "\\Events\\Event" + eventid.ToString() + ".xml"))
                {
                    using (XmlReader reader = XmlReader.Create(Program.startuppath + "\\Events\\Event" + eventid.ToString() + ".xml"))
                    {
                        reader.ReadStartElement("Event");
                        string fileversionstring = reader.ReadElementString("Version");

                        if (fileversionstring == Program.versionstring || (Convert.ToSingle(fileversionstring) < Convert.ToSingle(Program.versionstring) && MessageBox.Show($"Event #{eventid.ToString()} seems to have been made with an older version of the application. Would you like to try and read it anyway? (May not work correctly)", "MyScout 2016", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                        {
                            Program.events.Add(new Event(reader.ReadElementString("Name"), reader.ReadElementString("BeginDate"), reader.ReadElementString("EndDate")));
                            Program.events[Program.events.Count - 1].rounds.Clear();

                            reader.ReadStartElement("Teams");
                            int count = Convert.ToInt32(reader.ReadElementString("Count"));

                            //Load Team Info
                            for (int i = 0; i < count; i++)
                            {
                                reader.ReadStartElement("Team");
                                List<object> tokens = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("TeamInfoTokens"));
                                Team team = new Team(Convert.ToInt32(tokens[0]), tokens[1].ToString());
                                team.avgScore = Convert.ToInt32(tokens[2]);
                                team.teleDefensesCrossed = Convert.ToInt32(tokens[3]);
                                team.teleHighGoals = Convert.ToInt32(tokens[4]);
                                team.teleLowGoals = Convert.ToInt32(tokens[5]);
                                team.towersScaled = Convert.ToInt32(tokens[6]);

                                for (int j = 0; j < 8; j++)
                                {
                                    team.defensesCrossable[j] = Convert.ToBoolean(tokens[j + 7]);
                                }

                                team.canScoreHighGoals = Convert.ToBoolean(tokens[15]);
                                team.canScoreLowGoals = Convert.ToBoolean(tokens[16]);
                                team.loadsFromEmbrasures = Convert.ToBoolean(tokens[17]);
                                team.loadsFromBattrice = Convert.ToBoolean(tokens[18]);
                                team.loadsFromFloor = Convert.ToBoolean(tokens[19]);

                                team.crossingPowerScore = Convert.ToInt32(tokens[20]);
                                team.autoDefensesCrossed = Convert.ToInt32(tokens[21]);
                                team.autoHighGoals = Convert.ToInt32(tokens[22]);
                                team.autoLowGoals = Convert.ToInt32(tokens[23]);
                                team.deathCount = Convert.ToInt32(tokens[24]);

                                for (int j = 0; j < 8; j++)
                                {
                                    team.deathDefenses[j] = Convert.ToInt32(tokens[j + 21]);
                                }

                                Program.events[Program.events.Count - 1].teams.Add(team);
                                reader.ReadEndElement();
                            }

                            reader.ReadEndElement();

                            reader.ReadStartElement("Rounds");
                            Program.events[Program.events.Count - 1].lastviewedround = Convert.ToInt32(reader.ReadElementString("Current"));
                            List<object> AllianceScores = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("AllianceScoreTokens"));
                            Round.score = new int[2] { Convert.ToInt32(AllianceScores[0]), Convert.ToInt32(AllianceScores[1]) };

                            count = Convert.ToInt32(reader.ReadElementString("Count"));
                            for (int i = 0; i < count; i++)
                            {
                                reader.ReadStartElement("Round");
                                Round round = new Round();

                                reader.ReadStartElement("Teams"); //Load the teams for each round
                                List<object> tokens = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("TeamTokens"));
                                for (int i2 = 0; i2 < 6; i2++)
                                {
                                    round.teams[i2] = Convert.ToInt32(tokens[i2]);
                                }
                                reader.ReadEndElement();

                                reader.ReadStartElement("Defenses");
                                for (int i2 = 0; i2 < 6; i2++)
                                {
                                    List<object> AOReachedTokens = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("AOReachedTokens"));
                                    List<object> AOCrossedTokens = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("AOCrossedTokens"));
                                    List<object> TOCrossedTokens = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("TOCrossedTokens"));

                                    for (int i3 = 0; i3 < 9; i3++)
                                    {
                                        round.defenses[i2, i3].AOreached      = (bool)AOReachedTokens[i3];
                                        round.defenses[i2, i3].AOcrossed      = (bool)AOCrossedTokens[i3];
                                        round.defenses[i2, i3].TOtimescrossed = (int)TOCrossedTokens[i3];
                                    }
                                }
                                reader.ReadEndElement();

                                round.scaledtower = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("TOScaledTokens")).Cast<bool>().ToArray();
                                round.challengedtower = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("TOChallengedTokens")).Cast<bool>().ToArray();
                                round.AOhighgoalcount = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("AOHighGoalTokens")).Cast<int>().ToArray();
                                round.AOlowgoalcount = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("AOLowGoalTokens")).Cast<int>().ToArray();
                                round.TOhighgoalcount = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("TOHighGoalTokens")).Cast<int>().ToArray();
                                round.TOlowgoalcount = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("TOLowGoalTokens")).Cast<int>().ToArray();

                                round.comments = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("CommentTokens")).Cast<string>().ToArray();
                                round.humancomments = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("HumanCommentTokens")).Cast<string>().ToArray();
                                round.died = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("DiedTokens")).Cast<bool>().ToArray();
                                round.dieddefense = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("DiedDefenseTokens")).Cast<int>().ToArray();
                                round.diedcomments = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("DiedCommentTokens")).Cast<string>().ToArray();

                                Program.events[Program.events.Count - 1].rounds.Add(round); //Add the round we just made to the round list.
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
        #endregion

        #region scOutput-related functions (pun brought to you by the amazing Ethan™)
        /// <summary>
        /// Saves all events in memory to the program's event folder.
        /// </summary>
        public static void SaveAllEvents()
        {
            if (Directory.Exists(Program.startuppath + "\\Events") && Directory.GetFiles(Program.startuppath + "\\Events").Length > 0)
            {
                if (Directory.Exists(Program.startuppath + "\\Events Backup"))
                {
                    Directory.Delete(Program.startuppath + "\\Events Backup",true);
                }
                Directory.Move(Program.startuppath + "\\Events", Program.startuppath + "\\Events Backup");
            }
            Directory.CreateDirectory(Program.startuppath + "\\Events");

            for (int i = 0; i < Program.events.Count; i++)
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
            try
            {
                if (File.Exists(Program.startuppath + "\\Events\\Event" + eventid.ToString() + ".xml"))
                {
                    File.Delete(Program.startuppath + "\\Events\\Event" + eventid.ToString() + ".xml");
                }

                using (XmlTextWriter writer = new XmlTextWriter(Program.startuppath + "\\Events\\Event" + eventid.ToString() + ".xml", Encoding.ASCII))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.Indentation = 4;

                    writer.WriteStartDocument();
                    writer.WriteStartElement("Event");
                    writer.WriteElementString("Version", Program.versionstring);
                    writer.WriteElementString("Name", Program.events[eventid].name);
                    writer.WriteElementString("BeginDate", Program.events[eventid].begindate);
                    writer.WriteElementString("EndDate", Program.events[eventid].enddate);

                    writer.WriteStartElement("Teams");
                    writer.WriteElementString("Count", Program.events[eventid].teams.Count.ToString());

                    //Convert team information to a tokenized int string
                    foreach (Team team in Program.events[eventid].teams)
                    {
                        writer.WriteStartElement("Team");
                        List<object> tokens = new List<object>();

                        tokens.Add(team.id);
                        tokens.Add(team.name);
                        tokens.Add(team.avgScore);
                        tokens.Add(team.teleDefensesCrossed);
                        tokens.Add(team.teleHighGoals);
                        tokens.Add(team.teleLowGoals);
                        tokens.Add(team.towersScaled);

                        for (int i = 0; i < 8; i++)
                        {
                            tokens.Add(team.defensesCrossable[i]);
                        }
                        tokens.Add(team.canScoreHighGoals);
                        tokens.Add(team.canScoreLowGoals);
                        tokens.Add(team.loadsFromEmbrasures);
                        tokens.Add(team.loadsFromBattrice);
                        tokens.Add(team.loadsFromFloor);

                        tokens.Add(team.crossingPowerScore);
                        tokens.Add(team.autoDefensesCrossed);
                        tokens.Add(team.autoDefensesReached);
                        tokens.Add(team.autoHighGoals);
                        tokens.Add(team.autoLowGoals);
                        tokens.Add(team.deathCount);

                        for (int i = 0; i < 8; i++)
                        {
                            tokens.Add(team.deathDefenses[i]);
                        }

                        writer.WriteElementString("TeamInfoTokens", TokenizeStringHandler.CreateTokenizedString(tokens));
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();

                    writer.WriteStartElement("Rounds");
                    writer.WriteElementString("Current", (Program.events[eventid].lastviewedround == -1)? (Program.events[eventid].rounds.Count-1).ToString(): Program.events[eventid].lastviewedround.ToString());
                    writer.WriteElementString("AllianceScoreTokens", TokenizeStringHandler.CreateTokenizedString(new List<object> { Round.score[0], Round.score[1] }));

                    writer.WriteElementString("Count", Program.events[eventid].rounds.Count.ToString());
                    
                    foreach (Round round in Program.events[eventid].rounds)
                    {
                        writer.WriteStartElement("Round");
                        writer.WriteStartElement("Teams");

                        List<object> teams = new List<object>(); //Save teams for each round

                        for (int i = 0; i < 6; i++)
                        {
                            teams.Add(round.teams[i]);
                        }

                        writer.WriteElementString("TeamTokens", TokenizeStringHandler.CreateTokenizedString(teams));
                        writer.WriteEndElement();


                        writer.WriteStartElement("Defenses");
                        for (int i = 0; i < 6; i++)
                        {
                            List<object> AOReachedTokens = new List<object>(); //Save defenses information per team
                            List<object> AOCrossedTokens = new List<object>();
                            List<object> TOCrossedTokens = new List<object>();

                            for (int i2 = 0; i2 < 9; i2++)
                            {
                                AOReachedTokens.Add(round.defenses[i, i2].AOreached);
                                AOCrossedTokens.Add(round.defenses[i, i2].AOcrossed);
                                TOCrossedTokens.Add(round.defenses[i, i2].TOtimescrossed);
                            }

                            writer.WriteElementString("AOReachedTokens", TokenizeStringHandler.CreateTokenizedString(AOReachedTokens));
                            writer.WriteElementString("AOCrossedTokens", TokenizeStringHandler.CreateTokenizedString(AOCrossedTokens));
                            writer.WriteElementString("TOCrossedTokens", TokenizeStringHandler.CreateTokenizedString(TOCrossedTokens));
                        }
                        writer.WriteEndElement(); //Defenses

                        writer.WriteElementString("TOScaledTokens", TokenizeStringHandler.CreateTokenizedString(round.scaledtower.Cast<object>().ToList()));
                        writer.WriteElementString("TOChallengedTokens", TokenizeStringHandler.CreateTokenizedString(round.challengedtower.Cast<object>().ToList()));
                        writer.WriteElementString("AOHighGoalTokens", TokenizeStringHandler.CreateTokenizedString(round.AOhighgoalcount.Cast<object>().ToList()));
                        writer.WriteElementString("AOLowGoalTokens", TokenizeStringHandler.CreateTokenizedString(round.AOlowgoalcount.Cast<object>().ToList()));
                        writer.WriteElementString("TOHighGoalTokens", TokenizeStringHandler.CreateTokenizedString(round.TOhighgoalcount.Cast<object>().ToList()));
                        writer.WriteElementString("TOLowGoalTokens", TokenizeStringHandler.CreateTokenizedString(round.TOlowgoalcount.Cast<object>().ToList()));
                        writer.WriteElementString("CommentTokens", TokenizeStringHandler.CreateTokenizedString(round.comments.Cast<object>().ToList()));
                        writer.WriteElementString("HumanCommentTokens", TokenizeStringHandler.CreateTokenizedString(round.humancomments.Cast<object>().ToList()));
                        writer.WriteElementString("DiedTokens", TokenizeStringHandler.CreateTokenizedString(round.died.Cast<object>().ToList()));
                        writer.WriteElementString("DiedDefenseTokens", TokenizeStringHandler.CreateTokenizedString(round.dieddefense.Cast<object>().ToList()));
                        writer.WriteElementString("DiedCommentTokens", TokenizeStringHandler.CreateTokenizedString(round.diedcomments.Cast<object>().ToList()));
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    writer.WriteEndElement();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Event #{eventid.ToString()} could not be saved. \n\n{ex.Message}", "MyScout 2016", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Save pertinent data to Teams and calculate scores as necessary
        /// </summary>
        public static void SaveDataToTeams()
        {
            //for each team in the event
            for(int i = 0; i < Program.events[Program.currentevent].teams.Count; i++)
            {
                Team team = Program.events[Program.currentevent].teams[i];
                List<int> TOhighGoalsToAvg = new List<int>();
                List<int> TOlowGoalsToAvg = new List<int>();
                List<int> autoHighGoalsToAvg = new List<int>();
                List<int> autoLowGoalsToAvg = new List<int>();

                //for each round in the event
                foreach (Round r in Program.events[Program.currentevent].rounds)
                {
                    //for each team index in the round
                    for(int j = 0; j < 5; j++)
                    {
                        //if the team index is the same as the round's team index
                        if (r.teams[j] == i)
                        {
                            team.defensesCrossed[0] = r.defenses[j, 0].TOtimescrossed;
                            team.defensesCrossed[1] = r.defenses[j, 1].TOtimescrossed;
                            team.defensesCrossed[2] = r.defenses[j, 2].TOtimescrossed;
                            team.defensesCrossed[3] = r.defenses[j, 7].TOtimescrossed;
                            team.defensesCrossed[4] = r.defenses[j, 8].TOtimescrossed;
                            team.defensesCrossed[5] = r.defenses[j, 3].TOtimescrossed;
                            team.defensesCrossed[6] = r.defenses[j, 4].TOtimescrossed;
                            team.defensesCrossed[7] = r.defenses[j, 5].TOtimescrossed;
                            team.defensesCrossed[8] = r.defenses[j, 6].TOtimescrossed;
                            //TODO: rearrange MainFrm to mimic the internal team data List order

                            team.updateDefenseStats();

                            TOhighGoalsToAvg.Add(r.TOhighgoalcount[j]);
                            TOlowGoalsToAvg.Add(r.TOlowgoalcount[j]);
                            autoHighGoalsToAvg.Add(r.AOhighgoalcount[j]);
                            autoHighGoalsToAvg.Add(r.AOlowgoalcount[j]);

                            //Add to the death count
                            team.deathCount += r.died[j] ? 1 : 0;
                            if(r.died[j])
                            {
                                team.deathDefenses[r.dieddefense[j]] += 1;
                            }

                            team.towersScaled += r.scaledtower[j] ? 1 : 0;
                        }
                    }
                }
                //Avg high goals
                int highGoalAvg = 0;
                for(int j = 0; j < TOhighGoalsToAvg.Count; j++)
                {
                    highGoalAvg += TOhighGoalsToAvg[j];
                }

                //Avg low goals
                int lowGoalAvg = 0;
                for(int j = 0; j < TOlowGoalsToAvg.Count; j++)
                {
                    lowGoalAvg += TOlowGoalsToAvg[j];
                }

                //Avg auto high goals
                int autoHighGoalAvg = 0;
                for(int j = 0; j < autoHighGoalsToAvg.Count; j++)
                {
                    autoHighGoalAvg += autoHighGoalsToAvg[j];
                }

                //Avg auto low goals
                int autoLowGoalAvg = 0;
                for(int j = 0; j < autoLowGoalsToAvg.Count; j++)
                {
                    autoLowGoalAvg += autoLowGoalsToAvg[j];
                }

                if(TOhighGoalsToAvg.Count > 0)
                    team.teleHighGoals = highGoalAvg / TOhighGoalsToAvg.Count;

                if(TOlowGoalsToAvg.Count > 0)
                    team.teleLowGoals = lowGoalAvg / TOlowGoalsToAvg.Count;

                if(autoHighGoalsToAvg.Count > 0)
                    team.autoHighGoals = autoHighGoalAvg / autoHighGoalsToAvg.Count;

                if(autoLowGoalsToAvg.Count > 0)
                    team.autoLowGoals = autoLowGoalAvg / autoLowGoalsToAvg.Count;
                
                team.UpdateTeamScore();
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
            List<Team> sortedTeamList = teamList.OrderByDescending(
                team => (sorting == 0 ? team.avgScore : sorting == 1 ? team.autoDefensesCrossed : team.crossingPowerScore)
                ).ToList();

            string filepath = $"{Program.startuppath}\\Spreadsheets\\Scouting Report {ev.name}.xls";

            if (!Directory.Exists($"{Program.startuppath}\\Spreadsheets"))
            {
                Directory.CreateDirectory($"{Program.startuppath}\\Spreadsheets");
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

            worksheet.Cells[0, 2] = new Cell("Score");
            worksheet.Cells.ColumnWidth[2] = 1500;

            worksheet.Cells[0, 3] = new Cell("High Goals");
            worksheet.Cells.ColumnWidth[3] = 2500;
            worksheet.Cells[0, 4] = new Cell("Low Goals");
            worksheet.Cells[0, 5] = new Cell("Def Score");
            worksheet.Cells.ColumnWidth[4] = 2400;
            worksheet.Cells.ColumnWidth[5] = 2200;

            worksheet.Cells[0, 6] = new Cell("Defs:");
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

            for (int i = 1; i < sortedTeamList.Count() + 1; i++)
            {
                Team team = sortedTeamList[i - 1];
                if (team != null)
                {
                    worksheet.Cells[i, 0] = new Cell(team.id.ToString());
                    worksheet.Cells[i, 1] = new Cell(team.name);
                    worksheet.Cells[i, 2] = new Cell(team.avgScore.ToString());
                    worksheet.Cells[i, 3] = new Cell(team.teleHighGoals.ToString());
                    worksheet.Cells[i, 4] = new Cell(team.teleLowGoals.ToString());
                    worksheet.Cells[i, 5] = new Cell(team.crossingPowerScore.ToString());
                }
                else worksheet.Cells[i, 0] = new Cell("N/A");

                if(team != null)
                    for (int j = 0; j < 9; j++)
                    {
                        //Fill each defense cell with the number of times it has crossed the defense
                        worksheet.Cells[i, (j + 7)] = new Cell(team.defensesCrossed[j]);
                    }
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
            int[] rawTeamList = ev.rounds[roundID].teams;
            Team[] teamList = new Team[6];

            for(int i = 0; i < 6; i++)
            {
                teamList[i] = (Program.events[Program.currentevent].rounds[Program.currentround].teams[i] == -1) ? null :
                    Program.events[Program.currentevent].teams[Program.events[Program.currentevent].rounds[Program.currentround].teams[i]];
            }

            //Clean the report
            for(int i = 0; i < teamList.Length; i++)
            {
                if(teamList[i] == null)
                {
                    teamList[i] = new Team(0000, "null");
                }
            }

            string filepath = $"{Program.startuppath}\\Spreadsheets\\Scouting Report {ev.name} - Round {roundID+1}.xls";

            if (!Directory.Exists($"{Program.startuppath}\\Spreadsheets"))
            {
                Directory.CreateDirectory($"{Program.startuppath}\\Spreadsheets");
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
            worksheet.Cells[0, 4] = new Cell("FromEmb");
            worksheet.Cells[0, 5] = new Cell("FromBatt");
            worksheet.Cells.ColumnWidth[4] = 2250;
            worksheet.Cells.ColumnWidth[5] = 2300;

            worksheet.Cells[0, 6] = new Cell("FromFloor");
            worksheet.Cells.ColumnWidth[6] = 2400;

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

            for (int i = 1; i < teamList.Count() + 1; i++)
            {
                Team team = teamList[i - 1];
                if (team != null)
                {
                    worksheet.Cells[i, 0] = new Cell(team.id.ToString());
                    worksheet.Cells[i, 1] = new Cell(team.name);
                    worksheet.Cells[i, 2] = new Cell(team.canScoreHighGoals ? " " + ((char)0x221A).ToString() : "");
                    worksheet.Cells[i, 3] = new Cell(team.canScoreLowGoals ? " " + ((char)0x221A).ToString() : "");
                    worksheet.Cells[i, 4] = new Cell(team.loadsFromEmbrasures ? " " + ((char)0x221A).ToString() : "");
                    worksheet.Cells[i, 5] = new Cell(team.loadsFromBattrice ? " " + ((char)0x221A).ToString() : "");
                    worksheet.Cells[i, 6] = new Cell(team.loadsFromFloor ? " " + ((char)0x221A).ToString() : "");
                }
                else worksheet.Cells[i, 0] = new Cell("null");

                if(team != null)
                    for (int j = 0; j < 9; j++)
                    {
                        if (team.defensesCrossable[j]) worksheet.Cells[i, (j + 7)] = new Cell(" " + ((char)0x221A).ToString());
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
