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
    public partial class MainMenu : Form
    {

        /*
         * Globals
         */

        public delegate void setupDelegate();
        Dictionary<Panel, setupDelegate> setupPanels = new Dictionary<Panel, setupDelegate>();

        Panel currentMainPanel;

        double buttonPanelWidth = 0.2;

        //The following two are formatting variables which will be used to normalize the location of textboxes
        double labelLeft;
        double textLeft;
        double textRight;

        Boolean isAdmin;

        /*
         * Initialization and Resize Methods
         */

        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            labelLeft = 0.1;
            textLeft = 0.3;
            textRight = 0.7;

            isAdmin = !true;

            if (isAdmin)
            {
                newCustomerBtn.Visible = false;
            }else
            {
                adminBtn.Visible = false;
            }


            setupPanels.Add(returnPnl, setupReturnPnl);
            setupPanels.Add(rentPnl, setupRentPnl);
            setupPanels.Add(rent2Pnl, setupRent2Pnl);
            setupPanels.Add(adminPnl, setupAdminPnl);
            setupPanels.Add(reportsPnl, setupReportsPnl);
            setupPanels.Add(newCustomerPnl, setupNewCustomerPnl);
            setupPanels.Add(addUserPnl, setupAddUserPnl);

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
         * Button Click Events
         * ----------------------------------------------------------------------------------------------
         */

        private void ChangeBtn_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void checkoutBtn_Click(object sender, EventArgs e)
        {
            setCurrentMainPanel(rentPnl);
        }

        private void rent1Btn_Click(object sender, EventArgs e)
        {
            setCurrentMainPanel(rent2Pnl);
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            setCurrentMainPanel(returnPnl);
        }

        private void newCustomer_Click(object sender, EventArgs e)
        {
            setCurrentMainPanel(newCustomerPnl);
        }

        private void reportsBtn_Click(object sender, EventArgs e)
        {
            setCurrentMainPanel(reportsPnl);
        }

        private void adminBtn_Click(object sender, EventArgs e)
        {
            setCurrentMainPanel(adminPnl);
        }

        private void checkoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setCurrentMainPanel(rentPnl);
        }

        private void checkinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setCurrentMainPanel(returnPnl);
        }

        private void admin1Btn_Click(object sender, EventArgs e)
        {
            setCurrentMainPanel(addUserPnl);
        }
    
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

            if (isAdmin)
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

        /// <summary>
        /// Sets the position of all components within the new customer panel based on percent relative locations
        /// </summary>
        public void setupNewCustomerPnl()
        {
            setPositionPanelControl(customerTitleLbl, newCustomerPnl, .4, .7, 0, .1);

            setPositionPanelControl(newCustomer1Lbl, newCustomerPnl, labelLeft, textLeft, .2, .3);
            setPositionPanelControl(newCustomer2Lbl, newCustomerPnl, labelLeft, textLeft, .3, .4);
            setPositionPanelControl(newCustomer3Lbl, newCustomerPnl, labelLeft, textLeft, .4, .5);
            setPositionPanelControl(newCustomer4Lbl, newCustomerPnl, labelLeft, textLeft, .5, .6);

            setPositionPanelControl(newCustomer1Txt, newCustomerPnl, textLeft, textRight, .2, .3);
            setPositionPanelControl(newCustomer2Txt, newCustomerPnl, textLeft, textRight, .3, .4);
            setPositionPanelControl(newCustomer3Txt, newCustomerPnl, textLeft, textRight, .4, .5);
            setPositionPanelControl(newCustomer4Txt, newCustomerPnl, textLeft, textRight, .5, .6);

            setLocationPanelControl(newCustomer1Btn, newCustomerPnl, .4, .7);
        }

        public void setupAddUserPnl()
        {
            setPositionPanelControl(customerTitleLbl, newCustomerPnl, .4, .7, 0, .1);

            setPositionPanelControl(addUser1Lbl, newCustomerPnl, labelLeft, textLeft, .2, .3);
            setPositionPanelControl(addUser2Lbl, newCustomerPnl, labelLeft, textLeft, .3, .4);

            setPositionPanelControl(addUser1Txt, newCustomerPnl, textLeft, textRight, .2, .3);
            setPositionPanelControl(addUser2Txt, newCustomerPnl, textLeft, textRight, .3, .4);

            setLocationPanelControl(addUserRdb, newCustomerPnl, .4, .4);
            setLocationPanelControl(addUserBtn, newCustomerPnl, .4, .6);
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
            setPositionPanelControl(rentTitle2Lbl, newCustomerPnl, .4, .7, 0, .1);


            setPositionPanelControl(checkout2Lbl, rent2Pnl, labelLeft, textLeft, .2, .3);
            setPositionPanelControl(checkout3Lbl, rent2Pnl, labelLeft, textLeft, .3, .4);
            setPositionPanelControl(rent3Lbl, rent2Pnl, labelLeft, textLeft, .4, .5);

            setPositionPanelControl(checkout2Txt, rent2Pnl, textLeft, textRight, .2, .3);
            setPositionPanelControl(checkout3Txt, rent2Pnl, textLeft, textRight, .3, .4);

            setLocationPanelControl(comboBox1, rent2Pnl, textLeft, .4);
            setLocationPanelControl(rent2Btn, rent2Pnl, .4, .5);
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
    }
}