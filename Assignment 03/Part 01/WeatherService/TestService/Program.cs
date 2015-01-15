using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using TestService.net.webservicex.www;
using System.Net;

namespace TestService
{
    class Program
    {
        static void Main(string[] args)
        {   
            //This is a simmple tester for the services I developed

            SolarService.Service1Client myStuff = new SolarService.Service1Client();
            decimal lat = 34.05M;
            decimal lon = -118.25M;
            decimal anInt = myStuff.SolarIntensity(lat, lon);
            Console.WriteLine("The UV Index of {0}, {1} is {2}",lat, lon, anInt);
            
            //http://www.geoplugin.net/extras/postalcode.gp?lat=33.296991&long=-111.788652&format=xml

            double[] answer = myStuff.convertZip("85296");

            Console.WriteLine("Lat: {0}\nLong: {1}", answer[0], answer[1]);

            string[] theAnswer = myStuff.Weather5day("85296");


            for (int j = 0; j < 5; j++) {
                Console.WriteLine(theAnswer[j]);

            }

            Console.ReadLine();
        }
    }
}

