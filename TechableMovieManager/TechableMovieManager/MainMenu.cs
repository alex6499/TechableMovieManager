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
         * Globals
         */
        CustomersTable customersTable;

        public delegate void setupDelegate();
        Dictionary<Panel, setupDelegate> setupPanels = new Dictionary<Panel, setupDelegate>();

        Panel currentMainPanel;

        double buttonPanelWidth = 0.2;

        //The following two are formatting variables which will be used to normalize the location of textboxes
        double labelLeft;
        double textLeft;
        double textRight;

        User currentUser;

        /*
         * Initialization and Resize Methods
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
            labelLeft = 0.1;
            textLeft = 0.3;
            textRight = 0.7;
            
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
            setupPanels.Add(passwordPnl, setupPasswordPnl);

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
        
        public abstract class MainPanel
        {

        }

        /*
         * ----------------------------------------------------------------------------------------------
         * Button Click Events
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

        private void admin3Btn_Click(object sender, EventArgs e)
        {
            setCurrentMainPanel(newCustomerPnl);
        }
        private void admin5Btn_Click(object sender, EventArgs e)
        {

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
         * Resizing and positioning methods
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

        /*
         * Page and Panel Positioning Methods
         */

        /// <summary>
        /// Sets the position of all components within the form based on percent relative locations
        /// </summary>
        private void resizePage()
        {
            setPositionFormControl(mainButtonPnl, 0, buttonPanelWidth, .1, .95);

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
            setPositionFormControl(panel, buttonPanelWidth, .95, .1, .95);
            //fetches method for seting up the panel from dictionary
            setupDelegate setupMethod;
            setupPanels.TryGetValue(panel, out setupMethod);
            setupMethod();
        }


        /*
         * ----------------------------------------------------------------------------------------------
         * Setup Methods
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
                setPositionPanelControl(labels[i], panel, labelLeft, textLeft, top, top + 0.1);
                top += 0.1;
            }

            return top;
        }

        public double setTextBoxPostions(Panel panel, double top, params TextBox[] textBoxes)
        {
            for (int i = 0; i < textBoxes.Length; i++)
            {
                setPositionPanelControl(textBoxes[i], panel, textLeft, textRight, top, top + 0.1);
                top += 0.1;
            }

            return top;
        }

        /// <summary>
        /// Sets the position of all components within the new customer panel based on percent relative locations
        /// </summary>
        public void setupNewCustomerPnl()
        {
            Panel panel = newCustomerPnl;

            setPositionPanelControl(customerTitleLbl,panel, .4, .7, 0, .1);

            setPositionPanelControl(newCustomer1Lbl, panel, labelLeft, textLeft, .2, .3);
            setPositionPanelControl(newCustomer2Lbl, panel, labelLeft, textLeft, .3, .4);
            setPositionPanelControl(newCustomer3Lbl, panel, labelLeft, textLeft, .4, .5);
            setPositionPanelControl(newCustomer4Lbl, panel, labelLeft, textLeft, .5, .6);
            setPositionPanelControl(newCustomer5Lbl, panel, labelLeft, textLeft, .6, .7);

            setPositionPanelControl(newCustomer1Txt, panel, textLeft, textRight, .2, .3);
            setPositionPanelControl(newCustomer2Txt, panel, textLeft, textRight, .3, .4);
            setPositionPanelControl(newCustomer3Txt, panel, textLeft, textRight, .4, .5);
            setPositionPanelControl(newCustomer4Txt, panel, textLeft, textRight, .5, .6);
            setPositionPanelControl(newCustomer5Txt, panel, textLeft, textRight, .6, .7);

            setLocationPanelControl(newCustomer1Btn, panel, .4, .8);
        }

        public void setupAddUserPnl()
        {
            Panel panel = addUserPnl;

            setTitlePosition(addUserTitleLbl, panel);
            setLabelPostions(panel, 0.2, addUser1Lbl, addUser2Lbl, addUser3Lbl, addUser4Lbl);
            setTextBoxPostions(panel, 0.2, addUser1Txt, addUser2Txt, addUser3Txt, addUser4Txt);
            
            setLocationPanelControl(addUserRdb, panel, .4, .6);
            setLocationPanelControl(addUserBtn, panel, .4, .7);
        }


        public void setupPasswordPnl()
        {
            Panel panel = passwordPnl;

            setTitlePosition(passwordTitleLbl, panel);
            setLabelPostions(panel, 0.2, password1Lbl, password2Lbl, password3Lbl);
            double endOfText = setTextBoxPostions(panel, 0.2, password1Txt, password2Txt, password3Txt);
            
            setLocationPanelControl(password1Btn, panel, .4, endOfText + 0.1);
        }

        public void setupRentPnl()
        {
            setPositionPanelControl(rentTitleLbl, rentPnl, .4, .7, 0, .1);

            setPositionPanelControl(checkout1Lbl, rentPnl, labelLeft, textLeft, .2, .3);

            setPositionPanelControl(checkout1Txt, rentPnl, textLeft, textRight, .2, .3);

            setLocationPanelControl(rent1Btn, rentPnl, .4, .3);
        }

        public void setupRent2Pnl()
        {
            Panel panel = rent2Pnl;

            setPositionPanelControl(rentTitle2Lbl, panel, .4, .7, 0, .1);

            double endOfLabels = setLabelPostions(panel, 0.2, rent2Lbl, rent3Lbl, rent4Lbl, rent5Lbl, rent6Lbl);
            double endOfText = setTextBoxPostions(panel, 0.2, rent2Txt, rent3Txt, rent4Txt, rent5Txt, rent6Txt);
            
            setPositionPanelControl(rent7Lbl, rent2Pnl, labelLeft, textLeft, endOfLabels, endOfLabels + 0.1);
            setLocationPanelControl(comboBox1, rent2Pnl, textLeft, endOfText);

            setLocationPanelControl(rent2Btn, rent2Pnl, 0.4, endOfLabels + 0.2);
        }

        public void setupReturnPnl()
        {
            setPositionPanelControl(returnTitleLbl, returnPnl, .4, .7, 0, .1);

            setPositionPanelControl(return1Lbl, returnPnl, labelLeft, textLeft, .2, .3);

            setPositionPanelControl(return1Txt, returnPnl, textLeft, textRight, .2, .3);

            setLocationPanelControl(return1Btn, returnPnl, .4, .3);
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

        public void setupAdminPnl()
        {
            setPositionPanelControl(adminTitleLbl, adminPnl, .4, .7, 0, .1);

            setPositionPanelControl(adminTab, adminPnl, .1, .9, .1, .9);

            setControlPosition(admin1Data, 0, 1, 0, .8);
            setControlPosition(admin2Data, 0, 1, 0, .8);
            setControlPosition(admin3Data, 0, 1, 0, .8);

            setControlLocation(admin1Btn, .3, .85);
            setControlLocation(admin2Btn, .6, .85);
            setControlLocation(admin3Btn, .3, .85);
            setControlLocation(admin4Btn, .6, .85);
            setControlLocation(admin5Btn, .3, .85);
            setControlLocation(admin6Btn, .6, .85);
        }

        /*
         * Object Repositioning Methods
         * 
         */

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

    public class User
    {
        private bool admin;
        private string userName;

        public User(bool isAdmin, string userName)
        {
            this.admin = isAdmin;
            this.userName = userName;
        }

        public bool isAdmin()
        {
            return admin;
        }

        public string getUserName()
        {
            return userName;
        }
    }

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
}