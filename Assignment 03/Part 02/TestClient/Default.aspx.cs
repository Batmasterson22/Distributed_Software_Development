using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    static string thePrice = "0";

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
        catch (Exception ec) { Console.WriteLine("Not a valid input: " + ec); }

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
        catch (Exception ec) { Console.WriteLine("Not a valid input: " + ec); }


    }

    protected void buyButton_Click(object sender, EventArgs e)
    {   
        TestServices.Service1Client theTest3 = new TestServices.Service1Client();
        string[] tempReturnBuy = {""};
        string tempBuy1 = "", tempBuy2 = "";

        try
        {  
            //Get information from the two text boxes
            tempBuy1 = buyTB1.Text;
            tempBuy2 = buyTB2.Text;
            //This calls the ShoppingCart operation in the Service1 service
            tempReturnBuy = theTest3.ShoppingCart(tempBuy1, tempBuy2);
            //Adds the returned string to the buyLabel
            buyLabel.Text = tempReturnBuy[0];
            //Set the returned price to the static thePrice varaible
            thePrice = tempReturnBuy[1];

        }
        catch (Exception ecx)
        {
            Console.WriteLine("Exception occured in Buy: " + ecx);
        }

    }

    protected void creditButton_Click(object sender, EventArgs e)
    {
        string cardNum = "";
        //Get information from the creditTB1 text box and set it to cardNum
        cardNum = creditTB1.Text;

        //This strings are used to access the RESTful service location
        string testURL = "http://localhost:3174/CreditCardService/Service1.svc";
        string testURL2 = "CreditCard/{0}/{1}";

        try
        {
            if (thePrice == "0")
            {   
                //No order placed error check
                creditLabel.Text = "No order has been requested, please add items to the shopping cart";
            }
            else
            {   
                //This block is used to access the RESTful service by going to the service URL and pass
                //it the string from the text box and the static thePrice variable
                Uri baseUri = new Uri(testURL);
                UriTemplate myTemplate = new UriTemplate(testURL2);
                Uri completeUri = myTemplate.BindByPosition(baseUri, cardNum, thePrice);
                WebClient channel = new WebClient();
                byte[] abc = channel.DownloadData(completeUri);
                Stream strm = new MemoryStream(abc);
                DataContractSerializer obj = new DataContractSerializer(typeof(string));
                string randString = obj.ReadObject(strm).ToString();

                //This displays the returned string from accessing the RESTful service
                creditLabel.Text = randString;
            }
        }
        catch (Exception ecx)
        {
            Console.WriteLine("Exception occured in Credit: " + ecx);
        }
        
    }

    protected void schButton_Click(object sender, EventArgs e)
    {   
        TestServices.Service1Client theTest5 = new TestServices.Service1Client();
        string tempSch1 = "", tempSch2 = "", tempSch3 = "", tempSch4 = "", tempRetSch = "";
        
        //This block gets the various variables from the four text boxes
        tempSch1 = nameTB.Text;
        tempSch2 = monthTB.Text;
        tempSch3 = dayTB.Text;
        tempSch4 = timeTB.Text;

        //Calls the XMLScheduler operation the WeatherService service
        tempRetSch = theTest5.XMLScheduler(tempSch1, tempSch3, tempSch2, tempSch4);
        //Displays the returned string from the XMLScheduler operation
        schLabel.Text = tempRetSch;



    }
}