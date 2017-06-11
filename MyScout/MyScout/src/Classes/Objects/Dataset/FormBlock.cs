using System;
using System.Windows.Forms;
using System.Drawing;

namespace MyScout
{
    class FormBlock
    {

        /// <summary>
        /// The pixel offset of the FormBlock controls from the top-left corner
        /// </summary>
        private int xOffset = 0, yOffset = 0;
        private Control[] controls;
        private bool isAuto;

        public FormBlock(Array text, Control[] controls)
        {
            this.controls = controls;
        }

        public FormBlock(string text, FormBlockTemplate template) : this(new string[] { text }, template.getControls()) { }

        public FormBlock(string text, Control[] controls) : this(new string[] { text }, controls) { }

        public Control[] getControls()
        {
            return controls;
        }

        public void updatePosition(int xOffset, int yOffset)
        {
            foreach(Control c in controls)
            {
                c.Location = new Point(
                    c.Location.X + xOffset - this.xOffset,
                    c.Location.Y + yOffset - this.yOffset);
            }

            this.xOffset = xOffset;
            this.yOffset = yOffset;
        }
        
        public bool IsAuto { get => isAuto; set => isAuto = value; }
    }
}
