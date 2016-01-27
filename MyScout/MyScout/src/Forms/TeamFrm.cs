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
    public partial class TeamFrm : Form
    {
        public TeamFrm()
        {
            InitializeComponent();
            RefreshTeamList();
        }

        /// <summary>
        /// Makes sure the contents of the GUI team list are up to date
        /// with the contents of the actual list of teams.
        /// </summary>
        private void RefreshTeamList()
        {
            TeamList.Clear();
            foreach (Team t in Program.events[Program.currentevent].teams)
            {
                TeamList.Items.Add(new ListViewItem(new string[] { t.id.ToString(), t.name }));
            }
        }

        #region GUI Events
        /// <summary>
        /// Occurs when the "Add Team" button is "clicked."
        /// </summary>
        private void AddTeamBtn_Click(object sender, EventArgs e)
        {
            AddDataFrm adddata = new AddDataFrm(AddDataFrm.Data.Team);
            if (adddata.ShowDialog() == DialogResult.OK)
            {
                //Program.events[Program.currentevent].teams.Add(new Team(adddata.textBox1.Text));
            }
        }

        /// <summary>
        /// Occurs when the "Remove Team" button is "clicked."
        /// </summary>
        private void RemoveTeamBtn_Click(object sender, EventArgs e)
        {
            if (TeamList.SelectedItems.Count > 0 && MessageBox.Show("Are you SURE you want to remove the selected team?", "MyScout 2016", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Program.events[Program.currentevent].teams.RemoveAt(TeamList.SelectedIndices[0]);
                RefreshTeamList();
            }
        }

        /// <summary>
        /// Occurs when a key is pressed anywhere within the form.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Delete)
            {
                RemoveTeamBtn.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
    }
}
