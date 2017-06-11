using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MyScout
{
    /// <summary>
    /// Takes the info from FormBlock objects to assemble a GUI grid
    /// </summary>
    class FormAssembler
    {
        public static Dictionary<String, FormBlockTemplate> FormBoxDict;

        public static void Assemble(FormBlock[] blocks, GroupBox autobox, GroupBox telebox)
        {
            InitDictionary();

            //TODO: create blocks and add to boxes
            for(int i = 0; i < blocks.Count(); ++i)
            {
                GroupBox formBlockBox = new GroupBox();
                formBlockBox.Controls.AddRange(blocks[i].getControls());
                if(blocks[i].IsAuto)
                {
                    autobox.Controls.Add(formBlockBox);
                }
                else
                {
                    telebox.Controls.Add(formBlockBox);
                }
            }
        }

        /// <summary>
        /// This control's text can be changed
        /// </summary>
        public static string TEXT_DISPLAY = "txtdsp";
        public static string BOOL_SOURCE = "boolsrc";
        public static string INT_SOURCE = "intsrc";
        public static string STRING_SOURCE = "strsrc";

        public static string AUTO_BOX = "autobox";
        public static string TELEOP_BOX = "telebox";

        private static void InitDictionary()
        {
            //Checkbox
            CheckBox checkbox = new CheckBox();
            checkbox.Location = new Point(0, 0);
            checkbox.Tag = TEXT_DISPLAY + ";" + BOOL_SOURCE;
            FormBlockTemplate checkboxBlock = new FormBlockTemplate(new Control[] { checkbox });
            FormBoxDict.Add("checkbox", checkboxBlock);

            //Numberbox
            Button upbutton = new Button();
            upbutton.Text = "^";
            upbutton.Click += new EventHandler(incrInt);
            upbutton.Location = new Point(0, 0);
            upbutton.Size = new Size(90, 40);
            Button downbutton = new Button();
            downbutton.Text = "v";
            downbutton.Click += new EventHandler(decrInt);
            upbutton.Location = new Point(0, 80);
            upbutton.Size = new Size(90, 40);
            NumericUpDown nud = new NumericUpDown();
            nud.Location = new Point(0, 45);
            nud.Size = new Size(90, 30);
            nud.Value = 0;
            nud.Tag = INT_SOURCE;
            FormBlockTemplate numberboxBlock = new FormBlockTemplate(new Control[] { upbutton, nud, downbutton });
        }

        /// <summary>
        ///Increments a sibling INT_SOURCE nud
        /// </summary>
        static void incrInt(object sender, EventArgs e)
        {
            foreach(Control c in ((Button)sender).Parent.Controls)
            {
                if (c is NumericUpDown)
                {
                    if (c.Tag.ToString().Contains(INT_SOURCE))
                    {
                        //Increment the text value
                        c.Text = (Convert.ToInt16(((NumericUpDown)c).Value) + 1).ToString();
                    }
                }
            }
        }
        /// <summary>
        ///Decrements a sibling INT_SOURCE nud
        /// </summary>
        static void decrInt(object sender, EventArgs e)
        {
            foreach (Control c in ((Button)sender).Parent.Controls)
            {
                if (c.Tag.ToString().Contains(INT_SOURCE))
                {
                    //Increment the text value
                    c.Text = (Convert.ToInt16(c.Text) - 1).ToString();
                }
            }
        }
    }
}
