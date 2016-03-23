using System;
using System.Linq;
using System.Windows.Forms;

namespace MyScout
{
    public partial class AddDataFrm : Form
    {
        private Data Datatoadd;

        public enum Data
        {
            Event,
            Team
        }

        public AddDataFrm(Data Datatoadd)
        {
            InitializeComponent();
            this.Datatoadd = Datatoadd;

            if (Datatoadd == Data.Event)
            {
                textBox2.Text = textBox3.Text = $"{DateTime.Now.Month.ToString()}/{DateTime.Now.Day.ToString()}/{DateTime.Now.Year.ToString()}";
            }
            else
            {
                Lbl1.Text = "&ID";
                Lbl2.Text = "&Name";
                Lbl3.Dispose();
                textBox3.Dispose();

                Height = 177;
                Text = "Add Team";
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            OkBtn.Enabled = !string.IsNullOrEmpty(textBox1.Text) && (Datatoadd == Data.Team || !string.IsNullOrEmpty(textBox2.Text)) && (Datatoadd == Data.Team || !string.IsNullOrEmpty(textBox3.Text));
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Get the textBox that called the event
            TextBox DB = (TextBox)sender;
            //The list of characters that can be typed into the given textBox.
            char[] DBA = new char[] { };

            if (Datatoadd == Data.Event && sender != textBox1) { DBA = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', (char)Keys.Back, ' ', '/', '\\', '-' }; }
            else { DBA = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', (char)Keys.Back }; }

            if (((Datatoadd == Data.Event && sender != textBox1) || (Datatoadd == Data.Team && sender == textBox1)) && (!DBA.Contains(e.KeyChar)))
            {
                //DIE useless chars!!!
                e.Handled = true;
            }
        }
    }
}
