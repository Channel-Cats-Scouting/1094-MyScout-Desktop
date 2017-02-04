using System;
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
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public string getPromptText()
        {
            return promptTextBox.Text;
        }
    }
}
