using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WeatherService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);


        //Project_03 - Part_01----------------------------------------------------------------------------------

        [OperationContract]
        decimal SolarIntensity(decimal latitude, decimal longitude);

        [OperationContract]
        int convertLatLong(decimal latitude, decimal longitude);

        [OperationContract]
        double[] convertZip(string zipcode);

        [OperationContract]
        string[] Weather5day(string zipcode);


        //Project_03 - Part_02----------------------------------------------------------------------------------

        [OperationContract]
        string XMLScheduler(string name, string dayToSchedule, string monthToSchedule, string timeToSchedule);

        [OperationContract]
        string[] ShoppingCart(string item, string quantity);


    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
