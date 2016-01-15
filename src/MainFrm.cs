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
        /// <summary>
        /// The list of Teams
        /// </summary>
        public static List<Team> Teams = new List<Team>();

        public MainFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add a Team
            TeamFrm tf = new TeamFrm();
            tf.ShowDialog();

            if (tf.DialogResult == DialogResult.OK)
            {
                Team team = new Team(tf.NameTbx.Text, Convert.ToInt32(tf.NumberTBx.Text));
                Teams.Add(team);

                ListViewItem item = new ListViewItem(new string[] { team.name, team.number.ToString() }) { Tag = Teams.Count-1 };
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
                TeamList.Items.Remove(TeamList.SelectedItems[0]);
                TeamList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            UpdateText();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RmTeamBtn.Enabled = (TeamList.SelectedItems.Count > 0);
            ScoringPnl.Visible = RmTeamBtn.Enabled;

            if (RmTeamBtn.Enabled)
            {
                TeamnmLbl.Text = $"{Teams[(int)TeamList.SelectedItems[0].Tag].name} ({Teams[(int)TeamList.SelectedItems[0].Tag].number.ToString()})";
            }
        }

        private void UpdateText()
        {
            AddaTeamLbl.Text = (TeamList.Items.Count <= 0) ? "Add a Team to Begin" : "Select a Team to Begin";
        }

        private void TeamnmLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new TeamFrm().ShowDialog();
        }
    }
}
