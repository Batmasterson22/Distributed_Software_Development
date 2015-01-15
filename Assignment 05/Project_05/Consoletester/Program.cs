using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Consoletester
{
    class Program
    {
        static void Main(string[] args)
        {
            Project05Services.Service1Client toServ = new Project05Services.Service1Client();
            //XmlServices.Service1Client toServ = new XmlServices.Service1Client();
           
            string[] toche = new String[3];
            toche = toServ.checkXML("Jason", "1245", false);

            Console.WriteLine("1: " + toche[0]);
            Console.WriteLine("2: " + toche[1]);
            Console.WriteLine("3: " + toche[2]);

            toche = toServ.checkXML("Jason", "1555", true);
            Console.WriteLine("4: " + toche[0]);
            Console.WriteLine("5: " + toche[1]);
            Console.WriteLine("6: " + toche[2]);

            toche = toServ.checkXML("Jordan", "1555", true);
            Console.WriteLine("4: " + toche[0]);
            Console.WriteLine("5: " + toche[1]);
            Console.WriteLine("6: " + toche[2]);

            
            toche[0] = toServ.addToXML("Moris", "1152", "Member");
            Console.WriteLine(toche[0]);


            /*
             * 
             * 
            1: Unavailable
            2: Correct
            3: member
             * 
            4: Unavailable
            5: Incorrect
            6:
             * 
            4: Avaiable
            5:
            6:
            Thank you for registering Moris, you have Member access.
            Press any key to continue . . .
             * 
             * 
             * 
            Available
            Thank you for registering Moris, you have Member access.
            Press any key to continue . . .
             */

            /*
            That name is unavailable, please choose another.
            Thank you for registering Moris, you have Member access.
            Press any key to continue . . .
             */

        }
    }
}
