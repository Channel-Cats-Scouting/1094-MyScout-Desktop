using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MyScout
{
    public partial class MainFrm : Form
    {
        /// <summary>
        /// The panels that show all defense-related information on the GUI.
        /// </summary>
        Panel[] defensepnls;

        #region Not pointless secrets™
        /// <summary>
        /// ...It's not a secret™
        /// </summary>
        private int konamicodeindex = 0;
        /// <summary>
        /// ...It's still not a secret™
        /// </summary>
        private Keys[] konamicodekeys = new Keys[10] { Keys.Up, Keys.Up, Keys.Down, Keys.Down, Keys.Left, Keys.Right, Keys.Left, Keys.Right, Keys.B, Keys.A };
        /// <summary>
        /// ...IT'S DEFINITELY NOT A SECRET™
        /// </summary>
        private bool konamicodeactivated = false;
        /// <summary>
        /// shhhhh
        /// </summary>
        private Bubble[] bubbles;
        /// <summary>
        /// Not for a secret™
        /// </summary>
        public static Random rnd = new Random();
        #endregion

        /// <summary>
        /// MainFrm's constructor
        /// </summary>
        public MainFrm()
        {
            InitializeComponent();
            defensepnls = new Panel[9] { panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9 };
            EventList.Enabled = AddEventBtn.Enabled = RemoveEventBtn.Enabled = EditEventBtn.Enabled = false;
            MngGamesBtn.Select();
        }

        #region GUI-related functions

        /// <summary>
        /// Gets the index to use for assigning to the current round's "teams" array.
        /// </summary>
        private int GetTeamBtnID(Button TeamBtn)
        {
            switch (TeamBtn.Name)
            {
                case "RedAllianceBtn1":
                    return 0;
                case "RedAllianceBtn2":
                    return 1;
                case "RedAllianceBtn3":
                    return 2;
                case "BlueAllianceBtn1":
                    return 3;
                case "BlueAllianceBtn2":
                    return 4;
                case "BlueAllianceBtn3":
                    return 5;
            }
            return 0;
        }

        #region GUI-refresh functions
        /// <summary>
        /// Makes sure the contents of the GUI event list are up to date
        /// with the contents of the actual list of events.
        /// </summary>
        public void RefreshEventList()
        {
            EventList.Items.Clear();
            foreach (Event e in Program.Events)
            {
                EventList.Items.Add(new ListViewItem(new string[] { e.name, e.datasetname, e.begindate, e.enddate }));
            }
        }

        /// <summary>
        /// Refreshes the elements of the GUI
        /// </summary>
        public void RefreshControls()
        {
            EventList.Enabled = AddEventBtn.Enabled = RemoveEventBtn.Enabled = EditEventBtn.Enabled = !TeamPnl.Visible;

            if (Program.CurrentTeamIndex != -1)
            {
                TeamNameLbl.Text = $"{((string.IsNullOrEmpty(Program.Events[Program.CurrentEventIndex].teams[Program.CurrentTeamIndex].name))? "" : Program.Events[Program.CurrentEventIndex].teams[Program.CurrentTeamIndex].name + " - ")}{Program.Events[Program.CurrentEventIndex].teams[Program.CurrentTeamIndex].id.ToString()}";
                TeamNameLbl.ForeColor = label1.ForeColor = (TeamNameLbl.Text != "Channel Cats - 1094")?SystemColors.HotTrack:Color.Orange;

                //foreach (Panel pnl in defensepnls)
                //{
                //    if (!TeleOpRB.Checked)
                //    {
                //        //Update the Autonomous GUI
                //        Defense defense = Program.events[Program.currentevent].rounds[Program.currentround].defenses[Program.selectedteamroundindex, Array.IndexOf(defensepnls, pnl)];
                //        (pnl.Controls[3] as RadioButton).Checked = defense.AOcrossed;
                //        (pnl.Controls[2] as RadioButton).Checked = defense.AOreached;
                //        (pnl.Controls[1] as RadioButton).Checked = (!defense.AOcrossed && !defense.AOreached);
                //    }
                //    else
                //    {
                //        //Update the Tele-OP GUI
                //        int timescrossed = Program.events[Program.currentevent].rounds[Program.currentround].defenses[Program.selectedteamroundindex, Array.IndexOf(defensepnls, pnl)].TOtimescrossed;
                //        (pnl.Controls[3] as RadioButton).Checked = (timescrossed >= 2);
                //        (pnl.Controls[2] as RadioButton).Checked = (timescrossed == 1);
                //        (pnl.Controls[1] as RadioButton).Checked = (timescrossed == 0);
                //    }
                //}

                //RDComments.Text = Program.events[Program.currentevent].rounds[Program.currentround].diedcomments[Program.selectedteamroundindex];
                //RDDefenseChkbx.SelectedIndex = Program.events[Program.currentevent].rounds[Program.currentround].dieddefense[Program.selectedteamroundindex];
                //TCommentsTxtbx.Text = Program.events[Program.currentevent].rounds[Program.currentround].comments[Program.selectedteamroundindex];

                //if (!TeleOpRB.Checked)
                //{
                //    TLowGoalNUD.Value = Program.events[Program.currentevent].rounds[Program.currentround].AOlowgoalcount[Program.selectedteamroundindex];
                //    THighGoalNUD.Value = Program.events[Program.currentevent].rounds[Program.currentround].AOhighgoalcount[Program.selectedteamroundindex];
                //}
                //else
                //{
                //    TLowGoalNUD.Value = Program.events[Program.currentevent].rounds[Program.currentround].TOlowgoalcount[Program.selectedteamroundindex];
                //    THighGoalNUD.Value = Program.events[Program.currentevent].rounds[Program.currentround].TOhighgoalcount[Program.selectedteamroundindex];
                //}

                //TChallengedTowerChkbx.Checked = Program.events[Program.currentevent].rounds[Program.currentround].challengedtower[Program.selectedteamroundindex];
                //TScaledTowerChkbx.Checked = Program.events[Program.currentevent].rounds[Program.currentround].scaledtower[Program.selectedteamroundindex];
                //RDDied.Checked = Program.events[Program.currentevent].rounds[Program.currentround].died[Program.selectedteamroundindex];
                //HPCommentsTxtbx.Text = Program.events[Program.currentevent].rounds[Program.currentround].humancomments[Program.selectedteamroundindex];
            }
            else
            {
                TeamNameLbl.Text = "No Team Selected";
                TeamNameLbl.ForeColor = label1.ForeColor = SystemColors.HotTrack;

                AutonomousRB.Checked = true;
                TeleOpRB.Checked = false;

                foreach (Panel pnl in defensepnls)
                {
                    (pnl.Controls[2] as RadioButton).Checked = (pnl.Controls[3] as RadioButton).Checked = false;
                    (pnl.Controls[1] as RadioButton).Checked = true;
                }

                TCommentsTxtbx.Text = "";
                TLowGoalNUD.Value = 0;
                THighGoalNUD.Value = 0;
                TChallengedTowerChkbx.Checked = false;
                TScaledTowerChkbx.Checked = false;
                RDDied.Checked = false;
                HPCommentsTxtbx.Text = "";
            }

            //TODO: Documentation
            for (int index = 0; index < AllianceBtnPnl.Controls.Count; index++)
            {
                if (AllianceBtnPnl.Controls[index].Name != "BackBtn" && AllianceBtnPnl.Controls[index].Name != "button1" && AllianceBtnPnl.Controls[index].Name != "genProgressBar" && AllianceBtnPnl.Controls[index].Name != "genOutputLabel")
                {
                    Button btn = AllianceBtnPnl.Controls[index] as Button;
                    int i = index - 2;

                    if (Program.CurrentTeamIndex != -1 && Program.SelectedTeamRoundIndex == i) { btn.FlatAppearance.BorderSize = 1; MainPnl.Visible = true; }
                    else { btn.FlatAppearance.BorderSize = 0; }

                    //TODO rounds is sometimes 0 when it should be larger. This is just basically circumvented. Fix this later.
                    try
                    {
                        btn.Tag = (Program.Events[Program.CurrentEventIndex].rounds[Program.CurrentRoundIndex].Teams[i] == -1) ? null : (object)Program.Events[Program.CurrentEventIndex].rounds[Program.CurrentRoundIndex].Teams[i];
                        btn.Text = (Program.Events[Program.CurrentEventIndex].rounds[Program.CurrentRoundIndex].Teams[i] == -1) ? "----" : Program.Events[Program.CurrentEventIndex].teams[Program.Events[Program.CurrentEventIndex].rounds[Program.CurrentRoundIndex].Teams[i]].id.ToString();
                    }
                    catch
                    {
                        btn.Tag = null;
                        btn.Text = "----";
                    }
                }
            }

            label1.Text = $"Round {Program.CurrentRoundIndex + 1} of {Program.Events[Program.CurrentEventIndex].rounds.Count}";
            button6.Enabled = Program.CurrentRoundIndex != 0;
            button5.Text = (Program.CurrentRoundIndex < Program.Events[Program.CurrentEventIndex].rounds.Count - 1) ? "->" : "+";
        }

        public void UpdateTitle()
        {
            Program.MainFrm.Text = ((TeamPnl.Visible) ? Program.Events[Program.CurrentEventIndex].name + " - MyScout 2016" : "MyScout 2016") + ((Program.Saved) ? "" : "*");
        }

        #endregion

        #region GUI Events
        /// <summary>
        /// Occurs when this instance of the form has been loaded.
        /// </summary>
        private void MainFrm_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Application.StartupPath + "\\Events"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Events");
            }
            else
            {
                new Thread(new ThreadStart(IO.LoadAllEvents)).Start();
            }

            if (!Directory.Exists(Application.StartupPath + "\\Datasets"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Datasets");
            }
            else
            {
                new Thread(new ThreadStart(IO.LoadDefaultDataset)).Start();
            }
        }

        /// <summary>
        /// Occurs when this instance of the form is closing.
        /// </summary>
        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.Events.Count > 0 && ((!Program.Saved && MessageBox.Show("You have unsaved changes! Would you like to save them now?", "MyScout 2016", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)) || (Program.Saved))
            {
                new Thread(new ThreadStart(IO.SaveAllEvents)).Start();
            }
        }

        /// <summary>
        /// Occurs when a key is pressed anywhere within the form.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //If the program is currently on the event list...
            if (!TeamPnl.Visible)
            {
                if (keyData == Keys.Delete)
                {
                    RemoveEventBtn.PerformClick();
                    return true;
                }
                else if (konamicodeindex > 9) { konamicodeindex = 0; return true; }
                else if (!konamicodeactivated && keyData == konamicodekeys[konamicodeindex])
                {
                    if (konamicodeindex < 9)
                    {
                        konamicodeindex++;
                    }
                    else
                    {
                        MessageBox.Show("Go play your Atari games you cheater.");
                        if (MessageBox.Show("Oh.. also, er... are you prone to epileptic seizures? :|\nNo, seriously. This could be bad if so.. xD", "", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            konamicodeindex = 0;
                            konamicodeactivated = true;

                            bubbles = new Bubble[rnd.Next(10)];
                            for (int i = 0; i < bubbles.Length; i++)
                            {
                                bubbles[i] = new Bubble();
                                bubbles[i].Location = new Point(rnd.Next(Screen.PrimaryScreen.Bounds.Width), rnd.Next(Screen.PrimaryScreen.Bounds.Height));
                                bubbles[i].Show();
                            }
                        }
                    }
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Occurs when the "Back" button is "clicked."
        /// </summary>
        private void BackBtn_Click(object sender, EventArgs e)
        {
            TeamPnl.Visible = false;
            UpdateTitle();
            RefreshControls();
        }

        //TODO: Re-name "button1" to "OpenReportFolderBtn" or something similar.
        private void button1_Click(object sender, EventArgs e)
        {
            IO.SaveEvent(Program.CurrentEventIndex);
            
            //Open report generation dialog
            GenReport genreport = new GenReport();

            if(genreport.ShowDialog() == DialogResult.OK)
            {
                //if (!genreport.GetIsPrescout())
                //{
                //    //TODO Get rounds that the team # in GenReport is a part of
                //    //Generate spreadsheet, but make sure that the RoundID stays -1 if already -1
                //    IO.GenerateSpreadsheet(Program.events[Program.currentevent], genreport.GetRoundID() >= 0 ? genreport.GetRoundID() - 1 : -1, genreport.GetSorting());

                //    //Figure out file path based on report data
                //    string filePath = $"{Program.startuppath}\\Spreadsheets\\Scouting Report {Program.events[Program.currentevent].name}" + (genreport.GetIsEventReport() ? "" : (" - Round " + genreport.GetRoundID())) + ".xls";

                //    if (File.Exists(filePath))
                //    {
                //        System.Diagnostics.Process.Start("explorer.exe", @"/select, " + filePath);
                //    }
                //}
                //else
                //{
                //    Thread generatethread = new Thread(new ParameterizedThreadStart(GenerateTeamRounds));
                //    generatethread.Start(genreport);
                //}
            }
        }

        /// <summary>
        /// Returns a list of internal event ids that contain a certain team
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        public List<int> FindTeamInRounds(Team team)
        {
            List<int> output = new List<int>();
            Event ev = Program.Events[Program.CurrentEventIndex];

            //For each round in ev
            for (int i = 0; i < ev.rounds.Count; i++)
            {
                Round r = ev.rounds[i];
                //For each team stored in the round
                for (int j = 0; j < 6; j++)
                {
                    //If the team is the passed team
                    if(r.Teams[j] != -1 && ev.teams[r.Teams[j]] == team)
                    {
                        output.Add(i);
                        break;
                    }
                }
            }

            return output;
        }

        /// <summary>
        /// A pre-scouting report generation method, built for threading
        /// </summary>
        /// <param name="genreporttemp"></param>
        public void GenerateTeamRounds(Object genreporttemp)
        {
            Event ev = Program.Events[Program.CurrentEventIndex];
            GenReport genreport = (GenReport)genreporttemp;

            //Get the rounds
            List<int> roundsToReport = FindTeamInRounds(Program.Events[Program.CurrentEventIndex].teams[genreport.GetTeamIndex()]);

            //Generate the rounds
            for (int i = 0; i < roundsToReport.Count; i++)
            {
                //IO.CreateRoundSpreadsheet(ev, roundsToReport[i], genreport.GetSorting());
            }

            //Figure out file path based on report data
            string filePath = ($"{Program.StartupPath}\\Spreadsheets");

            if (Directory.Exists(filePath))
            {
                System.Diagnostics.Process.Start("explorer.exe", filePath);
            }
            //TODO add loading bar to MainFrm
        }

        //Re-name "button5" to "NextRoundBtn" or something similar.
        private void button5_Click(object sender, EventArgs e)
        {
            if (Program.CurrentRoundIndex < Program.Events[Program.CurrentEventIndex].rounds.Count - 1)
            {
                Program.CurrentRoundIndex++;
                Program.Saved = false;
            }
            else
            {
                Program.Events[Program.CurrentEventIndex].rounds.Add(new Round());
                Program.CurrentRoundIndex = Program.Events[Program.CurrentEventIndex].rounds.Count - 1;
            }

            MainPnl.Enabled = false;
            Program.CurrentTeamIndex = Program.SelectedTeamRoundIndex = -1;
            Program.Events[Program.CurrentEventIndex].lastviewedround = Program.CurrentRoundIndex;
            RefreshControls();
        }

        //TODO: Re-name "button6" to "PrevRoundBtn" or something similar.
        private void button6_Click(object sender, EventArgs e)
        {
            if (Program.CurrentRoundIndex > 0)
            {
                Program.CurrentRoundIndex--;
            }

            MainPnl.Enabled = false;
            Program.CurrentTeamIndex = Program.SelectedTeamRoundIndex = -1;
            Program.Events[Program.CurrentEventIndex].lastviewedround = Program.CurrentRoundIndex;
            RefreshControls();
        }

        #region Event-related
        /// <summary>
        /// Occurs when the "Add Event" button is "clicked."
        /// </summary>
        private void AddEventBtn_Click(object sender, EventArgs e)
        {
            AddDataFrm adddataFrm = new AddDataFrm(AddDataFrm.Data.Event);

            if (adddataFrm.ShowDialog() == DialogResult.OK)
            {
                Program.Events.Add(new Event(adddataFrm.textBox1.Text, adddataFrm.textBox2.Text, adddataFrm.textBox3.Text, Program.DataSetName));
                RefreshEventList();
            }
        }

        /// <summary>
        /// Occurs when the "Remove Event" button is "clicked."
        /// </summary>
        private void RemoveEventBtn_Click(object sender, EventArgs e)
        {
            if (EventList.SelectedItems.Count > 0 && MessageBox.Show($"Are you SURE you want to permanently delete event \"{Program.Events[EventList.SelectedIndices[0]].name}\"?", "MyScout 2016", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (File.Exists(Application.StartupPath + "\\Events\\Event" + EventList.SelectedIndices[0].ToString() + ".xml"))
                {
                    File.Delete(Application.StartupPath + "\\Events\\Event" + EventList.SelectedIndices[0].ToString() + ".xml");
                }

                Program.Events.RemoveAt(EventList.SelectedIndices[0]);
                RefreshEventList();
            }
        }

        /// <summary>
        /// Occurs when the "Edit Event" button is "clicked."
        /// </summary>
        private void EditEventBtn_Click(object sender, EventArgs e)
        {
            if (EventList.SelectedItems.Count > 0)
            {
                AddDataFrm adddataFrm = new AddDataFrm(AddDataFrm.Data.Event);
                adddataFrm.textBox1.Text = Program.Events[EventList.SelectedIndices[0]].name;
                adddataFrm.textBox2.Text = Program.Events[EventList.SelectedIndices[0]].begindate;
                adddataFrm.textBox3.Text = Program.Events[EventList.SelectedIndices[0]].enddate;
                adddataFrm.Text = "Edit Event";

                if (adddataFrm.ShowDialog() == DialogResult.OK)
                {
                    Program.Events[EventList.SelectedIndices[0]].name = adddataFrm.textBox1.Text;
                    Program.Events[EventList.SelectedIndices[0]].begindate = adddataFrm.textBox2.Text;
                    Program.Events[EventList.SelectedIndices[0]].enddate = adddataFrm.textBox3.Text;
                    RefreshEventList();
                }
            }
        }

        /// <summary>
        /// Occurs when an item on the event list is double-clicked.
        /// </summary>
        private void EventList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (EventList.SelectedIndices.Count > 0)
            {
                Program.CurrentEventIndex = EventList.SelectedIndices[0];
                Program.CurrentTeamIndex = Program.SelectedTeamRoundIndex = -1;
                Program.CurrentRoundIndex = (Program.Events[Program.CurrentEventIndex].lastviewedround == -1)? Program.Events[Program.CurrentEventIndex].rounds.Count - 1 : Program.Events[Program.CurrentEventIndex].lastviewedround;

                MainPnl.Enabled = false;
                TeamPnl.Visible = true;

                UpdateTitle();
                RefreshControls();
            }
        }
        #endregion

        #region Team-related
        /// <summary>
        /// Occurs when one of the team buttons is "clicked."
        /// </summary>
        private void TeamBtn_MouseClick(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            int allianceid = GetTeamBtnID(btn);

            if (btn.Tag == null || e.Button == MouseButtons.Right)
            {
                TeamFrm tf = new TeamFrm();
                if (tf.ShowDialog() == DialogResult.OK)
                {
                    Team selectedteam = Program.Events[Program.CurrentEventIndex].teams[Program.CurrentTeamIndex];
                    Program.Events[Program.CurrentEventIndex].rounds[Program.CurrentRoundIndex].Teams[GetTeamBtnID(btn)] = Program.CurrentTeamIndex;

                    btn.Text = selectedteam.id.ToString();
                    btn.Tag = Program.CurrentTeamIndex;

                    Program.SelectedTeamRoundIndex = GetTeamBtnID(btn);
                    foreach (Control control in AllianceBtnPnl.Controls)
                    {
                        //If the control is a button...
                        if (control.GetType() == typeof(Button))
                        {
                            Button button = control as Button;
                            button.FlatAppearance.BorderSize = 0;
                        }
                    }

                    btn.FlatAppearance.BorderSize = 1;
                    MainPnl.Enabled = true;
                }
            }
            else
            {
                if (Program.SelectedTeamRoundIndex != GetTeamBtnID(btn))
                {
                    Program.CurrentTeamIndex = (int)btn.Tag;
                    Program.SelectedTeamRoundIndex = GetTeamBtnID(btn);

                    foreach (Control control in AllianceBtnPnl.Controls)
                    {
                        //If the control is a button...
                        if (control.GetType() == typeof(Button))
                        {
                            Button button = control as Button;
                            button.FlatAppearance.BorderSize = 0;
                        }
                    }

                    btn.FlatAppearance.BorderSize = 1;
                    MainPnl.Enabled = true;
                }
                else if (MessageBox.Show("This team is already selected! Do you want to remove it from it's slot?", "MyScout 2016",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Program.Events[Program.CurrentEventIndex].rounds[Program.CurrentRoundIndex].Teams[Program.SelectedTeamRoundIndex] = -1;
                    Program.CurrentTeamIndex = Program.SelectedTeamRoundIndex = -1;
                    btn.Tag = null; btn.Text = "----";

                    foreach (Control control in AllianceBtnPnl.Controls)
                    {
                        //If the control is a button...
                        if (control.GetType() == typeof(Button))
                        {
                            Button button = control as Button;
                            button.FlatAppearance.BorderSize = 0;
                        }
                    }

                    MainPnl.Enabled = false;
                }
            }

            RefreshControls();
        }

        /// <summary>
        /// Occurs when "TeleOpRB" is checked or unchecked.
        /// </summary>
        private void DiedChkbx_CheckedChanged(object sender, EventArgs e)
        {
            //Enable/disable every control inside the "Died" groupbox
            RDDefenseLbl.Enabled = RDDefenseChkbx.Enabled = RDComments.Enabled = RDCommentsLbl.Enabled = RDDied.Checked;

            if (Program.SelectedTeamRoundIndex != -1)
            {
                //Program.events[Program.currentevent].rounds[Program.currentround].died[Program.selectedteamroundindex] = RDDied.Checked;
            }
        }

        /// <summary>
        /// Occurs when "TeleOpRB" is checked or unchecked.
        /// </summary>
        private void TeleOpRB_CheckedChanged(object sender, EventArgs e)
        {
            //Enable/disable the "Scaled Tower" and "Challenged Tower" checkboxes
            TScaledTowerChkbx.Enabled = TChallengedTowerChkbx.Enabled = TeleOpRB.Checked;

            //Rename and load data for radio buttons
            if (TeleOpRB.Checked)
            {
                foreach (Panel p in defensepnls)
                {
                    p.Controls[1].Text = "0";
                    p.Controls[2].Text = "1";
                    p.Controls[3].Text = "2+";
                    p.Refresh();
                }
            }
            else if (AutonomousRB.Checked)
            {
                foreach(Panel p in defensepnls)
                {
                    p.Controls[1].Text = "Did Nothing";
                    p.Controls[2].Text = "Reached";
                    p.Controls[3].Text = "Crossed";
                    p.Refresh();
                }
            }
            RefreshControls();
        }

        /// <summary>
        /// Occurs when "DefenseRB" is checked or unchecked.
        /// </summary>
        private void DefenseRB_CheckedChanged(object sender, EventArgs e)
        {
            if (Program.CurrentTeamIndex != -1 && Program.SelectedTeamRoundIndex != -1)
            {
                RadioButton rb = sender as RadioButton;
                Panel containingpnl = (rb != null && rb.Parent != null) ? rb.Parent as Panel : null;

                if (containingpnl != null && defensepnls.Contains(containingpnl))
                {
                    //if (!TeleOpRB.Checked)
                    //{
                    //    //TODO: Documentation
                    //    Program.events[Program.currentevent].rounds[Program.currentround].defenses[Program.selectedteamroundindex, Array.IndexOf(defensepnls, containingpnl)].AOcrossed = (containingpnl.Controls[3] as RadioButton).Checked;
                    //    Program.events[Program.currentevent].rounds[Program.currentround].defenses[Program.selectedteamroundindex, Array.IndexOf(defensepnls, containingpnl)].AOreached = (containingpnl.Controls[2] as RadioButton).Checked;
                    //}
                    //else
                    //{
                    //    //TODO: Documentation
                    //    Program.events[Program.currentevent].rounds[Program.currentround].defenses[Program.selectedteamroundindex, Array.IndexOf(defensepnls, containingpnl)].TOtimescrossed =
                    //    ((containingpnl.Controls[3] as RadioButton).Checked)? 2 : ((containingpnl.Controls[2] as RadioButton).Checked)? 1 : 0;
                    //}
                }
                Program.Saved = false;
            }
        }

        /// <summary>
        /// Occurs when the text in "TCommentsTxtbx" is changed.
        /// </summary>
        private void TCommentsTxtbx_TextChanged(object sender, EventArgs e)
        {
            if (Program.Events[Program.CurrentEventIndex].rounds.Count > Program.CurrentRoundIndex && Program.SelectedTeamRoundIndex != -1)
            {
                //Program.events[Program.currentevent].rounds[Program.currentround].comments[Program.selectedteamroundindex] = TCommentsTxtbx.Text;
            }
        }

        #endregion

        #endregion

        #endregion

        private void TLowGoalNUD_ValueChanged(object sender, EventArgs e)
        {
            if (Program.SelectedTeamRoundIndex != -1)
            {
                //if (!TeleOpRB.Checked)
                //{
                //    Program.events[Program.currentevent].rounds[Program.currentround].AOlowgoalcount[Program.selectedteamroundindex] = (int)TLowGoalNUD.Value;
                //}
                //else
                //{
                //    Program.events[Program.currentevent].rounds[Program.currentround].TOlowgoalcount[Program.selectedteamroundindex] = (int)TLowGoalNUD.Value;
                //}
                Program.Saved = false;
            }
        }

        private void THighGoalNUD_ValueChanged(object sender, EventArgs e)
        {
            if (Program.SelectedTeamRoundIndex != -1)
            {
                //if (!TeleOpRB.Checked)
                //{
                //    Program.events[Program.currentevent].rounds[Program.currentround].AOhighgoalcount[Program.selectedteamroundindex] = (int)THighGoalNUD.Value;
                //}
                //else
                //{
                //    Program.events[Program.currentevent].rounds[Program.currentround].TOhighgoalcount[Program.selectedteamroundindex] = (int)THighGoalNUD.Value;
                //}
                Program.Saved = false;
            }
        }

        private void TChallengedTowerChkbx_CheckedChanged(object sender, EventArgs e)
        {
            //if (Program.selectedteamroundindex != -1)
            //{
            //    Program.events[Program.currentevent].rounds[Program.currentround].challengedtower[Program.selectedteamroundindex] = TChallengedTowerChkbx.Checked;
            //    Program.saved = false;
            //}
        }

        private void TScaledTowerChkbx_CheckedChanged(object sender, EventArgs e)
        {
            //if (Program.selectedteamroundindex != -1)
            //{
            //    Program.events[Program.currentevent].rounds[Program.currentround].scaledtower[Program.selectedteamroundindex] = TScaledTowerChkbx.Checked;
            //    Program.saved = false;
            //}
        }

        private void HPCommentsTxtbx_TextChanged(object sender, EventArgs e)
        {
            //if (Program.events[Program.currentevent].rounds.Count > Program.currentround && Program.selectedteamroundindex != -1)
            //{
            //    Program.events[Program.currentevent].rounds[Program.currentround].humancomments[Program.selectedteamroundindex] = HPCommentsTxtbx.Text;
            //    Program.saved = false;
            //}
        }

        private void RDComments_TextChanged(object sender, EventArgs e)
        {
            //if (Program.events[Program.currentevent].rounds.Count > Program.currentround && Program.selectedteamroundindex != -1)
            //{
            //    Program.events[Program.currentevent].rounds[Program.currentround].diedcomments[Program.selectedteamroundindex] = RDComments.Text;
            //    Program.saved = false;
            //}
        }

        private void RDDefenseChkbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (Program.selectedteamroundindex != -1)
            //{
            //    Program.events[Program.currentevent].rounds[Program.currentround].dieddefense[Program.selectedteamroundindex] = RDDefenseChkbx.SelectedIndex;
            //    Program.saved = false;
            //}
        }

        private void preScoutButton_Click(object sender, EventArgs e)
        {
            if (Program.Events.Count > 0)
            {
                PrescoutFrm prescoutform = new PrescoutFrm();
                prescoutform.Show();
            }
            else
            {
                MessageBox.Show("There are no events to pre-scout!", "MyScout 2016", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IO.SaveEvent(Program.CurrentEventIndex);
            Program.Saved = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GameSelectFrm gameSelectFrm = new GameSelectFrm();
            if(gameSelectFrm.ShowDialog() == DialogResult.OK)
            {
                EventList.Enabled = AddEventBtn.Enabled = RemoveEventBtn.Enabled = EditEventBtn.Enabled = true;
                GameDataWarning.Enabled = GameDataWarning.Visible = false;
                GameNameLbl.Text = "Game:\r\n" + Program.DataSetName;

                //Reload all the events
                Program.Events.Clear();
                IO.LoadAllEvents();
            }
        }
    }
}
