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

        public static void cannotDeleteSelf()
        {
            string prompt = "You cannot delete yourself.";
            MessageBox.Show(prompt, "Invalid Input", MessageBoxButtons.OK);
        }


        public static void beingWorkedOn(string message)
        {
            string prompt = "This functionality is still being worked on.\n" + message;
            MessageBox.Show(prompt, "Invalid Input", MessageBoxButtons.OK);
        }

        public static void enterPhone()
        {
            string prompt = "Please enter phone number in the format format 012-345-6789.";
            MessageBox.Show(prompt, "Invalid Input", MessageBoxButtons.OK);
        }
        public static void noCopy()
        {
            string prompt = "No dvd has that UPC.";
            MessageBox.Show(prompt, "Invalid Input", MessageBoxButtons.OK);
        }
        public static void copyUnavailable()
        {
            string prompt = "That copy is not currently available for rental.";
            MessageBox.Show(prompt, "Invalid Input", MessageBoxButtons.OK);
        }
        public static void notACustomer()
        {
            string prompt = "The specified user does is not registered.";
            MessageBox.Show(prompt, "Invalid Input", MessageBoxButtons.OK);
        }
    }
}
