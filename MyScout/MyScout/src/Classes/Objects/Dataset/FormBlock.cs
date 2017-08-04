using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System;

namespace MyScout
{
    /// <summary>
    /// A specific block of controls to be added to the GUI
    /// </summary>
    class FormBlock
    {

        /// <summary>
        /// The pixel offset of the FormBlock controls from the top-left corner (TODO: remove)
        /// </summary>
        private int xOffset = 0, yOffset = 0;
        private int column;
        private Control[] controls;
        private bool isAuto;
        private int xSize, ySize;

        public FormBlock(string[] text, int[] ints, bool[] bools, float[] floats, bool isAuto, int xSize, int ySize, int dataSetIndex, Control[] controls)
        {
            this.controls = CloneControlArray(controls);
            this.xSize = xSize;
            this.ySize = ySize;
            this.isAuto = isAuto;

            TagMgr.WriteTags(this.controls, text);
            TagMgr.WriteTags(this.controls, ints);
            TagMgr.WriteTags(this.controls, bools);
            TagMgr.WriteTags(this.controls, floats);
            TagMgr.WriteDatapoint(this.controls, dataSetIndex);
            TagMgr.AttachFunctions(this.controls);
        }

        public FormBlock(string[] text, int[] ints, bool[] bools, bool isAuto, int xSize, int ySize, int dataSetIndex, Control[] controls) :
            this(text, ints, bools, new float[0], isAuto, xSize, ySize, dataSetIndex, controls) { }

        public FormBlock(string[] text, int[] ints, bool isAuto, int xSize, int ySize, int dataSetIndex, Control[] controls) :
            this(text, ints, new bool[0], new float[0], isAuto, xSize, ySize, dataSetIndex, controls) { }

        public FormBlock(string[] text, bool isAuto, int xSize, int ySize, int dataSetIndex, Control[] controls):
            this(text, new int[0], new bool[0], new float[0], isAuto, xSize, ySize, dataSetIndex, controls) { }

        public FormBlock(string text, bool isAuto, int xSize, int ySize, int dataSetIndex, Control[] controls) :
            this(new string[] { text }, new int[0], isAuto, xSize, ySize, dataSetIndex, controls){ }

        public FormBlock(string text, bool isAuto, int dataSetIndex, FormBlockTemplate template): 
            this(new string[] { text }, isAuto, template.Width, template.Height, dataSetIndex, template.getControls()) { }

        public Control[] getControls()
        {
            return controls;
        }

        /// <summary>
        /// Sets the position of the block to a new offset
        /// </summary>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
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

        public int Width { get => xSize; set => xSize = value; }
        public int Height { get => ySize; set => ySize = value; }
        public bool IsAuto { get => isAuto; set => isAuto = value; }
        public int Column { get => column; set => column = value; }

