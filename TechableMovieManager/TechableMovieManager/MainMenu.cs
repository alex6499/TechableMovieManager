using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        //The current User
        User currentUser;
        DVD currentDVD;
        Customer currentCustomer;

        Form loginMenu;

        //panel to setup method relation
        public delegate void setupDelegate();
        Dictionary<Panel, setupDelegate> setupPanels = new Dictionary<Panel, setupDelegate>();
        bool isFirstSetup = false;
        //main panel
        Panel currentMainPanel;

        //constant specifying button panel witdth
        const double BUTTON_PANEL_WIDTH = 0.2;
        
        /*
         * ----------------------------------------------------------------------------------------------
         * Part 2: Initialization methods and events
         * ----------------------------------------------------------------------------------------------
         */

        public MainMenu(User user, Form loginMenu)
        {
            this.loginMenu = loginMenu;

            currentUser = user;
            InitializeComponent();

            //restricts max chars in all textboxes
            GlobalControl.setNestedTextBoxMaxLength(this, 40);
            setEmailTextBoxSize(100);

            //assigns a setup method to each panel
            assignPanelSetupDelagates();

            //sets report panel to initial panel
            setCurrentMainPanel(rentPnl);
        }

        public void setEmailTextBoxSize(int maxLength)
        {
            TextBox[] emailBoxes = { newCustomer5Txt};

            foreach(TextBox emailBox in emailBoxes)
            {
                emailBox.MaxLength = maxLength;
            }
        }
        
        private void setColorScheme()
        {
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
        }
        
        private void assignPanelSetupDelagates()
        {
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
            setupPanels.Add(addCopyPnl, setupAddCopyPnl);
            setupPanels.Add(removeCopyPnl, setupRemoveCopyPnl);
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {           
            //sets the text in the top bar
            this.Text = currentUser.getFirstName() + " " + currentUser.getLastName() + " is logged in";
            
            //sets overall variable collor scheme
            setColorScheme();

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
            string upc = checkout1Txt.Text.Trim(' ');

            if (!Check.isUPC(upc))
            {
                Prompt.enterUPC();
                return;
            }
            
            if(!CopiesTable.hasCopy(upc)){
                Prompt.notInDB("dvd", "UPC");
                return;
            }
            if (!CopiesTable.isAvailable(upc)){
                Prompt.copyUnavailable();
                return;
            }
            
            string movie = MoviesTable.getMovieName(upc);
            currentDVD = new DVD(movie, upc);
            
            clearTextBoxes(rentPnl);
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
            TechableDS ds = new TechableDS();
            TechableDS.MoviesRow newMoviesRow = ds.Movies.NewMoviesRow();
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

        private void copyBtn_Click(object sender, EventArgs e)
        {
            setCurrentMainPanel(addCopyPnl);
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
            isFirstSetup = true;
            resizeMainPanel(panel);
            isFirstSetup = false;
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
            Reposition.setControl(mainButtonPnl, 0, BUTTON_PANEL_WIDTH, .1, .95);

            resizeMainPanel(currentMainPanel);

            if (currentUser.isAdmin())
            {
                Button[] mainButtons = { rentBtn, returnBtn, reportsBtn, adminBtn };
                Reposition.setVertically(mainButtons, mainButtonPnl);
            }
            else
            {
                Button[] mainButtons = { rentBtn, returnBtn, reportsBtn, newCustomerBtn };
                Reposition.setVertically(mainButtons, mainButtonPnl);
            }
        }

        private void resizeMainPanel(Panel panel)
        {
            Reposition.setControl(panel, BUTTON_PANEL_WIDTH, .95, .1, .95);
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

        public void setupAddCopyPnl()
        {
            double endOfText;
            double endOfLabels;

            Reposition.setTitle(addCopyTitleLbl);

            endOfLabels = Reposition.setLabels(0.2, addCopy1Lbl, addCopy2Lbl);
            endOfText = Reposition.setTextBoxes(0.2, addCopy1Txt, addCopy2Txt);

            Reposition.setControlLocation(addCopy1Btn, .4, endOfText);
        }

        public void setupAddMoviePnl()
        {
            double endOfText;
            double endOfLabels;

            Reposition.setTitle(addMovieTitleLbl);

            endOfLabels = Reposition.setLabels(0.2, addMovie1Lbl, addMovie2Lbl, addMovie3Lbl);
            endOfText = Reposition.setTextBoxes(0.2, addMovie1Txt, addMovie2Txt, addMovie3Txt);

            Reposition.setControlLocation(addMovie1Btn,.4, endOfText);
        }

        public void setupAddUserPnl()
        {
            double endOfText;
            double endOfLabels;

            Reposition.setTitle(addUserTitleLbl);
            endOfLabels = Reposition.setLabels( 0.2, addUser1Lbl, addUser2Lbl, addUser3Lbl, addUser4Lbl);
            endOfText = Reposition.setTextBoxes( 0.2, addUser1Txt, addUser2Txt, addUser3Txt, addUser4Txt);

            Reposition.setControlLocation(addUserRdb, .4, endOfText);
            Reposition.setControlLocation(addUserBtn, .4, endOfText + 0.1);
        }

        public void setupAdminPnl()
        {
            //fill the data tables with info
            if (isFirstSetup)
            {
                admin1Data.DataSource = EmployeesTable.getAll();
                admin2Data.DataSource = CustomersTable.getAll();
                admin3Data.DataSource = MoviesTable.getAll();
                admin4Data.DataSource = CopiesTable.getAll();
                sortBy(admin4Data, 0, true);
            }

            Reposition.setControl(adminTitleLbl, .4, .7, 0, .1);

            Reposition.setControl(adminTab, .1, .9, .1, .9);

            Reposition.setNestedControlPosition(admin1Data, .05, .95, 0, .8);
            Reposition.setNestedControlPosition(admin2Data, .05, .95, 0, .8);
            Reposition.setNestedControlPosition(admin3Data, .05, .95, 0, .8);
            Reposition.setNestedControlPosition(admin4Data, .05, .95, 0, .8);

            //user Buttons
            Reposition.setNestedControlLocation(admin1Btn, .1, .85);
            Reposition.setNestedControlLocation(adminPasswordBtn, .4, .85);
            Reposition.setNestedControlLocation(admin2Btn, .7, .85);

            //customer buttons
            Reposition.setNestedControlLocation(admin3Btn, .3, .85);
            Reposition.setNestedControlLocation(admin4Btn, .6, .85);

            //movie buttons
            Reposition.setNestedControlLocation(admin5Btn, .3, .85);
            Reposition.setNestedControlLocation(admin6Btn, .6, .85);

            //upc buttons
            Reposition.setNestedControlLocation(admin7Btn, .3, .85);
        }
        /// <summary>
        /// Sets the position of all components within the new customer panel based on percent relative locations
        /// </summary>
        public void setupNewCustomerPnl()
        {
            double endOfText;
            double endOfLabels;

            Reposition.setTitle(newCustomerTitleLbl);

            endOfLabels = Reposition.setLabels(0.2, newCustomer1Lbl, newCustomer2Lbl, newCustomer3Lbl, newCustomer4Lbl, newCustomer5Lbl);
            endOfText = Reposition.setTextBoxes(0.2, newCustomer1Txt, newCustomer2Txt, newCustomer3Txt, newCustomer4Txt, newCustomer5Txt);

            Reposition.setControlLocation(newCustomer1Btn,.4, endOfText);
        }

        public void setupPasswordPnl()
        {
            Panel panel = passwordPnl;
            double endOfText;
            double endOfLabels;

            Reposition.setTitle(passwordTitleLbl);
            endOfLabels = Reposition.setLabels( 0.2, password1Lbl, password2Lbl, password3Lbl);
            endOfText = Reposition.setTextBoxes(0.2, password1Txt, password2Txt, password3Txt);

            Reposition.setControlLocation(password1Btn, .4, endOfText);
        }

        public void setupRemoveCopyPnl() {
            double endOfText;
            double endOfLabels;

            Reposition.setTitle(removeCopyTitleLbl);

            endOfLabels = Reposition.setLabels(0.2, removeCopy1Lbl);
            endOfText = Reposition.setTextBoxes(0.2, removeCopy1Txt);

            Reposition.setControlLocation(removeCopy1Btn, .4, endOfText);
        }

        public void setupRemoveCustomerPnl()
        {
            double endOfText;
            double endOfLabels;

            Reposition.setTitle(removeCustomerTitleLbl);

            endOfLabels = Reposition.setLabels( 0.2, removeCustomer1Lbl);
            endOfText = Reposition.setTextBoxes(0.2, removeCustomer1Txt);

            Reposition.setControlLocation(removeCustomer1Btn, .4, endOfText);
        }

        public void setupRemoveMoviePnl()
        {
            double endOfText;
            double endOfLabels;

            Reposition.setTitle(removeMovieTitleLbl);

            endOfLabels = Reposition.setLabels(  0.2, removeMovie1Lbl);
            endOfText = Reposition.setTextBoxes( 0.2, removeMovie1Txt);

            Reposition.setControlLocation(removeMovie1Btn, .4, endOfText);
        }

        public void setupRemoveUserPnl()
        {
            double endOfText;
            double endOfLabels;

            Reposition.setTitle(removeUserTitleLbl);

            endOfLabels = Reposition.setLabels(0.2, removeUser1Lbl);
            endOfText = Reposition.setTextBoxes(0.2, removeUser1Txt);

            Reposition.setControlLocation(removeUser1Btn, .4, endOfText + 0.1);
        }

        public void setupRentPnl()
        {
            double endOfText;
            double endOfLabels;

            Reposition.setTitle(rentTitleLbl);

            endOfLabels = Reposition.setLabels(0.2, checkout1Lbl);
            endOfText = Reposition.setTextBoxes(0.2, checkout1Txt);

            Reposition.setControlLocation(rent1Btn, .4, endOfText);
            
        }

        public void setupRent2Pnl()
        {
            double endOfText;
            double endOfLabels;

            Reposition.setTitle(rentTitle2Lbl);

            endOfLabels = Reposition.setLabels(0.2, rent2Lbl, rent3Lbl, rent4Lbl);
            endOfText = Reposition.setTextBoxes(0.2, rent2Txt, rent3Txt, rent4Txt);

            Reposition.setControlLocation(rent2Btn, 0.4, endOfLabels);
        }

        public void sortBy(DataGridView data, int colNum, bool isAscending)
        {
            if (0 <= colNum && colNum < data.ColumnCount)
            {
                ListSortDirection direction;
                if (isAscending) {
                    direction = ListSortDirection.Ascending;
                } else {
                    direction = ListSortDirection.Descending;
                }
                data.Sort(data.Columns[colNum], direction);
            }
        }
        public void setupReportsPnl()
        {
            if (isFirstSetup)
            {
                reports1Data.DataSource = MoviesTable.getAll();
                sortBy(reports1Data, 5, false);
                reports2Data.DataSource = CustomersTable.getAll();
                sortBy(reports2Data, 7, false);
                reports3Data.DataSource = MoviesTable.getAll();
                reports4Data.DataSource = RentalsTable.getNotReturned();
                sortBy(reports4Data, 4, true);
                reports5Data.DataSource = RentalsTable.getLateMovies();
                sortBy(reports5Data, 4, true);
                reports6Data.DataSource = CopiesTable.getAll();
                sortBy(reports6Data, 0, true);
            }

            Reposition.setControl(reportsTitleLbl,  .4, .7, 0, .1);

            Reposition.setControl(reportsTab,  .1, .9, .1, .9);

            Reposition.setNestedControlPosition(reports1Data, .05, .95, 0, 1);
            Reposition.setNestedControlPosition(reports2Data, .05, .95, 0, 1);
            Reposition.setNestedControlPosition(reports3Data, .05, .95, 0, 1);
            Reposition.setNestedControlPosition(reports4Data, .05, .95, 0, 1);
            Reposition.setNestedControlPosition(reports5Data, .05, .95, 0, 1);
            Reposition.setNestedControlPosition(reports6Data, .05, .95, 0, 1);
        }

        public void setupReturnPnl()
        {
            Panel panel = returnPnl;
            double endOfText;
            double endOfLabels;

            Reposition.setControl(returnTitleLbl, .4, .7, 0, .1);

            endOfLabels = Reposition.setLabels(0.2, return1Lbl);
            endOfText = Reposition.setTextBoxes(0.2, return1Txt);

            Reposition.setControlLocation(return1Btn, .4, endOfText);
        }

        /*
        * ----------------------------------------------------------------------------------------------
        * Part 6: Clear methods
        * ----------------------------------------------------------------------------------------------
        */

        

        

        public void clearRadioButtons(Panel panel)
        {
            RadioButton[] radioButtons = panel.Controls.OfType<RadioButton>().ToArray<RadioButton>();

            foreach(RadioButton radioButton in radioButtons)
            {
                radioButton.Checked = false;
            }
        }

        public void clearTextBoxes(Panel panel)
        {
            TextBox[] textBoxes = panel.Controls.OfType<TextBox>().ToArray<TextBox>();

            foreach (TextBox textBox in textBoxes)
            {
                textBox.Clear();
            }
        }


        public void clearTextBoxes(Form form)
        {
            TextBox[] textBoxes = form.Controls.OfType<TextBox>().ToArray<TextBox>();

            foreach (TextBox textBox in textBoxes)
            {
                textBox.Clear();
            }
        }

        /*
         * ----------------------------------------------------------------------------------------------
         * Part 5: Submit Button Events
         * ----------------------------------------------------------------------------------------------
         */

        private void removeMovie1Btn_Click(object sender, EventArgs e)
        {
            string movieId = removeMovie1Txt.Text.Trim(' ');

            if (!Check.areValidInputs(movieId))
            {
                Prompt.enterValidInput();
                return;
            }
            if (!Check.isInt32(movieId))
            {
                Prompt.enterInt32("Movie Id");
                return;
            }
            if (!MoviesTable.hasMovieById(Int32.Parse(movieId)))
            {
                Prompt.notInDB("movie", "movie ID");
                return;
            }
            if (CopiesTable.hasCopyById(Int32.Parse(movieId)))
            {
                Prompt.removalDependency("movie", "UPC");
                return;
            }
            
            MoviesTable.setDeleted(true, Int32.Parse(movieId));
            clearTextBoxes(removeMoviePnl);
        }
        private void addCopy1Btn_Click(object sender, EventArgs e)
        {
            string movieId = addCopy1Txt.Text.Trim(' ');
            string upc = addCopy2Txt.Text.Trim(' ');

            if (!Check.areValidInputs(movieId, upc))
            {
                Prompt.enterValidInput();
                return;
            }
            //enter int MovieId
            if (!Check.isInt32(movieId))
            {
                Prompt.enterInt32("movie ID");
                return;
            }
            //incorrect UPC format
            if (!Check.isUPC(upc))
            {
                Prompt.enterUPC();
                return;
            }
            //specified movie is not in DB
            if (!MoviesTable.hasMovieById(Int32.Parse(movieId)))
            {
                Prompt.notInDB("movie", "movie ID");
                return;
            }
            //UPC ust be unique
            if (CopiesTable.hasCopy(upc))
            {
                Prompt.alreadyInDB("UPC");
                return;
            }

            CopiesTable.add(upc, Int32.Parse(movieId));

            addCopy2Txt.Clear();
        }
        private void return1Btn_Click(object sender, EventArgs e)
        {
            string upc = return1Txt.Text.Trim(' ');
            if (!Check.areValidInputs(upc))
            {
                Prompt.enterValidInput();
                return;
            }
            if (!Check.isUPC(upc))
            {
                Prompt.enterUPC();
                return;
            }
            if (!CopiesTable.hasCopy(upc))
            {
                Prompt.notInDB("dvd", "UPC");
                return;
            }
            if (CopiesTable.isAvailable(upc))
            {
                Prompt.cantReturn();
                return;
            }

            RentalsTable.returnMovie(upc);
            CopiesTable.makeAvailable(upc);

            clearTextBoxes(returnPnl);
            //MessageBox.Show(prompt, "Success.", MessageBoxButtons.OK);
            
        }

        private void removeUser1Btn_Click(object sender, EventArgs e)
        {
            string userName = removeUser1Txt.Text.Trim(' ');

            if (!Check.areValidInputs(userName))
            {
                Prompt.enterValidInput();
                return;
            }
            if (currentUser.getUserName().Equals(userName))
            {
                Prompt.cannotDeleteSelf();
                return;
            }
            EmployeesTable.delete(userName);

            clearTextBoxes(removeUserPnl);
        }
        private void newCustomer1Btn_Click(object sender, EventArgs e)
        {
            string firstName = newCustomer1Txt.Text.Trim(' ');
            string lastName = newCustomer2Txt.Text.Trim(' ');
            string phone = newCustomer3Txt.Text.Trim(' ');
            string email = newCustomer4Txt.Text.Trim(' ');
            string address = newCustomer5Txt.Text.Trim(' ');

            if (!Check.areValidInputs(firstName, lastName, phone, email, address))
            {
                Prompt.enterValidInput();
                return;
            }
            if (!Check.isPhone(phone))
            {
                Prompt.enterPhone();
                return;
            }
            if (CustomersTable.hasCustomer(firstName, lastName, phone))
            {
                Prompt.alreadyInDB("customer");
                return;
            }

            CustomersTable.add(lastName, firstName, email, address, phone);

            clearRadioButtons(newCustomerPnl);
            clearTextBoxes(newCustomerPnl);

            if (currentUser.isAdmin())
            {
                setCurrentMainPanel(adminPnl);
            }
        }

        private void addUserBtn_Click(object sender, EventArgs e)
        {
            string firstName = addUser1Txt.Text.Trim(' ');
            string lastName = addUser2Txt.Text.Trim(' ');
            string userName = addUser3Txt.Text.Trim(' ');
            string password = addUser4Txt.Text.Trim(' ');
            bool isAdmin = addUserRdb.Checked;

            if (!Check.areValidInputs(firstName, lastName, userName, password))
            {
                Prompt.enterValidInput();
                return;
            }
            //userName already in DB
            if (EmployeesTable.hasEverHadEmployee(userName))
            {
                Prompt.alreadyInDB("user");
                return;
            }


            EmployeesTable.add(lastName, firstName, isAdmin, userName, password);

            clearTextBoxes(addUserPnl);
        }

        private void removeCustomer1Btn_Click(object sender, EventArgs e)
        {
            string customerId = removeCustomer1Txt.Text.Trim(' ');

            if (!Check.areValidInputs(customerId))
            {
                Prompt.enterValidInput();
                return;
            }
            if (!Check.isInt32(customerId))
            {
                Prompt.enterInt32("Customer Id");
                return;
            }
            if (!CustomersTable.hasCustomer(Int32.Parse(customerId)))
            {
                Prompt.notInDB("customer", customerId);
                return;
            }
            if (RentalsTable.customerIsRenting(Int32.Parse(customerId)))
            {
                Prompt.removalDependency("customer", "rental");
                return;
            }

            CustomersTable.setDeleted(true, Int32.Parse(customerId));

            clearTextBoxes(removeCustomerPnl);
            //exit to admin panel
            setCurrentMainPanel(adminPnl);
        }

        private void addMovie1Btn_Click(object sender, EventArgs e)
        {
            string name = addMovie1Txt.Text.Trim(' ');
            string studio = addMovie2Txt.Text.Trim(' ');
            string year = addMovie3Txt.Text.Trim(' ');

            if (!Check.areValidInputs(name, studio, year))
            {
                Prompt.enterValidInput();
                return;
            }
            if (!Check.isYear(year))
            {
                Prompt.enterYear();
                return;
            }


            //Movie is already in DB
            if (MoviesTable.hasMovieByInfo(name, studio, Int32.Parse(year)))
            {
                Prompt.alreadyInDB("movie");
            }else
            {
                //Add to DB
                MoviesTable.add(name, Int32.Parse(year), studio);
            }

            //cleanup
            clearRadioButtons(addMoviePnl);
            clearTextBoxes(addMoviePnl);

            //transition to add DVDs for the movie
            addCopy1Txt.Text = MoviesTable.getMovieId(name, studio, Int32.Parse(year)).ToString();
            setCurrentMainPanel(addCopyPnl);
        }

        private void rent2Btn_Click(object sender, EventArgs e)
        {
            string firstName = rent2Txt.Text.Trim(' ');
            string lastName = rent3Txt.Text.Trim(' ');
            string phone = rent4Txt.Text.Trim(' ');
            int customerId;

            if (!Check.areValidInputs(firstName, lastName, phone))
            {
                Prompt.enterValidInput();
                return;
            }

            if (!Check.isPhone(phone))
            {
                Prompt.enterPhone();
                return;
            }

            if (!CustomersTable.hasCustomer(firstName, lastName, phone))
            {
                Prompt.notACustomer();
                return;
            }

            customerId = CustomersTable.getCustomerId(firstName, lastName, phone);

            currentCustomer = new Customer(customerId, firstName, lastName);

            CopiesTable.makeUnavailable(currentDVD.getUpc());

            RentalsTable.add(currentDVD.getUpc(), currentCustomer.getCustomerId(), currentUser.getUserName(), Date.dateAfter(7));
            CustomersTable.incrementTimesRented(currentCustomer.getCustomerId());
            MoviesTable.incrementTimesRented(currentDVD.getUpc());
            clearTextBoxes(rent2Pnl);
            setCurrentMainPanel(rentPnl);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearTextBoxes(loginMenu);
            this.Hide();
            loginMenu.Show();
        }

        private void exitProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setCurrentMainPanel(newCustomerPnl);
        }

        private void adminPnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void admin8Btn_Click(object sender, EventArgs e)
        {
            setCurrentMainPanel(removeCopyPnl);
        }

        private void removeCopy1Btn_Click(object sender, EventArgs e)
        {
            string upc = removeCopy1Txt.Text.Trim(' ');

            if (!Check.areValidInputs(upc))
            {
                Prompt.enterValidInput();
                return;
            }
            if (!Check.isUPC(upc))
            {
                Prompt.enterUPC();
                return;
            }
            if (!CopiesTable.hasCopy(upc))
            {
                Prompt.notInDB("dvd", "upc");
                return;
            }
            if (RentalsTable.upcIsRenting(upc))
            {
                Prompt.removalDependency("upc", "rental");
                return;
            }

            CopiesTable.delete(upc);

            clearTextBoxes(removeCopyPnl);
            //exit to admin panel
            setCurrentMainPanel(adminPnl);
        }

        private void addCopyPnl_Paint(object sender, PaintEventArgs e)
        {
           
        }
    }
}