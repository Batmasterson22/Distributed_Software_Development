//Jason R Hodges
//CSE 445 - Assignment 01
//Adds function to the simple web browser, i.e. navagate to a url, Stock quote service, and Encrpt/Decrypt service
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Internets
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //when the browser is opened it's start page is wwww.google.com
            webBrowser1.Navigate(txtUrl.Text);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {   //goes to the url that is entered into the txtUrl textBox
            webBrowser1.Navigate(txtUrl.Text);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {   //Question 5: Add Encrpyt function to the browser
            EncryptionService.ServiceClient myClient = new EncryptionService.ServiceClient();

            //call the Encrypt service and passes it the string in textBox1
            //then it displays the encrpted string in eLabel
            try { eLabel.Text = myClient.Encrypt(textBox1.Text);}
            catch (Exception ec) { eLabel.Text = ec.Message.ToString(); }
            
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {   //Continue Question 5: Add Decrypt function to the browser
            EncryptionService.ServiceClient myClient2 = new EncryptionService.ServiceClient();

            //call the Decrypt service and passes it the string in eLabel
            //then it displays the encrpted string in dLabel
            try { dLabel.Text = myClient2.Decrypt(eLabel.Text); }
            catch (Exception ec) { eLabel.Text = ec.Message.ToString(); }
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {   //Question 6: Get Stock Quote Service 
            ServiceReference1.ServiceClient stockClient = new ServiceReference1.ServiceClient();
            string theCompany = textBox2.Text;      //textBox next to Enter Stock Symbol label
            companyLabel.Text = theCompany;         //displays company symbol next to current value

            //calls the getStockquote operation from the Stock Quote Service
            string theValue = stockClient.getStockquote(textBox2.Text);
            //Converts the returned string to a double
            double theNumValue = Convert.ToDouble(theValue);        
            //formats the theNumValue to look like currency
            string outValue = theNumValue.ToString("$#,##0.00");
            //displays the formated value of the current stock price
            stockValue1.Text = outValue;



        }

        
    }
}
