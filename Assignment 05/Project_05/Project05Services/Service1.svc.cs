using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Encryption;

namespace Project05Services
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

        //This operation is used to check if the passed string matches a name in Credentials.xml
        public string[] checkXML(string toCheck, string password, bool checkBox)
        {
            string tempToCheck = "", tempPassword = "";
            
            string[] theResult = new String[3];
            theResult[0] = "Nothing";
            theResult[1] = "";
            theResult[2] = "";

            try
            {
                tempToCheck = Encrypt_Decrypt.Decrypt(toCheck);
                tempPassword = Encrypt_Decrypt.Decrypt(password);
            }
            catch (Exception ecx) { theResult[0] = ecx.Message; }

            //Path for the location for Credentials.xml file
            string appData1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/Credentials.xml");
            string xmlCheck1 = string.Format("Credentials/Member/" + tempToCheck + "/Password");
            string xmlCheck2 = string.Format("Credentials/Member/" + tempToCheck + "/Type");
            string xmlCheck3 = string.Format("Credentials/Member/" + tempToCheck);

            //This block uses XmlDocument to search through the XML by Member Name the check if the 
            //password that was entered matches the one in the XML file
            try
            {
                XmlDocument xml1 = new XmlDocument();
                xml1.Load(appData1);

                if (xml1.SelectSingleNode(xmlCheck3) != null)
                {
                    theResult[0] = "Unavailable";

                    if (xml1.SelectSingleNode(xmlCheck1).InnerText.Equals(tempPassword)
                        && checkBox == false)
                    {
                        theResult[1] = "Correct";
                        theResult[2] = xml1.SelectSingleNode(xmlCheck2).InnerText;                    
                    }
                    else
                    {
                        theResult[1] = "Incorrect";
                    }

                }
                else
                { theResult[0] = "Available"; }

            }
            catch (Exception ecx) { theResult[0] = ecx.Message; }

            return theResult; 
        }

        //Use a data contract as illustrated in the sample below to add composite types to service operations.
        public string addToXML(string name, string password, string type)
        {
            string confirm = "nothing";
            //Path for the location for Credentials.xml file
            string appData2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/Credentials.xml");

            //This block uses XElement to add a new member to the XML file
            try
            {
                XElement xml2 = XElement.Load(appData2);
                xml2.Add(new XElement("Member",
                    new XElement(name,  new XElement("Password", password), new XElement("Type", type))));
                xml2.Save(appData2);
                confirm = "Thank you for registering " + name + ", you have " + type + " access.";

            }
            catch (Exception ecx) { confirm = ecx.Message; }

            return confirm;
        }

    }
}
