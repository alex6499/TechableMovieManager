﻿using System;
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
         * Initialization and Resize Methods
         */

        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            resizePage();
            TableExample tableExample = new TableExample();
            tableExample.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            returnPnl.Visible = false;
            newCustomerPnl.Visible = false;
            moviesPnl.Visible = false;
            checkoutPnl.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkoutPnl.Visible = false;
            newCustomerPnl.Visible = false;
            moviesPnl.Visible = false;
            returnPnl.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkoutPnl.Visible = false;
            moviesPnl.Visible = false;
            returnPnl.Visible = false;
            newCustomerPnl.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            checkoutPnl.Visible = false;
            returnPnl.Visible = false;
            newCustomerPnl.Visible = false;
            moviesPnl.Visible = true;
        }

        /*
         * Page and Panel Positioning Methods
         */

        private void resizePage()
        {
            positionPanel(panel1, 0, .3, .1, .95);

            positionPanel(returnPnl, .3, .95, .1, .95);
            positionPanel(checkoutPnl, .3, .95, .1, .95);
            positionPanel(newCustomerPnl, .3, .95, .1, .95);
            positionPanel(moviesPnl, .3, .95, .1, .95);

            setupReturnPnl();
            setupNewCustomerPnl();
            setupCheckoutPnl();
            Button[] buttons = { checkinBtn, newCustomerBtn, returnBtn, reportsBtn, adminBtn };
            positionButtonsVertically(buttons);
        }

        public void setupNewCustomerPnl()
        {
            positionObject(customerTitleLbl, newCustomerPnl, .4, .7, .1, .2);

            positionObject(label4, newCustomerPnl, .3, .5, .2, .3);
            positionObject(label3, newCustomerPnl, .3, .5, .3, .4);
            positionObject(label5, newCustomerPnl, .3, .5, .4, .5);

            positionObject(textBox1, newCustomerPnl, .5, .8, .2, .3);
            positionObject(textBox2, newCustomerPnl, .5, .8, .3, .4);
            positionObject(textBox3, newCustomerPnl, .5, .8, .4, .5);
        }

        public void setupCheckoutPnl()
        {
            positionObject(checkoutTitleLbl, newCustomerPnl, .4, .7, .1, .2);


            positionObject(label11, checkoutPnl, .3, .5, .2, .3);
            positionObject(label1, checkoutPnl, .302, .5, .23, .35);
            positionObject(label12, checkoutPnl, .3, .5, .3, .4);
            positionObject(label1, checkoutPnl, .3, .5, .4, .5);
            positionObject(label10, checkoutPnl, .3, .5, .5, .6);

            positionObject(textBox9, checkoutPnl, .5, .8, .2, .3);
            positionObject(textBox8, checkoutPnl, .5, .8, .3, .4);
            positionObject(textBox10, checkoutPnl, .5, .8, .4, .5);
            positionObject(textBox7, checkoutPnl, .5, .8, .5, .6);
        }

        public void setupReturnPnl()
        {
            positionObject(returnTitleLbl, newCustomerPnl, .4, .7, .1, .2);

            positionObject(label7, checkoutPnl, .3, .5, .2, .3);
            positionObject(label8, checkoutPnl, .3, .5, .3, .4);
            positionObject(label6, checkoutPnl, .3, .5, .4, .5);

            positionObject(textBox6, checkoutPnl, .5, .8, .2, .3);
            positionObject(textBox5, checkoutPnl, .5, .8, .3, .4);
            positionObject(textBox4, checkoutPnl, .5, .8, .4, .5);
        }

        /*
         * Object Repositioning Methods
         * 
         */
        
        private void positionPanel(Panel panel, double left, double right, double top, double bottom)
        {
            int formWidth = this.Width;
            int formHeight = this.Height;

            int xPos = Convert.ToInt32(formWidth * left);
            int yPos = Convert.ToInt32(formHeight * top);
            int width = Convert.ToInt32(formWidth * right) - xPos;
            int height = Convert.ToInt32(formHeight * bottom) - yPos;

            panel.Location = new Point(xPos, yPos);
            panel.Size = new Size(width, height);
        }

        private void positionObject(Control control, Panel panel, double left, double right, double top, double bottom)
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

        private void setLocation(Control control, Panel panel, double x,  double y)
        {
            int formWidth = panel.Width;
            int formHeight = panel.Height;

            int xPos = Convert.ToInt32(formWidth * x);
            int yPos = Convert.ToInt32(formHeight * y);

            control.Location = new Point(xPos, yPos);
        }

        private void positionButtonsVertically(Button[] buttons)
        {
            int numberOfButtons = buttons.Length;
            int panelWidth = panel1.Width;
            int panelHeight = panel1.Height;

            for (int i = 0; i < buttons.Length; i++)
            {
                Button button = buttons[i];

                button.Location = new Point(0, i * panelHeight / numberOfButtons);
                button.Width = panelWidth;
                button.Height = panelHeight / numberOfButtons;
            }
        } 
    }
}