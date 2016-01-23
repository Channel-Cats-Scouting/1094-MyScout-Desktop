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
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Makes sure the contents of the GUI event list are up to date
        /// with the contents of the actual list of events.
        /// </summary>
        private void RefreshEventList()
        {
            EventList.Items.Clear();
            foreach (Event e in Program.events)
            {
                EventList.Items.Add(new ListViewItem(new string[] { e.name, e.begindate, e.enddate }));
            }
        }

        /// <summary>
        /// Makes sure the only controls that are enabled are the ones you can currently see.
        /// </summary>
        private void RefreshControls()
        {
            EventList.Enabled = AddEventBtn.Enabled = RemoveEventBtn.Enabled = EditEventBtn.Enabled = !TeamPnl.Visible;
        }

        #region GUI Events
        /// <summary>
        /// Occurs when the "Add Event" button is "clicked."
        /// </summary>
        private void AddEventBtn_Click(object sender, EventArgs e)
        {
            Program.events.Add(new Event("Chaifetz Arena", $"{DateTime.Now.Month.ToString()}/{DateTime.Now.Day.ToString()}/{DateTime.Now.Year.ToString()}", $"{DateTime.Now.Month.ToString()}/{DateTime.Now.Day.ToString()}/{DateTime.Now.Year.ToString()}"));
            RefreshEventList();
        }

        /// <summary>
        /// Occurs when an item on the event list is double-clicked.
        /// </summary>
        private void EventList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TeamPnl.Visible = true;
            RefreshControls();
        }

        private void RemoveEventBtn_Click(object sender, EventArgs e)
        {
            if (EventList.SelectedItems.Count > 0 && MessageBox.Show("Are you SURE you want to remove the selected event?","MyScout 2016",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Program.events.RemoveAt(EventList.SelectedIndices[0]);
                RefreshEventList();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!TeamPnl.Visible)
            {
                if (keyData == Keys.Delete)
                {
                    RemoveEventBtn.PerformClick();
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        private void BackBtn_Click(object sender, EventArgs e)
        {
            TeamPnl.Visible = false;
            RefreshControls();
        }
    }
}
