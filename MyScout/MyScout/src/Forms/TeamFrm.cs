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
    public partial class TeamFrm : Form
    {
        public TeamFrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Occurs when a key is pressed anywhere within the form.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
           if (keyData == Keys.Delete)
           {
                RemoveTeamBtn.PerformClick();
                return true;
           }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void RemoveTeamBtn_Click(object sender, EventArgs e)
        {
            //
        }
    }
}
