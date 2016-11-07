using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechableMovieManager
{
    public partial class LoginMenu : Form
    {
        EmployeesTable employeesTable = new EmployeesTable();
        public LoginMenu()
        {
            InitializeComponent();
            GlobalControl.setTextBoxMaxLength(this, 20);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = userNameTxt.Text;
            string password = passwordTxt.Text;
            
            Object[] i = employeesTable.getEmployee(userName, password);
            if (i != null)
            {
                int employeeId = (int)i[0];
                string firstName = (string)i[1];
                string lastName = (string)i[2];
                bool isAdmin = (bool)i[3];

                User user = new User(isAdmin, userName, firstName, lastName, employeeId);

                //start main menu
                MainMenu MainMenu = new MainMenu(user);
                this.Hide();
                MainMenu.Show();
            }
        }

        private void LoginMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
