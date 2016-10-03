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
        enum Position { RIGHT, LEFT, TOP, BOTTOM };

        Panel currentMainPanel;
        //The following two are formatting variables which will be used to normalize the location of textboxes
        double labelLeft;
        double textLeft;
        double textRight;

        Boolean isAdmin;

        Position mainButtonsPosition;

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

            isAdmin = true;

            if (isAdmin)
            {
                newCustomerBtn.Visible = false;
            }else
            {
                adminBtn.Visible = false;
            }
            //ensures all positions are correctly set at startup
            resizePage();
            //sets report panel to initial panel
            setCurrentMainPanel(rentPnl);


            mainButtonsPosition = Position.LEFT;
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
         * Button Click Events
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

        /// <summary>
        /// This method changes the current main panel to a new one specified
        /// </summary>
        /// <param name="panel">The new panel to show as the main panel</param>
        private void setCurrentMainPanel(Panel panel)
        {
            if (currentMainPanel != null)
            {
                currentMainPanel.Visible = false;
            }

            currentMainPanel = panel;
            currentMainPanel.Visible = true;
        }

        /*
         * Page and Panel Positioning Methods
         */
        
        /// <summary>
        /// Sets the position of all components within the form based on percent relative locations
        /// </summary>
        private void resizePage()
        {
            double buttonPanelWidth = 0.2;

            setPositionFormControl(mainButtonPnl, 0, buttonPanelWidth, .1, .95);

            setPositionFormControl(returnPnl, buttonPanelWidth, .95, .1, .95);
            setPositionFormControl(rentPnl, buttonPanelWidth, .95, .1, .95);
            setPositionFormControl(rent2Pnl, buttonPanelWidth, .95, .1, .95);
            setPositionFormControl(newCustomerPnl, buttonPanelWidth, .95, .1, .95);
            setPositionFormControl(reportsPnl, buttonPanelWidth, .95, .1, .95);
            setPositionFormControl(adminPnl, buttonPanelWidth, .95, .1, .95);

            setupReturnPnl();
            setupNewCustomerPnl();
            setupRentPnl();
            setupRent2Pnl();
            setupAdminPnl();
            setupReportsPnl();

            if (isAdmin)
            {
                Button[] mainButtons = { rentBtn, returnBtn, reportsBtn, adminBtn };
                setPositionVertically(mainButtons, mainButtonPnl);
            }else{
                Button[] mainButtons = { rentBtn, returnBtn, reportsBtn, newCustomerBtn };
                setPositionVertically(mainButtons, mainButtonPnl);
            }
            
            
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
            setPositionPanelControl(newCustomer3Lbl, newCustomerPnl, labelLeft, textLeft, .5, .6);

            setPositionPanelControl(newCustomer1Txt, newCustomerPnl, textLeft, textRight, .2, .3);
            setPositionPanelControl(newCustomer2Txt, newCustomerPnl, textLeft, textRight, .3, .4);
            setPositionPanelControl(newCustomer3Txt, newCustomerPnl, textLeft, textRight, .4, .5);
            setPositionPanelControl(newCustomer3Txt, newCustomerPnl, labelLeft, textLeft, .5, .6);

            setLocationPanelControl(newCustomer1Btn, newCustomerPnl, .4, .7);
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
            setPositionPanelControl(checkout4Lbl, rent2Pnl, labelLeft, textLeft, .4, .5);
            
            setPositionPanelControl(checkout2Txt, rent2Pnl, textLeft, textRight, .2, .3);
            setPositionPanelControl(checkout3Txt, rent2Pnl, textLeft, textRight, .3, .4);
            setPositionPanelControl(checkout4Txt, rent2Pnl, textLeft, textRight, .4, .5);

            setLocationPanelControl(rent2Btn, rent2Pnl, .4, .5);
        }

        public void setupReturnPnl()
        {
            setPositionPanelControl(returnTitleLbl, newCustomerPnl, .4, .7, 0, .1);

            setPositionPanelControl(return1Lbl, rentPnl, labelLeft, textLeft, .2, .3);

            setPositionPanelControl(return1Txt, rentPnl, textLeft, textRight, .2, .3);

            setLocationPanelControl(return1Btn, rent2Pnl, .4, .3);
        }
        public void setupReportsPnl()
        {
            setPositionPanelControl(reportsTitleLbl, reportsPnl, .4, .7, 0, .1);

            setPositionPanelControl(reportsTab, reportsPnl, .1, .9, .1, .9);

            setControlPosition(reports1Data, 0, 1, 0, 1);
            setControlPosition(reports2Data, 0, 1, 0, 1);
            setControlPosition(reports3Data, 0, 1, 0, 1);
            setControlPosition(reports4Data, 0, 1, 0, 1);
        }

        public void setupAdminPnl()
        {
            setPositionPanelControl(adminTitleLbl, adminPnl, .4, .7, 0, .1);

            setPositionPanelControl(adminTab, adminPnl, .1, .9, .1, .9);

            setControlPosition(admin1Data, 0, 1, 0, 1);
            setControlPosition(admin2Data, 0, 1, 0, 1);
            setControlPosition(admin3Data, 0, 1, 0, 1);
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
        private void setLocationPanelControl(Control control, Panel panel, double x,  double y)
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

        

        private void checkout1Lbl_Click(object sender, EventArgs e)
        {

        }

        private void customerTitleLbl_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}