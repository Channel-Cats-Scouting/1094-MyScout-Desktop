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
    public partial class Bubble : Form
    {
        Timer timer = new Timer();

        public Bubble()
        {
            InitializeComponent();

            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Location = new Point(MainFrm.rnd.Next(Screen.PrimaryScreen.Bounds.Width), MainFrm.rnd.Next(Screen.PrimaryScreen.Bounds.Height));
        }
    }
}
