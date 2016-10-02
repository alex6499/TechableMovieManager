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
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            resizePage();
        }



        private void ChangeBtn_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void relocateObject(Panel panel, double left, double right, double top, double bottom)
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
        private void relocateObject(TextBox textBox, Panel panel, double left, double right, double top, double bottom)
        {
            int formWidth = panel.Width;
            int formHeight = panel.Height;

            int xPos = Convert.ToInt32(formWidth * left);
            int yPos = Convert.ToInt32(formHeight * top);
            int width = Convert.ToInt32(formWidth * right) - xPos;
            int height = Convert.ToInt32(formHeight * bottom) - yPos;

            textBox.Location = new Point(xPos, yPos);
            textBox.Size = new Size(width, height);
        }
        private void relocateObject(Label label, Panel panel, double left, double right, double top, double bottom)
        {
            int formWidth = panel.Width;
            int formHeight = panel.Height;

            int xPos = Convert.ToInt32(formWidth * left);
            int yPos = Convert.ToInt32(formHeight * top);
            int width = Convert.ToInt32(formWidth * right) - xPos;
            int height = Convert.ToInt32(formHeight * bottom) - yPos;

            label.Location = new Point(xPos, yPos);
            label.Size = new Size(width, height);
        }
        private void relocateObject(Button button, Panel panel, double left, double right, double top, double bottom)
        {
            int formWidth = panel.Width;
            int formHeight = panel.Height;

            int xPos = Convert.ToInt32(formWidth * left);
            int yPos = Convert.ToInt32(formHeight * top);
            int width = Convert.ToInt32(formWidth * right) - xPos;
            int height = Convert.ToInt32(formHeight * bottom) - yPos;

            button.Location = new Point(xPos, yPos);
            button.Size = new Size(width, height);
        }

        private void relocateButtonsSquare()
        {
            int panelWidth = panel1.Width;
            int panelHeight = panel1.Height;

            //relocate and size button1
            button1.Location = new Point(0, 0);
            button1.Width = panelWidth / 2;
            button1.Height = panelHeight / 2;
            //relocate and size button2
            button2.Location = new Point(panelWidth / 2, 0);
            button2.Width = panelWidth / 2;
            button2.Height = panelHeight / 2;
            //relocate and size button3
            button3.Location = new Point(0, panelHeight / 2);
            button3.Width = panelWidth / 2;
            button3.Height = panelHeight / 2;
            //relocate and size button4
            /*button4.Location = new Point(panelWidth / 2, panelHeight / 2);
            button4.Width = panelWidth / 2;
            button4.Height = panelHeight / 2;*/
        }



       

        private void relocateButtonsVerticle()
        {
            int panelWidth = panel1.Width;
            int panelHeight = panel1.Height;

            //relocate and size button1
            button1.Location = new Point(0, 0);
            button1.Width = panelWidth;
            button1.Height = panelHeight / 4;
            //relocate and size button2
            button2.Location = new Point(0, panelHeight / 4);
            button2.Width = panelWidth;
            button2.Height = panelHeight / 4;
            //relocate and size button3
            button3.Location = new Point(0, panelHeight / 2);
            button3.Width = panelWidth;
            button3.Height = panelHeight / 4;
            //relocate and size button4
           /* button4.Location = new Point(0, panelHeight * 3 / 4);
            button4.Width = panelWidth;
            button4.Height = panelHeight / 4;*/
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainMenu_Resize(object sender, EventArgs e)
        {
            resizePage();
        }

        private void resizePage()
        {
            //relocatePanels(panel1, .2, 1, .2, .95);
            //relocateButtonsSquare();
            relocateObject(panel1, 0, .3, .1, .95);
            relocateObject(returnPnl, .3, .95, .1, .95);
            relocateObject(checkoutPnl, .3, .95, .1, .95);
            relocateButtonsVerticle();
        }
        private void moviesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            returnPnl.Visible = false;
            checkoutPnl.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkoutPnl.Visible = false;
            returnPnl.Visible = true;

            relocateObject(returnTitleLbl, returnPnl, .35, .65, .1, .3);
           relocateObject(upcLbl, returnPnl, .4, .55, .25, .35);
           relocateObject(upcTxtBox, returnPnl, .40, .55, .35, .45);
           relocateObject(submitBtn,returnPnl, .35, .65, .45, .55);
            
            
            
        }

        private void returnPnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkoutPnl_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}