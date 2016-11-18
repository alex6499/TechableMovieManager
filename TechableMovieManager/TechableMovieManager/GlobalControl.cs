using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechableMovieManager
{
    public static class GlobalControl
    {
        public static void setTextBoxMaxLength(Form form, int maxLength)
        {
            foreach (TextBox item in form.Controls.OfType<TextBox>())
            {
                item.MaxLength = maxLength;
            }
        }

        public static void setTextBoxMaxLength(Panel form, int maxLength)
        {
            foreach (TextBox item in form.Controls.OfType<TextBox>())
            {
                item.MaxLength = maxLength;
            }
        }

        public static void setNestedTextBoxMaxLength(Form form, int maxLength)
        {
            foreach (Panel panel in form.Controls.OfType<Panel>())
            {
                setTextBoxMaxLength(panel, maxLength);
            }
        }
    }
}
