using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechableMovieManager
{
    abstract class GlobalControl
    {
        public static void setTextBoxMaxLength(Form form, int maxLength)
        {
            foreach (TextBox item in form.Controls.OfType<TextBox>())
            {
                item.MaxLength = 20;
            }
        }
    }
}
