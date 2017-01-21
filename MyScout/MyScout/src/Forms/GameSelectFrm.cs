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
        string[] filepaths;
        public GameSelectFrm()
        {
            InitializeComponent();

            //Get all the raw paths
            filepaths = Directory.GetFiles(Program.StartupPath + "\\Datasets");
            for(int i = 0; i < filepaths.Length; i++)
            {
                //Add cleaned-up items to the box
                gameListBox.Items.Add(filepaths[i].Replace((Program.StartupPath + "\\Datasets\\"), ""));
            }
            gameListBox.SelectedIndex = 0;
            fullDescLabel.MaximumSize = new Size(200, 0);
            string[] nameanddesc = IO.GetNameAndDescFromDataset(filepaths[0]);
            fullNameLabel.Text = nameanddesc[0];
            fullDescLabel.Text = nameanddesc[1];
            AcceptButton = acceptBtn;
        }

        private void gameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(gameListBox.SelectedIndex != -1)
            {
                string[] nameanddesc = IO.GetNameAndDescFromDataset(filepaths[gameListBox.SelectedIndex]);
                fullNameLabel.Text = nameanddesc[0];
                fullDescLabel.Text = nameanddesc[1];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
            Dispose();
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            List<List<DataPoint>> newDataset = IO.LoadDatasetFromPath(filepaths[gameListBox.SelectedIndex]);
            if (newDataset != null)
            {
                Program.DataSet = newDataset;
                Program.DataSetName = IO.GetNameAndDescFromDataset(filepaths[gameListBox.SelectedIndex])[0];
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Abort;
            }
            Close();
            Dispose();
        }

        private void gameListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            acceptBtn_Click(sender, e);
        }
    }
}
