using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        TestServices.Service1Client theTest = new TestServices.Service1Client();
        try {   
            //This operation takes the takes the inputs from 2 textboxes and passes them to SolarIntensity service
            decimal tempLat = Convert.ToDecimal(TextBox1.Text);
            decimal tempLon = Convert.ToDecimal(TextBox2.Text);
            decimal finalAnswer = theTest.SolarIntensity(tempLat, tempLon);
            Label2.Text = Convert.ToString(finalAnswer);

        }
        catch (Exception ec) { Console.WriteLine("Not a valid input"); }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TestServices.Service1Client theTest2 = new TestServices.Service1Client();

        try {
            //This operation takes the takes the inputs from textboxe and passes it to Weather5day service
            string tempZip = zipTextBox.Text;
            string[] theAnswer = theTest2.Weather5day(tempZip);
            //Displays the 5 day forecast
            Label8.Text = theAnswer[0];
            Label9.Text = theAnswer[1];
            Label10.Text = theAnswer[2];
            Label11.Text = theAnswer[3];
            Label12.Text = theAnswer[4];

        }
        catch (Exception ec) { Console.WriteLine("Not a valid input"); }


    }
}