using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public MainFrm()
        {
            InitializeComponent();
            DefenseCBx.SelectedIndex = 0;
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
        }

        private void RefreshTeamPnl()
        {
            if (Program.selectedteam != -1)
            {
                TeamNameLbl.Text = $"{Program.events[Program.currentevent].teams[Program.selectedteam].name} - {Program.events[Program.currentevent].teams[Program.selectedteam].id.ToString()}";
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
                    RefreshTeamPnl();
                }
            }
            else
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
                RefreshTeamPnl();
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
            TeamPnl.Visible = true;
            Text = Program.events[EventList.SelectedIndices[0]].name + " - MyScout 2016";
            RefreshControls();
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
                            bubbles[i].Location = new Point(rnd.Next(Screen.PrimaryScreen.Bounds.Width),rnd.Next(Screen.PrimaryScreen.Bounds.Height));
                            bubbles[i].Show();
                        }
                    }
                }
            }
            else
            {
                if (keyData == Keys.W)
                {
                    button1.PerformClick();
                }
                else if (keyData == Keys.S)
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
            TimesCrossedLbl.Enabled = TimesCrossed.Enabled = button3.Enabled = button4.Enabled = ReachedRB.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DefenseCBx.SelectedIndex > 0) { DefenseCBx.SelectedIndex--; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DefenseCBx.SelectedIndex < DefenseCBx.Items.Count-1) { DefenseCBx.SelectedIndex++; }
        }
        #endregion

        private void button4_Click(object sender, EventArgs e)
        {
            TimesCrossed.Text = (Convert.ToInt32(TimesCrossed.Text)+1).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(TimesCrossed.Text) > 0) { TimesCrossed.Text = (Convert.ToInt32(TimesCrossed.Text) - 1).ToString(); }
        }
    }
}
