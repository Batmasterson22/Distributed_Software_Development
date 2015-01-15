using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Hosting;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace WeatherService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class UVService : IService1
    {
        string[, ,] calendar = new string[30, 90, 12];

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


        //CSE445 - Project 03 - Part 01
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //This operation uses developer.nrel.gov solar resource to get the Solar intensity by latitude and longitude
        public decimal SolarIntensity(decimal latitude, decimal longitude) {
            //developer.nrel.gov URL
            string uvIndexUrl = "http://developer.nrel.gov/api/solar/solar_resource/v1.xml?api_key=X2WMyLdge3vNTSvW9bLjhw7yHDk4NpDRRHTxKVk3&lat={0}&lon={1}";
            //Variables for this operation
            string finUrl = "";
            var uvIndex = 0.0D;
            decimal converted = 0.0M;
            finUrl = string.Format(uvIndexUrl, latitude, longitude);

            //Use XPath to navigate through the XML returned from the service
            XPathDocument xdoc2 = new XPathDocument(finUrl);
            XPathNavigator xpdoc2 = xdoc2.CreateNavigator();
            XPathNodeIterator xset2 = xpdoc2.Select("/response/outputs/avg-dni");

            //This loop sets the temp uvIndex to the annual Solar index
            while (xset2.MoveNext())
            {
                XPathNodeIterator xnode = xset2.Current.Select("annual");
                xnode.MoveNext();
                uvIndex = xnode.Current.ValueAsDouble;
            }
            //Converts the uvIndex string to a decimal
            converted = Convert.ToDecimal(uvIndex);

            return converted;
        }
        //This operations is used to convert latitude and longituded to the appropriate zipcode
        public int convertLatLong(decimal latitude, decimal longitude) {
            //geoplugin.net URL
            string latLongUrl = "http://www.geoplugin.net/extras/postalcode.gp?lat={0}&long={1}&format=xml";
            int theZip = 0;
            string finalUrl = string.Format(latLongUrl, latitude, longitude);

            //Use XPath to navigate through the XML returned from the service
            XPathDocument xdoc = new XPathDocument(finalUrl);
            XPathNavigator xpdoc = xdoc.CreateNavigator();
            XPathNodeIterator xset = xpdoc.Select("/geoPlugin");

            //This loop sets theZip to the postal code
            while (xset.MoveNext()) {
                XPathNodeIterator xnode = xset.Current.Select("geoplugin_postCode");
                xnode.MoveNext();
                theZip = xnode.Current.ValueAsInt;
            }
            return theZip;
        }
        //This operation converts a zipcode to the corresponding latitude and longitude 
        public double[] convertZip(string zipcode) {
            //maps.googleapis.com URL
            string zipUrl = "https://maps.googleapis.com/maps/api/geocode/xml?address={0}";
            string zipFinal = string.Format(zipUrl, zipcode);
            double[] theReturn = new Double[2];

            //Use XPath to navigate through the XML returned from the service
            XPathDocument xdoc3 = new XPathDocument(zipFinal);
            XPathNavigator xpdoc3 = xdoc3.CreateNavigator();
            XPathNodeIterator xset3 = xpdoc3.Select("/GeocodeResponse/result/geometry/location");

            //This loop sets the first 2 elements of theReturn array to the latitude and longitude
            while (xset3.MoveNext())
            {
                XPathNodeIterator xnode3 = xset3.Current.Select("lat");
                xnode3.MoveNext();
                theReturn[0] = xnode3.Current.ValueAsDouble;
                xnode3 = xset3.Current.Select("lng");
                xnode3.MoveNext();
                theReturn[1] = xnode3.Current.ValueAsDouble;
            }
            
            return theReturn;
        }
        //This operation is used to return the 5 day forecast for a spicific zipcode
        public string[] Weather5day(string zipcode) {
            //graphical.weather.gov URL
            string theWeatherUrl = "http://graphical.weather.gov/xml/SOAP_server/ndfdXMLclient.php?whichClient=NDFDgen&lat={0}&lon={1}&listLatLon=&lat1=&lon1=&lat2=&lon2=&resolutionSub=&listLat1=&listLon1=&listLat2=&listLon2=&resolutionList=&endPoint1Lat=&endPoint1Lon=&endPoint2Lat=&endPoint2Lon=&listEndPoint1Lat=&listEndPoint1Lon=&listEndPoint2Lat=&listEndPoint2Lon=&zipCodeList=&listZipCodeList=&centerPointLat=&centerPointLon=&distanceLat=&distanceLon=&resolutionSquare=&listCenterPointLat=&listCenterPointLon=&listDistanceLat=&listDistanceLon=&listResolutionSquare=&citiesLevel=&listCitiesLevel=&sector=&gmlListLatLon=&featureType=&requestedTime=&startTime=&endTime=&compType=&propertyName=&product=glance&begin=2004-01-01T00%3A00%3A00&end=2018-06-15T00%3A00%3A00&Unit=e&maxt=maxt&mint=mint&Submit=Submit";
            string[] strArray = new String[5];
            int[] intArray = new Int32[5];
            string temp1 = "", temp2 = "";
            double[] dBZip = convertZip(zipcode); //Calls convertZip operation above and passes it the zipcode variable
            int tempInt = 0;
            //Temp variables to hold the latitude and longitude from convertZip
            temp1 = Convert.ToString(dBZip[0]);
            temp2 = Convert.ToString(dBZip[1]);

            string finalZip = string.Format(theWeatherUrl, temp1, temp2);

            //Use XPath to navigate through the XML returned from the service
            XPathDocument xdoc4 = new XPathDocument(finalZip);
            XPathNavigator xpdoc4 = xdoc4.CreateNavigator();
            XPathNodeIterator xset4 = xpdoc4.Select("/dwml/data/parameters/temperature");

            //This loop sets the elements of intArray to different temperature values
            while (xset4.MoveNext()) {
                XPathNodeIterator xnode4 = xset4.Current.Select("value");
                xnode4.MoveNext();
                intArray[0] = xnode4.Current.ValueAsInt;
                xnode4.MoveNext();
                intArray[1] = xnode4.Current.ValueAsInt;
                xnode4.MoveNext();
                intArray[2] = xnode4.Current.ValueAsInt;
                xnode4.MoveNext();
                intArray[3] = xnode4.Current.ValueAsInt;
                xnode4.MoveNext();
                intArray[4] = xnode4.Current.ValueAsInt;
            }

            //This loop is used to make a single string from the High and Low temps then adds it to the strArray that is returned
            for (int j = 0; j < 5; j++)  {
                tempInt = intArray[j];
                tempInt += 31;
                temp1 = Convert.ToString(tempInt);
                temp2 = Convert.ToString(intArray[j]);
                strArray[j] = string.Format("Min Temp of {0} / Max Temp of {1}", temp2, temp1);

            }

            return strArray;
        }


        //CSE445 - Project 03 - Part 02
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        //This operation is used to schedule an solar panel installation time, it uses XML to store the schedule
        public string XMLScheduler(string name, string dayToSchedule, string monthToSchedule, string timeToSchedule)
        {   
            //Variables to be used in this operation
            string resp = "";
            XmlDocument txtRead = new XmlDocument();
            string retSch = "", amPM = "AM", currentMonth = "", currentHr = timeToSchedule;
            string[] months = { "Start", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };            
            int day = 0, month = 0, hour = 0, tempHour = 0;

            //Converts the string variables to integers so various calculations can be performed
            day = Convert.ToInt32(dayToSchedule);
            month = Convert.ToInt32(monthToSchedule);
            hour = Convert.ToInt32(timeToSchedule);
            currentMonth = months[month];

            //Converts the time to military 24 hour time so the XML file won't have duplicate values
            if (hour >= 1 && hour <= 6)
                hour += 12;
            
            //These strings will be used to navigate the XML file to a specific element
            string xmlCheck = string.Format("month/{0}/Day{1:00}/Time{2:00}", currentMonth, day, hour);
            string xmlCheck2 = string.Format("{0}/Day{1:00}/Time{2:00}", currentMonth, day, hour);

            //this string is used to find where the XML file is stored
            string appData = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "Schedule.xml");

            try
            {   
                //Checks if the chosen time is during the open hours of the company
                if (hour >= 8 && hour <= 18)
                {   
                    if (hour >= 12)             //This statment converts the time of day to PM if it 12 or after
                        amPM = "PM";

                    if (hour >= 13)             //Converts hour from military to 12 hour time
                    {
                        hour -= 12;
                        currentHr = Convert.ToString(hour);
                    }

                    //Loads the XML file so that it can be read or modified
                    txtRead.Load(appData);
                    //This is used to navigate to the specific day and set it's value to retSch
                    retSch = txtRead.SelectSingleNode(xmlCheck).InnerText;

                    //Checks if the specific day has already been scheduled, if it is open it proceed
                    if (retSch.Equals(""))
                    {   
                        //Return string to confirm the installation appointment time
                        resp = string.Format("{0} your appointment for solar installation "
                            + "is at {1}{2} on {3}/{4}", name, currentHr, amPM, currentMonth, dayToSchedule);

                        //Enters the name of the person who is scheduling the appointment into the XML file
                        txtRead.SelectSingleNode(xmlCheck).InnerText = name;
                        //Saves the modifications to the XML file
                        txtRead.Save(appData);
                      
                    } else
                    {
                        resp = "I'm sorry that time is unavailable, please choose another time.";
                    }

                } else 
                {
                    resp = "Sorry the installations are only scheduled between 8AM - 6PM";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Invaild Input: " + ex);
            }

            return resp;
        }
        //This operation is used to check the inventory and calculate price. Inventory is store in a XML file
        public string[] ShoppingCart(string item, string quantity)
        {
            //Variables to be used in this operation
            string[] solarPanels = { "XCS1432", "XDF2283", "XKS5476" };
            string[] toReturn = new String[2];
            Boolean found = false;
            XmlDocument theStock = new XmlDocument();
            int currentStock = 0, currentQuan = 0, currentPrice = 0;
            double totalPrice = 0D;

            //These strings are used to navigate the XML file to a specific element
            string xmlStock = string.Format("SolarPanel/Model/{0}/Quantity", item);
            string xmlPrice = string.Format("SolarPanel/Model/{0}/Price", item);

            //this string is used to find where the XML file is stored
            string appData2 = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "SolarPanelStock.xml");

            //This loop checks if the item number is valid
            for (int i = 0; i < solarPanels.Length - 1; i++)
            {
                if (item == solarPanels[i])
                    found = true;         
            }

            //If the item number is not found it returns an error message
            if (found == false)
            {
                toReturn[0] = "The item number is incorrect, please enter another one.";
                toReturn[1] = "Error1";
                return toReturn;
            }

            try
            {   
                //Loads the XML file using XmlDocument
                theStock.Load(appData2);

                //Converts the string variables to integers so various calculations can be performed
                currentStock = Convert.ToInt32(theStock.SelectSingleNode(xmlStock).InnerText);
                currentQuan = Convert.ToInt32(quantity);
                currentPrice = Convert.ToInt32(theStock.SelectSingleNode(xmlPrice).InnerText);

                //This checks if there are enough solar panels in stock to complete the order
                if (currentQuan <= currentStock)
                {   
                    //Calculate the total cost with 8.0% tax added
                    totalPrice = currentPrice * currentQuan * 1.08;
                    //Subtract the quantity ordered from the amount in stock
                    currentStock -= currentQuan;
                    //This updates the new amount in stock in the XML file
                    theStock.SelectSingleNode(xmlStock).InnerText = Convert.ToString(currentStock);
                    //Saves the modifications to the XML file
                    theStock.Save(appData2);

                    //These set the return string array to a string describing the order and the total price
                    toReturn[0] = string.Format("The total cost for {0} - {1} solar panels is {2:C2}.", quantity, item, totalPrice);
                    toReturn[1] = Convert.ToString(totalPrice);

                    return toReturn;

                }
                else
                {   
                    toReturn[0] = "There is not enough solar panels in stock to fill this order";
                    toReturn[1] = "Error2";
                    return toReturn;
                }

            }
            catch (Exception exc)
            {
                toReturn[0] = ("Exception: " + exc);
                toReturn[1] = "Error3";
                return toReturn;
            }

        }
        //This operation is used to validate a credit card number then charge it if it is valid
      


    }
}
