﻿using System;
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
                EventList.Items.Add(new ListViewItem(new string[] { e.filename, e.name, e.datasetname, e.begindate, e.enddate }));
            }

            if (EventList.Items.Count > 0)
            {
                EventList.Items[0].Selected = true;
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
            }
            else
            {
                TeamNameLbl.Text = "No Team Selected";
                TeamNameLbl.ForeColor = label1.ForeColor = SystemColors.HotTrack;
            }

            //TODO: Documentation
            for (int index = 0; index < AllianceBtnPnl.Controls.Count; index++)
            {
                if (AllianceBtnPnl.Controls[index].Name != "BackBtn" && AllianceBtnPnl.Controls[index].Name != "OptionsBtn" && AllianceBtnPnl.Controls[index].Name != "button1" && AllianceBtnPnl.Controls[index].Name != "genProgressBar" && AllianceBtnPnl.Controls[index].Name != "genOutputLabel")
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

            //Update Controls
            if (Program.SelectedTeamRoundIndex < 0) return;
            
            //Loop through both groupboxes
            for(int i = 0; i < teleOpGB.Controls.Count; ++i)
            {
                Control container = teleOpGB.Controls[i];
                if(TagMgr.ContainsTag(container, Tags.FORMBLOCK))
                {
                    DataPoint data = null;
                    for(int j = 0; j < container.Controls.Count; ++j)
                    {
                        Control c = container.Controls[j];
                        if (data == null)
                        {
                            string datapoint = TagMgr.GetTagValue(c, Tags.DATAPOINT_);
                            if (datapoint != "")
                            {
                                data = Program.CurrentRound.DataSet[Program.SelectedTeamRoundIndex][Convert.ToInt16(datapoint)];
                            --j;
                            }
                        }
                        else
                        {
                            if (c.GetType() == typeof(CheckBox) && TagMgr.ContainsTag(c, Tags.BOOL_SOURCE))
                            {
                                ((CheckBox)c).Checked = (bool)data.GetValue();
                            }
                            else if(c.GetType() == typeof(NumericUpDown) && TagMgr.ContainsTag(c, Tags.INT_SOURCE))
                            {
                                ((NumericUpDown)c).Value = (int)data.GetValue();
                            }
                        }
                    }
                }
            }

            autoLowGoalNUD.Value = (int)Program.CurrentRound.DataSet[Program.SelectedTeamRoundIndex][0].GetValue();
            autoHighGoalNUD.Value = (int)Program.CurrentRound.DataSet[Program.SelectedTeamRoundIndex][1].GetValue();
            autoGearChkbx.Checked = (bool)Program.CurrentRound.DataSet[Program.SelectedTeamRoundIndex][2].GetValue();
            autoLineChkbx.Checked = (bool)Program.CurrentRound.DataSet[Program.SelectedTeamRoundIndex][3].GetValue();

            highGoalTracker.Value = (int)Program.CurrentRound.DataSet[Program.SelectedTeamRoundIndex][5].GetValue();
            gearNUD.Value = (int)Program.CurrentRound.DataSet[Program.SelectedTeamRoundIndex][6].GetValue();
            ropeChkbx.Checked = (bool)Program.CurrentRound.DataSet[Program.SelectedTeamRoundIndex][7].GetValue();
        }

        public void UpdateTitle()
        {
            Program.MainFrm.Text = ((TeamPnl.Visible) ? Program.Events[Program.CurrentEventIndex].name + " - MyScout 2017 v" + Program.VersionString : "MyScout 2017 v" + Program.VersionString) + ((Program.Saved) ? "" : "*");
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
            if (Program.Events.Count > 0 && ((!Program.Saved && MessageBox.Show("You have unsaved changes! Would you like to save them now?", "MyScout 2017", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)) || (Program.Saved))
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
        private void Button1_Click(object sender, EventArgs e)
        {
            IO.SaveEvent(Program.CurrentEventIndex);
            
            //Open report generation dialog
            GenReportFrm genreport = new GenReportFrm();
            genreport.ShowDialog();
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
            GenReportFrm genreportfrm = (GenReportFrm)genreporttemp;

            //Get the rounds
            List<int> roundsToReport = FindTeamInRounds(Program.Events[Program.CurrentEventIndex].teams[genreportfrm.GetSelectedTeam()]);

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

            Program.CurrentTeamIndex = Program.SelectedTeamRoundIndex = -1;
            Program.Events[Program.CurrentEventIndex].lastviewedround = Program.CurrentRoundIndex;
            RefreshAfterRoundEdit();
        }

        public void RefreshAfterRoundEdit()
        {
            MainPnl.Enabled = false;
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
                Program.Events.Add(new Event(adddataFrm.textBox1.Text, adddataFrm.textBox2.Text, adddataFrm.textBox3.Text, Program.DataSetName, "Event_" + adddataFrm.textBox1.Text + ".xml"));
                RefreshEventList();
            }
        }

        /// <summary>
        /// Occurs when the "Remove Event" button is "clicked."
        /// </summary>
        private void RemoveEventBtn_Click(object sender, EventArgs e)
        {
            if (EventList.SelectedItems.Count > 0 && MessageBox.Show($"Are you SURE you want to permanently delete event \"{Program.Events[EventList.SelectedIndices[0]].name}\"?", "MyScout 2017", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
                Program.CurrentRoundIndex =
                    (Program.Events[Program.CurrentEventIndex].lastviewedround == -1)?
                    Program.Events[Program.CurrentEventIndex].rounds.Count - 1 :
                    Program.Events[Program.CurrentEventIndex].lastviewedround;

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
                else if (MessageBox.Show("This team is already selected! Do you want to remove it from it's slot?", "MyScout 2017",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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

        #endregion

        #endregion

        #endregion

        private void preScoutButton_Click(object sender, EventArgs e)
        {
            if (Program.Events.Count > 0)
            {
                PrescoutFrm prescoutform = new PrescoutFrm();
                prescoutform.Show();
            }
            else
            {
                MessageBox.Show("There are no events to pre-scout!", "MyScout 2017", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
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
                EventList.Select();
            }
        }

        private void highGoalTracker_ValueChanged(object sender, EventArgs e)
        {
            var bar = sender as TrackBar;
            if (bar == null) return;

            if (bar.Value % bar.SmallChange != 0)
            {
                bar.Value = bar.SmallChange * ((bar.Value + bar.SmallChange / 2) / bar.SmallChange);
            }

            Program.CurrentRound.DataSet[Program.SelectedTeamRoundIndex][5].SetValue(bar.Value);
        }

        private void NUD_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            if (nud == null) return;
            Program.CurrentRound.DataSet[Program.SelectedTeamRoundIndex][(int)nud.Tag].SetValue((int)nud.Value);
        }

        private void Chkbx_CheckedChanged(object sender, EventArgs e)
        {
            var chkBx = sender as CheckBox;
            if (chkBx == null) return;
            Program.CurrentRound.DataSet[Program.SelectedTeamRoundIndex][(int)chkBx.Tag].SetValue(chkBx.Checked);
        }

        private void upDownBtn_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            if (btn == upLowGoalBtn)
                modifyNUDValue(autoLowGoalNUD, 1);
            else if (btn == dnLowGoalBtn)
                modifyNUDValue(autoLowGoalNUD, -1);
            else if (btn == upHighGoalBtn)
                modifyNUDValue(autoHighGoalNUD, 1);
            else if (btn == dnHighGoalBtn)
                modifyNUDValue(autoHighGoalNUD, -1);
            else if (btn == leftHighGoalTOBtn)
                modifyTrackerValue(highGoalTracker, -25);
            else if (btn == rightHighGoalTOBtn)
                modifyTrackerValue(highGoalTracker, 25);
            else if (btn == upGearsTOBtn)
                modifyNUDValue(gearNUD, 1);
            else if (btn == dnGearsTOBtn)
                modifyNUDValue(gearNUD, -1);
        }

        private void modifyNUDValue(NumericUpDown nud, int modifier)
        {
            var value = nud.Value + modifier;
            if (value > nud.Maximum)
                value = nud.Maximum;
            else if (value < nud.Minimum)
                value = nud.Minimum;

            nud.Value = value;
        }

        private void modifyTrackerValue(TrackBar tracker, int modifier)
        {
            var value = tracker.Value + modifier;
            if (value > tracker.Maximum)
                value = tracker.Maximum;
            else if (value < tracker.Minimum)
                value = tracker.Minimum;

            tracker.Value = value;
        }

        private void OpenEventFolderBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", IO.EVENTS_FOLDER_ROOT);
        }

        private void OpenDatasetFolderBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", IO.DATASETS_FOLDER_ROOT);
        }

        private void OptionsBtn_Click(object sender, EventArgs e)
        {
            //TODO: Say something like "Hey don't do this you'll delete all your data" for noobs
            ConfigFrm configfrm = new ConfigFrm();
            configfrm.ShowDialog();
        }
    }
}