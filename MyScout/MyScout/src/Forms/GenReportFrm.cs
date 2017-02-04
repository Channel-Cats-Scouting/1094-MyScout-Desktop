﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Text;

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

        private void dataListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddBtn.Select();
        }

        private void GenReport_Load(object sender, EventArgs e)
        {
            dataListBox.Items.Clear();
            for (int i = 0; i < Program.DataSet[2].Count; i++)
            {
                dataListBox.Items.Add(Program.DataSet[2][i].GetName());
            }
            for (int i = 0; i < Program.DataSet[0].Count; i++)
            {
                dataListBox.Items.Add(Program.DataSet[0][i].GetName());
            }
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
            if (dataListBox.SelectedIndex != -1)
            {
                outListBox.Items.Add(dataListBox.SelectedItem);
            }
        }

        private void MoveUpBtn_Click(object sender, EventArgs e)
        {
            if (outListBox.SelectedIndex > 0)
            {
                object backup = outListBox.Items[outListBox.SelectedIndex - 1];
                outListBox.Items[outListBox.SelectedIndex - 1] = outListBox.SelectedItem;
                outListBox.Items[outListBox.SelectedIndex] = backup;
                outListBox.SelectedIndex--;
            }
        }

        private void MoveDownBtn_Click(object sender, EventArgs e)
        {
            if (outListBox.SelectedIndex != outListBox.Items.Count - 1)
            {
                object backup = outListBox.Items[outListBox.SelectedIndex + 1];
                outListBox.Items[outListBox.SelectedIndex + 1] = outListBox.SelectedItem;
                outListBox.Items[outListBox.SelectedIndex] = backup;
                outListBox.SelectedIndex++;
            }
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (outListBox.SelectedIndex != -1)
            {
                outListBox.Items.RemoveAt(outListBox.SelectedIndex);
            }
        }

        private void AddAllBtn_Click(object sender, EventArgs e)
        {
            outListBox.Items.AddRange(dataListBox.Items);
        }

        private void RemoveAllBtn_Click(object sender, EventArgs e)
        {
            outListBox.Items.Clear();
        }

        private void clearDuplicatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < outListBox.Items.Count; i++)
            {
                for (int i2 = 0; i2 < outListBox.Items.Count; i2++)
                {
                    if (i != i2 && ((string)outListBox.Items[i]).Equals((string)outListBox.Items[i2]))
                    {
                        outListBox.Items.RemoveAt(i2);
                        i2--;
                    }
                }
            }
        }

        private void saveReportBtn_Click(object sender, EventArgs e)
        {
            TextPrompt prompt = new TextPrompt("Please enter the name of this profile");
            if(prompt.ShowDialog() == DialogResult.OK)
            {
                string name = prompt.getPromptText();
                IO.SaveReportProfile(outListBox, name);
            }
        }

        private void loadReportBtn_Click(object sender, EventArgs e)
        {
            outListBox.Items.Clear();
            List<string> items = IO.LoadReportProfile(Convert.ToInt16(Program.CurrentEventIndex));
            for (int i = 0; i < items.Count; i++)
            {
                outListBox.Items.Add(items[i]);
            }
        }
    }
}