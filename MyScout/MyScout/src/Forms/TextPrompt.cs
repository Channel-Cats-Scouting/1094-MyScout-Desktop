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
    public partial class TextPrompt : Form
    {
        public TextPrompt(string promptLbl)
        {
            InitializeComponent();
            this.promptLbl.Text = promptLbl;
            AcceptButton = confirmBtn;
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public string getPromptText()
        {
            return promptTextBox.Text;
        }
    }
}
