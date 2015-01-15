//Jason R Hodges
//CSE 445 - Assignment 01
//Adds function to the simple temp conversion GUI
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TempConvGUI.TempConvService;  //Includes the TempConvService to be used in the the GUI

namespace TempConvGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Operation for the celsius to fahrenheit button
        private void cel2Fah_Click(object sender, EventArgs e)
        {
            //Create TempConvService object
            Service1Client celToFah = new Service1Client();     
            //Variables for int from textBox1 and int to display the converted value
            int degree = 0;                             
            int answer1 = 0;

            try{
                degree = Convert.ToInt32(this.textBox1.Text);   //Gets string from textBox1 and converts to an int
                answer1 = celToFah.c2f(degree);                 //calls c2f function in TempConvService
                this.answerLabel.Text = answer1.ToString();     //Displats the converted value in answerLabel
            }
            catch { MessageBox.Show("Not an integer"); }        //catch any no integers that are entered
            
        }

        //Operation for the fahrenheit to celsius button
        private void fah2Cel_Click(object sender, EventArgs e)
        {
            //Create TempConvService object
            Service1Client fahToCel = new Service1Client();
            //Variables for int from textBox1 and int to display the converted value
            int degree = 0;
            int answer1 = 0;

            try
            {
                degree = Convert.ToInt32(this.textBox1.Text);   //Gets string from textBox1 and converts to an int
                answer1 = fahToCel.f2c(degree);                 //calls f2c function in TempConvService
                this.answerLabel.Text = answer1.ToString();     //Displats the converted value in answerLabel
            }
            catch { MessageBox.Show("Not an integer"); }        //catch any no integers that are entered
        }
    }
}
