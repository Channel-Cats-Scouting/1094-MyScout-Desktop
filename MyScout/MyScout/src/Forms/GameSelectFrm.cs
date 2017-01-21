using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyScout
{
    public partial class GameSelectFrm : Form
    {
        private string[] filePaths;
        public GameSelectFrm()
        {
            InitializeComponent();

            //Get all the raw paths
            string dir = Path.Combine(Program.StartupPath, "Datasets");
            filePaths = Directory.GetFiles(dir);

            //Add cleaned-up items to the box
            for (int i = 0; i < filePaths.Length; ++i)
            {
                gameListBox.Items.Add(new FileInfo(filePaths[i]).Name);
            }

            if (gameListBox.Items.Count > 0) gameListBox.SelectedIndex = 0;
            if (filePaths.Length > 0)
            {
                string[] nameanddesc = IO.GetNameAndDescFromDataset(filePaths[0]);
                fullNameLabel.Text = nameanddesc[0];
                fullDescLabel.Text = nameanddesc[1];
            }
            else fullNameLabel.Text = fullDescLabel.Text = "";

            acceptBtn.Enabled = (filePaths.Length > 0);
        }

        private void gameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gameListBox.SelectedIndex != -1)
            {
                string[] nameanddesc = IO.GetNameAndDescFromDataset(filePaths[gameListBox.SelectedIndex]);
                fullNameLabel.Text = nameanddesc[0];
                fullDescLabel.Text = nameanddesc[1];
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            if (filePaths == null || filePaths.Length <= gameListBox.SelectedIndex) return;
            List<List<DataPoint>> newDataset = IO.LoadDatasetFromPath(filePaths[gameListBox.SelectedIndex]);

            if (newDataset != null)
            {
                Program.DataSet = newDataset;
                Program.DataSetName = IO.GetNameAndDescFromDataset(filePaths[gameListBox.SelectedIndex])[0];
                DialogResult = DialogResult.OK;
            }
            else
                DialogResult = DialogResult.Abort;

            Close();
        }

        private void gameListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            acceptBtn_Click(sender, e);
        }
    }
}