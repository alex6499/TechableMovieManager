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
        public static void enterValidInput()
        {
            string prompt = "Please only enter alphanumeric characters, spaces"
                + "\nand the followingsymbols . ! ? : ; , ' - ."
                + "\nalso note that leading and trailing white spaces are removed";
            MessageBox.Show(prompt, "Invalid Input", MessageBoxButtons.OK);
        }
        public static void cannotDeleteSelf()
        {
            string prompt = "You cannot delete yourself.";
            MessageBox.Show(prompt, "Invalid Input", MessageBoxButtons.OK);
        }
        public static void cantReturn()
        {
            string prompt = "This movie has already been returned.";
            MessageBox.Show(prompt, "Invalid Input", MessageBoxButtons.OK);
        }

        public static void beingWorkedOn(string message)
        {
            string prompt = "This functionality is still being worked on.\n" + message;
            MessageBox.Show(prompt, "Technical Issue", MessageBoxButtons.OK);
        }

        public static void enterPhone()
        {
            string prompt = "Please enter phone number in the format format 012-345-6789.";
            MessageBox.Show(prompt, "Invalid Input", MessageBoxButtons.OK);
        }
        public static void enterUPC()
        {
            string prompt = "Please enter a 5-20 digit numeric UPC.";
            MessageBox.Show(prompt, "Invalid Input", MessageBoxButtons.OK);
        }
        public static void enterYear()
        {
            string prompt = "Please year between 1900 and 2016.";
            MessageBox.Show(prompt, "Invalid Input", MessageBoxButtons.OK);
        }
        public static void alreadyInDB(string subject)
        {
            string prompt = "This " + subject + " is already in the database.";
            MessageBox.Show(prompt, "Search result", MessageBoxButtons.OK);
        }
        public static void notInDB(string subject, string searchedBy)
        {
            string prompt = "There is no " + subject + " with that " + searchedBy;
            MessageBox.Show(prompt, "Search result", MessageBoxButtons.OK);
        }
        public static void copyUnavailable()
        {
            string prompt = "That copy is not currently available for rental.";
            MessageBox.Show(prompt, "Search result", MessageBoxButtons.OK);
        }
        public static void notACustomer()
        {
            string prompt = "The specified user is not registered.";
            MessageBox.Show(prompt, "Search result", MessageBoxButtons.OK);
        }
    }
}
