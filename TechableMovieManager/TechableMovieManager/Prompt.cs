using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechableMovieManager
{
    public static class Prompt
    {
        public static void enterInt32(string field)
        {
            string prompt = "Enter an 32bit integer into " + field + ".";
            MessageBox.Show(prompt, "Invalid Input", MessageBoxButtons.OK);
        }
    }
}
