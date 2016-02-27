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
                                team.towerScaledAvg = Convert.ToInt32(tokens[6]);

                                for (int j = 0; j < 8; j++)
                                {
                                    team.defensesCrossable[j] = Convert.ToBoolean(tokens[j + 7]);
                                }

                                team.crossingPowerScore = Convert.ToInt32(tokens[16]);
                                team.autoDefensesCrossed = Convert.ToInt32(tokens[17]);
                                team.autoHighGoals = Convert.ToInt32(tokens[18]);
                                team.autoLowGoals = Convert.ToInt32(tokens[19]);
                                team.deathCount = Convert.ToInt32(tokens[20]);

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
                            Round.score[0] = Convert.ToInt32(reader.ReadElementString("AllianceScore1"));
                            Round.score[1] = Convert.ToInt32(reader.ReadElementString("AllianceScore2"));

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
                                    List<object> reachedTokens = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("ReachedTokens"));
                                    List<object> timesCrossedTokens = TokenizeStringHandler.ReadTokenizedString(reader.ReadElementString("TimesCrossedTokens"));
                                    for (int i3 = 0; i3 < 9; i3++)
                                    {
                                        round.defenses[i2, i3].reached = (bool)reachedTokens[i3];
                                        //round.defenses[i2, i3].timescrossed = (int)timesCrossedTokens[i3];
                                    }
                                }
                                reader.ReadEndElement();

                                Program.events[Program.events.Count - 1].rounds.Add(round);
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
            if (Directory.Exists(Program.startuppath + "\\Events"))
            {
                Directory.Delete(Program.startuppath + "\\Events",true);
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
                        tokens.Add(team.towerScaledAvg);

                        for (int i = 0; i < 8; i++)
                        {
                            tokens.Add(team.defensesCrossable[i]);
                        }

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
                    writer.WriteElementString("AllianceScore1", Round.score[0].ToString());
                    writer.WriteElementString("AllianceScore2", Round.score[1].ToString());

                    writer.WriteElementString("Count", Program.events[eventid].rounds.Count.ToString());
                    int debugTicker = 0;
                    foreach (Round round in Program.events[eventid].rounds)
                    {
                        debugTicker++;

                        writer.WriteStartElement("Round");
                        writer.WriteStartElement("Teams");
                        List<object> teams = new List<object>();//Save teams for each round
                        for (int i = 0; i < 6; i++)
                        {
                            teams.Add(round.teams[i]);
                        }
                        writer.WriteElementString("TeamTokens", TokenizeStringHandler.CreateTokenizedString(teams));
                        writer.WriteEndElement();

                        writer.WriteStartElement("Defenses");
                        for (int i = 0; i < 6; i++)
                        {
                            List<object> reachedTokens = new List<object>(); //Save defenses information per team
                            List<object> crossedTokens = new List<object>();

                            for (int i2 = 0; i2 < 9; i2++)
                            {
                                reachedTokens.Add(round.defenses[i, i2].reached);
                                //crossedTokens.Add(round.defenses[i, i2].timescrossed);
                            }
                            writer.WriteElementString("ReachedTokens", TokenizeStringHandler.CreateTokenizedString(reachedTokens));
                            writer.WriteElementString("TimesCrossedTokens", TokenizeStringHandler.CreateTokenizedString(crossedTokens));
                        }
                        writer.WriteEndElement();
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
        /// Generate a team spreadsheet in "{Program.startuppath}\Spreadsheets\Scouting Report {ev.name}.xls"
        /// </summary>
        /// <param name="ev">The event to load data from</param>
        /// <param name="sorting">How to sort the generated report; 1:TotalScore, 2:AutoScore, 3:CrossingPower</param>
        public static void CreateTeamSpreadsheet(Event ev, int sorting)
        {
            List<Team> teamList = ev.teams;

            //Sort the team list based on the sorting int
            List<Team> sortedTeamList = teamList.OrderByDescending(
                team => (sorting == 1 ? team.avgScore : sorting == 2 ? team.autoDefensesCrossed : team.crossingPowerScore)
                ).ToList();

            string filepath = $"{Program.startuppath}\\Spreadsheets\\Scouting Report {ev.name}.xls";

            if (!Directory.Exists($"{Program.startuppath}\\Spreadsheets"))
            {
                Directory.CreateDirectory($"{Program.startuppath}\\Spreadsheets");
            }

            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet("Scouting Report");
            worksheet.Cells[0, 0] = new Cell("ID");
            worksheet.Cells.ColumnWidth[0] = 1500;

            worksheet.Cells[0, 1] = new Cell("Name");
            worksheet.Cells.ColumnWidth[1] = 4000;

            worksheet.Cells[0, 2] = new Cell("Score");
            worksheet.Cells.ColumnWidth[2] = 1500;

            worksheet.Cells[0, 3] = new Cell("High Goals");
            worksheet.Cells[0, 4] = new Cell("Low Goals");
            worksheet.Cells[0, 5] = new Cell("Def Score");
            worksheet.Cells.ColumnWidth[3, 5] = 2500;

            worksheet.Cells[0, 6] = new Cell("Defenses:");
            worksheet.Cells.ColumnWidth[6] = 2700;

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
                worksheet.Cells[i, 0] = new Cell(team.id.ToString());
                worksheet.Cells[i, 1] = new Cell(team.name);
                worksheet.Cells[i, 2] = new Cell(team.avgScore.ToString());
                worksheet.Cells[i, 3] = new Cell(team.teleHighGoals.ToString());
                worksheet.Cells[i, 4] = new Cell(team.teleLowGoals.ToString());
                worksheet.Cells[i, 5] = new Cell(team.crossingPowerScore.ToString());

                for (int j = 0; j < 9; j++)
                {
                    if (team.defensesCrossable[j]) worksheet.Cells[i, (j + 6)] = new Cell(" " + ((char)0x221A).ToString());
                }
            }

            workbook.Worksheets.Add(worksheet);
            workbook.Save(filepath);
        }
        #endregion
    }
}
