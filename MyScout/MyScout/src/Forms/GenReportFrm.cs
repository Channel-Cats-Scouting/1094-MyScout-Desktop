using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyScout
{
    public partial class GenReport : Form
    {
        public int teamid;
        public int teamindex;

        /// <summary>
        /// A list of indexed Strings, containing all data point names in order
        /// </summary>
        public List<StringEntry> datalist = new List<StringEntry>();
        public List<string> dataStrings = new List<string>();
        public List<string> outStrings = new List<string>();

        /// <summary>
        /// A list of indices of each data point. The index of each int is the index of a corresponding String in dataStrings. 
        /// The value of each int is the index of a corresponding StringEntry in datalist.
        /// </summary>
        public List<int> dataIndices = new List<int>();


        /// <summary>
        /// A list of indices of each data point. The index of each int is the index of a corresponding String in outStrings. 
        /// The value of each int is the index of a corresponding StringEntry in datalist.
        /// </summary>
        public List<int> outIndices = new List<int>();

        public GenReport()
        {
            InitializeComponent();
            //For each type of scouting (pre/round)
            for(int i = 0; i < 2; i++)
                //For each data point in said type of scouting
                for(int j = 0; j < Program.DataSet[i].Count; j++)
                {
                    /*
                    * Add a new StringEntry with the data point's name and a generated index.
                    * Prescouting indices are the same, but round scouting indices are added to the end, 
                    * so they are a sequential list of indices.
                    */
                    datalist.Add(new StringEntry(Program.DataSet[i][j].GetName(), j + (i > 0 ? Program.DataSet[0].Count : 0)));
                }
            button2.Enabled = false;
            SyncStrings();
        }

        /// <summary>
        /// Reassigns strings based on 'Selected' StringEntry objects
        /// </summary>
        public void SyncStrings()
        {
            dataStrings = new List<string>();
            outStrings = new List<string>();

            for (int i = 0; i < datalist.Count; i++)
            {
                //If the StringEntry is not selected
                if(!datalist[i].getIsSelected())
                {
                    //Add the string to the dataListBox representative list and remember its index
                    dataStrings.Add(datalist[i].str);
                    dataIndices.Add(datalist[i].index);
                }
                else
                {
                    //Add the string to the outListBox representative list and remember its index
                    outStrings.Add(datalist[i].str);
                    outIndices.Add(datalist[i].index);
                }
            }

            dataListBox.Items.Clear();
            outListBox.Items.Clear();

            dataListBox.Items.AddRange(dataStrings.ToArray());
            outListBox.Items.AddRange(outStrings.ToArray());
        }

        /// <summary>
        /// Gets the index for a given string. Returns -1 if no string found.
        /// </summary>
        /// <param name="regex"></param>
        /// <returns></returns>
        private int findStringIndex(string regex)
        {
            int index = -1;
            foreach(StringEntry stren in datalist)
            {
                if(stren.str == regex)
                {
                    index = stren.index;
                }
            }
            return index;
        }

        private void reportTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

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
                button2.Text = "Team: " + Program.Events[Program.CurrentEventIndex].teams[teamform.GetSelectedTeamIndex()].id.ToString();
                teamid = Program.Events[Program.CurrentEventIndex].teams[teamform.GetSelectedTeamIndex()].id;
                teamindex = teamform.GetSelectedTeamIndex();
            }
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
            if(dataListBox.SelectedIndex != -1)
            {
                datalist[findStringIndex((string)dataListBox.SelectedItem)].setIsSelected(true);
                SyncStrings();
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (outListBox.SelectedIndex != -1)
            {
                datalist[findStringIndex((string)dataListBox.SelectedItem)].setIsSelected(false);
                SyncStrings();
            }
        }

        private void GenReport_Load(object sender, EventArgs e)
        {

        }
    }
}