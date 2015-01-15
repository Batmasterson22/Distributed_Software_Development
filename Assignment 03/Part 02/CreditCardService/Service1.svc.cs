using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CreditCardService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
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

        //This operation is the required RESTful service and it is used to validate a credit card number 
        //then charge the card if it is valid
        public string CreditCard(string creditCard, string totalPrice)
        {
            //Variables to be used in this operation
            string sPattern = "^\\d{3}-\\d{3}-\\d{3}-\\d{3}$";
            double toPrice = Convert.ToDouble(totalPrice);


            //Checks if the credit card matches the pattern
            if (System.Text.RegularExpressions.Regex.IsMatch(creditCard, sPattern))
            {
                //If the credit card is valid and returns the message if it is.
                return string.Format("\nThis Your order is complete and your credit card has been charged"
                + " for {0:C2}\nThank you for your business and don't forget to schedule an installation time", toPrice);

            }
            else
            {
                return "You entered an incorrect credit card number, please try again.";

            }

        }


    }
}
