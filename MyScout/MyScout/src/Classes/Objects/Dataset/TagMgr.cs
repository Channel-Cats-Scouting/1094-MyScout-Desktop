using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyScout
{
    /// <summary>
    /// A static manager for the control/tag system.
    /// This class handles reading and writing from tag/value pairs,
    /// as well as other general tag operations.
    /// </summary>
    static class TagMgr
    {
        public static bool ContainsTag(Control c, string tag)
        {
            string[] splitTags = new string[0];
            if (c.Tag != null)
            {
                splitTags = c.Tag.ToString().Split(';');

                for(int i = 0; i < splitTags.Length; ++i)
                {
                    if (splitTags[i].Contains(':'))
                    {
                        splitTags[i] = splitTags[i].Substring(0, splitTags[i].IndexOf(':') + 1);
                    }
                }
            }

            return splitTags.Contains(tag);
        }

        /// <summary>
        /// Given the name of a tag, returns the value associated with it. Returns "" if the tag wasn't found.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static string GetTagValue(Control c, string tag)
        {
            string mergedtag = "";
            string[] tags = c.Tag.ToString().Split(';');
            foreach (string s in tags)
            {
                if (s.Contains(tag))
                {
                    mergedtag = s;
                }
            }

            return mergedtag == "" ? "" : mergedtag.Split(':')[1].ToString();
        }

        /// <summary>
        /// Combines multiple tags into a single string, merging name/value tags as necessary.
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        public static string MergeTags(string[] tags)
        {
            List<string> mergedTags = new List<string>();
            //Merge tags and values
            for (int i = 0; i < tags.Length; ++i)
            {
                bool valueExists = false;
                //Get where the name/value separator is
                int colonlocation = tags[i].IndexOf(':');
                if (colonlocation != -1 && tags[i].Length > colonlocation + 1)
                {
                    valueExists = true;
                }

                //If there isn't an existing value that was found, merge this tag with the one after it
                if (tags[i].Contains(":") && tags.Length > i + 1 && !valueExists)
                {
                    tags[i] += tags[i + 1];
                    mergedTags.Add(tags[i]);
                    ++i;
                }
                else
                {
                    mergedTags.Add(tags[i]);
                }
            }

            return String.Join(";", mergedTags);
        }

        /// <summary>
        /// Writes a value to a tag in the given control
        /// </summary>
        /// <param name="c"></param>
        /// <param name="tag"></param>
        /// <param name="value"></param>
        public static void WriteTag(Control c, string tag, string value)
        {
            string[] tags;
            if (tag.EndsWith(":"))
            {
                tags = c.Tag.ToString().Split(';');
                for (int i = 0; i < tags.Length; ++i)
                {
                    if (tags[i].Contains(tag))
                    {
                        tags[i] = tag + value;
                    }
                }
            }
        }

        /// <summary>
        /// Replace variable placeholders with actual values, and sets control parameters from the appropriate tags.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controls"></param>
        /// <param name="values"></param>
        public static void WriteTags<T>(Control[] controls, T[] values)
        {
            int iVal = 0;
            //For each control
            for(int i = 0; i < controls.Length; ++i)
            {
                //If the control has tags
                if (controls[i].Tag != null)
                {
                    string[] tags = controls[i].Tag.ToString().Split(';');
                    //For each tag
                    for (int j = 0; j < tags.Length; ++j)
                    {
                        //If this tag contains the correct value type
                        if (tags[j].Contains(
                             typeof(T) == typeof(int) ? Tags.INT :
                             typeof(T) == typeof(bool) ? Tags.BOOL :
                             typeof(T) == typeof(float) ? Tags.FLOAT : "/ / / /")) //TODO: make this better
                        {
                            if (iVal < values.Length)
                            {
                                WriteParamFromTag(controls[i], tags[j], values[iVal]);

                                tags[j] = tags[j].Substring(0, tags[j].IndexOf(':')+1) + values[iVal].ToString();
                                ++iVal;
                            }
                        }
                        //Else if this tag contains text (which is only ever displayed onscreen)
                        else if(typeof(T) == typeof(string) && tags[j].Contains(Tags.TEXT_DISPLAY))
                        {
                            if (iVal < values.Length)
                            {
                                controls[i].Text = values[iVal].ToString();
                                ++iVal;
                            }
                        }
                    }

                    controls[i].Tag = MergeTags(tags);
                }
            }
        }

        /// <summary>
        /// Checks to make sure the tag is there, then sets a control parameter accordingly
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="c"></param>
        /// <param name="tag"></param>
        /// <param name="value"></param>
        private static void WriteParamFromTag<T>(Control c, string tag, T value)
        {
            if (c.GetType() == typeof(TrackBar))
            {
                TrackBar tb = ((TrackBar)c);
                if (tag.Contains(Tags.MAX_RANGE_))
                {
                    tb.Maximum = Convert.ToInt16(value);
                }
                
                if(tag.Contains(Tags.MIN_RANGE_))
                {
                    tb.Minimum = Convert.ToInt16(value);
                }
                
                if(tag.Contains(Tags.INCR_))
                {
                    tb.SmallChange = tb.LargeChange = Convert.ToInt16(value);
                }
            }
        }

        /// <summary>
        /// Attaches event handlers to the controls based on control type and explicit tagging
        /// </summary>
        /// <param name="controls"></param>
        public static void AttachFunctions(Control[] controls)
        {
            for(int i = 0; i < controls.Length; ++i)
            {
                if(ContainsTag(controls[i], Tags.ADJUST_TEXT))
                {
                    controls[i].Click += new EventHandler(TagEvent.AdjustTextInt);
                }
                else if(ContainsTag(controls[i], Tags.ADJUST_TRACK))
                {
                    controls[i].Click += new EventHandler(TagEvent.AdjustTrackbar);
                }
                else if(ContainsTag(controls[i], Tags.BOOL_SOURCE))
                {
                    if(controls[i].GetType() == typeof(CheckBox))
                    {
                       ((CheckBox)controls[i]).CheckedChanged += new EventHandler(TagEvent.Chkbx_CheckedChanged);
                    }
                }
                else if(ContainsTag(controls[i], Tags.INT_SOURCE))
                {
                    if(controls[i].GetType() == typeof(NumericUpDown))
                    {
                        ((NumericUpDown)controls[i]).ValueChanged += new EventHandler(TagEvent.NUD_ValueChanged);
                    }
                }
            }
        }

        /// <summary>
        /// Writes a datapoint to the DATAPOINT_ tag stored in one of the controls
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controls"></param>
        /// <param name="datapoint"></param>
        public static void WriteDatapoint(Control[] controls, int datapoint)
        {
            for(int i = 0; i < controls.Length; ++i)
            {
                if (controls[i].Tag != null)
                {
                    string[] tags = controls[i].Tag.ToString().Split(';');
                    for (int j = 0; j < tags.Length; ++j)
                    {
                        if (tags[j].Contains(Tags.DATA_INDEX))
                        {
                            tags[j] = tags[j].Substring(0, tags[j].IndexOf(':')+1) + datapoint.ToString();
                            break;
                        }
                    }

                    controls[i].Tag = MergeTags(tags);
                }
            }
        }
    }

    public static class Tags
    {
        /// <summary>
        /// This control's text can be changed
        /// </summary>
        public static string TEXT_DISPLAY = "txtdsp";
        /// <summary>
        /// This control provides a boolean value
        /// </summary>
        public static string BOOL_SOURCE = "boolsrc";
        /// <summary>
        /// This control provides an int value
        /// </summary>
        public static string INT_SOURCE = "intsrc";
        /// <summary>
        /// This control provides a string value
        /// </summary>
        public static string STRING_SOURCE = "strsrc";
        /// <summary>
        /// This control increments another
        /// </summary>
        public static string INCREMENT = "incr";
        /// <summary>
        /// This control decrements another
        /// </summary>
        public static string DECREMENT = "decr";

        //Begin value tags
        /// <summary>
        /// This control has a custom increment
        /// </summary>
        public static string INCR_ = "incr:";
        /// <summary>
        /// This control refers to a specific round datapoint (REQUIRED FOR MAINFRM GUI)
        /// </summary>
        public static string DATAPOINT_ = "rnddata:";
        /// <summary>
        /// This control refers to a specific team datapoint (REQUIRED FOR PRESCOUTING GUI)
        /// </summary>
        public static string TMDATA_ = "tmdata:";
        /// <summary>
        /// This control can be 'checked' by giving this a boolean value
        /// </summary>
        public static string CHECKED_ = "chkd:";
        /// <summary>
        /// This control has a max range
        /// </summary>
        public static string MAX_RANGE_ = "maxrng:";
        /// <summary>
        /// This control has a min range
        /// </summary>
        public static string MIN_RANGE_ = "minrng:";

        //variables
        public static string INT = "intval";
        public static string BOOL = "boolval";
        public static string FLOAT = "floatval";
        public static string STRING = "stringval";
        public static string DATA_INDEX = "dataindex";

        //Events
        public static string ADJUST_TEXT = "adjtxt";
        public static string ADJUST_TRACK = "adjtrack";

        //Encapsulation tags
        public static string FORMBLOCK = "formblock";
    }

    class TagEvent
    {
        /// <summary>
        ///Increments or decrements a sibling INT_SOURCE nud or textbox
        /// </summary>
        public static void AdjustTextInt(object sender, EventArgs e)
        {
            foreach (Control c in ((Control)sender).Parent.Controls)
            {
                if (c.Tag != null && TagMgr.ContainsTag(c, Tags.INT_SOURCE))
                {
                    string strIncr = TagMgr.GetTagValue(c, Tags.INCR_);
                    int increment = strIncr == "" ? 1 : Convert.ToInt16(strIncr);

                    //Adjust the INT_SOURCE according to tags
                    if (TagMgr.ContainsTag((Control)sender, Tags.INCREMENT))
                    {
                        c.Text = (Convert.ToInt16(c.Text) + increment).ToString();
                    }
                    else if (TagMgr.ContainsTag((Control)sender, Tags.DECREMENT))
                    {
                        c.Text = (Convert.ToInt16(c.Text) - increment).ToString();
                    }
                }
            }
        }

        public static void AdjustTrackbar(object sender, EventArgs e)
        {
            foreach (Control c in ((Control)sender).Parent.Controls)
            {
                if (c.GetType() == typeof(TrackBar) && c.Tag != null && TagMgr.ContainsTag(c, Tags.INT_SOURCE))
                {
                    TrackBar trackbar = (TrackBar)c;
                    if (((Control)sender).Tag != null)
                    {
                        if (trackbar.Value <= trackbar.Maximum - trackbar.SmallChange && TagMgr.ContainsTag((Control)sender, Tags.INCREMENT))
                        {
                            trackbar.Value += trackbar.SmallChange;
                        }
                        else if (trackbar.Value >= trackbar.SmallChange && TagMgr.ContainsTag((Control)sender, Tags.DECREMENT))
                        {
                            trackbar.Value -= trackbar.SmallChange;
                        }
                    }
                }
            }
        }

        public static void ChangeCheckedControl(object sender, EventArgs e)
        {
            Control control = sender as Control;
            foreach (Control c in control.Parent.Controls)
            {
                if (TagMgr.ContainsTag(c, Tags.CHECKED_))
                {
                    if (TagMgr.GetTagValue(c, Tags.CHECKED_) == "true")
                    {
                        TagMgr.WriteTag(c, Tags.CHECKED_, "false");
                    }
                    else
                    {
                        TagMgr.WriteTag(c, Tags.CHECKED_, "true");
                    }
                }
            }
        }

        public static void Chkbx_CheckedChanged(object sender, EventArgs e)
        {
            var chkBx = sender as CheckBox;
            if (chkBx == null) return;
            Program.CurrentRound.DataSet[Program.SelectedTeamRoundIndex][Convert.ToInt16(TagMgr.GetTagValue(chkBx, Tags.DATAPOINT_))].SetValue(chkBx.Checked);
        }

        public static void NUD_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            if (nud == null) return;
            Program.CurrentRound.DataSet[Program.SelectedTeamRoundIndex][Convert.ToInt16(TagMgr.GetTagValue(nud, Tags.DATAPOINT_))].SetValue((int)nud.Value);
        }
    }
}
