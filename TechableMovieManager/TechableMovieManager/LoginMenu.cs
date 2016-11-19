﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechableMovieManager
{
    public partial class LoginMenu : Form
    {
        /*
        public void LoadMovies()
        {
            StreamReader fileReader = new StreamReader("C:/Users/ithom2/Documents/Data/dvdParsed.csv");
            string line;
            int lineNum = 0;
            int added = 0;
            while ((line = fileReader.ReadLine()) != null)
            {
                lineNum++;
                string name = "";
                string studio = "";
                string yearStr = "";
                int year = 0;
                string a = "cat";

                string[] elements = line.Split(';');

                name = removeEnds(elements[0]);
                studio = removeEnds(elements[1]);
                yearStr = removeEnds(elements[2]);
                if (Check.isInt32(yearStr))
                    year = Int32.Parse(yearStr);
                else
                    year = 0;
                if ((lineNum % 2500) == 0 && year != 0)
                {
                    if (name.Length > 39 || studio.Length > 39)
                    {
                        int nextPartition2 = 0;
                    }else
                    {
                        added++;
                        MoviesTable.add(name, year, studio);
                    }
                }
                int nextPartition = 0;
            }

            fileReader.Close();
        }
        
        public void LoadCopies()
        {
            for(int i = 5; i <= 58; i++)
            {
                CopiesTable.add(i - 4, i);
                CopiesTable.add(54 + i - 4, i);
            }
        }
        */
        public string removeEnds(string input)
        {
            input = input.Remove(0, 1);
            input = input.Remove(input.Length - 1, 1);
            return input;
        }
        

        public LoginMenu()
        {
            InitializeComponent();
            GlobalControl.setTextBoxMaxLength(this, 40);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = userNameTxt.Text;
            string password = passwordTxt.Text;

            if (Check.isAllAlphaNumeric(userName, password))
            {
                Object[] i = EmployeesTable.getEmployee(userName, password);
                bool isValidCredentials = i != null;
                if (isValidCredentials)
                {
                    int employeeId = (int)i[0];
                    string firstName = (string)i[1];
                    string lastName = (string)i[2];
                    bool isAdmin = (bool)i[3];

                    User user = new User(isAdmin, userName, firstName, lastName, employeeId);

                    startMainMenu(user);
                }else if (userName.Equals("Admin"))
                {
                    User user = new User(true, userName, "fname", "lname", 666);

                    startMainMenu(user);
                }
                else
                {
                    MessageBox.Show("Incorrect username and/or password.", "Failed Authentication", MessageBoxButtons.OK);
                }
            }else
            {
                MessageBox.Show("Enter alphanumeric characters only.", "Invalid Input", MessageBoxButtons.OK);
            }
        }
        public void startMainMenu(User user)
        {
            //start main menu
            MainMenu MainMenu = new MainMenu(user);
            this.Hide();
            MainMenu.Show();
        }
        private void LoginMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LoginMenu_Load(object sender, EventArgs e)
        {
            //LoadMovies();
            //LoadCopies();
        }
    }
}
