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
    }
}
