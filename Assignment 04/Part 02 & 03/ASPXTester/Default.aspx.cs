using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //This button is used to call the first operation to add a person to the xml file
    protected void Button1_Click(object sender, EventArgs e)
    {
        ServiceReference2.Service1Client toAdd1 = new ServiceReference2.Service1Client();

        string returned = "", toPass = "";

        toPass = TextBox1.Text;                     //Gets TextBox1 data
        returned = toAdd1.addPerson(toPass);        //Pass TextBox1 data to addPerson()
        Label1.Text = returned;                     //Display result from addPerson()

    }

    //This button is used to call the transformation operation for XML and XSL to HTML
    protected void Button3_Click(object sender, EventArgs e)
    {
        ServiceReference2.Service1Client toTransform = new ServiceReference2.Service1Client();
         
        string returnUrl = "", xmlUrl = "", xslUrl = "";

        xmlUrl = TextBox11.Text;                //Gets TextBox11 data
        xslUrl = TextBox12.Text;                //Gets TextBox12 data

        //Calls transformation operation passing it the two URLs for the XML and XSL files
        returnUrl = toTransform.transformation(xmlUrl, xslUrl);
        
        Label2.Text = returnUrl;                //Displays the result of the transformation operation
        
    }

    /*
    //This button is used to call the second operation to add a person to the xml file
    protected void Button2_Click(object sender, EventArgs e)
    {
        ServiceReference2.Service1Client toAdd2 = new ServiceReference2.Service1Client();

        string theReturn = "", thePass = "";

        //Creates a string from the information from TextBox2 - TextBox10 seperated by commas
        thePass = string.Format(TextBox2.Text + "," + TextBox3.Text + "," + TextBox4.Text + ","
            + TextBox5.Text + "," + TextBox6.Text + "," + TextBox7.Text + "," + TextBox8.Text
            + "," + TextBox9.Text + "," + TextBox10.Text + ",");

        theReturn = toAdd2.addPerson(thePass);          //Pass formatted string to addPerson()

        Label1.Text = theReturn;                        //Display result of addPerson()

    }*/
}