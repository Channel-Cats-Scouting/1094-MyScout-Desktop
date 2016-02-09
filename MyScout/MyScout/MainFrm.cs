using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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

        //Variables for scaling of GUI
        //Back Button
        float BackBtnWidth;
        float BackBtnHeight;
        //Red Alliance Button 1
        float RDGroupBxWidth;
        float RDGroupBxHeight;
        //Red Alliance Button 1
        float HPGroupBxWidth;
        float HPGroupBxHeight;
        //Tele-op and Auto Group Box
        float TGroupBxHeight;
        float TGroupBxWidth;
        //Defenses Group Box
        float DefenseGBxHeight;
        float DefenseGBxWidth;
        //Form Height/Width
        float FrmWidth;
        float FrmHeight;
        public MainFrm()
        {
            InitializeComponent();
            DefenseCBx.SelectedIndex = 0;

            if (!Directory.Exists(Application.StartupPath+"\\Events"))
            {
                Directory.CreateDirectory(Application.StartupPath+"\\Events");
            }
            else
            {
                //TODO: Load Events
            }
        }

        /// <summary>
        /// Makes sure the contents of the GUI event list are up to date
        /// with the contents of the actual list of events.
        /// </summary>
        private void RefreshEventList()
        {
            EventList.Items.Clear();
            foreach (Event e in Program.events)
            {
                EventList.Items.Add(new ListViewItem(new string[] { e.name, e.begindate, e.enddate }));
            }
        }

        /// <summary>
        /// Makes sure the only controls that are enabled are the ones you can currently see.
        /// </summary>
        private void RefreshControls()
        {
            EventList.Enabled = AddEventBtn.Enabled = RemoveEventBtn.Enabled = EditEventBtn.Enabled = !TeamPnl.Visible;

            if (TeamPnl.Visible)
            {
                for (int index = 0; index < AllianceBtnPnl.Controls.Count; index++)
                {
                    if (AllianceBtnPnl.Controls[index].Name != "BackBtn")
                    {
                        Button btn = AllianceBtnPnl.Controls[index] as Button;
                        int i = index - 1;

                        btn.FlatAppearance.BorderSize = 0;
                        Console.WriteLine(btn.Name);
                        btn.Tag = (Program.events[Program.currentevent].Alliances[(i < 3) ? 0 : 1].teams[(i < 3) ? i : i - 3] == -1)? null : (object)Program.events[Program.currentevent].Alliances[(i < 3) ? 0 : 1].teams[(i < 3) ? i : i - 3];
                        btn.Text = (Program.events[Program.currentevent].Alliances[(i < 3) ? 0 : 1].teams[(i < 3) ? i : i - 3] == -1) ? "----" : Program.events[Program.currentevent].teams[Program.events[Program.currentevent].Alliances[(i < 3) ? 0 : 1].teams[(i < 3) ? i : i - 3]].id.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// TODO: Documentation
        /// </summary>
        private void RefreshTeamPnl()
        {
            if (Program.selectedteam != -1)
            {
                TeamNameLbl.Text = $"{Program.events[Program.currentevent].teams[Program.selectedteam].name} - {Program.events[Program.currentevent].teams[Program.selectedteam].id.ToString()}";
                TimesCrossed.Text = Program.events[Program.currentevent].teams[Program.selectedteam].defenses[DefenseCBx.SelectedIndex].timescrossed.ToString();
                ReachedRB.Checked = Program.events[Program.currentevent].teams[Program.selectedteam].defenses[DefenseCBx.SelectedIndex].reached;
                DidNothingRB.Checked = !ReachedRB.Checked;

                RefreshDefenseCrossedBtns();
            }
            else
            {
                TeamNameLbl.Text = "No Team Selected";
                TimesCrossed.Text = "0";
                ReachedRB.Checked = false;
                DidNothingRB.Checked = true;

                RefreshDefenseCrossedBtns();
            }
        }

        /// <summary>
        /// TODO: Documentation
        /// </summary>
        private void RefreshDefenseCrossedBtns()
        {
            button4.Enabled = (ReachedRB.Checked && Convert.ToInt32(TimesCrossed.Text) < 2);
            button3.Enabled = (ReachedRB.Checked && Convert.ToInt32(TimesCrossed.Text) > 0);
        }

        /// <summary>
        /// Save the given event as an XML file.
        /// </summary>
        /// <param name="eventid">The event to save as an XML file.</param>
        private void SaveEvent(int eventid)
        {
            if (File.Exists(Application.StartupPath+"\\Events\\Event"+eventid.ToString()+".xml"))
            {
                File.Delete(Application.StartupPath+"\\Events\\Event"+eventid.ToString()+".xml");
            }

            using (XmlWriter writer = XmlWriter.Create(Application.StartupPath + "\\Events\\Event" + eventid.ToString() + ".xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Event");
                writer.WriteElementString("Name", Program.events[eventid].name);

                writer.WriteStartElement("Teams");

                foreach (Team team in Program.events[eventid].teams)
                {
                    writer.WriteStartElement("Team");
                    writer.WriteElementString("Name", team.name);
                    writer.WriteElementString("ID", team.id.ToString());
                    writer.WriteElementString("Score",team.score.ToString());

                    writer.WriteStartElement("Defenses");

                    foreach (Defense defense in team.defenses)
                    {
                        writer.WriteStartElement("Defense");
                        writer.WriteElementString("Reached",defense.reached.ToString());
                        writer.WriteElementString("TimesCrossed", defense.timescrossed.ToString());
                        //writer.WriteElementString("Skill",defense.skill.ToString());
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }

        #region GUI Events
        /// <summary>
        /// Occurs when one of the team buttons is "clicked."
        /// </summary>
        private void TeamBtn_MouseClick(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            int allianceid = (btn == RedAllianceBtn1) ? 0 : (btn == RedAllianceBtn2) ? 1 : (btn == RedAllianceBtn3) ? 2 :
                (btn == BlueAllianceBtn1) ? 3 : (btn == BlueAllianceBtn2) ? 4 : 5;

            if (btn.Tag == null || e.Button == MouseButtons.Right)
            {
                TeamFrm tf = new TeamFrm();
                if (tf.ShowDialog() == DialogResult.OK)
                {
                    Team selectedteam = Program.events[Program.currentevent].teams[Program.selectedteam];
                    Program.events[Program.currentevent].Alliances[(allianceid < 3)?0:1].teams[(allianceid < 3)?allianceid:allianceid-3] = Program.selectedteam;

                    btn.Text = selectedteam.id.ToString();
                    btn.Tag = Program.selectedteam;

                    Program.selectedteam = (int)btn.Tag;
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
                    DefenseCBx.SelectedIndex = 0;

                    RefreshTeamPnl();
                }
            }
            else
            {
                if (Program.selectedteam != (int)btn.Tag)
                {
                    Program.selectedteam = (int)btn.Tag;
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
                    DefenseCBx.SelectedIndex = 0;
                    MainPnl.Enabled = true;
                    RefreshTeamPnl();
                }
                else if (MessageBox.Show("This team is already selected! Do you want to remove it from it's slot?", "MyScout 2016",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    btn.Tag = null; btn.Text = "----";
                    Program.selectedteam = -1;

                    foreach (Control control in AllianceBtnPnl.Controls)
                    {
                        //If the control is a button...
                        if (control.GetType() == typeof(Button))
                        {
                            Button button = control as Button;
                            button.FlatAppearance.BorderSize = 0;
                        }
                    }

                    DefenseCBx.SelectedIndex = 0;
                    MainPnl.Enabled = false;
                    RefreshTeamPnl();
                }
            }
        }

        /// <summary>
        /// Occurs when the "Back" button is "clicked."
        /// </summary>
        private void BackBtn_Click(object sender, EventArgs e)
        {
            TeamPnl.Visible = false;
            Text = "MyScout 2016";
            RefreshControls();
        }

        /// <summary>
        /// Occurs when the "Add Event" button is "clicked."
        /// </summary>
        private void AddEventBtn_Click(object sender, EventArgs e)
        {
            AddDataFrm adddataFrm = new AddDataFrm(AddDataFrm.Data.Event);

            if (adddataFrm.ShowDialog() == DialogResult.OK)
            {
                Program.events.Add(new Event(adddataFrm.textBox1.Text,adddataFrm.textBox2.Text,adddataFrm.textBox3.Text));
                RefreshEventList();
            }
        }

        /// <summary>
        /// Occurs when the "Remove Event" button is "clicked."
        /// </summary>
        private void RemoveEventBtn_Click(object sender, EventArgs e)
        {
            if (EventList.SelectedItems.Count > 0 && MessageBox.Show("Are you SURE you want to remove the selected event?", "MyScout 2016", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Program.events.RemoveAt(EventList.SelectedIndices[0]);
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
                adddataFrm.textBox1.Text = Program.events[EventList.SelectedIndices[0]].name;
                adddataFrm.textBox2.Text = Program.events[EventList.SelectedIndices[0]].begindate;
                adddataFrm.textBox3.Text = Program.events[EventList.SelectedIndices[0]].enddate;
                adddataFrm.Text = "Edit Event";

                if (adddataFrm.ShowDialog() == DialogResult.OK)
                {
                    Program.events[EventList.SelectedIndices[0]].name = adddataFrm.textBox1.Text;
                    Program.events[EventList.SelectedIndices[0]].begindate = adddataFrm.textBox2.Text;
                    Program.events[EventList.SelectedIndices[0]].enddate = adddataFrm.textBox3.Text;
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
                Program.selectedteam = -1;

                foreach (Control control in AllianceBtnPnl.Controls)
                {
                    //If the control is a button...
                    if (control.GetType() == typeof(Button))
                    {
                        Button button = control as Button;
                        button.Tag = null; button.Text = "----";
                        button.FlatAppearance.BorderSize = 0;
                    }
                }

                DefenseCBx.SelectedIndex = 0;
                MainPnl.Enabled = false;
                RefreshTeamPnl();

                TeamPnl.Visible = true;
                Text = Program.events[EventList.SelectedIndices[0]].name + " - MyScout 2016";
                Program.currentevent = EventList.SelectedIndices[0];
                RefreshControls();
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
                else if (konamicodeindex > 9) { konamicodeindex = 0; }
                else if (!konamicodeactivated && keyData == konamicodekeys[konamicodeindex])
                {
                    if (konamicodeindex < 9)
                    {
                        konamicodeindex++;
                    }
                    else
                    {
                        MessageBox.Show("Go play your Atari games you cheater.");
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
            }
            else
            {
                if (keyData == (Keys.Control | Keys.W))
                {
                    button1.PerformClick();
                }
                else if (keyData == (Keys.Control | Keys.S))
                {
                    button2.PerformClick();
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void DiedChkbx_CheckedChanged(object sender, EventArgs e)
        {
            //Enable/disable every control inside the "Died" groupbox
            RDDefenseLbl.Enabled = RDDefenseChkbx.Enabled = RDComments.Enabled = RDCommentsLbl.Enabled = RDDied.Checked;
        }

        private void TeleOpRB_CheckedChanged(object sender, EventArgs e)
        {
            TScaledTowerChkbx.Enabled = TChallengedTowerChkbx.Enabled = TeleOpRB.Checked;
        }

        private void ReachedRB_CheckedChanged(object sender, EventArgs e)
        {
            if (Program.selectedteam != -1)
            {
                //Set a whole lotta' things to the value of "ReachedRB.Checked."
                Program.events[Program.currentevent].teams[Program.selectedteam].defenses[DefenseCBx.SelectedIndex].reached
                = TimesCrossedLbl.Enabled = TimesCrossed.Enabled = button4.Enabled = ReachedRB.Checked;

                RefreshDefenseCrossedBtns();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DefenseCBx.SelectedIndex > 0) { DefenseCBx.SelectedIndex--; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DefenseCBx.SelectedIndex < DefenseCBx.Items.Count-1) { DefenseCBx.SelectedIndex++; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(TimesCrossed.Text) < 2)
            {
                TimesCrossed.Text = (Convert.ToInt32(TimesCrossed.Text) + 1).ToString();
                Program.events[Program.currentevent].teams[Program.selectedteam].defenses[DefenseCBx.SelectedIndex].timescrossed = Convert.ToInt32(TimesCrossed.Text);
                RefreshDefenseCrossedBtns();
            }
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.events.Count > Program.currentevent && MessageBox.Show("The current event has not yet been saved! Would you like to do so now?","MyScout 2016",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SaveEvent(Program.currentevent);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(TimesCrossed.Text) > 0)
            {
                TimesCrossed.Text = (Convert.ToInt32(TimesCrossed.Text) - 1).ToString();
                Program.events[Program.currentevent].teams[Program.selectedteam].defenses[DefenseCBx.SelectedIndex].timescrossed = Convert.ToInt32(TimesCrossed.Text);
                RefreshDefenseCrossedBtns();
            }
        }

        private void MainFrm_ResizeEnd(object sender, EventArgs e)
        {
            //Back Button Scaling
            BackBtnWidth = BackBtn.Width;
            FrmWidth = Width;
            BackBtnWidth = (float)Math.Round(FrmWidth * .06f);
            BackBtn.Width = (int)BackBtnWidth;
            BackBtnHeight = BackBtn.Height;
            FrmHeight = Height;
            BackBtnHeight = (float)Math.Round(FrmHeight * .1f);
            BackBtn.Height = (int)BackBtnHeight;

            //Robot Death Group Box Scaling
            RDGroupBxWidth = RDGroupBx.Width;
            FrmWidth = Width;
            RDGroupBxWidth = (float)Math.Round(FrmWidth * .23f);
            RDGroupBx.Width = (int)RDGroupBxWidth;
            RDGroupBxHeight = RDGroupBx.Height;
            FrmHeight = Height;
            RDGroupBxHeight = (float)Math.Round(FrmHeight * .50f);
            RDGroupBx.Height = (int)RDGroupBxHeight;

            //Human Player Group Box Scaling
            HPGroupBxWidth = HPGroupBx.Width;
            FrmWidth = Width;
            HPGroupBxWidth = (float)Math.Round(FrmWidth * .25);
            HPGroupBx.Width = (int)HPGroupBxWidth;
            FrmHeight = Height;
            HPGroupBxHeight = (float)Math.Round(FrmHeight * .25);
            HPGroupBx.Height = (int)HPGroupBxHeight;

            //Tele-op and Auto Group Box Scaling
            TGroupBxWidth = TGroupBx.Width;
            FrmWidth = Width;
            TGroupBxWidth = (float)Math.Round(FrmWidth * .5);
            TGroupBx.Width = (int)TGroupBxWidth;
            FrmHeight = Height;
            TGroupBxHeight = (float)Math.Round(FrmHeight * .83);
            TGroupBx.Height = (int)TGroupBxHeight;


        }

        #endregion

        private void TGroupBx_SizeChanged(object sender, EventArgs e)
        {
            //Defenses Group Box Scaling
            DefenseGBxWidth = DefenseGBx.Width;
            FrmWidth = Width;
            DefenseGBxWidth = (float)Math.Round(FrmWidth * .3);
            DefenseGBx.Width = (int)DefenseGBxWidth;
            FrmHeight = Height;
            DefenseGBxHeight = (float)Math.Round(FrmHeight * .5);
            DefenseGBx.Height = (int)DefenseGBxHeight;
        }

        private void DefenseCBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Program.events.Count > Program.currentevent && Program.events[Program.currentevent] != null)
            {
                RefreshTeamPnl();
            }
        }
    }
}