        private static Control[] CloneControlArray(Control[] controls)
        {
            List<Control> clonedControls = new List<Control>();
            foreach(Control c in controls)
            {
                Type t = c.GetType();
                Control cloned;
                if (t == typeof(Button))
                {
                    Button clonedBtn = new Button()
                    {
                        AccessibleName = c.AccessibleName,
                        BackgroundImage = c.BackgroundImage,
                        Cursor = c.Cursor,
                        Font = c.Font,
                        TextAlign = ((Button)c).TextAlign,
                        ForeColor = c.ForeColor,
                        BackColor = c.BackColor,
                        Size = c.Size,
                        Name = c.Name,
                        Location = c.Location,
                        MaximumSize = c.MaximumSize,
                        MinimumSize = c.MinimumSize,
                        Height = c.Height,
                        Width = c.Width,
                        Text = c.Text,
                        Tag = c.Tag,
                        FlatStyle = ((Button)c).FlatStyle
                    };

                    cloned = clonedBtn;
                }
                else if(t == typeof(NumericUpDown))
                {
                    NumericUpDown clonedNUD = new NumericUpDown()
                    {
                        AccessibleName = c.AccessibleName,
                        BackgroundImage = c.BackgroundImage,
                        Cursor = c.Cursor,
                        Font = c.Font,
                        TextAlign = ((NumericUpDown)c).TextAlign,
                        ForeColor = c.ForeColor,
                        BackColor = c.BackColor,
                        Size = c.Size,
                        Name = c.Name,
                        Location = c.Location,
                        MaximumSize = c.MaximumSize,
                        MinimumSize = c.MinimumSize,
                        Height = c.Height,
                        Width = c.Width,
                        Text = c.Text,
                        Tag = c.Tag
                    };

                    cloned = clonedNUD;
                }
                else if(t == typeof(CheckBox))
                {
                    CheckBox clonedChkbx = new CheckBox()
                    {
                        AccessibleName = c.AccessibleName,
                        BackgroundImage = c.BackgroundImage,
                        Cursor = c.Cursor,
                        Font = c.Font,
                        TextAlign = ((CheckBox)c).TextAlign,
                        CheckAlign = ((CheckBox)c).CheckAlign,
                        ForeColor = c.ForeColor,
                        BackColor = c.BackColor,
                        Size = c.Size,
                        Name = c.Name,
                        Location = c.Location,
                        MaximumSize = c.MaximumSize,
                        MinimumSize = c.MinimumSize,
                        Height = c.Height,
                        Width = c.Width,
                        Text = c.Text,
                        Tag = c.Tag
                    };

                    cloned = clonedChkbx;
                }
                else if(t == typeof(TrackBar))
                {
                    TrackBar clonedTB = new TrackBar()
                    {
                        AccessibleName = c.AccessibleName,
                        BackgroundImage = c.BackgroundImage,
                        Cursor = c.Cursor,
                        Font = c.Font,
                        ForeColor = c.ForeColor,
                        BackColor = c.BackColor,
                        Size = c.Size,
                        Name = c.Name,
                        Location = c.Location,
                        MaximumSize = c.MaximumSize,
                        MinimumSize = c.MinimumSize,
                        Maximum = ((TrackBar)c).Maximum,
                        Minimum = ((TrackBar)c).Minimum,
                        SmallChange = ((TrackBar)c).SmallChange,
                        LargeChange = ((TrackBar)c).LargeChange,
                        Height = c.Height,
                        Width = c.Width,
                        Text = c.Text,
                        Tag = c.Tag
                    };

                    cloned = clonedTB;
                }
                else if(t == typeof(Label))
                {
                    Label clonedLbl = new Label()
                    {
                        AccessibleName = c.AccessibleName,
                        BackgroundImage = c.BackgroundImage,
                        Cursor = c.Cursor,
                        Font = c.Font,
                        TextAlign = ((Label)c).TextAlign,
                        ForeColor = c.ForeColor,
                        BackColor = c.BackColor,
                        Size = c.Size,
                        Name = c.Name,
                        Location = c.Location,
                        MaximumSize = c.MaximumSize,
                        MinimumSize = c.MinimumSize,
                        FlatStyle = ((Label)c).FlatStyle,
                        Height = c.Height,
                        Width = c.Width,
                        Text = c.Text,
                        Tag = c.Tag
                    };

                    cloned = clonedLbl;
                }
                else
                {
                    cloned = new Control()
                    {
                        AccessibleName = c.AccessibleName,
                        BackgroundImage = c.BackgroundImage,
                        Cursor = c.Cursor,
                        Font = c.Font,
                        ForeColor = c.ForeColor,
                        BackColor = c.BackColor,
                        Size = c.Size,
                        Name = c.Name,
                        Location = c.Location,
                        MaximumSize = c.MaximumSize,
                        MinimumSize = c.MinimumSize,
                        Height = c.Height,
                        Width = c.Width,
                        Text = c.Text,
                        Tag = c.Tag
                    };
                }

                clonedControls.Add(cloned);
            }

            return clonedControls.ToArray();
        }
    }
}
