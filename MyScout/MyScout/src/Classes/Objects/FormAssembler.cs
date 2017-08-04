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
        public static Dictionary<String, FormBlockTemplate> FormBoxDict = new Dictionary<string, FormBlockTemplate>();

        public static void Assemble(FormBlock[] blocks, GroupBox autobox, GroupBox telebox)
        {

            //TODO: create blocks and add to boxes
            int autoXOffset = 0, teleXOffset = 0;
            int autoYOffset = 0, teleYOffset = 0;

            List<int> teleColXOffsets = new List<int>(new int[] { 0, 0, 0 });
            List<int> autoColXOffsets = new List<int>(new int[] { 0, 0, 0 });
            List<int> teleColYHeights = new List<int>(new int[] { 0, 0, 0 });
            List<int> autoColYHeights = new List<int>(new int[] { 0, 0, 0 });

            int padding = 10;

            //Figure out how wide each column should be
            foreach (FormBlock fb in blocks)
            {
                if (fb != null)
                {
                    if (fb.IsAuto)
                    {
                        if (autoColXOffsets[fb.Column + 1] < fb.Width)
                        {
                            autoColXOffsets[fb.Column + 1] = fb.Width;
                        }
                    }
                    else
                    {
                        if (teleColXOffsets[fb.Column + 1] < fb.Width)
                        {
                            teleColXOffsets[fb.Column + 1] = fb.Width;
                        }
                    }
                }
            }

            for (int i = 0; i < blocks.Count(); ++i)
            {
                if (blocks[i] != null)
                {
                    Label formBlockLabel = new Label();
                    formBlockLabel.Size = new Size(blocks[i].Width, blocks[i].Height);
                    formBlockLabel.Controls.AddRange(blocks[i].getControls());
                    formBlockLabel.Tag = Tags.FORMBLOCK;
                    if (blocks[i].IsAuto)
                    {
                        autobox.Controls.Add(formBlockLabel);

                        //Keep shifting the element over until it fits in a groupbox
                        while (autoColYHeights[blocks[i].Column] + blocks[i].Height + padding > autobox.Height)
                        {
                            blocks[i].Column++;
                        }

                        formBlockLabel.Location = new Point(autoColXOffsets[blocks[i].Column] + padding, autoColYHeights[blocks[i].Column] + padding * (i + 1));
                        autoColYHeights[blocks[i].Column] += blocks[i].Height + padding;
                    }
                    else
                    {
                        telebox.Controls.Add(formBlockLabel);

                        //Keep shifting the element over until it fits in a groupbox
                        while (teleColYHeights[blocks[i].Column] + blocks[i].Height + padding > autobox.Height)
                        {
                            blocks[i].Column++;
                        }

                        formBlockLabel.Location = new Point(teleColXOffsets[blocks[i].Column] + padding, teleColYHeights[blocks[i].Column] + padding * (i + 1));
                        teleColYHeights[blocks[i].Column] += blocks[i].Height + padding;
                    }
                }
            }
        }

        public static void InitDictionary()
        {
            //Empty the dictionary so we don't get multiple keyval pairs
            FormBoxDict.Clear();

            //Display font
            Font displayFont = new Font(FontFamily.GenericSansSerif, 18);
            //Entry font
            Font entryFont = new Font(FontFamily.GenericSansSerif, 15.75f);

            //Checkbox
            {
                CheckBox checkbox = new CheckBox()
                {
                    Location = new Point(0, 10),
                    Size = new Size(200, 40),
                    Tag = TagMgr.MergeTags(new string[] { Tags.TEXT_DISPLAY, Tags.BOOL_SOURCE, Tags.DATAPOINT_, Tags.DATA_INDEX }),
                    TextAlign = ContentAlignment.MiddleLeft,
                    CheckAlign = ContentAlignment.MiddleLeft,
                    Font = displayFont,
                    BackColor = Color.Transparent
                };
                FormBlockTemplate checkboxBlock = new FormBlockTemplate(new Control[] { checkbox }, 200, 41);
                FormBoxDict.Add("checkbox", checkboxBlock);
            }

            //Numberbox
            {
                Button upbutton = new Button()
                {
                    BackColor = Color.Gainsboro,
                    Text = "^",
                    Location = new Point(140, 0),
                    Size = new Size(90, 40),
                    Tag = TagMgr.MergeTags(new String[] { Tags.INCREMENT, Tags.ADJUST_TEXT })
                };

                Button downbutton = new Button()
                {
                    BackColor = Color.Gainsboro,
                    Text = "v",
                    Location = new Point(140, 80),
                    Size = new Size(90, 40),
                    Tag = TagMgr.MergeTags(new String[] { Tags.DECREMENT, Tags.ADJUST_TEXT })
                };

                NumericUpDown nud = new NumericUpDown()
                {
                    Location = new Point(140, 45),
                    Size = new Size(90, 30),
                    Value = 0,
                    Tag = TagMgr.MergeTags(new string[] { Tags.INT_SOURCE, Tags.DATAPOINT_, Tags.DATA_INDEX }),
                    Font = entryFont
                };

                Label label = new Label()
                {
                    Location = new Point(0, 0),
                    Size = new Size(120, 120),
                    Tag = Tags.TEXT_DISPLAY,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = displayFont,
                    BackColor = Color.Transparent
                };
                FormBlockTemplate numberboxBlock = new FormBlockTemplate(new Control[] { label, upbutton, nud, downbutton }, 230, 120);
                FormBoxDict.Add("numberbox", numberboxBlock);
            }

            //Trackbar
            {
                Button downbutton = new Button()
                {
                    Text = "<",
                    Location = new Point(0, 0),
                    Size = new Size(40, 90),
                    Tag = TagMgr.MergeTags(new string[] { Tags.DECREMENT, Tags.ADJUST_TRACK })
                };

                TrackBar trackbar = new TrackBar()
                {
                    Location = new Point(60, 0),
                    Size = new Size(110, 40),
                    Tag = TagMgr.MergeTags(new string[] { Tags.INT_SOURCE, Tags.MIN_RANGE_, Tags.INT, Tags.MAX_RANGE_, Tags.INT, Tags.INCR_, Tags.INT })
                };

                Button upbutton = new Button()
                {
                    Text = ">",
                    Location = new Point(130, 0),
                    Size = new Size(40, 90),
                    Tag = TagMgr.MergeTags(new string[] { Tags.INCREMENT, Tags.ADJUST_TRACK })
                };
                FormBlockTemplate trackbarBlock = new FormBlockTemplate(new Control[] { downbutton, upbutton, trackbar }, 170, 90);
                FormBoxDict.Add("trackbar", trackbarBlock);
            }
        }

    }
}
