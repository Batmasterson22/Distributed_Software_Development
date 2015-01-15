using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTheServices
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client theGoods = new ServiceReference1.Service1Client();

            string app1 = "http://webstrar11.fulton.asu.edu/page1/Persons.xml";
            string app2 = "http://webstrar11.fulton.asu.edu/page1/Persons.xsl";

            string theReturned = theGoods.transformation(app1, app2);
            //Cunningham,John,jocu,1452,Yes,4802451856,4802462594,TMobile,Work
            Console.WriteLine(theReturned);

            theReturned = theGoods.addPerson("Nash,Steve,stna,1452,Yes,4802451856,4802462594,TMobile,Work");

            Console.WriteLine(theReturned);
            Console.ReadLine();
        }
    }
}
