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
    public partial class PrescoutFrm : Form
    {
        private Team selectedTeam;

        public PrescoutFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TeamFrm teamform = new TeamFrm(panel1);
            teamform.ShowDialog();

            if(teamform.DialogResult == DialogResult.OK)
            {
                selectedTeam = Program.events[Program.currentevent].teams[teamform.GetSelectedTeamIndex()];
                button1.Text = selectedTeam.id.ToString() + "\n" + selectedTeam.name;
                LoadDefenses(selectedTeam);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            SaveDefenses(selectedTeam);
            Close();
        }

        public void LoadDefenses(Team team)
        {
            portcullisCheckBox.Checked = team.defensesCrossable[0];
            tippyRampCheckBox.Checked = team.defensesCrossable[1];
            moatCheckBox.Checked = team.defensesCrossable[2];
            rampartCheckBox.Checked = team.defensesCrossable[3];
            drawbridgeCheckBox.Checked = team.defensesCrossable[4];
            sallyPortCheckBox.Checked = team.defensesCrossable[5];
            rockWallCheckBox.Checked = team.defensesCrossable[6];
            roughTerrainCheckBox.Checked = team.defensesCrossable[7];
            lowBarCheckBox.Checked = team.defensesCrossable[8];
        }

        public void SaveDefenses(Team team)
        {
            team.defensesCrossable[0] = portcullisCheckBox.Checked;
            team.defensesCrossable[1] = tippyRampCheckBox.Checked;
            team.defensesCrossable[2] = moatCheckBox.Checked;
            team.defensesCrossable[3] = rampartCheckBox.Checked;
            team.defensesCrossable[4] = drawbridgeCheckBox.Checked;
            team.defensesCrossable[5] = sallyPortCheckBox.Checked;
            team.defensesCrossable[6] = rockWallCheckBox.Checked;
            team.defensesCrossable[7] = roughTerrainCheckBox.Checked;
            team.defensesCrossable[8] = lowBarCheckBox.Checked;
        }
    }
}
