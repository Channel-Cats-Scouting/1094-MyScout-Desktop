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
        bool applytomemory = true;

        public TeamFrm(bool applytomemory = true)
        {
            InitializeComponent();
            RefreshTeamList();
            this.applytomemory = applytomemory;
        }

        /// <summary>
        /// Makes sure the contents of the GUI team list are up to date
        /// with the contents of the actual list of teams.
        /// </summary>
        private void RefreshTeamList()
        {
            TeamList.Items.Clear();
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
                Program.events[Program.currentevent].teams.Add(new Team(Convert.ToInt32(adddata.textBox1.Text),adddata.textBox2.Text));
                RefreshTeamList();
            }
        }

        /// <summary>
        /// Occurs when the "Edit Team" button "clicked."
        /// </summary>
        private void EditTeamBtn_Click(object sender, EventArgs e)
        {
            if (TeamList.SelectedIndices.Count > 0)
            {
                AddDataFrm adddata = new AddDataFrm(AddDataFrm.Data.Team);
                adddata.textBox1.Text = Program.events[Program.currentevent].teams[TeamList.SelectedIndices[0]].id.ToString();
                adddata.textBox2.Text = Program.events[Program.currentevent].teams[TeamList.SelectedIndices[0]].name;

                if (adddata.ShowDialog() == DialogResult.OK)
                {
                    Program.events[Program.currentevent].teams[TeamList.SelectedIndices[0]].id = Convert.ToInt32(adddata.textBox1.Text);
                    Program.events[Program.currentevent].teams[TeamList.SelectedIndices[0]].name = adddata.textBox2.Text;
                    RefreshTeamList();
                }
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
        /// Occurs when a value on the teamlist is double-clicked.
        /// </summary>
        private void TeamList_DoubleClick(object sender, EventArgs e)
        {
            if (TeamList.SelectedItems.Count > 0 || (!string.IsNullOrEmpty(textBox1.Text) && TeamList.Items.Count > 0))
            {
                int selectedteam = GetSelectedTeamIndex();

                if (applytomemory)
                {
                    bool IsDuplicate = false;

                    foreach (Control control in Program.mainfrm.AllianceBtnPnl.Controls)
                    {
                        //If the control is a button...
                        if (control.GetType() == typeof(Button))
                        {
                            Button button = control as Button;
                            if (button != null && button.Tag != null && (int)button.Tag == selectedteam) { IsDuplicate = true; break; }
                        }
                    }

                    if (!IsDuplicate || MessageBox.Show($"Team { Program.events[Program.currentevent].teams[selectedteam].id } is already part of this round! Would you like to add it anyway?", "MyScout 2016", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        Program.selectedteam = selectedteam;
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
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
            else if (keyData == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    TeamList_DoubleClick(this, new EventArgs());
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                RefreshTeamList();
                AcceptButton = AddTeamBtn;
            }
            else
            {
                AcceptButton = SelectTeamButton;
                TeamList.Items.Clear();
                for (int i = 0; i < Program.events[Program.currentevent].teams.Count; i++)
                {
                    Team team = Program.events[Program.currentevent].teams[i];
                    if (team.name.ToUpper().Contains(textBox1.Text.ToUpper()) || team.id.ToString().Contains(textBox1.Text))
                    {
                        TeamList.Items.Add(new ListViewItem(new string[] { team.id.ToString(), team.name }) { Tag = i });
                    }
                }
            }
        }

        public int GetSelectedTeamIndex()
        {
            return (string.IsNullOrEmpty(textBox1.Text)) ? TeamList.SelectedIndices[0] : (TeamList.SelectedItems.Count > 0) ? (int)TeamList.SelectedItems[0].Tag : (int)TeamList.Items[0].Tag; ;
        }

        private void SelectTeamButton_Click(object sender, EventArgs e)
        {
            TeamList_DoubleClick(sender, e);
        }
    }
}
