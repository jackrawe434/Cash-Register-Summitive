using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;


namespace Cash_Register_Summitive
{
    public partial class Ye_Olde_Saloon : Form
    {
        //declaire Variables
        const double ALE_PRICE = 4.99;
        const double WHISKEY_PRICE = 7.85;
        const double CHOICE_PRICE = 11.15;
        const double TAX_VALUE = 0.13;
        double numberOfAle;
        double numberOfWhiskey;
        double numberOfChoice;
        double subtotal;
        double tax;
        double total;
        double tendered;
        double change;
        double aleTotal;
        double whiskeyTotal;
        double choiceTotal;

        public Ye_Olde_Saloon()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Number of objects declaration
                numberOfAle = Convert.ToDouble(aleUpDown.Text);
                numberOfWhiskey = Convert.ToDouble(whiskeyUpDown.Text);
                numberOfChoice = Convert.ToDouble(choiceUpDown.Text);

                aleTotal = numberOfAle * ALE_PRICE;
                whiskeyTotal = numberOfWhiskey * WHISKEY_PRICE;
                choiceTotal = numberOfChoice * CHOICE_PRICE;

                //Calculations
                subtotal = aleTotal + whiskeyTotal + choiceTotal;
                tax = subtotal * TAX_VALUE;
                total = subtotal + tax;

                //Display to labels
                subTotalAmountLabel.Text = (subtotal.ToString("C"));

                taxAmountLabel.Text = (tax.ToString("C"));

                totalAmountLabel.Text = (total.ToString("C"));
            }

            catch
            { receptLabel.Text = "The Bartender Ain't Smart Enough To Read Letters!!!"; }
        }

        private void CalculateTenderedButton_Click(object sender, EventArgs e)
        {//Graphics set up
            Graphics g = receptLabel.CreateGraphics();
            Font blackFont = new Font("Courier New", 10, FontStyle.Bold);
            SolidBrush blackText = new SolidBrush(Color.Black);


            //Variable declaration for tendered
            try
            {
                tendered = Convert.ToDouble(tenderedBox.Text);
            }
            catch
            {
                g.Clear(Color.White);
                g.DrawString("Hold Your Horses! You Gotta Pay Up!", blackFont, blackText, 10, 50);
            }

            if (tendered < total)
            {
                g.DrawString("\n\nYou Gotta Pay The Full Amount!", blackFont, blackText, 10, 50);
                changeAmountLabel.Text = "0";
            }


            //Calculations for tendered
           // subtotal = numberOfAle * ALE_PRICE + numberOfWhiskey * WHISKEY_PRICE + numberOfChoice * CHOICE_PRICE;
            tax = subtotal * TAX_VALUE;
            total = subtotal + tax;
            change = tendered - total;

            //display to label
            changeAmountLabel.Text = (change.ToString("C"));
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            //String creation
            Graphics g = receptLabel.CreateGraphics();
            Font blackFont = new Font("Courier New", 10, FontStyle.Bold);
            SolidBrush blackText = new SolidBrush(Color.Black);
            g.DrawString("Ye Olde Saloon", blackFont, blackText, 100, 12);
       
            //Sound set up
            SoundPlayer printSound = new SoundPlayer(Properties.Resources.Printer_noise);
            SoundPlayer openSound = new SoundPlayer(Properties.Resources.Cash_Open);

            Thread.Sleep(100);

            //Printer text code
            g.DrawString("Ale " + "x" + numberOfAle + " @     " + aleTotal.ToString("C"), blackFont, blackText, 10, 50);
            printSound.Play();
            Thread.Sleep(200);
            g.DrawString("Whiskey " + "x" + numberOfWhiskey + " @ " + whiskeyTotal.ToString("C"), blackFont, blackText, 10, 70);
            printSound.Play();
            Thread.Sleep(200);
            g.DrawString("Choice " + "x" + numberOfChoice + " @  " + choiceTotal.ToString("C"), blackFont, blackText, 10, 90);
            printSound.Play();
            Thread.Sleep(200);
            g.DrawString("Subtotal     " + subtotal.ToString("C"), blackFont, blackText, 10, 110);
            printSound.Play();
            Thread.Sleep(200);
            g.DrawString("Tax          " + tax.ToString("C"), blackFont, blackText, 10, 130);
            printSound.Play();
            Thread.Sleep(200);
            g.DrawString("Total        " + total.ToString("C"), blackFont, blackText, 10, 150);
            printSound.Play();
            Thread.Sleep(200);
            g.DrawString("Tendered     " + tendered.ToString("C"), blackFont, blackText, 10, 170);
            printSound.Play();
            Thread.Sleep(200);
            g.DrawString("Change       " + change.ToString("C"), blackFont, blackText, 10, 190);
            printSound.Play();
            Thread.Sleep(200);
            g.DrawString("Have a Boot Slappin Day!!!", blackFont, blackText, 10, 210);
            openSound.Play();
        }

        private void NewCustomerButton_Click(object sender, EventArgs e)
        {
            Graphics g = receptLabel.CreateGraphics();
            g.Clear(Color.White);

            changeAmountLabel.Text = "0";
            subTotalAmountLabel.Text = "0";
            taxAmountLabel.Text = "0";
            tenderedBox.Text = "0";
            totalAmountLabel.Text = "0";
            aleUpDown.Text = "0";
            whiskeyUpDown.Text = "0";
            choiceUpDown.Text = "0";
            double numberOfAle = 0;
            double numberOfWhiskey = 0;
            double numberOfChoice = 0;
            double subtotal = 0;
            double tax = 0;
            double total = 0;
            double tendered = 0;
            double change = 0;
            double aleTotal = 0;
            double whiskeyTotal = 0;
            double choiceTotal = 0;
        }
    }
}
