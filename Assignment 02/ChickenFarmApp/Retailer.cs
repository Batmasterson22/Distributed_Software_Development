//Name: Jason R Hodges - CSE445 - Online class
//Description: This retailer class is used to act like a customer of the chicken farm. It checks the amount
//of chickens in stock, determines if more need to be ordered, then places an order by encoding it to a string
//and pass it to the buffer.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;

namespace ChickenFarmApp
{
    public class Retailer
    {
        //Public getters for the varies variables in this class
        public int getSenderId() { return senderId; }                   //Get sender Id
        public int getCardNo() { return cardNo; }                       //Get card number
        public int getNoOfChicken() { return noOfChicken; }             //Get number of chickens
        public int getChickensInStock() { return chickensInStock; }     //Get number of chickens in stock
        public DateTime getTimeStamp() { return timeStamp; }            //Get time stamp

        //Public setters for the varies variables in this class
        public void setSenderId(int senderId) { this.senderId = senderId; }             //Set sender ID
        public void setCardNo(int cardNo) { this.cardNo = cardNo; }                     //Set card number
        public void setNoOfChicken(int noOfChicken) { this.noOfChicken = noOfChicken; } //Set # of chickens
        public void setChickensInStock(int chickensInStock) { this.chickensInStock = chickensInStock; } //Set # of chickens in stock
        public void setTimeStamp(DateTime timeStamp) { this.timeStamp = timeStamp; }    //Set the time stamp
        
        //Variables in the class
        private int senderId { get; set; }
        private int cardNo { get; set; }
        private int noOfChicken { get; set; }
        private int chickensInStock { get; set; }
        private DateTime timeStamp { get; set; }
        private ChickenFarm Chickens { get; set; }
        private MultiCellBuffer Buffer { get; set; }
        private static Random ran = new Random();
        
        //Initialize Retailer class
        public Retailer(MultiCellBuffer buffer, ChickenFarm chicken, int storeID) {
            chicken.PriceChangeHandler += retailerFunc;                 //Event Subscription for PriceChangeEvent 
            Buffer = buffer;
            senderId = storeID;
            cardNo = ran.Next(1000, 3000);                              //Generates a random card number between 1000-3000
            chickensInStock = 30;                                       //Start each retailer with 30 chickens in stock
        }
        //Retailer method to determine if chickens need to be ordered. If chickens in stock is less than 70 order more
        public void retailerFunc(double newPrice) {
            if (chickensInStock < 70) {
                int noOfChickens = ran.Next(50, 100);                               //Random number of chickens to order
                chickensInStock += noOfChickens;                                    //Calculate chickens in stock
                OrderClass order = new OrderClass(senderId, cardNo, noOfChickens);  //OrderClass Object to be encoded
                string encoded = Encoder(order);                                    //Encodes the OrderClass object
                Buffer.setOneCell(this, encoded);                                   //Send encoded string to the buffer
                Console.WriteLine("-Store {0} has requested a new order at {1}", senderId, order.getTimeStamp());

            }
            if (chickensInStock > 0) {      //Statement to check if the retailer has any chickens in stock
                chickensInStock -= 40;      //Decrement the number of chickens in stock
                if (chickensInStock < 0)    //Statement so that there will never be negative chickens instock value
                    chickensInStock = 0;
            }
        }
        //Encodes the OrderClass object into a string seperation methods by ',' then returns it
        public static string Encoder(OrderClass order) {
            string encoded = string.Format("{0},{1},{2},{3}", order.getSenderId(), order.getCardNo(),
                             order.getNoOfChickens(), order.getTimeStamp().ToString("O"));
            return encoded;
        }
        //Used to display order information if the retailer's credit card is accepted
        public void RetailerResponse(OrderClass order, double orderTotal, bool validCard) {
            if (validCard) {
                var processTime = DateTime.Now - order.getTimeStamp();
                Console.WriteLine(string.Format("~Store {0} your order is now complete: " +
                    "The total charges for\n{1} chickens with 8.5% tax and $0.70 S&H per chicken is " +
                    "{2:C}\nProcess time: {3}\n", order.getSenderId(), order.getNoOfChickens(), orderTotal, processTime));
            }
            else {  //Displays message if the retailer passes an incorrect credit card number
                Console.WriteLine("Store {0} has entered an invalid credit card number, please try again.", senderId);                
            }
        }


    }
}
