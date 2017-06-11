using System.Windows.Forms;

namespace MyScout
{
    class FormBlockTemplate
    {
        protected Control[] controls;
        
        public FormBlockTemplate(Control[] controls)
        {
            this.controls = controls;
        }

        public Control[] getControls()
        {
            return controls;
        }
    }
}
