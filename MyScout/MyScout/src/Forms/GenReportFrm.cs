using System;
using System.Windows.Forms;

namespace MyScout
{
    public partial class GenReport : Form
    {
        public int teamid;
        public int teamindex;

        public GenReport()
        {
            InitializeComponent();
            roundNumUpDown.Maximum = Program.events[Program.currentevent].rounds.Count;

            //Prepare component values
            totalScoreRB.Checked = true;
            reportTypeCB.SelectedIndex = 0;
            roundNumLabel.Enabled = roundNumUpDown.Enabled = false;
            button2.Enabled = false;
        }

        private void reportTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (reportTypeCB.SelectedIndex == 0)
            {
                roundNumLabel.Enabled = roundNumUpDown.Enabled = false;
                button2.Enabled = false;
                totalScoreRB.Enabled = autoScoreRB.Enabled = crossScoreRB.Enabled = true;
            }
            else if (reportTypeCB.SelectedIndex == 1)
            {
                roundNumLabel.Enabled = roundNumUpDown.Enabled = true;
                button2.Enabled = false;
                totalScoreRB.Enabled = autoScoreRB.Enabled = crossScoreRB.Enabled = false;
            }
            else if(reportTypeCB.SelectedIndex == 2)
            {
                roundNumLabel.Enabled = roundNumUpDown.Enabled = false;
                button2.Enabled = true;
                totalScoreRB.Enabled = autoScoreRB.Enabled = crossScoreRB.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        public int GetSorting()
        {
            return totalScoreRB.Checked ? 0 : autoScoreRB.Checked ? 1 : crossScoreRB.Checked ? 2 : -1;
        }

        public int GetRoundID()
        {
            return roundNumUpDown.Enabled ? (int)roundNumUpDown.Value-1 : -1;
        }

        public bool GetIsPrescout()
        {
            return reportTypeCB.SelectedIndex == 2;
        }

        public bool GetIsEventReport()
        {
            return reportTypeCB.SelectedIndex == 0 ? true : false;
        }

        public int GetTeamID()
        {
            return teamid;
        }

        public int GetTeamIndex()
        {
            return teamindex;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TeamFrm teamform = new TeamFrm(false);
            teamform.ShowDialog();
            if(teamform.DialogResult == DialogResult.OK)
            {
                button2.Text = "Team: " + Program.events[Program.currentevent].teams[teamform.GetSelectedTeamIndex()].id.ToString();
                teamid = Program.events[Program.currentevent].teams[teamform.GetSelectedTeamIndex()].id;
                teamindex = teamform.GetSelectedTeamIndex();
            }
        }
    }
}