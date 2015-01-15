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
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Part02Services
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

        //This operation is used to add a person to the existing Persons.xml
        public string addPerson(string toAdd)
        {
            string toReturn = "Nothing Entered";
            string lastName = "", firstName = "", id = "", password = "", encrypt = "", work = "", cell = "", provider = "", catagory = "";
            string appData = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/Persons.xml");
            string[] theData = new String[9];

            //this uses Split to seperate the various elements to be added
            theData = toAdd.Split(',');

            //this block set the array elements from Split to various string to make XElement easier to read
            lastName = theData[0];
            firstName = theData[1];
            id = theData[2];
            password = theData[3];
            encrypt = theData[4];
            work = theData[5];
            cell = theData[6];
            provider = theData[7];
            catagory = theData[8];

            try
            {   
                //This block is used to add the new person to the XML file using XElement (Problem 2.5)
                XElement xml = XElement.Load(appData);
                xml.Add(new XElement("Person",
                    new XElement("Name", new XElement("First", firstName), new XElement("Last", lastName)),
                    new XElement("Credential", new XElement("Id", id), new XElement("Password", new XAttribute("Encryption", encrypt), password)),
                    new XElement("Phone", new XElement("Work", work), new XElement("Cell", new XAttribute("Provider", provider), cell)),
                    new XElement("Categpry", catagory)
                    ));
                xml.Save(appData);                          //Save the modified XML file
                toReturn = "The Person Has Been Added";     //If everything works return a conformation
            }
            catch (Exception ecx) { toReturn = ecx.Message; }

            return toReturn;
        }

        //This operation is used to transform a XML and XSL to the corresponding HTML file (Problem 2.2)
        public string transformation(string xmlUrl, string xslUrl)
        {
            string theReturn = "Nothing Entered";

            try
            {   
                //This block uses XPath and XslCompiledTransform to generate the HML
                XPathDocument doc = new XPathDocument(xmlUrl);
                StringWriter strWrite = new StringWriter();                 //StringWriter for temp data storage
                XslCompiledTransform xslt = new XslCompiledTransform();
                xslt.Load(xslUrl);
                xslt.Transform(doc, null, strWrite);                        //Transforms the files
                theReturn = strWrite.ToString();                    //Sets the StringWriter to the return string

            }
            catch (Exception ec)
            {
                theReturn = ec.Message;
            }

            return theReturn;
        }

    }
}
