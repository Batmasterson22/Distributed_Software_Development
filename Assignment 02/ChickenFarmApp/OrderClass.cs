//Name: Jason R Hodges - CSE445 - Online class
//Description: This class holds all the variable for an order also contains the order string decoder
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;

namespace ChickenFarmApp
{
    public class OrderClass
    {
        //Public getters for the varies variables in this class
        public int getSenderId() { return senderId; }                               //Get sender ID
        public int getCardNo() { return cardNo; }                                   //Get card number
        public int getNoOfChickens() { return noOfChickens; }                       //Get number of chickens
        public DateTime getTimeStamp() { return timeStamp; }                        //Get time stamp

        //Public setters for the varies variables in this class
        public void setSenderId(int senderId) { this.senderId = senderId; }         //Set sender ID
        public void setCardNo(int cardNo) { this.cardNo = cardNo; }                 //Set card numbber
        public void setNoOfChickens(int noOfChickens) { this.noOfChickens = noOfChickens; } //Set number of chicens
        public void setTimeStamp(DateTime timeStamp) { this.timeStamp = timeStamp; } //Set time stamp

        //Variables in the class
        private int senderId { get; set; }
        private int cardNo { get; set; }
        private int noOfChickens { get; set; }       
        private DateTime timeStamp { get; set; }

        //Initialize the OrderClass
        public OrderClass(int senderId, int cardNo, int noOfChickens) {
            this.senderId = senderId;
            this.cardNo = cardNo;
            this.noOfChickens = noOfChickens;
            this.timeStamp = DateTime.Now;
        }
        //Overloaded OrderClass to conserve the time stamp of the order
        public OrderClass(int senderId, int cardNo, int noOfChickens, DateTime timeStamp) {
            this.senderId = senderId;
            this.cardNo = cardNo;
            this.noOfChickens = noOfChickens;
            this.timeStamp = timeStamp;
        }
        //Decoder method takes the order in string form and converts ti back to an OrderClass object using (.Split)
        public static OrderClass Decoder(string toDecode) {
            string[] splits = toDecode.Split(',');              //Split string by ',' then adds it to an OrderClass object
            OrderClass decoded = new OrderClass(Convert.ToInt32(splits[0]), Convert.ToInt32(splits[1]), Convert.ToInt32(splits[2]), DateTime.ParseExact(splits[3], "O", CultureInfo.InvariantCulture));
            return decoded;
        }
        //To string to return the encoded order
        public string ToStringOther() {
            string strReturn = Convert.ToString(senderId) + "," + Convert.ToString(cardNo) + "," + Convert.ToString(noOfChickens) + "," + timeStamp.ToString("O");
            return strReturn;
        }
    }
}
