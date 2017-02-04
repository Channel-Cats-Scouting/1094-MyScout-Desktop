namespace MyScout
{
    /// <summary>
    /// A String that contains its index and its "selected" status
    /// </summary>
    public class StringEntry
    {
        public string str;
        public int index;
        private bool selected;

        public StringEntry(string s, int i)
        {
            str = s;
            index = i;
        }

        /// <summary>
        /// Set if this entry is selected for use
        /// </summary>
        /// <param name="selected"></param>
        public void setIsSelected(bool selected)
        {
            this.selected = selected;
        }

        /// <summary>
        /// Get if this entry is selected for use
        /// </summary>
        /// <returns></returns>
        public bool getIsSelected()
        {
            return selected;
        }
    }
}
