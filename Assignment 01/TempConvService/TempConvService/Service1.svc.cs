//Jason R Hodges
//CSE 445 - Assignment 01
//Conatins the operations of the tempature conversion service
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TempConvService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        //Operation containing the algorithm for celsius to fahrenheit conversion
        public int c2f(int c)
        {   
            float x = ((((float)9 / 5) * c) + 32);  //algorithm for celsius to fahrenheit conversion
            int answer1 = Convert.ToInt32(x);       //converts float x to an integer
            return answer1;                         //return converted tempature
        }

        //Operation containing the algorithm for fahrenheit to celsius conversion
        public int f2c(int f)
        {
            float v = ((f - 32) * ((float)5 / 9));  //algorithm for fahrenheit to celsius conversion
            int answer2 = Convert.ToInt32(v);       //converts float v to an integer
            return answer2;                         //return converted tempature
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
