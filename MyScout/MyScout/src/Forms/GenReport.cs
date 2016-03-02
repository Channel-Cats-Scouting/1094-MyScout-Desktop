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
    public partial class GenReport : Form
    {
        public GenReport()
        {
            InitializeComponent();

            //Prepare component values
            totalScoreRB.Checked = true;
            reportTypeCB.SelectedIndex = 0;
            roundNumLabel.Enabled = roundNumUpDown.Enabled = false;
        }

        private void reportTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(reportTypeCB.SelectedIndex == 0)
            {
                roundNumLabel.Enabled = roundNumUpDown.Enabled = false;
            }
            else roundNumLabel.Enabled = roundNumUpDown.Enabled = true;
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
            return roundNumUpDown.Enabled ? (int)roundNumUpDown.Value : -1;
        }

        public bool GetIsEventReport()
        {
            return reportTypeCB.SelectedIndex == 0 ? true : false;
        }
    }
}
