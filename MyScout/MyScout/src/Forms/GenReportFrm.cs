using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyScout
{
    public partial class GenReportFrm : Form
    {
        public GenReportFrm()
        {
            InitializeComponent();
        }

        #region variables

        /// <summary>
        /// The currently selected team, for generating team reports
        /// </summary>
        public int selectedTeam;

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            IO.SaveDataToTeams();
            DialogResult = DialogResult.OK;
            Close();
        }

        public bool GetIsPrescout()
        {
            return reportTypeCB.SelectedIndex == 2;
        }

        public bool GetIsEventReport()
        {
            return reportTypeCB.SelectedIndex == 0;
        }

        public int GetSelectedTeam()
        {
            return selectedTeam;
        }

        private void reportTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void totalScoreRB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void autoScoreRB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }

        private void removeButton_Click(object sender, EventArgs e)
        {

        }

        private void GenReport_Load(object sender, EventArgs e)
        {
            dataListBox.Items.Clear();
            for(int i = 0; i < Program.DataSet[2].Count; i++)
            {
                dataListBox.Items.Add(Program.DataSet[2][i].GetName());
            }
        }

        private void dataListBox_Enter(object sender, EventArgs e)
        {
            AddBtn.Select();
        }

        private void dataListBox_Leave(object sender, EventArgs e)
        {
            GenBtn.Select();
        }

        private void GenBtn_Click(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            outListBox.Items.Add(dataListBox.SelectedItem);
        }
    }
}