using System.Windows.Forms;

namespace MyScout
{
    /// <summary>
    /// A generic FormBlock with no specific details, eg. name or datapoint
    /// </summary>
    class FormBlockTemplate
    {
        protected Control[] controls;
        protected int xSize, ySize;
        
        public FormBlockTemplate(Control[] controls, int xSize, int ySize)
        {
            this.controls = controls;
            this.xSize = xSize;
            this.ySize = ySize;
        }

        public Control[] getControls()
        {
            return controls;
        }

        public int Height
        {
            get
            {
                return ySize;
            }
        }

        public int Width
        {
            get
            {
                return xSize;
            }
        }

        /// <summary>
        /// Create a new non-generic FormBlock from this Template
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public FormBlock CreateSpecific(string text, bool isAuto, int dataSetIndex)
        {
            return new FormBlock(text, isAuto, dataSetIndex, this);
        }

        public FormBlock CreateSpecific(string text, int[] ints, bool isAuto, int dataSetIndex)
        {
            return new FormBlock(new string[] { text }, ints, isAuto, xSize, ySize, dataSetIndex, getControls());
        }
    }
}
