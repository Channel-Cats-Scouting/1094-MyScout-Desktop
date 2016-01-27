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
    public partial class AddDataFrm : Form
    {
        public enum Data
        {
            Event,
            Team
        }

        public AddDataFrm(Data Datatoadd)
        {
            InitializeComponent();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OkBtn.Enabled = !string.IsNullOrEmpty(textBox1.Text);
        }

        private void textBox2_KeyPressed(object sender, KeyPressEventArgs e)
        {
            //VAR = textnew
            string TextAddition = textBox2.Text;
            TextBox DB = (TextBox)sender;
            char back = (char)Keys.Back;
            string[] DBA = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "/", "\\", "-", back.ToString(), "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};

            if (!DBA.Contains<string>(e.KeyChar.ToString()))
            {
                // die useless chars
                //DB.Text = DB.Text.Remove(DB.Text.IndexOf(DB.Text[DB.Text.Length-1].ToString(),1));
                e.Handled = true;
            }
            
        }
    }
}
