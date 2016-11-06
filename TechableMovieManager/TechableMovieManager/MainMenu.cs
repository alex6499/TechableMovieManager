using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechableMovieManager
{
    public partial class MainMenu : Form
    {

        /*
         * ----------------------------------------------------------------------------------------------
         * Part 1: Global variables
         * ----------------------------------------------------------------------------------------------
         */

        //table interfaec objects
        CustomersTable customersTable;
        CustomersTable moviesTable;
        CustomersTable employeesTable;
        CustomersTable rentalsTable;

        //The current User
        User currentUser;

        //panel to setup method relation
        public delegate void setupDelegate();
        Dictionary<Panel, setupDelegate> setupPanels = new Dictionary<Panel, setupDelegate>();

        //main panel
        Panel currentMainPanel;

        //constant specifying button panel witdth
        const double BUTTON_PANEL_WIDTH = 0.2;

        //The following two are formatting variables which will be used to normalize the location of textboxes
        const double LABEL_LEFT = 0.1;
        const double TEXT_LEFT = 0.3;
        const double TEXT_RIGHT = 0.7;

        /*
         * ----------------------------------------------------------------------------------------------
         * Part 2: Initialization methods and events
         * ----------------------------------------------------------------------------------------------
         */

        public MainMenu(string userName)
        {
            currentUser = new User(userName.Equals("Admin"), userName);
            customersTable = new CustomersTable();
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            this.AcceptButton = rent1Btn;
            this.ActiveControl = checkout1Txt;
            
            this.Text = currentUser.getUserName() + " logged in";

            System.Drawing.Color buttonColor; 
            if (currentUser.isAdmin())
            {
                newCustomerBtn.Visible = false;
                this.BackColor = System.Drawing.Color.Goldenrod;
                buttonColor = System.Drawing.Color.SteelBlue;
            }
            else
            {
                adminBtn.Visible = false;
                this.BackColor = System.Drawing.Color.SteelBlue;
                buttonColor = System.Drawing.Color.Goldenrod;
            }

            rent1Btn.BackColor = buttonColor;
            rent2Btn.BackColor = buttonColor;
            return1Btn.BackColor = buttonColor;
            newCustomer1Btn.BackColor = buttonColor;

            //to create new panel, make a setup method, link it to the panel here, then make a event to show it
            setupPanels.Add(returnPnl, setupReturnPnl);
            setupPanels.Add(rentPnl, setupRentPnl);
            setupPanels.Add(rent2Pnl, setupRent2Pnl);
            setupPanels.Add(adminPnl, setupAdminPnl);
            setupPanels.Add(reportsPnl, setupReportsPnl);
            setupPanels.Add(newCustomerPnl, setupNewCustomerPnl);
            setupPanels.Add(addUserPnl, setupAddUserPnl);
            setupPanels.Add(addMoviePnl, setupAddMoviePnl);
            setupPanels.Add(passwordPnl, setupPasswordPnl);
            setupPanels.Add(removeCustomerPnl, setupRemoveCustomerPnl);
            setupPanels.Add(removeUserPnl, setupRemoveUserPnl);
            setupPanels.Add(removeMoviePnl, setupRemoveMoviePnl);

            //sets report panel to initial panel
            setCurrentMainPanel(rentPnl);

            //ensures all positions are correctly set at startup
            resizePage();
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void MainMenu_Resize(object sender, EventArgs e)
        {
            resizePage();
        }
        


        /*
         * ----------------------------------------------------------------------------------------------
         * Part 3: Button Click Events
         * ----------------------------------------------------------------------------------------------
         */

        private void ChangeBtn_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void checkoutBtn_Click(object sender, EventArgs e)
        {
            this.ActiveControl = checkout1Txt;
            this.AcceptButton = rent1Btn;
            setCurrentMainPanel(rentPnl);
        }

        private void rent1Btn_Click(object sender, EventArgs e)
        {
            setCurrentMainPanel(rent2Pnl);
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            this.AcceptButton = return1Btn;
            this.ActiveControl = return1Txt;
            setCurrentMainPanel(returnPnl);
        }

        private void newCustomer_Click(object sender, EventArgs e)
        {
            setCurrentMainPanel(newCustomerPnl);
        }

        private void reportsBtn_Click(object sender, EventArgs e)
        {
            setCurrentMainPanel(reportsPnl);
            DataSet1 ds = new DataSet1();
            DataSet1.MoviesRow newMoviesRow = ds.Movies.NewMoviesRow();

            
        }

        private void adminBtn_Click(object sender, EventArgs e)
        {
            setCurrentMainPanel(adminPnl);
        }

        private void admin1Btn_Click(object sender, EventArgs e)
        {
            setCurrentMainPanel(addUserPnl);
        }

        private void adminPasswordBtn_Click(object sender, EventArgs e)
        {
            setCurrentMainPanel(passwordPnl);
        }
        private void admin2Btn_Click(object sender, EventArgs e)
        {
            setCurrentMainPanel(removeUserPnl);
        }
        private void admin3Btn_Click(object sender, EventArgs e)
        {
            setCurrentMainPanel(newCustomerPnl);
        }
        private void admin4Btn_Click(object sender, EventArgs e)
        {
            setCurrentMainPanel(removeCustomerPnl);
        }
        private void admin5Btn_Click(object sender, EventArgs e)
        {
            setCurrentMainPanel(addMoviePnl);
        }
        private void admin6Btn_Click(object sender, EventArgs e)
        {
            setCurrentMainPanel(removeMoviePnl);
        }
        private void checkoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setCurrentMainPanel(rentPnl);
        }

        private void checkinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setCurrentMainPanel(returnPnl);
        }
        

        /*
         * ----------------------------------------------------------------------------------------------
         * Part 4; Resizing and positioning methods
         * ----------------------------------------------------------------------------------------------
         */

        /// <summary>
        /// This method changes the current main panel to a new one specified
        /// </summary>
        /// <param name="panel">The new panel to show as the main panel</param>
        private void setCurrentMainPanel(Panel panel)
        {
            resizeMainPanel(panel);
            //make old panel invisible
            if (currentMainPanel != null)
            {
                currentMainPanel.Visible = false;
            }
            panel.Visible = true;
            currentMainPanel = panel;
        }

        /// <summary>
        /// Sets the position of all components within the form based on percent relative locations
        /// </summary>
        private void resizePage()
        {
            setPositionFormControl(mainButtonPnl, 0, BUTTON_PANEL_WIDTH, .1, .95);

            resizeMainPanel(currentMainPanel);

            if (currentUser.isAdmin())
            {
                Button[] mainButtons = { rentBtn, returnBtn, reportsBtn, adminBtn };
                setPositionVertically(mainButtons, mainButtonPnl);
            }
            else
            {
                Button[] mainButtons = { rentBtn, returnBtn, reportsBtn, newCustomerBtn };
                setPositionVertically(mainButtons, mainButtonPnl);
            }
        }

        private void resizeMainPanel(Panel panel)
        {
            setPositionFormControl(panel, BUTTON_PANEL_WIDTH, .95, .1, .95);
            //fetches method for seting up the panel from dictionary
            setupDelegate setupMethod;
            setupPanels.TryGetValue(panel, out setupMethod);
            setupMethod();
        }

        /*
         * ----------------------------------------------------------------------------------------------
         * Part 5: Panel Setup Methods
         * ----------------------------------------------------------------------------------------------
         */

        public void setupAddMoviePnl()
        {
            Panel panel = addMoviePnl;
            double endOfText;
            double endOfLabels;

            setTitlePosition(addMovieTitleLbl, panel);

            endOfLabels = setLabelPostions(panel, 0.2, addMovie1Lbl, addMovie2Lbl, addMovie3Lbl, addMovie4Lbl, addMovie5Lbl);
            endOfText = setTextBoxPostions(panel, 0.2, addMovie1Txt, addMovie2Txt, addMovie3Txt, addMovie4Txt, addMovie5Txt);

            setLocationPanelControl(addMovie1Btn, panel, .4, endOfText + 0.1);
        }

        public void setupAddUserPnl()
        {
            Panel panel = addUserPnl;
            double endOfText;
            double endOfLabels;

            setTitlePosition(addUserTitleLbl, panel);
            endOfLabels = setLabelPostions(panel, 0.2, addUser1Lbl, addUser2Lbl, addUser3Lbl, addUser4Lbl);
            endOfText = setTextBoxPostions(panel, 0.2, addUser1Txt, addUser2Txt, addUser3Txt, addUser4Txt);

            setLocationPanelControl(addUserRdb, panel, .4, endOfText);
            setLocationPanelControl(addUserBtn, panel, .4, endOfText + 0.1);
        }

        public void setupAdminPnl()
        {
            setPositionPanelControl(adminTitleLbl, adminPnl, .4, .7, 0, .1);

            setPositionPanelControl(adminTab, adminPnl, .1, .9, .1, .9);

            setControlPosition(admin1Data, 0, 1, 0, .8);
            setControlPosition(admin2Data, 0, 1, 0, .8);
            setControlPosition(admin3Data, 0, 1, 0, .8);

            //user Buttons
            setControlLocation(admin1Btn, .1, .85);
            setControlLocation(adminPasswordBtn, .4, .85);
            setControlLocation(admin2Btn, .7, .85);

            //customer buttons
            setControlLocation(admin3Btn, .3, .85);
            setControlLocation(admin4Btn, .6, .85);

            //movie buttons
            setControlLocation(admin5Btn, .3, .85);
            setControlLocation(admin6Btn, .6, .85);
        }
        /// <summary>
        /// Sets the position of all components within the new customer panel based on percent relative locations
        /// </summary>
        public void setupNewCustomerPnl()
        {
            Panel panel = newCustomerPnl;
            double endOfText;
            double endOfLabels;

            setTitlePosition(newCustomerTitleLbl, panel);

            endOfLabels = setLabelPostions(panel, 0.2, newCustomer1Lbl, newCustomer2Lbl, newCustomer3Lbl, newCustomer4Lbl, newCustomer5Lbl);
            endOfText = setTextBoxPostions(panel, 0.2, newCustomer1Txt, newCustomer2Txt, newCustomer3Txt, newCustomer4Txt, newCustomer5Txt);

            setLocationPanelControl(newCustomer1Btn, panel, .4, endOfText + 0.1);
        }

        
        

        public void setupPasswordPnl()
        {
            Panel panel = passwordPnl;
            double endOfText;
            double endOfLabels;

            setTitlePosition(passwordTitleLbl, panel);
            endOfLabels = setLabelPostions(panel, 0.2, password1Lbl, password2Lbl, password3Lbl);
            endOfText = setTextBoxPostions(panel, 0.2, password1Txt, password2Txt, password3Txt);
            
            setLocationPanelControl(password1Btn, panel, .4, endOfText + 0.1);
        }

        public void setupRemoveCustomerPnl()
        {
            Panel panel = removeCustomerPnl;
            double endOfText;
            double endOfLabels;

            setTitlePosition(removeCustomerTitleLbl, panel);

            endOfLabels = setLabelPostions(panel, 0.2, removeCustomer1Lbl);
            endOfText = setTextBoxPostions(panel, 0.2, removeCustomer1Txt);

            setLocationPanelControl(removeCustomer1Btn, panel, .4, endOfText + 0.1);
        }

        public void setupRemoveMoviePnl()
        {
            Panel panel = removeMoviePnl;
            double endOfText;
            double endOfLabels;

            setTitlePosition(removeMovieTitleLbl, panel);

            endOfLabels = setLabelPostions(panel, 0.2, removeMovie1Lbl);
            endOfText = setTextBoxPostions(panel, 0.2, removeMovie1Txt);

            setLocationPanelControl(removeMovie1Btn, panel, .4, endOfText + 0.1);
        }

        public void setupRemoveUserPnl()
        {
            Panel panel = removeUserPnl;
            double endOfText;
            double endOfLabels;

            setTitlePosition(removeUserTitleLbl, panel);

            endOfLabels = setLabelPostions(panel, 0.2, removeUser1Lbl);
            endOfText = setTextBoxPostions(panel, 0.2, removeUser1Txt);

            setLocationPanelControl(removeUser1Btn, panel, .4, endOfText + 0.1);
        }

        public void setupRentPnl()
        {
            setPositionPanelControl(rentTitleLbl, rentPnl, .4, .7, 0, .1);

            setPositionPanelControl(checkout1Lbl, rentPnl, LABEL_LEFT, TEXT_LEFT, .2, .3);

            setPositionPanelControl(checkout1Txt, rentPnl, TEXT_LEFT, TEXT_RIGHT, .2, .3);

            setLocationPanelControl(rent1Btn, rentPnl, .4, .3);
        }

        public void setupRent2Pnl()
        {
            Panel panel = rent2Pnl;
            double endOfText;
            double endOfLabels;

            setPositionPanelControl(rentTitle2Lbl, panel, .4, .7, 0, .1);

            endOfLabels = setLabelPostions(panel, 0.2, rent2Lbl, rent3Lbl, rent4Lbl, rent5Lbl, rent6Lbl);
            endOfText = setTextBoxPostions(panel, 0.2, rent2Txt, rent3Txt, rent4Txt, rent5Txt, rent6Txt);
            
            setPositionPanelControl(rent7Lbl, rent2Pnl, LABEL_LEFT, TEXT_LEFT, endOfText, endOfText + 0.1);
            setLocationPanelControl(comboBox1, rent2Pnl, TEXT_LEFT, endOfText);

            setLocationPanelControl(rent2Btn, rent2Pnl, 0.4, endOfLabels + 0.2);
        }

        public void setupReportsPnl()
        {
            setPositionPanelControl(reportsTitleLbl, reportsPnl, .4, .7, 0, .1);

            setPositionPanelControl(reportsTab, reportsPnl, .1, .9, .1, .9);

            setControlPosition(reports1Data, 0, 1, 0, 1);
            setControlPosition(reports2Data, 0, 1, 0, 1);
            setControlPosition(reports3Data, 0, 1, 0, 1);
            setControlPosition(reports4Data, 0, 1, 0, 1);
            setControlPosition(reports5Data, 0, 1, 0, 1);
        }

        public void setupReturnPnl()
        {
            setPositionPanelControl(returnTitleLbl, returnPnl, .4, .7, 0, .1);

            setPositionPanelControl(return1Lbl, returnPnl, LABEL_LEFT, TEXT_LEFT, .2, .3);

            setPositionPanelControl(return1Txt, returnPnl, TEXT_LEFT, TEXT_RIGHT, .2, .3);

            setLocationPanelControl(return1Btn, returnPnl, .4, .3);
        }

        /*
        * ----------------------------------------------------------------------------------------------
        * Part 6: Set Position Methods
        * ----------------------------------------------------------------------------------------------
        */

        public void setTitlePosition(Label label, Panel panel)
        {
            setPositionPanelControl(label, panel, .4, .7, 0, .1);
        }
        public double setLabelPostions(Panel panel, double top, params Label[] labels)
        {
            for (int i = 0; i < labels.Length; i++)
            {
                setPositionPanelControl(labels[i], panel, LABEL_LEFT, TEXT_LEFT, top, top + 0.1);
                top += 0.1;
            }

            return top;
        }

        public double setTextBoxPostions(Panel panel, double top, params TextBox[] textBoxes)
        {
            for (int i = 0; i < textBoxes.Length; i++)
            {
                setPositionPanelControl(textBoxes[i], panel, TEXT_LEFT, TEXT_RIGHT, top, top + 0.1);
                top += 0.1;
            }

            return top;
        }

        private void setPositionFormControl(Control control, double left, double right, double top, double bottom)
        {
            int formWidth = this.Width;
            int formHeight = this.Height;

            int xPos = Convert.ToInt32(formWidth * left);
            int yPos = Convert.ToInt32(formHeight * top);
            int width = Convert.ToInt32(formWidth * right) - xPos;
            int height = Convert.ToInt32(formHeight * bottom) - yPos;

            control.Location = new Point(xPos, yPos);
            control.Size = new Size(width, height);
        }

        private void setPositionPanelControl(Control control, Panel panel, double left, double right, double top, double bottom)
        {
            int formWidth = panel.Width;
            int formHeight = panel.Height;

            int xPos = Convert.ToInt32(formWidth * left);
            int yPos = Convert.ToInt32(formHeight * top);
            int width = Convert.ToInt32(formWidth * right) - xPos;
            int height = Convert.ToInt32(formHeight * bottom) - yPos;

            control.Location = new Point(xPos, yPos);
            control.Size = new Size(width, height);
        }

        private void setControlPosition(Control control, double left, double right, double top, double bottom)
        {
            int formWidth = control.Parent.Parent.Width;
            int formHeight = control.Parent.Parent.Height;

            int xPos = Convert.ToInt32(formWidth * left);
            int yPos = Convert.ToInt32(formHeight * top);
            int width = Convert.ToInt32(formWidth * right) - xPos;
            int height = Convert.ToInt32(formHeight * bottom) - yPos;

            control.Location = new Point(xPos, yPos);
            control.Size = new Size(width, height);
        }

        private void setControlLocation(Control control, double x, double y)
        {
            int formWidth = control.Parent.Parent.Width;
            int formHeight = control.Parent.Parent.Height;

            int xPos = Convert.ToInt32(formWidth * x);
            int yPos = Convert.ToInt32(formHeight * y);

            control.Location = new Point(xPos, yPos);
        }

        private void setLocationPanelControl(Control control, Panel panel, double x, double y)
        {
            int formWidth = panel.Width;
            int formHeight = panel.Height;

            int xPos = Convert.ToInt32(formWidth * x);
            int yPos = Convert.ToInt32(formHeight * y);

            control.Location = new Point(xPos, yPos);
        }

        private void setSizePanelControl(Control control, Panel panel, double widthPercent, double heightPercent)
        {
            int formWidth = panel.Width;
            int formHeight = panel.Height;

            int width = Convert.ToInt32(formWidth * widthPercent);
            int height = Convert.ToInt32(formHeight * heightPercent);

            control.Size = new Size(width, height);
        }

        private void setPositionVertically(Control[] controls, Panel panel)
        {
            int numberOfControls = controls.Length;
            int panelWidth = panel.Width;
            int panelHeight = panel.Height;

            for (int i = 0; i < controls.Length; i++)
            {
                Control control = controls[i];

                control.Location = new Point(0, i * panelHeight / numberOfControls);

                control.Width = panelWidth;
                control.Height = panelHeight / numberOfControls;
            }
        }

        private void setPositionHorizontally(Control[] controls, Panel panel)
        {
            int numberOfControls = controls.Length;
            int panelWidth = panel.Width;
            int panelHeight = panel.Height;

            for (int i = 0; i < controls.Length; i++)
            {
                Control control = controls[i];

                control.Location = new Point(i * panelHeight / numberOfControls, 0);

                control.Width = panelWidth / numberOfControls;
                control.Height = panelHeight;
            }
        }

        private void newCustomer1Btn_Click(object sender, EventArgs e)
        {
            string fName = newCustomer1Txt.Text;
            string lName = newCustomer2Txt.Text;
            string phone = newCustomer3Txt.Text;
            string email = newCustomer4Txt.Text;
            string address = newCustomer5Txt.Text;

            customersTable.add(lName, fName, email, address, phone);
        }

        private void addUserTitleLbl_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }

    /*
    * ----------------------------------------------------------------------------------------------
    * Part 7: User Class
    * ----------------------------------------------------------------------------------------------
    */

    public class User
    {
        private bool admin;
        private int userId;
        private string userName;
        private string firstName;
        private string lastName;

        public User(bool isAdmin, string userName)
        {
            this.admin = isAdmin;
            this.userId = userId;
            this.userName = userName;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public User(bool isAdmin, string userName, string firstName, string lastName, int userId)
        {
            this.admin = isAdmin;
            this.userId = userId;
            this.userName = userName;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public bool isAdmin()
        {
            return admin;
        }

        public string getUserName()
        {
            return userName;
        }

        public int getUserId()
        {
            return userId;
        }

        public string getFirstName()
        {
            return firstName;
        }

        public string getLastName()
        {
            return lastName;
        }
    }

    /*
    * ----------------------------------------------------------------------------------------------
    * Part 8: Customer Table Class
    * ----------------------------------------------------------------------------------------------
    */

    public class CustomersTable
    {
        DataSet1.CustomersDataTable table;
        DataSet1TableAdapters.CustomersTableAdapter adapter;
        public CustomersTable()
        {
            table = new DataSet1.CustomersDataTable();
            adapter = new DataSet1TableAdapters.CustomersTableAdapter();
        }

        public void add(string lName, string fName, string email, string address, string phone)
        {
            adapter.InsertSansId(lName, fName, email, address, phone);
        }        
    }

    public class EmployeesTable
    {
        DataSet1.EmployeesDataTable table;
        DataSet1TableAdapters.EmployeesTableAdapter adapter;
        public EmployeesTable()
        {
            table = new DataSet1.EmployeesDataTable();
            adapter = new DataSet1TableAdapters.EmployeesTableAdapter();
        }

        public void add(string lName, string fName, bool isAdmin, string userName, string password)
        {
            adapter.InsertSansId(fName, lName, isAdmin, userName, password);
        }
    }

    public class MoviesTable
    {
        DataSet1.MoviesDataTable table;
        DataSet1TableAdapters.MoviesTableAdapter adapter;
        public MoviesTable()
        {
            table = new DataSet1.MoviesDataTable();
            adapter = new DataSet1TableAdapters.MoviesTableAdapter();
        }

        public void add(int quantityTotal, int quantityAvailable, int upc, string name, string date, string director)
        {
            adapter.InsertSansId(quantityTotal, quantityAvailable, upc, name, date, director);
        }
    }

    public class RentalsTable
    {
        DataSet1.RentalsDataTable table;
        DataSet1TableAdapters.RentalsTableAdapter adapter;
        public RentalsTable()
        {
            table = new DataSet1.RentalsDataTable();
            adapter = new DataSet1TableAdapters.RentalsTableAdapter();
        }

        public void add(int movieId, int customerId, int employeeId, string dueDate, decimal fine)
        {
            adapter.InsertSansId(movieId, customerId, employeeId, dueDate, fine);
        }
    }
}