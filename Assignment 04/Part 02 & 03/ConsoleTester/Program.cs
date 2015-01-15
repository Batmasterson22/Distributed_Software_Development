using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2) {
                Console.WriteLine("Error: Files required not found");
                return;            
            }
            
            string appData = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Persons.xml");
            string appData2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Persons.xsl");

            addPersonService.Service1Client addPer = new addPersonService.Service1Client();

            string theReturn = addPer.transformation(appData, appData2);
            Console.WriteLine(theReturn);

            //string lastName = "hodges", firstName = "jason", id = "jaho", password = "5242", encrypt = "yes",
            //work = "4802421565", cell = "4805298594", provider = "Sprint", catagory = "Friend";

            //string theReturn = addPer.addPerson("mark,thompson,math,5245,Yes,4802452652,4807425868,Sprint,Family");
           // Console.WriteLine(theReturn);
            /*
            string[] theReturn = addPer.XPathSearch("Moose", "OtherMoose");
            Console.WriteLine(theReturn[1]);
            Console.WriteLine(theReturn[0]);
            */

            
            string x = Console.ReadLine();


        }
    }
}
