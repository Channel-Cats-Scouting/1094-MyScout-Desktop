using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2016Scoring
{
    public partial class MainFrm : Form
    {
        public static List<Event> events = new List<Event>();
        public static int currentevent = 0;

        public MainFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add a Team
            AddFrm tf = new AddFrm();
            tf.thingtoadd = AddFrm.Type.Team;
            tf.ShowDialog();

            if (tf.DialogResult == DialogResult.OK)
            {
                Team team = new Team(tf.NameTbx.Text, Convert.ToInt32(tf.NumberTBx.Text));
                events[currentevent].Teams.Add(team);

                ListViewItem item = new ListViewItem(new string[] { team.name, team.number.ToString() }) { Tag = events[currentevent].Teams.Count-1 };
                TeamList.Items.Add(item);
                TeamList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                TeamList.Items[TeamList.Items.Count - 1].Selected = true;
            }
            UpdateText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TeamList.SelectedItems.Count > 0 && MessageBox.Show($"WARNING: Are you sure you wish to remove the \"{TeamList.SelectedItems[0].Text}\" team?","First Stronghold Scoring",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                events[currentevent].Teams.RemoveAt(TeamList.SelectedItems[0].Index);
                TeamList.Items.Remove(TeamList.SelectedItems[0]);
                TeamList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            UpdateText();
        }

        private void TeamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RmTeamBtn.Enabled = (TeamList.SelectedItems.Count > 0);
            ScoringPnl.Visible = RmTeamBtn.Enabled;

            if (RmTeamBtn.Enabled)
            {
                TeamnmLbl.Text = $"{events[currentevent].Teams[(int)TeamList.SelectedItems[0].Tag].name} ({events[currentevent].Teams[(int)TeamList.SelectedItems[0].Tag].number.ToString()})";
            }
        }

        private void UpdateText()
        {
            AddaTeamLbl.Text = (TeamList.Items.Count <= 0) ? "Add a Team to Begin" : "Select a Team to Begin";
        }

        private void TeamnmLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddFrm teamfrm = new AddFrm();
            teamfrm.ShowDialog();

            if (teamfrm.DialogResult == DialogResult.OK)
            {
                events[currentevent].Teams[(int)TeamList.SelectedItems[0].Tag].name = teamfrm.NameTbx.Text;
                events[currentevent].Teams[(int)TeamList.SelectedItems[0].Tag].number = Convert.ToInt32(teamfrm.NumberTBx.Text);
                TeamnmLbl.Text = $"{events[currentevent].Teams[(int)TeamList.SelectedItems[0].Tag].name} ({events[currentevent].Teams[(int)TeamList.SelectedItems[0].Tag].number.ToString()})";

                TeamList.SelectedItems[0].SubItems[0] = new ListViewItem.ListViewSubItem(TeamList.SelectedItems[0],teamfrm.NameTbx.Text);
                TeamList.SelectedItems[0].SubItems[1] = new ListViewItem.ListViewSubItem(TeamList.SelectedItems[0], teamfrm.NumberTBx.Text);
                TeamList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        private void AddEventBtn_Click(object sender, EventArgs e)
        {
            AddFrm teamfrm = new AddFrm();
            teamfrm.thingtoadd = AddFrm.Type.Event;
            teamfrm.Text = "Add a Event";
            teamfrm.label1.Text = "&Event Name:";
            teamfrm.label2.Text = "&Event Date:";
            teamfrm.NumberTBx.Text = $"{DateTime.Now.Month.ToString()}/{DateTime.Now.Day.ToString()}/{DateTime.Now.Year.ToString()}";
            teamfrm.ShowDialog();

            if (teamfrm.DialogResult == DialogResult.OK)
            {
                events.Add(new Event(teamfrm.NameTbx.Text,teamfrm.NumberTBx.Text));
                eventList.Items.Add(new ListViewItem(new string[] { teamfrm.NameTbx.Text, teamfrm.NumberTBx.Text }));
                eventList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void eventList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EventPnl.Visible = false;
            currentevent = eventList.SelectedItems[0].Index;
            eventLbl.Text = events[currentevent].name;

            TeamList.Items.Clear();

            foreach (Team team in events[currentevent].Teams)
            {
                ListViewItem item = new ListViewItem(new string[] { team.name, team.number.ToString() }) { Tag = events[currentevent].Teams.Count - 1 };
                TeamList.Items.Add(item);
            }

            AddTeamBtn.Enabled = RmTeamBtn.Enabled = true;
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            EventPnl.Visible = true;
            TeamList.Items.Clear();
            AddTeamBtn.Enabled = RmTeamBtn.Enabled = false;
            ScoringPnl.Visible = true;
            AddaTeamLbl.Text = (events[currentevent].Teams.Count > 0)?"Select":"Add"+" a Team to Begin";
        }

        private void RmEventBtn_Click(object sender, EventArgs e)
        {
            if (eventList.SelectedItems.Count > 0)
            {
                eventList.Items[currentevent].Remove();
                events.RemoveAt(currentevent);
            }
        }
    }
}
