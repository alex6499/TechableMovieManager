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
        double labelPos;
        double textPos;

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
            labelPos = 0.1;
            textPos = 0.5;

            //ensures all positions are correctly set at startup
            resizePage();
            //sets report panel to initial panel
            setCurrentMainPanel(checkoutPnl);


            mainButtonsPosition = Position.LEFT;
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
            setCurrentMainPanel(checkoutPnl);
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
            setCurrentMainPanel(checkoutPnl);
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
            setPositionFormControl(mainButtonPnl, 0, .3, .1, .95);

            setPositionFormControl(returnPnl, .3, .95, .1, .95);
            setPositionFormControl(checkoutPnl, .3, .95, .1, .95);
            setPositionFormControl(newCustomerPnl, .3, .95, .1, .95);
            setPositionFormControl(reportsPnl, .3, .95, .1, .95);
            setPositionFormControl(adminPnl, .3, .95, .1, .95);

            setupReturnPnl();
            setupNewCustomerPnl();
            setupCheckoutPnl();
            setupAdminPnl();
            setupReportsPnl();

            Button[] mainButtons = { checkinBtn, newCustomerBtn, returnBtn, reportsBtn, adminBtn };
            setPositionVertically(mainButtons, mainButtonPnl);
        }

        /// <summary>
        /// Sets the position of all components within the new customer panel based on percent relative locations
        /// </summary>
        public void setupNewCustomerPnl()
        {
            setPositionPanelControl(customerTitleLbl, newCustomerPnl, .4, .7, .1, .2);

            setPositionPanelControl(newCustomer1Lbl, newCustomerPnl, labelPos, textPos, .2, .3);
            setPositionPanelControl(newCustomer2Lbl, newCustomerPnl, labelPos, textPos, .3, .4);
            setPositionPanelControl(newCustomer3Lbl, newCustomerPnl, labelPos, textPos, .4, .5);

            setPositionPanelControl(newCustomer1Txt, newCustomerPnl, textPos, .8, .2, .3);
            setPositionPanelControl(newCustomer2Txt, newCustomerPnl, textPos, .8, .3, .4);
            setPositionPanelControl(newCustomer3Txt, newCustomerPnl, textPos, .8, .4, .5);
        }

        public void setupCheckoutPnl()
        {
            setPositionPanelControl(checkoutTitleLbl, newCustomerPnl, .4, .7, .1, .2);


            setPositionPanelControl(checkout1Lbl, checkoutPnl, labelPos, textPos, .2, .3);
            setPositionPanelControl(checkout2Lbl, checkoutPnl, labelPos, textPos, .3, .4);
            setPositionPanelControl(checkout3Lbl, checkoutPnl, labelPos, textPos, .4, .5);
            setPositionPanelControl(checkout4Lbl, checkoutPnl, labelPos, textPos, .5, .6);

            setPositionPanelControl(checkout1Txt, checkoutPnl, textPos, .8, .2, .3);
            setPositionPanelControl(checkout2Txt, checkoutPnl, textPos, .8, .3, .4);
            setPositionPanelControl(checkout3Txt, checkoutPnl, textPos, .8, .4, .5);
            setPositionPanelControl(checkout4Txt, checkoutPnl, textPos, .8, .5, .6);
        }

        public void setupReturnPnl()
        {
            setPositionPanelControl(returnTitleLbl, newCustomerPnl, .4, .7, .1, .2);

            setPositionPanelControl(return1Lbl, checkoutPnl, labelPos, textPos, .2, .3);
            setPositionPanelControl(return2Lbl, checkoutPnl, labelPos, textPos, .3, .4);
            setPositionPanelControl(return3Lbl, checkoutPnl, labelPos, textPos, .4, .5);

            setPositionPanelControl(return1Txt, checkoutPnl, textPos, .8, .2, .3);
            setPositionPanelControl(return2Txt, checkoutPnl, textPos, .8, .3, .4);
            setPositionPanelControl(return3Txt, checkoutPnl, textPos, .8, .4, .5);
        }
        public void setupReportsPnl()
        {
            setPositionPanelControl(reportsTitleLbl, reportsPnl, .4, .7, .1, .2);

            setPositionPanelControl(reportsTab, reportsPnl, .1, .9, .2, .9);
        }

        public void setupAdminPnl()
        {
            setPositionPanelControl(adminTitleLbl, adminPnl, .4, .7, .1, .2);

            setPositionPanelControl(adminTab, adminPnl, .1, .9, .2, .9);
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

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}