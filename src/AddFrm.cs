using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2016Scoring
{
    public partial class AddFrm : Form
    {
        public Type thingtoadd;

        public enum Type
        {
            Team,Event
        }

        public AddFrm()
        {
            InitializeComponent();
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

        private void Control_TextChanged(object sender, EventArgs e)
        {
            OkBtn.Enabled = (!string.IsNullOrEmpty(NumberTBx.Text) && ((thingtoadd == Type.Event) || (Convert.ToInt32(NumberTBx.Text) <= 9999 && Convert.ToInt32(NumberTBx.Text) >= 0 && !string.IsNullOrEmpty(NameTbx.Text))));
        }

        private void NumberBx_KeyDown(object sender, KeyEventArgs e)
        {
            //OkBtn.Enabled = (!string.IsNullOrEmpty(NumberTBx.Text) && Convert.ToInt32(NumberTBx.Text) <= 9999 && Convert.ToInt32(NumberTBx.Text) >= 0 && !string.IsNullOrEmpty(NameTbx.Text));
        }

        private void TeamFrm_Load(object sender, EventArgs e)
        {
            NameTbx.Select();
        }

        private void NumberBx_Enter(object sender, EventArgs e)
        {
            NumberTBx.Text = "";
        }

        private void NumberTBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (thingtoadd == Type.Team && !(NumberTBx.Text.Length < 4 && char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = errorLbl.Visible = true;
            }
            else { errorLbl.Visible = false; }
        }
    }
}
