using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.XPath;

namespace WeatherService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class UVService : IService1
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
        //This operation uses developer.nrel.gov solar resource to get the Solar intensity by latitude and longitude
        public decimal SolarIntensity(decimal latitude, decimal longitude) {
            //developer.nrel.gov URL
            string uvIndexUrl = "http://developer.nrel.gov/api/solar/solar_resource/v1.xml?api_key=X2WMyLdge3vNTSvW9bLjhw7yHDk4NpDRRHTxKVk3&lat={0}&lon={1}";
            //Variables for this operation
            string finUrl = "";
            double uvIndex = 0.0D;
            decimal converted = 0.0M;
            try { 
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
            }
            catch (Exception ec) { Console.WriteLine("Cannot convert"); }
            if (converted == 0.0M)
                converted = 3.7M;
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
                XPathNodeIterator xnode3 = xset4.Current.Select("value");
                xnode3.MoveNext();
                intArray[0] = xnode3.Current.ValueAsInt;
                xnode3.MoveNext();
                intArray[1] = xnode3.Current.ValueAsInt;
                xnode3.MoveNext();
                intArray[2] = xnode3.Current.ValueAsInt;
                xnode3.MoveNext();
                intArray[3] = xnode3.Current.ValueAsInt;
                xnode3.MoveNext();
                intArray[4] = xnode3.Current.ValueAsInt;
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

    }
}
