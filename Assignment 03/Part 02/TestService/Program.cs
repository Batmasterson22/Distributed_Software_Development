using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using TestService.net.webservicex.www;
using System.Net;
using System.Xml;
using System.IO;
using System.Runtime.Serialization;

namespace TestService
{
    class Program
    {
        static void Main(string[] args)
        {   
            //This is a simmple tester for the services I developed

            SolarService.Service1Client myStuff = new SolarService.Service1Client();
            decimal lat = 33.296991M;
            decimal lon = -111.788652M;
            decimal anInt = myStuff.SolarIntensity(lat, lon);
            Console.WriteLine("The UV Index of {0}, {1} is {2}",lat, lon, anInt);
            
            //http://www.geoplugin.net/extras/postalcode.gp?lat=33.296991&long=-111.788652&format=xml

            double[] answer = myStuff.convertZip("85296");

            Console.WriteLine("Lat: {0}\nLong: {1}", answer[0], answer[1]);

            string[] theAnswer = myStuff.Weather5day("85296");


            for (int j = 0; j < 5; j++) {
                Console.WriteLine(theAnswer[j]);

            }

            Console.WriteLine("\n");
            
            string someStuff = "";
            string[] someDis = new String[2];
             
            //someStuff = myStuff.XMLScheduler("Tom Ripa", "03", "07", "2");
            //Console.WriteLine(someStuff + "\n");

            //someDis = myStuff.ShoppingCart("XCS1432", "5");
            //Console.WriteLine(someDis[0]);

            //someStuff = myStuff.CreditCard("124-254-245-37", someDis[1]);
            //Console.WriteLine(someStuff);

            string cardNum = "124-562-589-658";
            string amount = "1188";

            //http://localhost:3174/CreditCardService/Service1.svc/CreditCard/124-562-589-658/1188

            string testURL = "http://localhost:3174/CreditCardService/Service1.svc";
            string testURL2 = "CreditCard/{0}/{1}";

            Uri baseUri = new Uri(testURL);
            UriTemplate myTemplate = new UriTemplate(testURL2);
            Uri completeUri = myTemplate.BindByPosition(baseUri, cardNum, amount);
            WebClient channel = new WebClient();
            byte[] abc = channel.DownloadData(completeUri);
            Stream strm = new MemoryStream(abc);
            DataContractSerializer obj = new DataContractSerializer(typeof(string));
            string randString = obj.ReadObject(strm).ToString();

            Console.WriteLine(randString);

            Console.ReadLine();
        }
    }
}

